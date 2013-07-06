using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UchetUSP.Algorithm;

namespace UchetUSP.WinForms.settings
{
    public partial class setings : Form
    {
        private int HeightForm = 0;
        private int WidthForm = 0;

        public setings()
        {
            InitializeComponent();
            LoadInitInforamation();
        }

        public setings(int widthOut, int heightOut)
        {
            InitializeComponent();
            HeightForm = heightOut;
            WidthForm = widthOut;
       
            InitChangeSizeApp();
        }

       
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush;

            //Get the item from the collection.
            TabPage _TabPage = tabControl1.TabPages[e.Index];

            //Get the real bound for the tab rectangle.
            Rectangle _TabBound = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                //Drow a different background color, and don't paint a focus rectangle.
                _TextBrush = new SolidBrush(Color.White);
                g.FillRectangle(Brushes.Gray, e.Bounds);

            }
            else {

                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            //Use own font
            Font _TabFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            //Draw string. Center the text.
            StringFormat _StringFlags = new StringFormat();
            _StringFlags.Alignment = StringAlignment.Center;
            _StringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBound, new StringFormat(_StringFlags));

        }

       

        void LoadInitInforamation()
        {
            this.Text += " " + SQLOracle.GetCurrentUser();

           
            if (SQLOracle.exist((object)SQLOracle.GetCurrentUser(), "USR", "USP_USER_SETTING"))
            {
                //загрузить данные
                ViewSettingsTabPages();
            }
            else
            {
                
                CheckAllCheckBoxes();
                InsertCurrentData();
            }
        }


        void InitChangeSizeApp()
        {
            this.Text += " " + SQLOracle.GetCurrentUser();

            if (SQLOracle.exist((object)SQLOracle.GetCurrentUser(), "USR", "USP_USER_SETTING"))
            {
              
            }
            else
            {
                CheckAllCheckBoxes();
                InsertCurrentData();
            }
        }


        void CheckAllCheckBoxes()
        {
            for (int i = 0; i < this.tabPage1.Controls.Count; i++)
			{			    
                if (this.tabPage1.Controls[i].Controls.Count > 0)
                {
                    for (int j = 0; j < this.tabPage1.Controls[i].Controls.Count; j++)
                    {
                        if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Checked = true;
                        }
                    }                    
                }   
			}
            for (int i = 0; i < this.tabPage3.Controls.Count; i++)
            {
                if (this.tabPage3.Controls[i].Controls.Count > 0)
                {
                    for (int j = 0; j < this.tabPage3.Controls[i].Controls.Count; j++)
                    {
                        if (this.tabPage3.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Checked = true;
                        }
                    }
                } 
            }
        }

        //используется в случае, если настройки пользователя не существуют (при загрузке настроек создается новая строка)
        void InsertCurrentData()
        {   
            System.Collections.Generic.List<string> parametr = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> value = new System.Collections.Generic.List<string>();
            string InputStringBegin = "INSERT INTO USP_USER_SETTING ( USR,  ";
            string InputStringEnd = "VALUES( :USR,   ";

            parametr.Add("USR");
            value.Add(SQLOracle.GetCurrentUser());
            

               for (int i = 0; i < this.tabPage1.Controls.Count; i++)
			    {			    
                    if (this.tabPage1.Controls[i].Controls.Count > 0)
                    {
                        for (int j = 0; j < this.tabPage1.Controls[i].Controls.Count; j++)
                        {
                            if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                            {
                                InputStringBegin += " " + ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                                InputStringEnd += " :" + ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                                parametr.Add(((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name.ToString());
                                value.Add(DifferentCalsses.StringCalss.ReturnCheckedStatus((CheckBox)this.tabPage1.Controls[i].Controls[j]));
                               
                            } if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(TextBox))
                            {
                                if (String.Compare(PriemSpisanie.IsNullParametr(((TextBox)this.tabPage1.Controls[i].Controls[j])), " ") != 0)
                                { 
                                    InputStringBegin += " " + ((TextBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                                    InputStringEnd += " :" + ((TextBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                                    parametr.Add(((TextBox)this.tabPage1.Controls[i].Controls[j]).Name.ToString());
                                    value.Add(((TextBox)this.tabPage1.Controls[i].Controls[j]).Text.ToString());                                
                                }                                
                            }
                        }                    
                    }   
			    }

                for (int i = 0; i < this.tabPage3.Controls.Count; i++)
                {
                    if (this.tabPage3.Controls[i].Controls.Count > 0)
                    {
                        for (int j = 0; j < this.tabPage3.Controls[i].Controls.Count; j++)
                        {
                            if (this.tabPage3.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                            {
                                InputStringBegin += " " + ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name + ", ";
                                InputStringEnd += " :" + ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name + ", ";
                                parametr.Add(((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name.ToString());
                                value.Add(DifferentCalsses.StringCalss.ReturnCheckedStatus((CheckBox)this.tabPage3.Controls[i].Controls[j]));
                            }
                        }
                    }
                }

                InputStringBegin = DifferentCalsses.StringCalss.CutLastLetter(InputStringBegin);
                InputStringEnd = DifferentCalsses.StringCalss.CutLastLetter(InputStringEnd);
                InputStringBegin += " ) ";
                InputStringEnd += " ) ";

                
                SQLOracle.InsertQuery(InputStringBegin + InputStringEnd, parametr, value);
                           
        }


        private void Save_Click(object sender, EventArgs e)
        {
            UpdateCommonSettings();

            for (int i = 0; i < this.tabPage3.Controls.Count; i++)
            {
                if (this.tabPage3.Controls[i].Controls.Count > 0)
                {
                    for (int j = 0; j < this.tabPage3.Controls[i].Controls.Count; j++)
                    {
                        if (this.tabPage3.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            if (((CheckBox)(this.tabPage3.Controls[i].Controls[j])).Checked == true)
                            { 
                                ((Form1)(this.Owner)).SetModuleEnable(((CheckBox)(this.tabPage3.Controls[i].Controls[j])).Name);

                            }else{

                                ((Form1)(this.Owner)).SetModuleDisable(((CheckBox)(this.tabPage3.Controls[i].Controls[j])).Name);
                            }

                        }
                    }
                }
            }          
        }



        //обновление информации о настройках
        void UpdateCommonSettings()
        {
            System.Collections.Generic.List<string> parametr = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> value = new System.Collections.Generic.List<string>();
            string InputString = "UPDATE USP_USER_SETTING SET USR = :USR,  ";          

            parametr.Add("USR");
            value.Add(SQLOracle.GetCurrentUser());

            for (int i = 0; i < this.tabPage1.Controls.Count; i++)
            {
                if (this.tabPage1.Controls[i].Controls.Count > 0)
                {
                    for (int j = 0; j < this.tabPage1.Controls[i].Controls.Count; j++)
                    {
                        if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            InputString += " " + ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name + " = " + 
                                " :" + ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                         
                            parametr.Add(((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name.ToString());
                            value.Add(DifferentCalsses.StringCalss.ReturnCheckedStatus((CheckBox)this.tabPage1.Controls[i].Controls[j]));

                        } if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(TextBox))
                        {
                            if (String.Compare(PriemSpisanie.IsNullParametr(((TextBox)this.tabPage1.Controls[i].Controls[j])), " ") != 0)
                            {
                                InputString += " " + ((TextBox)this.tabPage1.Controls[i].Controls[j]).Name + " = " + 
                                 " :" + ((TextBox)this.tabPage1.Controls[i].Controls[j]).Name + ", ";
                                parametr.Add(((TextBox)this.tabPage1.Controls[i].Controls[j]).Name.ToString());
                                value.Add(((TextBox)this.tabPage1.Controls[i].Controls[j]).Text.ToString());
                            }
                        }
                    }
                }
            }



            for (int i = 0; i < this.tabPage3.Controls.Count; i++)
            {
                if (this.tabPage3.Controls[i].Controls.Count > 0)
                {
                    for (int j = 0; j < this.tabPage3.Controls[i].Controls.Count; j++)
                    {
                        if (this.tabPage3.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                        {
                            InputString += " " + ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name + " = " +
                                " :" + ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name + ", ";

                            parametr.Add(((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name.ToString());
                            value.Add(DifferentCalsses.StringCalss.ReturnCheckedStatus((CheckBox)this.tabPage3.Controls[i].Controls[j]));

                        } 
                    }
                }
            }

            InputString = DifferentCalsses.StringCalss.CutLastLetter(InputString);

            InputString += " WHERE USR = :USRWHERE";

            parametr.Add("USRWHERE");
            value.Add(SQLOracle.GetCurrentUser());            
         
            SQLOracle.UpdateQuery(InputString, parametr, value);

        }


        void ViewSettingsTabPages()
        { 
            System.Collections.Generic.List<string> parametr = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> value = new System.Collections.Generic.List<string>();

            parametr.Add("USR");
            value.Add(SQLOracle.GetCurrentUser());
           
            System.Data.DataSet DS = SQLOracle.ParamQuerySelectNonPercent("SELECT * FROM USP_USER_SETTING WHERE USR = :USR", parametr, value);
            
            if (DS.Tables.Count > 0)
            {
                for (int i = 0; i < this.tabPage1.Controls.Count; i++)
                {
                    if (this.tabPage1.Controls[i].Controls.Count > 0)
                    {
                        for (int j = 0; j < this.tabPage1.Controls[i].Controls.Count; j++)
                        {
                            if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                            {
                                ((CheckBox)this.tabPage1.Controls[i].Controls[j]).Checked = DifferentCalsses.StringCalss.ReturnCheckedStatus( DS.Tables[0].Rows[0][((CheckBox)this.tabPage1.Controls[i].Controls[j]).Name].ToString());


                            } if (this.tabPage1.Controls[i].Controls[j].GetType() == typeof(TextBox))
                            {

                                ((TextBox)this.tabPage1.Controls[i].Controls[j]).Text = DS.Tables[0].Rows[0][((TextBox)this.tabPage1.Controls[i].Controls[j]).Name].ToString();
                                                                
                            }
                        }
                    }
                }


                for (int i = 0; i < this.tabPage3.Controls.Count; i++)
                {
                    if (this.tabPage3.Controls[i].Controls.Count > 0)
                    {
                        for (int j = 0; j < this.tabPage3.Controls[i].Controls.Count; j++)
                        {
                            if (this.tabPage3.Controls[i].Controls[j].GetType() == typeof(CheckBox))
                            {
                                ((CheckBox)this.tabPage3.Controls[i].Controls[j]).Checked = DifferentCalsses.StringCalss.ReturnCheckedStatus(DS.Tables[0].Rows[0][((CheckBox)this.tabPage3.Controls[i].Controls[j]).Name].ToString());

                            } 
                        }
                    }
                }
                
            }

        }


        public void voidCloseAPP()
        {
            if (SQLOracle.existParamQuery("FORM_SAVE", "USP_USER_SETTING", "FORM_SAVE = '1' AND USR ", "USR", SQLOracle.GetCurrentUser()))
            {
                
                System.Collections.Generic.List<string> parametr = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> value = new System.Collections.Generic.List<string>();

                string InputString = "UPDATE USP_USER_SETTING SET FORM_WIDTH = :FORM_WIDTH, FORM_HEIGHT = :FORM_HEIGHT WHERE USR = : USR  ";
      
                parametr.Add("FORM_WIDTH");
                value.Add(WidthForm.ToString());
                parametr.Add("FORM_HEIGHT");
                value.Add(HeightForm.ToString());
                parametr.Add("USR");
                value.Add(SQLOracle.GetCurrentUser());
                SQLOracle.UpdateQuery(InputString, parametr, value);
                parametr.Clear();
                value.Clear();
            }
        }


    }
}