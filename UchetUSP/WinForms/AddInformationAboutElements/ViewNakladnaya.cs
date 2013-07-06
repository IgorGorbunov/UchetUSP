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
    public partial class ViewNacladnaya : Form
    {
       
        private int thisStatus = 0;

        /// <summary>
        /// статус формы вывода накладных;
        /// </summary>
        /// <param name="statusOfNakl">      
        ///1- Просмотр информации.
        ///2- Редактировать информацию.
        ///3- Удалить информацию.</param>
        /// <returns></returns>
        public ViewNacladnaya(int statusOfNakl)
        {
            InitializeComponent();

            thisStatus = statusOfNakl;

            setStatus(statusOfNakl);
        }

        private void setStatus(int statusOfNakl)
        {
            if (statusOfNakl == 1)
            {
                this.Text = "Просмотр накладных!";

            }else if(statusOfNakl == 2)
            {
                this.Text = "Редактирование накладных!";
            }
            else if (statusOfNakl == 3)
            {
                this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
                this.Text = "Удаление накладных!";
            }            
        }

        private void актыНаСписаниеToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

       
      
        private void ViewAct_Load(object sender, EventArgs e)
        {

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();

            UpdateData();
                    
        }
        //Обновление данных в dataGrid
        private void UpdateData()
        {

            this.dataGridView1.DataSource = SQLOracle.getDS("Select NOMER_TREBOV_NAKLADNOI AS \"Номер требования-накладной\", " +
                " DATA_SOSTAVLENIYA AS \"Дата составления\", " +
                " COD_VIDA_OPER AS \"Код вида операции\", " +
                " OTPRAV_STRUCT_PODR AS \"(Отп)Структурное подразделение\", " +
                " OTPRAV_VID_DEYAT AS \"(Отп)Вид деятельности\", " +
                " SHIFR_POLUCH AS \"Шифр получателя\", " +
                " SHIFR_POTREB AS \"Шифр потребителя\", " +
                " VID_DEYAT AS \"Вид деятельности\", " +              
                " UCH_ED_VIP AS  \"Учет единица выпуска продукции\", " +
                " PORYAD_NUM AS \"Порядковый номер по картотеке\" " +
                " FROM KTC.USP_NAKLADNAYA_HEAD WHERE (DATA_SOSTAVLENIYA <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                " AND (DATA_SOSTAVLENIYA >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))").Tables[0];
            
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

        

       

        //фильтрация вывода данных 
        private void filterActs()
        {
            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();

            string QueryString = "Select NOMER_TREBOV_NAKLADNOI AS \"Номер требования-накладной\", " +
                " DATA_SOSTAVLENIYA AS \"Дата составления\", " +
                " COD_VIDA_OPER AS \"Код вида операции\", " +
                " OTPRAV_STRUCT_PODR AS \"(Отп)Структурное подразделение\", " +
                " OTPRAV_VID_DEYAT AS \"(Отп)Вид деятельности\", " +
                " SHIFR_POLUCH AS \"Шифр получателя\", " +
                " SHIFR_POTREB AS \"Шифр потребителя\", " +
                " VID_DEYAT AS \"Вид деятельности\", " +             
                " UCH_ED_VIP AS  \"Учет единица выпуска продукции\", " +
                " PORYAD_NUM AS \"Порядковый номер по картотеке\" " +
                " FROM KTC.USP_NAKLADNAYA_HEAD WHERE (DATA_SOSTAVLENIYA <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                " AND (DATA_SOSTAVLENIYA >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))";
         
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                QueryString += " AND (NOMER_TREBOV_NAKLADNOI LIKE :NOMER_TREBOV_NAKLADNOI)";
                Parameters.Add("NOMER_TREBOV_NAKLADNOI"); Values.Add(textBox1.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox2), " ") != 0)
            {
                QueryString += " AND (COD_VIDA_OPER LIKE :COD_VIDA_OPER) ";
                Parameters.Add("COD_VIDA_OPER"); Values.Add(textBox2.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                QueryString += " AND (OTPRAV_STRUCT_PODR LIKE :OTPRAV_STRUCT_PODR)";
                Parameters.Add("OTPRAV_STRUCT_PODR"); Values.Add(textBox3.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                QueryString += "AND (OTPRAV_VID_DEYAT LIKE :OTPRAV_VID_DEYAT)";
                Parameters.Add("OTPRAV_VID_DEYAT"); Values.Add(textBox4.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                QueryString += "AND (SHIFR_POLUCH LIKE :SHIFR_POLUCH) ";
                Parameters.Add("SHIFR_POLUCH"); Values.Add(textBox5.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                QueryString += " AND (SHIFR_POTREB LIKE :SHIFR_POTREB) ";
                Parameters.Add("SHIFR_POTREB"); Values.Add(textBox6.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                QueryString += " AND (VID_DEYAT LIKE :VID_DEYAT) ";
                Parameters.Add("VID_DEYAT"); Values.Add(textBox7.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
            {
                QueryString += " AND (UCH_ED_VIP LIKE :UCH_ED_VIP) ";
                Parameters.Add("UCH_ED_VIP"); Values.Add(textBox8.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
            {
                QueryString += " AND (PORYAD_NUM LIKE :PORYAD_NUM) ";
                Parameters.Add("PORYAD_NUM"); Values.Add(textBox9.Text);
            }
          
            this.dataGridView1.DataSource = SQLOracle.ParamQuerySelect(QueryString, Parameters, Values).Tables[0];
            this.dataGridView1.Update();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (thisStatus == 1)
            {
                using (WinForms.AddInformationAboutElements.AddNakladnaya NewAct = new UchetUSP.WinForms.AddInformationAboutElements.AddNakladnaya(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
                {
                    NewAct.ShowDialog();
                }
            }
            else if (thisStatus == 2)
            {
                using (WinForms.AddInformationAboutElements.AddNakladnaya NewAct = new UchetUSP.WinForms.AddInformationAboutElements.AddNakladnaya(2, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
                {
                    NewAct.ShowDialog();
                }

                UpdateData();

            }
            else if (thisStatus == 3)
            {
                using (WinForms.AddInformationAboutElements.AddNakladnaya NewAct = new UchetUSP.WinForms.AddInformationAboutElements.AddNakladnaya(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
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
            using (WinForms.AddInformationAboutElements.AddNakladnaya NewAct = new UchetUSP.WinForms.AddInformationAboutElements.AddNakladnaya(1, dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString()))
            {
                NewAct.ShowDialog();
            }
        }

        //удаление элемента из БД
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Выдействительно хотить удалить накладную?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLOracle.delete("DELETE FROM KTC.USP_NAKLADNAYA_HEAD WHERE NOMER_TREBOV_NAKLADNOI = " + dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
                SQLOracle.delete("DELETE FROM KTC.USP_NAKLADNAYA_DATA WHERE NOMER_TREBOV_NAKLADNOI = " + dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
               
                UpdateData();
            }
        }
        //блокировка не  числовых операций
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            filterActs();
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