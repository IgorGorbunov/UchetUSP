using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using UchetUSP.WinForms;
using UchetUSP.Algorithm;



namespace UchetUSP.Layout
{
    public partial class LayoutOrderTZ : IDisposable
    {

        private bool isDisposed = false;

        //форма ТЗ
        private System.Windows.Forms.DataGridView dataGridView1;
        System.Windows.Forms.Button button1;
        

        
        System.Windows.Forms.Button button4;
        System.Windows.Forms.Button button5;
        System.Windows.Forms.Button button6;
        System.Windows.Forms.Panel panel2;
        System.Windows.Forms.GroupBox groupBox1;
        System.Windows.Forms.GroupBox groupBox2;        
        System.Windows.Forms.Label label1;
        System.Windows.Forms.Label label2;   
        System.Windows.Forms.DateTimePicker dateTimePicker1;
        System.Windows.Forms.DateTimePicker dateTimePicker2;
        System.Windows.Forms.ComboBox comboBox1;
        System.Windows.Forms.ComboBox comboBox2;
        System.Windows.Forms.ComboBox comboBox3;

        //Рабочая форма
        System.Windows.Forms.Panel ParentPanel;

        //Рабочая строка статуса
        System.Windows.Forms.ToolStripStatusLabel ParentToolStripStatusLabel;

        //Инициализация класса с получением рабочей формы
        public LayoutOrderTZ(System.Windows.Forms.Panel Panel,System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1)
        {
            ParentPanel = Panel;
            ParentToolStripStatusLabel = ToolStripStatusLabel1;
        }

        //////////////////////////////////////////////////////////////////////////
        ////Макет панели для работы с техническим заданием
        /////////////////////////////////////////////////////////////////////////
        
