using System;
using System.Collections.Generic;
using System.Data;


/// <summary>
    /// Класс со статическими методами, реализующие SQL-запросы к данным заказа (листа заказа, ВПП ...)
    /// </summary>
    static class AssemblyOrders
    {
    private const string Table = " from USP_ASSEMBLY_ORDERS";
    private const string Where = " where NUM = '";
    private const string VppTable = "VPP_POZ20";

    enum Status
    {
        //Created = 1,
        //AssCreated = 2,
        //AssDelivered = 3,
        AssReturned = 4
    }

    private const string EndQuery = Table + Where;

    /// <summary>
        /// Возвращает дату создания сборки УСПО
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getAssCreationDate(string orderNum)
        {
            return SQLOracle.selectDate("select ASSEMBLY_CREATION_DATE" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Возвращает фамилию сборщика УСПО по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssCreatorSurname(string orderNum)
        {
            return SQLOracle.selectStr("select ASSEMBLY_CREATOR_SURNAME" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Возвращает сложность сборки УСПО
        /// </summary>
        /// <param name="id">id сборки УСПО</param>
        /// <returns></returns>
        public static int getAssDiffic(int id)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ASSEMBLY_ID", id.ToString());

            return SQLOracle.selectInt("select ASSEMBLY_DIFFICULTY_GROUP from USP_ASSEMBLY_ORDERS where ASSEMBLY_ID = :ASSEMBLY_ID and ASSEMBLY_DIFFICULTY_GROUP is not NULL group by ASSEMBLY_DIFFICULTY_GROUP", Dict);
        }

        /// <summary>
        /// Возвращает дату поставки сборки УСПО заказчику
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getAssDeliveryDate(string orderNum)
        {
            return SQLOracle.selectDate("select ASSEMBLY_DELIVERY_DATE from USP_ASSEMBLY_ORDERS where NUM = '" + orderNum + "'");
        }

        /// <summary>
        /// Возвращает должность получающего сборку
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssGeterPosition(string orderNum)
        {
            return SQLOracle.selectStr("select ASSEMBLY_GETER_POSITION" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Возвращает фамилию получающего сборку
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssGeterSurname(string orderNum)
        {
            return SQLOracle.selectStr("select ASSEMBLY_GETER_SURNAME" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Возвращает фамилию выдающего сборку
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssGiverSurname(string orderNum)
        {
            return SQLOracle.selectStr("select ASSEMBLY_GIVER_SURNAME" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Метод возвращает id сборки листа заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static int getAssId(string orderNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", orderNum);

            return SQLOracle.selectInt("select ASSEMBLY_ID from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает номерок сборки УСПО по номеру листа заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static int getAssNum(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_NUM from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Возвращает плановую дату возврата сборки
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getAssPlannedReturnDate(string orderNum)
        {
            return SQLOracle.selectDate("select ASSEMBLY_PLANNED_RETURN_DATE" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Метод возвращает дату возврата сборки в цех УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getAssReturnDate(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectDate("select ASSEMBLY_RETURN_DATE from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает фамилию возвращающего сборку в цех УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssReturnGiverSurname(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select ASSEMBLY_RETURN_GIVER_SURNAME from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает фамилию получающего обратно сборку в цех УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssReturnGeterSurname(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select ASSEMBLY_RETURN_GETER_SURNAME from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Возвращает участка УСПО по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getAssSectorNum(string orderNum)
        {
            return SQLOracle.selectStr("select ASSEMBLY_SECTOR_NUM" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Метод возвращает фамилию бригадира (мастера участка) УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getBrigadierSurname(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.sel("select BRIGADIER_SURNAME from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Метод возвращает бригадира для текущего пользователя
        /// </summary>
        /// <returns></returns>
        public static string getBrigadierSurnameSettings()
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            string connection = UchetUSP.Program.ConnectionString;
            string[] split = connection.Split('/');
            string login = split[0];
            Dict.Add("LOGIN", login);

            return SQLOracle.selectStr("select CS_SUR from USP_USER_SETTING where USR = :LOGIN", Dict).ToString();
        }

        /// <summary>
        /// Возвращает дату (оформления) заказа по его номеру
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getCreationDate(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectDate("select CREATION_DATE from USP_ASSEMBLY_ORDERS where  NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает фамилию оформляющего по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getCreatorSurname(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select CREATOR_SURNAME from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Метод возвращает должность заказчика по номеру листа заказа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string getCustomerPosition(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select CUSTOMER_POSITION from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Метод возращает фамилию заказчика по номер листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getCustomerSurname(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select CUSTOMER_SURNAME from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Возвращает дату востребования сборки по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static DateTime getDemandDate(string orderNum)
        {
            return SQLOracle.selectDate("select DEMAND_DATE" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Метод возвращает id тз
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTZId(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select ID_TZ from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Метод возвращает количество сборок в году до заданного месяца
        /// </summary>
        /// <param name="date">Дата: используется год и месяц</param>
        /// <returns></returns>
        public static int getNAssesInYear(DateTime date)
        {
            string cmdQuery = "select count(*) from USP_ASSEMBLY_ORDERS where to_char(ASSEMBLY_CREATION_DATE, 'MM') < to_number(" + date.Month + ") and to_char(ASSEMBLY_CREATION_DATE, 'YYYY') = to_number(" + date.Year + ")";

            return SQLOracle.selectInt(cmdQuery);
        }

        /// <summary>
        /// Метод возвращает кол-во ТЗ в ВПП
        /// </summary>
        /// <param name="VPPNum">Номер ВПП</param>
        /// <returns></returns>
        public static int getNTZs(string VPPNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPNum);

            string cmdQuery = "select count(*) from VPP_TZ20 where N_VD = :VPP_NUM";
            return SQLOracle.selectInt(cmdQuery, Dict);
        }

        /// <summary>
        /// Возвращает количество обрабатываемых деталей по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static int getPartsCount(string orderNum)
        {
            return SQLOracle.selectInt("select PARTS_COUNT" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Возвращает наименование детали по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getPartName(string orderNum)
        {
            return SQLOracle.selectStr("select PART_NAME" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Метод, возвращающий обозначение обрабатываемой детали по номеру листа заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getPartTitle(string orderNum)
        {
            string result = SQLOracle.selectStr("select OB_D from VPP_POZ20 where N_VD = (select VPP_NUM" + Table + Where + orderNum + "')");
            return result;
        }
        /// <summary>
        /// Метод, возвращающий обозначение обрабатываемой детали
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getPartTitle_TZ(string id)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", id);

            string result = SQLOracle.selectStr("select OBOZN_DET from USP_TZ_DATA where ID_DOC = :ID", Dict);
            return result;
        }

        /// <summary>
        /// Возвращает плановую дату изготовления УСПО
        /// </summary>
        /// <param name="id">Id ТЗ без проектирования</param>
        /// <returns></returns>
        public static DateTime getPlanProductionDate_TZnumber(string id)
        {
            Dictionary<string, string> D = new Dictionary<string, string>();
            D.Add("ID", id);

            return SQLOracle.selectDate("select DATA_ISP from USP_TZ_DATA where ID_DOC = :ID", D);
        }
        /// <summary>
        /// Возвращает плановую дату изготовления УСПО
        /// </summary>
        /// <param name="VPPnumber">Номер ВПП/ВЗД</param>
        /// <returns></returns>
        public static DateTime getPlanProductionDate_VPPnumber(string VPPnumber)
        {
            Dictionary<string, string> D = new Dictionary<string, string>();
            D.Add("VPP_NUM", VPPnumber);

            return SQLOracle.selectDate("select DT_I from " + VppTable + " where N_VD = :VPP_NUM", D);
        }

        /// <summary>
        /// Метод возвращает код изделия по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getProductCode(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select KI from VPP_POZ20 where N_VD = (select VPP_NUM from USP_ASSEMBLY_ORDERS where NUM = :NUM)", Dict);
        }
        /// <summary>
        /// Метод возвращает код изделия
        /// </summary>
        /// <param name="id">ID ТЗ</param>
        /// <returns></returns>
        public static string getProductCode_TZ(string id)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", id);

            return SQLOracle.selectStr("SELECT PDM_IZD.KB FROM PDM_IZD, PDM_DOC_YTV WHERE PDM_IZD.IZD = PDM_DOC_YTV.IZD and PDM_DOC_YTV.ID_DOC = :ID", Dict);
        }

        /// <summary>
        /// Метод возвращает номер участка сборки УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static string getSectorNum(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectStr("select ASSEMBLY_SECTOR_NUM from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict).ToString();
        }

        /// <summary>
        /// Метод возвращает номер участка для текущего пользователя
        /// </summary>
        /// <returns></returns>
        public static string getSectorNumSettings()
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            string connection = UchetUSP.Program.ConnectionString;
            string[] split = connection.Split('/');
            string login = split[0];
            Dict.Add("LOGIN", login);

            return SQLOracle.selectStr("select CS_DEP from USP_USER_SETTING where USR = :LOGIN", Dict).ToString();
        }

        /// <summary>
        /// Возвращает дополнительные технические условия
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTechConditions(string orderNum)
        {
            return SQLOracle.selectStr("select TECH_CONDITIONS" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Возвращает должность автора дополнительных технических условий
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTechConditionsPosition(string orderNum)
        {
            return SQLOracle.selectStr("select TECH_CONDITIONS_POSITION" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Возвращает фамилию автора дополнительных технических условий
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTechConditionsSurname(string orderNum)
        {
            return SQLOracle.selectStr("select TECH_CONDITIONS_SURNAME" + EndQuery + orderNum + "'");
        }

        /// <summary>
        /// Возвращает наименование технологической операции
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTechOperationName(string orderNum)
        {
            return SQLOracle.selectStr("select TECH_OPERATION_NAME" + Table + Where + orderNum + "'");
        }

        /// <summary>
        /// Возвращает номер технического задания по номеру заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getTZnumber(string orderNum)
        {
            return SQLOracle.selectStr("select TZ_NUM" + Table + Where + orderNum + "'");
        }
        /// <summary>
        /// Возвращает номер технического задания
        /// </summary>
        /// <param name="idDoc">ID ТЗ</param>
        /// <returns></returns>
        public static string getTZnum(string idDoc)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", idDoc);

            return SQLOracle.selectStr("select DOC from PDM_DOC_YTV where ID_DOC = :ID", Dict).ToString();
        }

        /// <summary>
        /// Метод возвращает позицию ТЗ
        /// </summary>
        /// <param name="orderNum">Номер заказа</param>
        /// <returns></returns>
        public static int getTZpos(string orderNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", orderNum);

            return SQLOracle.selectInt("SELECT TZ_POS FROM USP_ASSEMBLY_ORDERS O WHERE O.NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает идентификатор ВПП
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getVPPId(string num)
        {
            string VPPNum = getVPPnumber(num);

            return UchetUSP.VPP.getId(VPPNum);
        }

        /// <summary>
        /// Возвращает номер ВПП по номеру листа заказа
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        /// <returns></returns>
        public static string getVPPnumber(string orderNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", orderNum);

            return SQLOracle.selectStr("select VPP_NUM" + Table + " where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает код цеха заказчика по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getWorkshopCode(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("SELECT WORKSHOP_CODE FROM USP_ASSEMBLY_ORDERS O WHERE O.NUM = :NUM", Dict);
        }
        public static int getWorkshopCode_VPPnumber(string VPPnum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("VPP_NUM", VPPnum);

            return SQLOracle.selectInt("select distinct CE from VPP_TZ20 where N_VD = :VPP_NUM");
        }
        /// <summary>
        /// Метод возвращает код цеха заказчика по id ТЗ
        /// </summary>
        /// <param name="idDoc">id ТЗ</param>
        /// <returns></returns>
        public static string getWorkshopCode_TZ(string idDoc)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ID", idDoc);

            return SQLOracle.selectStr("select KOD_CEHA from USP_TZ_DATA where ID_DOC = :ID", Dict);
        }

        //------------------
        /// <summary>
        /// Метод возвращает кол-во элементов в сборке
        /// </summary>
        /// <param name="num">
        /// Номер заказа
        /// </param>
        public static int getElementsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_ELEMENTS_COUNT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает количество прихватов и планок в УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getStrapsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_STRAPS_COUNT from USP_ASSEMBLY_ORDERS where NUM =:NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает количество болтов с гайками в УСПО по номеру листа заказа
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getNutsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_NUTS_COUNT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает количество специальных шпонок
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getSpecialDowelsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_SPECIAL_DOWELS_COUNT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает количество специальных деталей
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getSpecialElementsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_SPECIAL_ELEMEN_COUNT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает количество рассчитанных и выверенных размеров
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getDimensionsCount(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_DIMENSIONS_COUNT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }

        /// <summary>
        /// Метод возвращает группу сложности сборки УСПО
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static int getDifficultyGroup(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            return SQLOracle.selectInt("select ASSEMBLY_DIFFICULTY_GROUP from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
        }


        //------------------------------------------
        /// <summary>
        /// Метод возвращает true, если заказ основан на ВПП с проектированием
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static bool isProject(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            int val = SQLOracle.selectInt("select PROJECT from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
            if (val == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод возвращает true, если заказ основан на ТЗ без ВПП
        /// </summary>
        /// <param name="num">Номер листа заказа</param>
        /// <returns></returns>
        public static bool isTZ(string num)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", num);

            int val = SQLOracle.selectInt("select ID_TZ from USP_ASSEMBLY_ORDERS where NUM = :NUM", Dict);
            if (val == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //------------------ DATASETS ---------------------------

        /// <summary>
        /// Метод, возвращающий данные по собранным сборкам за конкретный месяц
        /// </summary>
        /// <param name="date">Дата, месяц которой будет условием выборки</param>
        /// <returns></returns>
        public static DataSet getAssembliesInfo(DateTime date)
        {
            int currMonth, currYear;

            currMonth = date.Month;
            currYear = date.Year;

            string parametrs = "";
            parametrs += "CREATION_DATE";
            parametrs += ", ASSEMBLY_CREATION_DATE";
            parametrs += ", WORKSHOP_CODE";
            parametrs += ", USP_ASSEMBLY_ORDERS.NUM";
            parametrs += ", TZ_NUM";
            parametrs += ", ASSEMBLY_NUM";
            parametrs += ", PRODUCT_CODE";
            parametrs += ", PART_TITLE";
            parametrs += ", PART_NAME";
            parametrs += ", EQUIP_TITLE";
            parametrs += ", ASSEMBLY_ELEMENTS_COUNT";
            parametrs += ", NULL"; //РАЗМЕР ПАЗА
            parametrs += ", ASSEMBLY_DIFFICULTY_GROUP";

            string cmdQuery = "select " + parametrs + " from USP_ASSEMBLY_ORDERS" +
                " where to_char(ASSEMBLY_CREATION_DATE, 'MM') = to_number(:currMonth) and to_char(ASSEMBLY_CREATION_DATE, 'YYYY') = to_number(:currYear)";

            Dictionary<string, string> Dict = new Dictionary<string, string>();

            Dict.Add("currMonth", currMonth.ToString());
            Dict.Add("currYear", currYear.ToString());

            return SQLOracle.getDS(cmdQuery, Dict);
        }

        /// <summary>
        /// Метод возвращает листы заказа с определенным статусом
        /// </summary>
        /// <param name="status">Статус заказа: 1 - оформлен, 2 - сборка создана, 3 - сборка выдана заказчику, 4 - сборка принята обратно в цех УСПО </param>
        /// <returns></returns>
        public static DataTable getOrders(int status)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("STATUS", status.ToString());

            return SQLOracle.getDT("select NUM, VPP_NUM, TZ_NUM, PART_NAME from USP_ASSEMBLY_ORDERS where DOC_STATUS = :STATUS", Dict);
        }
        /// <summary>
        /// Метод возвращает листы заказа с определенным статусом в заданном временном интервале
        /// </summary>
        /// <param name="status">Статус заказа: 1 - оформлен, 2 - сборка создана, 3 - сборка выдана заказчику, 4 - сборка принята обратно в цех УСПО </param>
        /// <param name="fromDate">Дата начала временного промежутка</param>
        /// <param name="toDate">Дата конца временного промежутка</param>
        /// <param name="columnName">Наименование столбца для фильтрации по времени</param>
        /// <returns></returns>
        public static DataTable GetOrders(int status, DateTime fromDate, DateTime toDate, string columnName)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("STATUS", status.ToString());

            DateTime fD = fromDate.Date;
            dict.Add("FROM_DATE", fD.ToString());

            DateTime tomorrow = toDate.Date.AddDays(1);
            dict.Add("TO_DATE", tomorrow.ToString());

            string cmdQuery = "select NUM, " +
                                     "VPP_NUM, " +
                                     "TZ_NUM, " +
                                     "PART_TITLE, " +
                                     "WORKSHOP_CODE, " +
                                     "TECHNOLOG, " + columnName + 
                              " from USP_ASSEMBLY_ORDERS " +
                              "where DOC_STATUS = :STATUS and " + 
                                     columnName + " >= to_date(:FROM_DATE,'dd.mm.yyyy hh24:mi:ss') and " + 
                                     columnName + " < to_date(:TO_DATE,'dd.mm.yyyy hh24:mi:ss')";
            
            DataTable dt = SQLOracle.getDT(cmdQuery, dict);
            dt.Columns[0].ColumnName = "Номер";
            dt.Columns[1].ColumnName = "Номер ВПП";
            dt.Columns[2].ColumnName = "Номер ТЗ";
            dt.Columns[3].ColumnName = "Обозначение детали";
            dt.Columns[4].ColumnName = "Цех заказчик";
            dt.Columns[5].ColumnName = "Владелец";

            return dt;
        }

        /// <summary>
        /// Возвращает информацию по завершённым листам заказа в выбранном временном диапазоне
        /// возвращения сборки.
        /// </summary>
        /// <param name="fromDate">Начало временного промежутка.</param>
        /// <param name="toDate">Конец временного промежутка.</param>
        /// <returns></returns>
        public static DataTable GetCompletedOrders(DateTime fromDate, DateTime toDate)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            DateTime fD = fromDate.Date;
            dict.Add("FROM_DATE", fD.ToString());

            DateTime tomorrow = toDate.Date.AddDays(1);
            dict.Add("TO_DATE", tomorrow.ToString());

            string cmdQuery = "select NUM, " +
                              "VPP_NUM, " +
                              "TZ_NUM, " +
                              "CREATION_DATE, " +
                              "ASSEMBLY_RETURN_DATE, " + 
                              "PART_TITLE, " +
                              "WORKSHOP_CODE, " +
                              "TECHNOLOG " +
                              "from USP_ASSEMBLY_ORDERS " +
                              "where DOC_STATUS = " + (int)Status.AssReturned + " and " +
                                  "ASSEMBLY_RETURN_DATE >= " +
                                        "to_date(:FROM_DATE,'dd.mm.yyyy hh24:mi:ss') and " +
                                  "ASSEMBLY_RETURN_DATE < " +
                                        "to_date(:TO_DATE,'dd.mm.yyyy hh24:mi:ss')";

            DataTable dt = SQLOracle.getDT(cmdQuery, dict);
            dt.Columns[0].ColumnName = "Номер";
            dt.Columns[1].ColumnName = "Номер ВПП";
            dt.Columns[2].ColumnName = "Номер ТЗ";
            dt.Columns[3].ColumnName = "Дата создания листа заказа";
            dt.Columns[4].ColumnName = "Дата возврата сборки";
            dt.Columns[5].ColumnName = "Обозначение детали";
            dt.Columns[6].ColumnName = "Цех заказчик";
            dt.Columns[7].ColumnName = "Владелец";

            return dt;
        }

        /// <summary>
        /// Метод удаляет лист заказа вместе с горячей статистикой
        /// </summary>
        /// <param name="orderNum">Номер листа заказа</param>
        public static void deleteOrder(string orderNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("ORDER_NUM", orderNum);

            SQLOracle.delete("delete from USP_HOT_STATS where ORDER_NUM = :ORDER_NUM", Dict);
            Dict.Clear();

            if (!AssemblyOrders.isProject(orderNum))
            {
                int id = _ASSEMBLIES.getId_OrderNum(orderNum);
                Dict.Add("ID", id.ToString());
                SQLOracle.delete("delete from USP_ASSEMBLIES where ID = :ID", Dict);
                SQLOracle.delete("delete from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID", Dict);
                Dict.Clear();
            }

            if (isTZ(orderNum))
            {
                string idDoc = getTZId(orderNum);
                Dict.Add("ID_DOC", idDoc);

                string cmdUpdate = "update USP_TZ_DATA set UTV = 1, HP_KOL_EDEN = null where ID_DOC = :ID_DOC";
                SQLOracle.update(cmdUpdate, Dict);

                cmdUpdate = "update USP_TZ_DATA_TP set OBOZN_KOMP = NULL, NAIM_KOMP = NULL, KOL = null where ID_DOC = :ID_DOC";
                SQLOracle.update(cmdUpdate, Dict);
            }

            Dict.Clear();
            Dict.Add("ORDER_NUM", orderNum);
            SQLOracle.delete("delete from USP_ASSEMBLY_ORDERS where NUM = :ORDER_NUM", Dict);
        }

        /// <summary>
        /// Метод откатывает лист заказа на необходимую позицию
        /// </summary>
        /// <param name="status">Статус листа заказа: 1 - оформлен, 2 - сборка создана, 3 - сборка передана заказчику</param>
        /// <param name="orderNum">Номер листа заказа</param>
        public static void setStatus(int status, string orderNum)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("NUM", orderNum);
            int assId = AssemblyOrders.getAssId(orderNum);
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();

            string cmdUpdate = "update USP_ASSEMBLY_ORDERS set ";
            switch (status)
            {
                case 1:

                    //без проектирования
                    if (!AssemblyOrders.isProject(orderNum))
                    {
                        //Удаляем сборку
                        assId = AssemblyOrders.getAssId(orderNum);
                        ParamsDict.Add("ID", assId.ToString());
                        SQLOracle.delete("delete from USP_ASSEMBLIES where ID = :ID", ParamsDict);

                        //Удаляем элементы сборок
                        SQLOracle.delete("delete from USP_ASSEMBLY_ELEMENTS where ASSEMBLY_ID = :ID", ParamsDict);

                        //Удаляем горячую статистику
                        ParamsDict.Clear();
                        ParamsDict.Add("NUM", orderNum);
                        SQLOracle.delete("delete from USP_HOT_STATS where ORDER_NUM = :NUM", ParamsDict);

                        cmdUpdate += "ASSEMBLY_ID = NULL, ";
                        cmdUpdate += "ASSEMBLY_ELEMENTS_COUNT = NULL, ";
                    }
                    cmdUpdate += "DOC_STATUS = 1, ASSEMBLY_SECTOR_NUM = NULL, ASSEMBLY_NUM = NULL, ASSEMBLY_CREATOR_SURNAME = NULL, BRIGADIER_SURNAME = NULL, ASSEMBLY_CREATION_DATE = NULL, ";

                    cmdUpdate += "ASSEMBLY_GETER_POSITION = NULL, ASSEMBLY_GETER_SURNAME = NULL, ASSEMBLY_GIVER_SURNAME = NULL, ASSEMBLY_PLANNED_RETURN_DATE = NULL, ASSEMBLY_DELIVERY_DATE = NULL, ";
                    cmdUpdate += "ASSEMBLY_RETURN_GIVER_SURNAME = NULL, ASSEMBLY_RETURN_GETER_SURNAME = NULL, ASSEMBLY_RETURN_DATE = NULL";

                    if (isTZ(orderNum))
                    {
                        string TZId = AssemblyOrders.getTZId(orderNum);

                        Dictionary<string, string> PDict = new Dictionary<string, string>();
                        PDict.Add("TZ_ID", TZId);

                        string cmdUpdate1 = "update USP_TZ_DATA set UTV = 1, HP_KOL_EDEN = null where ID_DOC = :TZ_ID";
                        SQLOracle.update(cmdUpdate1, PDict);

                        cmdUpdate = "update USP_TZ_DATA_TP set OBOZN_KOMP = NULL, NAIM_KOMP = NULL, KOL = null where ID_DOC = :TZ_ID";
                        SQLOracle.update(cmdUpdate, PDict);
                    }
                    break;
                case 2:
                    cmdUpdate += "DOC_STATUS = 2, ASSEMBLY_GETER_POSITION = NULL, ASSEMBLY_GETER_SURNAME = NULL, ASSEMBLY_GIVER_SURNAME = NULL, ASSEMBLY_PLANNED_RETURN_DATE = NULL, ASSEMBLY_DELIVERY_DATE = NULL, ";
                    cmdUpdate += "ASSEMBLY_RETURN_GIVER_SURNAME = NULL, ASSEMBLY_RETURN_GETER_SURNAME = NULL, ASSEMBLY_RETURN_DATE = NULL";
                    break;
                case 3:
                    cmdUpdate += "DOC_STATUS = 3, ASSEMBLY_RETURN_GIVER_SURNAME = NULL, ASSEMBLY_RETURN_GETER_SURNAME = NULL, ASSEMBLY_RETURN_DATE = NULL";

                    //Вставляем горячую статистику

                    ParamsDict.Clear();
                    assId = AssemblyOrders.getAssId(orderNum);
                    Dictionary<string, string> ElementsDict = _ASSEMBLIES.getElements(assId);
                    string cmdInsert = "insert into USP_HOT_STATS (ORDER_NUM, ELEMENT_TITLE, ELEMENTS_COUNT) values (:ORDER_NUM, :ELEMENT_TITLE, :ELEMENTS_COUNT)";

                    foreach (KeyValuePair<string, string> Pair in ElementsDict)
                    {
                        ParamsDict.Add("ORDER_NUM", orderNum);
                        ParamsDict.Add("ELEMENT_TITLE", Pair.Key);
                        ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                        SQLOracle.insert(cmdInsert, ParamsDict);
                        ParamsDict.Clear();
                    }
                    break;
            }
            cmdUpdate += " where NUM = :NUM";
            SQLOracle.update(cmdUpdate, Dict);
        }
    }
