using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Класс для возвращения данных по ТЗ через ВПП
/// </summary>
class _VPP_TZ
{
    /// <summary>
    /// Метод возвращает позицию ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="num">Номер ТЗ</param>
    /// <returns></returns>
    public static int getPosition(string VPPNum, string num)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", num);

        string cmdQuery = "select POZ from VPP_TZ20 where N_VD = :VPP_NUM and N_TZ = :POS";
        return SQLOracle.selectInt(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает места базирования по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getBasing(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select BAZ from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает код классфикатора по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getClassCode(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select KOD_O from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает поставку по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getDelivery(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select POST from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает чертеж (обозначение) по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getDrawning(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select CH from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает наименование оснастки по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getEquipName(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select NM from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает обозначение оснастки по номеру ВПП
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <returns></returns>
    public static string getEquipTitle(string VPPNum)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);

        string cmdQuery = "select OB_O from VPP_POZ20 where N_VD = :VPP_NUM";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает места обработки по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getManufactLocation(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select OBRAB from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает номер ТЗ по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getNum(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select N_TZ from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает оборудование по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getPlantList(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select TP from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает код изделия по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getProductCode(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select KI from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает технические требования по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static string getTechRequirements(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select TT from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает очередь по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static int getQueue(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select OCH_O from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectInt(cmdQuery, Dict);
    }

    /// <summary>
    /// Метод возвращает номер цеха заказчика по номеру ВПП и позиции ТЗ
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ</param>
    /// <returns></returns>
    public static int getWorkshopCode(string VPPNum, int pos)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);
        Dict.Add("POS", pos.ToString());

        string cmdQuery = "select CE from VPP_TZ20 where N_VD = :VPP_NUM and POZ = :POS";
        return SQLOracle.selectInt(cmdQuery, Dict);
    }
}

