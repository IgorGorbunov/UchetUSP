using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace UchetUSP
{
    /// <summary>
    /// Класс заполнения ВПП
    /// </summary>
    class VPP : ExcelClass, IDisposable
    {
        string _VPPnum;
        string _templateName = "VPP.xlt";
        Dictionary<string, string> _D = new Dictionary<string,string>();
        DataSet _DS;
        DataTable _DTAgree;

        /// <summary>
        /// Создаёт класс ВПП
        /// </summary>
        /// <param name="VPPnum">Номер ВПП</param>
        public VPP(string VPPnum)
        {
            _VPPnum = VPPnum;
        }

        //------------------------------------------------------------------
        public static string _table = "VPP_POZ20";
        public static string _tableTitle = "VPP_TIT20";
        public static string _tableTZ = "VPP_TZ20";
        public static string _condition = " where N_VD = :VPP_NUM";

        /// <summary>
        /// Метод возвращает идентификатор ВПП
        /// </summary>
        /// <param name="VPPNum">Номер ВПП</param>
        /// <returns></returns>
        public static int getId(string VPPNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPNum);

            string cmdQuery = "select NUM from VPP_POZ20 where N_VD = :VPP_NUM";
            return SQLOracle.selectInt(cmdQuery, Dict);
        }

        /// <summary>
        /// Метод возвращает идентификатор КТС
        /// </summary>
        /// <param name="equipTitle">Обозначение УСПО</param>
        /// <returns></returns>
        public static int getKTCId(string equipTitle)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("TITLE", equipTitle);

            string cmdQuery = "select ID_DOC from PDM_DOC where TYP = 2 and DOC = :TITLE";
            return SQLOracle.selectInt(cmdQuery, Dict);
        }

        /// <summary>
        /// Метод возвращает обозначение УСПО
        /// </summary>
        /// <param name="id">Идентификатор ВПП</param>
        /// <returns></returns>
        public static string getEquipTitle(int id)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", id.ToString());

            string cmdQuery = "select OB_O from VPP_POZ20 where NUM = :ID";
            return SQLOracle.selectStr(cmdQuery, Dict);
        }

        /*
        public static int getWorkshopCode(string VPPnum)
        {
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            ParamsDict.Add(":VPP_NUM", VPPnum);

            return SQLOracle.selectInt("select CE from " + _table + _condition);
        }*/
        public static int getNRows(string VPPnum)
        {
            return SQLOracle.selectInt("select count(POZ) from " + _table + " where N_VD = '" + VPPnum + "'");
        }

        public static string getKDnum(string VPPnum)
        {
            return SQLOracle.selectStr("select I_KD from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
        }
        public static string getORDdate(string VPPnum)
        {
            DateTime Date = SQLOracle.selectDate("select DT_ORD from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
            if (Date == new DateTime(1, 1, 1))
                return "";
            else
                return Date.ToShortDateString();
        }
        public static string getORDtitle(string VPPnum)
        {
            return SQLOracle.selectStr("select ORD from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
        }
        static string getOwnerFam(string VPPnum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPnum);

            return SQLOracle.selectStr("select FAM from PDM_USR U, PDM_DOC_YTV Y, VPP_POZ20 P where U.USR = Y.USR and Y.ID_DOC = P.NUM and P.N_VD = :VPP_NUM", Dict);
        }
        static DateTime getOwnDate(string VPPnum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPnum);

            return SQLOracle.selectDate("select ARX_TIME from PDM_DOC_YTV Y, VPP_POZ20 P where Y.ID_DOC = P.NUM and P.N_VD = :VPP_NUM", Dict);
        }
        public static int getPGO(string VPPnum)
        {
            return SQLOracle.selectInt("select PGO from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
        }
        public static string getProductTitle(string VPPnum)
        {
            return SQLOracle.selectStr("select KI from " + _table + " where N_VD = '" + VPPnum + "'");
        }
        public static string getRegistrationDate(string VPPnum)
        {
            DateTime Date = SQLOracle.selectDate("select DT_R from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
            if (Date == new DateTime(1, 1, 1))
                return "";
            else
                return Date.ToShortDateString();
        }
        public static string getSendTo(string VPPnum)
        {
            return SQLOracle.selectStr("select CEHA from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
        }
        public static int getSTKnum(string VPPnum)
        {
            return SQLOracle.selectInt("select TK from " + _tableTitle + " where N_VD = '" + VPPnum + "'");
        }
        public static int getWorkshopCode(string VPPnum)
        {
            return SQLOracle.selectInt("select distinct CE from " + _tableTZ + " where N_VD = '" + VPPnum + "'");
        }

        static DataTable getDTAgree(string VPPNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPNum);

            string cmdQuery = "select A.WNM, U.FAM, A.DT from PDM_DOC_PODP_ARX A, PDM_USR U, VPP_POZ20 P where U.USR = A.USR and A.USR <> '-' and A.USR is not NULL and A.ID_DOC = P.NUM and P.N_VD = :VPP_NUM";
            return SQLOracle.getDT(cmdQuery, Dict);
        }
        public static DataSet getDSElements(string VPPnum)
        {
            return SQLOracle.getDS("select P_ORD, OB_D, POZ, NA_O, KOD_O, OB_O, KOL_V, OCH_O, KOD_P, DT_P, CI, DT_I, SW, SO, TRUD, KZ from " + _table + " where N_VD = '" + VPPnum + "' order by POZ");
        }
        //------------------------------------------------------------------

        void _getParams()
        {
            _writeToD("VPP_NUM", _VPPnum);
            _writeToD("REGISTRATION_DATE", getRegistrationDate(_VPPnum));
            _writeToD("ORD_TITLE", getORDtitle(_VPPnum));
            _writeToD("ORD_DATE", getORDdate(_VPPnum));
            _writeToD("PRODUCT_TITLE", getProductTitle(_VPPnum));
            _writeToD("STK_NUM", getSTKnum(_VPPnum));
            _writeToD("WORKSHOP_CODE", getWorkshopCode(_VPPnum));
            _writeToD("PGO", "0" + getPGO(_VPPnum).ToString());
            _writeToD("KD_NUM", getKDnum(_VPPnum));
            _writeToD("SEND_TO", getSendTo(_VPPnum));

            //_writeToD("p_raz_fam", getOwnerFam(_VPPnum));
            //DateTime controlDate = new DateTime(1, 1, 1);
            //DateTime date = getOwnDate(_VPPnum);

            //if (date.Date != controlDate.Date)
            //{
            //    _writeToD("p_raz_date", date.ToShortDateString());
            //    _writeToD("p_prov_date", date.ToShortDateString());
            //    _writeToD("p_sog_date1", date.ToShortDateString());
            //    _writeToD("p_sog_date2", date.ToShortDateString());
            //    _writeToD("p_sog_date3", date.ToShortDateString());
            //    _writeToD("p_sog_date4", date.ToShortDateString());
            //    _writeToD("p_sog_date5", date.ToShortDateString());
            //}

            _DS = getDSElements(_VPPnum);
            _DTAgree = getDTAgree(_VPPnum);
        }

        /// <summary>
        /// Создает ВПП
        /// </summary>
        public void createXLS()
        {
            HashCode.HashCode.CheckFileByHash(_templateName);

            if (System.IO.File.Exists(Program.PathString + "\\" + _templateName))
            {
                _getParams();
                NewDocument(_templateName);
                _fillXLS();
                this.Visible = true;
            }
        }

        void _fillXLS()
        {

            foreach (KeyValuePair<string, string> Pair in _D)
            {
                _writeFromD(Pair.Key);
            }

            _writeElements();
            _writeAgree();
        }

        void _writeElements()
        {
            int nRows = getNRows(_VPPnum);

            int firstRow = 12;
            string[] colNames = { "A", "B", "F", "G", "L", "N", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA" };

            int row = firstRow;
            for (int i = 1; i <= nRows; i++)
            {
                object[] arr = _DS.Tables[0].Rows[i - 1].ItemArray;

                for (int j = 0; j < 16; j++)
                {
                    WriteDataToCell(colNames[j] + row.ToString(), arr[j].ToString());
                }
                row++;
            }
        }

        void _writeAgree()
        {
            int nRows = _DTAgree.Rows.Count;

            int firstRow = 32;
            string[] colNames1 = { "O", "Q", "U" };
            string[] colNames2 = { "V", "X", "Z" };
            string[] colNames;

            colNames = colNames1;
            int row = firstRow;
            for (int i = 1; i <= nRows; i++)
            {
                if (row == 36)//перевод записи на другие столбцы с начальной строки
                {
                    colNames = colNames2;
                    row = 32;
                }

                object[] arr = _DTAgree.Rows[i - 1].ItemArray;

                for (int j = 0; j < 3; j++)
                {
                    string ob = arr[j].ToString();
                    if (j == 2)
                    {
                        string[] split = ob.Split(' ');
                        ob = split[0]; //берем только дату
                    }
                    WriteDataToCell(colNames[j] + row.ToString(), ob);
                }
                row++;
            }
        }


        void _writeFromD(string key, string adress)
        {
            if (_D.ContainsKey(key))
                WriteDataToCell(adress, _D[key]);
        }
        void _writeFromD(string key)
        {
            if (_D.ContainsKey(key))
                WriteDataToCell(key, _D[key]);
        }
        void _writeToD(string key, object value)
        {
            if (_D.ContainsKey(key))
                _D[key] = value.ToString();
            else
                _D.Add(key, value.ToString());
        }

    }
}