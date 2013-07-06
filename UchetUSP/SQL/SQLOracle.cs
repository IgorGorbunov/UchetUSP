using System;  
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using UchetUSP.LOG;
using UchetUSP.DifferentCalsses;

/// <summary>
/// ����� � ���������������� �������� ����������, �������� �������� � ���� Oracle
/// </summary>
class SQLOracle
{
    public static string _user = "";
    static string _password = "";
    static string _dataSource = "";

    static string _connectionString;

    static void ConfigureConnectionString()
    {
        char[] conSplit = {'/','@'};

        string[] conString = UchetUSP.Program.ConnectionString.Split(conSplit);

        if (conString.Length >= 2)
        { 
            _user = conString[0];
            _password = conString[1];
            _dataSource = conString[2];

            BuildConnectionString(_user, _password, _dataSource);
        }
    }

    public static string GetCurrentUser()
    {
        char[] conSplit = { '/', '@' };

        string[] conString = UchetUSP.Program.ConnectionString.Split(conSplit);

        string user = "";

        if (conString.Length >= 2)
        {
            user = conString[0];  
        }

        return user;
    }


    static void BuildConnectionString(string user,string password,string dataSource)
    {
        _connectionString = "User id=" + user +
                                             ";password=" + password +
                                             ";Data Source = " + dataSource;
    }



    /*static string _connectionString = "User id=" + _user + 
                                      ";password=" + _password +
                                      ";Data Source = " + _dataSource;*/

    //("User id=PROG;password=591000;Data Source = (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = tiger-ad37ad0d2)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = USP) ))"); // ����������

    //("User id = 591014; password = 591000; Data Source = eoi");
    //("User id=PROG;password=591000;Data Source = (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = tiger-ad37ad0d2)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = USP) ))"); // ����������


