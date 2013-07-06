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
    /// Форма редактирования состава сборки при нехватке элементов на складе УСПО
    /// </summary>
    public partial class fEditAssembly : Form
    {
        int _tempAssId = 0;

        Dictionary<string, string> _Elements;


        public fEditAssembly(Dictionary<string, string> Elements)
        {
            InitializeComponent();

            _Elements = Elements;

            Data.ElemsNEventHandler = new Data.MyEvent(_addElement);
        }

        void _addElement(object elemN)
        {
            string title = dGVElements["Обозначение", dGVElements.CurrentCell.RowIndex].Value.ToString();

            _writeElement(title, elemN.ToString());

            _updateControls();
        }

        void _writeTempElements()
        {
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            string cmdInsert = "insert into USP_ASSEMBLY_ELEMENTS (ASSEMBLY_ID, ELEMENT_NUM, ELEMENTS_COUNT) values (:ASSEMBLY_ID, :ELEMENT_NUM, :ELEMENTS_COUNT)";

            foreach (KeyValuePair<string, string> Pair in _Elements)
            {
                ParamsDict.Add("ASSEMBLY_ID", _tempAssId.ToString());
                ParamsDict.Add("ELEMENT_NUM", Pair.Key);
                ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                SQLOracle.insert(cmdInsert, ParamsDict);
                ParamsDict.Clear();
            }
        }
        void _deleteTempElements()
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", _tempAssId.ToString());

            string cmdDelete = "delete from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID";
            SQLOracle.delete(cmdDelete, Dict);
        }

        void _writeElement(string title, string count)
        {
            Dictionary<string, string> Parametrs = new Dictionary<string, string>();
            Parametrs.Add("ASSEMBLY_ID", _tempAssId.ToString());
            Parametrs.Add("ELEMENT_NUM", title);
            Parametrs.Add("ELEMENTS_COUNT", count);

            string cmdInsert = "insert into USP_ASSEMBLY_ELEMENTS (ASSEMBLY_ID, ELEMENT_NUM, ELEMENTS_COUNT) values (:ASSEMBLY_ID, :ELEMENT_NUM, :ELEMENTS_COUNT)";
            SQLOracle.insert(cmdInsert, Parametrs);
        }
        void _deleteElement(string title)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("TITLE", title);
            Dict.Add("ID", _tempAssId.ToString());

            string cmdDelete = "delete from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID and ELEMENT_NUM = :TITLE";
            SQLOracle.delete(cmdDelete, Dict);
        }

        void _paintRows()
        {
            for (int i = 0; i < dGVFirstElements.RowCount; i++)
            {
                string title = dGVFirstElements["Обозначение", i].Value.ToString();
                int count = Int32.Parse(dGVFirstElements["Кол-во", i].Value.ToString());

                int free = _ELEMENTS.getAllN(title) - _ELEMENTS.getBusyN(title);

                if (_ELEMENTS.existElement(title))
                {
                    if (free < count)
                    {
                        dGVFirstElements.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        dGVFirstElements.Rows[i].Cells[1].Style.BackColor = Color.Red;
                    }
                }
            }
        }

        void _updateControls()
        {
            dGVFirstElements.DataSource = _ASSEMBLY_ELEMENTS.getElementsDT(_tempAssId);
            dGVFirstElements.Columns[0].Width = 128;
            dGVFirstElements.Columns[1].Width = 40;

            _paintRows();

            if (dGVFirstElements.RowCount <= 0)
            {
                bttnDelEl.Enabled = false;
                bttnOK.Enabled = false;
            }
            else
            {
                bttnDelEl.Enabled = true;
                bttnOK.Enabled = true;
            }
        }

        //------------------------------------------------------------------------

        private void fEditAssembly_Load(object sender, EventArgs e)
        {
            _deleteTempElements();
            _writeTempElements();
            _updateControls();
        }

        private void tBAddElement_TextChanged(object sender, EventArgs e)
        {
            string elTitle = (sender as TextBox).Text;

            dGVElements.DataSource = _ELEMENTS.getElements_Title(elTitle);
            dGVElements.Columns[0].Width = 90;
            dGVElements.Columns[1].Width = 140;
            dGVElements.Columns[2].Width = 80;
        }

        private void bttnDelEl_Click(object sender, EventArgs e)
        {
            string elementTitle = dGVFirstElements["Обозначение", dGVFirstElements.CurrentCell.RowIndex].Value.ToString();

            if ((elementTitle != null) && (elementTitle != ""))
            {
                _deleteElement(elementTitle);
                _updateControls(); 
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            _deleteTempElements();
        }

        private void fEditAssembly_FormClosed(object sender, FormClosedEventArgs e)
        {
            _deleteTempElements();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            bool notEnoughElems = false; //недостаточно кол-ва элементов
            for (int i = 0; i < dGVFirstElements.RowCount; i++)
            {
                if (dGVFirstElements.Rows[i].Cells[0].Style.BackColor == Color.Red)
                {
                    
                    notEnoughElems = true;
                    break;
                }               
            }
            if (notEnoughElems)
            {
                MessageBox.Show("Для запуска листа заказа не хватает элементов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _Elements.Clear();
                for (int i = 0; i < dGVFirstElements.RowCount; i++)
                {
                    string key = dGVFirstElements[0, i].Value.ToString();
                    string value = dGVFirstElements[1, i].Value.ToString();
                    _Elements.Add(key, value);
                }

                _deleteTempElements();
                Data.ElemsAfterEditingAss(_Elements);
                this.Close();
            }
        }

        private void dGVElements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellTitle = (sender as DataGridView)["Обозначение", (sender as DataGridView).CurrentCell.RowIndex].Value.ToString();

            bool isEqual = false;
            for (int i = 0; i < dGVFirstElements.RowCount; i++)
            {
                string title = dGVFirstElements["Обозначение", i].Value.ToString();
                if (cellTitle == title)
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
                int row = (sender as DataGridView).CurrentCell.RowIndex;
                string sMasElement = (sender as DataGridView)["Кол-во на складе", row].Value.ToString();
                int nMaxElement = Int32.Parse(sMasElement);

                using (ElementCountForm form = new ElementCountForm(nMaxElement))
                {
                    form.ShowDialog();
                }
            }
        }

    }
}