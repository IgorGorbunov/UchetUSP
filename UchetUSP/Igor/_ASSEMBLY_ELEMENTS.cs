using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

/// <summary>
/// Класс со связями элементов УСП со сборкой без проектирования ВПП
/// </summary>
class _ASSEMBLY_ELEMENTS
{
    static string _table = "USP_ASSEMBLY_ELEMENTS";

    /// <summary>
    /// Возвращает максимальный id сборки
    /// </summary>
    /// <returns></returns>
    public static int getMaxAssId()
    {
        return SQLOracle.getMaxIndexInt("ASSEMBLY_ID", _table);
    }

    /// <summary>
    /// Возвращает элементы по id сборки
    /// </summary>
    /// <param name="assId">id сборки</param>
    /// <returns></returns>
    public static Dictionary<string, string> getElementsDict(int assId)
    {
        Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
        ParamsDict.Add("ASSEMBLY_ID", assId.ToString());

        return SQLOracle.selectDictStr("select ELEMENT_NUM, ELEMENTS_COUNT from " + _table + " where ASSEMBLY_ID = :ASSEMBLY_ID", ParamsDict);
    }

    /// <summary>
    /// Метод возвращает таблицу с элементами из сборки УСПО с их количеством
    /// </summary>
    /// <param name="assId">id УСПО</param>
    /// <returns></returns>
    public static DataTable getElementsDT(int assId)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("ID", assId.ToString());

        string cmdQuery = "select ELEMENT_NUM, ELEMENTS_COUNT from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID";
        DataTable DT = SQLOracle.getDT(cmdQuery, Dict);
        DT.Columns[0].ColumnName = "Обозначение";
        DT.Columns[1].ColumnName = "Кол-во";

        return DT;
    }
}