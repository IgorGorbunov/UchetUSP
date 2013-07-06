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
    public partial class ActSpisanie : Form
    {
        private int statusOfAct = 0;
       
        /// <summary>
        /// статус формы акта на списание;
        /// </summary>
        /// <param name="status">
        ///0 - Загрузить информацию.       
        ///3- Удалить информацию.</param>
        /// <returns></returns>      
        public ActSpisanie(int status)
        {
            InitializeComponent();
            statusOfAct = status;
            checkStatus(status);
        }

        /// <summary>
        /// статус формы акта на списание;
        /// </summary>
        /// <param name="status">       
        ///1- Отобразить информацию.
        ///2- Редактировать информацию.
        ///3- Удалить информацию.</param>
        /// <returns></returns>      
        public ActSpisanie(int status,string number)
        {
            InitializeComponent();
            statusOfAct = status;
            checkStatus(status);
            viewData(number);
        }

        /// <summary>
        /// Внесение изменений в вид и функционал формы в зависимости от статуса вызова;
        /// </summary>
        /// <param name="status">       
        ///0- Загрузка данных.
        ///1-  Отображение данных.
        ///2- Обновление данных.
        ///3 - Удаление данных. </param>
        /// <returns></returns>   
        private void checkStatus( int status)
        {
            if(status==0)
            {
                this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.LoadDataToolStripMenuItem_Click);
                this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить данные"; 
                this.загрузитьДанныеToolStripMenuItem.Enabled = true;
                this.загрузитьДанныеToolStripMenuItem.Visible = true;
                this.Text = "Оформление акта на списание";

            }else if(status==1)
            {                
                this.загрузитьДанныеToolStripMenuItem.Enabled = false;
                this.загрузитьДанныеToolStripMenuItem.Visible = false;
                this.Text = "Просмотр акта на списание";
                //Установка всех элементов на панели в ReadOnly
                foreach(Control c in this.tabPage1.Controls)
                {
                    if (c is Panel)
                    {
                        foreach (Control panelContr in c.Controls)
                        {
                            if (panelContr is TextBox)
                            {
                                ((System.Windows.Forms.TextBox)panelContr).ReadOnly = true;
                            }
                            else if (panelContr is DateTimePicker)
                            {
                                ((System.Windows.Forms.DateTimePicker)panelContr).Enabled = false;
                            }
                         
                        }
                        
                    }else if(c is TextBox)
                    {
                        
                        ((System.Windows.Forms.TextBox)c).ReadOnly=true;
                    }
                    else if (c is DateTimePicker)
                    {
                        ((System.Windows.Forms.DateTimePicker)c).Enabled = false;
                    }
                }

                foreach(Control c in this.tabPage2.Controls)
                {

                    if (c is Panel)
                    {
                        foreach (Control panelContr in c.Controls)
                        {
                            if (panelContr is TextBox)
                            {
                                ((System.Windows.Forms.TextBox)panelContr).ReadOnly = true;
                            }
                            else if (panelContr is DateTimePicker)
                            {
                                ((System.Windows.Forms.DateTimePicker)panelContr).Enabled = false;
                            }

                        }

                    }
                    else if (c is TextBox)
                    {

                        ((System.Windows.Forms.TextBox)c).ReadOnly = true;
                    }
                    else if (c is DateTimePicker)
                    {
                        ((System.Windows.Forms.DateTimePicker)c).Enabled = false;
                    }
                }

                

            }else if(status==2)
            {
                this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.UpdateDataToolStripMenuItem_Click);
                this.загрузитьДанныеToolStripMenuItem.Enabled = true;
                this.загрузитьДанныеToolStripMenuItem.Visible = true;
                this.Text = "Редактирование акта на списание";
                this.загрузитьДанныеToolStripMenuItem.Text = "Обновить данные";
                this.J8.ReadOnly = true;

            }else if(status==3)
            {
                //this.загрузитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.загрузитьДанныеToolStripMenuItem_Click);
                this.загрузитьДанныеToolStripMenuItem.Enabled = true;
                this.загрузитьДанныеToolStripMenuItem.Visible = true;
                this.загрузитьДанныеToolStripMenuItem.Text = "Удалить данные"; 
            }

            
        
        }
         
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Проверка информации на наличие подобных актов на списание;
        /// </summary>       
        /// <returns></returns>   
        private string CheckInformation()
        {
            string DisplayErrors = "";

            if (SQLOracle.exist("USP_ACTNASPISANIE_HEAD", (string)("N_ACT = '" + J8.Text.ToString() + "'")) == true)
            {
                DisplayErrors += "Подобный номер акта на списание уже занесен\n";
            }

            if (PriemSpisanie.IsNumber(J8.Text.ToString()) == false)
            {
                DisplayErrors += "Недопустимо пустое поле для номера акта на списание\n";
            }

            if (String.Compare(DisplayErrors, "") == 0)
            {
                return "0";
            }
            else
            {

                return DisplayErrors;
            }

        }



        /// <summary>
        /// Выгрузка данных в Excel;
        /// </summary>        
        /// <returns></returns>   
        private void вExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ExcelClass InformationAboutElements = new ExcelClass();

            HashCode.HashCode.CheckFileByHash("акт на списание.xlt");

            if (System.IO.File.Exists(Program.PathString + "\\" + "акт на списание.xlt"))
            {                
                try
                {
                    HashCode.HashCode.CheckFileByHash("акт на списание.xlt");

                    InformationAboutElements.OpenDocument(Program.PathString + "\\акт на списание.xlt");
                    InformationAboutElements.Visible = false;
                    //Акт №
                    InformationAboutElements.SelectCells("J8", Type.Missing);
                    InformationAboutElements.WriteDataToCell(J8.Text.ToString());
                    //Должность оформляющего
                    InformationAboutElements.SelectCells("U4", Type.Missing);
                    InformationAboutElements.WriteDataToCell(U4.Text.ToString());
                    //Расшифровка подписи оформляющего
                    InformationAboutElements.SelectCells("U6", Type.Missing);
                    InformationAboutElements.WriteDataToCell(U6.Text.ToString());
                    //Организация
                    InformationAboutElements.SelectCells("D12", Type.Missing);
                    InformationAboutElements.WriteDataToCell(D12.Text.ToString());
                    //Структурное подразделение
                    InformationAboutElements.SelectCells("F14", Type.Missing);
                    InformationAboutElements.WriteDataToCell(F14.Text.ToString());

                    // Дата приказа
                    InformationAboutElements.SelectCells("J26", Type.Missing);
                    InformationAboutElements.WriteDataToCell(J26.Text.ToString());
                    // Год осмотра предметов
                    InformationAboutElements.SelectCells("S26", Type.Missing);
                    InformationAboutElements.WriteDataToCell(S26.Text.ToString());
                    // Форма по ОКПО
                    InformationAboutElements.SelectCells("Z10", Type.Missing);
                    InformationAboutElements.WriteDataToCell(Z10.Text.ToString());

                    //Общее количество предметов
                    InformationAboutElements.SelectCells("F86", Type.Missing);
                    InformationAboutElements.WriteDataToCell(F86.Text.ToString());

                    //Номера и акты выбытия
                    InformationAboutElements.SelectCells("F89", Type.Missing);
                    InformationAboutElements.WriteDataToCell(F89.Text.ToString());

                    //Утиль
                    InformationAboutElements.SelectCells("F112", Type.Missing);
                    InformationAboutElements.WriteDataToCell(((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find("F112", true)[0])).Text.ToString());


                    //Панели  
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < ((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panel" + i.ToString()), true)[0])).Controls.Count; j++)
                        {

                            InformationAboutElements.SelectCells(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panel" + i.ToString()), true)[0])).Controls[j].Name.ToString(), Type.Missing);
                            InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panel" + i.ToString()), true)[0])).Controls[j].Text.ToString());
                        }
                    }

                    for (int i = 7; i < 16; i++)
                    {
                        for (int j = 0; j < ((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panel" + i.ToString()), true)[0])).Controls.Count; j++)
                        {

                            InformationAboutElements.SelectCells(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panel" + i.ToString()), true)[0])).Controls[j].Name.ToString(), Type.Missing);
                            InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panel" + i.ToString()), true)[0])).Controls[j].Text.ToString());
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


                }
            }
        }

  
        private void проверитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (string.Compare(CheckInformation(), "0") == 0)
            {
                MessageBox.Show("Номер введен без ошибок", "Сообщение!");
            }
            else
            {
                MessageBox.Show(CheckInformation(), "Ошибка!");
            }

        }

        /// <summary>
        /// Загрузка данных в БД (запускается на статусе добавления данныз)
        /// </summary>      
        /// <returns></returns>   
        private void LoadInformationToDB()
        {

            if (string.Compare(CheckInformation(), "0") == 0)
            {
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

                System.Collections.Generic.List<string> DataFromTextBox = new System.Collections.Generic.List<string>();


                //Основные данные
                Parameters.Add("N_ACT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                Parameters.Add("OKUD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z10));
                Parameters.Add("UTV_DOLZNOST"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U4));
                Parameters.Add("UTV_RAS_PODP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U6));
                Parameters.Add("ORAGANIZATION_HEAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(D12));
                Parameters.Add("STRUCT_PODR_HEAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F14));
                Parameters.Add("DATA_SOST"); DataFromTextBox.Add(H22.Value.ToString());
                Parameters.Add("COD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(K22));
                Parameters.Add("STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(M22));
                Parameters.Add("NOMER_CEHA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(P22));
                Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(R22));
                Parameters.Add("CORRESP_SCHET"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U22));
                Parameters.Add("COD_ZATRAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Y22));
                Parameters.Add("PRICAZ_OT"); DataFromTextBox.Add(J26.Value.ToString());
                Parameters.Add("PRICAZ_YEAR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(S26));
                Parameters.Add("KOL_PREDETOV"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F86));
                Parameters.Add("NOM_ACT_VIB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F89));
                Parameters.Add("UTIL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F112));
                //Итог 1
                Parameters.Add("ITOG_KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J83));
                Parameters.Add("ITOG_DATA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(L83));
                Parameters.Add("ITOG_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(N83));
                Parameters.Add("ITOG_SUM_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(P83));
                Parameters.Add("ITOG_SUM_AMOR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(R83));
                Parameters.Add("ITOG_SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(T83));
                Parameters.Add("ITOG_PRIHINA_NAIMENOV"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(V83));
                Parameters.Add("ITOG_PRICH_COD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(X83));
                Parameters.Add("ITOG_SROK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z83));
                //Итог 2
                Parameters.Add("ITOGTWO_KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(S103));
                Parameters.Add("ITOGTWO_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U103));
                Parameters.Add("ITOGTWO_SUMMA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(X103));
                Parameters.Add("ITOGTWO_PORYAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z103));


                string cmd = "INSERT INTO USP_ACTNASPISANIE_HEAD" +
                    "(N_ACT, OKUD, UTV_DOLZNOST, UTV_RAS_PODP, ORAGANIZATION_HEAD, STRUCT_PODR_HEAD, "+
                    "DATA_SOST, COD_VIDA_OPER, STRUCT_PODR, NOMER_CEHA, VID_DEYAT, CORRESP_SCHET, COD_ZATRAT, "+
                    "PRICAZ_OT, PRICAZ_YEAR, KOL_PREDETOV, NOM_ACT_VIB, UTIL, ITOG_KOL, ITOG_DATA, ITOG_CENA, ITOG_SUM_CENA, "+
                    "ITOG_SUM_AMOR, ITOG_SROK_SLUZ, ITOG_PRIHINA_NAIMENOV, ITOG_PRICH_COD, ITOG_SROK, ITOGTWO_KOL, ITOGTWO_CENA, ITOGTWO_SUMMA, ITOGTWO_PORYAD)"+
                    " VALUES (:N_ACT, :OKUD, :UTV_DOLZNOST, :UTV_RAS_PODP, :ORAGANIZATION_HEAD, :STRUCT_PODR_HEAD,"+
                    "  to_date(:DATA_SOST,'DD.MM.YYYY hh24:mi:ss'), :COD_VIDA_OPER, :STRUCT_PODR, :NOMER_CEHA, :VID_DEYAT, :CORRESP_SCHET, :COD_ZATRAT, "+
                    "to_date(:PRICAZ_OT,'DD.MM.YYYY hh24:mi:ss'), :PRICAZ_YEAR, :KOL_PREDETOV, :NOM_ACT_VIB, :UTIL, :ITOG_KOL, :ITOG_DATA, :ITOG_CENA, :ITOG_SUM_CENA, "+
                    ":ITOG_SUM_AMOR, :ITOG_SROK_SLUZ, :ITOG_PRIHINA_NAIMENOV, :ITOG_PRICH_COD, :ITOG_SROK, :ITOGTWO_KOL, :ITOGTWO_CENA, :ITOGTWO_SUMMA, :ITOGTWO_PORYAD)";

                
                successToLoadData = SQLOracle.InsertQuery(cmd, Parameters, DataFromTextBox);
                
                //MessageBox.Show("1");

                Parameters.Clear();
                DataFromTextBox.Clear();
               
                if (successToLoadData == true)
                    for (int i = 1; i < 6; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "INSERT INTO USP_ACTNASPISANIE_DATA_ONE(ACT_NOMER,NUMBER_OF_PANEL," +
                                " PREDMET_NAIM, PREDMET_NOMEN_NOMER, PREDMET_INVENT_NOMER, ED_IZM_NAIM, ED_IZM_KOD, KOL_VO, DATA_POSTUPLENIYA, "+
                                "CENA, SUMMA_CENA_RUB, SUMMA_AMORTIZ, SROK_SLUZ, PRICH_SPIS_NAIM, PRICH_SPIS_KOD, NOMER_PASPORTA)" +
                                " VALUES(:ACT_NOMER,:NUMBER_OF_PANEL," +
                                " :PREDMET_NAIM, :PREDMET_NOMEN_NOMER, :PREDMET_INVENT_NOMER, :ED_IZM_NAIM, :ED_IZM_KOD, :KOL_VO,to_date(:DATA_POSTUPLENIYA,'DD.MM.YYYY hh24:mi:ss')," +
                                " :CENA, :SUMMA_CENA_RUB, :SUMMA_AMORTIZ, :SROK_SLUZ, :PRICH_SPIS_NAIM, :PRICH_SPIS_KOD, :NOMER_PASPORTA)";


                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            Parameters.Add("PREDMET_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1))+36).ToString()), true)[0])));
                            Parameters.Add("PREDMET_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1))+38).ToString()), true)[0])));
                            Parameters.Add("PREDMET_INVENT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("F" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 38).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("J" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("DATA_POSTUPLENIYA"); DataFromTextBox.Add(((System.Windows.Forms.DateTimePicker)(this.tabPage1.Controls.Find(("L" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Value.ToString());
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("N" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SUMMA_CENA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("P" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SUMMA_AMORTIZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("R" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("T" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("V" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("X" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("NOMER_PASPORTA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("Z" + ((4 * (i - 1)) + 36).ToString()), true)[0])));

                            successToLoadData = SQLOracle.InsertQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }

                if (successToLoadData == true)
                    for (int i = 7; i < 12; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "INSERT INTO USP_ACTNASPISANIE_DATA_ONE(ACT_NOMER,NUMBER_OF_PANEL," +
                                " PREDMET_NAIM, PREDMET_NOMEN_NOMER, PREDMET_INVENT_NOMER, ED_IZM_NAIM, ED_IZM_KOD, KOL_VO, DATA_POSTUPLENIYA, " +
                                "CENA, SUMMA_CENA_RUB, SUMMA_AMORTIZ, SROK_SLUZ, PRICH_SPIS_NAIM, PRICH_SPIS_KOD,NOMER_PASPORTA)" +
                                " VALUES(:ACT_NOMER,:NUMBER_OF_PANEL," +
                                " :PREDMET_NAIM, :PREDMET_NOMEN_NOMER, :PREDMET_INVENT_NOMER, :ED_IZM_NAIM, :ED_IZM_KOD, :KOL_VO, to_date(:DATA_POSTUPLENIYA,'DD.MM.YYYY hh24:mi:ss')," +
                                " :CENA, :SUMMA_CENA_RUB, :SUMMA_AMORTIZ, :SROK_SLUZ, :PRICH_SPIS_NAIM, :PRICH_SPIS_KOD, :NOMER_PASPORTA)";


                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            Parameters.Add("PREDMET_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) + 39 ).ToString()), true)[0])));
                            Parameters.Add("PREDMET_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) +41).ToString()), true)[0])));
                            Parameters.Add("PREDMET_INVENT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 41).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("J" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("DATA_POSTUPLENIYA"); DataFromTextBox.Add(((System.Windows.Forms.DateTimePicker)(this.tabPage2.Controls.Find(("L" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Value.ToString());
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("N" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SUMMA_CENA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("P" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SUMMA_AMORTIZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("R" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("T" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("V" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("NOMER_PASPORTA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((4 * (i - 1)) + 39).ToString()), true)[0])));

                            successToLoadData = SQLOracle.InsertQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }

                if (successToLoadData == true)
                    for (int i = 1; i <=2; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "INSERT INTO USP_ACTNASPISANIE_DATA_TWO(ACT_NOMER,NUMBER_OF_PANEL,KOD_VIDA_OPER, VID_DEYAT, STRUCT_PODR, UTIL_NAIM, UTIL_NOMEN_NOMER, ED_IZM_NAIM, ED_IZM_KOD, KOL_VO, CENA, SUMMA_RUB, PORYADKOV_NUM)" +
                                " VALUES(:ACT_NOMER,:NUMBER_OF_PANEL, :KOD_VIDA_OPER, :VID_DEYAT, :STRUCT_PODR, :UTIL_NAIM, :UTIL_NOMEN_NOMER, :ED_IZM_NAIM, :ED_IZM_KOD, :KOL_VO, :CENA, :SUMMA_RUB,:PORYADKOV_NUM)";
                            

                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            Parameters.Add("KOD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("C" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("UTIL_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("I" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("UTIL_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("L" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("O" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Q" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("S" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("U" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("SUMMA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("PORYADKOV_NUM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((2 * (i - 1)) + 99).ToString()), true)[0])));

                            successToLoadData = SQLOracle.InsertQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }


                if (successToLoadData == true)
                {
                    MessageBox.Show("Данные успешно загружены!");
                }

            }
            else
            {
                MessageBox.Show(CheckInformation(), "Ошибка!");
            }
        }

        /// <summary>
        /// Отображение данных из БД в форме акта на списание по нмоеру
        /// </summary>
        /// <param name="number">       
        ///Номер требуемого акта на списание</param>
        /// <returns></returns>   
        private void viewData(string number)
        {            
               
                System.Data.DataSet GetData = SQLOracle.getDS("Select * FROM USP_ACTNASPISANIE_HEAD WHERE N_ACT = '" + number + "'");
                            
                J8.Text = GetData.Tables[0].Rows[0][0].ToString();
                Z10.Text = GetData.Tables[0].Rows[0][1].ToString();
                U4.Text = GetData.Tables[0].Rows[0][2].ToString();
                U6.Text = GetData.Tables[0].Rows[0][3].ToString();
                D12.Text = GetData.Tables[0].Rows[0][4].ToString();
                F14.Text = GetData.Tables[0].Rows[0][5].ToString();
                H22.Text = GetData.Tables[0].Rows[0][6].ToString();
                K22.Text = GetData.Tables[0].Rows[0][7].ToString();
                M22.Text = GetData.Tables[0].Rows[0][8].ToString();
                P22.Text = GetData.Tables[0].Rows[0][9].ToString();
                R22.Text = GetData.Tables[0].Rows[0][10].ToString();
                U22.Text = GetData.Tables[0].Rows[0][11].ToString();
                Y22.Text = GetData.Tables[0].Rows[0][12].ToString();
                J26.Text = GetData.Tables[0].Rows[0][13].ToString();
                S26.Text = GetData.Tables[0].Rows[0][14].ToString();
                F86.Text = GetData.Tables[0].Rows[0][15].ToString();
                F89.Text = GetData.Tables[0].Rows[0][16].ToString();
                F112.Text = GetData.Tables[0].Rows[0][17].ToString();
                J83.Text = GetData.Tables[0].Rows[0][18].ToString();
                L83.Text = GetData.Tables[0].Rows[0][19].ToString();
                N83.Text = GetData.Tables[0].Rows[0][20].ToString();
                P83.Text = GetData.Tables[0].Rows[0][21].ToString();
                R83.Text = GetData.Tables[0].Rows[0][22].ToString();
                T83.Text = GetData.Tables[0].Rows[0][23].ToString();
                V83.Text = GetData.Tables[0].Rows[0][24].ToString();
                X83.Text = GetData.Tables[0].Rows[0][25].ToString();
                Z83.Text = GetData.Tables[0].Rows[0][26].ToString();
                S103.Text = GetData.Tables[0].Rows[0][27].ToString();
                U103.Text = GetData.Tables[0].Rows[0][28].ToString();
                X103.Text = GetData.Tables[0].Rows[0][29].ToString();
                Z103.Text = GetData.Tables[0].Rows[0][30].ToString();

                GetData.Clear();

                for (int i = 1; i < 6; i++)
                {
                    GetData = SQLOracle.getDS("Select * FROM USP_ACTNASPISANIE_DATA_ONE WHERE ACT_NOMER = '" + number + "' AND NUMBER_OF_PANEL = '" + i + "'");
                                                
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][1].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1)) + 38).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][2].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("F" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][3].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][4].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 38).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][5].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("J" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][6].ToString();
                    ((System.Windows.Forms.DateTimePicker)(this.tabPage1.Controls.Find(("L" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][7].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("N" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][8].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("P" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][9].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("R" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][10].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("T" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][11].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("V" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][12].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("X" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][13].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("Z" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][15].ToString(); //перескочил т.к. в БД номер панелей предпоследний

                    GetData.Clear();
                }

                for (int i = 7; i < 12; i++)
                {
                    GetData = SQLOracle.getDS("Select * FROM USP_ACTNASPISANIE_DATA_ONE WHERE ACT_NOMER = '" + number + "' AND NUMBER_OF_PANEL = '" + i + "'");

                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][1].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) + 41).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][2].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][3].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][4].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 41).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][5].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("J" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][6].ToString();
                    ((System.Windows.Forms.DateTimePicker)(this.tabPage2.Controls.Find(("L" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][7].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("N" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][8].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("P" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][9].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("R" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][10].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("T" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][11].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("V" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][12].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][13].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][15].ToString(); //перескочил т.к. в БД номер панелей предпоследний

                    GetData.Clear();
                }

                for (int i = 1; i <= 2; i++)
                {
                    GetData = SQLOracle.getDS("Select * FROM USP_ACTNASPISANIE_DATA_TWO WHERE ACT_NOMER = '" + number + "' AND NUMBER_OF_PANEL = '" + i + "'");

                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][1].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("C" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][2].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][3].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("I" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][4].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("L" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][5].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("O" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][6].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Q" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][7].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("S" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][8].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("U" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][9].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][10].ToString();
                    ((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((2 * (i - 1)) + 99).ToString()), true)[0])).Text = GetData.Tables[0].Rows[0][12].ToString(); //перескочил т.к. в БД номер панелей предпоследний

                    GetData.Clear();
                }

                GetData.Dispose();
            
        }




        /// <summary>
        /// Загрузка данных в БД (запускается на статусе добавления данныз)
        /// </summary>      
        /// <returns></returns>   
        private void UpdateInformationInDB()
        {
            //проверяем есть ли такой номер в БД (на случай если кто-то удалит его в процессе работы)
            if (string.Compare(CheckInformation(), "0") != 0)
            {
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

                System.Collections.Generic.List<string> DataFromTextBox = new System.Collections.Generic.List<string>();


                //Основные данные
                
                Parameters.Add("OKUD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z10));
                Parameters.Add("UTV_DOLZNOST"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U4));
                Parameters.Add("UTV_RAS_PODP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U6));
                Parameters.Add("ORAGANIZATION_HEAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(D12));
                Parameters.Add("STRUCT_PODR_HEAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F14));
                Parameters.Add("DATA_SOST"); DataFromTextBox.Add(H22.Value.ToString());
                Parameters.Add("COD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(K22));
                Parameters.Add("STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(M22));
                Parameters.Add("NOMER_CEHA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(P22));
                Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(R22));
                Parameters.Add("CORRESP_SCHET"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U22));
                Parameters.Add("COD_ZATRAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Y22));
                Parameters.Add("PRICAZ_OT"); DataFromTextBox.Add(J26.Value.ToString());
                Parameters.Add("PRICAZ_YEAR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(S26));
                Parameters.Add("KOL_PREDETOV"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F86));
                Parameters.Add("NOM_ACT_VIB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F89));
                Parameters.Add("UTIL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(F112));
                //Итог 1
                Parameters.Add("ITOG_KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J83));
                Parameters.Add("ITOG_DATA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(L83));
                Parameters.Add("ITOG_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(N83));
                Parameters.Add("ITOG_SUM_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(P83));
                Parameters.Add("ITOG_SUM_AMOR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(R83));
                Parameters.Add("ITOG_SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(T83));
                Parameters.Add("ITOG_PRIHINA_NAIMENOV"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(V83));
                Parameters.Add("ITOG_PRICH_COD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(X83));
                Parameters.Add("ITOG_SROK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z83));
                //Итог 2
                Parameters.Add("ITOGTWO_KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(S103));
                Parameters.Add("ITOGTWO_CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(U103));
                Parameters.Add("ITOGTWO_SUMMA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(X103));
                Parameters.Add("ITOGTWO_PORYAD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(Z103));
                //Номер акта
                Parameters.Add("N_ACT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                
               
                string cmd = "UPDATE USP_ACTNASPISANIE_HEAD SET" +                 
                " OKUD = :OKUD,  "+
                " UTV_DOLZNOST = :UTV_DOLZNOST,  "+
                " UTV_RAS_PODP = :UTV_RAS_PODP,  "+
                " ORAGANIZATION_HEAD = :ORAGANIZATION_HEAD,  "+
                " STRUCT_PODR_HEAD = :STRUCT_PODR_HEAD, " +
                " DATA_SOST = to_date(:DATA_SOST,'DD.MM.YYYY hh24:mi:ss'),  "+
                " COD_VIDA_OPER = :COD_VIDA_OPER,  "+
                " STRUCT_PODR = :STRUCT_PODR,  "+
                " NOMER_CEHA = :NOMER_CEHA,  "+
                " VID_DEYAT = :VID_DEYAT,  "+
                " CORRESP_SCHET = :CORRESP_SCHET,  "+
                " COD_ZATRAT = :COD_ZATRAT, " +
                " PRICAZ_OT = to_date(:PRICAZ_OT,'DD.MM.YYYY hh24:mi:ss'), "+ 
                " PRICAZ_YEAR = :PRICAZ_YEAR,  "+
                " KOL_PREDETOV = :KOL_PREDETOV, "+ 
                " NOM_ACT_VIB = :NOM_ACT_VIB,  "+
                " UTIL = :UTIL,  "+
                " ITOG_KOL = :ITOG_KOL,  "+
                " ITOG_DATA = :ITOG_DATA,  "+
                " ITOG_CENA = :ITOG_CENA,  "+
                " ITOG_SUM_CENA = :ITOG_SUM_CENA, " +
                " ITOG_SUM_AMOR = :ITOG_SUM_AMOR, " +
                " ITOG_SROK_SLUZ = :ITOG_SROK_SLUZ,  "+
                " ITOG_PRIHINA_NAIMENOV = :ITOG_PRIHINA_NAIMENOV,  "+
                " ITOG_PRICH_COD = :ITOG_PRICH_COD,  "+
                " ITOG_SROK = :ITOG_SROK,  "+
                " ITOGTWO_KOL = :ITOGTWO_KOL,  "+
                " ITOGTWO_CENA = :ITOGTWO_CENA,  "+
                " ITOGTWO_SUMMA = :ITOGTWO_SUMMA, "+ 
                " ITOGTWO_PORYAD = :ITOGTWO_PORYAD " +
                "WHERE N_ACT = :N_ACT";    

                successToLoadData = SQLOracle.UpdateQuery(cmd, Parameters, DataFromTextBox);

                
                Parameters.Clear();
                DataFromTextBox.Clear();

                if (successToLoadData == true)
                    for (int i = 1; i < 6; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "UPDATE USP_ACTNASPISANIE_DATA_ONE SET  " +                               
                                " PREDMET_NAIM = :PREDMET_NAIM, " +
                                " PREDMET_NOMEN_NOMER = :PREDMET_NOMEN_NOMER, " +
                                " PREDMET_INVENT_NOMER = :PREDMET_INVENT_NOMER, " +
                                " ED_IZM_NAIM = :ED_IZM_NAIM, " +
                                " ED_IZM_KOD = :ED_IZM_KOD, "+
                                " KOL_VO =: KOL_VO, " +
                                " DATA_POSTUPLENIYA = to_date(:DATA_POSTUPLENIYA,'DD.MM.YYYY hh24:mi:ss'), " +
                                " CENA = :CENA, " +
                                " SUMMA_CENA_RUB = :SUMMA_CENA_RUB, " +
                                " SUMMA_AMORTIZ = :SUMMA_AMORTIZ, " +
                                " SROK_SLUZ = :SROK_SLUZ, " +
                                " PRICH_SPIS_NAIM =:PRICH_SPIS_NAIM, " +
                                " PRICH_SPIS_KOD = :PRICH_SPIS_KOD, " +
                                " NOMER_PASPORTA = :NOMER_PASPORTA WHERE " +
                                " ACT_NOMER = :ACT_NOMER AND" +
                                " NUMBER_OF_PANEL = :NUMBER_OF_PANEL " ;
                            

                            

                            Parameters.Add("PREDMET_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("PREDMET_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("A" + ((4 * (i - 1)) + 38).ToString()), true)[0])));
                            Parameters.Add("PREDMET_INVENT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("F" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("H" + ((4 * (i - 1)) + 38).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("J" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("DATA_POSTUPLENIYA"); DataFromTextBox.Add(((System.Windows.Forms.DateTimePicker)(this.tabPage1.Controls.Find(("L" + ((4 * (i - 1)) + 36).ToString()), true)[0])).Value.ToString());
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("N" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SUMMA_CENA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("P" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SUMMA_AMORTIZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("R" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("T" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("V" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("X" + ((4 * (i - 1)) + 36).ToString()), true)[0])));
                            Parameters.Add("NOMER_PASPORTA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage1.Controls.Find(("Z" + ((4 * (i - 1)) + 36).ToString()), true)[0])));

                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            successToLoadData = SQLOracle.UpdateQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }

                if (successToLoadData == true)
                    for (int i = 7; i < 12; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "UPDATE USP_ACTNASPISANIE_DATA_ONE SET  " +                             
                               " PREDMET_NAIM = :PREDMET_NAIM, " +
                               " PREDMET_NOMEN_NOMER = :PREDMET_NOMEN_NOMER, " +
                               " PREDMET_INVENT_NOMER = :PREDMET_INVENT_NOMER, " +
                               " ED_IZM_NAIM = :ED_IZM_NAIM, " +
                               " ED_IZM_KOD = :ED_IZM_KOD, " +
                               " KOL_VO =: KOL_VO, " +
                               " DATA_POSTUPLENIYA = to_date(:DATA_POSTUPLENIYA,'DD.MM.YYYY hh24:mi:ss'), " +
                               " CENA = :CENA, " +
                               " SUMMA_CENA_RUB = :SUMMA_CENA_RUB, " +
                               " SUMMA_AMORTIZ = :SUMMA_AMORTIZ, " +
                               " SROK_SLUZ = :SROK_SLUZ, " +
                               " PRICH_SPIS_NAIM =:PRICH_SPIS_NAIM, " +
                               " PRICH_SPIS_KOD = :PRICH_SPIS_KOD, " +
                               " NOMER_PASPORTA = :NOMER_PASPORTA WHERE " +
                               " ACT_NOMER = :ACT_NOMER AND " +
                                " NUMBER_OF_PANEL = :NUMBER_OF_PANEL " ;
                          

                            Parameters.Add("PREDMET_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("PREDMET_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((4 * (i - 1)) + 41).ToString()), true)[0])));
                            Parameters.Add("PREDMET_INVENT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("H" + ((4 * (i - 1)) + 41).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("J" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("DATA_POSTUPLENIYA"); DataFromTextBox.Add(((System.Windows.Forms.DateTimePicker)(this.tabPage2.Controls.Find(("L" + ((4 * (i - 1)) + 39).ToString()), true)[0])).Value.ToString());
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("N" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SUMMA_CENA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("P" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SUMMA_AMORTIZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("R" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("SROK_SLUZ"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("T" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("V" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("PRICH_SPIS_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((4 * (i - 1)) + 39).ToString()), true)[0])));
                            Parameters.Add("NOMER_PASPORTA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((4 * (i - 1)) + 39).ToString()), true)[0])));

                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            successToLoadData = SQLOracle.UpdateQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }

                if (successToLoadData == true)
                    for (int i = 1; i <= 2; i++)
                    {
                        if (successToLoadData == true)
                        {
                            string cmdDATA = "UPDATE USP_ACTNASPISANIE_DATA_TWO SET " +  
                                " KOD_VIDA_OPER =: KOD_VIDA_OPER, " +
                                " VID_DEYAT =: VID_DEYAT, " +
                                " STRUCT_PODR =: STRUCT_PODR, " +
                                " UTIL_NAIM = :UTIL_NAIM, " +
                                " UTIL_NOMEN_NOMER = :UTIL_NOMEN_NOMER, " +
                                " ED_IZM_NAIM =:ED_IZM_NAIM, " +
                                " ED_IZM_KOD =:ED_IZM_KOD, " +
                                " KOL_VO =:KOL_VO, " +
                                " CENA = :CENA, " +
                                " SUMMA_RUB =:SUMMA_RUB, " +
                                " PORYADKOV_NUM =:PORYADKOV_NUM" +
                                " WHERE ACT_NOMER = :ACT_NOMER  AND " +
                                " NUMBER_OF_PANEL = :NUMBER_OF_PANEL ";

                            

                            Parameters.Add("KOD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("A" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("C" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("F" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("UTIL_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("I" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("UTIL_NOMEN_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("L" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_NAIM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("O" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("ED_IZM_KOD"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Q" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("KOL_VO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("S" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("U" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("SUMMA_RUB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("X" + ((2 * (i - 1)) + 99).ToString()), true)[0])));
                            Parameters.Add("PORYADKOV_NUM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)(this.tabPage2.Controls.Find(("Z" + ((2 * (i - 1)) + 99).ToString()), true)[0])));

                            Parameters.Add("ACT_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(J8));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i).ToString());

                            successToLoadData = SQLOracle.UpdateQuery(cmdDATA, Parameters, DataFromTextBox);

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    }


                if (successToLoadData == true)
                {
                    MessageBox.Show("Данные успешно обновлены!");
                }

            }
            else
            {
                MessageBox.Show(CheckInformation(), "Ошибка!");
            }
        }


        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInformationInDB();
        }

        private void LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInformationToDB();
        }

       

        private void Z10_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void A65_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
           
        }

        private void P36_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotMoney(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void P36_Leave(object sender, EventArgs e)
        {
            PriemSpisanie.blockKeyNotMoneyLeaveEvent((System.Windows.Forms.TextBox)(sender));
            countMoneyMainFields();
        }

        private void N63_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotMoney(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void N63_Leave(object sender, EventArgs e)
        {
            PriemSpisanie.blockKeyNotMoneyLeaveEvent((System.Windows.Forms.TextBox)(sender));
            countMoneyMainFields();
        }

        private void U99_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotMoney(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void U99_Leave(object sender, EventArgs e)
        {
            PriemSpisanie.blockKeyNotMoneyLeaveEvent((System.Windows.Forms.TextBox)(sender));
            countMoneySecondFields();
        
        }

        private void countMoneyMainFields()
        {
            N83.Clear();
            P83.Clear();
            R83.Clear();

            N83.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N36))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N40))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N44))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N48))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N52))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N63))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N67))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N71))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N75))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(N79))));

            P83.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P36))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P40))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P44))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P48))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P52))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P63))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P67))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P71))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P75))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(P79))));

            R83.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R36))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R40))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R44))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R48))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R52))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R63))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R67))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R71))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R75))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(R79))));
        
        }

        private void countMainFields()
        {
            J83.Clear();

            J83.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J36))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J40))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J44))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J48))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J52))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J63))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J67))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J71))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J75))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(J79))));
                       
        }

        private void J79_KeyUp(object sender, KeyEventArgs e)
        {
            countMainFields();
        }

        private void J36_KeyUp(object sender, KeyEventArgs e)
        {
            countMainFields();
        }

        private void countMoneySecondFields()
        {

            S103.Clear();
            U103.Clear();
            X103.Clear();

            S103.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(S99))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(S101))));
            U103.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(U99))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(U101))));
            X103.Text = Convert.ToString((Convert.ToDouble(PriemSpisanie.IsEmptyParametr(X99))) + (Convert.ToDouble(PriemSpisanie.IsEmptyParametr(X101))));
            
        }

        private void S101_Leave(object sender, EventArgs e)
        {
            countMoneySecondFields();
        }

        private void L40_ValueChanged(object sender, EventArgs e)
        {

        }

        



       
      
       
        

      

     

    }
}