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
        public ViewAct()
        {
            InitializeComponent();
        }

        private void актыНаСписаниеToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void ViewAct_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update(); 
         
            this.dataGridView1.DataSource = SQLOracle.getDS("Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss'))").Tables[0];
            
         
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

        private void filterActs()
        {
            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();
            string QueryString = "Select N_ACT AS \"Номер акта\", DATA_SOST AS \"Дата составления\", COD_VIDA_OPER AS \"Код вида операций\", STRUCT_PODR AS \"Структурное подразделение\", NOMER_CEHA AS \"Номер цеха\", VID_DEYAT AS \"Вид деятельности\", CORRESP_SCHET AS \"Кор счет\", COD_ZATRAT AS \"Код затрат\" FROM USP_ACTNASPISANIE_HEAD WHERE (DATA_SOST <= to_date( '" + dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) AND (DATA_SOST >= to_date( '" + dateTimePicker1.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) ";
         
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                QueryString += " AND N_ACT = :N_ACT";
                Parameters.Add("N_ACT"); Values.Add(textBox1.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox2), " ") != 0)
            {
                QueryString += " AND COD_VIDA_OPER = :COD_VIDA_OPER";
                Parameters.Add("COD_VIDA_OPER"); Values.Add(textBox2.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                QueryString += " AND STRUCT_PODR = :STRUCT_PODR";
                Parameters.Add("STRUCT_PODR"); Values.Add(textBox3.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                QueryString += "AND NOMER_CEHA :NOMER_CEHA,";
                Parameters.Add("NOMER_CEHA"); Values.Add(textBox4.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                QueryString += "AND VID_DEYAT = :VID_DEYAT ";
                Parameters.Add("VID_DEYAT"); Values.Add(textBox5.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                QueryString += " AND CORRESP_SCHET = :CORRESP_SCHET";
                Parameters.Add("CORRESP_SCHET"); Values.Add(textBox6.Text);
            }
            else if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                QueryString += " AND COD_ZATRAT = :COD_ZATRAT ";
                Parameters.Add("COD_ZATRAT"); Values.Add(textBox7.Text);
            }

            this.dataGridView1.DataSource = SQLOracle.ParamQuerySelect(QueryString, Parameters, Values).Tables[0];

            
        }
      

      
    }
}