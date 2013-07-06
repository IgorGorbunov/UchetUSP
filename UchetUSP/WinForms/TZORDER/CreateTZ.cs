using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;
using UchetUSP.DifferentCalsses;
using UchetUSP.Layout;

namespace UchetUSP.WinForms
{
    public partial class CreateTZ : Form
    {
        private System.Collections.Generic.Dictionary<string, string> D = new System.Collections.Generic.Dictionary<string, string>();

        private int BMPIsLoads = 0;

        private int BMPIsLoad
        {
            set
            {
                BMPIsLoads = value;
            }
            get
            {
                return BMPIsLoads;
            }

        }

        private string number;
        private int Utv;
     

        /// <summary>
        /// статус формы ТЗ;
        /// </summary>
        /// <param name="statusOfLoad"> 
        ///0 - Загрузить информацию.
        ///1- Просмотреть информацию
        ///2- Редактировать информацию.</param>
        /// <param name="numberOfTZ"></param>
        /// <returns></returns>  
        public CreateTZ(int statusOfLoad,int UtvStatus,string numberOfTZ)
        {

            InitializeComponent();
            number = numberOfTZ;
            Utv = UtvStatus;
            checkStatus(statusOfLoad);
            //изображения не загружены
            BMPIsLoad = 0;
            
        }

       

        void checkStatus(int Status)
        {
            if(Status == 0)
            {
                this.загрузкToolStripMenuItem.Text = "Обновить информацию"; 
               this.загрузкToolStripMenuItem.Click += new System.EventHandler(this.Load_Click);               
               NUM_TZ.Enabled = false;
               COD_IZD.Enabled = false;
               
               LoadInformation();
               this.Text += " (не оформлено)"; 
           }
           else if (Status == 1)
           { 
               this.загрузкToolStripMenuItem.Text = ""; 
               this.загрузкToolStripMenuItem.Enabled = false;
               LoadInformation();
               viewDataFromDB();               
           
           }else if(Status == 2)
           {
               this.NUM_TZ.Enabled = false;
               this.загрузкToolStripMenuItem.Text = "Обновить информацию";
               this.загрузкToolStripMenuItem.Click += new System.EventHandler(this.Update_Click);
               viewDataFromDB();
               LoadInformation();
           }

        }

