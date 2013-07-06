using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ����� ��� ����������� ������ �� �� ����� ���
/// </summary>
class _VPP_TZ
{
    /// <summary>
    /// ����� ���������� ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="num">����� ��</param>
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
    /// ����� ���������� ����� ����������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ��� ������������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� �������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ������ (�����������) �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ������������ �������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ����������� �������� �� ������ ���
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <returns></returns>
    public static string getEquipTitle(string VPPNum)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VPP_NUM", VPPNum);

        string cmdQuery = "select OB_O from VPP_POZ20 where N_VD = :VPP_NUM";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }

    /// <summary>
    /// ����� ���������� ����� ��������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ����� �� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ������������ �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ��� ������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ����������� ���������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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
    /// ����� ���������� ����� ���� ��������� �� ������ ��� � ������� ��
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� ��</param>
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

