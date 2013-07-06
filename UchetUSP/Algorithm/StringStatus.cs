using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.Layout
{
    partial class Layout : IDisposable
    {
         //����������� ������ ������� ��� pictureBox
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "����������� ��� �� ����";
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "����� ��������� �� �������� ���������";
        }

        private void button1_MouseHover_LoadNX(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "�������� ��������� ��� � NX";
        }

        private void button1_MouseHover_Edit(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "�������������� ���������� � ��������� ���";
        }
        private void button1_MouseHover_Delete(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "���������� ���������� ��������� ���";
        }

        private void treeView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "���������� ��������� ��� �� ������";
        }
        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "����������� ��������� ���";
        }
    }


    partial class LayoutOrderTZ : IDisposable
    {
        private void buttonView_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "���������� ����������� �������";
        }
             
        private void buttonEdit_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "�������������� ������������ �������";
        }

        private void buttonFind_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "����� ������������ �������";
        }
        private void BeginTime_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� ������������ �������";
        }

        private void EndTime_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� ������������ �������";
        }
        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "����������� �������";
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {

            if (String.Compare(comboBox1.Text, "����������") == 0)                
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ��������� � ������������ �������� ���������";

            if (String.Compare(comboBox1.Text, "���������") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ��������� � ������������ ���������";
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            if (String.Compare(comboBox2.Text, "�� ���������") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ���������, ������� ���� ��������� �����";

            if (String.Compare(comboBox2.Text, "�� �� ���������") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ���������, ������� �� ���������� �����";
        }
        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            if (String.Compare(comboBox3.Text, "����������") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ���������, ������� ��������� �� ����������";

            if (String.Compare(comboBox3.Text, "������������") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ���������, ������� ���� ����������";

            if (String.Compare(comboBox3.Text, "�����") == 0)
                ParentToolStripStatusLabel.Text = "��� ���������� ���������� �� ���������, ������� ��������� � ������";
        }
        private void Update_MouseHover(object sender, EventArgs e)
        {
            ParentToolStripStatusLabel.Text = "���������� ����������";
        }



        
    }
    
    
    partial class LayoutOrder : IDisposable
        {

            private void comboBox1_MainForm(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "���") == 0)
                        ParentToolStripStatusLabel.Text = "����� �� ����� ���� ����������";

                if (String.Compare(comboBox1.Text, "���") == 0)
                    ParentToolStripStatusLabel.Text = "����� �� �����  ���";

                    if (String.Compare(comboBox1.Text, "���") == 0)
                        ParentToolStripStatusLabel.Text = "����� �� �����  ���";

                  
                    if (String.Compare(comboBox1.Text, "�� (��� ���)") == 0)
                        ParentToolStripStatusLabel.Text = "����� �� ����� ��, ���������� � �� \"���� ���\"";
            }

            private void comboBox2_MainForm(object sender, EventArgs e)
            {
                if (String.Compare(comboBox2.Text, "���") == 0)
                    ParentToolStripStatusLabel.Text = "������ ���� ��������� � Excel";

                if (String.Compare(comboBox2.Text, "���") == 0)
                    ParentToolStripStatusLabel.Text = "������ ���/��� � Excel";

                if (String.Compare(comboBox2.Text, "��") == 0)
                    ParentToolStripStatusLabel.Text = "������ �� � Excel";


                if (String.Compare(comboBox2.Text, "������������") == 0)
                    ParentToolStripStatusLabel.Text = "������ ������������ � Excel";
            }

            private void dGV_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "����������� ����� �������. �������� 2 ���� �� �������� ������� ��� ������������ ����� ������";               
            }

            private void button3_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "��������� ������ ������ ���� � NX ��� �������� �������";               
            }

             private void button4_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "����� ������� �� �������� ���������";               
            }

             private void dateTimePicker1_MainForm(object sender, EventArgs e)
            {               
                    ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� �������";               
            }
            private void dateTimePicker2_MainForm(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� �������";
            }    
        
            ///Confirm Order

            private void dGV_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����������� ������ ������. �������� 2 ���� �� �������� ������� ��� ������ ������� ������������� ���������� ������ �� ������ ����";
            }    
            private void dateTimePicker1_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� ������ ������";
            }    
            private void dateTimePicker2_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� ������ ������";
            }
            private void button3_ConfirmOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����� ������ ������ �� �������� ���������";
            }
             private void comboBox1_ConfirmOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "���������� � Excel") == 0)
                    ParentToolStripStatusLabel.Text = "����������� ������ ������ � Excel";

                if (String.Compare(comboBox1.Text, "�������") == 0)
                    ParentToolStripStatusLabel.Text = "�������� ������ ������";
               
            }

             //Grant Order

            private void dGV_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����������� ������ ������. �������� 2 ���� �� �������� ������� ��� ������ ������� ������ ������ ����";
            }

            private void dateTimePicker1_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� ������ ������";
            }
            private void dateTimePicker2_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� ������ ������";
            }
            private void button3_GrantOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����� ������ ������ �� �������� ���������";
            }
            private void comboBox1_GrantOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "���������� � Excel") == 0)
                    ParentToolStripStatusLabel.Text = "���������� ������ ������ � Excel";

                if (String.Compare(comboBox1.Text, "�������� ������") == 0)
                    ParentToolStripStatusLabel.Text = "������� ������ ������ �� ���������� ������";

                if (String.Compare(comboBox1.Text, "�������") == 0)
                    ParentToolStripStatusLabel.Text = "�������� ������ ������";
               
            }
        
            //Get Order

            private void dGV_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����������� ������ ������. �������� 2 ���� �� �������� ������� ��� ������ ������� �������� �������� �� ������� ����";
            }

            private void dateTimePicker1_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� ������ ������";
            }
            private void dateTimePicker2_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� ������ ������";
            }
            private void button3_GetOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����� ������ ������ �� �������� ���������";
            }
            private void comboBox1_GetOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "���������� � Excel") == 0)
                    ParentToolStripStatusLabel.Text = "���������� ������ ������ � Excel";

                if (String.Compare(comboBox1.Text, "�������� ������ ���������") == 0)
                    ParentToolStripStatusLabel.Text = "������� ������ ������ �� ���������� ������";

                if (String.Compare(comboBox1.Text, "�������") == 0)
                    ParentToolStripStatusLabel.Text = "�������� ������ ������";

            }


            //HistoryOrder

        private void dGV_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����������� ������ ������";
            }

            private void dateTimePicker1_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "��������� ���� ��� ���������� ������ ������";
            }
            private void dateTimePicker2_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "�������� ���� ��� ���������� ������ ������";
            }
            private void button3_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����� ������ ������ �� �������� ���������";
            }
            private void dTPAssCard_HistoryOrder(object sender, EventArgs e)
            {
                ParentToolStripStatusLabel.Text = "����� ������ ����� ���������� ����� �� ������� ����";
            }

            private void comboBox1_HistoryOrder(object sender, EventArgs e)
            {
                if (String.Compare(comboBox1.Text, "���������� � Excel") == 0)
                    ParentToolStripStatusLabel.Text = "���������� ������ ������ � Excel";

                if (String.Compare(comboBox1.Text, "�������� ����������� �� �����") == 0)
                    ParentToolStripStatusLabel.Text = "������� ������ ������ �� ���������� ������";

                if (String.Compare(comboBox1.Text, "�������") == 0)
                    ParentToolStripStatusLabel.Text = "�������� ������ ������";

            }


        
        }
}
