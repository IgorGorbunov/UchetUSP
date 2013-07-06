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
    /// Форма принятия сборки на склад УСПО
    /// </summary>
    public partial class fGetAssembly : Form
    {
        string _orderNum;

        byte _page;
        byte _lastPage;

        bool _isBttnOk;

        Dictionary<string, string> D;

        public fGetAssembly(string num)
        {
            InitializeComponent();

            _page = 0;
            _lastPage = 1;

            _isBttnOk = false;

            D = new Dictionary<string, string>();

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
            lblHeader.Text = "Введите данные принятия сборки УСПО";
            pnlHeader.Visible = true;

            bttnNext.Enabled = true; //при переходе со след. страницы назад

            tBCustomerSurname.Text = AssemblyOrders.getCustomerSurname(_orderNum);
            tBCreatorSurname.Text = AssemblyOrders.getCreatorSurname(_orderNum);

            _setBorderPages(1);
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
            _setD("ASSEMBLY_RETURN_GIVER_SURNAME", tBCustomerSurname.Text);
            _setD("ASSEMBLY_RETURN_GETER_SURNAME", tBCreatorSurname.Text);
        }

        void _writeToDB()
        {
            //REFACTORME дубляж кода
            string cmdUpdate = "update USP_ASSEMBLY_ORDERS set ";
            foreach (KeyValuePair<string, string> pair in D)
            {
                cmdUpdate += pair.Key;
                cmdUpdate += " = '";
                cmdUpdate += pair.Value;
                cmdUpdate += "', ";
            }
            cmdUpdate = cmdUpdate.Remove(cmdUpdate.Length - 2, 1); // удаляем последнюю запятую, но оставляем пробел
            cmdUpdate += "where NUM = '";
            cmdUpdate += _orderNum + "'";

            SQLOracle.update(cmdUpdate);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set ASSEMBLY_RETURN_DATE = " + SQLOracle.getDateTime(dTPCreatorGet.Value) + " where NUM = '" + _orderNum + "'";
            SQLOracle.update(cmdUpdate);

            cmdUpdate = "update USP_ASSEMBLY_ORDERS set DOC_STATUS = 4 where NUM = '" + _orderNum + "'";
            SQLOracle.update(cmdUpdate);

            _deleteFromHot();
        }

        void _deleteFromHot()
        {
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            ParamsDict.Add("ORDER_NUM", _orderNum);

            SQLOracle.delete("delete from USP_HOT_STATS where ORDER_NUM = :ORDER_NUM", ParamsDict);
        }

        void _setD(string key, string value)
        {
            if (D.ContainsKey(key))
                D[key] = value;
            else
                D.Add(key, value);
        }

        //----------------------------------------------------------------------

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bttnNext_Click(object sender, EventArgs e)
        {
            if (_isBttnOk)
            {
                if (dTPCreatorGet.Value.ToShortDateString() == dTPCustomerReturn.Value.ToShortDateString())
                {
                    _createDictionary();
                    _writeToDB();
                    MessageBox.Show("Сборка принята!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Ошибка! Даты не могут быть различными!",
                                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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