using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    public partial class ColdStatsForm : Form
    {
        public ColdStatsForm()
        {
            InitializeComponent();

            fillDGV();
        }

        void fillDGV()
        {
            DataTable DT = _ELEMENTS.getColdStats(dTPFrom.Value, dTPTo.Value);

            DT.Columns[0].ColumnName = "Обозначение";
            //DT.Columns[0].ColumnName = "Обозначение";
            //DT.Columns[0].ColumnName = "Обозначение";

            dGV.DataSource = DT;
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fillDGV();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            fillDGV();
        }
    }
}