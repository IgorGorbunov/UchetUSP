using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace UchetUSP.Algorithm
{
    class ShowVPP
    {
        /// <summary>
        /// Возвращает список всех ВПП/ВЗД/ВПП на доработку на УСП
        /// </summary>       
        /// <param name="docStatus">Статус документа (1 - ВПП, 2 - ВЗД, 3 - ВПП на доработку)</param>
        /// <param name="fromDate">Начало временного интервала</param>
        /// <param name="toDate">Конец временного интервала</param>
        /// <returns></returns>
        public static DataTable getVPPs(int docStatus, DateTime fromDate, DateTime toDate)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("FROM_DATE", fromDate.Date.ToString());
            Dict.Add("TO_DATE", toDate.ToString());

            string cmdQuery = "select N_VD AS \"Номер ВПП\","+
            " N_TZ AS \"Номер ТЗ\", "+
            " POZ AS \"Позиция ТЗ в ВПП\", " +
            "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"Обозначение детали\"," +
            "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Версия\", " +
            "(SELECT PDM_IZD.KB FROM PDM_IZD, PDM_DOC_YTV WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD AND PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM AND PDM_IZD.KB <> '0')  AS \"Код изделия\" , " +
            "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Владелец\", " +
            "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Дата утверждения\", " +
            "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"Отдел\" " +
            "from VPP_TZ20 where N_VD = ANY (" +
                "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY (" +
                "select N_VD from VPP_TIT20 where "; //фильтр и для поиска по критериям ниже
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
                    "PDM_DOC_YTV.DOC AS \"Номер ТЗ\", " +
                    "PDM_DOC_YTV.REV AS \"Версия\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"Код изделия\" , " +
                    "PDM_DOC_YTV.USR AS \"Владелец\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"Отдел\", " +
                    "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                    "USP_TZ_DATA.NAIM_DET   AS \"Наименование детали\", " +
                    "USP_TZ_DATA.KOD_CEHA AS \"Код цеха-потребителя\", " +
                    "USP_TZ_DATA.OB_NAIM AS \"Наименование оборудования\", " +
                    "USP_TZ_DATA.OB_MODEL AS \"Модель оборудования\", " +
                    "USP_TZ_DATA.OB_SHIR AS \"Ширина паза\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"Дата утверждения\" " +
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                    toDate.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                    "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + fromDate.ToString() +
                    "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1' and PDM_DOC_YTV.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS)";
            return SQLOracle.getDT(cmdQuery);
        }

        /// <summary>
        /// Возвращает список всех ВПП/ВЗД/ВПП на доработку на УСП
        /// </summary>       
        /// <returns></returns>
        public static System.Data.DataSet getVPPs(DateTime fromDate, DateTime toDate)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("FROM_DATE", fromDate.Date.ToString());
            Dict.Add("TO_DATE", toDate.ToString());

            //различия между ВПП и ТЗ можно определить по ID_DOC колонке. ID_DOC колонака будет всегда нулевой для ВПП
            string cmdQuery = "(select NULL AS \"ID_DOC\", N_VD AS \"Номер ВПП\"," +
            " N_TZ AS \"Номер ТЗ\", "+
            " POZ AS \"Позиция ТЗ в ВПП\", " +
            "(SELECT VPP_POZ20.OB_D FROM VPP_POZ20 WHERE VPP_POZ20.POZ = VPP_TZ20.POZ AND VPP_POZ20.N_VD = VPP_TZ20.N_VD)  AS \"Обозначение детали\"," +
            "(SELECT PDM_DOC_YTV.REV FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Версия\", " +
            "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = ((SELECT PDM_DOC_YTV.IZD FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM)) AND PDM_IZD.KB <> '0') AS \"Код изделия\" , " +           
            "(SELECT PDM_DOC_YTV.USR FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Владелец\", " +
            "(SELECT PDM_DOC_YTV.ARX_TIME FROM PDM_DOC_YTV WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM) AS \"Дата утверждения\", " +
            "(SELECT p.OTD FROM PDM_DOC_YTV, PDM_PODR p WHERE PDM_DOC_YTV.ID_DOC = VPP_TZ20.NUM and p.KOD = PDM_DOC_YTV.PODR) AS \"Отдел\" " +            
            "from VPP_TZ20 where N_VD = ANY (" +
                "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY " +
                "(select N_VD from VPP_TIT20 WHERE  DT_R >= to_date(:FROM_DATE,'dd.mm.yyyy hh24:mi:ss') and DT_R <= to_date(:TO_DATE,'dd.mm.yyyy hh24:mi:ss'))"; //фильтр и для поиска по критериям ниже

          
            cmdQuery += " and PR1 = 1)" +
                " and NOT EXISTS(select * from USP_ASSEMBLY_ORDERS WHERE VPP_NUM = VPP_TZ20.N_VD AND TZ_NUM = VPP_TZ20.N_TZ) )";

            cmdQuery += "UNION (SELECT PDM_DOC_YTV.ID_DOC AS \"ID_DOC\", " +
                      "NULL AS \"Номер ВПП\", " +
                    "PDM_DOC_YTV.DOC AS \"Номер ТЗ\", " +     
                    "NULL AS \"Позиция ТЗ в ВПП\", "+
                    "USP_TZ_DATA.OBOZN_DET AS \"Обозначение детали\", " +
                    "PDM_DOC_YTV.REV AS \"Версия\", " +
                    "(SELECT PDM_IZD.KB FROM PDM_IZD WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD)  AS \"Код изделия\" , " +
                    "PDM_DOC_YTV.USR AS \"Владелец\", " +
                    "PDM_DOC_YTV.ARX_TIME AS \"Дата утверждения\", " +
                    "(SELECT PDM_PODR.OTD FROM PDM_PODR WHERE PDM_PODR.KOD = PDM_DOC_YTV.PODR)  AS \"Отдел\" " +                                        
                    "FROM  PDM_DOC_YTV INNER JOIN USP_TZ_DATA ON PDM_DOC_YTV.ID_DOC = USP_TZ_DATA.ID_DOC " +
                    "where  (PDM_DOC_YTV.ARX_TIME <= to_date( '" +
                    toDate.ToString() + "','DD.MM.YYYY hh24:mi:ss')) " +
                    "AND (PDM_DOC_YTV.ARX_TIME >= to_date( '" + fromDate.ToString() +
                    "','DD.MM.YYYY hh24:mi:ss')) AND USP_TZ_DATA.UTV  = '1' and USP_TZ_DATA.ID_DOC not in (select ID_TZ from USP_ASSEMBLY_ORDERS))";
            
            return SQLOracle.getDS(cmdQuery,Dict);
        }
                   
        
                    
    }
}
