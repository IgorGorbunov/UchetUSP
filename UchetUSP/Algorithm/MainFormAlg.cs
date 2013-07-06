using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace UchetUSP
{
    public partial class Form1 : Form
    {
        void FindDataGrid(ref DataGridView dg, Control contr)
        {

            for (int i = 0; i < contr.Controls.Count; i++)
            {

                if (contr.Controls[i].Controls.Count > 0)
                {
                    if (contr.Controls[i].GetType() == typeof(DataGridView))
                    {
                       
                        dg = (DataGridView)contr.Controls[i];
                        return;
                    }
                    else
                    {

                        FindDataGrid(ref dg, contr.Controls[i]);
                    }

                }
                else
                {
                    if (contr.Controls[i].GetType() == typeof(DataGridView))
                    {
                        
                        dg = (DataGridView)contr.Controls[i];
                        return;
                    }
                }
            }



            return;
        }

        void ExportDGVToExcel(DataGridView dgv)
        {
            ExcelClass InformationAboutElements = new ExcelClass();

            Font HeadFont = new Font(" Times New Roman ", 12.0f, FontStyle.Bold);
            Font otherFont = new Font(" Times New Roman ", 12.0f, FontStyle.Regular);
                    

            int iterator = 0;

            try
            {
                char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                int CurrentCell = 0;
                InformationAboutElements.NewDocument();
                InformationAboutElements.AddNewPageAtTheStart("Данные");

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].Visible == true)
                    {
                        
                        InformationAboutElements.SelectCells(alpha[iterator] + (1).ToString(), Type.Missing);                    
                        InformationAboutElements.SetFont(HeadFont, 0);
                        InformationAboutElements.SetBorderStyle(0, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);

                        InformationAboutElements.WriteDataToCell(dgv.Columns[i].HeaderText);

                        for (int j = 0; j < dgv.Rows.Count; j++)
                        {
                            
                            InformationAboutElements.SelectCells(alpha[iterator] + (j + 2).ToString(), Type.Missing);
                            InformationAboutElements.SetFont(otherFont, 0);
                            InformationAboutElements.SetBorderStyle(0, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
                            InformationAboutElements.setAutoFit(alpha[iterator] + (j + 2).ToString());
                            InformationAboutElements.WriteDataToCell(dgv[i, j].Value.ToString());                        
                        }

                        if (dgv[i, 0].Value.ToString().Length > dgv.Columns[i].HeaderText.Length)
                        {
                            InformationAboutElements.setAutoFit(alpha[iterator] + (2).ToString());
                        }
                        else
                        {
                            InformationAboutElements.setAutoFit(alpha[iterator] + (1).ToString());
                        }
                        

                        iterator++;
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
                HeadFont.Dispose();

            }
            
        }






        private void экспортToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выгрузка данных в таблицу Excel";
        }

        private void выходToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Выход из программы";
        }

        private void MD_OL_NEW_OR_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Просмотр поступивших заказов";
        }

        private void CurrentOrderMain_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с текущими заказами";
        }

        private void MD_OL_CONF_OR_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с листами заказа (Подтверждение исполнения заказа)";
        }

        private void MD_OL_GIVE_OR_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с листами заказа (Выдача сборки в цех)";
        }

        private void MD_OL_GET_OR_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с листами заказа (Принятие сборки из цеха)";
        }

        private void MD_OL_HIS_OR_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с листами заказа (Завершенные заказы/Карта учета УСПО)";
        }

        private void MD_TZ_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Работа с теническим заданием без ипользования ВПП";
        }

        private void MD_ASSEM_STAT_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Просмотр статистики по сборками УСПО";
        }

        private void общаяИнформацияПоЭлементамУСПToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Просмотр информации по элементам УСП";
        }

        private void текущийПериуToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Статистика по задействованным элементам в текущий период времени";
        }

        private void заToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Общая статистика по элементам";
        }

        private void добавитьЭлементToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Внесение информации по новым элементам УСП";
        }

        private void редактироватьToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Корректировка информации по новым элементам УСП";
        }

        private void удалитьЭлементToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Сокращение количества элементов на складе";
        }

        private void оформитьНакладнуюToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Оформление тебования-накладных";
        }

        private void редактироватьНакладнуюToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Корректировка тебования-накладных";
        }

        private void просмотретьНакладнуюToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Просмор тебования-накладных";
        }

        private void удалитьНакладнуюToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Удаление тебования-накладных";
        }

        private void оформитьАктToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Оформление актов на списание";
        }

        private void редактироватьАктToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Корректировка актов на списание";
        }

        private void просмотретьАктыToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Просмотр актов на списание";
        }

        private void удалитьАктыToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Удаление актов на списание";
        }

        private void общиеНастройкиToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Изменение настроек текущего пользователя";
        }

        private void toolStripMenuItem4_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Вызов справочной информации по ПО";
        }

        private void информацияToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Описание ПО";
        }
        public void SetModuleDisable(string NameModule)
        {
            switch (NameModule)
            {
                case "MD_OL_NEW_OR":
                    MD_OL_NEW_OR.Enabled = false;
                    MD_OL_NEW_OR.Visible = false;
                    break;
                case "MD_OL_CONF_OR":
                    MD_OL_CONF_OR.Enabled = false;
                    MD_OL_CONF_OR.Visible = false;
                    break;
                case "MD_OL_GIVE_OR":
                    MD_OL_GIVE_OR.Enabled = false;
                    MD_OL_GIVE_OR.Visible = false;
                    break;
                case "MD_OL_GET_OR":
                    MD_OL_GET_OR.Enabled = false;
                    MD_OL_GET_OR.Visible = false;
                    break;
                case "MD_OL_HIS_OR":
                    MD_OL_HIS_OR.Enabled = false;
                    MD_OL_HIS_OR.Visible = false;
                    break;
                case "MD_TZ":
                    MD_TZ.Enabled = false;
                    MD_TZ.Visible = false;
                    break;
                case "MD_ASSEM_STAT":
                    MD_ASSEM_STAT.Enabled = false;
                    MD_ASSEM_STAT.Visible = false;
                    break;
                case "MD_ELEM_NALICH":
                    MD_ELEM_NALICH.Enabled = false;
                    MD_ELEM_NALICH.Visible = false;
                    break;
                case "MD_ELEM_OPER":
                    MD_ELEM_OPER.Enabled = false;
                    MD_ELEM_OPER.Visible = false;
                    break;
                case "MD_ELEM_DOC":
                    MD_ELEM_DOC.Enabled = false;
                    MD_ELEM_DOC.Visible = false;
                    break;
            }

            disableGeneral();
        }


        private void disableGeneral()
        {
            if ((MD_OL_NEW_OR.Enabled == false) && (MD_OL_CONF_OR.Enabled == false) && (MD_OL_GIVE_OR.Enabled == false) && (MD_OL_GET_OR.Enabled == false) && (MD_OL_HIS_OR.Enabled == false))
            {
                OrderMain.Enabled = false;
                OrderMain.Visible = false;
            }
            if ((MD_OL_CONF_OR.Enabled == false) && (MD_OL_GIVE_OR.Enabled == false) && (MD_OL_GET_OR.Enabled == false))
            {
                CurrentOrderMain.Enabled = false;
                CurrentOrderMain.Visible = false;
            }
            if ((MD_TZ.Enabled == false))
            {
                TZMain.Enabled = false;
                TZMain.Visible = false;
            }
            if ((MD_TZ.Enabled == false))
            {
                TZMain.Enabled = false;
                TZMain.Visible = false;
            }
            if ((MD_ASSEM_STAT.Enabled == false))
            {
                AssemMain.Enabled = false;
                AssemMain.Visible = false;
            }
            if ((MD_ELEM_NALICH.Enabled == false) && (MD_ELEM_OPER.Enabled == false) && (MD_ELEM_DOC.Enabled == false))
            {
                ElemMain.Enabled = false;
                ElemMain.Visible = false;
            }
        }

        public void SetModuleEnable(string NameModule)
        {
            switch (NameModule)
            {
                case "MD_OL_NEW_OR":
                    MD_OL_NEW_OR.Enabled = true;
                    MD_OL_NEW_OR.Visible = true;
                    break;
                case "MD_OL_CONF_OR":
                    MD_OL_CONF_OR.Enabled = true;
                    MD_OL_CONF_OR.Visible = true;
                    break;
                case "MD_OL_GIVE_OR":
                    MD_OL_GIVE_OR.Enabled = true;
                    MD_OL_GIVE_OR.Visible = true;
                    break;
                case "MD_OL_GET_OR":
                    MD_OL_GET_OR.Enabled = true;
                    MD_OL_GET_OR.Visible = true;
                    break;
                case "MD_OL_HIS_OR":
                    MD_OL_HIS_OR.Enabled = true;
                    MD_OL_HIS_OR.Visible = true;
                    break;
                case "MD_TZ":
                    MD_TZ.Enabled = true;
                    MD_TZ.Visible = true;
                    break;
                case "MD_ASSEM_STAT":
                    MD_ASSEM_STAT.Enabled = true;
                    MD_ASSEM_STAT.Visible = true;
                    break;
                case "MD_ELEM_NALICH":
                    MD_ELEM_NALICH.Enabled = true;
                    MD_ELEM_NALICH.Visible = true;
                    break;
                case "MD_ELEM_OPER":
                    MD_ELEM_OPER.Enabled = true;
                    MD_ELEM_OPER.Visible = true;
                    break;
                case "MD_ELEM_DOC":
                    MD_ELEM_DOC.Enabled = true;
                    MD_ELEM_DOC.Visible = true;
                    break;
            }

            enableGeneral();
        }


        private void enableGeneral()
        {
            if ((MD_OL_NEW_OR.Enabled == true) || (MD_OL_CONF_OR.Enabled == true) || (MD_OL_GIVE_OR.Enabled == true) || (MD_OL_GET_OR.Enabled == true) || (MD_OL_HIS_OR.Enabled == true))
            {
                OrderMain.Enabled = true;
                OrderMain.Visible = true;
            }
            if ((MD_OL_CONF_OR.Enabled == true) || (MD_OL_GIVE_OR.Enabled == true) || (MD_OL_GET_OR.Enabled == true))
            {
                CurrentOrderMain.Enabled = true;
                CurrentOrderMain.Visible = true;
            }
            if ((MD_TZ.Enabled == true))
            {
                TZMain.Enabled = true;
                TZMain.Visible = true;
            }
            if ((MD_TZ.Enabled == true))
            {
                TZMain.Enabled = true;
                TZMain.Visible = true;
            }
            if ((MD_ASSEM_STAT.Enabled == true))
            {
                AssemMain.Enabled = true;
                AssemMain.Visible = true;
            }
            if ((MD_ELEM_NALICH.Enabled == true) || (MD_ELEM_OPER.Enabled == true) || (MD_ELEM_DOC.Enabled == true))
            {
                ElemMain.Enabled = true;
                ElemMain.Visible = true;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            using (WinForms.settings.setings SettingsForm = new WinForms.settings.setings(this.Width, this.Height))
            {
                SettingsForm.voidCloseAPP();
            }
        }


        void setSizeForm()
        {
            if (SQLOracle.existParamQuery("FORM_SAVE", "USP_USER_SETTING", "FORM_SAVE = '1' AND USR ", "USR", SQLOracle.GetCurrentUser()))
            {
                System.Collections.Generic.List<string> SizeStr = SQLOracle.GetStrFromBD("FORM_WIDTH, FORM_HEIGHT", "USP_USER_SETTING", "USR", SQLOracle.GetCurrentUser());

                if (SizeStr.Count > 0)
                {
                    this.Width = Convert.ToInt32(SizeStr[0]);
                    this.Height = Convert.ToInt32(SizeStr[1]);
                }

                SizeStr.Clear();
            }

        }

        /// <summary>
        /// обновление меню формы для текущего пользователя в соответствии с БД
        /// </summary>
        void UpdateMenu()
        {
            if (SQLOracle.existParamQuery("FORM_SAVE", "USP_USER_SETTING", "USR ", "USR", SQLOracle.GetCurrentUser()))
            {
                System.Collections.Generic.List<string> parametr = new System.Collections.Generic.List<string>();
                System.Collections.Generic.List<string> value = new System.Collections.Generic.List<string>();

                parametr.Add("USR");
                value.Add(SQLOracle.GetCurrentUser());

                System.Data.DataSet DS = SQLOracle.ParamQuerySelectNonPercent("SELECT * FROM USP_USER_SETTING WHERE USR = :USR", parametr, value);

                if (DS.Tables.Count > 0)
                {

                    for (int i = 0; i < DS.Tables[0].Columns.Count; i++)
                    {
                        if (String.Compare(DS.Tables[0].Rows[0][i].ToString(), "0") == 0)
                        {
                            SetModuleDisable(DS.Tables[0].Columns[i].ColumnName.ToString());
                        }

                    }

                }
            }
            
            
            
        }

       
    }
}
