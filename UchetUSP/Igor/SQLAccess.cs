using System;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

class SQLOracle1 //������� �� SQLAccess
{
    public static string _user = "";
    //static string _password = "";
    //static string _dataSource = "";

    static string _dbPath = @"D:\USP\UchetUSP\usp.mdb";
    //static string _dbPath = @"C:\USP\UchetUSP\usp.mdb";
    static string _connectionString = "provider=Microsoft.Jet.OLEDB.4.0;data source=" + _dbPath;

    static OleDbConnection _conn = new OleDbConnection(_connectionString);

    static void _open()
    {
        _conn.Open();
    }
    static void _close()
    {
        _conn.Close();
    }

    public static bool connect(string login, string password)
    {
        return true;
    }

    /// <summary>
    /// ����������� ���� � ������ Access
    /// </summary>
    /// <param name="DT">����</param>
    /// <returns></returns>
    public static string getDateTime(DateTime DT)
    {
        string oraDT = DT.ToString();
        return "'" + oraDT + "'";
    }

    public static DataSet getDS(string cmdQuery)
    {
        DataSet DS = new DataSet();

        _open();
        OleDbDataAdapter DA = new OleDbDataAdapter();
        OleDbCommand Cmd =
                new OleDbCommand(cmdQuery, _conn);

        DA.SelectCommand = Cmd;
        DA.Fill(DS);

        Cmd.Dispose();
        DA.Dispose();

        _close();
        return DS;
    }
    /// <summary>
    /// ���������� DataSet �� �������������������� select-�������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="Dict">Dictionary � ����������������� �������</param>
    /// <returns></returns>
    public static DataSet getDS(string cmdQuery, Dictionary<string, string> Dict)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);
            Cmd.CommandType = CommandType.Text;

            OleDbDataAdapter DA = new OleDbDataAdapter(Cmd);

            foreach (KeyValuePair<string, string> pair in Dict)
            {
                DA.SelectCommand.Parameters.AddWithValue(":" + pair.Key, pair.Value);
            }

            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (System.Exception ex)
        {
            MessageBox.Show(cmdQuery + "\n" + ex.Message);
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            OleDbDataAdapter DA = new OleDbDataAdapter(Cmd);
            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (Exception Ex)
        {
            MessageBox.Show(cmdQuery + "\n" + Ex.Message);
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
    public static DataTable getDT(string cmdQuery, Dictionary<string, string> Dict)
    {
        DataSet DS = new DataSet();

        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            OleDbDataAdapter DA = new OleDbDataAdapter(Cmd);

            foreach (KeyValuePair<string, string> pair in Dict)
            {
                DA.SelectCommand.Parameters.AddWithValue(":" + pair.Key, pair.Value);
            }

            DA.Fill(DS);

            DA.Dispose();
            Cmd.Dispose();

        }
        catch (Exception ex)
        {
            MessageBox.Show(cmdQuery + "\n" + ex.Message);
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);
            OleDbDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                value = Reader.GetValue(0);
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            MessageBox.Show(cmdQuery + "\n" + Ex.ToString());
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OleDbDataReader Reader = Cmd.ExecuteReader();

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

            MessageBox.Show(mess + "\n" + Ex.ToString());
        }
        finally
        {
            _close();
        }

        return value;
    }


    public static bool selectBool(string cmdQuery)
    {
        bool value = false;

        _open();
        try
        {
            System.Data.OleDb.OleDbCommand cmd = _conn.CreateCommand();
            cmd.CommandText = cmdQuery;

            System.Data.OleDb.OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                value = reader.GetBoolean(0);

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }
        finally
        {
            _close();
        }

        return value;
    }

    /// <summary>
    /// ��������� int-��������� select-�������
    /// </summary>
    /// <param name="cmdQuery">Select-������</param>
    /// <returns></returns>
    public static int selectInt(string cmdQuery)
    {
        _open();
        OleDbCommand Cmd = _conn.CreateCommand();

        Cmd.CommandText = cmdQuery;

        OleDbDataReader Reader = Cmd.ExecuteReader();

        int result = 0;
        if (Reader.Read())
        {
            string s = Reader.GetValue(0).ToString();
            if (!"".Equals(s))
                result = Int32.Parse(s);
        }

        Reader.Close();
        Cmd.Dispose();
        _close();

        return result;
    }
    public static int selectInt(string cmdQuery, int nullValue)
    {
        _open();
        System.Data.OleDb.OleDbCommand cmd = _conn.CreateCommand();

        cmd.CommandText = cmdQuery;

        System.Data.OleDb.OleDbDataReader reader = cmd.ExecuteReader();

        int result = nullValue;
        if (reader.Read())
        {
            string s = reader.GetValue(0).ToString();
            if (!"".Equals(s))
                result = System.Int32.Parse(s);
        }

        reader.Close();
        cmd.Dispose();
        _close();

        return result;
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OleDbDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    value = Int32.Parse(Reader.GetValue(0).ToString());
                }
                catch (InvalidCastException) { } //����� ������ ��������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception E)
        {
            MessageBox.Show(cmdQuery + "\n" + E.ToString());
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OleDbDataReader Reader = Cmd.ExecuteReader();

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

            MessageBox.Show(mess + "\n" + Ex.ToString());
        }
        finally
        {
            _close();
        }

        return value;
    }

    public static string selectStr(string cmdQuery)
    {
        _open();
        OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);
        OleDbDataReader Reader = Cmd.ExecuteReader();

        string result = "";
        if (Reader.Read())
            try
            {
                result = Reader.GetString(0);
            }
            catch (InvalidCastException) { } //����� ������ ��������

        Reader.Close();
        Cmd.Dispose();
        _close();

        return result;
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OleDbDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
            {
                try
                {
                    value = Reader.GetString(0);
                }
                catch (InvalidCastException) { } //����� ������ ��������
            }

            Reader.Close();
            Cmd.Dispose();
        }
        catch (System.Exception E)
        {
            MessageBox.Show(cmdQuery + "\n" + E.ToString());
        }
        finally
        {
            _close();
        }

        return value;
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);
            OleDbDataReader Reader = Cmd.ExecuteReader();

            while (Reader.Read())
                List.Add(Reader.GetString(0));

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(cmdQuery + "\n" + ex.Message);
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
    /// <param name="ParamsDict">������� � ����������������� �������</param>
    /// <returns></returns>
    public static Dictionary<string, string> selectDictStr(string cmdQuery, Dictionary<string, string> ParamsDict)
    {
        Dictionary<string, string> ResultDict = new Dictionary<string, string>();

        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            OleDbDataReader Reader = Cmd.ExecuteReader();

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
        catch (Exception ex)
        {
            MessageBox.Show(cmdQuery + "\n" + ex.ToString());
        }
        finally
        {
            _close();
        }

        return ResultDict;
    }

    /// <summary>
    /// Select-������ ������������ ���� � �����
    /// </summary>
    /// <param name="cmdQuery">Select-������</param>
    /// <returns></returns>
    public static DateTime selectDate(string cmdQuery)
    {
        _open();
        OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);
        OleDbDataReader Reader = Cmd.ExecuteReader();

        DateTime ResultDate = new System.DateTime(1, 1, 1);
        if (Reader.Read())
            try
            {
                ResultDate = Reader.GetDateTime(0);
            }
            catch (InvalidCastException) { } //����� ������ ��������

        Reader.Close();
        Cmd.Dispose();
        _close();

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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }
            OleDbDataReader Reader = Cmd.ExecuteReader();

            if (Reader.Read())
                    ResultDate = Reader.GetDateTime(0);

            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception E)
        {
            MessageBox.Show(cmdQuery + "\n" + E.ToString());
        }
        finally
        {
            _close();
        }

        return ResultDate;
    }


    /// <summary>
    /// Insert-������
    /// </summary>
    /// <param name="cmdInsert">Insert-������</param>
    public static void insert(string cmdInsert)
    {
        _open();
        OleDbCommand Cmd = _conn.CreateCommand();

        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        _close();
    }
    /// <summary>
    /// ������������������� Insert-������
    /// </summary>
    /// <param name="cmdInsert">Insert-������</param>
    /// <param name="Dict">Dictionary c ����������������� �������</param>
    public static void insert(string cmdInsert, Dictionary<string, string> Dict)
    {
        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdInsert, _conn);

            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception e)
        {
            MessageBox.Show(cmdInsert + "\n" + e.ToString());
        }
        finally
        {
            _close();
        }
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
            OleDbCommand Cmd = new OleDbCommand(cmdUpdate, _conn);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show(cmdUpdate + "\n" + ex.ToString());
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
    public static void update(string cmdUpdate, Dictionary<string, string> Dict)
    {
        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdUpdate, _conn);

            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                Cmd.Parameters.AddWithValue(":" + Pair.Key, Pair.Value);
            }

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception ex)
        {
            string mess = cmdUpdate + "\n";
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                mess += Pair.Key + " - " + Pair.Value + "\n";
            }
            MessageBox.Show(mess + "\n" + ex.ToString());
        }
        finally
        {
            _close();
        }
    }

    public static void delete(string cmdDelete)
    {
        _open();
        try
        {
            OleDbCommand Cmd = new OleDbCommand(cmdDelete, _conn);

            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
        }
        catch (Exception Ex)
        {
            MessageBox.Show(cmdDelete + "\n" + Ex.ToString());
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
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

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
                mess += Pair.Key + " - " + Pair.Value;
            }

            MessageBox.Show(mess + "\n" + Ex.ToString());
        }
        finally
        {
            _close();
        }
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

    public static bool exist(string table, string where)
    {
        bool flag = false;

        _open();
        try
        {
            string cmdQuery = "select * from " + table + " where " + where;

            System.Data.OleDb.OleDbCommand cmd = _conn.CreateCommand();
            cmd.CommandText = cmdQuery;

            System.Data.OleDb.OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
                flag = true;
            else
                flag = false;

            reader.Close();
            cmd.Dispose();
        }
        catch (System.Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
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

    public static int getMaxIndexInt(string field, string table)
    {
        return selectInt("SELECT MAX(" + field + ") FROM " + table);
    }


    //-----------------------------------------------------------

    /// <summary>
    /// ���������� ��������
    /// </summary>
    /// <param name="cmdQuery">select-������</param>
    /// <param name="TheFirstParametr">��������</param>
    /// <returns></returns>
    public static Image getBlobImageWithBuffer(string cmdQuery, string TheFirstParametr)
    {

        Image returnImage;

        try
        {
            int PictureCol = 0;

            _open();
            OleDbCommand Cmd = new OleDbCommand(cmdQuery, _conn);

            Cmd.Parameters.AddWithValue(":OBOZN", TheFirstParametr);

            OleDbDataReader Reader = Cmd.ExecuteReader();

            Reader.Read();
            Byte[] b = new Byte[Convert.ToInt32((Reader.GetBytes(PictureCol, 0, null, 0, Int32.MaxValue)))];
            Reader.GetBytes(PictureCol, 0, b, 0, b.Length);

            MemoryStream MS = new MemoryStream(b);
            MS.Write(b, 0, b.Length);

            returnImage = Image.FromStream(MS);

            MS.Close();
            Reader.Close();
            Cmd.Dispose();
        }
        catch (Exception E)
        {
            returnImage = null;

            MessageBox.Show(cmdQuery + "/n" + E.ToString());
        }
        finally
        {
            _close();
        }


        return returnImage;

    }



    //----------------------------------- �������� �� ���� -------------------------------------------


    static public DataSet ParamQuerySelect(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox)
    {
        return new DataSet();
    }
    //������� �������������������� ������� �� �������� ������� ������ � �������
    public static bool existParamQuery(string id, string table, string parametr, string value)
    {
        return false;
    }
    //������� �������������������� ������� �� ��������� ����� ������
    public static List<string> GetInformationListWithParamQuery(string id, string table, string parametr, string value)
    {
        return new List<string>();
    }
    //������ �� ������������������� ������� � ��������� �������� (����������� ������)
    static public void SpecificInsertQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox, byte[] BMPInByte)
    {

    }
    //������ �� ������������������� ������� � ��������� �������� (����������� ������)
    static public void SpecificUpdateQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox, byte[] BMPInByte)
    {

    }
    //�������� ������������� ������ �� ����, ������� � ���������� �� where
    public static bool exist(string idField, string table, string where)
    {
        return false;
    }

    public static System.Drawing.Image getBlobImageWithBuffer(string cmdQuery, string TheFirstParametr, string TheSecondParametr, string TheThirdParametr)
    {
        return null;
    }

    static public string UnloadPartToTEMPFolder(string obonachenie)
    {
        return null;
    }

    static public bool InsertQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox)
    {
        return false;
    }

    //������ �� ������������������� ������� 

    static public bool UpdateQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox)
    {
        return false;

    }

    //�������� BLBO ��������
    static public bool BLOBUpdateQuery(string cmdQuery, string Parameters, byte[] BMPInByte)
    {
        return false;

    }

    /// <summary>
    /// ��������� ����������� �� ��
    /// </summary>
    /// <returns></returns>
    public static System.Drawing.Image getBlobImage(string cmdQuery)
    {

        System.Drawing.Bitmap returnImage = null;

        return returnImage;

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

        return AcquiredInformation;
    }

    static public System.Data.DataSet ParamQuerySelectNonPercent(string cmdQuery, System.Collections.Generic.List<string> Parameters, System.Collections.Generic.List<string> DataFromTextBox)
    {
        return null;
    }

    /// <summary>
    /// ��������� ����������� �� ��
    /// </summary>
    /// <returns></returns>
    public static string LoadImageToTemp(string cmdQuery)
    {

        string returnImage = null;

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
        string value = "";

        return value;
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
        object value = "";


            return value.ToString();


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

    /// <summary>
    /// �������� ����������
    /// </summary>
    /// <param name="obonachenie">����������� ������</param>
    /// <returns></returns>
    static public bool UnloadDoc(string NameOfFile)
    {
            return false;
    }


    //������� �������������������� ������� �� �������� ������� ������ � �������

    public static bool existParamQuery(string id, string table, string SQLParametr, string CSharpParametr, string value)
    {
        bool flag = false;


        return flag;
    }

    /// <summary>
    /// �������� �������� � TEMP
    /// </summary>
    /// <param name="HD">����������� ��������</param>
    /// <returns></returns>
    static public string UnloadOsnasToTEMPFolder(string NUM)
    {

            return UchetUSP.Program.PathString + "\\";

    }

    static public string UnloadOsnasToTEMPFolder(string NUM, string POZ)
    {

            return "0";

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

        return flag;
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

        return hasSketch;

    }

    /// <summary>
    /// �������� ������� ��� 20 � TEMP
    /// </summary>
    /// <param name="HD">����������� NMF</param>
    /// <returns></returns>
    static public string UnloadOsnasToTEMPFolderFile20(string NMF)
    {

        return "";
    }

}