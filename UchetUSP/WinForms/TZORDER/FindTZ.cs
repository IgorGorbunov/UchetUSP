using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;
using UchetUSP.Layout;

namespace UchetUSP.WinForms.TZORDER
{
    public partial class FindTZ : Form
    {
        int status;
        DataGridView dataGridView1;
        DateTimePicker dateTimePicker1;
        DateTimePicker dateTimePicker2;
        int Utv;

        string filterLZ = " ";

        public FindTZ(int stat,int UtvDocStat, DataGridView dtgv1, DateTimePicker picker1, DateTimePicker picker2)
        {
            InitializeComponent();
            Utv = UtvDocStat;
            status = stat;
            dataGridView1 = dtgv1;
            dateTimePicker1 = picker1;
            dateTimePicker2 = picker2;
            BlockTextBox();
            this.AND.Checked = true;
            this.Not.Checked = true;
        }


        public FindTZ(int stat, int UtvDocStat, DataGridView dtgv1, DateTimePicker picker1, DateTimePicker picker2,string voidStr)
        {
            InitializeComponent();
            Utv = UtvDocStat;
            status = stat;
            dataGridView1 = dtgv1;
            dateTimePicker1 = picker1;
            dateTimePicker2 = picker2;
            BlockTextBox();
            this.AND.Checked = true;
            this.Not.Checked = true;
            FilterForLZ();
        }

        void FilterForLZ()
        {
            filterLZ = "  AND PDM_DOC_YTV.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS) ";
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumberExceptPercent(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initSearch();
        }
        //блокирует textbox если таких параметров не существует
        void BlockTextBox()
        {
            if ((status == 2) || (status == 4))
            {
                textBox6.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox10.Enabled = false;
                textBox11.Enabled = false;

            }
        }

        void BuildStringAND()
        {
            string ANDstring = "";

            string TableName = SetTableName();

            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                GetCheckBoxStatus(textBox1);
                ANDstring += " AND (" + TableName + ".DOC " + GetCheckBoxStatus(textBox1) + " LIKE :DOC) ";
                Parameters.Add("DOC"); Values.Add(textBox1.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                ANDstring += " AND (" + TableName + ".REV  " + GetCheckBoxStatus(textBox3) + " LIKE :REV) ";
                Parameters.Add("REV"); Values.Add(textBox3.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ANDstring += " AND ((SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = " + TableName + ".IZD)  " + GetCheckBoxStatus(textBox4) + " LIKE :KB) ";
                Parameters.Add("KB"); Values.Add(textBox4.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                ANDstring += " AND (" + TableName + ".USR  " + GetCheckBoxStatus(textBox5) + " LIKE :USR) ";
                Parameters.Add("USR"); Values.Add(textBox5.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.OBOZN_DET   " + GetCheckBoxStatus(textBox6) + " LIKE :OBOZN_DET) ";
                Parameters.Add("OBOZN_DET"); Values.Add(textBox6.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.NAIM_DET   " + GetCheckBoxStatus(textBox7) + " LIKE :NAIM_DET) ";
                Parameters.Add("NAIM_DET"); Values.Add(textBox7.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.KOD_CEHA   " + GetCheckBoxStatus(textBox8) + " LIKE :KOD_CEHA) ";
                Parameters.Add("KOD_CEHA"); Values.Add(textBox8.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.OB_NAIM   " + GetCheckBoxStatus(textBox9) + "  LIKE :OB_NAIM) ";
                Parameters.Add("OB_NAIM"); Values.Add(textBox9.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox10), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.OB_MODEL   " + GetCheckBoxStatus(textBox10) + "  LIKE :OB_MODEL) ";
                Parameters.Add("OB_MODEL"); Values.Add(textBox10.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox11), " ") != 0)
            {
                ANDstring += " AND (USP_TZ_DATA.OB_SHIR  " + GetCheckBoxStatus(textBox11) + "  LIKE :OB_SHIR) ";
                Parameters.Add("OB_SHIR"); Values.Add(textBox11.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox12), " ") != 0)
            {
                ANDstring += " AND ((SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = " + TableName + ".PODR)  " + GetCheckBoxStatus(textBox12) + " LIKE :PODR) ";
                Parameters.Add("PODR"); Values.Add(textBox12.Text);
            }



            GenerateData(ANDstring,ref Parameters,ref Values);
            
        }


