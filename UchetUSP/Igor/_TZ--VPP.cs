using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ����� � ��������� � �� ��� ���
/// </summary>
class _TZ__VPP
{
    /// <summary>
    /// ����� ���������� ����������� ������� ����
    /// </summary>
    /// <param name="id">������������� ��</param>
    /// <returns></returns>
    public static string getEquipTitle(string id)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("ID", id);

        string cmdQuery = "select OBOZN_UPTO from USP_TZ_DATA where ID_DOC = :ID";
        return SQLOracle.selectStr(cmdQuery, Dict);
    }
}