    //static  OracleConnection _conn = new  OracleConnection("User id=591014;password=591000;Data Source = (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.6.4.250)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = eoi) ))");

   
    static  OracleConnection _conn;
    static void _open()
    {
        try
        {
            ConfigureConnectionString();
            _conn = new  OracleConnection(_connectionString);
            _conn.Open();
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.ToString());
        }
    }
    static void _close()
    {
        _conn.Close();
    }

    

    public static bool connect(string login, string password)
    {
        string parentConnection = _conn.ConnectionString;
        _conn.ConnectionString = @"User Id=`" + login + "`;Password=`" + password +
                _dataSource;

        try
        {
            _open();
            return true;
        }
        catch (System.Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
            return false;
        }
        finally
        {
            _close();
        }
    }

    /// <summary>
    /// ����������� ���� � ������ to_date('����', 'dd.mm.yyyy hh24:mi:ss')
    /// </summary>
    /// <param name="DT">����</param>
    /// <returns></returns>
    public static string getDateTime(DateTime DT)
    {
        string oraDT = DT.ToString();
        return "to_date('" + oraDT + "','dd.mm.yyyy hh24:mi:ss')";
    }


    /// <summary>
    /// ����� ������������ DataSet �� ��������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <returns></returns>
    public static DataSet getDS(string cmdQuery)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            Cmd.CommandType = CommandType.Text;

            OracleDataAdapter DA = new OracleDataAdapter(Cmd);

            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return DS;
    }
    /// <summary>
    /// ����� ������������ DataSet �� ��������� �������������������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Dict">������� � ����������������� �������</param>
    /// <returns></returns>
    public static DataSet getDS(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            Cmd.CommandType = CommandType.Text;

            OracleDataAdapter DA = new OracleDataAdapter(Cmd);

            foreach (KeyValuePair<string, string> pair in ParamsDict)
            {
                DA.SelectCommand.Parameters.AddWithValue(":" + pair.Key, pair.Value);
            }

            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return DS;
    }

    /// <summary>
    /// ���������� ������� � ������������������� select-��������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Dict">Dictioanry � ������������������ �������</param>
    /// <returns></returns>
    public static DataTable getDT(string cmdQuery)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            OracleDataAdapter DA = new OracleDataAdapter(Cmd);
            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        if (DS.Tables.Count == 0)
        {
            return null;
        }
        else
        {
            return DS.Tables[0];
        }
    }
    /// <summary>
    /// ���������� ������� � ������������������� select-��������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Dict">Dictioanry � ������������������ �������</param>
    /// <returns></returns>
    public static DataTable getDT(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            OracleDataAdapter DA = new OracleDataAdapter(Cmd);

            foreach (KeyValuePair<string, string> pair in ParamsDict)
            {
                DA.SelectCommand.Parameters.AddWithValue(":" + pair.Key, pair.Value);
            }

            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        if (DS.Tables.Count == 0)
        {
            return null;
        }
        else
        {
            return DS.Tables[0];
        }
    }


    /// <summary>
    /// �����, ����������� select-������
    /// </summary>
    /// <param name="cmdQuery">SQL-����� �������</param>
    /// <returns></returns>
    public static object sel(string cmdQuery)
    {
        object value = null;
        _open();

        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    value = Reader.GetValue(0);
                }
                catch (InvalidExpressionException) { } //������������ NULL-��������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }
    /// <summary>
    /// �����, ����������� ������������������� select-������
    /// </summary>
    /// <param name="cmdQuery">SQL-����� �������</param>
    /// <param name="ParamsDict">Dictionary c ����������������� �������</param>
    /// <returns></returns>
    public static object sel(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        object value = null;
        _open();

        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                value = Reader.GetValue(0);
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    public static List<int> selectListInt(string cmdQuery)
    {
        System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
                list.Add(System.Int32.Parse(reader.GetValue(0).ToString()));

            reader.Close();
            cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return list;
    }
    public static List<long> selectListLong(string cmdQuery)
    {
        System.Collections.Generic.List<long> list = new System.Collections.Generic.List<long>();

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
                list.Add(System.Int32.Parse(reader.GetValue(0).ToString()));

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return list;
    }
    /// <summary>
    /// ���������� ��������� select-������� � ���� ������ ��������� ����������
    /// </summary>
    /// <param name="cmdQuery">����� sql-�������</param>
    /// <returns></returns>
    public static List<string> selectListStr(string cmdQuery)
    {
        List<string> List = new List<string>();

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
                List.Add(Reader.GetString(0));

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return List;
    }
    /// <summary>
    /// ���������� ��������� select-������� � ���� ������� ��������� ����������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="paramsDict">������� � ����������������� �������</param>
    /// <returns></returns>
    public static Dictionary<string, string> selectDictStr(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        Dictionary<string, string> ResultDict = new Dictionary<string, string>();

        _open();

        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                OracleParameter parametr = new OracleParameter(":" + Pair.Key, Pair.Value);
                Cmd.Parameters.Add(parametr);
            }

            OracleDataReader Reader = Cmd.ExecuteReader();

            string key, value;
            while (Reader.Read())
            {
                key = Reader.GetValue(0).ToString();
                value = Reader.GetValue(1).ToString();
                ResultDict.Add(key, value);
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return ResultDict;
    }

    public static bool selectBool(string cmdQuery)
    {
        bool value = false;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                value = reader.GetBoolean(0);

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    /// <summary>
    /// ����� select-������� ������������� int-���� ��� ����������
    /// </summary>
    /// <param name="sql">��������� ������</param>
    /// <returns></returns>
    public static int selectInt(string cmdQuery)
    {
        Int32 value = 0;
        try
        {
            _open();
        }
        catch (Exception Ex)
        {
            MessageBox.Show(Ex.Message);
        }

        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    string str = Reader.GetValue(0).ToString();
                    value = Int32.Parse(str);
                }
                catch (FormatException) { } //����� ������ ��������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }
    public static int selectInt(string cmdQuery, int nullValue)
    {
        int value = nullValue;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                value = System.Int32.Parse(reader.GetValue(0).ToString());

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }
    /// <summary>
    /// ���������� int �������������������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="ParamsDict">Dictionary � ����������������� �������</param>
    /// <returns></returns>
    public static int selectInt(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        int value = 0;

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    object ob = Reader.GetValue(0);
                    string str = ob.ToString();
                    value = Int32.Parse(str);
                }
                catch (InvalidCastException) { } //����� ������ ��������
                catch (FormatException) {  } //����� ������ select-������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }
    /// <summary>
    /// ���������� int �������������������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="ParamsDict">Dictionary � ����������������� �������</param>
    /// <param name="nullValue">������� ��������</param>
    /// <returns></returns>
    public static int selectInt(string cmdQuery, Dictionary<string, string> ParamsDict, int nullValue)
    {
        int value = nullValue;

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    object ob = Reader.GetValue(0);
                    string str = ob.ToString();
                    value = Int32.Parse(str);
                }
                catch (InvalidCastException) { } //����� ������ ��������
                catch (FormatException) { } //����� ������ select-������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    public static long selectLong(string cmdQuery)
    {
        long value = 0;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                value = System.Int32.Parse(reader.GetValue(0).ToString());

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }
    public static long selectLong(string cmdQuery, long nullValue)
    {
        long value = nullValue;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                value = System.Int32.Parse(reader.GetValue(0).ToString());

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    /// <summary>
    /// ����� select-������� ������������� ��������� ��� ����������
    /// </summary>
    /// <param name="sql">��������� ������</param>
    /// <returns></returns>
    public static string selectStr(string cmdQuery)
    {
        string value = "";

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
                try
                {
                    value = Reader.GetValue(0).ToString();
                }
                catch (InvalidCastException) { } //����� ������ ��������
                catch (InvalidOperationException) { } //����� ������� ��������

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    public static string selectStr(string cmdQuery, string nullValue)
    {
        string value = nullValue;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = cmd.ExecuteReader();

            if (Reader.Read())
                value = Reader.GetValue(0).ToString();

            Reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    /// <summary>
    /// ���������� string �������������������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="ParamsDict">Dictionary � ����������������� �������</param>
    /// <returns></returns>
    public static string selectStr(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        string value = "";

        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    value = Reader.GetValue(0).ToString();
                }
                catch (InvalidCastException) { } //����� ������ ��������
                catch (InvalidOperationException) { } //����� ������� �������� ����
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return value;
    }

    /// <summary>
    /// Select-������ ������������ ���� � �����
    /// </summary>
    /// <param name="cmdQuery">Select-������</param>
    /// <returns></returns>
    public static DateTime selectDate(string cmdQuery)
    {
        DateTime ResultDate = new DateTime(1, 1, 1);
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
                try
                {
                    ResultDate = Reader.GetDateTime(0);
                }
                catch (InvalidOperationException) { } //����� NULL-��������

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return ResultDate;
    }
    /// <summary>
    /// Select-������ ������������ ���� � �����
    /// </summary>
    /// <param name="cmdQuery">Select-������</param>
    /// <param name="ParamsDict">Dictionary c ����������������� �������</param>
    /// <returns></returns>
    public static DateTime selectDate(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        DateTime ResultDate = new DateTime(1, 1, 1);
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }
            OracleDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
                try
                {
                    ResultDate = Reader.GetDateTime(0);
                }
                catch (InvalidOperationException) { } //����� ������ ��������

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return ResultDate;
    }


    /// <summary>
    /// Update-������
    /// </summary>
    /// <param name="cmdQuery">Update-������</param>
    public static void update(string cmdUpdate)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdUpdate, _conn);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdUpdate + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }
    /// <summary>
    /// ������������������� update-������
    /// </summary>
    /// <param name="cmdQuery">update-������</param>
    /// <param name="Dict">Dictionary � ����������������� �������</param>
    public static void update(string cmdUpdate, Dictionary<string, string> ParamsDict)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdUpdate, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdUpdate + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }
    public static void updateDateParams(string cmdUpdate, System.DateTime date, string num)
    {
        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdUpdate, _conn);

            OracleParameter dateParam = new OracleParameter();
            dateParam.DbType = System.Data.DbType.Date;
            dateParam.Value = date;
            dateParam.ParameterName = "date";

            cmd.Parameters.Add(dateParam);
            cmd.Parameters.AddWithValue(":num", num);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdUpdate + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }


    public static void alter(string cmdQuery)
    {
        _open();
        try
        {
            OracleCommand cmdAlter = new OracleCommand(cmdQuery, _conn);

            cmdAlter.ExecuteNonQuery();
            cmdAlter.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }

    /// <summary>
    /// Insert-������
    /// </summary>
    /// <param name="cmdInsert">Insert-������</param>
    public static void insert(string cmdInsert)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdInsert, _conn);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdInsert + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }
    /// <summary>
    /// ������������������� Insert-������
    /// </summary>
    /// <param name="cmdInsert">Insert-������</param>
    /// <param name="Dict">Dictionary c ����������������� �������</param>
    public static void insert(string cmdInsert, Dictionary<string, string> ParamsDict)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdInsert, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdInsert + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }

    /// <summary>
    /// ����� delete-�������
    /// </summary>
    /// <param name="cmdQuery">SQL ����� delete-�������</param>
    public static void delete(string cmdQuery)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }
    /// <summary>
    /// ����� �������������������� delete-�������
    /// </summary>
    /// <param name="cmdQuery">SQL ����� delete-�������</param>
    /// <param name="ParamsDict">Dictionary � �����������������</param>
    public static void delete(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        _open();
        try
        {
            OracleCommand Cmd = new OracleCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            string mess = cmdQuery + "\n";
            mess += "Parametrs:" + "\n";

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            mess += Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }
    }

    public static bool isVoid(string table)
    {
        bool flag = true;
        string cmdQuery = "select * from " + table;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                flag = false;
            else
                flag = true;

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return flag;
    }
    public static bool exist(string table, string where)
    {
        bool flag = false;
        string cmdQuery = "select * from " + table + " where " + where;

        _open();
        try
        {
            OracleCommand cmd = new OracleCommand(cmdQuery, _conn);
            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception Ex)
        {
            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);
        }
        finally
        {
            _close();
        }

        return flag;
    }

    /// <summary>
    /// M���� ���������� true, ���� �������� � ��������������� ���� � ������� �������
    /// </summary>
    /// <param name="value">��������</param>
    /// <param name="column">����</param>
    /// <param name="table">�������</param>
    /// <returns></returns>
    public static bool exist(object value, string column, string table)
    {
        Dictionary<string, string> Dict = new Dictionary<string, string>();
        Dict.Add("VALUE", value.ToString());

        object val = sel("select " + column + " from " + table + " where " +
            column + " = :VALUE", Dict);
        
        if (val == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static int countInt(string table)
    {
        return selectInt("select COUNT(ID) from " + table);
    }
    public static long countLong(string table)
    {
        return selectLong("select COUNT(ID) from " + table);
    }

    /// <summary>
    /// ����� ���������� ���������� ��������� ����� �� �������� ������� �� ��������� �������
    /// </summary>
    /// <param name="table">������������ �������</param>
    /// <param name="where">������� ��� ��������� ����� WHERE</param>
    public static int countInt(string table, string where)
    {
        return selectInt("select COUNT (*) from " + table + " where " + where);
    }
    /// <summary>
    /// ����� ���������� ���������� ��������� ����� �� �������� ������� �� ��������� �������������������� �������
    /// </summary>
    /// <param name="table">������������ �������</param>
    /// <param name="where">������� ��� ��������� ����� WHERE</param>
    /// <param name="ParamsDict">Dictionary � �����������������</param>
    public static int countInt(string table, string where, Dictionary<string, string> ParamsDict)
    {
        return selectInt("select COUNT (*) from " + table + " where " + where, ParamsDict);
    }

    public static long countLong(string table, string where)
    {
        return selectLong("select COUNT(ID) from " + table + " where " + where);
    }

    public static int countIntDist(string table, string fieldDistinct)
    {
        return selectInt("select COUNT(DISTINCT " + fieldDistinct + ") from " + table);
    }
    public static long countLongDist(string table, string fieldDistinct)
    {
        return selectLong("select COUNT(DISTINCT " + fieldDistinct + ") from " + table);
    }

    public static int getMaxIndexInt(string field, string table)
    {
        return selectInt("select MAX(" + field + ") from " + table);
    }
    public static int getMinIndexInt(string field, string table)
    {
        return selectInt("select MIN(" + field + ") from " + table);
    } 

    //������������������� ������ � n-����������� ����������

    static private  OracleDataAdapter oracleDataAdapter1;

    static private System.Data.DataSet dataSet11;

    static private  OracleCommand oracleSelectCommand1;

    static private  OracleCommand oracleInsertCommand1;

    static private  OracleCommand oracleUpdateCommand1;

    static private  OracleDataReader reader;


    /// <summary>
    /// ���������� ��������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="TheFirstParametr">��������</param>
    /// <returns></returns>
    public static Image getBlobImageWithBuffer(string cmdQuery, string TheFirstParametr)
    {

        Image returnImage = null;

        initObjectsForSelectQuery();

        try
        {
            int PictureCol = 0;


            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new  OracleParameter(":OBOZN", TheFirstParametr));


            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Connection.Open();

            reader = oracleSelectCommand1.ExecuteReader();

            
            reader.Read();

            Byte[] b = null;
            try
            {
                b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(PictureCol, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(PictureCol, 0, b, 0, b.Length);

                oracleSelectCommand1.Connection.Close();

                System.IO.MemoryStream str = new System.IO.MemoryStream(b);

                str.Write(b, 0, b.Length);

                returnImage = System.Drawing.Image.FromStream(str);

                IDisposable d = (IDisposable)str;

                str.Close();

                d.Dispose();
            }
            catch (InvalidOperationException) { } //���� ��� �������


        }
        catch (Exception Ex)
        {
            oracleSelectCommand1.Connection.Close();

            string mess = cmdQuery + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);

            returnImage = null;
        }
        finally
        {
            reader.Close();
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }


        return returnImage;

    }


    /// <summary>
    /// ����� ���������� ���� � �����
    /// </summary>
    /// <param name="VPPNum">����� ���</param>
    /// <param name="pos">������� �� � ���</param>
    /// <returns></returns>
    public static bool getTZSketch(string VPPNum, int pos)
    {

        bool hasSketch = false;

        initObjectsForSelectQuery();

        try
        {
            int PictureCol = 0;


            oracleSelectCommand1.CommandText = "select TZ_BL from VPP_TZ20 where N_VD = '" + VPPNum + "' and POZ = " + pos;

            oracleSelectCommand1.Connection.Open();

            reader = oracleSelectCommand1.ExecuteReader();

            if (reader.Read())
            {
                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(PictureCol, 0, null, 0, System.Int32.MaxValue)))];

                if (b.Length > 0)
                {
                    reader.GetBytes(PictureCol, 0, b, 0, b.Length);

                    oracleSelectCommand1.Connection.Close();

                    System.IO.MemoryStream str = new System.IO.MemoryStream(b);

                    str.Write(b, 0, b.Length);

                    string filePath = UchetUSP.Program.PathString + @"/" + VPPNum + "-" + pos + ".xls";
                    System.IO.File.WriteAllBytes(filePath, b);
                    hasSketch = true;

                    IDisposable d = (IDisposable)str;

                    str.Close();

                    d.Dispose();

                    str.Dispose();
                }
            }

        }
        catch (Exception Ex)
        {
            oracleSelectCommand1.Connection.Close();

            hasSketch = false;

            string mess = oracleSelectCommand1.CommandText + "\n" + Ex.ToString();
            MessageBox.Show(mess);
            Log.WriteLog(mess);

        }
        finally
        {
            reader.Close();
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }


        return hasSketch;

    }










    //������������� �������� ��� �������������������� SELECT

    static private void initObjectsForSelectQuery()
    {
        ConfigureConnectionString();

        oracleDataAdapter1 = new  OracleDataAdapter();

        _conn = new  OracleConnection(_connectionString);

        dataSet11 = new System.Data.DataSet();

        oracleSelectCommand1 = new  OracleCommand();

        oracleDataAdapter1.SelectCommand = oracleSelectCommand1;

        oracleSelectCommand1.Connection = _conn;


    }


    //������������� �������� ��� �������������������� INSERT

    static private void initObjectsForInsertQuery()
    {
        ConfigureConnectionString();

        oracleDataAdapter1 = new  OracleDataAdapter();

        _conn = new  OracleConnection(_connectionString);

        dataSet11 = new System.Data.DataSet();

        oracleInsertCommand1 = new  OracleCommand();

        oracleDataAdapter1.InsertCommand = oracleInsertCommand1;

        oracleInsertCommand1.Connection = _conn;
    }

    //������������� �������� ��� �������������������� UPDATE

    static private void initObjectsForUpdateQuery()
    {
        ConfigureConnectionString();

        oracleDataAdapter1 = new  OracleDataAdapter();

        _conn = new  OracleConnection(_connectionString);

        dataSet11 = new System.Data.DataSet();

        oracleUpdateCommand1 = new  OracleCommand();

        oracleDataAdapter1.UpdateCommand = oracleUpdateCommand1;

        oracleUpdateCommand1.Connection = _conn;
    }


    //���������� �������� �������������������� Select

    static private void disposeObjectsForSelectQuery()
    {
       
        oracleDataAdapter1.Dispose();

        _conn.Dispose();

        dataSet11.Dispose();

        oracleSelectCommand1.Dispose();

    }

    //���������� �������� �������������������� Insert

    static private void disposeObjectsForInsertQuery()
    {
        
        oracleDataAdapter1.Dispose();

        _conn.Dispose();

        dataSet11.Dispose();

        oracleInsertCommand1.Dispose();

    }

    //���������� �������� �������������������� Update

    static private void disposeObjectsForUpdateQuery()
    {
       

        oracleDataAdapter1.Dispose();

        _conn.Dispose();

        dataSet11.Dispose();

        oracleUpdateCommand1.Dispose();

    }

    static public System.Data.DataSet ParamQuerySelect(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox)
    {

        initObjectsForSelectQuery();


        try
        {
            oracleSelectCommand1.Connection.Open();

            oracleDataAdapter1.SelectCommand.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                oracleDataAdapter1.SelectCommand.Parameters.Add(new  OracleParameter((string)(":" + Parameters[i].ToString()), (string)("%" + DataFromTextBox[i].ToString() + "%")));
            }

            if (dataSet11.Tables.Count > 0)
            {
                dataSet11.Tables[0].Clear();
            }

            oracleDataAdapter1.Fill(dataSet11);

            oracleSelectCommand1.Connection.Close();

            return dataSet11;

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleSelectCommand1.Connection.Close();

            Log.WriteLog(ex);

            return dataSet11;
        }
        finally
        {
            disposeObjectsForSelectQuery();
        }

    }


    static public System.Data.DataSet ParamQuerySelectNonPercent(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox)
    {

        initObjectsForSelectQuery();


        try
        {
            oracleSelectCommand1.Connection.Open();

            oracleDataAdapter1.SelectCommand.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                oracleDataAdapter1.SelectCommand.Parameters.Add(new OracleParameter((string)(":" + Parameters[i].ToString()), (string)(DataFromTextBox[i].ToString())));
            }

            if (dataSet11.Tables.Count > 0)
            {
                dataSet11.Tables[0].Clear();
            }

            oracleDataAdapter1.Fill(dataSet11);

            oracleSelectCommand1.Connection.Close();

            return dataSet11;

        }
        catch (OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleSelectCommand1.Connection.Close();

            Log.WriteLog(ex);

            return dataSet11;
        }
        finally
        {
            disposeObjectsForSelectQuery();
        }

    }

    static public System.Data.DataSet ParamQuerySelectNonPercent(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox,System.Collections.Generic.List<string> TypeVar)
    {

        initObjectsForSelectQuery();


        try
        {
            oracleSelectCommand1.Connection.Open();

            oracleDataAdapter1.SelectCommand.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                if(String.Compare(TypeVar[i],"int")==0)
                {                  
                    oracleDataAdapter1.SelectCommand.Parameters.Add(new OracleParameter((string)(":" + Parameters[i].ToString()), Convert.ToInt32(DataFromTextBox[i])));
                }
                else if (String.Compare(TypeVar[i], "string") == 0)
                {
                    oracleDataAdapter1.SelectCommand.Parameters.Add(new OracleParameter((string)(":" + Parameters[i].ToString()), (string)(DataFromTextBox[i].ToString())));
                }
                
            }

            if (dataSet11.Tables.Count > 0)
            {
                dataSet11.Tables[0].Clear();
            }

            oracleDataAdapter1.Fill(dataSet11);

            oracleSelectCommand1.Connection.Close();

            return dataSet11;

        }
        catch (OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleSelectCommand1.Connection.Close();

            Log.WriteLog(ex);

            return dataSet11;
        }
        finally
        {
            disposeObjectsForSelectQuery();
        }

    }

    //������ �� ������������������� ������� � ��������� �������� (����������� ������)

    static public void SpecificInsertQuery(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox, byte[] BMPInByte)
    {
        initObjectsForInsertQuery();

        try
        {
            oracleInsertCommand1.Connection.Open();

            oracleInsertCommand1.CommandText = cmdQuery;

            oracleInsertCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                oracleInsertCommand1.Parameters.Add(new  OracleParameter((string)(":" + Parameters[i].ToString()), DataFromTextBox[i].ToString()));
            }


            oracleInsertCommand1.Parameters.Add(new  OracleParameter(":DET",  OracleType.Blob, BMPInByte.Length, System.Data.ParameterDirection.Input, false, 0, 0, null, System.Data.DataRowVersion.Current, BMPInByte));


            oracleInsertCommand1.ExecuteNonQuery();

            oracleInsertCommand1.Connection.Close();

            System.Windows.Forms.MessageBox.Show("��������� ������� ��� ������.�������� ������ �������!", "���������!");

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

            oracleInsertCommand1.Connection.Close();
        }
        finally
        {
            disposeObjectsForInsertQuery();
        }





    }



    //������ �� ������������������� ������� 

    static public bool InsertQuery(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox)
    {
        initObjectsForInsertQuery();

        try
        {
            oracleInsertCommand1.Connection.Open();

            oracleInsertCommand1.CommandText = cmdQuery;

            oracleInsertCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                oracleInsertCommand1.Parameters.Add(new  OracleParameter((string)(":" + Parameters[i].ToString()), DataFromTextBox[i].ToString()));
            }
            
            oracleInsertCommand1.ExecuteNonQuery();

            oracleInsertCommand1.Connection.Close();

            return true;

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleInsertCommand1.Connection.Close();

            Log.WriteLog(ex);

            return false;
        }
        finally
        {

            disposeObjectsForInsertQuery();
        }
    }


    //�������� ������������� ������ �� ����, ������� � ���������� �� where

    public static bool exist(string idField, string table, string where)
    {
        bool flag = false;

        _open();

        try
        {
            string cmdQuery = "select " + idField + " from " + table + " where " + where;

             OracleCommand cmd = new  OracleCommand(cmdQuery, _conn);
             OracleDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();
            cmd.Dispose();
            reader.Dispose();
        }
        catch (System.Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());

            Log.WriteLog(e);

        }
        finally
        {
            _close();
        }

        return flag;
    }

    //������� �������������������� ������� �� �������� ������� ������ � �������

    public static bool existParamQuery(string id, string table, string parametr, string value)
    {
        bool flag = false;

        initObjectsForSelectQuery();

        try
        {
            string cmdQuery = "select " + id + " from " + table + " where " + parametr + " = :" + parametr;

            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new  OracleParameter((string)(":" + parametr), value));

            reader = oracleSelectCommand1.ExecuteReader();



            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();


        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }

        return flag;
    }


    

    //������� �������������������� ������� �� �������� ������� ������ � �������

    public static bool existParamQuery(string id, string table, string SQLParametr, string CSharpParametr, string value)
    {
        bool flag = false;

        initObjectsForSelectQuery();

        try
        {
            string cmdQuery = "select " + id + " from " + table + " where " + SQLParametr + " = :" + CSharpParametr;

            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new OracleParameter((string)(":" + CSharpParametr), value));

            reader = oracleSelectCommand1.ExecuteReader();



            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();


        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }

        return flag;
    }


   


    //������� �������������������� ������� �� ��������� ����� ������

    public static System.Collections.Generic.List<string> GetInformationListWithParamQuery(string id, string table, string parametr, string value)
    {
        System.Collections.Generic.List<string> AcquiredInformation = new System.Collections.Generic.List<string>();

        initObjectsForSelectQuery();

        try
        {
            string cmdQuery = "select " + id + " from " + table + " where " + parametr + " = :" + parametr;

            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new  OracleParameter((string)(":" + parametr), value));

            reader = oracleSelectCommand1.ExecuteReader();


            while (reader.Read())
            {
                AcquiredInformation.Add(reader.GetString(0));
            }

            reader.Close();

            oracleSelectCommand1.Connection.Close();
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }

        return AcquiredInformation;
    }




    /// <summary>
    /// �������� ������� � TEMP
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public string UnloadPartToTEMPFolder(string obonachenie)
    {

        System.Collections.Generic.List<string> AcquiredInformation = new System.Collections.Generic.List<string>();

        initObjectsForSelectQuery();


        try
        {
            System.String[] Path = { System.IO.Path.GetTempPath(), "\\", obonachenie, ".prt" };

            System.String Path_dir = System.String.Concat(Path);


            if (!System.IO.File.Exists(Path_dir))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT BL FROM FILE_BLOB21 WHERE NMF = :NMF";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new  OracleParameter(":NMF", (string)(obonachenie + ".prt")));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(Path_dir, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return Path_dir;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }


    /// <summary>
    /// �������� ������� ��� 20 � TEMP
    /// </summary>
    /// <param name="HD">����������� NMF</param>
    /// <returns></returns>
    static public string UnloadOsnasToTEMPFolderFile20(string NMF)
    {

        initObjectsForSelectQuery();

        try
        {
            UnloadPartToPAthFolderFile_blob20(NMF.Trim());

            System.Collections.Generic.List<string> ChildrenList;

            if (SQLOracle.existParamQuery("NMF", "MODEL_STRUCT20", "NMF", NMF))
            { 
              ChildrenList = SQLOracle.GetInformationListWithParamQuery("NMF", "MODEL_STRUCT20", "PARENT", NMF);
               
                for (int i = 0; i < ChildrenList.Count; i++)
                {               
                    UnloadPartToPAthFolderFile_blob20(ChildrenList[i].Trim());
                }
            }
            

            return UchetUSP.Program.PathString + "\\" + NMF;
        }
        catch (Exception ex)
        {
            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }



    /// <summary>
    /// �������� ��������� ������� �������� � TEMP file_blob20
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public string UnloadPartToPAthFolderFile_blob20(string obonachenie)
    {
        
        initObjectsForSelectQuery();


        try
        {
            System.String[] Path = { UchetUSP.Program.PathString, "\\", obonachenie };

            System.String Path_dir = System.String.Concat(Path);

           
            if (!System.IO.File.Exists(Path_dir))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT BL FROM FILE_BLOB20 WHERE NMF = :NMF";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new OracleParameter(":NMF", obonachenie));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(Path_dir, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return Path_dir;
        }
        catch (Exception ex)
        {
            //System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }

    /// <summary>
    /// �������� �������� � TEMP
    /// </summary>
    /// <param name="HD">����������� ��������</param>
    /// <returns></returns>
    static public string UnloadOsnasToTEMPFolder(string NUM, string POZ)
    {
                
        initObjectsForSelectQuery();

        try
        {


            string OBOZN = ParamQuerySelect("SELECT OB_O FROM VPP_POZ20 WHERE N_VD = :N_VD AND POZ = '" + POZ.Trim() + "' ", "N_VD", NUM);
                       
            string NMF = ParamQuerySelect("SELECT NMF FROM MODEL_ATTR20 WHERE HD = :HD", "HD", OBOZN.Trim());
                          
          
            System.Collections.Generic.List<string> ChildrenList = SQLOracle.GetInformationListWithParamQuery("NMF", "MODEL_STRUCT20", "PARENT", NMF);

           
            UnloadPartToPAthFolder(NMF.Trim());
            UnloadPartToPAthFolderFileBlob(NMF.Trim());

            for (int i = 0; i < ChildrenList.Count; i++)
			{
                UnloadPartToPAthFolder(ChildrenList[i].Trim());
                UnloadPartToPAthFolderFileBlob(ChildrenList[i].Trim());
            }

            return UchetUSP.Program.PathString + "\\" + NMF;
        }
        catch (Exception ex)
        {     
            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }


    /// <summary>
    /// �������� ��������� ������� �������� � TEMP file_blob00
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public string UnloadPartToPAthFolder(string obonachenie)
    {
             
        initObjectsForSelectQuery();


        try
        {
            System.String[] Path = { UchetUSP.Program.PathString, "\\", obonachenie };

            System.String Path_dir = System.String.Concat(Path);


            if (!System.IO.File.Exists(Path_dir))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT BL FROM FILE_BLOB20 WHERE NMF = :NMF";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new OracleParameter(":NMF", obonachenie));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(Path_dir, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return Path_dir;
        }
        catch (Exception ex)
        {
            //System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }

    /// <summary>
    /// �������� ��������� ������� �������� � TEMP file_blob
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public string UnloadPartToPAthFolderFileBlob(string obonachenie)
    {

        initObjectsForSelectQuery();


        try
        {
            System.String[] Path = { UchetUSP.Program.PathString, "\\", obonachenie };

            System.String Path_dir = System.String.Concat(Path);


            if (!System.IO.File.Exists(Path_dir))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT BL FROM FILE_BLOB WHERE NMF = :NMF";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new OracleParameter(":NMF", obonachenie));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(Path_dir, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return Path_dir;
        }
        catch (Exception ex)
        {
            //System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return "0";
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }




    public static System.Drawing.Image getBlobImageWithBuffer(string cmdQuery, string TheFirstParametr, string TheSecondParametr, string TheThirdParametr)
    {

        System.Drawing.Image returnImage;

        initObjectsForSelectQuery();

        try
        {
            int PictureCol = 0;


            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new  OracleParameter(":NAME", TheFirstParametr));

            oracleSelectCommand1.Parameters.Add(new OracleParameter(":GOST", TheSecondParametr));

            oracleSelectCommand1.Parameters.Add(new OracleParameter(":OBOZN", TheThirdParametr));

           



            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Connection.Open();

            reader = oracleSelectCommand1.ExecuteReader();

            reader.Read();

            System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(PictureCol, 0, null, 0, System.Int32.MaxValue)))];

            reader.GetBytes(PictureCol, 0, b, 0, b.Length);

            oracleSelectCommand1.Connection.Close();

            System.IO.MemoryStream str = new System.IO.MemoryStream(b);

            str.Write(b, 0, b.Length);

            returnImage = System.Drawing.Image.FromStream(str);

            IDisposable d = (IDisposable)str;

            str.Close();

            d.Dispose();




        }
        catch (Exception ex)
        {
            oracleSelectCommand1.Connection.Close();

            returnImage = null;

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Close();
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }


        return returnImage;

    }


    //������ �� ������������������� ������� 

    static public bool UpdateQuery(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox)
    {
        initObjectsForUpdateQuery();

        try
        {
            oracleUpdateCommand1.Connection.Open();

            oracleUpdateCommand1.CommandText = cmdQuery;

            oracleUpdateCommand1.Parameters.Clear();

            for (int i = 0; i < Parameters.Count; i++)
            {
                oracleUpdateCommand1.Parameters.Add(new  OracleParameter((string)(":" + Parameters[i].ToString()), DataFromTextBox[i].ToString()));
            }
            
            oracleUpdateCommand1.ExecuteNonQuery();

            oracleUpdateCommand1.Connection.Close();
           
            return true;

        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleUpdateCommand1.Connection.Close();

            Log.WriteLog(ex);

            return false;
        }
        finally
        {
            disposeObjectsForUpdateQuery();

        }


    }

    //������ �� ������������������� ������� � ��������� �������� (����������� ������)

    static public void SpecificUpdateQuery(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox, byte[] BMPInByte)
    {
        initObjectsForUpdateQuery();

        try
        {
            oracleUpdateCommand1.Connection.Open();

            oracleUpdateCommand1.CommandText = cmdQuery;

            oracleUpdateCommand1.Parameters.Clear();

            for (int i = 0; i < (Parameters.Count - 1); i++)
            {
                oracleUpdateCommand1.Parameters.Add(new  OracleParameter((string)(":" + Parameters[i].ToString()), DataFromTextBox[i].ToString()));
            }


            oracleUpdateCommand1.Parameters.Add(new OracleParameter(":DET", OracleType.Blob, BMPInByte.Length, System.Data.ParameterDirection.Input, false, 0, 0, null, System.Data.DataRowVersion.Current, BMPInByte));

            oracleUpdateCommand1.Parameters.Add(new  OracleParameter((string)(":" + Parameters[(Parameters.Count - 1)].ToString()), DataFromTextBox[(Parameters.Count - 1)].ToString()));

            oracleUpdateCommand1.ExecuteNonQuery();

            oracleUpdateCommand1.Connection.Close();

            System.Windows.Forms.MessageBox.Show("��������� ������� ��� ������.���������� ������ ������ �������!", "���������!");

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleUpdateCommand1.Connection.Close();

            Log.WriteLog(ex);
        }
        finally
        {
            disposeObjectsForUpdateQuery();
        }

    }

    //�������� BLBO ��������
    static public bool BLOBUpdateQuery(string cmdQuery, string Parameters, byte[] BMPInByte)
    {
        initObjectsForUpdateQuery();

        try
        {
            oracleUpdateCommand1.Connection.Open();

            oracleUpdateCommand1.CommandText = cmdQuery;

            oracleUpdateCommand1.Parameters.Clear();


            oracleUpdateCommand1.Parameters.Add(new OracleParameter((":" + Parameters), OracleType.Blob, BMPInByte.Length, System.Data.ParameterDirection.Input, false, 0, 0, null, System.Data.DataRowVersion.Current, BMPInByte));

            oracleUpdateCommand1.ExecuteNonQuery();

            oracleUpdateCommand1.Connection.Close();            

            return true;

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleUpdateCommand1.Connection.Close();
            Log.WriteLog(ex);

            return false;
        }
        finally
        {
            disposeObjectsForUpdateQuery();
        }

    }


    /// <summary>
    /// ��������� ����������� �� ��
    /// </summary>
    /// <returns></returns>
    public static System.Drawing.Image getBlobImage(string cmdQuery)
    {

        System.Drawing.Bitmap returnImage = null;

        initObjectsForSelectQuery();

        try
        {
            int PictureCol = 0;


            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Connection.Open();

            reader = oracleSelectCommand1.ExecuteReader();

            if (reader.Read())
            { 
                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(PictureCol, 0, null, 0, System.Int32.MaxValue)))];
                            
                reader.GetBytes(PictureCol, 0, b, 0, b.Length);
                
                oracleSelectCommand1.Connection.Close();
                  
                System.IO.MemoryStream str = new System.IO.MemoryStream(b);
                     
                str.Write(b, 0, b.Length);
                   
                returnImage = (Bitmap)System.Drawing.Image.FromStream(str);

                IDisposable d = (IDisposable)str;

                str.Close();

                d.Dispose();

                str.Dispose();
            
            }

        }
        catch (Exception ex)
        {
            
            oracleSelectCommand1.Connection.Close();

            returnImage = null;

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Close();
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }


        return returnImage;

    }

    /// <summary>
    /// ����� ������������ string �������� ����� ������������������ ������ � ��������� ��������� Where
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Parameters">�������� ���������</param>
    /// <param name="DataFromTextBox">�������� ���������</param>
    /// <returns></returns>
    static public string ParamQuerySelect(string cmdQuery, string Parameters, string DataFromTextBox)
    {

        initObjectsForSelectQuery();

        string value = "";

        try
        {
            
            oracleSelectCommand1.Connection.Open();

            oracleDataAdapter1.SelectCommand.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleDataAdapter1.SelectCommand.Parameters.Add(new  OracleParameter((string)(":" + Parameters), DataFromTextBox));
          
            reader = oracleSelectCommand1.ExecuteReader();


            if (reader.Read())
                try
                {                    
                     value = reader.GetString(0);
                }
                catch (InvalidCastException) { } //����� ������ ��������
                catch (InvalidOperationException) { } //����� ������� �������� ����

            reader.Close();           

            oracleSelectCommand1.Connection.Close();           

            return value;

        }
        catch ( OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleSelectCommand1.Connection.Close();
            
            Log.WriteLog(ex);

            return value;
        }
        finally
        {
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }

    }



    /// <summary>
    /// ����� ������������ ������ ������� � ���� List
    /// </summary>
    /// <param name="id">���� Select</param>
    /// <param name="table">������� ��</param>
    /// <param name="parametr">�������� ������� Where</param>
    /// <param name="value">�������� ������� Where</param>
    /// <returns></returns>
    public static System.Collections.Generic.List<string> GetStrFromBD(string id, string table, string parametr, string value)
    {
        System.Collections.Generic.List<string> AcquiredInformation = new System.Collections.Generic.List<string>();

        initObjectsForSelectQuery();

        try
        {
            string cmdQuery = "select " + id + " from " + table + " where " + parametr + " = :" + parametr;

            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleSelectCommand1.Parameters.Add(new  OracleParameter((string)(":" + parametr), value));

            reader = oracleSelectCommand1.ExecuteReader();


            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount;i++ )
                    AcquiredInformation.Add(reader.GetString(i));
            }

            reader.Close();

            oracleSelectCommand1.Connection.Close();
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }

        return AcquiredInformation;
    }


    /// <summary>
    /// ��������� ����������� �� ��
    /// </summary>
    /// <returns></returns>
    public static string LoadImageToTemp(string cmdQuery)
    {

        string returnImage = null;

        initObjectsForSelectQuery();

        try
        {
            int PictureCol = 0;


            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Connection.Open();

            reader = oracleSelectCommand1.ExecuteReader();

            if (reader.Read())
            {
                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(PictureCol, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(PictureCol, 0, b, 0, b.Length);

                oracleSelectCommand1.Connection.Close();

                System.IO.MemoryStream str = new System.IO.MemoryStream(b);

                str.Write(b, 0, b.Length);

                using (TemporaryFile tempFile = new TemporaryFile())
                {
                    returnImage = tempFile.FilePath.ToString();
                }

                System.Drawing.Image.FromStream(str).Save(returnImage);

                IDisposable d = (IDisposable)str;

                str.Close();

                d.Dispose();

                str.Dispose();

            }

        }
        catch (Exception ex)
        {

            oracleSelectCommand1.Connection.Close();

            returnImage = null;

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Close();
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }


        return returnImage;

    }


    /// <summary>
    /// ����� ������������ ������ ������� � ���� List (�� ������������������)
    /// </summary>
    /// <param name="id">���� Select</param>
    /// <param name="table">������� ��</param>
    /// <param name="parametr">�������� ������� Where</param>
    /// <param name="value">�������� ������� Where</param>
    /// <returns></returns>
    public static System.Collections.Generic.List<string> GetStrFromBDNonParam(string cmd)
    {
        System.Collections.Generic.List<string> AcquiredInformation = new System.Collections.Generic.List<string>();

        initObjectsForSelectQuery();

        try
        {
            string cmdQuery = cmd;

            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();
        

            reader = oracleSelectCommand1.ExecuteReader();


            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                    AcquiredInformation.Add(reader.GetString(i));
            }

            reader.Close();

            oracleSelectCommand1.Connection.Close();
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            Log.WriteLog(ex);

        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }

        return AcquiredInformation;
    }

    /// <summary>
    /// ����� ������������ string �������� ����� ������������������ ������ � ��������� ��������� Where
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Parameters">�������� ���������</param>
    /// <param name="DataFromTextBox">�������� ���������</param>
    /// <returns></returns>
    static public string ParamQuerySelectObject(string cmdQuery, string Parameters, string DataFromTextBox)
    {

        initObjectsForSelectQuery();

        object value = "";

        try
        {
            oracleSelectCommand1.Connection.Open();

            oracleDataAdapter1.SelectCommand.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            oracleDataAdapter1.SelectCommand.Parameters.Add(new OracleParameter((string)(":" + Parameters), DataFromTextBox));

            reader = oracleSelectCommand1.ExecuteReader();


            if (reader.Read())
                try
                {
                    value = reader.GetValue(0);
                }
                catch (InvalidCastException) { } //����� ������ ��������

            reader.Close();

            oracleSelectCommand1.Connection.Close();

            return value.ToString();

        }
        catch (OracleException ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);

            oracleSelectCommand1.Connection.Close();

            Log.WriteLog(ex);

            return value.ToString();
        }
        finally
        {
            reader.Dispose();
            disposeObjectsForSelectQuery();
        }

    }


    /// <summary>
    /// �������� ����������
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public bool UnloadDoc(string NameOfFile)
    {        
        initObjectsForSelectQuery();

        string PartPath = UchetUSP.Program.PathString + "\\" + NameOfFile;

        try
        {

            if (!System.IO.File.Exists(PartPath))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT FILEBLOB FROM USP_TEMPLATES WHERE NAMEFILE = :NAMEFILE";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new OracleParameter(":NAMEFILE", (string)(NameOfFile)));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(PartPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return true;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return false;
        }
        finally
        {
            reader.Dispose();

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }

    /// <summary>
    /// ������������������� exist
    /// </summary>
    /// <param name="cmdQuery">cmdQuery-������</param>
    /// <param name="ParamsDict">����� ����������</param>
    /// <returns>true - ����������; 
    /// false - �� ����������</returns>
    public static bool exist(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
       
        bool flag = false;

        initObjectsForSelectQuery();

        _open();
        try
        {          
            oracleSelectCommand1.Connection.Open();

            oracleSelectCommand1.CommandText = cmdQuery;

            oracleSelectCommand1.Parameters.Clear();

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {                               
                oracleSelectCommand1.Parameters.Add(new OracleParameter(":" + Pair.Key, Pair.Value));
            }

            

            reader = oracleSelectCommand1.ExecuteReader();


            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();
            
        }
        catch (Exception Ex)
        {
            Log.WriteLog(Ex);
        }
        finally
        {
            reader.Dispose();
            oracleSelectCommand1.Connection.Close();
            disposeObjectsForSelectQuery();
        }


        return flag;
    }


    static public bool UnloadDll(string NameOfFile)
    {
        initObjectsForSelectQuery();

        string[] split = Application.ExecutablePath.Split('\\');

        string PartPath = "";
        for (int i = 0; i < split.Length - 1; i++)
        {
            PartPath += split[i] + '\\';
        }

        PartPath += NameOfFile;

        try
        {

            if (!System.IO.File.Exists(PartPath))
            {

                System.IO.FileStream fs;

                int Prt_file = 0;

                string cmdQuery = "SELECT FILEBLOB FROM USP_TEMPLATES WHERE NAMEFILE = :NAMEFILE";

                oracleSelectCommand1.CommandText = cmdQuery;

                oracleSelectCommand1.Parameters.Clear();

                oracleSelectCommand1.Parameters.Add(new OracleParameter(":NAMEFILE", (string)(NameOfFile)));

                oracleSelectCommand1.Connection.Open();

                reader = oracleSelectCommand1.ExecuteReader();

                reader.Read();

                System.Byte[] b = new System.Byte[System.Convert.ToInt32((reader.GetBytes(Prt_file, 0, null, 0, System.Int32.MaxValue)))];

                reader.GetBytes(Prt_file, 0, b, 0, b.Length);

                reader.Close();

                oracleSelectCommand1.Connection.Close();

                fs = new System.IO.FileStream(PartPath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write);

                IDisposable d = (IDisposable)fs;

                fs.Write(b, 0, b.Length);

                d.Dispose();


            }

            return true;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message, "������");

            Log.WriteLog(ex);

            return false;
        }
        finally
        {
            if (reader != null)
            {
                reader.Dispose();
            }

            oracleSelectCommand1.Connection.Close();

            disposeObjectsForSelectQuery();
        }
    }

}
