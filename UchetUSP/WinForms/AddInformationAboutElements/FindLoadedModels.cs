using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.WinForms.AddInformationAboutElements
{
    public partial class FindLoadedModels : Form
    {
        public FindLoadedModels()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            findLoadedParts(searchBox.Text);
        }

        private void findLoadedParts(string OboznOfPart)
        {
            if (!SQLOracle.existParamQuery("OBOZN", "DB_DATA", "OBOZN", OboznOfPart))
            {
                toolStripStatusLabel1.Text = "������ �� �������!";

                string NMF = SQLOracle.ParamQuerySelect("SELECT NMF FROM KTC.MODEL_ATTR20 WHERE HD = :HD", "HD", OboznOfPart);

                if (SQLOracle.existParamQuery("NMF", "FILE_BLOB20", "NMF", NMF.Trim()))
                {
                    toolStripStatusLabel1.Text = "������ ������� � ������� �������� ���������� � ���� ������!";

                    System.Collections.Generic.List<string> AcquiredInformation = new System.Collections.Generic.List<string>();

                    treeOfModel.BeginUpdate();

                    treeOfModel.Nodes.Clear();

                    treeOfModel.Nodes.Add(NMF);

                    AcquiredInformation = SQLOracle.GetInformationListWithParamQuery("NMF", "MODEL_STRUCT20", "PARENT", (NMF));

                    for (int i = 0; i < AcquiredInformation.Count; i++)
                    {
                        treeOfModel.Nodes[0].Nodes.Add(AcquiredInformation[i].ToString());
                    }

                    AcquiredInformation.Clear();

                    treeOfModel.EndUpdate();

                    treeOfModel.Nodes[0].ExpandAll();
                }

            }
            else {

                toolStripStatusLabel1.Text = "���������� � ������ ��� �������!";
                
            }
               
                    
        }

        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                    findLoadedParts(searchBox.Text);
        }


        private void FindLoadedModels_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "��������...";
        }

        private void treeOfModel_DoubleClick(object sender, EventArgs e)
        {
          //  if (String.Compare(treeOfModel.Nodes[0].Name, "") != 0)
            {
                string openPart = SQLOracle.UnloadOsnasToTEMPFolderFile20((treeOfModel.Nodes[0].Text));
                

                if (String.Compare(openPart, "0") != 0)
                {
                    System.Diagnostics.Process initPart = System.Diagnostics.Process.Start(openPart);
                    initPart.Dispose();
                }

            }

        }

    }
}