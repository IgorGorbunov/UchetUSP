using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;
using UchetUSP.Layout;

namespace UchetUSP.WinForms.VPP
{
    public partial class FindVPP : Form
    {
       
        DataGridView dataGridView1;
        DateTimePicker dateTimePicker1;
        DateTimePicker dateTimePicker2;
        int status;


        /// <summary>
        /// Запуск поика по ВПП/ВЗД/ВПП на доработку/ТЗ
        /// </summary>       
        /// <param name="stat">Статус документа (1 - ВПП, 2 - ВЗД, 3 - ВСЕ)</param>
        /// <param name="dtgv1">Таблица для вывода</param>
        /// <param name="picker1">Начало временного интервала</param>
        /// <param name="picker2">Конец временного интервала</param>
        /// <returns></returns>
        public FindVPP(int stat, DataGridView dtgv1, DateTimePicker picker1, DateTimePicker picker2)
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
            //ВПП
            if (status == 1)
            {
                this.Text = "Поиск ВПП";
                this.label1.Text = "Номер ВПП:";
                this.label4.Text = "Позиция ТЗ в ВПП:";

            }else if(status == 2){//ВЗД

                this.Text = "Поиск ВЗД";
                this.label1.Text = "Номер ВЗД:";
                this.label4.Text = "Позиция ТЗ в ВЗД:";
            }
            else if (status == 3)//ВСЕ
            {
                this.Text = "Поиск ВПП/ВЗД/ТЗ";
                this.label1.Text = "Номер ВПП/ВЗД (Поиск по ВПП/ВЗД):";
                this.label4.Text = "Позиция ТЗ в ВПП/ВЗД:";
            }
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
            string ANDstringVPP = "";
            string ANDstringTZ = "";
          

            System.Collections.Generic.List<string> ParametersVPP = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> ValuesVPP = new System.Collections.Generic.List<string>();


          
            //формирование строки для ВПП

            //Номер ВПП/ВЗД
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {
                
                ANDstringVPP += " AND (VPP_TZ20.N_VD " + GetCheckBoxStatus(textBox1) + " LIKE :N_VD) ";
                ParametersVPP.Add("N_VD"); ValuesVPP.Add(textBox1.Text);
            }
            //Номер ТЗ
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {
                ANDstringVPP += " AND (VPP_TZ20.N_TZ " + GetCheckBoxStatus(textBox3) + " LIKE :N_TZ) ";
                ParametersVPP.Add("N_TZ"); ValuesVPP.Add(textBox3.Text);
            }
           
