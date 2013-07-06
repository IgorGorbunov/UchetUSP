using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ����� � ��������� � �������������
/// </summary>
class _USR
{
    /// <summary>
    /// ����� ���������� ������� �������� ������������
    /// </summary>
    /// <returns></returns>
    public static string getCurrSurname()
    {
        string connection = UchetUSP.Program.ConnectionString;
        string[] split = connection.Split('/');
        string login = split[0];

        return getSurname(login);
    }

    static string getSurname(string login)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("LOGIN", login);

        return SQLOracle.sel("select FAM from PDM_USR where USR = :LOGIN", Dict).ToString();
    }
}

