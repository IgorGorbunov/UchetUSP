using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

class _ELEMENTS
{
    static string _elementsTable = "DB_DATA";


    /// <summary>
    /// ���������� ���������� ��������� (�����)
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static int getAllN(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        string cmdQuery = "select NALICHI from " + _elementsTable + " where obozn = :TITLE and NALICHI <> 999";
        return SQLOracle.selectInt(cmdQuery, Dict);
    }


    /// <summary>
    /// ���������� ���������� ��������� � ������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static int getBusyN(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        return SQLOracle.selectInt("select SUM(ELEMENTS_COUNT) from USP_HOT_STATS where ELEMENT_TITLE = :TITLE", Dict);
    }

    /// <summary>
    /// ���������� ���������� ��������� �� ������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static int getFreeN(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        int busy = getBusyN(title);

        return SQLOracle.selectInt("select NALICHI - " + busy + " from DB_DATA where obozn = :TITLE", Dict);
    }

    /// <summary>
    /// ���������� ���� ��������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static string getGOST(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        return SQLOracle.selectStr("select GOST from " + _elementsTable + " where obozn = :TITLE", Dict);
    }

    /// <summary>
    /// ���������� ������ ��������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static string getGroup(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        int group = SQLOracle.selectInt("select GROUP_USP from DB_DATA where obozn = :TITLE", Dict, 99);

        string groupS = "";
        switch (group)
        {
            case 0:
                groupS = "������� ������";
                break;
            case 1:
                groupS = "��������� ������";
                break;
            case 2:
                groupS = "������������ ������";
                break;
            case 3:
                groupS = "������������ ������";
                break;
            case 4:
                groupS = "��������� ������";
                break;
            case 5:
                groupS = "��������� ������";
                break;
            case 6:
                groupS = "������ ������";
                break;
            case 7:
                groupS = "��������� �������";
                break;
        }

        return groupS;
    }

    /// <summary>
    /// ���������� ������������ ��������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static string getName(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string,string>();
        Dict.Add("TITLE", title);

        return SQLOracle.selectStr("select NAME from " + _elementsTable + " where obozn = :TITLE", Dict);
    }

    /// <summary>
    /// ���������� ������������ ��������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static string getKatalog(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        int catalog = SQLOracle.selectInt("select KATALOG_USP from " + _elementsTable + " where obozn = :TITLE", Dict, 99);

        string catalogS = "";
        switch (catalog)
        {
            case 0:
                catalogS = "���-8";
                break;
            case 1:
                catalogS = "���-12";
                break;
            case 2:
                catalogS = "����������� ������";
                break;
        }

        return catalogS;
    }

    /// <summary>
    /// ���������� ����� ��������
    /// </summary>
    /// <param name="title">�����������</param>
    /// <returns></returns>
    public static string getWeight(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        return SQLOracle.selectStr("select MASSA from " + _elementsTable + " where obozn = :TITLE", Dict);
    }

    /// <summary>
    /// ����� ���������� true, ���� ���������� �������� ������� � DB_DATA
    /// </summary>
    /// <param name="title">����������� ��������</param>
    /// <returns></returns>
    public static bool existElement(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", title);

        string cmdQuery = "select OBOZN from DB_DATA where OBOZN = :TITLE";

        if (SQLOracle.selectStr(cmdQuery, Dict) == "")
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    //-----------------------------------------------------------------------
    public static int getElementsN()
    {
        return SQLOracle.selectInt("select SUM(NALICHI) from DB_DATA where NALICHI <> 999");
    }

    public static int getBusyElementsN()
    {
        return SQLOracle.selectInt("select SUM(ASSEMBLY_ELEMENTS_COUNT) from USP_ASSEMBLY_ORDERS where DOC_STATUS = 1 or DOC_STATUS = 2 or DOC_STATUS = 3");
    }

    public static string getFrequetElemTitle()
    {
        return SQLOracle.selectStr("WITH T AS (SELECT count(HD) as ELEM_N, HD FROM model_struct20 WHERE HD IS NOT NULL) select T.HD from T where T.ELEM_N = max(T.ELEM_N);");
    }

    public static List<string> getUseableElems()
    {
        return SQLOracle.selectListStr("select HD from model_struct20 where PARENT = any (select NMF from model_attr20 where HD = any (select OB_O from VPP_POZ20 where N_VD = any (select VPP_NUM from USP_ASSEMBLY_ORDERS where DOC_STATUS = 1 or DOC_STATUS = 2 or DOC_STATUS = 3)))");
    }

    //------------------------------ DATASETS ------------------------------------

    /// <summary>
    /// ���������� ������� � ������� � ������� ���������� ���������
    /// </summary>
    /// <param name="title">��������� ����������� ��������</param>
    /// <returns></returns>
    public static DataTable getElements_Title(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string,string>();
        Dict.Add("TITLE", "%" + title + "%");


        DataTable DT = SQLOracle.getDT("with T " +
            "as " +
            "( " +
            "select USP_HOT_STATS.ELEMENT_TITLE, sum(USP_HOT_STATS.ELEMENTS_COUNT) as S " +
            "from USP_HOT_STATS " +
            "where USP_HOT_STATS.ELEMENT_TITLE like :TITLE " +
            "group by USP_HOT_STATS.ELEMENT_TITLE " +
            ") " +
            "select DB_DATA.OBOZN, DB_DATA.NAME, DB_DATA.NALICHI-COALESCE(T.S,0) as TOTAL " +
            "from DB_DATA left join T " +
            "on DB_DATA.OBOZN=T.ELEMENT_TITLE " +
            "where DB_DATA.OBOZN like :TITLE and DB_DATA.NALICHI <> 0 and DB_DATA.NALICHI <> 999", Dict);


        DT.Columns[0].ColumnName = "�����������";
        DT.Columns[1].ColumnName = "������������";
        DT.Columns[2].ColumnName = "���-�� �� ������";
        return DT;
    }

    /// <summary>
    /// ���������� ��������������� ���������
    /// </summary>
    /// <param name="title">��������� ����������� ��������</param>
    /// <returns></returns>
    public static DataTable getElementsDestination(string title)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", "%" + title + "%");


        DataTable DT = SQLOracle.getDT("with T " +
            "as " +
            "( " +
            "select USP_HOT_STATS.ELEMENT_TITLE, sum(USP_HOT_STATS.ELEMENTS_COUNT) as S " +
            "from USP_HOT_STATS " +
            "where USP_HOT_STATS.ELEMENT_TITLE like :TITLE " +
            "group by USP_HOT_STATS.ELEMENT_TITLE " +
            ") " +
            "select DB_DATA.OBOZN, DB_DATA.NAME, DB_DATA.NALICHI-COALESCE(T.S,0) as TOTAL " +
            "from DB_DATA left join T " +
            "on DB_DATA.OBOZN=T.ELEMENT_TITLE " +
            "where DB_DATA.OBOZN like :TITLE and DB_DATA.NALICHI <> 0 and DB_DATA.NALICHI <> 999", Dict);


        DT.Columns[0].ColumnName = "�����������";
        DT.Columns[1].ColumnName = "������������";
        DT.Columns[2].ColumnName = "���������������";
        return DT;
    }

    /// <summary>
    /// ����� ���������� ������� � ���������� �� ������ ���� � �� �����������
    /// </summary>
    /// <param name="equipTitle">����������� ����</param>
    /// <returns></returns>
    public static DataTable getElements(string equipTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", equipTitle);

        string cmdQuery = "select HD, CNT from KTC.model_struct20 where PARENT = (select NMF from KTC.model_attr20 where HD = :TITLE) and T = 0";
        DataTable DT = SQLOracle.getDT(cmdQuery, Dict);
        DT.Columns[0].ColumnName = "�����������";
        DT.Columns[1].ColumnName = "���-��";

        return DT;
    }

    /// <summary>
    /// ����� ���������� ������� � ���������� ��������������� � ������� � ��������� �������
    /// </summary>
    /// <param name="DTFrom">������ ���������</param>
    /// <param name="DTTo">����� ���������</param>
    /// <returns></returns>
    public static DataTable getColdStats(DateTime DTFrom, DateTime DTTo)
    {
        DateTime fromDate = DTFrom.Date;
        DateTime toDate = DTTo.Date;
        toDate = toDate.AddDays(1);

        return SQLOracle.getDT("select ELEMENT_NUM, count(ELEMENT_NUM), SUM (trunc(to_number(ASSEMBLY_RETURN_DATE - ASSEMBLY_DELIVERY_DATE), 3) * 24) from USP_ASSEMBLY_ELEMENTS E, USP_ASSEMBLY_ORDERS O " +
            "where O.ASSEMBLY_ID = E.ASSEMBLY_ID and CREATION_DATE >= to_date('" + DTFrom.ToString() + "', 'dd.mm.yyyy hh24:mi:ss') and CREATION_DATE < to_date('" + toDate.ToString() + "','dd.mm.yyyy hh24:mi:ss')" +
            " GROUP BY ELEMENT_NUM");
    }
}