         public void LayoutTZ()
          {

              if (isDisposed)
              {
                  throw new ObjectDisposedException("Layout");
              }
              dataGridView1 = new System.Windows.Forms.DataGridView();
              button1 = new System.Windows.Forms.Button();
              button4 = new System.Windows.Forms.Button();
              button5 = new System.Windows.Forms.Button();
              button6 = new System.Windows.Forms.Button();
              panel2 = new System.Windows.Forms.Panel();
              groupBox1 = new System.Windows.Forms.GroupBox();
              groupBox2 = new System.Windows.Forms.GroupBox();
              label1 = new System.Windows.Forms.Label();
              label2 = new System.Windows.Forms.Label();            
              dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
              dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
              comboBox1 = new System.Windows.Forms.ComboBox();
              comboBox2 = new System.Windows.Forms.ComboBox();
              comboBox3 = new System.Windows.Forms.ComboBox();

            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ParentPanel.SuspendLayout();

            // 
            // panel2
            // 
            panel2.Controls.Add(this.groupBox1);
            panel2.Controls.Add(this.button6);
            panel2.Controls.Add(this.button5);
            panel2.Controls.Add(this.button4);               
            panel2.Controls.Add(this.button1);
            panel2.Controls.Add(this.groupBox2);  
            panel2.Dock = System.Windows.Forms.DockStyle.Right;
            panel2.Location = new System.Drawing.Point(548, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(200, 294);
            panel2.TabIndex = 1;


            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(6, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(187, 24);
            button1.TabIndex = 0;
            button1.Text = "Просмотреть ТЗ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(ViewTZ_Click);
            button1.MouseHover += new System.EventHandler(buttonView_MouseHover);           
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(6, 35);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(187, 24);
            button4.TabIndex = 3;
            button4.Text = "Редактировать ТЗ";
            button4.UseVisualStyleBackColor = true;
            button4.Click += new System.EventHandler(EditTZ_Click);
            button4.MouseHover += new System.EventHandler(buttonEdit_MouseHover);
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(6, 66);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(187, 24);
            button5.TabIndex = 4;
            button5.Text = "Поиск ТЗ";
            button5.UseVisualStyleBackColor = true;
            button5.Click += new System.EventHandler(SearchTZ_Click);
            button5.MouseHover += new System.EventHandler(buttonFind_MouseHover);

            // 
            // butto6
            // 
            button6.Location = new System.Drawing.Point(6, 95);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(187, 24);
            button6.TabIndex = 5;
            button6.Text = "Обновить";
            button6.UseVisualStyleBackColor = true;
            button6.Click += new System.EventHandler(UpdateTZ_Click);
            button6.MouseHover += new System.EventHandler(Update_MouseHover);
            // 
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(6, 119);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(178, 82);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Дата:";

            // 
            // 
            // groupBox2
            //             
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Controls.Add(comboBox2);
            groupBox2.Controls.Add(comboBox3);       
            groupBox2.Location = new System.Drawing.Point(6, 205);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(178, 109);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Параметры:";
                        
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] {
            "Разработка",
            "Подписано"});
            comboBox1.Location = new System.Drawing.Point(6, 19);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new System.Drawing.Size(166, 21);
            comboBox1.TabIndex = 1;
            comboBox1.MouseHover += new System.EventHandler(comboBox1_MouseHover);
            comboBox1.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] {
            "ТЗ оформлено",
            "ТЗ не оформлено"});
            comboBox2.Location = new System.Drawing.Point(6, 47);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new System.Drawing.Size(166, 21);
            comboBox2.TabIndex = 2;
            comboBox2.MouseHover += new System.EventHandler(comboBox2_MouseHover);
            comboBox2.SelectedIndexChanged += new System.EventHandler(comboBox_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] {
            "Проработка",
            "Утвержденные",
            "Архив"});
            comboBox3.Location = new System.Drawing.Point(6, 73);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new System.Drawing.Size(166, 21);
            comboBox3.TabIndex = 3;
            comboBox3.MouseHover += new System.EventHandler(comboBox3_MouseHover);
            comboBox3.SelectedIndexChanged += new System.EventHandler(comboBox3_SelectedIndexChanged);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 23);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(13, 13);
            label1.TabIndex = 0;
            label1.Text = "с";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 51);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(19, 13);
            label2.TabIndex = 1;
            label2.Text = "по";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(34, 19);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Leave += new System.EventHandler(dateTimePicker1_Leave);
            dateTimePicker1.MouseHover += new System.EventHandler(BeginTime_MouseHover);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new System.Drawing.Point(34, 47);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(138, 20);
            dateTimePicker2.TabIndex = 3;
            dateTimePicker2.Leave += new System.EventHandler(dateTimePicker2_Leave);
            dateTimePicker2.MouseHover += new System.EventHandler(EndTime_MouseHover);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new System.Drawing.Size(548, 294);
            dataGridView1.TabIndex = 2;
            dataGridView1.MouseHover += new System.EventHandler(dataGridView1_MouseHover);
            dataGridView1.DoubleClick += new System.EventHandler(ViewTZ_Click);

             //
            //Изменение размера
             //
            ParentPanel.Controls.Add(dataGridView1);
            ParentPanel.Controls.Add(panel2);
           

            
            panel2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ParentPanel.ResumeLayout(false);
            ParentPanel.PerformLayout();
            

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
                    if (ParentPanel.Controls.Contains(dataGridView1))
                    {
                        this.dataGridView1.DoubleClick -= new System.EventHandler(ViewTZ_Click);
                        dateTimePicker1.MouseHover -= new System.EventHandler(dataGridView1_MouseHover);
                        ParentPanel.Controls.Remove(dataGridView1);
                        dataGridView1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button1))
                    {
                        button1.Click -= new System.EventHandler(ViewTZ_Click);
                        button1.MouseHover -= new System.EventHandler(buttonView_MouseHover);
                        ParentPanel.Controls.Remove(button1);
                        button1.Dispose();

                    }
                    
                    if (ParentPanel.Controls.Contains(button4))
                    {
                        button4.Click -= new System.EventHandler(EditTZ_Click);
                        button4.MouseHover -= new System.EventHandler(buttonEdit_MouseHover);
                        ParentPanel.Controls.Remove(button4);
                        button4.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button5))
                    {
                        button5.Click -= new System.EventHandler(SearchTZ_Click);
                        button5.MouseHover -= new System.EventHandler(buttonFind_MouseHover);
                        ParentPanel.Controls.Remove(button5);
                        button5.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button6))
                    {
                        button6.Click -= new System.EventHandler(UpdateTZ_Click);
                        button6.MouseHover -= new System.EventHandler(Update_MouseHover);
                        ParentPanel.Controls.Remove(button6);
                        button6.Dispose();
                    }

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

                    if (ParentPanel.Controls.Contains(comboBox1))
                    {
                        comboBox1.SelectedIndexChanged -= new System.EventHandler(comboBox_SelectedIndexChanged);
                        comboBox1.MouseHover -= new System.EventHandler(comboBox1_MouseHover);
                        ParentPanel.Controls.Remove(comboBox1);
                        comboBox1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(comboBox2))
                    {
                        comboBox2.SelectedIndexChanged -= new System.EventHandler(comboBox_SelectedIndexChanged);
                        comboBox2.MouseHover -= new System.EventHandler(comboBox2_MouseHover);
                        ParentPanel.Controls.Remove(comboBox2);
                        comboBox2.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(comboBox3))
                    {
                        comboBox3.SelectedIndexChanged -= new System.EventHandler(comboBox3_SelectedIndexChanged);
                        comboBox3.MouseHover -= new System.EventHandler(comboBox3_MouseHover);
                        ParentPanel.Controls.Remove(comboBox3);
                        comboBox3.Dispose();
                    }
                    if (ParentPanel.Controls.Contains(panel2))
                    {
                        ParentPanel.Controls.Remove(panel2);
                        panel2.Dispose();
                    }

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
                    

                    if (ParentPanel.Controls.Contains(dateTimePicker1))
                    {
                        dateTimePicker1.Leave -= new System.EventHandler(dateTimePicker1_Leave);
                        dateTimePicker1.MouseHover -= new System.EventHandler(BeginTime_MouseHover);
                        ParentPanel.Controls.Remove(dateTimePicker1);
                        dateTimePicker1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(dateTimePicker2))
                    {
                        dateTimePicker2.Leave -= new System.EventHandler(dateTimePicker2_Leave);
                        dateTimePicker2.MouseHover -= new System.EventHandler(EndTime_MouseHover);
                        ParentPanel.Controls.Remove(dateTimePicker2);
                        dateTimePicker2.Dispose();
                    }

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


        ~LayoutOrderTZ()
        {
            Dispose(false);
        }

       }
}
