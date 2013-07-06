using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;


namespace UchetUSP.Layout
{
    partial class LayoutColdStats : IDisposable
    {
        private bool isDisposed = false;      
   
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;

        //Рабочая форма
        System.Windows.Forms.Panel ParentPanel;

        //Рабочая строка статуса
        System.Windows.Forms.ToolStripStatusLabel ParentToolStripStatusLabel;

        //Инициализация класса с получением рабочей формы
        public LayoutColdStats(System.Windows.Forms.Panel Panel,System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1)
        {
            ParentPanel = Panel;
            ParentToolStripStatusLabel = ToolStripStatusLabel1;
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
                       
                        this.dataGridView1.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
                        ParentPanel.Controls.Remove(dataGridView1);
                        dataGridView1.Dispose();
                    }
                    if (ParentPanel.Controls.Contains(dateTimePicker1))
                    {
                        dateTimePicker1.ValueChanged -= new System.EventHandler(dateTimePicker1_ValueChanged);
                        ParentPanel.Controls.Remove(dateTimePicker1);
                        dateTimePicker1.Dispose();

                    }
                    if (ParentPanel.Controls.Contains(dateTimePicker2))
                    {
                        dateTimePicker2.ValueChanged -= new System.EventHandler(dateTimePicker2_ValueChanged);
                        ParentPanel.Controls.Remove(dateTimePicker2);
                        dateTimePicker2.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(label2))
                    {
                        ParentPanel.Controls.Remove(label2);
                        label2.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(label1))
                    {
                        ParentPanel.Controls.Remove(label1);
                        label1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(groupBox1))
                    {
                        ParentPanel.Controls.Remove(groupBox1);
                        groupBox1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(panel2))
                    {
                        ParentPanel.Controls.Remove(panel2);
                        panel2.Dispose();
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


        //////////////////////////////////////////////////////////////////////////
        //Макет панели для работы со статистикой
        /////////////////////////////////////////////////////////////////////////
      
        public System.Windows.Forms.Panel setLayout()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ParentPanel.SuspendLayout();

            
             // 
             // panel2
             // 
             this.panel2.Controls.Add(this.groupBox1);
             this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
             this.panel2.Location = new System.Drawing.Point(649, 0);
             this.panel2.Name = "panel2";
             this.panel2.Size = new System.Drawing.Size(194, 329);
             this.panel2.TabIndex = 0;            
             // 
             // dataGridView1
             // 
             this.dataGridView1.AllowUserToAddRows = false;
             this.dataGridView1.AllowUserToDeleteRows = false;
             this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
             this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
             this.dataGridView1.Location = new System.Drawing.Point(0, 0);
             this.dataGridView1.Name = "dataGridView1";
             this.dataGridView1.ReadOnly = true;
             this.dataGridView1.Size = new System.Drawing.Size(649, 329);
             this.dataGridView1.TabIndex = 1;
             this.dataGridView1.ReadOnly = true;
             this.dataGridView1.RowHeadersVisible = false;
             // events
             dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
             // 
             // groupBox1
             // 
             this.groupBox1.Controls.Add(this.dateTimePicker2);
             this.groupBox1.Controls.Add(this.dateTimePicker1);
             this.groupBox1.Controls.Add(this.label2);
             this.groupBox1.Controls.Add(this.label1);
             this.groupBox1.Location = new System.Drawing.Point(6, 13);
             this.groupBox1.Name = "groupBox1";
             this.groupBox1.Size = new System.Drawing.Size(176, 87);
             this.groupBox1.TabIndex = 0;
             this.groupBox1.TabStop = false;
             this.groupBox1.Text = "Поиск";
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Location = new System.Drawing.Point(6, 20);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(13, 13);
             this.label1.TabIndex = 0;
             this.label1.Text = "с";
             // 
             // label2
             // 
             this.label2.AutoSize = true;
             this.label2.Location = new System.Drawing.Point(6, 59);
             this.label2.Name = "label2";
             this.label2.Size = new System.Drawing.Size(19, 13);
             this.label2.TabIndex = 1;
             this.label2.Text = "по";
             // 
             // dateTimePicker1
             // 
             this.dateTimePicker1.Location = new System.Drawing.Point(31, 19);
             this.dateTimePicker1.Name = "dateTimePicker1";
             this.dateTimePicker1.Size = new System.Drawing.Size(133, 20);
             this.dateTimePicker1.TabIndex = 2;
             dateTimePicker1.ValueChanged += new System.EventHandler(dateTimePicker1_ValueChanged);
             // 
             // dateTimePicker2
             // 
             this.dateTimePicker2.Location = new System.Drawing.Point(31, 55);
             this.dateTimePicker2.Name = "dateTimePicker2";
             this.dateTimePicker2.Size = new System.Drawing.Size(133, 20);
             this.dateTimePicker2.TabIndex = 3;
             dateTimePicker2.ValueChanged += new System.EventHandler(dateTimePicker2_ValueChanged);


             
            // 
            // Parent panel
            // 
             
             ParentPanel.Controls.Add(this.dataGridView1);
             ParentPanel.Controls.Add(this.panel2);
             
             this.panel2.ResumeLayout(false);
             ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
             this.groupBox1.ResumeLayout(false);
             this.groupBox1.PerformLayout();
             ParentPanel.ResumeLayout(false);
             ParentPanel.PerformLayout();

             //установка dateTimePicker1 и dateTimePicker2

             this.dateTimePicker1.Value = this.dateTimePicker2.Value.AddMonths(-1);

             this.dateTimePicker1.Update();

            
             return ParentPanel;

        }
        

       
         /// <summary>
        /// Метод заполняет таблицу элементами в промежутке времени
        /// </summary>
        /// <param name="fromDate">Начало промежутка</param>
        /// <param name="toDate">Конец промежутка</param>
        public void fillDGV(DateTime fromDate, DateTime toDate)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            DataTable DT = _ELEMENTS.getColdStats(fromDate, toDate);

            DT.Columns[0].ColumnName = "Обозначение элемента";
            DT.Columns[1].ColumnName = "Количество сборок с элементом";
            DT.Columns[2].ColumnName = "Количество времени элемента в цеху (час)";
            dataGridView1.DataSource = DT;

            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 224;
        }

        //-------------------------------------------------------------------------

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            fillDGV(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            fillDGV(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            int rowIndex = (sender as DataGridView).CurrentCell.RowIndex;
            string cell = (sender as DataGridView).Rows[rowIndex].Cells[0].Value.ToString();
            if ((cell != ""))
            {
                using (MoreStatsForm form = new MoreStatsForm(cell, false))
                {
                    form.ShowDialog();
                }
            }
        }


        ~LayoutColdStats()
        {
            Dispose(false);
        }

       }
}
