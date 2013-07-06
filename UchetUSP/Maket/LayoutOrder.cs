using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using UchetUSP.WinForms;
using UchetUSP.Algorithm;
using System.Threading;
using System.Data;
using UchetUSP.AccessUser;
using System.Diagnostics;

namespace UchetUSP.Layout
{
    public partial class LayoutOrder : IDisposable
    {
        int docStatus;
        private bool isDisposed = false;

        DataGridView dGV = new DataGridView();
        Button button1;
        Button button3;
        Button button4;
        Label label1;
        Label label2;

        ComboBox comboBox1;
        ComboBox comboBox2;

        Panel panel2;
        Panel panel3;

        GroupBox groupBox1;
        GroupBox groupBox2;
        GroupBox groupBox3;
        GroupBox groupBox4;
        GroupBox gBDateFilter;

        DateTimePicker dateTimePicker1;
        DateTimePicker dateTimePicker2;
        DateTimePicker dTPAssCard;

        Dictionary<string, string> _Elements;
        bool _assWasEdited = false;

        //Рабочая форма
        Panel ParentPanel;

        //Рабочая строка статуса
        System.Windows.Forms.ToolStripStatusLabel ParentToolStripStatusLabel;

        //Инициализация класса с получением рабочей формы
        public LayoutOrder(Panel Panel, System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1)
        {
            ParentPanel = Panel;
            ParentToolStripStatusLabel = ToolStripStatusLabel1;

            Data.ElemsAfterEditingAss = new Data.MyEventDict(writeElems);
        }

        void writeElems(Dictionary<string, string> Dict)
        {
            _Elements = Dict;
            _assWasEdited = true;
        }


