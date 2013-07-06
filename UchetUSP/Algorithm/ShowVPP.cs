using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace UchetUSP.Algorithm
{
    class ShowVPP
    {
        /// <summary>
        /// ���������� ������ ���� ���/���/��� �� ��������� �� ���
        /// </summary>       
        /// <param name="docStatus">������ ��������� (1 - ���, 2 - ���, 3 - ��� �� ���������)</param>
        /// <param name="fromDate">������ ���������� ���������</param>
        /// <param name="toDate">����� ���������� ���������</param>
        /// <returns></returns>
        public static DataTable getVPPs(int docStatus, DateTime fromDate, DateTime toDate)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("FROM_DATE", fromDate.Date.ToString());
            Dict.Add("TO_DATE", toDate.ToString());

            string cmdQuery = "select N_VD AS \"����� ���\","+
            " N_TZ AS \"����� ��\", "+
            " POZ AS \"������� �� � ���\", " +
            "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"����������� ������\"," +
            "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"������\", " +
            "(SELECT PDM_IZD.KB FROM PDM_IZD, PDM_DOC_YTV WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD AND PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM AND PDM_IZD.KB <> '0')  AS \"��� �������\" , " +
            "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"��������\", " +
            "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"���� �����������\", " +
            "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"�����\" " +
            "from VPP_TZ20 where N_VD = ANY (" +
                "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY (" +
                "select N_VD from VPP_TIT20 where "; //������ � ��� ������ �� ��������� ����
         //   (SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)
            switch (docStatus)
            {
                case 1:
                    cmdQuery += "PR2 = 0";
                    break;
                case 2:
                    cmdQuery += "PR2 = 1";
                    break;
                case 3:
                    cmdQuery += "PR3 = 1";
                    break;
            }

            cmdQuery += " and DT_R >= to_date(:FROM_DATE,'dd.mm.yyyy hh24:mi:ss') and DT_R <= to_date(:TO_DATE,'dd.mm.yyyy hh24:mi:ss')) and PR1 = 1)" +
                "  and NOT EXISTS(select * from USP_ASSEMBLY_ORDERS WHERE VPP_NUM = VPP_TZ20.N_VD AND TZ_NUM = VPP_TZ20.N_TZ)";
            //System.Windows.Forms.MessageBox.Show(cmdQuery);
            return SQLOracle.getDT(cmdQuery, Dict);
        }


        public static DataTable getTZs(DateTime fromDate, DateTime toDate)
        {
            //System.Windows.Forms.MessageBox.Show(fromDate.ToString() + "\n" + toDate.ToString());
            string cmdQuery = "SELECT PDM_DOC_YTV.ID_DOC, " +
                    "PDM_DOC_YTV.DOC AS \"����� ��\", " +
                    "PDM_DOC_YTV.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC_YTV.USR AS \"��������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"�����\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"������������ ������\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"��� ����-�����������\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"������������ ������������\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"������ ������������\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"������ ����\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"���� �����������\" " +
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                    toDate.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                    "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + fromDate.ToString() +
                    "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1' and PDM_DOC_YTV.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS)";
            return SQLOracle.getDT(cmdQuery);
        }

        /// <summary>
        /// ���������� ������ ���� ���/���/��� �� ��������� �� ���
        /// </summary>       
        /// <returns></returns>
        public static System.Data.DataSet getVPPs(DateTime fromDate, DateTime toDate)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("FROM_DATE", fromDate.Date.ToString());
            Dict.Add("TO_DATE", toDate.ToString());

            //�������� ����� ��� � �� ����� ���������� �� ID_DOC �������. ID_DOC �������� ����� ������ ������� ��� ���
            string cmdQuery = "(select NULL AS \"ID_DOC\", N_VD AS \"����� ���\"," +
            " N_TZ AS \"����� ��\", "+
            " POZ AS \"������� �� � ���\", " +
            "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"����������� ������\"," +
            "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"������\", " +
            "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = ((SELECT PDM_DOC_YTV.IZD FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)) AND PDM_IZD.KB <> '0') AS \"��� �������\" , " +           
            "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"��������\", " +
            "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"���� �����������\", " +
            "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"�����\" " +            
            "from VPP_TZ20 where N_VD = ANY (" +
                "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY " +
                "(select N_VD from VPP_TIT20 WHERE  DT_R >= to_date(:FROM_DATE,'dd.mm.yyyy hh24:mi:ss') and DT_R <= to_date(:TO_DATE,'dd.mm.yyyy hh24:mi:ss'))"; //������ � ��� ������ �� ��������� ����

          
            cmdQuery += " and PR1 = 1)" +
                " and NOT EXISTS(select * from USP_ASSEMBLY_ORDERS WHERE VPP_NUM = VPP_TZ20.N_VD AND TZ_NUM = VPP_TZ20.N_TZ) )";

            cmdQuery += "UNION (SELECT PDM_DOC_YTV.ID_DOC AS \"ID_DOC\", " +
                      "NULL AS \"����� ���\", " +
                    "PDM_DOC_YTV.DOC AS \"����� ��\", " +     
                    "NULL AS \"������� �� � ���\", "+
                    "USP_TZ_DATA.OBOZN_DET AS \"����������� ������\", " +
                    "PDM_DOC_YTV.REV AS \"������\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"��� �������\" , " +
                    "PDM_DOC_YTV.USR AS \"��������\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"���� �����������\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"�����\" " +                                        
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                    toDate.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                    "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + fromDate.ToString() +
                    "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1' and USP_TZ_DATA.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS))";
            
            return SQLOracle.getDS(cmdQuery,Dict);
        }
                   
        
                    
    }
}
