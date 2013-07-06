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
    /// Класс статистики по текущим элементам
    /// </summary>
    public partial class HotStatsForm : Form
    {
        public HotStatsForm()
        {
            InitializeComponent();

            DataSet DS = SQLOracle.getDS("SELECT t.name, element_title, SUM(elements_count), t.nalichi - SUM(elements_count) FROM USP_HOT_STATS u inner join DB_DATA t on u.element_title=t.obozn GROUP BY ELEMENT_title, t.name, t.nalichi");
            DS.Tables[0].Columns[0].ColumnName = "Наименование";
            DS.Tables[0].Columns[1].ColumnName = "Обозначение";
            DS.Tables[0].Columns[2].ColumnName = "Количество недоступных";
            DS.Tables[0].Columns[3].ColumnName = "Количество на складе";

            dGVElements.DataSource = DS.Tables[0];

            dGVElements.Columns[0].Width = 326;

            DataTable DT = DS.Tables[0];
        }

        private void dGVElements_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string cell = (sender as DataGridView).Rows[(sender as DataGridView).CurrentCell.RowIndex].Cells[1].Value.ToString();
            using (MoreStatsForm form = new MoreStatsForm(cell))
            {
                form.ShowDialog();
            }
        }

        void ExportDGVToExcel(DataGridView dgv)
        {
            ExcelClass InformationAboutElements = new ExcelClass();

            Font HeadFont = new Font(" Times New Roman ", 12.0f, FontStyle.Bold);


            int iterator = 0;

            try
            {
                char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                InformationAboutElements.NewDocument();
                InformationAboutElements.AddNewPageAtTheStart("Данные");

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {

                        InformationAboutElements.SelectCells(alpha[iterator] + (1).ToString(), Type.Missing);
                        InformationAboutElements.SetFont(HeadFont, 0);
                        InformationAboutElements.SetBorderStyle(0, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);

                        InformationAboutElements.WriteDataToCell(dgv.Columns[i].HeaderText);

                        for (int j = 0; j < dgv.Rows.Count; j++)
                        {

                            InformationAboutElements.SelectCells(alpha[iterator] + (j + 2).ToString(), Type.Missing);
                            InformationAboutElements.SetFont(HeadFont, 0);
                            InformationAboutElements.SetBorderStyle(0, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
                            InformationAboutElements.setAutoFit(alpha[iterator] + (j + 2).ToString());
                            InformationAboutElements.WriteDataToCell(dgv[i, j].Value.ToString());
                        }

                        if (dgv[i, 0].Value.ToString().Length > dgv.Columns[i].HeaderText.Length)
                        {
                            InformationAboutElements.setAutoFit(alpha[iterator] + (2).ToString());
                        }
                        else
                        {
                            InformationAboutElements.setAutoFit(alpha[iterator] + (1).ToString());
                        }


                        iterator++;
                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }
            finally
            {

                InformationAboutElements.Visible = true;
                InformationAboutElements.Dispose();
                HeadFont.Dispose();

            }

        }

        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dGVElements.RowCount > 0)
            {
                ExportDGVToExcel(dGVElements);
            } 
        }

    }
}