        ///////////////////////////////////////////////////////////////
        ///////////////////////удаление компонентов формы//////////////
        ///////////////////////////////////////////////////////////////

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    //datagridview
                    if (ParentPanel.Controls.Contains(dGV))
                    {
                        this.dGV.MouseHover -= new System.EventHandler(dGV_HistoryOrder);
                        this.dGV.MouseHover -= new System.EventHandler(dGV_GetOrder); 
                        this.dGV.MouseHover -= new System.EventHandler(dGV_GrantOrder);  
                        dGV.MouseHover -= new System.EventHandler(dGV_ConfirmOrder);
                        dGV.MouseHover -= new System.EventHandler(dGV_MainForm);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_init_order);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Confirm_Order);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Grant_Order);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Get_Order);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_History_Order);
                        dGV.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_init_order);
                        ParentPanel.Controls.Remove(dGV);
                        dGV.Dispose();
                    }
                    //кнопки
                    if (ParentPanel.Controls.Contains(button1))
                    {
                        ParentPanel.Controls.Remove(button1);
                        button1.Dispose();

                    }
                    if (ParentPanel.Controls.Contains(button3))
                    {
                        this.button3.MouseHover -= new System.EventHandler(button3_HistoryOrder);
                        this.button3.MouseHover -= new System.EventHandler(button3_GetOrder);
                        this.button3.MouseHover -= new System.EventHandler(button3_GrantOrder); 
                        this.button3.MouseHover -= new System.EventHandler(button3_ConfirmOrder);
                        button3.MouseHover -= new System.EventHandler(button3_MainForm);
						this.button3.Click -= new System.EventHandler(SearchHistoryOrder_Click);
                        this.button3.Click -= new System.EventHandler(SearchGetOrder_Click);
                        this.button3.Click -= new System.EventHandler(SearchGrantOrder_Click);
                        this.button3.Click -= new System.EventHandler(SearchLZConfirm_Click);
                        ParentPanel.Controls.Remove(button3);
                        button3.Dispose();
                    }
                    if (ParentPanel.Controls.Contains(button4))
                    {
                        button4.MouseHover -= new System.EventHandler(button4_MainForm);
                        button4.Click -= new System.EventHandler(SearchVPP_Click);
                        ParentPanel.Controls.Remove(button4);
                        button4.Dispose();
                    }

                    //лейблы

                    if (ParentPanel.Controls.Contains(label1))
                    {
                        ParentPanel.Controls.Remove(label1);
                        label1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(label2))
                    {
                        ParentPanel.Controls.Remove(label2);
                        label2.Dispose();
                    }

                    //dateTimePicker;
                    if (ParentPanel.Controls.Contains(dateTimePicker1))
                    {
                        this.dateTimePicker1.MouseHover -= new System.EventHandler(dateTimePicker1_HistoryOrder);
                        this.dateTimePicker1.MouseHover -= new System.EventHandler(dateTimePicker1_GetOrder);
                        this.dateTimePicker1.MouseHover -= new System.EventHandler(dateTimePicker1_GrantOrder); 
                        dateTimePicker1.MouseHover -= new System.EventHandler(dateTimePicker1_ConfirmOrder);
                        dateTimePicker1.MouseHover -= new System.EventHandler(dateTimePicker1_MainForm);
                        this.dateTimePicker1.CloseUp -= new EventHandler(dTP_ValueChanged_Confirm_Order);
                        dateTimePicker1.CloseUp -= new System.EventHandler(dTP_ValueChanged);
                        ParentPanel.Controls.Remove(dateTimePicker1);
                        dateTimePicker1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(dateTimePicker2))
                    {
                        this.dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_HistoryOrder);
                        this.dateTimePicker2.MouseHover -= new System.EventHandler(dateTimePicker2_GetOrder);
                        this.dateTimePicker2.MouseHover -= new System.EventHandler(dateTimePicker2_GrantOrder); 
                        dateTimePicker2.MouseHover -= new System.EventHandler(dateTimePicker2_ConfirmOrder);
                        dateTimePicker2.MouseHover -= new System.EventHandler(dateTimePicker2_MainForm);
                        this.dateTimePicker2.CloseUp -= new EventHandler(dTP_ValueChanged_Confirm_Order);
                        dateTimePicker2.CloseUp -= new System.EventHandler(dTP_ValueChanged);
                        ParentPanel.Controls.Remove(dateTimePicker2);
                        dateTimePicker2.Dispose();
                    }
                    //comboBox

                    if (ParentPanel.Controls.Contains(comboBox1))
                    {
                        this.comboBox1.MouseHover -= new System.EventHandler(comboBox1_HistoryOrder);
                        this.comboBox1.MouseHover -= new System.EventHandler(comboBox1_GetOrder);
                        this.comboBox1.MouseHover -= new System.EventHandler(comboBox1_GrantOrder); 
                        this.comboBox1.MouseHover -= new System.EventHandler(comboBox1_ConfirmOrder);
                        comboBox1.MouseHover -= new System.EventHandler(comboBox1_MainForm);
                        ParentPanel.Controls.Remove(comboBox1);
                        comboBox1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(comboBox2))
                    {
                        comboBox2.MouseHover -= new System.EventHandler(comboBox2_MainForm);
                        ParentPanel.Controls.Remove(comboBox2);
                        comboBox2.Dispose();
                    }

                    //groupBox

                    if (ParentPanel.Controls.Contains(groupBox1))
                    {
                        ParentPanel.Controls.Remove(groupBox1);
                        groupBox1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(groupBox2))
                    {
                        ParentPanel.Controls.Remove(groupBox2);
                        groupBox2.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(groupBox3))
                    {
                        ParentPanel.Controls.Remove(groupBox3);
                        groupBox3.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(groupBox4))
                    {
                        ParentPanel.Controls.Remove(groupBox4);
                        groupBox4.Dispose();
                    }

                    //panel

                    if (ParentPanel.Controls.Contains(panel2))
                    {
                        ParentPanel.Controls.Remove(panel2);
                        panel2.Dispose();
                    }
                    if (ParentPanel.Controls.Contains(panel3))
                    {
                        ParentPanel.Controls.Remove(panel3);
                        panel3.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(dTPAssCard))
                    {
                        this.dTPAssCard.MouseHover -= new System.EventHandler(dTPAssCard_HistoryOrder);
                        ParentPanel.Controls.Remove(dTPAssCard);
                        dTPAssCard.Dispose();
                    }

                    

                    //ParentPanel.SizeChanged -= new System.EventHandler(ParentPanel_SizeChanged);

                    //принудительно освобождаем память от мусора

                    System.GC.Collect();

                }
                isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }




        //////////////////////////////////////////////////////////////////////////
        ////ОСНОВНАЯ ПАНЕЛЬ ВЫВОДА ВПП/ВЗД/ТЗ////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////

        public void LayoutMainForm()
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            dGV = new System.Windows.Forms.DataGridView();

            comboBox1 = new System.Windows.Forms.ComboBox();
            comboBox2 = new System.Windows.Forms.ComboBox();

            groupBox1 = new System.Windows.Forms.GroupBox();

            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            //button1 = new System.Windows.Forms.Button();
            //button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();

            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();

            //фильтр по дате
            label1 = new Label();
            label2 = new Label();

            gBDateFilter = new GroupBox();

            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            //


            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dGV)).BeginInit();
            groupBox1.SuspendLayout();
            gBDateFilter.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ParentPanel.SuspendLayout();


            // 
            // panel2
            // 

            panel2.Controls.Add(groupBox3);
            panel2.Controls.Add(groupBox4);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(gBDateFilter);
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(595, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(184, 294);
            panel2.TabIndex = 1;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] {
            "ВСЕ",
            "ВПП",
            "ВЗД",
            "ТЗ (без ВПП)"});
            comboBox1.Location = new System.Drawing.Point(6, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(160, 21);
            comboBox1.TabIndex = 2;
            comboBox1.Text = comboBox1.Items[0].ToString();
            comboBox1.SelectedIndexChanged += new System.EventHandler(cBOrders_SelectedIndexChanged);
            comboBox1.MouseHover += new System.EventHandler(comboBox1_MainForm);
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] {
            "ВСЕ",
            "ВПП",
            "ТЗ",
            "Спецификация"
            });
            comboBox2.Location = new System.Drawing.Point(6, 19);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(160, 21);
            comboBox2.TabIndex = 1;
            comboBox2.MouseHover += new System.EventHandler(comboBox2_MainForm);
            comboBox2.SelectedIndexChanged += new System.EventHandler(cB_GetKD);
            // 
            // panel3
            // 
            panel3.Controls.Add(dGV);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(600, 294);
            panel3.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            dGV.Location = new System.Drawing.Point(0, 0);
            dGV.Name = "dataGridView1";
            dGV.Size = new System.Drawing.Size(595, 294);
            dGV.TabIndex = 0;
            this.dGV.ReadOnly = true;
            this.dGV.MultiSelect = false;
            this.dGV.RowHeadersVisible = false;
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            dGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_init_order);
            dGV.MouseHover += new System.EventHandler(dGV_MainForm);
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(6, 20);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(160, 23);
            button3.TabIndex = 6;
            button3.Text = "Выгрузить модель";
            button3.UseVisualStyleBackColor = true;
            button3.MouseHover += new System.EventHandler(button3_MainForm);
            button3.Click += new System.EventHandler(LoadPartToNX_Click);
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(6, 50);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(160, 23);
            button4.TabIndex = 7;
            button4.Text = "Поиск";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(SearchVPP_Click);
            button4.MouseHover += new System.EventHandler(button4_MainForm);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBox2);
            groupBox1.ForeColor = System.Drawing.Color.Black;
            groupBox1.Location = new System.Drawing.Point(9, 160);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(171, 52);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Документация:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.ForeColor = System.Drawing.Color.Black;
            groupBox3.Location = new System.Drawing.Point(9, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(171, 52);
            groupBox3.TabIndex = 10;
            groupBox3.TabStop = false;
            groupBox3.Text = "Сортировать по:";

            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(button4);
            groupBox4.ForeColor = System.Drawing.Color.Black;
            groupBox4.Location = new System.Drawing.Point(9, 224);
            groupBox4.Name = "groupBox3";
            groupBox4.Size = new System.Drawing.Size(171, 80);
            groupBox4.TabIndex = 10;
            groupBox4.TabStop = false;
            groupBox4.Text = "Функционал:";

            //сортировка по дате

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // groupBox1
            // 
            this.gBDateFilter.Controls.Add(this.dateTimePicker2);
            this.gBDateFilter.Controls.Add(this.label2);
            this.gBDateFilter.Controls.Add(this.label1);
            this.gBDateFilter.Controls.Add(this.dateTimePicker1);
            this.gBDateFilter.Location = new System.Drawing.Point(9, 13);
            this.gBDateFilter.Name = "groupBox1";
            this.gBDateFilter.Size = new System.Drawing.Size(171, 77);
            this.gBDateFilter.TabIndex = 0;
            this.gBDateFilter.TabStop = false;
            this.gBDateFilter.Text = "Вывести:";
            gBDateFilter.ForeColor = System.Drawing.Color.Black;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "с";

            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 0;
            dateTimePicker1.CloseUp += new System.EventHandler(dTP_ValueChanged);
            dateTimePicker1.MouseHover += new System.EventHandler(dateTimePicker1_MainForm);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(36, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker2.TabIndex = 3;
            dateTimePicker2.CloseUp += new System.EventHandler(dTP_ValueChanged);
            dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_MainForm);

            //установка dateTimePicker1 и dateTimePicker2

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();


            // 
            // Parent panel
            // 

            ParentPanel.Controls.Add(panel3);
            ParentPanel.Controls.Add(panel2);

            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gBDateFilter.ResumeLayout(false);
            gBDateFilter.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dGV)).EndInit();
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();



        }

        void cB_GetKD(object sender, EventArgs e)
        {
            if ((dGV.RowCount > 0) && (dGV.CurrentCell != null))
            {
                bool isTZ = false; //сортировка по ТЗ вне ВПП
                if (comboBox1.Text == "ТЗ (без ВПП)")
                {
                    isTZ = true;
                }

                if ((sender as ComboBox).Text == "ВПП")
                {
                    if (!isTZ)//!сортировка по ТЗ вне ВПП
                    {
                        string cell = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Номер ВПП"].Value.ToString();
                        if (cell != "") //не ТЗ вне ВПП
                        {
                            VPP doc = new VPP(cell);
                            doc.createXLS();
                        }
                    }
                }
                else if ((sender as ComboBox).Text == "ТЗ")
                {
                    if (!isTZ)//!сортировка по ТЗ вне ВПП
                    {
                        string cell = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Номер ВПП"].Value.ToString();

                        if (cell != "")//не ТЗ вне ВПП
                        {
                            int TZPos = Int32.Parse(dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Позиция ТЗ в ВПП"].Value.ToString());
                            Dictionary<string, string> Dict = Instrumentary.setDictTZ(cell, TZPos);
                            xlsTZ tzDoc = new xlsTZ(Dict);
                            tzDoc.createDocument();
                        }
                        else //однозначно ТЗ вне ВПП
                        {
                            string cellDocId = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["ID_DOC"].Value.ToString();
                                CreateTZ tz = new CreateTZ(1, 0, cellDocId);
                                tz.createXLS();

                        }
                    }
                    else //однозначно ТЗ вне ВПП
                    {
                        string cellDocId = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["ID_DOC"].Value.ToString();
                            CreateTZ tz = new CreateTZ(1, 0, cellDocId);
                            tz.createXLS();
                    }
                }
                else if ((sender as ComboBox).Text == "Спецификация")
                {
                    if (!isTZ)//!сортировка по ТЗ вне ВПП
                    {
                        string cell = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Номер ВПП"].Value.ToString();
                        if (cell != "")//не ТЗ вне ВПП
                        {
                            _startKTC();
                        }
                    }
                }
                else
                {
                    if (!isTZ)//!сортировка по ТЗ вне ВПП
                    {
                        string cell = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Номер ВПП"].Value.ToString();
                        if (cell != "")//не ТЗ вне ВПП
                        {
                            VPP doc = new VPP(cell);
                            doc.createXLS();

                            int TZPos = Int32.Parse(dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Позиция ТЗ в ВПП"].Value.ToString());
                            Dictionary<string, string> Dict = Instrumentary.setDictTZ(cell, TZPos);
                            xlsTZ tzDoc = new xlsTZ(Dict);
                            tzDoc.createDocument();

                            _startKTC();
                        }
                        else //однозначно ТЗ вне ВПП
                        {
                            string cellDocId = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["ID_DOC"].Value.ToString();
                            CreateTZ tz = new CreateTZ(1, 0, cellDocId);
                            tz.createXLS();
                        }
                    }
                    else //однозначно ТЗ вне ВПП
                    {
                        string cellDocId = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["ID_DOC"].Value.ToString();
                        CreateTZ tz = new CreateTZ(1, 0, cellDocId);
                        tz.createXLS();
                    }
                    
                }
            }
        }

        private void dTP_ValueChanged(object sender, EventArgs e)
        {
            fillOrders();
        }

        private void cBOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillOrders();
        }

        /// <summary>
        /// Заполнение DataGridView ТЗшками или листами заказа
        /// </summary>
        public void fillOrders()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if (comboBox1.SelectedIndex == 1)
            {
                //Thread PreLoaderTr = new Thread(new ThreadStart(LaunchPreLoader.start));
                //PreLoaderTr.Start();
                dGV.DataSource = Algorithm.ShowVPP.getVPPs(1, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                //Thread PreLoaderTr = new Thread(new ThreadStart(LaunchPreLoader.start));
                //PreLoaderTr.Start();
                dGV.DataSource = Algorithm.ShowVPP.getVPPs(2, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                //Thread PreLoaderTr = new Thread(new ThreadStart(LaunchPreLoader.start));
                //PreLoaderTr.Start();
                dGV.DataSource = Algorithm.ShowVPP.getVPPs(dateTimePicker1.Value, dateTimePicker2.Value).Tables[0];
                dGV.Columns["ID_DOC"].Visible = false;
                
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                //Thread PreLoaderTr = new Thread(new ThreadStart(LaunchPreLoader.start));
                //PreLoaderTr.Start();
                dGV.DataSource = Algorithm.ShowVPP.getTZs(dateTimePicker1.Value, dateTimePicker2.Value);
                dGV.Columns["ID_DOC"].Visible = false;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        ////////СОБЫТИЯ И ФУНКЦИИ ПАНЕЛИ ВЫВОДА ВПП/ВЗД/ТЗ///////////////////////
        /////////////////////////////////////////////////////////////////////////

        //Вывести VPP
        /*private void ShowOrder_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if (comboBox1.SelectedIndex == 1)
            {
                dGV.DataSource = Algorithm.ShowVPP.getVPPs(1).Tables[0];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                dGV.DataSource = Algorithm.ShowVPP.getVPPs(2).Tables[0];
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                Thread PreLoaderTr = new Thread(new ThreadStart(LaunchPreLoader.start));
                PreLoaderTr.Start();
                dGV.DataSource = Algorithm.ShowVPP.getVPPs().Tables[0];
                PreLoaderTr.Abort();
            }

        }*/

        private void dataGridView1_CellDoubleClick_init_order(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            if (AccessUser.AccessUser.GetRLType(1))//доступ кладовщицы
            {
                
                if (comboBox1.Text == "ВСЕ")
                {
                    if (dGV[0, dGV.SelectedCells[0].RowIndex].Value.ToString().Equals(""))
                    {
                        _startVPP();
                    }
                    else
                    {
                        _startTZ();
                    }
                }
                else if (comboBox1.Text == "ТЗ (без ВПП)")
                {
                    _startTZ();
                }
                else if (comboBox1.Text == "ВПП")
                {
                    _startVPP();
                }

            }
            else {
                MessageBox.Show("У Вас нет прав ызова мастера создания заказа на сборку УСПО!");
            }
           

        }

        void _startVPP()
        {
            string VPPnum = dGV["Номер ВПП", dGV.SelectedCells[0].RowIndex].Value.ToString();
            string TZnum = dGV["Номер ТЗ", dGV.SelectedCells[0].RowIndex].Value.ToString();
            int TZpoz = Int32.Parse(dGV["Позиция ТЗ в ВПП", dGV.SelectedCells[0].RowIndex].Value.ToString());
            string techn = dGV["Владелец", dGV.SelectedCells[0].RowIndex].Value.ToString();

            string assTitle = _ASSEMBLIES.getAssemblyTitle(VPPnum, TZpoz);
            Dictionary<string, string> Dict = _ASSEMBLIES.getElements(assTitle);
            bool notElements = false;
            string elTitle = "";
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                int free = _ELEMENTS.getAllN(Pair.Key) - _ELEMENTS.getBusyN(Pair.Key);
                if (_ELEMENTS.existElement(Pair.Key))
                {
                    if (free < Int32.Parse(Pair.Value))
                    {
                        notElements = true;
                        elTitle = Pair.Key;
                        break;
                    } 
                }
            }

            if (notElements)
            {
                if (MessageBox.Show("Для запуска листа заказа не хватает элементов.\n Хотите создать заказ, изменив состав сборки УСПО?", "Предупреждение!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning).ToString() == "Yes")
                {
                    fEditAssembly FEdit = new fEditAssembly(Dict);
                    FEdit.ShowDialog();
                }

                if (_assWasEdited)
                {
                    using (UchetUSP.AddUspOrder order = new AddUspOrder(VPPnum, TZnum, TZpoz, 1, techn, _Elements))
                    {
                        order.ShowDialog();
                    }
                    _assWasEdited = false;
                }
            }
            else
            {
                using (UchetUSP.AddUspOrder order = new AddUspOrder(VPPnum, TZnum, TZpoz, 1, techn, null))
                {
                    order.ShowDialog();
                }
            }
            
            fillOrders();
        }
        void _startTZ()
        {
            string idDoc = dGV["ID_DOC", dGV.SelectedCells[0].RowIndex].Value.ToString();
            string techn = dGV["Владелец", dGV.SelectedCells[0].RowIndex].Value.ToString();

            using (UchetUSP.AddUspOrder order = new AddUspOrder(idDoc, techn))
            {
                order.ShowDialog();
            }
            fillOrders();
        }


        void _startKTC()
        {
            string VPPNum = dGV["Номер ВПП", dGV.SelectedCells[0].RowIndex].Value.ToString();
            int VPPId = VPP.getId(VPPNum);
            string equipTitle = VPP.getEquipTitle(VPPId);
            int KTCId = VPP.getKTCId(equipTitle);

            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID_DOC", KTCId.ToString());

            int countPodp = SQLOracle.selectInt("select count(*) from PDM_DOC_PODP where DT is not null and ID_DOC = :ID_DOC", Dict);

            if (countPodp >= 3)
            {
                //Process.Start("exKTC_OSN.exe", "\"143515/143515@eoi\" \"C:\\Documents and Settings\\591056\\Local Settings\\Temp\\KTPP\" \"0\" \"2025831\" \"00\" \"7600\" \"USP_test_47601.0220.551.000   \"");
                //Process.Start("exKTC_OSN.exe", Program.ConnectionString + " \"C:\\Documents and Settings\\591056\\Local Settings\\Temp\\KTPP\" " + "0 " + KTCId + " " + "00 7600 " + equipTitle);
                Process StartKTC = new Process();
                StartKTC.StartInfo.FileName = "exKTC_OSN.exe";
                StartKTC.StartInfo.Arguments = Program.ConnectionString + " ";
                //StartKTC.StartInfo.Arguments += Program.PathString + " ";
                StartKTC.StartInfo.Arguments += "\"C:\\temp\" ";
                StartKTC.StartInfo.Arguments += "0 "; //скорее всего права
                StartKTC.StartInfo.Arguments += KTCId + " ";
                StartKTC.StartInfo.Arguments += "00 ";
                StartKTC.StartInfo.Arguments += "7600 ";
                StartKTC.StartInfo.Arguments += equipTitle;
                StartKTC.Start();
            }
            else
            {
                MessageBox.Show("Спецификация еще не утверждена!");
            }
        }




        //////////////////////////////////////////////////////////////////////////
        ////ПАНЕЛЬ ПОДТВЕРЖДЕНИЯ ЛИСТА ЗАКАЗА НА ИСПОЛНЕНИЕ ЗАКАЗА///////////////
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Функция формирования панели для отображения листов заказа для подтверждения их исполнения;
        /// </summary>
        /// <returns></returns>
        public void LayoutConfirmOrder()
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }


            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();

            comboBox1 = new System.Windows.Forms.ComboBox();

            button1 = new System.Windows.Forms.Button();

            button3 = new System.Windows.Forms.Button();

            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();

            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();

            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();




            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ParentPanel.SuspendLayout();


            ParentPanel.Controls.Add(panel3);
            ParentPanel.Controls.Add(panel2);

            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 294);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV.Location = new System.Drawing.Point(0, 0);
            this.dGV.Name = "dataGridView1";
            this.dGV.Size = new System.Drawing.Size(548, 294);
            this.dGV.TabIndex = 0;
            this.dGV.ReadOnly = true;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.MultiSelect = false;
            this.dGV.RowHeadersVisible = false;
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            dGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Confirm_Order);
            dGV.MouseHover += new System.EventHandler(dGV_ConfirmOrder);            
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(548, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 294);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вывести:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "с";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.CloseUp += new EventHandler(dTP_ValueChanged_Confirm_Order);
            dateTimePicker1.MouseHover += new System.EventHandler(dateTimePicker1_ConfirmOrder);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(36, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.CloseUp += new EventHandler(dTP_ValueChanged_Confirm_Order);
            dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_ConfirmOrder);

            //установка dateTimePicker1 и dateTimePicker2

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Поиск";
            this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(SearchLZConfirm_Click);
            this.button3.MouseHover += new System.EventHandler(button3_ConfirmOrder);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(17, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Операции:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Вывести ВПП",
            "Вывести ТЗ",
            "Вывести спецификацию",
            "Отобразить в Excel",
            "Удалить"});
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(comboBox1_ConfirmOrder);

            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();




        }

        private void dTP_ValueChanged_Confirm_Order(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            ShowNotConfirmedOrder(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        //////////////////////////////////////////////////////////////////////////
        ////СОБЫТИЯ И ФУНКЦИИ ПАНЕЛИ ПОДТВЕРЖДЕНИЯ ЛИСТА ЗАКАЗА НА ИСПОЛНЕНИЕ ЗАКАЗА
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Метод возвращает список оформленных, не подтвержденных сборками листов заказа в заданном временном промежутке
        /// </summary>
        /// <param name="fromDate">Начало временного интервала</param>
        /// <param name="toDate">Конец временного интервала</param>
        public void ShowNotConfirmedOrder(DateTime fromDate, DateTime toDate)
        {
            docStatus = 1;
            dGV.DataSource = Update(docStatus);
        }

        private void dataGridView1_CellDoubleClick_Confirm_Order(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if (AccessUser.AccessUser.GetRLType(1))//доступ кладовщицы
            {
                string num = dGV[0, dGV.SelectedCells[0].RowIndex].Value.ToString();

                using (UchetUSP.fOrderExecution order = new fOrderExecution(num))
                {
                    order.ShowDialog();
                }
                dGV.DataSource = Update(docStatus);
            }
            else {
                MessageBox.Show("У Вас нет прав вызова мастера подтверждения исполнения заказа на сборку УСПО!");
            }

        }





        //////////////////////////////////////////////////////////////////////////
        ////ПАНЕЛЬ РАБОТЫ С ЛИСТОМ ЗАКАЗА НА ВЫДАЧУ В ЦЕХ////////////////////////
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Функция формирования панели для отображения листов заказа для выдачи;
        /// </summary>
        /// <returns></returns>
        public void LayoutGrantOrder()
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();

            comboBox1 = new System.Windows.Forms.ComboBox();

            button1 = new System.Windows.Forms.Button();

            button3 = new System.Windows.Forms.Button();

            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();

            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();

            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();




            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ParentPanel.SuspendLayout();


            ParentPanel.Controls.Add(panel3);
            ParentPanel.Controls.Add(panel2);

            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 294);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV.Location = new System.Drawing.Point(0, 0);
            this.dGV.Name = "dataGridView1";
            this.dGV.Size = new System.Drawing.Size(548, 294);
            this.dGV.TabIndex = 0;
            this.dGV.ReadOnly = true;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.MultiSelect = false;
            this.dGV.RowHeadersVisible = false;
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Grant_Order);
            this.dGV.MouseHover += new System.EventHandler(dGV_GrantOrder);     
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(548, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 294);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вывести:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "с";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.CloseUp += new EventHandler(dTP_ValueChanged_Grant_Order);
            this.dateTimePicker1.MouseHover += new System.EventHandler(dateTimePicker1_GrantOrder);    
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(36, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.CloseUp += new EventHandler(dTP_ValueChanged_Grant_Order);
            this.dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_GrantOrder); 

            //установка dateTimePicker1 и dateTimePicker2

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Поиск";
            this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(SearchGrantOrder_Click);
            this.button3.MouseHover += new System.EventHandler(button3_GrantOrder);  
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(17, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Операции:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Вывести ВПП",
            "Вывести ТЗ",
            "Вывести спецификацию",
            "Отобразить в Excel",
            "Отменить сборку",
            "Удалить"});
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(comboBox1_GrantOrder); 

            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();



        }

        private void dTP_ValueChanged_Grant_Order(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            ShowNotGrantedOrder(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        //////////////////////////////////////////////////////////////////////////
        ////СОБЫТИЯ И ФУНКЦИИ ПАНЕЛИ РАБОТЫ С ЛИСТОМ ЗАКАЗА НА ВЫДАЧУ В ЦЕХ//////
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Метод возвращает список подтвержденных сборками, но еще не выданных листов заказа в заданном временном промежутке
        /// </summary>
        /// <param name="fromDate">Начало временного интервала</param>
        /// <param name="toDate">Конец временного интервала</param>
        public void ShowNotGrantedOrder(DateTime fromDate, DateTime toDate)
        {
            docStatus = 2;
            dGV.DataSource = Update(docStatus);
        }

        private void dataGridView1_CellDoubleClick_Grant_Order(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            if (AccessUser.AccessUser.GetRLType(1))//доступ кладовщицы
            {
                string num = dGV[0, dGV.SelectedCells[0].RowIndex].Value.ToString();

                using (UchetUSP.fGiveAssembly order = new fGiveAssembly(num))
                {
                    order.ShowDialog();
                }
                dGV.DataSource = Update(docStatus);
            }
            else
            {
                MessageBox.Show("У Вас нет прав вызова мастера выдачи сборки УСПО!");
            }

        }





        //////////////////////////////////////////////////////////////////////////
        ////ПАНЕЛЬ РАБОТЫ С ЛИСТОМ ЗАКАЗА НА ПОЛУЧЕНИЕ СБОРКИ ИЗ ЦЕХА////////////
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Функция формирования панели для отображения листов заказа для возврата;
        /// </summary>
        /// <returns></returns>
        public void LayoutGetOrder()
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();

            comboBox1 = new System.Windows.Forms.ComboBox();

            button1 = new System.Windows.Forms.Button();

            button3 = new System.Windows.Forms.Button();

            panel2 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();

            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();

            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();




            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ParentPanel.SuspendLayout();


            ParentPanel.Controls.Add(panel3);
            ParentPanel.Controls.Add(panel2);

            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dGV);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 294);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGV.Location = new System.Drawing.Point(0, 0);
            this.dGV.Name = "dataGridView1";
            this.dGV.Size = new System.Drawing.Size(548, 294);
            this.dGV.TabIndex = 0;
            this.dGV.ReadOnly = true;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.MultiSelect = false;
            this.dGV.RowHeadersVisible = false;
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            dGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick_Get_Order);
            this.dGV.MouseHover += new System.EventHandler(dGV_GetOrder); 
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(548, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 294);
            this.panel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Location = new System.Drawing.Point(17, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(171, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вывести:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "с";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(36, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.CloseUp += new EventHandler(dTP_ValueChanged_Get_Order);
            this.dateTimePicker1.MouseHover += new System.EventHandler(dateTimePicker1_GetOrder);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(36, 45);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(129, 20);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.CloseUp += new EventHandler(dTP_ValueChanged_Get_Order);
            this.dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_GetOrder);

            //установка dateTimePicker1 и dateTimePicker2

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(17, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Поиск";
            this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(SearchGetOrder_Click);
            this.button3.MouseHover += new System.EventHandler(button3_GetOrder);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(17, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(171, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Операции:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Вывести ВПП",
            "Вывести ТЗ",
            "Вывести спецификацию",
            "Отобразить в Excel",
            "Отменить выдачу заказчику",
            "Удалить"});
            this.comboBox1.Location = new System.Drawing.Point(6, 29);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(comboBox1_GetOrder);

            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();


        }

        private void dTP_ValueChanged_Get_Order(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            ShowNotGetOrder(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        //////////////////////////////////////////////////////////////////////////
        ////СОБЫТИЯ И ФУНКЦИИ ПАНЕЛИ РАБОТЫ С ЛИСТОМ ЗАКАЗА НА ПОЛУЧЕНИЕ СБОРКИ ИЗ ЦЕХА
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Метод возвращает список листов заказа, сборки которых выданы в цеха в заданном временном промежутке
        /// </summary>
        /// <param name="fromDate">Начало временного интервала</param>
        /// <param name="toDate">Конец временного интервала</param>
        public void ShowNotGetOrder(DateTime fromDate, DateTime toDate)
        {
            docStatus = 3;
            dGV.DataSource = Update(docStatus);
        }

        private void dataGridView1_CellDoubleClick_Get_Order(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if (AccessUser.AccessUser.GetRLType(1))//доступ кладовщицы
            {

                string num = dGV[0, dGV.SelectedCells[0].RowIndex].Value.ToString();

                using (UchetUSP.fGetAssembly order = new fGetAssembly(num))
                {
                    order.ShowDialog();
                }
                dGV.DataSource = Update(docStatus);
            }
            else
            {
                MessageBox.Show("У Вас нет прав вызова мастера возврата оснастки на участок УСПО!");
            }
            

        }





        //////////////////////////////////////////////////////////////////////////
        ////ПАНЕЛЬ РАБОТЫ С ИСТОРИЕЙ ПО ЛИСТАМ ЗАКАЗВОВ НА ОПРЕДЕЛЕННЫЙ ПЕРИУД ВРЕМЕНИ
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Функция формирования панели для отображения истории по  листам заказов;
        /// </summary>
        /// <returns></returns>
        public void LayoutHistoryOrder()
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();

            button3 = new Button();
            button1 = new Button();

            panel2 = new Panel();
            panel3 = new Panel();

            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            dTPAssCard = new DateTimePicker();

            label1 = new Label();
            label2 = new Label();

            comboBox1 = new ComboBox();




            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dGV)).BeginInit();
            ParentPanel.SuspendLayout();


            // 
            // panel1
            // 
            ParentPanel.Controls.Add(panel3);
            ParentPanel.Controls.Add(panel2);

            // 
            // panel2
            // 
            panel2.Controls.Add(button3);
            panel2.Controls.Add(dTPAssCard);
            panel2.Controls.Add(groupBox1);
            panel2.Controls.Add(groupBox2);
            panel2.Controls.Add(groupBox3);
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(548, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(200, 294);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(dGV);
            panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(548, 294);
            panel3.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Location = new System.Drawing.Point(17, 19);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(171, 77);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Вывести:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Location = new System.Drawing.Point(17, 99);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(171, 47);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Операции:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dTPAssCard);
            groupBox3.Controls.Add(button1);
            groupBox3.Location = new System.Drawing.Point(17, 152);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(171, 72);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "Карта учета:";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(17, 44);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(141, 24);
            button1.TabIndex = 3;
            button1.Text = "Вывести";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new EventHandler(AccountingCard_Click);
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(36, 19);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(129, 20);
            dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.CloseUp += new EventHandler(dTP_ValueChanged_History_Order);
            this.dateTimePicker1.MouseHover += new System.EventHandler(dateTimePicker1_HistoryOrder);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(13, 13);
            label1.TabIndex = 1;
            label1.Text = "с";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 49);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(19, 13);
            label2.TabIndex = 2;
            label2.Text = "по";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new System.Drawing.Point(36, 45);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(129, 20);
            dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.CloseUp += new EventHandler(dTP_ValueChanged_History_Order);
            this.dateTimePicker2.MouseHover += new System.EventHandler(dateTimePicker2_HistoryOrder);

            //установка dateTimePicker1 и dateTimePicker2

            this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

            this.dateTimePicker1.Update();

            // 
            // dTPAssCard
            // 
            dTPAssCard.Location = new System.Drawing.Point(17, 18);
            dTPAssCard.Name = "dTPAssCard";
            dTPAssCard.Size = new System.Drawing.Size(141, 23);
            dTPAssCard.TabIndex = 4;
            dTPAssCard.Format = DateTimePickerFormat.Custom;
            dTPAssCard.CustomFormat = "MMMM yyyy";
            this.dTPAssCard.MouseHover += new System.EventHandler(dTPAssCard_HistoryOrder);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Вывести ВПП",
            "Вывести ТЗ",
            "Вывести спецификацию",
            "Отобразить в Excel",
            "Отменить возвращение на склад",
            "Удалить"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(154, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.MouseHover += new System.EventHandler(comboBox1_HistoryOrder);
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(17, 238);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(171, 23);
            button3.TabIndex = 3;
            button3.Text = "Поиск";
            button3.UseVisualStyleBackColor = true;
			 button3.Click += new System.EventHandler(SearchHistoryOrder_Click);
             this.button3.MouseHover += new System.EventHandler(button3_HistoryOrder);
            // 
            // dataGridView1
            // 
            dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dGV.Dock = System.Windows.Forms.DockStyle.Fill;
            dGV.Location = new System.Drawing.Point(0, 0);
            dGV.Name = "dataGridView1";
            dGV.Size = new System.Drawing.Size(548, 294);
            dGV.TabIndex = 0;
            this.dGV.ReadOnly = true;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.MultiSelect = false;
            this.dGV.RowHeadersVisible = false;
            this.dGV.AllowUserToAddRows = false;
            this.dGV.AllowUserToDeleteRows = false;
            this.dGV.MouseHover += new System.EventHandler(dGV_HistoryOrder);



            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dGV)).EndInit();
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();


        }

        private void dTP_ValueChanged_History_Order(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            ShowHistoryOrder(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dTPAssCard_ValueChanged(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            using (UchetUSP.xlsAccountingCard ShowAccountingCard = new xlsAccountingCard(dTPAssCard.Value))
            {
                ShowAccountingCard.createDocument();
            }
        }

        //////////////////////////////////////////////////////////////////////////
        ////СОБЫТИЯ И ФУНКЦИИ ПАНЕЛИ РАБОТЫ С ИСТОРИЕЙ ПО ЛИСТАМ ЗАКАЗВОВ НА ОПРЕДЕЛЕННЫЙ ПЕРИУД ВРЕМЕНИ
        /////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Метод возвращает список листов заказов, по которым сборки возвращены на участок УСПО в заданном временном промежутке
        /// </summary>
        /// <param name="fromDate">Начало временного интервала</param>
        /// <param name="toDate">Конец временного интервала</param>
        public void ShowHistoryOrder(DateTime fromDate, DateTime toDate)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            docStatus = 4;
            dGV.DataSource = Update(docStatus);

        }

        private void dataGridView1_CellDoubleClick_History_Order(object sender, DataGridViewCellEventArgs e)
        {

        }


        DataTable Update(int status)
        {
            DataTable dt;
            switch (status)
            {
                case 1:
                    dt = AssemblyOrders.GetOrders(status, dateTimePicker1.Value, dateTimePicker2.Value, "CREATION_DATE");
                    dt.Columns[6].ColumnName = "Дата создания листа заказа";
                    break;
                case 2:
                    dt = AssemblyOrders.GetOrders(status, dateTimePicker1.Value, dateTimePicker2.Value, "ASSEMBLY_CREATION_DATE");
                    dt.Columns[6].ColumnName = "Дата создания сборки";
                    break;
                case 3:
                    dt = AssemblyOrders.GetOrders(status, dateTimePicker1.Value, dateTimePicker2.Value, "ASSEMBLY_DELIVERY_DATE");
                    dt.Columns[6].ColumnName = "Дата поставки сборки";
                    break;
                case 4:
                    dt = AssemblyOrders.GetCompletedOrders(dateTimePicker1.Value,
                                                           dateTimePicker2.Value);
                    break;
                default:
                    dt = null;
                    break;
            }
            return dt;
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dGV.Rows.Count > 0)
            {
                string cell = dGV.Rows[dGV.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if ((sender as ComboBox).Text == "Удалить")
                {//доступ кладовщицы
                    if (AccessUser.AccessUser.GetRLType(1))
                    {
                        if (MessageBox.Show("Вы действительно хотите удалить лист заказа № " + cell + " ?\nУдаленная информация не может быть восстановлена!", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString() == "Yes")
                        {
                            AssemblyOrders.deleteOrder(cell);
                            dGV.DataSource = Update(docStatus);
                            MessageBox.Show("Лист заказа успешно удален!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("У Вас нет прав на удаление Листов Заказа!");
                    }
                }
                else if ((sender as ComboBox).Text == "Отобразить в Excel")
                {
                    if (docStatus == 1)
                    {
                        Dictionary<string, string> Dict = Instrumentary.setDictOrder1(cell);
                        xlsAssemblyOrder1 Order1 = new xlsAssemblyOrder1(Dict);
                        Order1.createDocument();
                    }
                    else if (docStatus == 3)
                    {
                        Dictionary<string, string> Elements = new Dictionary<string, string>();
                        Dictionary<string, string> Dict = Instrumentary.setDictOrder2(cell, out Elements);
                        xlsAssemblyOrder2 Order2 = new xlsAssemblyOrder2(Dict, Elements);
                        Order2.createDocument();
                    }
                    else
                    {
                        Dictionary<string, string> Elements = new Dictionary<string, string>();
                        xlsAssemblyOrder Order = new xlsAssemblyOrder(cell);
                        Order.createDocument();
                    }

                }
                else if ((sender as ComboBox).Text == "Вывести ВПП")
                {
                    string VPPNum = AssemblyOrders.getVPPnumber(cell);

                    if (VPPNum != "")
                    {
                        VPP doc = new VPP(VPPNum);
                        doc.createXLS();
                    }
                }
                else if ((sender as ComboBox).Text == "Вывести ТЗ")
                {
                    string VPPNum = AssemblyOrders.getVPPnumber(cell);
                    if (VPPNum != "")
                    {
                        string TZNum = dGV.Rows[dGV.CurrentCell.RowIndex].Cells["Номер ТЗ"].Value.ToString();
                        int TZPos = _VPP_TZ.getPosition(VPPNum, TZNum);
                        Dictionary<string, string> Dict = Instrumentary.setDictTZ(VPPNum, TZPos);
                        xlsTZ tzDoc = new xlsTZ(Dict);
                        tzDoc.createDocument();
                    }
                    else
                    {
                        string cellDocId = AssemblyOrders.getTZId(cell);

                        if (cellDocId != "")
                        {
                            CreateTZ tz = new CreateTZ(1, 1, cellDocId);
                            tz.createXLS();
                        }
                    }
                }
                else if ((sender as ComboBox).Text == "Вывести спецификацию")
                {
                    string cellNum = dGV["Номер", dGV.CurrentCell.RowIndex].Value.ToString();
                    if (!AssemblyOrders.isTZ(cellNum))
                    {
                        int VPPId = AssemblyOrders.getVPPId(cellNum);
                        string equipTitle = VPP.getEquipTitle(VPPId);
                        _startKTC();
                    }
                }
                else
                {
                    //доступ кладовщицы
                    if (AccessUser.AccessUser.GetRLType(1))
                    {
                        if (MessageBox.Show("Вы действительно хотите перевести листа заказа № " + cell + " на предыдущую стадию?", "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning).ToString() == "Yes")
                        {
                            AssemblyOrders.setStatus(docStatus - 1, cell);
                            dGV.DataSource = Update(docStatus);
                            MessageBox.Show("Стадия изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("У Вас нет прав перевода Листа Заказа на предыдущую стадию!");
                    }
                }
            }
        }


        private void AccountingCard_Click(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            using (UchetUSP.xlsAccountingCard ShowAccountingCard = new xlsAccountingCard(dTPAssCard.Value))
            {
                ShowAccountingCard.createDocument();
            }
        }

        ~LayoutOrder()
        {
            Dispose(false);
        }

    }
}
