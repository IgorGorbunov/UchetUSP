using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using UchetUSP.Algorithm;
using UchetUSP.WinForms;
using UchetUSP.AccessUser;


namespace UchetUSP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Добро пожаловать в АС \"Учет УСП\"";
            
        }

        private int StatusOfForm  = 0;

        //настройка исключает возможность повторного запуска одной и тойже панели при ее активации;

        private int ActiveStatus
        {
              get{   
                        return  this.StatusOfForm;
                  }
                set{
                    this.StatusOfForm = value;
                    }
        
        }

        Layout.LayoutAss AssLayout;
        Layout.Layout ElementsWrk;
        Layout.LayoutOrder newLaoutOrder;
        Layout.LayoutOrderTZ TZOrder;
        Layout.LayoutColdStats ColdStatistic;


        
        private void Form1_Load(object sender, EventArgs e)
        {
                      

            ElementsWrk = new Layout.Layout(this.panel1,toolStripStatusLabel1);
            newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
            TZOrder = new UchetUSP.Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
            ColdStatistic = new Layout.LayoutColdStats(this.panel1, toolStripStatusLabel1);
            AssLayout = new UchetUSP.Layout.LayoutAss(this.panel1, toolStripStatusLabel1);

            if (String.Compare(Program.DocIdString, "0") == 0)//запускается в слуаче отсутствия номера передаваемого документа
            {
                if (ActiveStatus != 5)
                {
                    ActiveStatus = 5;

                    CheckDispose();

                    newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
                    newLaoutOrder.LayoutMainForm();
                }

                //TODO добавить данные о юзере
                setSizeForm();
                UpdateMenu();
            }
            else {//запускается в случае если передан номер документа

                if ((String.Compare(Program.EditRighsString, "1") == 0) && (!UchetUSP.AccessUser.AccessUser.GetEditRights(Program.DocIdString)))//разрешение на действие если пользователь имеет доступ и документ не был подписан
                {
                   
                    this.Visible = false;
                    //запускается если ТЗ было оформлено
                    if (SQLOracle.exist("USP_TZ_DATA", "ID_DOC = '" + Program.DocIdString + "'"))
                    {                        
                        //правильно ли передан 5ый параметр оснастки и кода устверждения
                        if (Program.DocIdUtv.Length > 0)
                        { //если код утверждения = 0 (разработка)
                            if (String.Compare(Program.DocIdUtv[0].ToString(), "0") == 0)
                            { 
                                    if (ActiveStatus != 1)
                                    {
                                    ActiveStatus = 1;

                                    CheckDispose();
                                    TZOrder = new Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
                                    TZOrder.LayoutTZ();
                                    TZOrder.loadTZForm(1);
                                    TZOrder.SetDataGridRowSelect(Program.DocIdString);                            
                                    }

                                }//если код утверждения = 1 или 2 (архив или утвержденные)
                                else if ((String.Compare(Program.DocIdUtv[0].ToString(), "2") == 0)||(String.Compare(Program.DocIdUtv[0].ToString(), "1") == 0))
                                {
                                    if (ActiveStatus != 1)
                                    {
                                        ActiveStatus = 1;

                                        CheckDispose();
                                        TZOrder = new Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
                                        TZOrder.LayoutTZ();
                                        TZOrder.loadTZForm(3);
                                        TZOrder.SetDataGridRowSelect(Program.DocIdString);
                                    }
                                    
                                }
                        }
                       
                      

                    }
                    else {
                        //если документ не оформлен
                        using (CreateTZ NewTZForm = new CreateTZ(0,0, Program.DocIdString))
                        {
                            NewTZForm.ShowDialog();
                            Application.Exit();
                        }

                    }                     
                }
                else //запрет на действие (3ий параметр)
                {
                    //если документ был оформлен
                    if (SQLOracle.exist("USP_TZ_DATA", "ID_DOC = '" + Program.DocIdString + "'"))
                    {

                        if (ActiveStatus != 1)
                        {
                            ActiveStatus = 1;

                            CheckDispose();
                            TZOrder = new Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
                            TZOrder.LayoutTZ();                            
                            TZOrder.loadTZForm(3);
                            TZOrder.SetDataGridRowSelect(Program.DocIdString);
                        }


                    }
                    else//если документ не был оформлен
                    {
                        if (ActiveStatus != 1)
                        {
                            ActiveStatus = 1;

                            CheckDispose();
                            TZOrder = new Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
                            TZOrder.LayoutTZ();                            
                            TZOrder.loadTZForm(4);
                            TZOrder.SetDataGridRowSelect(Program.DocIdString);
                        }

                    }  
                    
                
                }
                
                
            }

                      
                        
        }

        private void CheckDispose()
        {
            AssLayout.Dispose();
            ElementsWrk.Dispose();
            newLaoutOrder.Dispose();
            TZOrder.Dispose();
            ColdStatistic.Dispose();
        }


        private void toolStripSeparator1_Click(object sender, EventArgs e)
        {

        }
              

        private void оформитьТЗToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           
            if (ActiveStatus != 1)
            {
                ActiveStatus = 1;
                CheckDispose();
                TZOrder = new Layout.LayoutOrderTZ(this.panel1, toolStripStatusLabel1);
                TZOrder.LayoutTZ();
                TZOrder.loadTZForm(1);                                          
            }

        }


        

        private void создатьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(AddUspOrder newOrder = new AddUspOrder())
            {
                newOrder.ShowDialog();
            }
            
        }

        private void просмотрТЗВнеВППToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void общаяИнформацияПоЭлементамУСПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 2)
            {
                ActiveStatus = 2;

                CheckDispose();

                ElementsWrk = new Layout.Layout(this.panel1,toolStripStatusLabel1);                           
              
                ElmInform.ViewInform(ElementsWrk.LayoutElemUSP(1));  
            
            }                 
          
        }

        private void общиеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.settings.setings SettingsForm = new WinForms.settings.setings())
            {
                SettingsForm.ShowDialog(this);
            }
        }

        private void внестиИнформациюПоСуществующейМоделиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.AddInformationAboutElements.AddInformation AddForm = new UchetUSP.WinForms.AddInformationAboutElements.AddInformation(1))
            {
                AddForm.ShowDialog();
            }

        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessUser.AccessUser.GetRLType(1))
            {
                if (ActiveStatus != 3)
                {
                    ActiveStatus = 3;

                    CheckDispose();

                    ElementsWrk = new Layout.Layout(this.panel1, toolStripStatusLabel1);

                    ElmInform.ViewInform(ElementsWrk.LayoutElemUSP(2));

                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав корректировки информации по элементам УСП!");
            }


            
        }

        private void удалитьЭлементToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AccessUser.AccessUser.GetRLType(1))
            {
                if (ActiveStatus != 4)
                {
                    ActiveStatus = 4;

                    CheckDispose();

                    ElementsWrk = new Layout.Layout(this.panel1, toolStripStatusLabel1);

                    ElmInform.ViewInform(ElementsWrk.LayoutElemUSP(3));

                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав изменения информации по количеству элементов на складе!");
            }


           
        }
     

        private void оформитьАктНаСписаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(0))
            {
                NewAct.ShowDialog();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 6)
            {
                ActiveStatus = 6;

                CheckDispose();

                newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
                newLaoutOrder.LayoutConfirmOrder();
                newLaoutOrder.ShowNotConfirmedOrder(DateTime.Today,DateTime.Today);

            }
        }

        private void выдатьСборкуВЦехToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 7)
            {
                ActiveStatus = 7;

                CheckDispose();

                newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
                newLaoutOrder.LayoutGrantOrder();
                newLaoutOrder.ShowNotGrantedOrder(DateTime.Today, DateTime.Today);
            }
        }

        private void принятьСборкуИзЦехаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 8)
            {
                ActiveStatus = 8;

                CheckDispose();

                newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
                newLaoutOrder.LayoutGetOrder();
                newLaoutOrder.ShowNotGetOrder(DateTime.Today, DateTime.Today);

            }
        }

        private void завершенныеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 9)
            {
                ActiveStatus = 9;

                CheckDispose();

                newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
              
                newLaoutOrder.LayoutHistoryOrder();
                
                newLaoutOrder.ShowHistoryOrder(DateTime.Today, DateTime.Today);
                
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {            
            CheckDispose();
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckDispose();
            Application.Exit();
        }

        private void добавитьЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.AddInformation AddForm = new UchetUSP.WinForms.AddInformationAboutElements.AddInformation(1))
                {
                    AddForm.ShowDialog();
                }
            }
            else {
                MessageBox.Show("У Вас нет прав внесения информации по элементам УСП!");
            }
            

        }



        private void оформитьНакладнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.AddNakladnaya AddNakl = new UchetUSP.WinForms.AddInformationAboutElements.AddNakladnaya(0))
                {
                    AddNakl.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на оформление тебования-накладных!");
            }

        }

        private void оформитьАктToolStripMenuItem_Click(object sender, EventArgs e)
        {           

            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.ActSpisanie NewAct = new UchetUSP.WinForms.AddInformationAboutElements.ActSpisanie(0))
                {
                    NewAct.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на оформление актов на списание!");
            }

        }

        private void редактироватьАктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.ViewAct ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewAct(2))
                {
                    ViewAct.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на корректировку актов на списание!");
            }
            
        }

        private void просмотретьАктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.AddInformationAboutElements.ViewAct ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewAct(1))
            {
                ViewAct.ShowDialog();
            }

        }

        private void удалитьАктыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.ViewAct ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewAct(3))
                {
                    ViewAct.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на удаление актов на списание!");
            }
        }

        private void редактироватьНакладнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.ViewNacladnaya ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewNacladnaya(2))
                {
                    ViewAct.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на корректировку тебования-накладных!");
            }
                
        }

        private void просмотретьНакладнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.AddInformationAboutElements.ViewNacladnaya ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewNacladnaya(1))
            {
                ViewAct.ShowDialog();
            }
        }

        private void удалитьНакладнуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (AccessUser.AccessUser.GetRLType(1))
            {
                using (WinForms.AddInformationAboutElements.ViewNacladnaya ViewAct = new UchetUSP.WinForms.AddInformationAboutElements.ViewNacladnaya(3))
                {
                    ViewAct.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("У Вас нет прав на удаление тебования-накладных!");
            }
        }

        private void месторасположениеЭлементовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

       
        /*
        private void пользователиСистемыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WinForms.Settings.Users NewUsers = new UchetUSP.WinForms.Settings.Users())
            {

                if (String.Compare(SQLOracle.ParamQuerySelect(("SELECT USERS_ADD FROM USP_CREATE_GROUP WHERE NAME = (SELECT NAMEOFGROUP FROM USP_USERS WHERE USERLOGIN = :login)"), "login", SQLOracle._user), "1") == 0)
                {
                    NewUsers.ShowDialog();
                }
                else {
                    MessageBox.Show("У Вас недостасточно прав для доступа к наcтройкам пользователей");
                }
                
            }
        }*/

        private void подписаниеТЗToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show( UchetUSP.AccessUser.AccessUser.GetUserRights().ToString());
        }

        private void информацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UchetUSP.About newAbout = new About())
            {
                newAbout.ShowDialog();
            }
            
        }


        /// <summary>
        /// Устанавливает сроку состояния из разных частей программы;
        /// </summary>
        /// <param name="str">
        /// строка сотояния</param>
        /// <returns></returns>
        public void SetToolStripStatusLabel(string str)
        {
            toolStripStatusLabel1.Text = str;
        }

        private void оформитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void новыеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ActiveStatus != 5)
            {
                ActiveStatus = 5;

                CheckDispose();

                newLaoutOrder = new Layout.LayoutOrder(this.panel1, toolStripStatusLabel1);
                newLaoutOrder.LayoutMainForm();
                newLaoutOrder.fillOrders();
            }

        }

        private void текущийПериуToolStripMenuItem_Click(object sender, EventArgs e)
        {
                using (HotStatsForm StatForm = new HotStatsForm())
	            {
                    StatForm.ShowDialog();
	            } 
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ActiveStatus != 11)
            {
                ActiveStatus = 11;

                CheckDispose();

                AssLayout = new Layout.LayoutAss(this.panel1, toolStripStatusLabel1);
                AssLayout.setLayout();
                AssLayout.fillDGV(DateTime.Today, DateTime.Today);
            }
        }

        private void заToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveStatus != 10)
            {
                ActiveStatus = 10;

                CheckDispose();

                ColdStatistic = new Layout.LayoutColdStats(this.panel1, toolStripStatusLabel1);
                ColdStatistic.setLayout();
                ColdStatistic.fillDGV(DateTime.Today, DateTime.Today);
            }
        }

      
      

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView dg = null;
            FindDataGrid(ref dg,this.panel1);
            if (dg != null)
            {
                ExportDGVToExcel(dg);
               /* MessageBox.Show("");
                DataTable dt;
                dt = ((DataTable)(dg.DataSource));
                //MessageBox.Show(dt.Rows[0][0].ToString());
                xlsStats newExcel = new xlsStats((DataTable)(dg.DataSource));*/
            }                       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ElementsDestinationForm f = new ElementsDestinationForm())
            {
                f.ShowDialog();
            }
        }
      
       
    }
}