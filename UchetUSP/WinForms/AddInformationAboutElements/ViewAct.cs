using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;

namespace UchetUSP.WinForms.AddInformationAboutElements
{
    public partial class ViewAct : Form
    {
       
        private int thisStatus = 0;

        /// <summary>
        /// статус формы вывода акта на списание;
        /// </summary>
        /// <param name="statusOfNakl">      
        ///1- Просмотр информации.
        ///2- Редактировать информацию.
        ///3- Удалить информацию.</param>
        /// <returns></returns>
        public ViewAct(int statusOfNakl)
        {
            InitializeComponent();

            thisStatus = statusOfNakl;

            setStatus(statusOfNakl);
        }

        private void setStatus(int statusOfNakl)
        {
            if (statusOfNakl == 1)
            {
                this.Text = "Просмотр актов на списание!";

            }else if(statusOfNakl == 2)
            {
                this.Text = "Редактирование актов на списание!";
            }
            else if (statusOfNakl == 3)
            {
                this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
                this.Text = "Удаление актов на списание!";
            }            
        }

        private void актыНаСписаниеToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

       
      
        private void ViewAct_Load(object sender, EventArgs e)
        {

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update(); 
         
            this.dataGridView1.DataSource = SQLOracle.getDS("Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM KTC.USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))").Tables[0];
            
         
        }


        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {


            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала должна быть меньше даты конца!");
                this.dateTimePicker1.Value = this.dateTimePicker2.Value;
                this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMonths(-1);
                filterActs();
            }
        
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("Дата начала должна быть меньше даты конца!");
                this.dateTimePicker2.Value = this.dateTimePicker1.Value;
                this.dateTimePicker2.Value = this.dateTimePicker2.Value.AddMonths(1);
                filterActs();
            }

            
        }       

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            filterActs();
        }

        //фильтрация вывода данных 
        private void filterActs()
        {
            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();

            string QueryString = "Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM KTC.USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) ";
         
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                QueryString += " AND (N_ACT LIKE :N_ACT)";
                Parameters.Add("N_ACT"); Values.Add(textBox1.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox2), " ") != 0)
            {
                QueryString += " AND (COD_VIDA_OPER LIKE :COD_VIDA_OPER) ";
                Parameters.Add("COD_VIDA_OPER"); Values.Add(textBox2.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                QueryString += " AND (STRUCT_PODR LIKE :STRUCT_PODR)";
                Parameters.Add("STRUCT_PODR"); Values.Add(textBox3.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                QueryString += "AND (NOMER_CEHA LIKE :NOMER_CEHA)";
                Parameters.Add("NOMER_CEHA"); Values.Add(textBox4.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                QueryString += "AND (VID_DEYAT LIKE :VID_DEYAT) ";
                Parameters.Add("VID_DEYAT"); Values.Add(textBox5.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                QueryString += " AND (CORRESP_SCHET LIKE :CORRESP_SCHET) ";
                Parameters.Add("CORRESP_SCHET"); Values.Add(textBox6.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                QueryString += " AND (COD_ZATRAT LIKE :COD_ZATRAT) ";
                Parameters.Add("COD_ZATRAT"); Values.Add(textBox7.Text);
            }

          
            this.dataGridView1.DataSource = SQLOracle.ParamQuerySelect(QueryString, Parameters, Values).Tables[0];
            this.dataGridView1.Update();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (thisStatus == 1)
            {
                using (WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
                {
                    NewAct.ShowDialog();
                }
            }
            else if (thisStatus == 2)
            {
                using (WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(2, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
                {
                    NewAct.ShowDialog();
                }
                this.dataGridView1.DataSource = SQLOracle.getDS("Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM KTC.USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))").Tables[0];
            
            }
            else if (thisStatus == 3)
            {
                using (WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
                {
                    NewAct.ShowDialog();
                }
            } 

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripDelete.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }


        private void просмотретьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
            {
                NewAct.ShowDialog();
            }
        }

        //удаление элемента из БД
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выдействительно хотить удалить акт?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLOracle.delete("DELETE FROM KTC.USP_ACTNASPISANIE_HEAD WHERE N_ACT = " + dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
                SQLOracle.delete("DELETE FROM KTC.USP_ACTNASPISANIE_DATA_ONE WHERE ACT_NOMER = " + dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
                SQLOracle.delete("DELETE FROM KTC.USP_ACTNASPISANIE_DATA_TWO WHERE ACT_NOMER  = " + dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
                this.dataGridView1.DataSource = SQLOracle.getDS("Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM KTC.USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))").Tables[0];
            
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
                int CurrentCell = 0;
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
                       
                ExportDGVToExcel(this.dataGridView1);             
                
        }





       
      

      
    }
}