        private void LoadInformation()
        {
            if (Utv == 0)
            { 
                 NUM_TZ.Text = SQLOracle.selectStr("SELECT DOC FROM PDM_DOC WHERE ID_DOC = '" + number + "'");
                COD_IZD.Text = SQLOracle.selectStr("SELECT KB FROM PDM_IZD WHERE IZD =  (SELECT IZD FROM PDM_DOC WHERE ID_DOC = '"+number+"')");
                this.Text = "Техническое задание № " + NUM_TZ.Text + " " + SQLOracle.selectStr("SELECT REV FROM PDM_DOC WHERE ID_DOC = '" + number + "'");
            }
            else if (Utv == 1)
            {
                NUM_TZ.Text = SQLOracle.selectStr("SELECT DOC FROM PDM_DOC_YTV WHERE ID_DOC = '" + number + "'");
                COD_IZD.Text = SQLOracle.selectStr("SELECT KB FROM PDM_IZD WHERE IZD =  (SELECT IZD FROM PDM_DOC_YTV WHERE ID_DOC = '" + number + "')");
                this.Text = "Техническое задание № " + NUM_TZ.Text + " " + SQLOracle.selectStr("SELECT REV FROM PDM_DOC_YTV WHERE ID_DOC = '" + number + "'");
            }
            else if (Utv == 2)
            {
                NUM_TZ.Text = SQLOracle.selectStr("SELECT DOC FROM PDM_DOC_ARX WHERE ID_DOC = '" + number + "'");
                COD_IZD.Text = SQLOracle.selectStr("SELECT KB FROM PDM_IZD WHERE IZD =  (SELECT IZD FROM PDM_DOC_ARX WHERE ID_DOC = '" + number + "')");
                this.Text = "Техническое задание № " + NUM_TZ.Text + " " + SQLOracle.selectStr("SELECT REV FROM PDM_DOC_ARX WHERE ID_DOC = '" + number + "'");
            }
           
        }

    
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {              
                this.SCETCH1.ImageLocation = openFileDialog1.FileName;

                this.SCETCH1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

      
        /// <summary>
        /// Проверка информации на наличие подобных ТЗ;
        /// </summary>       
        /// <returns></returns>   
        private string CheckInformation()
        {
            string DisplayErrors = "";
            try
            {
                /*if (SQLOracle.exist("USP_TZ_DATA", (string)("ID_DOC = '" + number + "'")) == true)
                {
                    DisplayErrors += "Подобный номер ТЗ уже занесен\n";
                }*/
               
                if (PriemSpisanie.IsNumber(NUM_TZ.Text.ToString()) == false)
                {
                    DisplayErrors += "Недопустимо пустое поле для номера ТЗ\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(OB_NAIM), " ") == 0)
                {
                    DisplayErrors += "Недопустимо пустое поле для наименования оборудования\n";
                }
                if (String.Compare(PriemSpisanie.IsNullParametr(OB_MODEL)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для модели оборудования\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(OB_SHIR)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для ширины паза\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(OBOZN_DET)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для обозначения детали\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(NAIM_DET)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для наименования детали\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(KOD_CEHA)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для кода цеха потребителя\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(SODER_OPER)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для содержания операции\n";
                }

                if (String.Compare(PriemSpisanie.IsNullParametr(TEH_USL)," ")==0)
                {
                    DisplayErrors += "Недопустимо пустое поле для технических условий\n";
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
            catch (Exception ex)
            {
                return "1";
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


        private void SCETCH_Click(object sender, EventArgs e)
        {

        }

        private void загрузитьТЗToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SCETCH2.ImageLocation = openFileDialog1.FileName;

                this.SCETCH2.SizeMode = PictureBoxSizeMode.CenterImage;

            }
        }

        private void OBOZN_KOMP08_TextChanged(object sender, EventArgs e)
        {

        }

        private void NAIM_KOMP15_TextChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Выгрузка данных в Excel;
        /// </summary>        
        /// <returns></returns> 
        private void экспортВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createXLS();
        }


        /// <summary>
        /// Выгрузка данных в Excel;
        /// </summary>        
        /// <returns></returns> 
        public void createXLS()
        {
            ExcelClass TZExcel = new ExcelClass();

            HashCode.HashCode.CheckFileByHash("техническое задание.xlt");

            if (System.IO.File.Exists(Program.PathString + "\\техническое задание.xlt"))
            {

                try
                {
                    TZExcel.OpenDocument(Program.PathString + "\\техническое задание.xlt");
                    TZExcel.Visible = false;

                    if ((BMPIsLoad == 1) || (BMPIsLoad == 3))
                    {
                        if (this.SCETCH1.Image != null)
                        {
                            using (TemporaryFile tempFile = new TemporaryFile())
                            {
                                this.SCETCH1.Image.Save(tempFile.FilePath.ToString(), System.Drawing.Imaging.ImageFormat.Bmp);

                                TZExcel.SelectCells(this.SCETCH1.Name, Type.Missing);

                                TZExcel.WritePictureToCell(tempFile.FilePath.ToString());

                            }

                        }

                    }
                    else if ((BMPIsLoad == 0) || (BMPIsLoad == 2))
                    {

                        if (this.SCETCH1.Image != null)
                        {
                            TZExcel.SelectCells(this.SCETCH1.Name, Type.Missing);

                            TZExcel.WritePictureToCell(SQLOracle.LoadImageToTemp("Select SCETCH1 FROM USP_TZ_DATA WHERE ID_DOC = '" + number + "'"));

                        }
                    }


                    if ((BMPIsLoad == 2) || (BMPIsLoad == 3))
                    {
                        if (this.SCETCH2.Image != null)
                        {
                            using (TemporaryFile tempFile = new TemporaryFile())
                            {
                                this.SCETCH2.Image.Save(tempFile.FilePath.ToString(), System.Drawing.Imaging.ImageFormat.Bmp);

                                TZExcel.SelectCells(this.SCETCH2.Name, Type.Missing);

                                TZExcel.WritePictureToCell(tempFile.FilePath.ToString());

                            }

                        }

                    }
                    else if ((BMPIsLoad == 0) || (BMPIsLoad == 1))
                    {

                        if (this.SCETCH2.Image != null)
                        {
                            TZExcel.SelectCells(this.SCETCH2.Name, Type.Missing);

                            TZExcel.WritePictureToCell(SQLOracle.LoadImageToTemp("Select SCETCH2 FROM USP_TZ_DATA WHERE ID_DOC = '" + number + "'"));

                        }
                    }



                    for (int i = 0; i < this.tabPage1.Controls.Count; i++)
                    {

                        if (this.tabPage1.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage1.Controls[i].GetType() == typeof(DateTimePicker)) || (this.tabPage1.Controls[i].GetType() == typeof(TextBox)) || (this.tabPage1.Controls[i].GetType() == typeof(ComboBox)))
                            {
                                TZExcel.SelectCells(this.tabPage1.Controls[i].Name, Type.Missing);
                                TZExcel.WriteDataToCell(this.tabPage1.Controls[i].Text.ToString());
                            }

                        }
                        else if (this.tabPage1.Controls[i].Controls.Count > 0)
                        {
                            ExcelExport(this.tabPage1.Controls[i], ref TZExcel);
                        }
                    }


                    for (int i = 0; i < this.tabPage2.Controls.Count; i++)
                    {
                        if (this.tabPage2.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage2.Controls[i].GetType() == typeof(DateTimePicker)) || (this.tabPage2.Controls[i].GetType() == typeof(TextBox)) || (this.tabPage2.Controls[i].GetType() == typeof(ComboBox)))
                            {
                                TZExcel.SelectCells(this.tabPage2.Controls[i].Name, Type.Missing);
                                TZExcel.WriteDataToCell(this.tabPage2.Controls[i].Text.ToString());
                            }

                        }
                        else if (this.tabPage2.Controls[i].Controls.Count > 0)
                        {
                            ExcelExport(this.tabPage2.Controls[i], ref TZExcel);
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");

                }
                finally
                {
                    TZExcel.Visible = true;
                    TZExcel.Dispose();
                }
            }
        }



        private void ExcelExport(System.Windows.Forms.Control control,ref ExcelClass TZExcel)
        {
           
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i].Controls.Count == 0)
                {

                    if ((control.Controls[i].GetType() == typeof(DateTimePicker)) || (control.Controls[i].GetType() == typeof(TextBox)) || (control.Controls[i].GetType() == typeof(ComboBox)))
                    {                        
                        TZExcel.SelectCells(control.Controls[i].Name, Type.Missing);
                        TZExcel.WriteDataToCell(control.Controls[i].Text.ToString());
                    }

                }
                else if (control.Controls[i].Controls.Count > 0)
                {
                    ExcelExport(control.Controls[i],ref TZExcel);
                }

            }
        }