            //Позиция ТЗ в ВПП
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ANDstringVPP += " AND (VPP_TZ20.POZ  " + GetCheckBoxStatus(textBox4) + " LIKE :POZ) ";
                ParametersVPP.Add("POZ"); ValuesVPP.Add(textBox4.Text);
            }
            //Обозначение детали
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {

                ANDstringVPP += " AND ((SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  " + GetCheckBoxStatus(textBox5) + " LIKE :CH) ";
                ParametersVPP.Add("CH"); ValuesVPP.Add(textBox5.Text);
            }
            //Версия
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ANDstringVPP += " AND ((SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)  " + GetCheckBoxStatus(textBox6) + " LIKE :REV) ";
                ParametersVPP.Add("REV"); ValuesVPP.Add(textBox6.Text);
            }

            //Код изделия
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ANDstringVPP += " AND ((SELECT PDM_IZD.KB FROM PDM_IZD, PDM_DOC_YTV WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD AND PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM AND PDM_IZD.KB <> '0')  " + GetCheckBoxStatus(textBox7) + " LIKE :KB) ";
                ParametersVPP.Add("KB"); ValuesVPP.Add(textBox7.Text);
            }
            
            //Владелец
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
            {
                ANDstringVPP += " AND ((SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) " + GetCheckBoxStatus(textBox8) + " LIKE :USR) ";
                ParametersVPP.Add("USR"); ValuesVPP.Add(textBox8.Text);
            }

            //Отдел
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
            {
                ANDstringVPP += " AND ((SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR)  " + GetCheckBoxStatus(textBox9) + " LIKE :OTD) ";
                ParametersVPP.Add("OTD"); ValuesVPP.Add(textBox9.Text);
            }

            //формирование строки ТЗ
            if ((status == 3))
            { 
                //Номер ТЗ
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
                {
                    
                    ANDstringTZ += " AND (PDM_DOC_YTV.DOC " + GetCheckBoxStatus(textBox3) + " LIKE :DOC) ";
                    ParametersVPP.Add("DOC"); ValuesVPP.Add(textBox3.Text);
                }
               
                //Обозначение детали
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
                {
                    ANDstringTZ += " AND (USP_TZ_DATA.OBOZN_DET  " + GetCheckBoxStatus(textBox5) + " LIKE :OBOZN_DET) ";
                    ParametersVPP.Add("OBOZN_DET"); ValuesVPP.Add(textBox5.Text);
                }
                //Версия
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
                {
                    ANDstringTZ += " AND (PDM_DOC_YTV.REV  " + GetCheckBoxStatus(textBox6) + " LIKE :REVTZ) ";
                    ParametersVPP.Add("REVTZ"); ValuesVPP.Add(textBox6.Text);
                }

                //Код изделия
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
                {
                    ANDstringTZ += " AND ((SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD) " + GetCheckBoxStatus(textBox7) + " LIKE :KBTZ) ";
                    ParametersVPP.Add("KBTZ"); ValuesVPP.Add(textBox7.Text);
                }

                //Владелец
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
                {
                    ANDstringTZ += " AND (PDM_DOC_YTV.USR  " + GetCheckBoxStatus(textBox8) + " LIKE :USRTZ) ";
                    ParametersVPP.Add("USRTZ"); ValuesVPP.Add(textBox8.Text);
                }

                //Отдел
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
                {
                    ANDstringTZ += " AND ((SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR) " + GetCheckBoxStatus(textBox9) + " LIKE :OTDTZ) ";
                    ParametersVPP.Add("OTDTZ"); ValuesVPP.Add(textBox9.Text);
                }

            
            }
            

            GenerateData(ANDstringVPP, ANDstringTZ, ref ParametersVPP, ref ValuesVPP);
            
        }


        void BuildStringOR()
        {

            string ORstringVPP = "";
            string ORstringTZ = "";


            System.Collections.Generic.List<string> ParametersVPP = new System.Collections.Generic.List<string>();

            System.Collections.Generic.List<string> ValuesVPP = new System.Collections.Generic.List<string>();



            //формирование строки для ВПП

            //Номер ВПП/ВЗД
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox1), " ") != 0)
            {

                ORstringVPP += "  (VPP_TZ20.N_VD " + GetCheckBoxStatus(textBox1) + " LIKE :N_VD)  OR ";
                ParametersVPP.Add("N_VD"); ValuesVPP.Add(textBox1.Text);
            }
            //Номер ТЗ
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
            {

                ORstringVPP += "  (VPP_TZ20.N_TZ " + GetCheckBoxStatus(textBox3) + " LIKE :N_TZ)  OR ";
                ParametersVPP.Add("N_TZ"); ValuesVPP.Add(textBox3.Text);
            }

            //Позиция ТЗ в ВПП
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox4), " ") != 0)
            {
                ORstringVPP += "  (VPP_TZ20.POZ  " + GetCheckBoxStatus(textBox4) + " LIKE :POZ)  OR ";
                ParametersVPP.Add("POZ"); ValuesVPP.Add(textBox4.Text);
            }
            //Обозначение детали
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
            {
                ORstringVPP += "  ((SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD) " + GetCheckBoxStatus(textBox5) + " LIKE :CH)  OR ";
                ParametersVPP.Add("CH"); ValuesVPP.Add(textBox5.Text);
            }
            //Версия
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
            {
                ORstringVPP += "  ((SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)  " + GetCheckBoxStatus(textBox6) + " LIKE :REV)  OR ";
                ParametersVPP.Add("REV"); ValuesVPP.Add(textBox6.Text);
            }

            //Код изделия
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
            {
                ORstringVPP += "  ((SELECT PDM_IZD.KB FROM PDM_IZD, PDM_DOC_YTV WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD AND PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM AND PDM_IZD.KB <> '0')  " + GetCheckBoxStatus(textBox7) + " LIKE :KB)  OR ";
                ParametersVPP.Add("KB"); ValuesVPP.Add(textBox7.Text);
            }

            //Владелец
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
            {
                ORstringVPP += "  ((SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) " + GetCheckBoxStatus(textBox8) + " LIKE :USR)  OR ";
                ParametersVPP.Add("USR"); ValuesVPP.Add(textBox8.Text);
            }

            //Отдел
            if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
            {
                ORstringVPP += "  ((SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR)  " + GetCheckBoxStatus(textBox9) + " LIKE :OTD)  OR ";
                ParametersVPP.Add("OTD"); ValuesVPP.Add(textBox9.Text);
            }

            //формирование строки ТЗ
            if ((status == 3))
            {
                //Номер ТЗ
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox3), " ") != 0)
                {

                    ORstringTZ += "  (PDM_DOC_YTV.DOC " + GetCheckBoxStatus(textBox3) + " LIKE :DOC)  OR ";
                    ParametersVPP.Add("DOC"); ValuesVPP.Add(textBox3.Text);
                }

                //Обозначение детали
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox5), " ") != 0)
                {
                    ORstringTZ += "  (USP_TZ_DATA.OBOZN_DET  " + GetCheckBoxStatus(textBox5) + " LIKE :OBOZN_DET)  OR ";
                    ParametersVPP.Add("OBOZN_DET"); ValuesVPP.Add(textBox5.Text);
                }
                //Версия
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox6), " ") != 0)
                {
                    ORstringTZ += "  (PDM_DOC_YTV.REV  " + GetCheckBoxStatus(textBox6) + " LIKE :REVTZ)  OR ";
                    ParametersVPP.Add("REVTZ"); ValuesVPP.Add(textBox6.Text);
                }

                //Код изделия
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox7), " ") != 0)
                {
                    ORstringTZ += "  ((SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD) " + GetCheckBoxStatus(textBox7) + " LIKE :KBTZ)  OR ";
                    ParametersVPP.Add("KBTZ"); ValuesVPP.Add(textBox7.Text);
                }

                //Владелец
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox8), " ") != 0)
                {
                    ORstringTZ += "  (PDM_DOC_YTV.USR  " + GetCheckBoxStatus(textBox8) + " LIKE :USRTZ)  OR ";
                    ParametersVPP.Add("USRTZ"); ValuesVPP.Add(textBox8.Text);
                }

                //Отдел
                if (String.Compare(PriemSpisanie.IsNullParametr(textBox9), " ") != 0)
                {
                    ORstringTZ += "  ((SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR) " + GetCheckBoxStatus(textBox9) + " LIKE :OTDTZ)  OR ";
                    ParametersVPP.Add("OTDTZ"); ValuesVPP.Add(textBox9.Text);
                }


            }


            if (ORstringVPP.Length > 2)
            {
                ORstringVPP = ORstringVPP.Remove(ORstringVPP.Length - 3);
            }

            if (ORstringTZ.Length > 2)
            {
                ORstringTZ = ORstringTZ.Remove(ORstringTZ.Length - 3);
            }

            if (String.Compare(ORstringVPP, "") != 0)
            {
                ORstringVPP = "AND (" + ORstringVPP + ")";

            }

            if (String.Compare(ORstringTZ, "") != 0)
            {
                ORstringTZ = "AND (" + ORstringTZ + ")";
                
            }


            GenerateData(ORstringVPP, ORstringTZ, ref ParametersVPP, ref ValuesVPP);
            
        }


        void GenerateData(string sentenceVPP, string sentenceTZ, ref System.Collections.Generic.List<string> Parameters, ref System.Collections.Generic.List<string> Values)
        {
            if ((String.Compare(sentenceVPP, "") == 0) && (String.Compare(sentenceTZ, "") != 0))
            {            
               
                 string cmdQuery = "(SELECT PDM_DOC_YTV.ID_DOC AS \"ID_DOC\", " +
                          "NULL AS \"Номер ВПП\", " +
                        "PDM_DOC_YTV.DOC AS \"Номер ТЗ\", " +
                        "NULL AS \"Позиция ТЗ в ВПП\", " +
                        "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                        "PDM_DOC_YTV.REV AS \"Версия\", " +
                        "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"Код изделия\" , " +
                        "PDM_DOC_YTV.USR AS \"Владелец\", " +
                        "PDM_DOC_YTV.ARX_TIME AS \"Дата утверждения\", " +
                        "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"Отдел\" " +
                        "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                        "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                        dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                        "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                        "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1' and PDM_DOC_YTV.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS) ";

                cmdQuery += sentenceTZ + ")";

               
                dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent(cmdQuery, Parameters, Values).Tables[0];

                dataGridView1.Columns["ID_DOC"].Visible = false;
            }
            else if ((String.Compare(sentenceTZ, "") == 0)&&(String.Compare(sentenceVPP, "") != 0))
            {
                    string cmdQuery = "(select NULL AS \"ID_DOC\", N_VD AS \"Номер ВПП\"," +
                   " N_TZ AS \"Номер ТЗ\", " +
                   " POZ AS \"Позиция ТЗ в ВПП\", " +
                   "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"Обозначение детали\"," +
                   "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Версия\", " +
                   "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = ((SELECT PDM_DOC_YTV.IZD FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)) AND PDM_IZD.KB <> '0') AS \"Код изделия\" , " +
                   "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Владелец\", " +
                   "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Дата утверждения\", " +
                   "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"Отдел\" " +
                   "from VPP_TZ20 where N_VD = ANY (" +
                   "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY " +
                   "(select N_VD from VPP_TIT20 WHERE "+GetPRCodeForVppVZD()+" DT_R >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and DT_R <= to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss'))"; //фильтр и для поиска по критериям ниже


                    cmdQuery += " and PR1 = 1)" +
                        "  and NOT EXISTS(select * from USP_ASSEMBLY_ORDERS WHERE VPP_NUM = VPP_TZ20.N_VD AND TZ_NUM = VPP_TZ20.N_TZ) ";

                    cmdQuery += sentenceVPP + ")";                   

                   
                    dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent(cmdQuery, Parameters, Values).Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;

                }
                else if ((String.Compare(sentenceVPP, "") != 0) && (String.Compare(sentenceTZ, "") != 0))
                {
                    string cmdQuery = "(select NULL AS \"ID_DOC\", N_VD AS \"Номер ВПП\"," +
                     " N_TZ AS \"Номер ТЗ\", " +
                     " POZ AS \"Позиция ТЗ в ВПП\", " +
                     "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"Обозначение детали\"," +
                     "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Версия\", " +
                     "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = ((SELECT PDM_DOC_YTV.IZD FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)) AND PDM_IZD.KB <> '0') AS \"Код изделия\" , " +
                     "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Владелец\", " +
                     "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Дата утверждения\", " +
                     "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"Отдел\" " +
                     "from VPP_TZ20 where N_VD = ANY (" +
                     "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY " +
                     "(select N_VD from VPP_TIT20 WHERE  DT_R >= to_date('" + dateTimePicker1.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss') and DT_R <= to_date('" + dateTimePicker2.Value.ToString() + "','dd.mm.yyyy hh24:mi:ss'))"; //фильтр и для поиска по критериям ниже


                    cmdQuery += " and PR1 = 1)" +
                        " and NOT EXISTS(select * from USP_ASSEMBLY_ORDERS WHERE VPP_NUM = VPP_TZ20.N_VD AND TZ_NUM = VPP_TZ20.N_TZ) ";

                    cmdQuery += sentenceVPP + ")";

                    cmdQuery += " UNION (SELECT PDM_DOC_YTV.ID_DOC AS \"ID_DOC\", " +
                              "NULL AS \"Номер ВПП\", " +
                            "PDM_DOC_YTV.DOC AS \"Номер ТЗ\", " +
                            "NULL AS \"Позиция ТЗ в ВПП\", " +
                            "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                            "PDM_DOC_YTV.REV AS \"Версия\", " +
                            "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"Код изделия\" , " +
                            "PDM_DOC_YTV.USR AS \"Владелец\", " +
                            "PDM_DOC_YTV.ARX_TIME AS \"Дата утверждения\", " +
                            "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"Отдел\" " +
                            "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                            "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                            dateTimePicker2.Value.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                            "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + dateTimePicker1.Value.ToString() +
                            "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1'  AND USP_TZ_DATA.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS) ";

                    cmdQuery += sentenceTZ + ")";

               
                    dataGridView1.DataSource = SQLOracle.ParamQuerySelectNonPercent(cmdQuery, Parameters, Values).Tables[0];

                    dataGridView1.Columns["ID_DOC"].Visible = false;  
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
            if (status == 1)//Параметр для ВПП и ВПП на доработку
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumberExceptPercent(e, (System.Windows.Forms.TextBox)(sender));
        }

      
    
    }
       
}