        void BuildStringOR()
        {
            string ORstring = "";

            string TableName = SetTableName();

            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> Values = new System.Collections.Generic.List<string>();

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                ORstring += " (" + TableName + ".DOC  " + GetCheckBoxStatus(textBox1) + " LIKE :DOC) OR ";
                Parameters.Add("DOC"); Values.Add(textBox1.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                ORstring += " (" + TableName + ".REV " + GetCheckBoxStatus(textBox3) + "  LIKE :REV) OR ";
                Parameters.Add("REV"); Values.Add(textBox3.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ORstring += " ((SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = " + TableName + ".IZD)  " + GetCheckBoxStatus(textBox4) + " LIKE :KB) OR ";
                Parameters.Add("KB"); Values.Add(textBox4.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                ORstring += " (" + TableName + ".USR  " + GetCheckBoxStatus(textBox5) + " LIKE :USR) OR ";
                Parameters.Add("USR"); Values.Add(textBox5.Text);
            }

            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.OBOZN_DET  " + GetCheckBoxStatus(textBox6) + "  LIKE :OBOZN_DET) OR ";
                Parameters.Add("OBOZN_DET"); Values.Add(textBox6.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.NAIM_DET  " + GetCheckBoxStatus(textBox7) + "  LIKE :NAIM_DET) OR ";
                Parameters.Add("NAIM_DET"); Values.Add(textBox7.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.KOD_CEHA  " + GetCheckBoxStatus(textBox8) + "  LIKE :KOD_CEHA) OR ";
                Parameters.Add("KOD_CEHA"); Values.Add(textBox8.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.OB_NAIM  " + GetCheckBoxStatus(textBox9) + "   LIKE :OB_NAIM) OR ";
                Parameters.Add("OB_NAIM"); Values.Add(textBox9.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox10), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.OB_MODEL  " + GetCheckBoxStatus(textBox10) + "   LIKE :OB_MODEL) OR ";
                Parameters.Add("OB_MODEL"); Values.Add(textBox10.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox11), " ") != 0)
            {
                ORstring += " (USP_TZ_DATA.OB_SHIR   " + GetCheckBoxStatus(textBox11) + "  LIKE :OB_SHIR) OR ";
                Parameters.Add("OB_SHIR"); Values.Add(textBox11.Text);
            }
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox12), " ") != 0)
            {
                ORstring += " ((SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = " + TableName + ".PODR)  " + GetCheckBoxStatus(textBox12) + " LIKE :PODR) OR ";
                Parameters.Add("PODR"); Values.Add(textBox12.Text);
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
              

        void GenerateData(string sentence,ref System.Collections.Generic.List<string> Parameters,ref System.Collections.Generic.List<string> Values)
        {
            if (status == 1)
            {

                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC.ID_DOC, " +
                  "PDM_DOC.DOC AS \"Номер ТЗ\", " +
                  "PDM_DOC.REV AS \"Версия\", " +
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"Код изделия\" , " +
                  "PDM_DOC.USR AS \"Владелец\", " +
                  "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"Отдел\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                  "PDM_DOC.DT AS \"Дата создания\" " +
                  "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC.DT <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='Исполнитель' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NULL)  " + sentence, Parameters, Values).Tables[0];

                dataGridView1.Columns["ID_DOC"].Visible = false;

                /* if(String.Compare(SQLOracle.selectStr("SELECT ")))
                 this.comboBox2.SelectedItem = "ТЗ оформлено";
                 this.comboBox1.SelectedItem = "Разработка";
                 this.button4.Enabled = true;*/

            } if (status == 2)
            {

                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC.ID_DOC, " +
               "PDM_DOC.DOC AS \"Номер ТЗ\", " +
               "PDM_DOC.REV AS \"Версия\", " +
               "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"Код изделия\" , " +
               "PDM_DOC.USR AS \"Владелец\", " +
               "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"Отдел\", " +
               "PDM_DOC.DT AS \"Дата создания\" " +
               "FROM  PDM_DOC " +
               "WHERE  (PDM_DOC.DT <= to_date( '" +
               dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
               "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
               "','DD.MM.YYYY hh24:mi:ss')) " +
               "AND NOT EXISTS(SELECT USP_TZ_DATA.ID_DOC FROM USP_TZ_DATA  WHERE USP_TZ_DATA.ID_DOC = PDM_DOC.ID_DOC) " +
               "AND PDM_DOC.TYP = '93'" +
               "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='Исполнитель' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NULL)  " + sentence, Parameters, Values).Tables[0];


                dataGridView1.Columns["ID_DOC"].Visible = false;

                /* this.comboBox2.SelectedItem = "ТЗ не оформлено";
                 this.comboBox1.SelectedItem = "Разработка";
                 this.button4.Enabled = true;*/

            } if (status == 3)
            {

                if (Utv == 1)
                {
                    dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC_YTV.ID_DOC, " +
                "PDM_DOC_YTV.DOC AS \"Номер ТЗ\", " +
                "PDM_DOC_YTV.REV AS \"Версия\", " +
                "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"Код изделия\" , " +
                "PDM_DOC_YTV.USR AS \"Владелец\", " +
                "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"Отдел\", " +
                "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                "PDM_DOC_YTV.ARX_TIME AS \"Дата утверждения\" " +
                "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '" + Utv + "'" + filterLZ + sentence, Parameters, Values).Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                else if (Utv == 0)
                {
                    dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC.ID_DOC, " +
                  "PDM_DOC.DOC AS \"Номер ТЗ\", " +
                  "PDM_DOC.REV AS \"Версия\", " +
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC.IZD)  AS \"Код изделия\" , " +
                  "PDM_DOC.USR AS \"Владелец\", " +
                  "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"Отдел\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                  "PDM_DOC.DT AS \"Дата создания\" " +
                  "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC.DT <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss'))  AND (USP_TZ_DATA.UTV IS NULL) "+
                  "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='Исполнитель' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NOT NULL) " + 
                  sentence, Parameters, Values).Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                else if (Utv == 2)
                {
                    dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC_ARX.ID_DOC, " +
                  "PDM_DOC_ARX.DOC AS \"Номер ТЗ\", " +
                  "PDM_DOC_ARX.REV AS \"Версия\", " +
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_ARX.IZD)  AS \"Код изделия\" , " +
                  "PDM_DOC_ARX.USR AS \"Владелец\", " +
                  "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_ARX.PODR)  AS \"Отдел\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                  "PDM_DOC_ARX.ARX_TIME AS \"Дата утверждения\" " +
                  "FROM  PDM_DOC_ARX INNER JOIN USP_TZ_DATA ON PDM_DOC_ARX.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC_ARX.ARX_TIME <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC_ARX.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '" + Utv + "'" + sentence, Parameters, Values).Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;
                }
                /*
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC.ID_DOC, " +
                  "PDM_DOC.DOC AS \"Номер ТЗ\", " +
                  "PDM_DOC.REV AS \"Версия\", " +
                  "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC.IZD)  AS \"Код изделия\" , " +
                  "PDM_DOC.USR AS \"Владелец\", " +
                  "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                  "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                  "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                  "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                  "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                  "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                  "PDM_DOC.DT AS \"Дата создания\" " +
                  "FROM  PDM_DOC INNER JOIN USP_TZ_DATA ON PDM_DOC.ID_DOC = USP_TZ_DATA.ID_DOC " +
                  "where  (PDM_DOC.DT <= to_date( '" +
                  dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                  "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
                  "','DD.MM.YYYY hh24:mi:ss')) AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='Исполнитель' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NOT NULL)  " + sentence, Parameters, Values).Tables[0];
                */
                //dataGridView1.Columns["ID_DOC"].Visible = false;

                /*this.comboBox2.SelectedItem = "ТЗ оформлено";
                this.comboBox1.SelectedItem = "Подписано";
                this.button4.Enabled = false;*/

            } if (status == 4)
            {

                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent("SELECT PDM_DOC.ID_DOC, " +
              "PDM_DOC.DOC AS \"Номер ТЗ\", " +
              "PDM_DOC.REV AS \"Версия\", " +
              "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD= PDM_DOC.IZD)  AS \"Код изделия\" , " +
              "PDM_DOC.USR AS \"Владелец\", " +
              "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC.PODR)  AS \"Отдел\", " +
              "PDM_DOC.DT AS \"Дата создания\" " +
              "FROM  PDM_DOC " +
              "WHERE  (PDM_DOC.DT <= to_date( '" +
              dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
              "AND (PDM_DOC.DT >= to_date( '" + dateTimePicker1.Value.ToString() +
              "','DD.MM.YYYY hh24:mi:ss')) " +
              "AND NOT EXISTS(SELECT USP_TZ_DATA.ID_DOC FROM USP_TZ_DATA  WHERE USP_TZ_DATA.ID_DOC = PDM_DOC.ID_DOC) " +
              "AND PDM_DOC.TYP = '93' " +
              "AND EXISTS(SELECT PDM_DOC_PODP.USR FROM PDM_DOC_PODP WHERE PDM_DOC_PODP.WNM ='Исполнитель' AND PDM_DOC_PODP.ID_DOC = PDM_DOC.ID_DOC AND PDM_DOC_PODP.USR IS NOT NULL)  " + sentence, Parameters, Values).Tables[0];

                /*this.comboBox2.SelectedItem = "ТЗ не оформлено";
                this.comboBox1.SelectedItem = "Подписано";
                this.button4.Enabled = false;*/
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

        private string SetTableName()
        {
            if(Utv == 0)
            {
                return "PDM_DOC";

            }else if(Utv == 1)
            {
                return "PDM_DOC_YTV";
            
            }else if(Utv == 2)
            {
                return "PDM_DOC_ARX";
            }
            return "";
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

        private void FindTZ_Load(object sender, EventArgs e)
        {

        }

      
    
    }
       
}