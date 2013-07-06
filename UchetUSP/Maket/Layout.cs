using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.ComponentModel;
using UchetUSP.WinForms;
using UchetUSP.Algorithm;


namespace UchetUSP.Layout
{
    partial class Layout : IDisposable
    {

        private bool isDisposed = false;
      
        private System.Windows.Forms.DataGridView dataGridView1;
        System.Windows.Forms.Button button1;
        System.Windows.Forms.Button button2;
        System.Windows.Forms.Button button3;
        System.Windows.Forms.Button button4;
        System.Windows.Forms.Button button5;

        //форма "Информация по элементам УСП"
              
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        

        //Рабочая форма
        System.Windows.Forms.Panel ParentPanel;

        //Рабочая строка статуса
        System.Windows.Forms.ToolStripStatusLabel ParentToolStripStatusLabel;

        //Инициализация класса с получением рабочей формы
        public Layout(System.Windows.Forms.Panel Panel,System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1)
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
                        dataGridView1.MouseHover -= new System.EventHandler(dataGridView1_MouseHover);
                        dataGridView1.MouseDown -= new System.Windows.Forms.MouseEventHandler(DataGridView_MouseDown);
                        dataGridView1.KeyUp -= new System.Windows.Forms.KeyEventHandler(dataGridView1_KeyUp);
                        dataGridView1.EditingControlShowing -= new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
                        dataGridView1.CellDoubleClick -= new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
                        ParentPanel.Controls.Remove(dataGridView1);
                        dataGridView1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button1))
                    {
                        button1.MouseHover -= new System.EventHandler(button1_MouseHover_Delete);
                        button1.MouseHover -= new System.EventHandler(button1_MouseHover_LoadNX);
                        button1.MouseHover -= new System.EventHandler(button1_MouseHover_Edit);
                        button1.Click -= new System.EventHandler(EditInformation);
                        button1.Click -= new System.EventHandler(DeleteElement);
                        ParentPanel.Controls.Remove(button1);
                        button1.Dispose();

                    }
                    if (ParentPanel.Controls.Contains(button2))
                    {
                        button2.MouseHover -= new System.EventHandler(button2_MouseHover);
                        button2.Click -= new System.EventHandler(
                            SearchData_Click);
                        ParentPanel.Controls.Remove(button2);
                        button2.Dispose();

                    }
                    if (ParentPanel.Controls.Contains(button3))
                    {
                        
                        ParentPanel.Controls.Remove(button3);
                        button3.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button4))
                    {
                        
                        ParentPanel.Controls.Remove(button4);
                        button4.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(button5))
                    {                        
                        ParentPanel.Controls.Remove(button5);
                        button5.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(panel1))
                    {

                        ParentPanel.Controls.Remove(panel1);
                        panel1.Dispose();
                    }

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

                    if (ParentPanel.Controls.Contains(splitter1))
                    {

                        ParentPanel.Controls.Remove(splitter1);
                        splitter1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(splitter2))
                    {

                        ParentPanel.Controls.Remove(splitter2);
                        splitter2.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(pictureBox1))
                    {
                        pictureBox1.MouseHover += new System.EventHandler(pictureBox1_MouseHover);
                        ParentPanel.Controls.Remove(pictureBox1);
                        pictureBox1.Dispose();
                    }

                    if (ParentPanel.Controls.Contains(treeView1))
                    {
                        treeView1.MouseHover -= new System.EventHandler(treeView1_MouseHover);
                        treeView1.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(TreeView_Click);
                        ParentPanel.Controls.Remove(treeView1);
                        treeView1.Dispose();
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
        //Макет панели для работы c общей информацией по элементам УСП
        /////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Функция формирования панели для отображения/редактирования/удаления информации о элементах УСП;
        /// </summary>
        /// <param name="StatusOfInformPanel">
        /// 1- Отобразить информацию.
             ///2- Редактировать информацию.
             ///3- Сократить количество элементов.</param>
        /// <returns></returns>
        public System.Windows.Forms.Panel LayoutElemUSP(int StatusOfInformPanel)
        {


            /*
             * 1- Отобразить информацию.
             * 2- Редактировать информацию.
             * 3- Сократить количество элементов.
             * */

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            
             panel1 = new System.Windows.Forms.Panel();
             panel2 = new System.Windows.Forms.Panel();
             panel3 = new System.Windows.Forms.Panel();
             splitter1 = new System.Windows.Forms.Splitter();
             splitter2 = new System.Windows.Forms.Splitter();
             button1 = new System.Windows.Forms.Button();
             pictureBox1 = new System.Windows.Forms.PictureBox();
             button2 = new System.Windows.Forms.Button();
             treeView1 = new System.Windows.Forms.TreeView();
             dataGridView1 = new System.Windows.Forms.DataGridView();
             panel1.SuspendLayout();
             panel2.SuspendLayout();
             panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)( pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)( dataGridView1)).BeginInit();
             ParentPanel.SuspendLayout();
                        
          
            // 
            // panel1
            // 
             panel1.Controls.Add( dataGridView1);
             panel1.Controls.Add( splitter1);
             panel1.Controls.Add( panel2);
             panel1.Dock = System.Windows.Forms.DockStyle.Fill;
             panel1.Location = new System.Drawing.Point(0, 24);
             panel1.Name = "panel1";
             panel1.Size = new System.Drawing.Size(651, 293);
             panel1.TabIndex = 3;
            // 
            // panel2
            // 
             panel2.Controls.Add( treeView1);
             panel2.Controls.Add( button2);
             panel2.Controls.Add( splitter2);
             panel2.Controls.Add( panel3);
             panel2.Dock = System.Windows.Forms.DockStyle.Left;
             panel2.Location = new System.Drawing.Point(0, 0);
             panel2.Name = "panel2";
             panel2.Size = new System.Drawing.Size(147, 293);
             panel2.TabIndex = 0;
            // 
            // panel3
            // 
             
             panel3.Controls.Add( pictureBox1);
             panel3.Controls.Add( button1);
             panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
             panel3.Location = new System.Drawing.Point(0, 184);
             panel3.Name = "panel3";
             panel3.Size = new System.Drawing.Size(147, 109);
             panel3.TabIndex = 0;
             
            // 
            // splitter1
            // 
             splitter1.Location = new System.Drawing.Point(147, 0);
             splitter1.Name = "splitter1";
             splitter1.Size = new System.Drawing.Size(3, 293);
             splitter1.TabIndex = 1;
             splitter1.TabStop = false;
            // 
            // splitter2
            // 
             splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
             splitter2.Location = new System.Drawing.Point(0, 181);
             splitter2.Name = "splitter2";
             splitter2.Size = new System.Drawing.Size(147, 3);
             splitter2.TabIndex = 1;
             splitter2.TabStop = false;
            // 
            // button1
            // 
             if (StatusOfInformPanel == 1)
             {
                 button1.Dock = System.Windows.Forms.DockStyle.Bottom;
                 button1.Location = new System.Drawing.Point(0, 84);
                 button1.Name = "button1";
                 button1.Size = new System.Drawing.Size(147, 25);
                 button1.TabIndex = 0;
                 button1.Text = "Запустить в NX";
                 button1.UseVisualStyleBackColor = true;
                 button1.Click += new System.EventHandler(LoadToNX_Click);
                 button1.MouseHover += new System.EventHandler(button1_MouseHover_LoadNX);

             }
             else if (StatusOfInformPanel == 2)
             {

                 button1.Dock = System.Windows.Forms.DockStyle.Bottom;
                 button1.Location = new System.Drawing.Point(0, 84);
                 button1.Name = "button1";
                 button1.Size = new System.Drawing.Size(147, 25);
                 button1.TabIndex = 0;
                 button1.Text = "Редактировать";
                 button1.UseVisualStyleBackColor = true;
                 button1.Click += new System.EventHandler(EditInformation);
                 button1.MouseHover += new System.EventHandler(button1_MouseHover_Edit);

             }
             else if (StatusOfInformPanel == 3)
             {
                 button1.Dock = System.Windows.Forms.DockStyle.Bottom;
                 button1.Location = new System.Drawing.Point(0, 84);
                 button1.Name = "button1";
                 button1.Size = new System.Drawing.Size(147, 25);
                 button1.TabIndex = 0;
                 button1.Text = "Уменьшить количество элементов";
                 button1.UseVisualStyleBackColor = true;
                 button1.Click += new System.EventHandler(DeleteElement);
                 button1.MouseHover += new System.EventHandler(button1_MouseHover_Delete);

             }


            // 
            // pictureBox1
            // 

             pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
             pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;             
             pictureBox1.Location = new System.Drawing.Point(0, 0);
             pictureBox1.Name = "pictureBox1";
             pictureBox1.Size = new System.Drawing.Size(147, 84);
             pictureBox1.TabIndex = 1;
             pictureBox1.TabStop = false;
             pictureBox1.MouseHover += new System.EventHandler(pictureBox1_MouseHover);
           
             
            // 
            // button2
            // 
             button2.Dock = System.Windows.Forms.DockStyle.Bottom;
             button2.Location = new System.Drawing.Point(0, 158);
             button2.Name = "button2";
             button2.Size = new System.Drawing.Size(147, 23);
             button2.TabIndex = 2;
             button2.Text = "Поиск";
             button2.UseVisualStyleBackColor = true;
             button2.Click += new System.EventHandler(SearchData_Click);
             button2.MouseHover += new System.EventHandler(button2_MouseHover);
            // 
            // treeView1
            // 
             treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
             treeView1.Location = new System.Drawing.Point(0, 0);
             treeView1.Name = "treeView1";
             treeView1.Size = new System.Drawing.Size(147, 158);
             treeView1.TabIndex = 3;
             treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TreeView_Click);
             treeView1.MouseHover += new System.EventHandler(treeView1_MouseHover);
            // 
            // dataGridView1
            // 
             dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
             dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
             dataGridView1.Location = new System.Drawing.Point(150, 0);
             dataGridView1.Name = "dataGridView1";
             dataGridView1.Size = new System.Drawing.Size(501, 293);
             dataGridView1.TabIndex = 2;
            //dataGridView1.ReadOnly = true;
             dataGridView1.AllowUserToAddRows = false;
             dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(DataGridView_MouseDown);
             dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(dataGridView1_KeyUp);
             dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
             dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
             dataGridView1.MouseHover += new System.EventHandler(dataGridView1_MouseHover);
            // 
            // Parent panel
            // 
             
             ParentPanel.Controls.Add( panel1);
             //ParentPanel.Controls.Add(statusStrip1);
             //ParentPanel.Controls.Add(menuStrip1);
             panel1.ResumeLayout(false);
             panel2.ResumeLayout(false);
             panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)( pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)( dataGridView1)).EndInit();
             ParentPanel.ResumeLayout(false);
             ParentPanel.PerformLayout();

            
     
            
             return ParentPanel;




        }
        

       
        //щелчек по элементам дерева

        private void TreeView_Click(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            //передаем информацию о выделенном дереве на обработку в алгоритмы

            ElmInform.sortInformWithTree(e,dataGridView1);    
            
        }
        // клик на datagrid

        private void DataGridView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            ElmInform.loadPictureInPictureBox(e,ParentPanel);
        }

        // нажатие стрелки вверх на datagrid

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            if(e.KeyCode == Keys.Down)
            {
                ElmInform.loadPictureInPictureBoxWithKeyEvent(dataGridView1.SelectedCells[0].RowIndex, ParentPanel);
                
            }

            if (e.KeyCode == Keys.Up)
            {
                ElmInform.loadPictureInPictureBoxWithKeyEvent(dataGridView1.SelectedCells[0].RowIndex, ParentPanel);
     
            }
        }

        //Загрзука моделей в NX 
        private void LoadToNX_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }
            if (SQLOracle.exist((object)dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString(), "HD", "MODEL_ATTR"))
            {                
                ElmInform.loadPartToNX(dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
            }
            else if (SQLOracle.exist((object)dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString(), "HD", "MODEL_ATTR20"))
            {                
                ElmInform.loadPartToNXSpecDet(dataGridView1[1, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());
            }
            
        }

        //Поиск данных
        private void SearchData_Click(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            using (WinForms.ElementInform.search newSearchInBD = new WinForms.ElementInform.search(dataGridView1))
            {
                newSearchInBD.ShowDialog();
                newSearchInBD.Dispose();
            }
            

            

           
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

           ((TextBox)e.Control).ReadOnly = true; 
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            Algorithm.ElmInform.DisplayInformationAboutElement(dataGridView1, e.RowIndex);

        }




        private void EditInformation(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }

            using (WinForms.AddInformationAboutElements.AddInformation AddForm = new UchetUSP.WinForms.AddInformationAboutElements.AddInformation(2,dataGridView1))
            {
                AddForm.ShowDialog();                
            }            
           
        }

        private void DeleteElement(object sender, EventArgs e)
        {

            if (isDisposed)
            {
                throw new ObjectDisposedException("Layout");
            }


            Algorithm.ElmInform.DeleteElementFromDB(dataGridView1);
         
           
        }


        
       
        ~Layout()
        {
            Dispose(false);
        }

       }
}
