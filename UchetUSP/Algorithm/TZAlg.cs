using System;
using System.Collections.Generic;
using System.Text;
using UchetUSP.WinForms;
using UchetUSP.Algorithm;
using System.Windows.Forms;

namespace UchetUSP.Layout
{
    partial class LayoutOrderTZ
    {
        private int statusOfForm = 0;

        public int status
        {
            set {
                statusOfForm = value;
            }
            get {
                return statusOfForm;
            }        
        }


        private int statusOfUtv = 0;

        public int Utv
        {
            set
            {
                statusOfUtv = value;
            }
            get
            {
                return statusOfUtv;
            }
        }


       
        
        /// <summary>
        /// ������ �����;
        /// </summary>
        /// <param name="i">       
        ///1- �� ���������� � �� ���������.
        ///2- �� �� ��������� � �� ���������.
        ///3- �� ��������� � ���������
        ///4- �� �� ��������� � �����c���</param>
        /// <returns></returns> 
        public void loadTZForm(int i)
        {
            status = i;

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();

            GetStatusOfUtvDocument();

            UpdateDataGrid();

            setStatusOfPorp();
           
        }    

        private void UpdateDataGrid()
        {

            if (status == 1)
            {

                dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
                  "PDM_DOC.DOC AS \"����� ��\", " +
                  "PDM_DOC.REV AS \"������\", " +                  
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
                  "PDM_DOC.USR AS \"��������\", " +
                  "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                  "PDM_DOC.DT AS \"���� ��������\" " +
                  "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC.DT <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss')) "+
                  "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='�����������' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NULL)").Tables[0];

                dataGridView1.Columns["ID_DOC"].Visible = false;

               /* if(String.Compare(SQLOracle.selectStr("SELECT ")))
                this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.SelectedItem = "����������";
                this.button4.Enabled = true;*/

            } if (status == 2)
            {

                    dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
                   "PDM_DOC.DOC AS \"����� ��\", " +
                   "PDM_DOC.REV AS \"������\", " +
                   "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
                   "PDM_DOC.USR AS \"��������\", " +
                   "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
                   "PDM_DOC.DT AS \"���� ��������\" " +
                   "FROM  PDM_DOC " +
                   "WHERE  (PDM_DOC.DT <= to_date( '" +
                   dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                   "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                   "','DD.MM.YYYY hh24:mi:ss')) " +
                   "AND NOT EXISTS(SELECT USP_TZ_DATA.ID_DOC FROM USP_TZ_DATA  WHERE USP_TZ_DATA.ID_DOC = PDM_DOC.ID_DOC) " +
                   "AND PDM_DOC.TYP = '93'"+
                   "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='�����������' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NULL)").Tables[0];


                    dataGridView1.Columns["ID_DOC"].Visible = false;

