class SQLOracle
{
    private static Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection();


    SQLOracle()
    {
        //данные вводить без `
        conn.ConnectionString = @"User Id=`user`;Password=`pass`;Data Source=`ip.ip.ip.ip`/`SID or Service name`";
    }

    public static System.Collections.Generic.List<int> selectListInt(string cmdQuery)
    {
        System.Collections.Generic.List<int> list = new System.Collections.Generic.List<int>();

        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
            list.Add(System.Int32.Parse(reader.GetValue(0).ToString()));

        reader.Close();
        cmd.Dispose();

        return list;
    }
    public static System.Collections.Generic.List<long> selectListLong(string cmdQuery)
    {
        System.Collections.Generic.List<long> list = new System.Collections.Generic.List<long>();

        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
            list.Add(System.Int32.Parse(reader.GetValue(0).ToString()));

        reader.Close();
        cmd.Dispose();

        return list;
    }
    public static System.Collections.Generic.List<string> selectListStr(string cmdQuery)
    {
        System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();

        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
            list.Add(reader.GetString(0));

        reader.Close();
        cmd.Dispose();

        return list;
    }

    public static int selectInt(string cmdQuery)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        int value = 0;
        while (reader.Read())
            value = System.Int32.Parse(reader.GetValue(0).ToString());

        reader.Close();
        cmd.Dispose();

        return value;
    }
    public static int selectInt(string cmdQuery, int nullValue)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        int value = nullValue;
        while (reader.Read())
            value = System.Int32.Parse(reader.GetValue(0).ToString());

        reader.Close();
        cmd.Dispose();

        return value;
    }
    public static long selectLong(string cmdQuery)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        long value = 0;
        while (reader.Read())
            value = System.Int32.Parse(reader.GetValue(0).ToString());

        reader.Close();
        cmd.Dispose();

        return value;
    }
    public static long selectLong(string cmdQuery, long nullValue)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        long value = nullValue;
        while (reader.Read())
            value = System.Int32.Parse(reader.GetValue(0).ToString());

        reader.Close();
        cmd.Dispose();

        return value;
    }
    public static string selectStr(string cmdQuery)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        string value = "";
        while (reader.Read())
            value = reader.GetString(0);

        reader.Close();
        cmd.Dispose();

        return value;
    }
    public static string selectStr(string cmdQuery, string nullValue)
    {
        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        string value = nullValue;
        while (reader.Read())
            value = reader.GetString(0);

        reader.Close();
        cmd.Dispose();

        return value;
    }

    public static void update(string sqlUpdate)
    {
        Oracle.DataAccess.Client.OracleCommand cmdUpdate = new Oracle.DataAccess.Client.OracleCommand(sqlUpdate, conn);

        cmdUpdate.ExecuteNonQuery();
        cmdUpdate.Dispose();
    }

    public static void alter(string sqlAlter)
    {
        Oracle.DataAccess.Client.OracleCommand cmdAlter = new Oracle.DataAccess.Client.OracleCommand(sqlAlter, conn);

        cmdAlter.ExecuteNonQuery();
        cmdAlter.Dispose();
    }

    public static void insert(string sqlInsert)
    {
        Oracle.DataAccess.Client.OracleCommand cmdInsert = new Oracle.DataAccess.Client.OracleCommand(sqlInsert, conn);

        cmdInsert.ExecuteNonQuery();
        cmdInsert.Dispose();
    }

    public static void delete(string sqlDelete)
    {
        Oracle.DataAccess.Client.OracleCommand cmdDelete = new Oracle.DataAccess.Client.OracleCommand(sqlDelete, conn);

        cmdDelete.ExecuteNonQuery();
        cmdDelete.Dispose();
    }

    public static bool isVoid(string table)
    {
        string cmdQuery = "select * from " + table;

        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            reader.Close();
            cmd.Dispose();

            return false;
        }

        reader.Close();
        cmd.Dispose();

        return true;
    }
    public static bool isExist(string table, string where)
    {
        string cmdQuery = "select * from " + table + " where " + where;

        Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(cmdQuery, conn);
        Oracle.DataAccess.Client.OracleDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            reader.Close();
            cmd.Dispose();

            return true;
        }

        reader.Close();
        cmd.Dispose();

        return false;
    }

    public static int countInt(string table)
    {
        return selectInt("select COUNT(ID) from " + table);
    }
    public static long countLong(string table)
    {
        return selectLong("select COUNT(ID) from " + table);
    }

    public static int countInt(string table, string where)
    {
        return selectInt("select COUNT(ID) from " + table + " where " + where);
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

    public static int getMaxIndexInt(string table, string field)
    {
        return selectInt("select MAX(" + field + ") from " + table);
    }
    public static int getMinIndexInt(string table, string field)
    {
        return selectInt("select MIN(" + field + ") from " + table);
    }
}
