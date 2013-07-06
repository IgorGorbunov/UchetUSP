using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

/// <summary>
/// Класс содержащий sql-запросы к сборкам
/// </summary>
class _ASSEMBLIES
{
    static string _table = "model_struct20";
    static string _where = " where PARENT = (select NMF from model_attr20 where HD = :PARENT_TITLE) and T = 0";

    //--------------------------------------------------------

    /// <summary>
    /// Метод возвращает все сборки в заданном временном интервале
    /// </summary>
    /// <param name="DTFrom">Начало интервала</param>
    /// <param name="DTTo">Конец интервала</param>
    /// <returns></returns>
    public static DataTable getAssemblies(DateTime DTFrom, DateTime DTTo)
    {
        DateTime fromDate = DTFrom.Date;
        DateTime toDate = DTTo.Date;
        toDate = toDate.AddDays(1);

        /*return SQLOracle.getDT("select A.ID, A.NUM, O.ASSEMBLY_NUM, O.PART_TITLE, O.TECH_CONDITIONS, A.ELEMENTS_COUNT, O.CREATION_DATE from USP_ASSEMBLIES A, USP_ASSEMBLY_ORDERS O " +
            "where O.ASSEMBLY_ID = A.ID and O.CREATION_DATE >= to_date('" + DTFrom.ToString() + "', 'dd.mm.yyyy hh24:mi:ss') and O.CREATION_DATE < to_date('" + toDate.ToString() + "','dd.mm.yyyy hh24:mi:ss')");*/

        return SQLOracle.getDT("select A.ID, A.NUM, A.ELEMENTS_COUNT, O.ASSEMBLY_STRAPS_COUNT, O.ASSEMBLY_NUTS_COUNT, O.ASSEMBLY_SPECIAL_ELEMEN_COUNT, O.ASSEMBLY_DIFFICULTY_GROUP from USP_ASSEMBLIES A, USP_ASSEMBLY_ORDERS O " +
            "where O.ASSEMBLY_ID = A.ID and A.NUM is not NULL and O.CREATION_DATE >= to_date('" + DTFrom.ToString() + "', 'dd.mm.yyyy hh24:mi:ss') and O.CREATION_DATE < to_date('" + toDate.ToString() + "','dd.mm.yyyy hh24:mi:ss')");
    }

    /// <summary>
    /// Метод возвращает идентификатор сборки по обозначению
    /// </summary>
    /// <param name="title">Обозначение УСПО</param>
    /// <returns></returns>
    public static int getId(string title)
    {
        Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
        ParamsDict.Add("NUM", title);

        return SQLOracle.selectInt("select ID from USP_ASSEMBLIES where NUM = :NUM", ParamsDict);
    }

    /// <summary>
    /// Метод возвращает идентификатор сборки
    /// </summary>
    /// <param name="orderNum">Номер листа заказа</param>
    /// <returns></returns>
    public static int getId_OrderNum(string orderNum)
    {
        Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
        ParamsDict.Add("NUM", orderNum);

        return SQLOracle.selectInt("select ID from USP_ASSEMBLIES A, USP_ASSEMBLY_ORDERS O where O.NUM = :NUM and O.ASSEMBLY_ID = A.ID", ParamsDict);
    }

    //--------------------------------------------------------
    /// <summary>
    /// Метод возвращает обозначение сборки УСПО по заданному ВПП
    /// </summary>
    /// <param name="VPPnum">Номер ВПП</param>
    /// <param name="pos">Позиция ВПП</param>
    public static string getAssemblyTitle(string VPPnum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPnum);
        Dict.Add("POS", pos.ToString());