               /* this.comboBox2.SelectedItem = "�� �� ���������";
                this.comboBox1.SelectedItem = "����������";
                this.button4.Enabled = true;*/

            } if (status == 3)
            {

                if (Utv == 1)
                {                    
                        dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC_YTV.ID_DOC, " +
                    "PDM_DOC_YTV.DOC AS \"����� ��\", " +
                    "PDM_DOC_YTV.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC_YTV.USR AS \"��������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"�����\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"���� �����������\" " +
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                    dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                    "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                    "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '" + Utv + "'").Tables[0];

                        dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                else if (Utv == 0)
                {
                        dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
                      "PDM_DOC.DOC AS \"����� ��\", " +
                      "PDM_DOC.REV AS \"������\", " +
                      "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC.IZD)  AS \"��� �������\" , " +
                      "PDM_DOC.USR AS \"��������\", " +
                      "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
                      "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                      "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                      "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                      "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                      "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                      "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                      "PDM_DOC.DT AS \"���� ��������\" " +
                      "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                      "where  (PDM_DOC.DT <= to_date( '" +
                      dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                      "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                      "','DD.MM.YYYY hh24:mi:ss'))  AND (USP_TZ_DATA.UTV IS NULL) AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='�����������' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NOT NULL)").Tables[0];

                        dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                else if (Utv == 2)
                {
                    dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC_ARX.ID_DOC, " +
                  "PDM_DOC_ARX.DOC AS \"����� ��\", " +
                  "PDM_DOC_ARX.REV AS \"������\", " +
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_ARX.IZD)  AS \"��� �������\" , " +
                  "PDM_DOC_ARX.USR AS \"��������\", " +
                  "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_ARX.PODR)  AS \"�����\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                  "PDM_DOC_ARX.ARX_TIME AS \"���� �����������\" " +
                  "FROM  PDM_DOC_ARX INNER JOIN USP_TZ_DATA ON PDM_DOC_ARX.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC_ARX.ARX_TIME <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC_ARX.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '" + Utv + "'").Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                
              
                  

                /*this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.SelectedItem = "���������";
                this.button4.Enabled = false;*/

            } if (status == 4)
            {

                dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
              "PDM_DOC.DOC AS \"����� ��\", " +
              "PDM_DOC.REV AS \"������\", " +
              "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
              "PDM_DOC.USR AS \"��������\", " +
              "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
              "PDM_DOC.DT AS \"���� ��������\" " +
              "FROM  PDM_DOC " +
              "WHERE  (PDM_DOC.DT <= to_date( '" +
              dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
              "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
              "','DD.MM.YYYY hh24:mi:ss')) " +
              "AND NOT EXISTS(SELECT USP_TZ_DATA.ID_DOC FROM USP_TZ_DATA  WHERE USP_TZ_DATA.ID_DOC = PDM_DOC.ID_DOC) " +
              "AND PDM_DOC.TYP = '93' "+
              "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='�����������' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NOT NULL)").Tables[0];

                /*this.comboBox2.SelectedItem = "�� �� ���������";
                this.comboBox1.SelectedItem = "���������";
                this.button4.Enabled = false;*/
            }

        }

        //�������� ����� �� 
        private void ViewTZ_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if (dataGridView1.RowCount > 0)
            {
                if (UchetUSP.AccessUser.AccessUser.GetViewRights((dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                {
                    if (status == 1)
                    {
                        using (CreateTZ NewTZForm = new CreateTZ(1, 0, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                        {
                            NewTZForm.ShowDialog();
                        }


                    } if (status == 2)
                    {
                        MessageBox.Show("�������� �� ��������. ������� \"�������������\", ��� �� �������� ��������!");


                    } if (status == 3)
                    {
                        if (Utv == 0)
                        {
                            using (CreateTZ NewTZForm = new CreateTZ(1, 0, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                            {
                                NewTZForm.ShowDialog();
                            }
                        }
                        else if (Utv == 1)
                        {
                            using (CreateTZ NewTZForm = new CreateTZ(1, 1, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                            {
                                NewTZForm.ShowDialog();
                            }

                        }
                        else if (Utv == 2)
                        {
                            using (CreateTZ NewTZForm = new CreateTZ(1, 2, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                            {
                                NewTZForm.ShowDialog();
                            }

                        }

                    } if (status == 4)
                    {
                        MessageBox.Show("����������� ������� ���������, �� �� ���� ���������!");
                    }
                }
                else {

                    MessageBox.Show("�������� �� �������� ������������! ������� ��������!");
                }
               
            }
            

        }

        

        //�������������� ����� �� 
        private void EditTZ_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            if(dataGridView1.RowCount>0)
                if (UchetUSP.AccessUser.AccessUser.GetOtdAccess((dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                {
                    if (status == 1)
                    {
                        using (CreateTZ NewTZForm = new CreateTZ(2, 0, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                        {
                            NewTZForm.ShowDialog();
                        }

                    } if (status == 2)
                    {
                        using (CreateTZ NewTZForm = new CreateTZ(0, 0, (dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()))
                        {
                            NewTZForm.ShowDialog();
                        }

                    }
                }
                else {

                    MessageBox.Show("� ��� ��� ���� �� ������������� ������� ���������. �������� ��� ������ ������� " + UchetUSP.AccessUser.AccessUser.GetUsrDeveloperOtd((dataGridView1["ID_DOC", dataGridView1.SelectedCells[0].RowIndex].Value.ToString()).ToString()));
                
                }               
 
        }


        //����� �� 
        private void SearchTZ_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            using (WinForms.TZORDER.FindTZ FindTz = new UchetUSP.WinForms.TZORDER.FindTZ(status,Utv,dataGridView1, dateTimePicker1,dateTimePicker2))
            {
                FindTz.ShowDialog();
            }
        }


       

      
        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("���� ������ ������ ���� ������ ���� �����!");
                this.dateTimePicker1.Value = this.dateTimePicker2.Value;
                this.dateTimePicker1.Value = this.dateTimePicker1.Value.AddMonths(-1);

            }
            else {
                UpdateDataGrid();
            }

        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            if (this.dateTimePicker1.Value > this.dateTimePicker2.Value)
            {
                MessageBox.Show("���� ������ ������ ���� ������ ���� �����!");
                this.dateTimePicker2.Value = this.dateTimePicker1.Value;
                this.dateTimePicker2.Value = this.dateTimePicker2.Value.AddMonths(1);
            }
            else {
                UpdateDataGrid();
            }

        }

       

        public void SetDataGridRowSelect(string number)
        {


           this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

           this.dateTimePicker1.Update();


           if (status == 1)
           {
               dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
                "PDM_DOC.DOC AS \"����� ��\", " +
                "PDM_DOC.REV AS \"������\", " +
                "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
                "PDM_DOC.USR AS \"��������\", " +
                "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
                "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                 "PDM_DOC.DT AS \"���� ��������\" " +
                "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                "where  PDM_DOC.ID_DOC ='" + number + "'").Tables[0];

           } if (status == 2)
           {
               dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
               "PDM_DOC.DOC AS \"����� ��\", " +
               "PDM_DOC.REV AS \"������\", " +
               "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
               "PDM_DOC.USR AS \"��������\" " +
               "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
               "PDM_DOC.DT AS \"���� ��������\" " +
               "FROM  PDM_DOC " +
               "where  PDM_DOC.ID_DOC ='" + number + "'").Tables[0];

           } if (status == 3)
           {
               if (Utv == 1)
               {
                   dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC_YTV.ID_DOC, " +
                    "PDM_DOC_YTV.DOC AS \"����� ��\", " +
                    "PDM_DOC_YTV.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC_YTV.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC_YTV.USR AS \"��������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"�����\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"���� �����������\" " +
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  PDM_DOC_YTV.ID_DOC ='" + number + "'").Tables[0];
               }
               else if (Utv == 0)
               { 
                    dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
                    "PDM_DOC.DOC AS \"����� ��\", " +
                    "PDM_DOC.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC.USR AS \"��������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                    "PDM_DOC.DT AS \"���� ��������\" " +
                    "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  PDM_DOC.ID_DOC ='" + number + "'").Tables[0];
                }
                else if (Utv == 2)
                {
                    dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC_ARX.ID_DOC, " +
                    "PDM_DOC_ARX.DOC AS \"����� ��\", " +
                    "PDM_DOC_ARX.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC_ARX.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC_ARX.USR AS \"��������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_ARX.PODR)  AS \"�����\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                    "PDM_DOC_ARX.ARX_TIME AS \"���� �����������\" " +
                    "FROM  PDM_DOC_ARX INNER JOIN USP_TZ_DATA ON PDM_DOC_ARX.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  PDM_DOC_ARX.ID_DOC ='" + number + "'").Tables[0];
                }

               

           } if (status == 4)
           {               

               dataGridView1.DataSource = SQLOracle.getDS("SELECT PDM_DOC.ID_DOC, " +
               "PDM_DOC.DOC AS \"����� ��\", " +
               "PDM_DOC.REV AS \"������\", " +
               "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"��� �������\" , " +
               "PDM_DOC.USR AS \"��������\", " +
               "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"�����\", " +
               "PDM_DOC.DT AS \"���� ��������\" " +
               "FROM  PDM_DOC " +
               "where  PDM_DOC.ID_DOC ='" + number + "'").Tables[0];
             
           }

            dataGridView1.Columns["ID_DOC"].Visible = false;
        }

       
        public void setStatusOfPorp()
        {
            if (status == 1)
            {                
                this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.SelectedItem = "����������";
                this.comboBox3.SelectedItem = "����������";

                if (UchetUSP.AccessUser.AccessUser.GetTehRights())
                {
                    this.button4.Enabled = true;
                }
                else
                {

                    this.button4.Enabled = false;

                }

                this.button1.Enabled = true;
               
            } if (status == 2)
            {
                this.comboBox2.SelectedItem = "�� �� ���������";
                this.comboBox1.SelectedItem = "����������";
                this.comboBox3.SelectedItem = "����������";
                if (UchetUSP.AccessUser.AccessUser.GetTehRights())
                {
                    this.button4.Enabled = true;
                }
                else
                {
                    this.button4.Enabled = false;

                }
                this.button1.Enabled = false;
                
            } if (status == 3)
            {
                
                if(Utv == 1)
                {
                    this.comboBox3.SelectedItem = "������������";

                }
                else if (Utv == 2)
                {
                    this.comboBox3.SelectedItem = "�����";

                }else if(Utv == 0)
                {
                    this.comboBox3.SelectedItem = "����������";
                }

                this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.SelectedItem = "���������";
                this.button4.Enabled = false;
                this.button1.Enabled = true;

                
            } if (status == 4)
            {
                this.comboBox2.SelectedItem = "�� �� ���������";
                this.comboBox1.SelectedItem = "���������";
                this.comboBox3.SelectedItem = "����������";
                this.button4.Enabled = false;
                this.button1.Enabled = false;
            }

        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        //���� �� ����������, �� �������� ���������� ������ ���� �������� � ��������.

        void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.Compare(comboBox3.Text, "������������") == 0)
            {
                Utv = 1;
                this.comboBox1.SelectedItem = "���������";
                this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
            }
            else if (String.Compare(comboBox3.Text, "�����") == 0)
            {
                Utv = 2;
                this.comboBox1.SelectedItem = "���������";
                this.comboBox2.SelectedItem = "�� ���������";
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
            }
            else if (String.Compare(comboBox3.Text, "����������") == 0)
            {
                Utv = 0;
                this.comboBox1.Enabled = true;
                this.comboBox2.Enabled = true;
            }

            UpdateForm();
        }


        void UpdateForm()
        {
            if ((String.Compare(comboBox1.Text, "����������") == 0) && (String.Compare(comboBox2.Text, "�� ���������") == 0))
            {
                status = 1;

                if (UchetUSP.AccessUser.AccessUser.GetTehRights())
                {
                    this.button4.Enabled = true;
                }
                else {

                    this.button4.Enabled = false;
                
                }
               
                this.button1.Enabled = true;
                UpdateDataGrid();
            }
            if ((String.Compare(comboBox1.Text, "����������") == 0) && (String.Compare(comboBox2.Text, "�� �� ���������") == 0))
            {
                status = 2;
                if (UchetUSP.AccessUser.AccessUser.GetTehRights())
                {
                    this.button4.Enabled = true;
                }
                else
                {
                    this.button4.Enabled = false;

                }
                this.button1.Enabled = false;
                UpdateDataGrid();
            }
            if ((String.Compare(comboBox1.Text, "���������") == 0) && (String.Compare(comboBox2.Text, "�� ���������") == 0))
            {                
                status = 3;
                this.button4.Enabled = false;
                this.button1.Enabled = true;
                UpdateDataGrid();
            }
            if ((String.Compare(comboBox1.Text, "���������") == 0) && (String.Compare(comboBox2.Text, "�� �� ���������") == 0))
            {
                status = 4;
                this.button4.Enabled = false;
                this.button1.Enabled = false;
                UpdateDataGrid();
            }
        
        }


        void GetStatusOfUtvDocument()
        {
            string getUtvStatus = SQLOracle.selectStr("select UTV from USP_TZ_DATA where ID_DOC = '" + Program.DocIdString + "'");

            if (String.Compare(getUtvStatus, "1") == 0)
            {
                Utv = 1;

            }
            else if (String.Compare(getUtvStatus, "2") == 0)
            {
                Utv = 2;

            }
            else if (String.Compare(getUtvStatus, "") == 0)
            {
                Utv = 0;
            }
        
        }

        void UpdateTZ_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();            
        }

       
    }
}
