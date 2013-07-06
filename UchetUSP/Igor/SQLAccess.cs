using System;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

class SQLOracle1 //конечно же SQLAccess
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
    /// Преобразует дату в формат Access
    /// </summary>
    /// <param name="DT">дата</param>
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
    /// Возвращает DataSet по параметризированному select-запросу
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="Dict">Dictionary с параметризаторами запроса</param>
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
    /// Возвращает таблицу с параметризированным select-запросом
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="Dict">Dictioanry с параметризаторрами запроса</param>
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
    /// Возвращает таблицу с параметризированным select-запросом
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="Dict">Dictioanry с параметризаторрами запроса</param>
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
    /// Метод, реализующий select-запрос
    /// </summary>
    /// <param name="cmdQuery">SQL-текст запроса</param>
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
    /// Метод, реализующий параметризированный select-запрос
    /// </summary>
    /// <param name="cmdQuery">SQL-текст запроса</param>
    /// <param name="ParamsDict">Dictionary c параметризаторами запроса</param>
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
    /// Возвращет int-результат select-запроса
    /// </summary>
    /// <param name="cmdQuery">Select-запрос</param>
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
    /// Возвращает int параметризированного select-запроса
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="ParamsDict">Dictionary с параметризаторами запроса</param>
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
                catch (InvalidCastException) { } //ловим пустое значение
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
    /// Возвращает int параметризированного select-запроса
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="ParamsDict">Dictionary с параметризаторами запроса</param>
    /// <param name="nullValue">Нулевое значение</param>
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
                catch (InvalidCastException) { } //ловим пустое значение
                catch (FormatException) { } //ловим пустой select-запрос
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
            catch (InvalidCastException) { } //ловим пустое значение

        Reader.Close();
        Cmd.Dispose();
        _close();

        return result;
    }
    /// <summary>
    /// Возвращает string параметризированного select-запроса
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="ParamsDict">Dictionary с параметризаторами запроса</param>
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
                catch (InvalidCastException) { } //ловим пустое значение
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
    /// Возвращает результат select-запроса в виде списка строковых переменных
    /// </summary>
    /// <param name="cmdQuery">Текст sql-запроса</param>
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
    /// Возвращает результат select-запроса в виде словаря строковых переменных
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="ParamsDict">словарь с параметризаторами запроса</param>
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
    /// Select-запрос возвращающий дату и время
    /// </summary>
    /// <param name="cmdQuery">Select-запрос</param>
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
            catch (InvalidCastException) { } //ловим пустое значение

        Reader.Close();
        Cmd.Dispose();
        _close();

        return ResultDate;
    }
    /// <summary>
    /// Select-запрос возвращающий дату и время
    /// </summary>
    /// <param name="cmdQuery">Select-запрос</param>
    /// <param name="ParamsDict">Dictionary c параметризаторами запроса</param>
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
    /// Insert-запрос
    /// </summary>
    /// <param name="cmdInsert">Insert-запрос</param>
    public static void insert(string cmdInsert)
    {
        _open();
        OleDbCommand Cmd = _conn.CreateCommand();

        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        _close();
    }
    /// <summary>
    /// Параметризированный Insert-запрос
    /// </summary>
    /// <param name="cmdInsert">Insert-запрос</param>
    /// <param name="Dict">Dictionary c параметризаторами запроса</param>
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
    /// Update-запрос
    /// </summary>
    /// <param name="cmdQuery">Update-запрос</param>
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
    /// Параметризированный update-запрос
    /// </summary>
    /// <param name="cmdQuery">update-запрос</param>
    /// <param name="Dict">Dictionary с параметризаторами запроса</param>
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
    /// Метод параметризированного delete-запроса
    /// </summary>
    /// <param name="cmdQuery">SQL текст delete-запроса</param>
    /// <param name="ParamsDict">Dictionary с параметризаторами</param>
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
    /// Метод возвращает количество выбранных строк из заданной таблицы по заданному условию
    /// </summary>
    /// <param name="table">Наименование таблицы</param>
    /// <param name="where">Условие без ключевого слова WHERE</param>
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
    /// Mетод возвращает true, если значение в соответствующем поле и таблице найдено
    /// </summary>
    /// <param name="value">Значение</param>
    /// <param name="column">Поле</param>
    /// <param name="table">Таблица</param>
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
    /// Возвращает картинку
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="TheFirstParametr">параметр</param>
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



    //----------------------------------- заглушки на Леху -------------------------------------------


    static public DataSet ParamQuerySelect(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox)
    {
        return new DataSet();
    }
    //функция параметризированного запроса на проверку наличия данных в таблице
    public static bool existParamQuery(string id, string table, string parametr, string value)
    {
        return false;
    }
    //функция параметризированного запроса на получение листа данных
    public static List<string> GetInformationListWithParamQuery(string id, string table, string parametr, string value)
    {
        return new List<string>();
    }
    //запрос на параметризированную вставку с загрузкой картинки (специальный запрос)
    static public void SpecificInsertQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox, byte[] BMPInByte)
    {

    }
    //запрос на параметризированную вставку с загрузкой картинки (специальный запрос)
    static public void SpecificUpdateQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox, byte[] BMPInByte)
    {

    }
    //проверка существования данных по полю, таблице и параметрам из where
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

    //запрос на параметризированную вставку 

    static public bool UpdateQuery(string cmdQuery, List<string> Parameters, List<string> DataFromTextBox)
    {
        return false;

    }

    //загрузка BLBO картинок
    static public bool BLOBUpdateQuery(string cmdQuery, string Parameters, byte[] BMPInByte)
    {
        return false;

    }

    /// <summary>
    /// Получение изображения из БД
    /// </summary>
    /// <returns></returns>
    public static System.Drawing.Image getBlobImage(string cmdQuery)
    {

        System.Drawing.Bitmap returnImage = null;

        return returnImage;

    }

    /// <summary>
    /// Метод возвращающий строку таблицы в виде List
    /// </summary>
    /// <param name="id">поля Select</param>
    /// <param name="table">Таблица БД</param>
    /// <param name="parametr">Параметр условия Where</param>
    /// <param name="value">Значение условия Where</param>
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
    /// Получение изображения из БД
    /// </summary>
    /// <returns></returns>
    public static string LoadImageToTemp(string cmdQuery)
    {

        string returnImage = null;

        return returnImage;

    }

    /// <summary>
    /// Метод возвращающий string значение через праметризированный селект с единичным условияем Where
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="Parameters">Название параметра</param>
    /// <param name="DataFromTextBox">Значение параметра</param>
    /// <returns></returns>
    static public string ParamQuerySelect(string cmdQuery, string Parameters, string DataFromTextBox)
    {
        string value = "";

        return value;
    }

    /// <summary>
    /// Метод возвращающий string значение через праметризированный селект с единичным условияем Where
    /// </summary>
    /// <param name="cmdQuery">select-запрос</param>
    /// <param name="Parameters">Название параметра</param>
    /// <param name="DataFromTextBox">Значение параметра</param>
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
    /// выгрузка документов
    /// </summary>
    /// <param name="obonachenie">обозначение модели</param>
    /// <returns></returns>
    static public bool UnloadDoc(string NameOfFile)
    {
            return false;
    }


    //функция параметризированного запроса на проверку наличия данных в таблице

    public static bool existParamQuery(string id, string table, string SQLParametr, string CSharpParametr, string value)
    {
        bool flag = false;


        return flag;
    }

    /// <summary>
    /// выгрузка оснастки в TEMP
    /// </summary>
    /// <param name="HD">обозначение оснастки</param>
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
    /// Параметризированный exist
    /// </summary>
    /// <param name="cmdQuery">cmdQuery-строка</param>
    /// <param name="ParamsDict">набор параметров</param>
    /// <returns>true - существует; 
    /// false - не существует</returns>
    public static bool exist(string cmdQuery, Dictionary<string, string> ParamsDict)
    {

        bool flag = false;

        return flag;
    }

    /// <summary>
    /// Метод возвращает путь к файлу
    /// </summary>
    /// <param name="VPPNum">Номер ВПП</param>
    /// <param name="pos">Позиция ТЗ в ВПП</param>
    /// <returns></returns>
    public static bool getTZSketch(string VPPNum, int pos)
    {

        bool hasSketch = false;

        return hasSketch;

    }

    /// <summary>
    /// выгрузка моделей УСП 20 в TEMP
    /// </summary>
    /// <param name="HD">обозначение NMF</param>
    /// <returns></returns>
    static public string UnloadOsnasToTEMPFolderFile20(string NMF)
    {

        return "";
    }

}