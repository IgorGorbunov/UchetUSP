using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    public partial class ElementsDestinationForm : Form
    {
        public ElementsDestinationForm()
        {
            InitializeComponent();

            _setDGVDestColumns();
        }

        void _setDGVDestColumns()
        {
            string name;

            name = "Обозначение элемента";
            dGVDest.Columns.Add(name, name);

            name = "Местонахождение элемента";
            dGVDest.Columns.Add(name, name);
        }

        private void tBElemTitle_TextChanged(object sender, EventArgs e)
        {
            string elTitle = (sender as TextBox).Text;

            dGVElems.DataSource = _ELEMENTS.getElementsDestination(elTitle);
            dGVElems.Columns[0].Width = 90;
            dGVElems.Columns[1].Width = 140;
            dGVElems.Columns[2].Width = 80;
        }

        private void dGVElems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string title = dGVElems["Обозначение", dGVElems.CurrentRow.Index].Value.ToString();
            string dest = dGVElems["Местонахождение", dGVElems.CurrentRow.Index].Value.ToString();
            dGVDest.Rows.Add(title, dest);
        }
    }
}