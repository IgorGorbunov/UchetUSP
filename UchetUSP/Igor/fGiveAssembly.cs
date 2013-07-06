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
    /// Форма выдачи сборки заказчику
    /// </summary>
    public partial class fGiveAssembly : Form
    {
        string _orderNum;

        byte _page;
        byte _lastPage;

        bool _isBttnOk;

        Dictionary<string, string> _D, Dexcel;

        /// <summary>
        /// Создает форму по номеру листа заказа
        /// </summary>
        /// <param name="num">номер листа заказа</param>
        public fGiveAssembly(string num)
        {
            InitializeComponent();

            _page = 0;
            _lastPage = 1;

            _isBttnOk = false;

            _D = new Dictionary<string, string>();
            Dexcel = new Dictionary<string, string>();

            _orderNum = num;
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
            lblHeader.Text = "Введите данные выдачи сборки УСПО";
            pnlHeader.Visible = true;

            bttnNext.Enabled = true; //при переходе со след. страницы назад

            _setBorderPages(1);
            tBGetterPosition.Text = AssemblyOrders.getCustomerPosition(_orderNum);

            string customerSurname = AssemblyOrders.getCustomerSurname(_orderNum);
            tBGetterSurname.Text = customerSurname;
            tBGiverSurname.Text = AssemblyOrders.getCreatorSurname(_orderNum);

            _setDict(Dexcel, "CUSTOMER_SURNAME", customerSurname);
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
            }
        }

        void _createDictionary()
        {
            _setBothDict("ASSEMBLY_GETER_POSITION", tBGetterPosition.Text);
            _setBothDict("ASSEMBLY_GETER_SURNAME", tBGetterSurname.Text);
            _setBothDict("ASSEMBLY_GIVER_SURNAME", tBGiverSurname.Text);
            _setBothDict("ASSEMBLY_PLANNED_RETURN_DATE", dTPPlanedReturnDate.Value.ToShortDateString());

            _setDict(Dexcel, "ASSEMBLY_DELIVERY_DATE", dTPDeliveryDate.Value.ToShortDateString());
            //_setDict(D, "ASSEMBLY_DELIVERY_DATE", dTPDeliveryDate.Value.ToString());

            int assNum = AssemblyOrders.getAssNum(_orderNum);
            if (assNum != 0)
            {
                _setDict(Dexcel, "ASSEMBLY_NUM", assNum.ToString()); 
            }
            _setDict(Dexcel, "NUM", _orderNum.ToString());
            _setDict(Dexcel, "WORKSHOP_CODE", AssemblyOrders.getWorkshopCode(_orderNum).ToString());

            if (AssemblyOrders.isTZ(_orderNum))
            {
                string idTZ = AssemblyOrders.getTZId(_orderNum);
                _setDict(Dexcel, "PRODUCT_CODE", AssemblyOrders.getProductCode_TZ(idTZ));
                _setDict(Dexcel, "PART_TITLE", AssemblyOrders.getPartTitle_TZ(idTZ));
            }
            else
            {
                _setDict(Dexcel, "PRODUCT_CODE", AssemblyOrders.getProductCode(_orderNum).ToString());
                _setDict(Dexcel, "PART_TITLE", AssemblyOrders.getPartTitle(_orderNum));
            }

            _setDict(Dexcel, "PART_NAME", AssemblyOrders.getPartName(_orderNum));
            _setDict(Dexcel, "TZ_NUM", AssemblyOrders.getTZnumber(_orderNum));
            _setDict(Dexcel, "TECH_OPERATION_NAME", AssemblyOrders.getTechOperationName(_orderNum));
            _setDict(Dexcel, "PARTS_COUNT", AssemblyOrders.getPartsCount(_orderNum).ToString());

            _setDict(Dexcel, "CREATION_DATE", AssemblyOrders.getCreationDate(_orderNum).ToShortDateString());
            _setDict(Dexcel, "DEMAND_DATE", AssemblyOrders.getDemandDate(_orderNum).ToShortDateString());
            _setDict(Dexcel, "ASSEMBLY_CREATOR_SURNAME", AssemblyOrders.getAssCreatorSurname(_orderNum));
        }

        void _writeToDB()
        {
            //REFACTORME дубляж кода
            string cmdUpdate = "update USP_ASSEMBLY_ORDERS set ";
            foreach (KeyValuePair<string, string> pair in _D)
            {
                cmdUpdate += pair.Key;
                cmdUpdate += " = :";
                cmdUpdate += pair.Key;
                cmdUpdate += ", ";
            }
            cmdUpdate = cmdUpdate.Remove(cmdUpdate.Length - 2, 1); // удаляем последнюю запятую, но оставляем пробел
            cmdUpdate += "where NUM = '";
            cmdUpdate += _orderNum + "'";

            SQLOracle.update(cmdUpdate, _D);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set ASSEMBLY_DELIVERY_DATE = " + 
                SQLOracle.getDateTime(dTPDeliveryDate.Value) +
                " where NUM = '" +
                _orderNum + "'";

            SQLOracle.update(cmdUpdate);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set DOC_STATUS = 3 where NUM = '" + _orderNum + "'";
            SQLOracle.update(cmdUpdate);
        }

        void _generateOrder()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            int assId = AssemblyOrders.getAssId(_orderNum);
            dict = _ASSEMBLIES.getElements(assId);

            xlsAssemblyOrder2 order = new xlsAssemblyOrder2(Dexcel, dict);
            order.createDocument();
        }

        void _setDict(Dictionary<string, string> Dict, string key, string value)
        {
            if (Dict.ContainsKey(key))
                Dict[key] = value;
            else
                Dict.Add(key, value);
        }
        void _setBothDict(string key, string value)
        {
            _setDict(_D, key, value);
            _setDict(Dexcel, key, value);
        }
        //-------------------------------------------------------------

        
        //-------------------------------------------------------------

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bttnNext_Click(object sender, EventArgs e)
        {
            if (_isBttnOk)
            {
                _createDictionary();
                _writeToDB();
                MessageBox.Show("Сборка выдана!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _generateOrder();
                this.Close();
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
            }
        }

    }
}