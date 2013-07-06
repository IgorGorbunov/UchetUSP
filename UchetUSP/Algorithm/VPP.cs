using System;
using System.Collections.Generic;
using System.Text;
using UchetUSP.WinForms;
using UchetUSP.Algorithm;
using System.Windows.Forms;

namespace UchetUSP.Layout
{
    public partial class LayoutOrder : IDisposable
    {


        void SearchVPP_Click(object sender, EventArgs e)
        {
            if (String.Compare(comboBox1.Text, "�� (��� ���)") == 0)
            {
                using (WinForms.TZORDER.FindTZ newSearch = new UchetUSP.WinForms.TZORDER.FindTZ(3, 1,dGV,dateTimePicker1,dateTimePicker2,"����� ��� ��"))
                {
                    newSearch.ShowDialog();
                }
            }
            else if (String.Compare(comboBox1.Text, "���") == 0)
            {
                using (WinForms.VPP.FindVPP newSearch = new UchetUSP.WinForms.VPP.FindVPP(1,  dGV, dateTimePicker1, dateTimePicker2))
                {
                    newSearch.ShowDialog();
                }
            }
            else if (String.Compare(comboBox1.Text, "���") == 0)
            {
                using (WinForms.VPP.FindVPP newSearch = new UchetUSP.WinForms.VPP.FindVPP(2, dGV, dateTimePicker1, dateTimePicker2))
                {
                    newSearch.ShowDialog();
                }
            }

            else if (String.Compare(comboBox1.Text, "���") == 0)
            {
                using (WinForms.VPP.FindVPP newSearch = new UchetUSP.WinForms.VPP.FindVPP(3,  dGV, dateTimePicker1, dateTimePicker2))
                {
                    newSearch.ShowDialog();
                }
            }
        }

        void  SearchLZConfirm_Click(object sender, EventArgs e)
        {
            using (WinForms.OrderList.FindOL newSearch = new UchetUSP.WinForms.OrderList.FindOL(1, dGV, dateTimePicker1, dateTimePicker2))
            {
                newSearch.ShowDialog();
            }
        }

        void SearchGrantOrder_Click(object sender, EventArgs e)
        {
            using (WinForms.OrderList.FindOL newSearch = new UchetUSP.WinForms.OrderList.FindOL(2, dGV, dateTimePicker1, dateTimePicker2))
            {
                newSearch.ShowDialog();
            }
        }

        void SearchGetOrder_Click(object sender, EventArgs e)
        {
            using (WinForms.OrderList.FindOL newSearch = new UchetUSP.WinForms.OrderList.FindOL(3, dGV, dateTimePicker1, dateTimePicker2))
            {
                newSearch.ShowDialog();
            }
        }

        void SearchHistoryOrder_Click(object sender, EventArgs e)
        {
            using (WinForms.OrderList.FindOL newSearch = new UchetUSP.WinForms.OrderList.FindOL(4, dGV, dateTimePicker1, dateTimePicker2))
            {
                newSearch.ShowDialog();
            }
        }



        void LoadPartToNX_Click(object sender, EventArgs e)
        {
            if (dGV.RowCount > 0)
            {
                if (String.Compare(comboBox1.Text, "���")==0)
                {
                                        
                    if (String.Compare(dGV["ID_DOC", dGV.SelectedCells[0].RowIndex].Value.ToString(),"")!=0)
                    {
                         
                    }
                    else {

                        if (IsModel())
                        {
                            
                            string PartOsn = SQLOracle.UnloadOsnasToTEMPFolder(dGV["����� ���", dGV.SelectedCells[0].RowIndex].Value.ToString(), dGV["������� �� � ���", dGV.SelectedCells[0].RowIndex].Value.ToString());
                          
                            if (String.Compare(PartOsn, "0") != 0)
                            {
                                System.Diagnostics.Process initPart = System.Diagnostics.Process.Start(PartOsn);
                                initPart.Dispose();
                            }
                        }
                        else {
                            MessageBox.Show("������ �� �������!");
                        }
                           
                    }
                }
                else if ((String.Compare(comboBox1.Text, "���") == 0) || (String.Compare(comboBox1.Text, "���") == 0))
                {
                           if (IsModel())
                                {
                                    string PartOsn = SQLOracle.UnloadOsnasToTEMPFolder(dGV["����� ���", dGV.SelectedCells[0].RowIndex].Value.ToString(), dGV["������� �� � ���", dGV.SelectedCells[0].RowIndex].Value.ToString());

                                    if (String.Compare(PartOsn, "0") != 0)
                                    {
                                        System.Diagnostics.Process initPart = System.Diagnostics.Process.Start(PartOsn);
                                        initPart.Dispose();
                                    }
                            }
                            else
                            {
                                MessageBox.Show("������ �� �������!");
                            }
                }
              
                
            }
        }

        bool IsModel()
        {
            string OBOZN;
            Dictionary<string, string> ParamDic = new Dictionary<string, string>();
            ParamDic.Add("N_VD",dGV["����� ���", dGV.SelectedCells[0].RowIndex].Value.ToString());
            ParamDic.Add("POZ", (dGV["������� �� � ���", dGV.SelectedCells[0].RowIndex].Value.ToString()).Trim());

            if (SQLOracle.exist("SELECT OB_O FROM VPP_POZ20 WHERE N_VD = :N_VD AND POZ = :POZ", ParamDic))
            {                
                OBOZN = SQLOracle.ParamQuerySelect("SELECT OB_O FROM VPP_POZ20 WHERE N_VD = :N_VD AND POZ = '" + ParamDic["POZ"] + "' ", "N_VD", ParamDic["N_VD"]);
            }
            else
            {               
                return false;
            }

            if (SQLOracle.existParamQuery("NMF","MODEL_ATTR20","HD",OBOZN.Trim()))
            {                                
                return true;
            }

            return false;
        
        }


    }
}
