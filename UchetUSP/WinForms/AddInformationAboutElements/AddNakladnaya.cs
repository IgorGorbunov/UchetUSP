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
    public partial class AddNakladnaya : Form
    {
        private int statusOfAct = 0;
          /// <summary>
        /// статус формы акта на списание;
        /// </summary>
        /// <param name="status">
        ///0 - Загрузить информацию</param>
        /// <returns></returns>   
        public AddNakladnaya(int status)
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
        ///2- Редактировать информацию.</param>
        /// <returns></returns>      
        public AddNakladnaya(int status, string number)
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
                this.загрузитьИнформациюToolStripMenuItem.Click += new System.EventHandler(this.LoadDataToolStripMenuItem_Click);
                this.загрузитьИнформациюToolStripMenuItem.Text = "Загрузить данные";
                this.загрузитьИнформациюToolStripMenuItem.Enabled = true;
                this.загрузитьИнформациюToolStripMenuItem.Visible = true;
                this.Text = "Оформление требование-накладной";

            }else if(status==1)
            {
                this.загрузитьИнформациюToolStripMenuItem.Enabled = false;
                this.загрузитьИнформациюToolStripMenuItem.Visible = false;
                this.Text = "Просмотр требование-накладной";
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
                this.загрузитьИнформациюToolStripMenuItem.Click += new System.EventHandler(this.UpdateDataToolStripMenuItem_Click);
                this.загрузитьИнформациюToolStripMenuItem.Enabled = true;
                this.загрузитьИнформациюToolStripMenuItem.Visible = true;
                this.загрузитьИнформациюToolStripMenuItem.Text = "Обновить данные";
                this.PanelN1OneA.ReadOnly = true;
                this.Text = "Редактирование требования-накладной";

            }

            
        
        }



        private void AddNakladnaya_Load(object sender, EventArgs e)
        {
           
            
        }


        private string CheckInformation()
        {
            string DisplayErrors = "";

            if (SQLOracle.exist("KTC.USP_NAKLADNAYA_HEAD", (string)("NOMER_TREBOV_NAKLADNOI = '" + PanelN1OneA.Text.ToString() + "'")) == true)
            {
                DisplayErrors += "Подобный номер требования накладной уже занесен\n";
            }

            if (IsNumber(PanelN1OneA.Text.ToString())==false)
            {
                DisplayErrors += "Недопустимо пустое поле для номера требования накладной\n";            
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


        private bool IsNumber(string num)
        {
            System.Text.RegularExpressions.Regex rxNums = new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (rxNums.IsMatch(num))
            { 
                return true;
            }
            else
            {                
                return false;
            }
        }

        private void вExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelClass InformationAboutElements = new ExcelClass();

            HashCode.HashCode.CheckFileByHash("требование-накладная.xlt");

            if (System.IO.File.Exists(Program.PathString + "\\требование-накладная.xlt"))
            {

                try
                {

                    int TagOfObject = 0;
                    InformationAboutElements.OpenDocument(Program.PathString + "\\требование-накладная.xlt");
                    InformationAboutElements.Visible = false;
                    //перевод данных в Excel
                    //органзация
                    InformationAboutElements.SelectCells("D8", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox1.Text.ToString());
                    //номер требование накладной
                    InformationAboutElements.SelectCells("C19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1OneA.Text.ToString());
                    //Дата составления
                    InformationAboutElements.SelectCells("F19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1One.Text.ToString());
                    //Код вида операций
                    InformationAboutElements.SelectCells("I19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1two.Text.ToString());
                    //структурное подразделение
                    InformationAboutElements.SelectCells("K19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1three.Text.ToString());
                    //вид деятельности
                    InformationAboutElements.SelectCells("N19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1four.Text.ToString());
                    //шифр получателя
                    InformationAboutElements.SelectCells("Q19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1five.Text.ToString());
                    //шифр потребителя
                    InformationAboutElements.SelectCells("S19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1FiveA.Text.ToString());
                    //вид деятельности
                    InformationAboutElements.SelectCells("U19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1Six.Text.ToString());
                    //Учетная ед. выпуска продукции (работ. услуг)
                    InformationAboutElements.SelectCells("X19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1Seven.Text.ToString());
                    //Порядковый но-мер, по склад. картотеке
                    InformationAboutElements.SelectCells("AA19", Type.Missing);
                    InformationAboutElements.WriteDataToCell(PanelN1sevenA.Text.ToString());
                    //Через кого
                    InformationAboutElements.SelectCells("C23", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox2.Text.ToString());
                    //Затребовал
                    InformationAboutElements.SelectCells("C25", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox3.Text.ToString());
                    //Разрешил
                    InformationAboutElements.SelectCells("W25", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox4.Text.ToString());
                    //Отпустил дата
                    InformationAboutElements.SelectCells("C111", Type.Missing);
                    InformationAboutElements.WriteDataToCell(dateTimePicker1.Text.ToString());
                    //Отпустил фамилия
                    InformationAboutElements.SelectCells("H111", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox245.Text.ToString());
                    //Получил фамилия
                    InformationAboutElements.SelectCells("V111", Type.Missing);
                    InformationAboutElements.WriteDataToCell(textBox246.Text.ToString());
                    //Получил дата
                    InformationAboutElements.SelectCells("R111", Type.Missing);
                    InformationAboutElements.WriteDataToCell(dateTimePicker2.Text.ToString());

                    for (int i = 0; i < 5; i++)
                        for (int j = 0; j < ((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls.Count; j++)
                        {

                            TagOfObject = (Convert.ToInt32(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Tag));

                            if (TagOfObject == 0)
                            {
                                //Корресп. Счет, суб-счет, код аналит. Учета
                                InformationAboutElements.SelectCells("A" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 1)
                            {
                                //Материальные ценности наименование (9)
                                InformationAboutElements.SelectCells("C" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 2)
                            {
                                //код материала
                                InformationAboutElements.SelectCells("C" + (i * 4 + 38).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 3)
                            {
                                //заводской номер
                                InformationAboutElements.SelectCells("F" + (i * 4 + 38).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 4)
                            {
                                //Ед. изм. Наимен. Код
                                InformationAboutElements.SelectCells("I" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 5)
                            {
                                //Ед. изм. Наимен. Код
                                InformationAboutElements.SelectCells("I" + (i * 4 + 38).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 6)
                            {
                                //затребовано
                                InformationAboutElements.SelectCells("K" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 7)
                            {
                                //отпущено
                                InformationAboutElements.SelectCells("M" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 8)
                            {
                                //Цена (руб., коп.)
                                InformationAboutElements.SelectCells("O" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 9)
                            {
                                //Сумма без расчета НДС, руб. коп.
                                InformationAboutElements.SelectCells("Q" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 10)
                            {
                                //Корреспон. счет, суб-счет, код аналит. учета
                                InformationAboutElements.SelectCells("S" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 11)
                            {
                                //Обесп. Серийн. № машины
                                InformationAboutElements.SelectCells("U" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 12)
                            {
                                //Некомп-плектный остаток
                                InformationAboutElements.SelectCells("W" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 13)
                            {
                                //Код издел. ШР, БЛ, № с/з
                                InformationAboutElements.SelectCells("Y" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 14)
                            {
                                //Признак раздела
                                InformationAboutElements.SelectCells("AA" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 15)
                            {
                                //Код основ. Матер.
                                InformationAboutElements.SelectCells("AC" + (i * 4 + 36).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage1.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                        }




                    for (int i = 5; i < 16; i++)
                        for (int j = 0; j < ((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls.Count; j++)
                        {

                            TagOfObject = (Convert.ToInt32(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Tag));

                            if (TagOfObject == 0)
                            {
                                //Корресп. Счет, суб-счет, код аналит. Учета
                                InformationAboutElements.SelectCells("A" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 1)
                            {
                                //Материальные ценности наименование (9)
                                InformationAboutElements.SelectCells("C" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 2)
                            {
                                //код материала
                                InformationAboutElements.SelectCells("C" + ((i - 5) * 4 + 67).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 3)
                            {
                                //заводской номер
                                InformationAboutElements.SelectCells("F" + ((i - 5) * 4 + 67).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 4)
                            {
                                //Ед. изм. Наимен. Код
                                InformationAboutElements.SelectCells("I" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 5)
                            {
                                //Ед. изм. Наимен. Код
                                InformationAboutElements.SelectCells("I" + ((i - 5) * 4 + 67).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 6)
                            {
                                //затребовано
                                InformationAboutElements.SelectCells("K" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 7)
                            {
                                //отпущено
                                InformationAboutElements.SelectCells("M" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());

                            }
                            else if (TagOfObject == 8)
                            {
                                //Цена (руб., коп.)
                                InformationAboutElements.SelectCells("O" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 9)
                            {
                                //Сумма без расчета НДС, руб. коп.
                                InformationAboutElements.SelectCells("Q" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 10)
                            {
                                //Корреспон. счет, суб-счет, код аналит. учета
                                InformationAboutElements.SelectCells("S" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 11)
                            {
                                //Обесп. Серийн. № машины
                                InformationAboutElements.SelectCells("U" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 12)
                            {
                                //Некомп-плектный остаток
                                InformationAboutElements.SelectCells("W" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 13)
                            {
                                //Код издел. ШР, БЛ, № с/з
                                InformationAboutElements.SelectCells("Y" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 14)
                            {
                                //Признак раздела
                                InformationAboutElements.SelectCells("AA" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
                            }
                            else if (TagOfObject == 15)
                            {
                                //Код основ. Матер.
                                InformationAboutElements.SelectCells("AC" + ((i - 5) * 4 + 65).ToString(), Type.Missing);
                                InformationAboutElements.WriteDataToCell(((System.Windows.Forms.Panel)(this.tabPage2.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Text.ToString());
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



        private void LoadInformationToDB()
        {

            if (string.Compare(CheckInformation(), "0") == 0)
            {
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

                System.Collections.Generic.List<string> DataFromTextBox = new System.Collections.Generic.List<string>();
              
                Parameters.Add("ORGANIZATION"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox1));
                Parameters.Add("NOMER_TREBOV_NAKLADNOI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1OneA));
                Parameters.Add("DATA_SOSTAVLENIYA"); DataFromTextBox.Add(PanelN1One.Value.ToString());
                Parameters.Add("COD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1two));
                Parameters.Add("OTPRAV_STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1three));
                Parameters.Add("OTPRAV_VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1four));
                Parameters.Add("SHIFR_POLUCH"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1five));
                Parameters.Add("SHIFR_POTREB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1FiveA));
                Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1Six));
                Parameters.Add("UCH_ED_VIP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1Seven));
                Parameters.Add("PORYAD_NUM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1sevenA));
                Parameters.Add("CHEREZ_KOGO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox2));
                Parameters.Add("ZATREBOVAL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox3));
                Parameters.Add("RAZRESHIL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox4));
                Parameters.Add("OTPUSTIL_DATE"); DataFromTextBox.Add(dateTimePicker1.Value.ToString());
                Parameters.Add("OTPUSTIL_FAM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox245));
                Parameters.Add("POLUCHIL_DATE"); DataFromTextBox.Add(dateTimePicker2.Value.ToString());
                Parameters.Add("POLUCHIL_FAM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox246));


                string cmd = "INSERT INTO KTC.USP_NAKLADNAYA_HEAD(ORGANIZATION, NOMER_TREBOV_NAKLADNOI, DATA_SOSTAVLENIYA, COD_VIDA_OPER, OTPRAV_STRUCT_PODR, OTPRAV_VID_DEYAT, SHIFR_POLUCH, SHIFR_POTREB, VID_DEYAT, UCH_ED_VIP, PORYAD_NUM, CHEREZ_KOGO, " +
                        "ZATREBOVAL, RAZRESHIL, OTPUSTIL_DATE, OTPUSTIL_FAM, POLUCHIL_DATE, POLUCHIL_FAM) VALUES (:ORGANIZATION, :NOMER_TREBOV_NAKLADNOI, to_date(:DATA_SOSTAVLENIYA,'DD.MM.YYYY hh24:mi:ss'), :COD_VIDA_OPER, :OTPRAV_STRUCT_PODR, :OTPRAV_VID_DEYAT, :SHIFR_POLUCH, :SHIFR_POTREB, :VID_DEYAT, :UCH_ED_VIP, :PORYAD_NUM" +
                        ", :CHEREZ_KOGO, :ZATREBOVAL, :RAZRESHIL, to_date(:OTPUSTIL_DATE,'DD.MM.YYYY hh24:mi:ss'), :OTPUSTIL_FAM, to_date(:POLUCHIL_DATE,'DD.MM.YYYY hh24:mi:ss'), :POLUCHIL_FAM)";

                successToLoadData = SQLOracle.InsertQuery(cmd, Parameters, DataFromTextBox);


                Parameters.Clear();
                DataFromTextBox.Clear();

                if (successToLoadData==true)
                        for (int i = 0; i < 16; i++)
                        {
                            string cmdDATA = "INSERT INTO KTC.USP_NAKLADNAYA_DATA (NOMER_TREBOV_NAKLADNOI,NUMBER_OF_PANEL";
                            
                            string cmdValue = "VALUES(:NOMER_TREBOV_NAKLADNOI,:NUMBER_OF_PANEL";

                           
                            Parameters.Add("NOMER_TREBOV_NAKLADNOI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1OneA));
                            Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i + 2).ToString());

                            for (int j = 0; j < ((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls.Count; j++)
                            {

                                int TagOfObject = (Convert.ToInt32(((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Tag));

                                if (TagOfObject == 0)
                                {
                                    //Корресп. Счет, суб-счет, код аналит. Учета
                                    Parameters.Add("KORRESP_SCHET"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));

                                    cmdDATA += ",KORRESP_SCHET"; cmdValue += ",:KORRESP_SCHET";
                                }
                                else if (TagOfObject == 1)
                                {
                                    //Материальные ценности наименование (9)
                                    Parameters.Add("MATERR_CENNOSTI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",MATERR_CENNOSTI"; cmdValue += ",:MATERR_CENNOSTI";
                                }
                                else if (TagOfObject == 2)
                                {
                                    //код материала
                                    Parameters.Add("COD_MATER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",COD_MATER"; cmdValue += ",:COD_MATER";
                                }
                                else if (TagOfObject == 3)
                                {
                                    //заводской номер
                                    Parameters.Add("ZAVOD_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",ZAVOD_NOMER"; cmdValue += ",:ZAVOD_NOMER";
                                }
                                else if (TagOfObject == 4)
                                {
                                    //Ед. изм. Наимен. Код
                                    Parameters.Add("ED_IZM_NAIM_1"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",ED_IZM_NAIM_1"; cmdValue += ",:ED_IZM_NAIM_1";
                                }
                                else if (TagOfObject == 5)
                                {
                                    //Ед. изм. Наимен. Код
                                    Parameters.Add("ED_IZM_NAIM_2"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",ED_IZM_NAIM_2"; cmdValue += ",:ED_IZM_NAIM_2";
                                }
                                else if (TagOfObject == 6)
                                {
                                    //затребовано
                                    Parameters.Add("ZATREBOVANO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",ZATREBOVANO"; cmdValue += ",:ZATREBOVANO";
                                }
                                else if (TagOfObject == 7)
                                {
                                    //отпущено
                                    Parameters.Add("OTPUSHENO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",OTPUSHENO"; cmdValue += ",:OTPUSHENO";
                                }
                                else if (TagOfObject == 8)
                                {
                                    //Цена (руб., коп.)
                                    Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",CENA"; cmdValue += ",:CENA";
                                }
                                else if (TagOfObject == 9)
                                {
                                    //Сумма без расчета НДС, руб. коп.
                                    Parameters.Add("SUMMA_BEZ_NDS"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",SUMMA_BEZ_NDS"; cmdValue += ",:SUMMA_BEZ_NDS";
                                }
                                else if (TagOfObject == 10)
                                {
                                    //Корреспон. счет, суб-счет, код аналит. учета
                                    Parameters.Add("KORRESP_SCHET_2"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",KORRESP_SCHET_2"; cmdValue += ",:KORRESP_SCHET_2";
                                }
                                else if (TagOfObject == 11)
                                {
                                    //Обесп. Серийн. № машины
                                    Parameters.Add("OBESP_SER_MASH"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",OBESP_SER_MASH"; cmdValue += ",:OBESP_SER_MASH";
                                }
                                else if (TagOfObject == 12)
                                {
                                    //Некомп-плектный остаток
                                    Parameters.Add("NEKOMPLEKT_OSTATOK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",NEKOMPLEKT_OSTATOK"; cmdValue += ",:NEKOMPLEKT_OSTATOK";
                                }
                                else if (TagOfObject == 13)
                                {
                                    //Код издел. ШР, БЛ, № с/з
                                    Parameters.Add("COD_IZD_SHR_BL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",COD_IZD_SHR_BL"; cmdValue += ",:COD_IZD_SHR_BL";
                                }
                                else if (TagOfObject == 14)
                                {
                                    //Признак раздела
                                    Parameters.Add("PRIZNAK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",PRIZNAK"; cmdValue += ",:PRIZNAK";
                                }
                                else if (TagOfObject == 15)
                                {
                                    //Код основ. Матер.
                                    Parameters.Add("COD_OSNOV_MATER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                    cmdDATA += ",COD_OSNOV_MATER"; cmdValue += ",:COD_OSNOV_MATER";
                                }
                            }
                        cmd = cmdDATA + ")" + cmdValue + ")";

                        successToLoadData = SQLOracle.InsertQuery(cmd, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();

                    
                    
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
        
        private void проверитьИнформациюToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void blockKeyNotNumber(KeyPressEventArgs e, System.Windows.Forms.TextBox textBox)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                if (textBox.Text.Length != 0)
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1, 1);
            }

            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }
            e.Handled = true;
        
        }

        //функция обновления данных
        private void UpdateInformationInDB()
        {
            if (string.Compare(CheckInformation(), "0") != 0)
            {
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

                System.Collections.Generic.List<string> DataFromTextBox = new System.Collections.Generic.List<string>();


                string cmd = "UPDATE KTC.USP_NAKLADNAYA_HEAD SET " +
                " ORGANIZATION = :ORGANIZATION, " +
                " DATA_SOSTAVLENIYA = to_date(:DATA_SOSTAVLENIYA,'DD.MM.YYYY hh24:mi:ss'), " +
                " COD_VIDA_OPER = :COD_VIDA_OPER, " +
                " OTPRAV_STRUCT_PODR = :OTPRAV_STRUCT_PODR, " +
                " OTPRAV_VID_DEYAT = :OTPRAV_VID_DEYAT, " +
                " SHIFR_POLUCH = :SHIFR_POLUCH, " +
                " SHIFR_POTREB = :SHIFR_POTREB, " +
                " VID_DEYAT = :VID_DEYAT, " +
                " UCH_ED_VIP = :UCH_ED_VIP, " +
                " PORYAD_NUM = :PORYAD_NUM, " +
                " CHEREZ_KOGO = :CHEREZ_KOGO, " +
                " ZATREBOVAL = :ZATREBOVAL, " +
                " RAZRESHIL = :RAZRESHIL, " +
                " OTPUSTIL_DATE = to_date(:OTPUSTIL_DATE,'DD.MM.YYYY hh24:mi:ss'), " +
                " OTPUSTIL_FAM = :OTPUSTIL_FAM, " +
                " POLUCHIL_DATE = to_date(:POLUCHIL_DATE,'DD.MM.YYYY hh24:mi:ss'), " +
                " POLUCHIL_FAM = :POLUCHIL_FAM " +
                " WHERE NOMER_TREBOV_NAKLADNOI = :NOMER_TREBOV_NAKLADNOI";

                Parameters.Add("ORGANIZATION"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox1));
                Parameters.Add("DATA_SOSTAVLENIYA"); DataFromTextBox.Add(PanelN1One.Value.ToString());
                Parameters.Add("COD_VIDA_OPER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1two));
                Parameters.Add("OTPRAV_STRUCT_PODR"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1three));
                Parameters.Add("OTPRAV_VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1four));
                Parameters.Add("SHIFR_POLUCH"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1five));
                Parameters.Add("SHIFR_POTREB"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1FiveA));
                Parameters.Add("VID_DEYAT"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1Six));
                Parameters.Add("UCH_ED_VIP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1Seven));
                Parameters.Add("PORYAD_NUM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1sevenA));
                Parameters.Add("CHEREZ_KOGO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox2));
                Parameters.Add("ZATREBOVAL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox3));
                Parameters.Add("RAZRESHIL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox4));
                Parameters.Add("OTPUSTIL_DATE"); DataFromTextBox.Add(dateTimePicker1.Value.ToString());
                Parameters.Add("OTPUSTIL_FAM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox245));
                Parameters.Add("POLUCHIL_DATE"); DataFromTextBox.Add(dateTimePicker2.Value.ToString());
                Parameters.Add("POLUCHIL_FAM"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(textBox246));
                Parameters.Add("NOMER_TREBOV_NAKLADNOI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1OneA));
               
                successToLoadData = SQLOracle.UpdateQuery(cmd, Parameters, DataFromTextBox);
                               
                Parameters.Clear();
                DataFromTextBox.Clear();

                if (successToLoadData == true)
                    for (int i = 0; i < 16; i++)
                    {
                        string cmdDATA = "UPDATE KTC.USP_NAKLADNAYA_DATA SET   ";
                            
                        
                        for (int j = 0; j < ((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls.Count; j++)
                        {

                            int TagOfObject = (Convert.ToInt32(((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Tag));

                            if (TagOfObject == 0)
                            {
                                //Корресп. Счет, суб-счет, код аналит. Учета
                                Parameters.Add("KORRESP_SCHET"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));

                                cmdDATA += "KORRESP_SCHET = :KORRESP_SCHET, "; 
                            }
                            else if (TagOfObject == 1)
                            {
                                //Материальные ценности наименование (9)
                                Parameters.Add("MATERR_CENNOSTI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "MATERR_CENNOSTI = :MATERR_CENNOSTI, "; 
                            }
                            else if (TagOfObject == 2)
                            {
                                //код материала
                                Parameters.Add("COD_MATER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "COD_MATER = :COD_MATER, "; 
                            }
                            else if (TagOfObject == 3)
                            {
                                //заводской номер
                                Parameters.Add("ZAVOD_NOMER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "ZAVOD_NOMER = :ZAVOD_NOMER, "; 
                            }
                            else if (TagOfObject == 4)
                            {
                                //Ед. изм. Наимен. Код
                                Parameters.Add("ED_IZM_NAIM_1"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "ED_IZM_NAIM_1 = :ED_IZM_NAIM_1, ";
                            }
                            else if (TagOfObject == 5)
                            {
                                //Ед. изм. Наимен. Код
                                Parameters.Add("ED_IZM_NAIM_2"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "ED_IZM_NAIM_2 = :ED_IZM_NAIM_2, "; 
                            }
                            else if (TagOfObject == 6)
                            {
                                //затребовано
                                Parameters.Add("ZATREBOVANO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "ZATREBOVANO = :ZATREBOVANO, ";
                            }
                            else if (TagOfObject == 7)
                            {
                                //отпущено
                                Parameters.Add("OTPUSHENO"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "OTPUSHENO = :OTPUSHENO, "; 
                            }
                            else if (TagOfObject == 8)
                            {
                                //Цена (руб., коп.)
                                Parameters.Add("CENA"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "CENA = :CENA, "; 
                            }
                            else if (TagOfObject == 9)
                            {
                                //Сумма без расчета НДС, руб. коп.
                                Parameters.Add("SUMMA_BEZ_NDS"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "SUMMA_BEZ_NDS = :SUMMA_BEZ_NDS, "; 
                            }
                            else if (TagOfObject == 10)
                            {
                                //Корреспон. счет, суб-счет, код аналит. учета
                                Parameters.Add("KORRESP_SCHET_2"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "KORRESP_SCHET_2 = :KORRESP_SCHET_2, ";
                            }
                            else if (TagOfObject == 11)
                            {
                                //Обесп. Серийн. № машины
                                Parameters.Add("OBESP_SER_MASH"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "OBESP_SER_MASH = :OBESP_SER_MASH, "; 
                            }
                            else if (TagOfObject == 12)
                            {
                                //Некомп-плектный остаток
                                Parameters.Add("NEKOMPLEKT_OSTATOK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "NEKOMPLEKT_OSTATOK = :NEKOMPLEKT_OSTATOK, ";
                            }
                            else if (TagOfObject == 13)
                            {
                                //Код издел. ШР, БЛ, № с/з
                                Parameters.Add("COD_IZD_SHR_BL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "COD_IZD_SHR_BL = :COD_IZD_SHR_BL, ";
                            }
                            else if (TagOfObject == 14)
                            {
                                //Признак раздела
                                Parameters.Add("PRIZNAK"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "PRIZNAK = :PRIZNAK, "; 
                            }
                            else if (TagOfObject == 15)
                            {
                                //Код основ. Матер.
                                Parameters.Add("COD_OSNOV_MATER"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]));
                                cmdDATA += "COD_OSNOV_MATER = :COD_OSNOV_MATER, "; 
                            }
                        }

                        cmdDATA = cmdDATA.Remove(cmdDATA.Length - 2);

                        string cmdEnd = " WHERE NOMER_TREBOV_NAKLADNOI = :NOMER_TREBOV_NAKLADNOI AND NUMBER_OF_PANEL = :NUMBER_OF_PANEL";


                        Parameters.Add("NOMER_TREBOV_NAKLADNOI"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(PanelN1OneA));
                        Parameters.Add("NUMBER_OF_PANEL"); DataFromTextBox.Add((i + 2).ToString());
                     
                        successToLoadData = SQLOracle.UpdateQuery(cmdDATA + cmdEnd, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();



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

        //отображение данных по ячейкам из БД
        private void viewData(string number)
        {          
                string cmd = "Select "+                    
                        " ORGANIZATION, " +
                        " DATA_SOSTAVLENIYA, " +
                        " COD_VIDA_OPER, " +
                        " OTPRAV_STRUCT_PODR, " +
                        " OTPRAV_VID_DEYAT, " +
                        " SHIFR_POLUCH, " +
                        " SHIFR_POTREB, " +
                        " VID_DEYAT, " +
                        " UCH_ED_VIP, " +
                        " PORYAD_NUM, " +
                        " CHEREZ_KOGO, " +
                        " ZATREBOVAL, " +
                        " RAZRESHIL, " +
                        " OTPUSTIL_DATE, " +
                        " OTPUSTIL_FAM, " +
                        " POLUCHIL_DATE, " +
                        " POLUCHIL_FAM" +
                        " FROM KTC.USP_NAKLADNAYA_HEAD" +
                        " WHERE NOMER_TREBOV_NAKLADNOI = '" + number + "'";

                System.Data.DataSet DataNakladnoy = SQLOracle.getDS(cmd);


                textBox1.Text = DataNakladnoy.Tables[0].Rows[0][0].ToString();
                PanelN1One.Text = DataNakladnoy.Tables[0].Rows[0][1].ToString();
                PanelN1two.Text = DataNakladnoy.Tables[0].Rows[0][2].ToString();
                PanelN1three.Text = DataNakladnoy.Tables[0].Rows[0][3].ToString();
                PanelN1four.Text = DataNakladnoy.Tables[0].Rows[0][4].ToString();
                PanelN1five.Text = DataNakladnoy.Tables[0].Rows[0][5].ToString();
                PanelN1FiveA.Text = DataNakladnoy.Tables[0].Rows[0][6].ToString();
                PanelN1Six.Text = DataNakladnoy.Tables[0].Rows[0][7].ToString();
                PanelN1Seven.Text = DataNakladnoy.Tables[0].Rows[0][8].ToString();
                PanelN1sevenA.Text = DataNakladnoy.Tables[0].Rows[0][9].ToString();
                textBox2.Text = DataNakladnoy.Tables[0].Rows[0][10].ToString();
                textBox3.Text = DataNakladnoy.Tables[0].Rows[0][11].ToString();
                textBox4.Text = DataNakladnoy.Tables[0].Rows[0][12].ToString();
                dateTimePicker1.Text = DataNakladnoy.Tables[0].Rows[0][13].ToString();
                textBox245.Text = DataNakladnoy.Tables[0].Rows[0][14].ToString();
                dateTimePicker2.Text = DataNakladnoy.Tables[0].Rows[0][15].ToString();
                textBox246.Text = DataNakladnoy.Tables[0].Rows[0][16].ToString();

                PanelN1OneA.Text = number;

                DataNakladnoy.Clear();



                for (int i = 0; i < 16; i++)
                {

                    cmd = "SELECT " +
                        " KORRESP_SCHET ," +
                        " MATERR_CENNOSTI ," +
                        " COD_MATER ," +
                        " ZAVOD_NOMER ," +
                        " ED_IZM_NAIM_1 ," +
                        " ED_IZM_NAIM_2 ," +
                        " ZATREBOVANO ," +
                        " OTPUSHENO ," +
                        " CENA ," +
                        " SUMMA_BEZ_NDS ," +
                        " KORRESP_SCHET_2 ," +
                        " OBESP_SER_MASH ," +
                        " NEKOMPLEKT_OSTATOK ," +
                        " COD_IZD_SHR_BL ," +
                        " PRIZNAK ," +
                        " COD_OSNOV_MATER " +
                        " FROM KTC.USP_NAKLADNAYA_DATA " +
                        " WHERE  NOMER_TREBOV_NAKLADNOI = '" + number + "'" +
                        " AND NUMBER_OF_PANEL = '" + (i+2).ToString() + "'";

                    DataNakladnoy = SQLOracle.getDS(cmd);


                    for (int j = 0; j < ((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls.Count; j++)
                    {

                        int TagOfObject = (Convert.ToInt32(((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j].Tag));

                        if (TagOfObject == 0)
                        {
                            //Корресп. Счет, суб-счет, код аналит. Учета
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][0].ToString(); ;

                        }
                        else if (TagOfObject == 1)
                        {
                            //Материальные ценности наименование (9)
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][1].ToString(); ;

                        }
                        else if (TagOfObject == 2)
                        {
                            //код материала
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][2].ToString(); ;

                        }
                        else if (TagOfObject == 3)
                        {
                            //заводской номер
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][3].ToString(); ;

                        }
                        else if (TagOfObject == 4)
                        {
                            //Ед. изм. Наимен. Код
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][4].ToString(); ;

                        }
                        else if (TagOfObject == 5)
                        {
                            //Ед. изм. Наимен. Код
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][5].ToString(); ;

                        }
                        else if (TagOfObject == 6)
                        {
                            //затребовано
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][6].ToString(); ;

                        }
                        else if (TagOfObject == 7)
                        {
                            //отпущено
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][7].ToString(); ;

                        }
                        else if (TagOfObject == 8)
                        {
                            //Цена (руб., коп.)
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][8].ToString(); ;

                        }
                        else if (TagOfObject == 9)
                        {
                            //Сумма без расчета НДС, руб. коп.
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][9].ToString(); ;

                        }
                        else if (TagOfObject == 10)
                        {
                            //Корреспон. счет, суб-счет, код аналит. учета
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][10].ToString(); ;

                        }
                        else if (TagOfObject == 11)
                        {
                            //Обесп. Серийн. № машины
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][11].ToString(); ;

                        }
                        else if (TagOfObject == 12)
                        {
                            //Некомп-плектный остаток
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][12].ToString(); ;

                        }
                        else if (TagOfObject == 13)
                        {
                            //Код издел. ШР, БЛ, № с/з
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][13].ToString(); ;

                        }
                        else if (TagOfObject == 14)
                        {
                            //Признак раздела
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][14].ToString();

                        }
                        else if (TagOfObject == 15)
                        {
                            //Код основ. Матер.
                            ((System.Windows.Forms.TextBox)((System.Windows.Forms.Panel)(this.Controls.Find(("panelN" + (i + 2).ToString()), true)[0])).Controls[j]).Text = DataNakladnoy.Tables[0].Rows[0][15].ToString(); ;

                        }
                    }
                    DataNakladnoy.Clear();


                }
                
        }

        private void LoadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadInformationToDB();
        }

        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateInformationInDB();
        }

        private void PanelN1OneA_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void textBox84_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void PanelN2sixteen_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotMoney(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void PanelN2sixteen_Leave(object sender, EventArgs e)
        {
            PriemSpisanie.blockKeyNotMoneyLeaveEvent((System.Windows.Forms.TextBox)(sender));
        }

        private void tabControl1_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotMoney(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void tabControl1_Leave(object sender, EventArgs e)
        {
            PriemSpisanie.blockKeyNotMoneyLeaveEvent((System.Windows.Forms.TextBox)(sender));
        }

       
       


        

      

        
       

        
              

       
    }
}