using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;
using UchetUSP.Layout;

namespace UchetUSP.WinForms.OrderList
{
    public partial class FindOL : Form
    {
       
        DataGridView dataGridView1;
        DateTimePicker dateTimePicker1;
        DateTimePicker dateTimePicker2;
        int status;


        /// <summary>
        /// ������ ������ ������ ������
        /// </summary>       
        /// <param name="stat">������ ��������� (1 - �������� ����� ������, 2 - �������� ������, 3 - �������� ������, 4 - ������� ������)</param>
        /// <param name="dtgv1">������� ��� ������</param>
        /// <param name="picker1">������ ���������� ���������</param>
        /// <param name="picker2">����� ���������� ���������</param>
        /// <returns></returns>
        public FindOL(int stat, DataGridView dtgv1, DateTimePicker picker1, DateTimePicker picker2)
        {
            InitializeComponent();
            status = stat;
            initFormSettings();                       
            dataGridView1 = dtgv1;
            dateTimePicker1 = picker1;
            dateTimePicker2 = picker2;           
            this.AND.Checked = true;
            this.Not.Checked = true;
        }


        void initFormSettings()
        {   
           this.Text = "����� ������ ������";   
        }



        void EnableALLCheckBox()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(CheckBox))
                {
                    this.Controls[i].Enabled = true;
                }
            }
        }

        void DisableAllCheckBox()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(CheckBox))
                {
                    if (String.Compare(this.Controls[i].Name, "Not")!=0)
                    { 
                        this.Controls[i].Enabled = false;
                    }
                    
                }
            }
        }

        void UnCheckAllCheckBox()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].GetType() == typeof(CheckBox))
                {
                    ((CheckBox)this.Controls[i]).Checked = false;
                }
            }
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            initSearch();
        }
       

        void BuildStringAND()
        {
            string ANDstring = ""; 

            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();

        
                      
            //����� 
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {    
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.NUM " + GetCheckBoxStatus(textBox1) + " LIKE :NUM) ";
                Parameters.Add("NUM"); Values.Add(textBox1.Text); 
            }
            //����� ���
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.VPP_NUM " + GetCheckBoxStatus(textBox3) + " LIKE :VPP_NUM) ";
                Parameters.Add("VPP_NUM"); Values.Add(textBox3.Text); 
            }
           
            //����� ��
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.TZ_NUM  " + GetCheckBoxStatus(textBox4) + " LIKE :TZ_NUM) ";
                Parameters.Add("TZ_NUM"); Values.Add(textBox4.Text); 
            }
            //����������� ������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.PART_TITLE  " + GetCheckBoxStatus(textBox5) + " LIKE :PART_TITLE) ";
                Parameters.Add("PART_TITLE"); Values.Add(textBox5.Text); 
            }
            //��� ��������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.WORKSHOP_CODE  " + GetCheckBoxStatus(textBox6) + " LIKE :WORKSHOP_CODE) ";
                Parameters.Add("WORKSHOP_CODE"); Values.Add(textBox6.Text);
            }
            //��������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ANDstring += " AND (USP_ASSEMBLY_ORDERS.TECHNOLOG  " + GetCheckBoxStatus(textBox7) + " LIKE :TECHNOLOG) ";
                Parameters.Add("TECHNOLOG"); Values.Add(textBox7.Text);
            }

            GenerateData(ANDstring, ref Parameters, ref Values);
            
        }


        void BuildStringOR()
        {
            string ORstring = "";

            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();


            //����� 
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.NUM " + GetCheckBoxStatus(textBox1) + " LIKE :NUM) OR ";
                Parameters.Add("NUM"); Values.Add(textBox1.Text); 
            }
            //����� ���
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.VPP_NUM " + GetCheckBoxStatus(textBox3) + " LIKE :VPP_NUM) OR ";
                Parameters.Add("VPP_NUM"); Values.Add(textBox3.Text); 
            }

            //����� ��
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.TZ_NUM  " + GetCheckBoxStatus(textBox4) + " LIKE :TZ_NUM) OR ";
                Parameters.Add("TZ_NUM"); Values.Add(textBox4.Text);
            }
            //����������� ������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.PART_TITLE  " + GetCheckBoxStatus(textBox5) + " LIKE :PART_TITLE) OR ";
                Parameters.Add("PART_TITLE"); Values.Add(textBox5.Text); 
            }
            //��� ��������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.WORKSHOP_CODE  " + GetCheckBoxStatus(textBox6) + " LIKE :WORKSHOP_CODE) OR ";
                Parameters.Add("WORKSHOP_CODE"); Values.Add(textBox6.Text); 
            }
            //��������
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ORstring += " (USP_ASSEMBLY_ORDERS.TECHNOLOG  " + GetCheckBoxStatus(textBox7) + " LIKE :TECHNOLOG) OR ";
                Parameters.Add("TECHNOLOG"); Values.Add(textBox7.Text); 
            }

            if (ORstring.Length > 2)
            {
                ORstring = ORstring.Remove(ORstring.Length - 3);
            }

            if (String.Compare(ORstring, "") != 0)
            {
                ORstring = "AND (" + ORstring + ")";

            }
            
            GenerateData(ORstring, ref Parameters, ref Values);
 
        }


        void GenerateData(string sentence, ref System.Collections.Generic.List<string> Parameters, ref System.Collections.Generic.List<string> Values)
        {

            if (status == 1)
            {
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("select NUM AS \"�����\", VPP_NUM AS \"����� ���\", TZ_NUM AS \"����� ��\",  PART_TITLE  AS \"����������� ������\", WORKSHOP_CODE  AS \"��� ��������\", TECHNOLOG AS \"��������\", CREATION_DATE  AS \"���� �������� ����� ������\" from USP_ASSEMBLY_ORDERS where DOC_STATUS = " + status + " and CREATION_DATE >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and CREATION_DATE < to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') " + sentence, Parameters, Values).Tables[0];
            }else if (status == 2)
            {
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("select NUM AS \"�����\", VPP_NUM AS \"����� ���\", TZ_NUM AS \"����� ��\",  PART_TITLE  AS \"����������� ������\", WORKSHOP_CODE  AS \"��� ��������\", TECHNOLOG AS \"��������\", ASSEMBLY_CREATION_DATE  AS \"���� �������� ������\" from USP_ASSEMBLY_ORDERS where DOC_STATUS = " + status + " and ASSEMBLY_CREATION_DATE >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and ASSEMBLY_CREATION_DATE < to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') " + sentence, Parameters, Values).Tables[0];
            }
            else if (status == 3)
            {
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("select NUM AS \"�����\", VPP_NUM AS \"����� ���\", TZ_NUM AS \"����� ��\",  PART_TITLE  AS \"����������� ������\", WORKSHOP_CODE  AS \"��� ��������\", TECHNOLOG AS \"��������\", ASSEMBLY_DELIVERY_DATE AS \"���� �������� ������\" from USP_ASSEMBLY_ORDERS where DOC_STATUS = " + status + " and ASSEMBLY_DELIVERY_DATE >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and ASSEMBLY_DELIVERY_DATE < to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') " + sentence, Parameters, Values).Tables[0];
            }
            else if (status == 4)
            {
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("select NUM AS \"�����\", VPP_NUM AS \"����� ���\", TZ_NUM AS \"����� ��\",  PART_TITLE  AS \"����������� ������\", WORKSHOP_CODE  AS \"��� ��������\", TECHNOLOG AS \"��������\", ASSEMBLY_RETURN_DATE AS \"���� �������� ������\" from USP_ASSEMBLY_ORDERS where DOC_STATUS = " + status + " and ASSEMBLY_RETURN_DATE >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and ASSEMBLY_RETURN_DATE < to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') " + sentence, Parameters, Values).Tables[0];
            }   
        }

        private void Not_CheckedChanged(object sender, EventArgs e)
        {
            if (Not.Checked == true)
            {
                EnableALLCheckBox();
            }
            else
            {
                DisableAllCheckBox();
                UnCheckAllCheckBox();
            }
        }

        private string GetCheckBoxStatus(TextBox textBox)
        {
            string name = textBox.Name;

            if (((CheckBox)(this.Controls.Find("checkBox" + textBox.Tag.ToString(), true)[0])).Checked == true)
            {
                return " NOT ";
            }
            else {
                return " ";
            }

            
        }

      
        private void initSearch()
        {
            if (OR.Checked == true)
            {
                BuildStringOR();
            }
            else if (AND.Checked == true)
            {
                BuildStringAND();
            }
            
        }

        private string GetPRCodeForVppVZD()
        {
            if (status == 1)//�������� ��� ��� � ��� �� ���������
            {
                return "PR2 = 0 AND";
            }
            else if (status == 2)
            {

                return "PR2 = 1 AND";
            }
            else
            {
                return " ";
            }
        }

       
      
    
    }
       
}