        //загрузка в БД
        private void LoadTzToDB()
        {

            if (SQLOracle.exist("USP_TZ_DATA", (string)("ID_DOC = '" + number + "'"))==false)
            {
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new List<string>();
                System.Collections.Generic.List<string> DataFromTextBox = new List<string>();

                string cmdName = "INSERT INTO USP_TZ_DATA ( ";
                string cmdValue = "VALUES ( ";


                try
                {
                    for (int i = 0; i < this.tabPage1.Controls.Count; i++)
                    {
                        if (this.tabPage1.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage1.Controls[i].GetType() == typeof(ComboBox)))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + ",";
                                cmdValue += " :" + this.tabPage1.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)this.tabPage1.Controls[i]));

                            }
                            else if ((this.tabPage1.Controls[i].GetType() == typeof(TextBox)))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + ",";
                                cmdValue += " :" + this.tabPage1.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)this.tabPage1.Controls[i]));

                            }
                            else if (this.tabPage1.Controls[i].GetType() == typeof(DateTimePicker))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + ",";
                                cmdValue += " to_date(:" + this.tabPage1.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(((DateTimePicker)(this.tabPage1.Controls[i])).Value.ToString());
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (this.tabPage1.Controls[i].Controls.Count > 0)
                        {
                            LoadDBCycle(this.tabPage1.Controls[i], ref cmdName, ref  cmdValue, ref  Parameters, ref  DataFromTextBox);
                        }
                    }


                    for (int i = 0; i < this.tabPage2.Controls.Count; i++)
                    {
                        if (this.tabPage2.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage2.Controls[i].GetType() == typeof(ComboBox)))
                            {
                                cmdName += " " + this.tabPage2.Controls[i].Name + ",";
                                cmdValue += " :" + this.tabPage2.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)this.tabPage2.Controls[i]));
                            }
                            else if ((this.tabPage2.Controls[i].GetType() == typeof(TextBox)))
                            {
                                cmdName += " " + this.tabPage2.Controls[i].Name + ",";
                                cmdValue += " :" + this.tabPage2.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)this.tabPage2.Controls[i]));
                                
                            }
                            else if (this.tabPage2.Controls[i].GetType() == typeof(DateTimePicker))
                            {
                                cmdName += " " + this.tabPage2.Controls[i].Name + ",";
                                cmdValue += " to_date(:" + this.tabPage2.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(((DateTimePicker)(this.tabPage2.Controls[i])).Value.ToString());
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if ((this.tabPage2.Controls[i].Controls.Count > 0) && ((String.Compare(this.tabPage2.Controls[i].Name, "panel45")) != 0))
                        {
                            LoadDBCycle(this.tabPage2.Controls[i], ref cmdName, ref  cmdValue, ref  Parameters, ref  DataFromTextBox);
                        }
                    }
                    cmdName += " ID_DOC,";
                    cmdValue += " :ID_DOC,";
                    Parameters.Add("ID_DOC");
                    DataFromTextBox.Add(number);

                    

                    cmdName = cmdName.Remove(cmdName.Length - 1);
                    cmdValue = cmdValue.Remove(cmdValue.Length - 1);

                    cmdName += ") " + cmdValue + ")";

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");

                }

                successToLoadData = SQLOracle.InsertQuery(cmdName, Parameters, DataFromTextBox);

                Parameters.Clear();
                DataFromTextBox.Clear();


                for (int i = 1; i < 10; i++) 
                {     
                    if(successToLoadData == true)
                    {
                        cmdName = "INSERT INTO USP_TZ_DATA_TP (ID_DOC, NAIM_KOMP,OBOZN_KOMP, KOL, NUM_PANEL) VALUES(:ID_DOC, :NAIM_KOMP,:OBOZN_KOMP, :KOL, :NUM_PANEL)";
                        Parameters.Add("ID_DOC"); DataFromTextBox.Add(number);
                        Parameters.Add("NAIM_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP0" + i.ToString()), true)[0]))));
                        Parameters.Add("OBOZN_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP0" + i.ToString()), true)[0]))));
                        Parameters.Add("KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel34.Controls.Find(("KOL0" + i.ToString()), true)[0]))));
                        Parameters.Add("NUM_PANEL"); DataFromTextBox.Add(i.ToString());

                        successToLoadData = SQLOracle.InsertQuery(cmdName, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();
                    }
                }

                for (int i = 10; i < 21; i++)
                {
                    if (successToLoadData == true)
                    {
                        cmdName = "INSERT INTO USP_TZ_DATA_TP (ID_DOC, NAIM_KOMP,OBOZN_KOMP, KOL, NUM_PANEL) VALUES(:ID_DOC, :NAIM_KOMP,:OBOZN_KOMP, :KOL, :NUM_PANEL)";
                        Parameters.Add("ID_DOC"); DataFromTextBox.Add(number);
                        Parameters.Add("NAIM_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP" + i.ToString()), true)[0]))));
                        Parameters.Add("OBOZN_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP" + i.ToString()), true)[0]))));
                        Parameters.Add("KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel34.Controls.Find(("KOL" + i.ToString()), true)[0]))));
                        Parameters.Add("NUM_PANEL"); DataFromTextBox.Add(i.ToString());

                        successToLoadData = SQLOracle.InsertQuery(cmdName, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();
                    }
                }

                
                    if ((this.SCETCH1.Image != null) && (successToLoadData == true))
                        using (TemporaryFile tempFile = new TemporaryFile())
                        {
                           
                            this.SCETCH1.Image.Save(tempFile.FilePath.ToString());
                         

                            System.IO.FileStream FileStreamSCETCH1 = new System.IO.FileStream(tempFile.FilePath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] SCETCH1InByte = new Byte[FileStreamSCETCH1.Length];                           
                            FileStreamSCETCH1.Read(SCETCH1InByte, 0, SCETCH1InByte.Length);
                            FileStreamSCETCH1.Close();
                            IDisposable disp = (IDisposable)FileStreamSCETCH1;
                            disp.Dispose();

                            successToLoadData = SQLOracle.BLOBUpdateQuery(("UPDATE USP_TZ_DATA SET SCETCH1 = :SCETCH1 WHERE ID_DOC = '" + number + "'"), "SCETCH1", SCETCH1InByte);
                            FileStreamSCETCH1.Dispose();                            

                        }

                    if ((this.SCETCH2.Image != null) && (successToLoadData == true))
                        using (TemporaryFile tempFile = new TemporaryFile())
                        {
                            
                            this.SCETCH2.Image.Save(tempFile.FilePath.ToString());

                            System.IO.FileStream FileStreamBMP = new System.IO.FileStream(tempFile.FilePath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] BMPInByte = new Byte[FileStreamBMP.Length];                          
                            FileStreamBMP.Read(BMPInByte, 0, BMPInByte.Length);
                            FileStreamBMP.Close();
                            IDisposable disp = (IDisposable)FileStreamBMP;
                            disp.Dispose();

                            successToLoadData = SQLOracle.BLOBUpdateQuery(("UPDATE USP_TZ_DATA SET SCETCH2 = :SCETCH2 WHERE ID_DOC = '" + number + "'"), "SCETCH2", BMPInByte);
                            FileStreamBMP.Dispose();
                        }
              
                if (successToLoadData == true)
                {
                    MessageBox.Show("Загрузка прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Загрузка прошла неудачно!");
                }


            }
            else { UpdateTzToDB(); }
            
        }


        private void LoadDBCycle( System.Windows.Forms.Control control, ref string cmdName, ref string cmdValue, ref System.Collections.Generic.List<string> Parameters, ref  System.Collections.Generic.List<string> DataFromTextBox)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i].Controls.Count == 0)
                {

                    if ((control.Controls[i].GetType() == typeof(ComboBox)))
                    {
                        cmdName += " " + control.Controls[i].Name + ",";
                        cmdValue += " :" + control.Controls[i].Name + ",";
                        Parameters.Add(control.Controls[i].Name);
                        DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)(control.Controls[i])));
                    }
                    else if ((control.Controls[i].GetType() == typeof(TextBox)))
                    {
                        cmdName += " " + control.Controls[i].Name + ",";
                        cmdValue += " :" + control.Controls[i].Name + ",";
                        Parameters.Add(control.Controls[i].Name);
                        DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)(control.Controls[i])));
                    
                    }
                    else if (control.Controls[i].GetType() == typeof(DateTimePicker))
                        {
                            cmdName += " " + control.Controls[i].Name + ",";
                            cmdValue += " to_date(:" + control.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                            Parameters.Add(control.Controls[i].Name);
                            DataFromTextBox.Add(((DateTimePicker)(control.Controls[i])).Value.ToString());
                        }
                        else
                        {
                            continue;
                        }
                    
                }
                else if ((control.Controls[i].Controls.Count > 0) && ((String.Compare(control.Controls[i].Name, "panel45")) != 0))
                {
                    LoadDBCycle(control.Controls[i], ref cmdName,ref cmdValue, ref Parameters,ref DataFromTextBox);
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SCETCH1.ImageLocation = openFileDialog1.FileName;

                this.SCETCH1.SizeMode = PictureBoxSizeMode.CenterImage;

                //если изображения не загружены, то 1, иначе 3 (оба загружены)
                if (BMPIsLoad == 0)
                { 
                    BMPIsLoad = 1;

                }else if(BMPIsLoad == 2)
                {
                    BMPIsLoad = 3;
                }
                

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SCETCH2.ImageLocation = openFileDialog1.FileName;

                this.SCETCH2.SizeMode = PictureBoxSizeMode.CenterImage;

                //если изображения не загружены, то 2, иначе 3 (оба загружены)
                if (BMPIsLoad == 0)
                {
                    BMPIsLoad = 2;

                }
                else if (BMPIsLoad == 1)
                {
                    BMPIsLoad = 3;
                }
            }
        }

        private void Load_Click(object sender, EventArgs e)
        {
            LoadTzToDB();
        }

        private void Update_Click(object sender, EventArgs e)
        {

            if (string.Compare(CheckInformation(), "0") == 0)
            {
                UpdateTzToDB();
            }
            else
            {
                MessageBox.Show(CheckInformation(), "Ошибка!");
            }
            
        }
       
        
        private void viewDataFromDB()
        {
            //получение общих данных в цикле
            /////////////////////////////////////////////////////////////////////
            System.Data.DataSet GetData = SQLOracle.getDS("SELECT "+
            "OB_NAIM, "+
            "OB_MODEL, "+
            "OB_SHIR, "+
            "OBOZN_DET, "+
            "NAIM_DET, "+
            "KOD_CEHA, "+
            "SODER_OPER, "+
            "TEH_USL, "+
            "RAZ_DOLZN, "+
            "RAZ_FIO, "+
            "RAZ_PODP, "+
            "RAZ_DATE, "+
            "PROV_DOLZN, "+
            "PROV_FIO, "+
            "PROV_PODP, "+
            "PROV_DATE, "+
            "UTV_DOLZN, "+
            "UTV_FIO, "+
            "UTV_PODP, "+
            "DATE_UTV, "+
            "OBOZN_UPTO, "+
            "KOD_NAKL, "+
            "TP_NOMER_TP,"+ 
            "TP_TO, "+
            "TP_NAIMTO, "+ 
            "TP_NOM_PEREH, "+ 
            "NAIM_PRISP, "+
            "DATA_ISP, "+
            "GOD_POR_NOMER, "+
            "HP_KOL_EDEN, "+
            "HP_KOL_SD, "+
            "HP_KOL_SHPON, "+
            "HP_KOL_PRIH, "+
            "HP_GRP_SLZ, "+
            "KOD_PODR, "+
            "NUM_TEL "+
            "FROM USP_TZ_DATA WHERE ID_DOC = '"+ number +"'");
            
           
           
            for (int col = 0; col < GetData.Tables[0].Columns.Count; col++)
            {              
                
                for (int i = 0; i < this.tabPage1.Controls.Count; i++)
                {
                    if (this.tabPage1.Controls[i].Controls.Count == 0)
                    {
                        if ((this.tabPage1.Controls[i].GetType() == typeof(ComboBox)))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage1.Controls[i].Name) == 0)
                            {
                                
                                this.tabPage1.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();
                                
                            }
                        }
                        else if ((this.tabPage1.Controls[i].GetType() == typeof(TextBox)))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage1.Controls[i].Name) == 0)
                            {
                               
                                this.tabPage1.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();
                                
                            }
                        }
                        else if (this.tabPage1.Controls[i].GetType() == typeof(DateTimePicker))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage1.Controls[i].Name) == 0)
                            {
                               
                                this.tabPage1.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();                                
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (this.tabPage1.Controls[i].Controls.Count > 0)
                    {
                        ViewDBCycle(this.tabPage1.Controls[i], ref GetData, ref col);
                    }
                }

                for (int i = 0; i < this.tabPage2.Controls.Count; i++)
                {
                    if (this.tabPage2.Controls[i].Controls.Count == 0)
                    {
                        if ((this.tabPage2.Controls[i].GetType() == typeof(ComboBox)))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage2.Controls[i].Name) == 0)
                            {

                                this.tabPage2.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();

                            }
                        }
                        else if ((this.tabPage2.Controls[i].GetType() == typeof(TextBox)))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage2.Controls[i].Name) == 0)
                            {
                                this.tabPage2.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();

                            }
                        }
                        else if (this.tabPage2.Controls[i].GetType() == typeof(DateTimePicker))
                        {
                            if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, this.tabPage2.Controls[i].Name) == 0)
                            {

                                this.tabPage2.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (this.tabPage2.Controls[i].Controls.Count > 0)
                    {
                        ViewDBCycle(this.tabPage2.Controls[i], ref GetData, ref col);
                    }
                }                
            }
            //выгрузка картинок
            /////////////////////////////////////////////////////////////////////

            this.SCETCH1.Image = SQLOracle.getBlobImage("Select SCETCH1 FROM USP_TZ_DATA WHERE ID_DOC = '" + number + "'");

            this.SCETCH2.Image = SQLOracle.getBlobImage("Select SCETCH2 FROM USP_TZ_DATA WHERE ID_DOC = '" + number + "'");


            //заолнение данных таблицы второго листа
            /////////////////////////////////////////////////////////////////////
            GetData = SQLOracle.getDS("SELECT * FROM USP_TZ_DATA_TP WHERE ID_DOC = '" + number + "'");

            for (int i = 1; i < 21; i++)
            {
                if (Convert.ToInt32(GetData.Tables[0].Rows[i - 1][4]) < 10)
                {
                    ((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP0" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][2].ToString();
                    ((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP0" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][1].ToString();
                    ((TextBox)(this.panel34.Controls.Find(("KOL0" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][3].ToString();
                }
                else if (Convert.ToInt32(GetData.Tables[0].Rows[i - 1][4]) >= 10)
                {
                    ((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][2].ToString();
                    ((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][1].ToString();
                    ((TextBox)(this.panel34.Controls.Find(("KOL" + GetData.Tables[0].Rows[i - 1][4].ToString()), true)[0])).Text = GetData.Tables[0].Rows[i - 1][3].ToString();
                }
            }

            //заолнение данных о пользователях (подписчиках)
            /////////////////////////////////////////////////////////////////////

            System.Data.DataSet GetUserData = null;

            if (Utv == 0)
            { 
                GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP  WHERE ID_DOC = '" + number + "' AND WNM = 'Исполнитель') ");

            }
            else if ((Utv == 1) || (Utv == 2))
            {
                GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = '" + number + "' AND WNM = 'Исполнитель') ");
            }
          
            
            if ((GetUserData.Tables.Count != 0))
           {
               if (GetUserData.Tables[0].Rows.Count != 0)
               {
                   RAZ_PODP.Text = "Подписано";
                   RAZ_DOLZN.Text = GetUserData.Tables[0].Rows[0]["DOLJN"].ToString();
                   RAZ_FIO.Text = GetUserData.Tables[0].Rows[0]["FAM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["IM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["OTCH"].ToString();
                   NUM_TEL.Text = GetUserData.Tables[0].Rows[0]["TLF"].ToString();
                   KOD_PODR.Text = GetUserData.Tables[0].Rows[0]["PODR"].ToString();
                   
                   if (Utv == 0)
                   {
                       RAZ_DATE.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP  WHERE ID_DOC = " + number + " AND WNM = 'Исполнитель'");
                   }
                   else if ((Utv == 1) || (Utv == 2))
                   {
                       RAZ_DATE.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = " + number + " AND WNM = 'Исполнитель'");
                   }
          
               }               
           }

           GetUserData.Dispose();

           if (Utv == 0)
           {
               GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP  WHERE ID_DOC = '" + number + "' AND WNM = 'Проверил') ");

           }
           else if ((Utv == 1) || (Utv == 2))
           {
               GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = '" + number + "' AND WNM = 'Проверил') ");
           }



           if ((GetUserData.Tables.Count != 0))
           {
               if (GetUserData.Tables[0].Rows.Count != 0)
               {
                   PROV_PODP.Text = "Подписано";
                   PROV_DOLZN.Text = GetUserData.Tables[0].Rows[0]["DOLJN"].ToString();
                   PROV_FIO.Text = GetUserData.Tables[0].Rows[0]["FAM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["IM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["OTCH"].ToString();

                   if (Utv == 0)
                   {
                       PROV_DATE.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP  WHERE ID_DOC = " + number + " AND WNM = 'Проверил'");
                   }
                   else if ((Utv == 1) || (Utv == 2))
                   {
                       PROV_DATE.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = " + number + " AND WNM = 'Проверил'");
                   }
               }
           }

           GetUserData.Dispose();
           if (Utv == 0)
           {
               GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP  WHERE ID_DOC = '" + number + "' AND WNM = 'Утвердил') ");

           }
           else if ((Utv == 1) || (Utv == 2))
           {
               GetUserData = SQLOracle.getDS("SELECT DOLJN, PODR, FAM, IM, OTCH, TLF from PDM_USR WHERE USR =  (SELECT USR FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = '" + number + "' AND WNM = 'Утвердил') ");
           }


           if ((GetUserData.Tables.Count != 0))
           {
               if (GetUserData.Tables[0].Rows.Count != 0)
               {
                   UTV_PODP.Text = "Подписано";
                   UTV_DOLZN.Text = GetUserData.Tables[0].Rows[0]["DOLJN"].ToString();
                   UTV_FIO.Text = GetUserData.Tables[0].Rows[0]["FAM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["IM"].ToString() + " " +
                       GetUserData.Tables[0].Rows[0]["OTCH"].ToString();
                  
                   if (Utv == 0)
                   {
                       DATE_UTV.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP  WHERE ID_DOC = " + number + " AND WNM = 'Утвердил'");
                   }
                   else if ((Utv == 1) || (Utv == 2))
                   {
                       DATE_UTV.Value = SQLOracle.selectDate("SELECT DT FROM PDM_DOC_PODP_ARX  WHERE ID_DOC = " + number + " AND WNM = 'Утвердил'");
                   }
               }
           }

           GetUserData.Dispose();
           /////////////////////////////////////////////////////////////////////


           }



        private void ViewDBCycle(System.Windows.Forms.Control control, ref DataSet GetData, ref int col)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i].Controls.Count == 0)
                {

                    if ((control.Controls[i].GetType() == typeof(ComboBox)))
                    {
                        if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, control.Controls[i].Name) == 0)
                        {                            
                            control.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();                            
                        }
                    }
                    else if ((control.Controls[i].GetType() == typeof(TextBox)))
                    {
                        if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, control.Controls[i].Name) == 0)
                        {
                            
                            control.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();                            
                        }

                    }
                    else if (control.Controls[i].GetType() == typeof(DateTimePicker))
                    {
                        if (String.Compare(GetData.Tables[0].Columns[col].ColumnName, control.Controls[i].Name) == 0)
                        {
                            
                            control.Controls[i].Text = GetData.Tables[0].Rows[0][col].ToString();
                           
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
                else if ((control.Controls[i].Controls.Count > 0) && ((String.Compare(control.Controls[i].Name, "panel45")) != 0))
                {
                    ViewDBCycle(control.Controls[i], ref GetData, ref col);
                }

            }
        }

        private void UpdateTzToDB()
        {

           
                bool successToLoadData = false;

                System.Collections.Generic.List<string> Parameters = new List<string>();
                System.Collections.Generic.List<string> DataFromTextBox = new List<string>();

                string cmdName = "UPDATE USP_TZ_DATA SET ";
                
            

                try
                {
                    for (int i = 0; i < this.tabPage1.Controls.Count; i++)
                    {
                        if (this.tabPage1.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage1.Controls[i].GetType() == typeof(ComboBox)))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + " = :" + this.tabPage1.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)this.tabPage1.Controls[i]));

                            }
                            else if ((this.tabPage1.Controls[i].GetType() == typeof(TextBox)))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + " = :" + this.tabPage1.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)this.tabPage1.Controls[i]));

                            }
                            else if (this.tabPage1.Controls[i].GetType() == typeof(DateTimePicker))
                            {
                                cmdName += " " + this.tabPage1.Controls[i].Name + " = to_date(:" + this.tabPage1.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                                Parameters.Add(this.tabPage1.Controls[i].Name);
                                DataFromTextBox.Add(((DateTimePicker)(this.tabPage1.Controls[i])).Value.ToString());
                            }
                            else
                            {
                                continue;
                            }


                        }
                        else if (this.tabPage1.Controls[i].Controls.Count > 0)
                        {
                            UpdateDBCycle(this.tabPage1.Controls[i], ref cmdName, ref  Parameters, ref  DataFromTextBox);
                        }
                    }


                    for (int i = 0; i < this.tabPage2.Controls.Count; i++)
                    {
                        if (this.tabPage2.Controls[i].Controls.Count == 0)
                        {

                            if ((this.tabPage2.Controls[i].GetType() == typeof(ComboBox)))
                            {

                                cmdName += " " + this.tabPage2.Controls[i].Name + " = :" + this.tabPage2.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)this.tabPage2.Controls[i]));
                            }
                            else if ((this.tabPage2.Controls[i].GetType() == typeof(TextBox)))
                            {
                                cmdName += " " + this.tabPage2.Controls[i].Name + " = :" + this.tabPage2.Controls[i].Name + ",";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)this.tabPage2.Controls[i]));


                            }
                            else if (this.tabPage2.Controls[i].GetType() == typeof(DateTimePicker))
                            {
                                cmdName += " " + this.tabPage2.Controls[i].Name + " = to_date(:" + this.tabPage2.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                                Parameters.Add(this.tabPage2.Controls[i].Name);
                                DataFromTextBox.Add(((DateTimePicker)(this.tabPage2.Controls[i])).Value.ToString());
                            }
                            else
                            {
                                continue;
                            }


                        }
                        else if ((this.tabPage2.Controls[i].Controls.Count > 0) && ((String.Compare(this.tabPage2.Controls[i].Name, "panel45")) != 0))
                        {
                            UpdateDBCycle(this.tabPage2.Controls[i], ref cmdName, ref  Parameters, ref  DataFromTextBox);
                        }
                    }
                    cmdName = cmdName.Remove(cmdName.Length - 1);

                    cmdName += " WHERE ID_DOC = '" + number + "'";
                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");

                }

                successToLoadData = SQLOracle.UpdateQuery(cmdName, Parameters, DataFromTextBox);

                Parameters.Clear();
                DataFromTextBox.Clear();


                for (int i = 1; i < 10; i++)
                {
                    if (successToLoadData == true)
                    {
                        cmdName = "UPDATE USP_TZ_DATA_TP SET NAIM_KOMP = :NAIM_KOMP,OBOZN_KOMP = :OBOZN_KOMP, KOL = :KOL WHERE NUM_PANEL = '" + i.ToString() + "' AND ID_DOC = '" + number +"'";
                     
                        Parameters.Add("NAIM_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP0" + i.ToString()), true)[0]))));
                        Parameters.Add("OBOZN_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP0" + i.ToString()), true)[0]))));
                        Parameters.Add("KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel34.Controls.Find(("KOL0" + i.ToString()), true)[0]))));
         
                        successToLoadData = SQLOracle.UpdateQuery(cmdName, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();
                    }
                }

                for (int i = 10; i < 21; i++)
                {
                    if (successToLoadData == true)
                    {
                        cmdName = "UPDATE USP_TZ_DATA_TP SET NAIM_KOMP = :NAIM_KOMP,OBOZN_KOMP = :OBOZN_KOMP, KOL = :KOL WHERE NUM_PANEL = '" + i.ToString() + "' AND ID_DOC = '" + number + "'";
                     
                        Parameters.Add("NAIM_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel33.Controls.Find(("NAIM_KOMP" + i.ToString()), true)[0]))));
                        Parameters.Add("OBOZN_KOMP"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel32.Controls.Find(("OBOZN_KOMP" + i.ToString()), true)[0]))));
                        Parameters.Add("KOL"); DataFromTextBox.Add(PriemSpisanie.IsNullParametr(((TextBox)(this.panel34.Controls.Find(("KOL" + i.ToString()), true)[0]))));
          
                        successToLoadData = SQLOracle.UpdateQuery(cmdName, Parameters, DataFromTextBox);

                        Parameters.Clear();
                        DataFromTextBox.Clear();
                    }
                }

                if ((BMPIsLoad == 1)||(BMPIsLoad == 3))
                    if ((this.SCETCH1.Image != null) && (successToLoadData == true))
                        using (TemporaryFile tempFile = new TemporaryFile())
                        {


                            this.SCETCH1.Image.Save(tempFile.FilePath.ToString());


                            System.IO.FileStream FileStreamSCETCH1 = new System.IO.FileStream(tempFile.FilePath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] SCETCH1InByte = new Byte[FileStreamSCETCH1.Length];
                            FileStreamSCETCH1.Read(SCETCH1InByte, 0, SCETCH1InByte.Length);
                            FileStreamSCETCH1.Close();
                            IDisposable disp = (IDisposable)FileStreamSCETCH1;
                            disp.Dispose();

                            successToLoadData = SQLOracle.BLOBUpdateQuery(("UPDATE USP_TZ_DATA SET SCETCH1 = :SCETCH1 WHERE ID_DOC = '" + number + "'"), "SCETCH1", SCETCH1InByte);
                            FileStreamSCETCH1.Dispose();

                        }
                if ((BMPIsLoad == 2) || (BMPIsLoad == 3))
                    if ((this.SCETCH2.Image != null) && (successToLoadData == true))
                        using (TemporaryFile tempFile = new TemporaryFile())
                        {
                            this.SCETCH2.Image.Save(tempFile.FilePath.ToString());

                           
                            System.IO.FileStream FileStreamBMP = new System.IO.FileStream(tempFile.FilePath.ToString(), System.IO.FileMode.Open, System.IO.FileAccess.Read);
                            byte[] BMPInByte = new Byte[FileStreamBMP.Length];
                            FileStreamBMP.Read(BMPInByte, 0, BMPInByte.Length);
                            FileStreamBMP.Close();
                            IDisposable disp = (IDisposable)FileStreamBMP;
                            disp.Dispose();

                            successToLoadData = SQLOracle.BLOBUpdateQuery(("UPDATE USP_TZ_DATA SET SCETCH2 = :SCETCH2 WHERE ID_DOC = '" + number + "'"), "SCETCH2", BMPInByte);
                            FileStreamBMP.Dispose();
                        }





                if (successToLoadData == true)
                {
                    MessageBox.Show("Загрузка прошла успешно!");
                }
                else
                {
                    MessageBox.Show("Загрузка прошла неудачно!");
                }
                      

        }


        private void UpdateDBCycle(System.Windows.Forms.Control control, ref string cmdName, ref System.Collections.Generic.List<string> Parameters, ref  System.Collections.Generic.List<string> DataFromTextBox)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i].Controls.Count == 0)
                {

                    if ((control.Controls[i].GetType() == typeof(ComboBox)))
                    {
                        cmdName += " " + control.Controls[i].Name + " = :" + control.Controls[i].Name + ",";
                        Parameters.Add(control.Controls[i].Name);
                        DataFromTextBox.Add(PriemSpisanie.IsNullParametr((ComboBox)(control.Controls[i])));
                    }
                    else if ((control.Controls[i].GetType() == typeof(TextBox)))
                    {
                        cmdName += " " + control.Controls[i].Name + " = :" + control.Controls[i].Name + ",";
                        Parameters.Add(control.Controls[i].Name);
                        DataFromTextBox.Add(PriemSpisanie.IsNullParametr((TextBox)(control.Controls[i])));

                    }
                    else if (control.Controls[i].GetType() == typeof(DateTimePicker))
                    {
                        cmdName += " " + control.Controls[i].Name + " = to_date(:" + control.Controls[i].Name + ",'DD.MM.YYYY hh24:mi:ss'),";
                        Parameters.Add(control.Controls[i].Name);
                        DataFromTextBox.Add(((DateTimePicker)(control.Controls[i])).Value.ToString());
                    }
                    else
                    {
                        continue;
                    }

                }
                else if ((control.Controls[i].Controls.Count > 0) && ((String.Compare(control.Controls[i].Name, "panel45")) != 0))
                {
                    UpdateDBCycle(control.Controls[i], ref cmdName, ref Parameters, ref DataFromTextBox);
                }

            }
        }

       

        private void TP_NOMER_TP_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.TextBox)(sender));
        }

        private void NUM_TZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            PriemSpisanie.blockKeyNotNumber(e, (System.Windows.Forms.ComboBox)(sender));
        }

       
       

       
     

       
    }
}