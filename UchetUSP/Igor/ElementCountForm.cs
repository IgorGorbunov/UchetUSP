using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    public partial class ElementCountForm : Form
    {
        int _nMax;

        /// <summary>
        /// Конструктор с параметром максимально возможного кол-ва элемента
        /// </summary>
        /// <param name="nMax">Максимально возможное кол-во элемента</param>
        public ElementCountForm(int nMax)
        {
            this._nMax = nMax;
            InitializeComponent();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            if (nUDElementsN.Value <= _nMax)
            {
                Data.ElemsNEventHandler(nUDElementsN.Value);
                this.Close();
            }
            else
            {
                MessageBox.Show("Недостаточно элементов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}