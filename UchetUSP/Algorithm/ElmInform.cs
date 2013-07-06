using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace UchetUSP.Algorithm
{
    class ElmInform
    {
        //вывод данных в DataGridView 

        public static void ViewInform(System.Windows.Forms.Panel WorkPanel)
        {
            System.Windows.Forms.DataGridView dgv = ((System.Windows.Forms.DataGridView)WorkPanel.Controls.Find("dataGridView1", true)[0]);
            
              if (dgv.Name == "dataGridView1") 
            {
                if (isCounElemZero())
                {
                    dgv.DataSource = SQLOracle.getDS("SELECT NAME, OBOZN, GOST, L, B, B1, H, D, D1, D_SM_DB, D1_SM_DB, A, S, B_SM_DB, H" +
                      "0, H_SM_DB, T, N, MASSA, NALICHI, TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = 0 AND NALICHI <> 0").Tables[0];

                }
                else {

                    dgv.DataSource = SQLOracle.getDS("SELECT NAME, OBOZN, GOST, L, B, B1, H, D, D1, D_SM_DB, D1_SM_DB, A, S, B_SM_DB, H" +
                         "0, H_SM_DB, T, N, MASSA, NALICHI, TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = 0").Tables[0];
                                    
                }
                    
                   renameDGVColumns(dgv);
                  hideUnusefulColumn(dgv);
                  
                  dgv.Refresh();       
                
            }

            CreateTreeView(WorkPanel);  
            
        }

        private static bool isCounElemZero()
        {

            if (SQLOracle.existParamQuery("CS_ELEM", "USP_USER_SETTING", "CS_ELEM = '1' AND USR ", "USR", SQLOracle.GetCurrentUser()))
            {                
                return true;
            }
            else {                
                return false;
            }

        }

        public static void CreateTreeView(System.Windows.Forms.Panel WorkPanel)
        {

            System.Windows.Forms.TreeView tv = ((System.Windows.Forms.TreeView)WorkPanel.Controls.Find("treeView1", true)[0]);

            if (tv.Name == "treeView1")
            {

                tv.BeginUpdate(); 

                tv.Nodes.Clear();

                tv.Nodes.Add("УСП-8");

                CreateSecondNode(0,tv);

                tv.Nodes.Add("УСП-12");

                CreateSecondNode(1,tv);

                tv.Nodes.Add("Спец. детали");

                CreateSecondNode(2,tv);

                CreateThirdNode(tv);

                tv.EndUpdate();                
            }           
        
        }

        public static void CreateSecondNode(int nodePosition,System.Windows.Forms.TreeView tv)
        {

            tv.Nodes[nodePosition].Nodes.Add("Базовые детали");

            tv.Nodes[nodePosition].Nodes.Add("Корпусные детали");

            tv.Nodes[nodePosition].Nodes.Add("Установочные детали");

            tv.Nodes[nodePosition].Nodes.Add("Направляющие детали");

            tv.Nodes[nodePosition].Nodes.Add("Прижимные детали");

            tv.Nodes[nodePosition].Nodes.Add("Крепежные детали");

            tv.Nodes[nodePosition].Nodes.Add("Разные детали");

            tv.Nodes[nodePosition].Nodes.Add("Сборочные еденицы");

        }


        public static void CreateThirdNode(System.Windows.Forms.TreeView tv)
        {         
            System.Data.DataTable dtTree;
           
            dtTree = SQLOracle.getDS("SELECT DISTINCT NAME, GROUP_USP, KATALOG_USP FROM DB_DATA").Tables[0];

            for (int position = 0; position < dtTree.Rows.Count; position++)
            {
             
                tv.Nodes[Convert.ToInt32(dtTree.Rows[position][2].ToString())].Nodes[Convert.ToInt32(dtTree.Rows[position][1].ToString())].Nodes.Add(dtTree.Rows[position][0].ToString());
                                            
            }

            dtTree.Dispose();        
        }

        public static void hideUnusefulColumn(System.Windows.Forms.DataGridView dgv)
        {
            dgv.Columns["TT"].Visible = false;
            dgv.Columns["YT"].Visible = false;
            dgv.Columns["PR"].Visible = false;
            dgv.Columns["RZ"].Visible = false;
            dgv.Columns["GROUP_USP"].Visible = false;
            dgv.Columns["KATALOG_USP"].Visible = false;
            
        }

        public static void sortInformWithTree(System.Windows.Forms.TreeViewEventArgs e,System.Windows.Forms.DataGridView dgv)
        {

            if (((e.Node.Parent) != null) && e.Node.Parent.GetType() == typeof(System.Windows.Forms.TreeNode))
            {
                if (((e.Node.Parent.Parent) != null) && e.Node.Parent.Parent.GetType() == typeof(System.Windows.Forms.TreeNode))
                {
                    if (isCounElemZero())
                    {
                        dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                    " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                    " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                    " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE NAME = '" + e.Node.Text.ToString() + "' AND KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' AND NALICHI <> 0").Tables[0];
                    }
                    else
                    {
                        dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                        " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                        " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                        " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE NAME = '" + e.Node.Text.ToString() + "' AND KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' ").Tables[0];
                
                    }

                    hideEmptyColumn(dgv);
                }
                else
                {
                    if (isCounElemZero())
                    {
                        dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                    " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                    " A,  S, B_SM_DB ,  H0,  T,  N, H_SM_DB,MASSA" +
                                    " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Index) + "' AND NALICHI <> 0").Tables[0];
                    }
                    else {
                        dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                        " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                        " A,  S, B_SM_DB ,  H0,  T,  N, H_SM_DB,MASSA" +
                                        " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Parent.Index) + "' AND GROUP_USP = '" + Convert.ToString(e.Node.Index) + "'").Tables[0];
                    
                    }

                    hideEmptyColumn(dgv);
                }
            }
            else
            {
                if (isCounElemZero())
                {
                    dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                    " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                    " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                    " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM  DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Index) + "' AND NALICHI <> 0").Tables[0];
                }
                else
                {
                    dgv.DataSource = SQLOracle.getDS("SELECT NAME , OBOZN , GOST,  L, " +
                                       " B,  B1, H,  D, D1, D_SM_DB , D1_SM_DB, " +
                                       " A,  S, B_SM_DB ,  H0,  T,  N,H_SM_DB, MASSA" +
                                       " , NALICHI , TT, YT, PR, RZ, GROUP_USP, KATALOG_USP, UG FROM  DB_DATA WHERE KATALOG_USP = '" + Convert.ToString(e.Node.Index) + "' ").Tables[0];
               
                }
                hideEmptyColumn(dgv);
            }
            
        }

        public static void hideEmptyColumn(System.Windows.Forms.DataGridView dgv)
        {
            bool columnIsEmpty = true;

            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = true;
            }

            hideUnusefulColumn(dgv);

            for(int i=0;i<dgv.ColumnCount;i++)
            {
                for (int j = 0; j < dgv.RowCount; j++)
                {
                    columnIsEmpty = true;

                    if (String.Compare(dgv.Rows[j].Cells[i].Value.ToString(), "0")!=0)
                    {
                        columnIsEmpty = false;
                        break;

                    }

                }

                if (columnIsEmpty == true)
                {
                    dgv.Columns[i].Visible = false;
                }
            }

            //исправляет баг скртия столбца наличия элементов
            dgv.Columns["NALICHI"].Visible = true;
                

        }


        static private System.Windows.Forms.DataGridView.HitTestInfo hitTest;

        static public void loadPictureInPictureBox(System.Windows.Forms.MouseEventArgs e, System.Windows.Forms.Panel WorkPanel)
        {
            System.Windows.Forms.DataGridView dgv = ((System.Windows.Forms.DataGridView)WorkPanel.Controls.Find("dataGridView1", true)[0]);

            if (dgv.Name == "dataGridView1")
            {
                

                     hitTest = dgv.HitTest(e.X, e.Y);

                     if (hitTest.RowIndex >= 0)
                     { 
                             System.Windows.Forms.PictureBox pictureBox1 = ((System.Windows.Forms.PictureBox)WorkPanel.Controls.Find("pictureBox1", true)[0]);

                            object pic = SQLOracle.getBlobImageWithBuffer("SELECT DET FROM DB_DATA WHERE NAME = :NAME AND GOST = :GOST AND OBOZN = :OBOZN ", dgv[0, hitTest.RowIndex].Value.ToString(), dgv[2, hitTest.RowIndex].Value.ToString(), dgv[1, hitTest.RowIndex].Value.ToString());
                            if (pic != null)
                            {
                                pictureBox1.Image = (Image)pic;
                                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                            }
                                else
	                        {
                                pictureBox1.Image = UchetUSP.Properties.Resources.delete_16x16;
                                pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
	                        }
                       
                         
                     }
        
                             
            }
        }

        static public void loadPictureInPictureBoxWithKeyEvent(int RowIndex, System.Windows.Forms.Panel WorkPanel)
        {
            System.Windows.Forms.DataGridView dgv = ((System.Windows.Forms.DataGridView)WorkPanel.Controls.Find("dataGridView1", true)[0]);

            if (dgv.Name == "dataGridView1")
            {
                    System.Windows.Forms.PictureBox pictureBox1 = ((System.Windows.Forms.PictureBox)WorkPanel.Controls.Find("pictureBox1", true)[0]);

                    
                    pictureBox1.Image.Dispose();

                    object pic = SQLOracle.getBlobImageWithBuffer("SELECT DET FROM DB_DATA WHERE NAME = :NAME AND GOST = :GOST AND OBOZN = :OBOZN ", dgv[0, RowIndex].Value.ToString(), dgv[2, RowIndex].Value.ToString(), dgv[1, RowIndex].Value.ToString());
                    if (pic != null)
                    {
                        pictureBox1.Image = (Image)pic;
                        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    }
                    else
	                {                       
                        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                        pictureBox1.Image = UchetUSP.Properties.Resources.delete_16x16;
	                }
                        
                
            }
        }

        static public void loadPartToNX(string oboznachenie)
        {
            string curname;

            string openPart = SQLOracle.UnloadPartToTEMPFolder(oboznachenie);

            System.Collections.Generic.List<string> childComponents = SQLOracle.GetInformationListWithParamQuery("NMF", "MODEL_STRUCT21", "PARENT", (oboznachenie  + ".prt"));

            for (int i = 0; i < childComponents.Count; i++)
            {
                curname = System.IO.Path.GetFileNameWithoutExtension(childComponents[i]);
                SQLOracle.UnloadPartToTEMPFolder(curname);
            }

                if (String.Compare(openPart, "0") != 0)
                {
                    System.Diagnostics.Process initPart = System.Diagnostics.Process.Start(openPart);
                    initPart.Dispose();
                }


        }


        static public void loadPartToNXSpecDet(string oboznachenie)
        {

            string NMF = SQLOracle.ParamQuerySelect("SELECT NMF FROM KTC.MODEL_ATTR20 WHERE HD = :HD", "HD", oboznachenie);

            string openPart = SQLOracle.UnloadOsnasToTEMPFolderFile20(NMF.Trim());


            if (String.Compare(openPart, "0") != 0)
            {
                System.Diagnostics.Process initPart = System.Diagnostics.Process.Start(openPart);
                initPart.Dispose();
            }

        }

        



        static public void renameDGVColumns(System.Windows.Forms.DataGridView dgv)
        {
            dgv.Columns[0].HeaderText = "Наименование";
            dgv.Columns[1].HeaderText = "Обозначение";
            dgv.Columns[2].HeaderText = "ГОСТ";
            dgv.Columns[9].HeaderText = "d";
            dgv.Columns[10].HeaderText = "d1";
            dgv.Columns[11].HeaderText = "альфа";
            dgv.Columns[13].HeaderText = "b";
            dgv.Columns[15].HeaderText = "h";
            dgv.Columns[16].HeaderText = "t";
            dgv.Columns[18].HeaderText = "Масса";
            dgv.Columns[19].HeaderText = "Наличие";
            dgv.Columns[26].HeaderText = "Месторасположение";
        }

        static public void DisplayInformationAboutElement(System.Windows.Forms.DataGridView dgv, int i)
        {

            using (WinForms.ElementInform.InformAboutElement DispInform = new UchetUSP.WinForms.ElementInform.InformAboutElement())
            {


                for (int j = 0; j < 19; j++)
                {
                    if (String.Compare(dgv[j, i].Value.ToString(), "0") != 0)
                        DispInform.AddRowToDataGrid(dgv.Columns[dgv[j, i].ColumnIndex].HeaderText, dgv[j, i].Value.ToString());                
                }
               
                DispInform.AddRowToDataGrid("Технические требования", dgv[20, i].Value.ToString());
                DispInform.AddRowToDataGrid("Утвердил", dgv[21, i].Value.ToString());
                DispInform.AddRowToDataGrid("Проверил", dgv[22, i].Value.ToString());
                DispInform.AddRowToDataGrid("Разработал", dgv[23, i].Value.ToString());
                DispInform.AddRowToDataGrid("Месторасположение", dgv[26, i].Value.ToString()); 
                    
                DispInform.ShowDialog();


            }
        }

        static private void AddRow(System.Data.DataTable DisplayedTable, String TheFirstColumn, string TheSecondColumn)
        {

            System.Data.DataRow NewRow;

            NewRow = DisplayedTable.NewRow();

            NewRow["Параметр"] = TheFirstColumn;
            NewRow["Значение"] = TheSecondColumn;

            DisplayedTable.Rows.Add(NewRow);

            NewRow.Delete();

        }

        static public void DeleteElementFromDB(System.Windows.Forms.DataGridView dgv)
        {
            using (WinForms.Common.InputBox InputnumberOfElements = new UchetUSP.WinForms.Common.InputBox("Удаление элементов", "Удалить", "Количество удаляемых элементов"))
            {

                if (InputnumberOfElements.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (string.Compare(InputnumberOfElements.textBox1.Text, "") != 0)
                    { 
                        if (Convert.ToInt32(dgv[19, dgv.SelectedCells[0].RowIndex].Value.ToString()) >= Convert.ToInt32(InputnumberOfElements.textBox1.Text))
                        {
                            System.Collections.Generic.List<string> Parameters = new System.Collections.Generic.List<string>();

                            System.Collections.Generic.List<string> DataFromTextBox = new System.Collections.Generic.List<string>();

                            int NalichieParam = 0;

                            NalichieParam = (Convert.ToInt32(dgv[19, dgv.SelectedCells[0].RowIndex].Value.ToString()) - Convert.ToInt32(InputnumberOfElements.textBox1.Text));

                            Parameters.Add("NALICHI"); DataFromTextBox.Add(NalichieParam.ToString());
                            Parameters.Add("OBOZN"); DataFromTextBox.Add(dgv[1, dgv.SelectedCells[0].RowIndex].Value.ToString());

                            string cmd = "UPDATE DB_DATA SET NALICHI =:NALICHI WHERE OBOZN = :OBOZN";


                            if (SQLOracle.UpdateQuery(cmd, Parameters, DataFromTextBox) == true)
                            {
                                System.Windows.Forms.MessageBox.Show("ОБновление данных прошло успешно!");
                            }

                            Parameters.Clear();
                            DataFromTextBox.Clear();
                        }
                    
                    }
                   
                }
            
            }
                   
        }

                    
    }
}