        string str = SQLOracle.selectStr("select OB_O from VPP_POZ20 where N_VD = :VPP_NUM and POZ = :POS", Dict);
        return str.Trim();
    }
    /// <summary>
    /// Метод возвращает обозначение сборки УСПО по заданному номеру листа заказа
    /// </summary>
    /// <param name="orderNum">Номер листа заказа</param>
    /// <returns></returns>
    public static string getAssemblyTitle_orderNum(string orderNum)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        string VPPNum = AssemblyOrders.getVPPnumber(orderNum);
        int pos = AssemblyOrders.getTZpos(orderNum);

        return getAssemblyTitle(VPPNum, pos);
    }

    /// <summary>
    /// Возвращает количество использования сборки
    /// </summary>
    /// <param name="id">id сборки</param>
    /// <returns></returns>
    public static int getN(int id)
    {
        Dictionary<string, string> Dict = new Dictionary<string,string>();
        Dict.Add("ASSEMBLY_ID", id.ToString());

        return SQLOracle.selectInt("select count(*) from USP_ASSEMBLY_ORDERS where ASSEMBLY_ID = :ASSEMBLY_ID", Dict);
    }

    /// <summary>
    /// Возвращает словарь с "обозначеник"-"кол-во" элементвов входящих в УСПО
    /// </summary>
    /// <param name="parentTitle">Обозначение УСПО</param>
    /// <returns></returns>
    public static Dictionary<string, string> getElements(string parentTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string,string>();
        Dict.Add("PARENT_TITLE", parentTitle);

        string str = "select HD, CNT from KTC.model_struct20 where PARENT = (select NMF from KTC.model_attr20 where HD = :PARENT_TITLE) and T = 0";
        return SQLOracle.selectDictStr(str, Dict);
    }
    /// <summary>
    /// Возвращает словарь с "обозначеник"-"кол-во" элементвов входящих в УСПО
    /// </summary>
    /// <param name="id">id УСПО</param>
    /// <returns></returns>
    public static Dictionary<string, string> getElements(int id)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("ID", id.ToString());

        return SQLOracle.selectDictStr("select ELEMENT_NUM, ELEMENTS_COUNT from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID", Dict);
    }

    /// <summary>
    /// Метод возвращает кол-во элементов в сборке
    /// </summary>
    /// <param name="assemblyTitle">
    /// Обозначение сборки
    /// </param>
    public static int getElementsCount(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assemblyTitle);
        
        return SQLOracle.selectInt("select sum(cnt) from " + _table + _where, Dict);
    }

    public static int getStrapsCount(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(S.CNT) from model_struct20 S, model_attr20 A, DB_DATA D where D.GROUP_USP = 4 and S.HD = D.OBOZN and S.PARENT = A.NMF and A.HD = :PARENT_TITLE", Dict);
    }

    public static int getNutsCount(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(S.CNT) from model_struct20 S, model_attr20 A, DB_DATA D where D.GROUP_USP = 5 and S.HD = D.OBOZN and S.PARENT = A.NMF and A.HD = :PARENT_TITLE", Dict);
    }

    public static int getSpecialElementsCount(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(S.CNT) from model_struct20 S, model_attr20 A, DB_DATA D where D.KATALOG_USP = 2 and S.HD = D.OBOZN and S.PARENT = A.NMF and A.HD = :PARENT_TITLE", Dict);
    }

    /// <summary>
    /// Метод возвращает кол-во элементов в сборке
    /// </summary>
    /// <param name="assemblyTitle">
    /// Обозначение сборки
    /// </param>
    public static int getElementsCountU(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(ELEMENTS_COUNT) from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = (select ID from USP_ASSEMBLIES where NUM = :TITLE)", Dict);
    }

    public static int getStrapsCountU(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(U.ELEMENTS_COUNT) from USP_ASSEMBLY_ELEMENTS U DB_DATA D where D.OBOZN = U.ELEMENTS_NUM and D.GROUP_USP = 4 and ASSEMBLY_ID = (select ID from USP_ASSEMBLIES where NUM = :TITLE)", Dict);
    }

    public static int getNutsCountU(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(U.ELEMENTS_COUNT) from USP_ASSEMBLY_ELEMENTS U DB_DATA D where D.OBOZN = U.ELEMENTS_NUM and D.GROUP_USP = 5 and ASSEMBLY_ID = (select ID from USP_ASSEMBLIES where NUM = :TITLE", Dict);
    }

    public static int getSpecialElementsCountU(string assemblyTitle)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assemblyTitle);

        return SQLOracle.selectInt("select sum(U.ELEMENTS_COUNT) from USP_ASSEMBLY_ELEMENTS U DB_DATA D where D.OBOZN = U.ELEMENTS_NUM and D.KATALOG_USP = 2 and ASSEMBLY_ID = (select ID from USP_ASSEMBLIES where NUM = :TITLE", Dict);
    }






    public static string test1(string assTitle)
    {
        string cmdQuery = "select NMF from KTC.model_attr20 where HD = :PARENT_TITLE";
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("PARENT_TITLE", assTitle);

        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    public static string test2(string assTitle)
    {
        string cmdQuery = "select NMF from KTC.model_attr20 where HD = '"+assTitle+"'";
        MessageBox.Show(cmdQuery+'\n'+"select NMF from KTC.model_attr20 where HD = 'USP_test_47601.0220.551.000'");


        return SQLOracle.selectStr(cmdQuery);
    }

    public static string test3(string assTitle)
    {
        string cmdQuery = "select NMF from KTC.model_attr20 where HD = 'USP_test_47601.0220.551.000'";

        return SQLOracle.selectStr(cmdQuery);
    }
}
