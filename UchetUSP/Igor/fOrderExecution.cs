using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    /// <summary>
    /// Форма подтверждения исполнения заказа
    /// </summary>
    public partial class fOrderExecution : Form
    {
        string _orderNum, _assemblyTitle;
        int _nElements;

        byte _page;
        byte _lastPage;

        bool _isBttnOk;
        bool _isWithoutProject = true;

        Dictionary<string, string> D;

        public fOrderExecution(string num)
        {
            InitializeComponent();

            _page = 0;
            _lastPage = 2;

            _isBttnOk = false;

            D = new Dictionary<string, string>();

            _orderNum = num;

            _assemblyTitle = _ASSEMBLIES.getAssemblyTitle_orderNum(_orderNum);

            //c проектированием или состав сборки уже введен
            if (AssemblyOrders.getAssId(_orderNum) != 0)
            {
                _isWithoutProject = false;
                _lastPage--;
            }

            Data.ElemsNEventHandler = new Data.MyEvent(_addElement);
        }

        void _addElement(object elemN)
        {
            string title = dGVElements.Rows[dGVElements.CurrentCell.RowIndex].Cells[0].Value.ToString();
            lBAddedElements.Items.Add(title + " - " + elemN.ToString() + " шт.");
        }

        //изменение главных кнопок
        void _setBorderPages(byte page)
        {
            if (page == 0)
                bttnPrev.Enabled = false;
            else
                bttnPrev.Enabled = true;

            if (page == _lastPage)
            {
                _modifyLastPage();
            }
            else
            {
                bttnNext.Text = "Далее >";
                _isBttnOk = false;
            }
        }

        void _modifyLastPage()
        {
            bttnNext.Text = "Готово";
            _isBttnOk = true;

        }

        void _setPage0()
        {
            pnlHeader.Visible = false;

            _setBorderPages(0);
        }
        void _setPage1()
        {
            lblHeader.Text = "Введите данные исполнения заказа";
            pnlHeader.Visible = true;

            tBSectorNum.Text = AssemblyOrders.getSectorNumSettings();
            tBBrigadierSurname.Text = AssemblyOrders.getBrigadierSurnameSettings();

            bttnNext.Enabled = true; //при переходе со след. страницы назад

            _setBorderPages(1);
        }
        void _setPage2()
        {
            lblHeader.Text = "Добавьте элементы УСП, из которых состоит сборка";

            _setBorderPages(2);
        }

        void _setOkBttn()
        {
            if (_isWithoutProject)
            {
                if (lBAddedElements.Items.Count > 0)
                {
                    _finish();
                }
                else
                {
                    MessageBox.Show("Недостаточно элементов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _finish();
            }
        }

        void _finish()
        {
            _createDictionary();
            _writeToDB();
            MessageBox.Show("Сборка принята!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        //установка необходимой страницы
        void _setNextPage()
        {
            switch (_page)
            {
                case 0:
                    _setPage1();
                    _page++;
                    tabControl1.SelectedIndex = _page;
                    break;
                case 1:

                    _setPage2();
                    _page++;
                    tabControl1.SelectedIndex = _page;
                    break;
            }
        }

        /*//чтение характеристик
        void _getUSPParams()
        {
            tBElementsCount.Text = _ASSEMBLY_ORDERS.getElementsCount(_orderNum).ToString();
            tBStrapsCount.Text = _ASSEMBLY_ORDERS.getStrapsCount(_orderNum).ToString();
            tBNutsCount.Text = _ASSEMBLY_ORDERS.getNutsCount(_orderNum).ToString();
            tBSpecialElementsCount.Text = _ASSEMBLY_ORDERS.getSpecialElementsCount(_orderNum).ToString();
        }
        //запись характеристик
        void _setUSPParams()
        {
            _setD("ASSEMBLY_ELEMENTS_COUNT", tBElementsCount.Text);
            _setD("ASSEMBLY_STRAPS_COUNT", tBStrapsCount.Text);
            _setD("ASSEMBLY_NUTS_COUNT", tBNutsCount.Text);
            _setD("ASSEMBLY_SPECIAL_DOWELS_COUNT", tBSpecialDowelsCount.Text);
            _setD("ASSEMBLY_SPECIAL_ELEMEN_COUNT", tBSpecialElementsCount.Text);
            _setD("ASSEMBLY_DIMENSIONS_COUNT", tBDimensionsCount.Text);
            _setD("ASSEMBLY_DIFFICULTY_GROUP", tBDifficultGroup.Text);
        }*/

        void _setD(string key, string value)
        {
            if (D.ContainsKey(key))
                D[key] = value;
            else
                D.Add(key, value);
        }
        void _setD(string key, object value)
        {
            if (D.ContainsKey(key))
                D[key] = value.ToString();
            else
                D.Add(key, value.ToString());
        }

        void _createDictionary()
        {
            //_setUSPParams();           

            string key;

            key = "ASSEMBLY_SECTOR_NUM";
            _setD(key, tBSectorNum.Text);
            
            key = "ASSEMBLY_NUM";
            _setD(key, tBAssemblyNum.Text);

            key = "ASSEMBLY_CREATOR_SURNAME";
            _setD(key, tBAssemblyCreatorSurname.Text);

            key = "BRIGADIER_SURNAME";
            _setD(key, tBBrigadierSurname.Text);
        }

        void _writeToDB()
        {
            Dictionary<string, string> ElementsDict = new Dictionary<string, string>();
            ElementsDict = _setElements(ElementsDict);

            if (_isWithoutProject)
            {
                int assId = _ASSEMBLY_ELEMENTS.getMaxAssId() + 1;
                _writeElements(assId, ElementsDict);
                _setD("ASSEMBLY_ID", assId);
            }

            string cmdUpdate = "update USP_ASSEMBLY_ORDERS set ";
            foreach (KeyValuePair<string, string> pair in D)
            {
                cmdUpdate += pair.Key;
                cmdUpdate += " = :";
                cmdUpdate += pair.Key;
                cmdUpdate += ", ";
            }
            cmdUpdate = cmdUpdate.Remove(cmdUpdate.Length - 2, 1); // удаляем последнюю запятую, но оставляем пробел
            cmdUpdate += "where NUM = '";
            cmdUpdate += _orderNum + "'";

            SQLOracle.update(cmdUpdate, D);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set ASSEMBLY_CREATION_DATE = " + SQLOracle.getDateTime(dTPCreationDate.Value) + " where NUM = '" + _orderNum + "'";
            SQLOracle.update(cmdUpdate);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set DOC_STATUS = 2" + " where NUM = '" + _orderNum + "'";
            SQLOracle.update(cmdUpdate);

            writeTZUtv(ElementsDict);
        }

        void _writeElementsInTZ(Dictionary<string, string> Dict)
        {
            string TZId = AssemblyOrders.getTZId(_orderNum);

            int position = 1;
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                string name = _ELEMENTS.getName(Pair.Key);

                Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
                ParamsDict.Add("TITLE", Pair.Key);
                ParamsDict.Add("NAME", name);
                ParamsDict.Add("COUNT", Pair.Value);
                ParamsDict.Add("ID_DOC", TZId);
                ParamsDict.Add("POS", position.ToString());

                SQLOracle.update("update USP_TZ_DATA_TP set OBOZN_KOMP = :TITLE, NAIM_KOMP = :NAME, KOL = :COUNT where ID_DOC = :ID_DOC and NUM_PANEL = :POS", ParamsDict);
                position++;
            }
        }

        void writeTZUtv(Dictionary<string, string> Dict)
        {
            if (AssemblyOrders.isTZ(_orderNum))
            {
                string TZId = AssemblyOrders.getTZId(_orderNum);
                int nElements = Instrumentary.getSumListValues(Dict);

                Dictionary<string, string> PDict = new Dictionary<string, string>();
                PDict.Add("TZ_ID", TZId);
                PDict.Add("SUM", nElements.ToString());

                string cmdUpdate = "update USP_TZ_DATA set UTV = 2, HP_KOL_EDEN = :SUM where ID_DOC = :TZ_ID";
                SQLOracle.update(cmdUpdate, PDict);

                _writeElementsInTZ(Dict);
            }
        }

        Dictionary<string, string> _setElements(Dictionary<string, string> Dict)
        {
            if (_isWithoutProject) //без проектирования
            {
                Dict = _fromLBtoDict(Dict);
                _nElements = _getNelements(Dict);
                _setD("ASSEMBLY_ELEMENTS_COUNT", _nElements);
            }
            return Dict;
        }

        void _writeElements(int assId, Dictionary<string, string> ElementsDict)
        {
            _writeAss(assId);

            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            string cmdInsert1 = "insert into USP_ASSEMBLY_ELEMENTS (ASSEMBLY_ID, ELEMENT_NUM, ELEMENTS_COUNT) values (:ASSEMBLY_ID, :ELEMENT_NUM, :ELEMENTS_COUNT)";
            string cmdInsert2 = "insert into USP_HOT_STATS (ORDER_NUM, ELEMENT_TITLE, ELEMENTS_COUNT) values (:ORDER_NUM, :ELEMENT_TITLE, :ELEMENTS_COUNT)";

            foreach (KeyValuePair<string, string> Pair in ElementsDict)
            {
                    ParamsDict.Add("ASSEMBLY_ID", assId.ToString());
                    ParamsDict.Add("ELEMENT_NUM", Pair.Key);
                    ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                    SQLOracle.insert(cmdInsert1, ParamsDict);
                    ParamsDict.Clear();

                ParamsDict.Add("ORDER_NUM", _orderNum);
                ParamsDict.Add("ELEMENT_TITLE", Pair.Key);
                ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                SQLOracle.insert(cmdInsert2, ParamsDict);
                ParamsDict.Clear();
            }
        }

        Dictionary<string, string> _fromLBtoDict(Dictionary<string, string> Dict)
        {
            foreach (string item in lBAddedElements.Items)
            {
                string[] split = item.ToString().Split(' ');
                string title = split[0];
                string count = split[2];

                Dict.Add(title, count);
            }
            return Dict;
        }

        int _getNelements(Dictionary<string, string> Dict)
        {
            int count = 0;
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                count += Int32.Parse(Pair.Value);
            }
            return count;
        }

        void _writeAss(int id)
        {
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            ParamsDict.Add("ID", id.ToString());
            ParamsDict.Add("NUM", _assemblyTitle);
            ParamsDict.Add("ELEMENTS_COUNT", _nElements.ToString());

            string cmdInsert = "insert into USP_ASSEMBLIES (ID, NUM, ELEMENTS_COUNT) values (:ID, :NUM, :ELEMENTS_COUNT)";
            SQLOracle.insert(cmdInsert, ParamsDict);
        }

        //------------------------------------------------------------

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bttnNext_Click(object sender, EventArgs e)
        {
            if (_isBttnOk)
            {
                _setOkBttn();
            }
            else
            {
                _setNextPage();
            }
        }

        private void bttnPrev_Click(object sender, EventArgs e)
        {
            _page--;

            switch (_page)
            {
                case 0:
                    _setPage0();
                    tabControl1.SelectedIndex = _page;
                    break;
                case 1:
                    _setPage1();
                    tabControl1.SelectedIndex = _page;
                    break;
            }
        }

        private void tBAddElement_TextChanged(object sender, EventArgs e)
        {
            string elTitle = (sender as TextBox).Text;

            dGVElements.DataSource = _ELEMENTS.getElements_Title(elTitle);
            dGVElements.Columns[0].Width = 90;
            dGVElements.Columns[1].Width = 140;
            dGVElements.Columns[2].Width = 80;
        }

        private void dGVElements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cell = dGVElements.Rows[dGVElements.CurrentCell.RowIndex].Cells[0].Value.ToString();

            bool isEqual = false;
            foreach (object itm in lBAddedElements.Items)
            {
                string[] split = itm.ToString().Split(' ');
                string title = split[0];

                if (cell.Equals(title))
                {
                    isEqual = true;
                    break;
                }
            }

            if (isEqual)
            {
                MessageBox.Show("Элемент уже добавлен!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int nMaxElement = Int32.Parse(dGVElements.Rows[dGVElements.CurrentCell.RowIndex].Cells[2].Value.ToString());
                using (ElementCountForm form = new ElementCountForm(nMaxElement))
                {
                    form.ShowDialog();
                }
            }
        }

        private void bttnDelEl_Click(object sender, EventArgs e)
        {
            if (lBAddedElements.Text != "")
            {
                lBAddedElements.Items.RemoveAt(lBAddedElements.SelectedIndex);
            }

        }


    }
}