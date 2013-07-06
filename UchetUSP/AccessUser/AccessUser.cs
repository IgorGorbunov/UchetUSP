using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace UchetUSP.AccessUser
{
    class AccessUser
    {

        private static int Status = 4;

        private static int StatusOfDoc
        {
            set{
                Status = value;
            }
            get{
                return Status;
            }
        }


        /// <summary>
        ///Получение номера документа;
        /// </summary>          
        /// <returns>номер ТЗ</returns>  
        private static string GetDocId()
        {
            return "2005695";
        }


        /// <summary>
        ///Проверка документа на принадлежность текущему пользователю с возможностью редактирования;
        /// </summary>          
        /// <returns>true  - документ пренадлежит текущему пользователю 
        /// false - документ не пренадлежит текущему пользователю</returns>  
       public static bool GetUserRights()
        {
            if (GetStatusOfDoc() == 0)
            {                
                return SQLOracle.exist("USR_DOC", "PDM_DOC_PODP", "ID_DOC = '" + GetDocId() + "' AND USR_DOC = '" + SQLOracle._user + "'");
              
            }
            else { 

                return false;
            }
         
        }


        


        /// <summary>
        ///Получение статуса подписания документа
        /// </summary>         
        /// <returns>0 - создан;
        /// 1 - Подписал разработчик;
        /// 2 - Подписал Начальник ТБ;
        /// 3 - Подписал Начальник отд. УГТ;</returns> 
        private static int GetStatusOfDoc()
        {
            if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = 'Исполнитель'"),null)==0)
            {
                if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = 'Проверил'"), null) == 0)
                {
                    if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = 'Увердил'"), null) == 0)
                    {
                        StatusOfDoc = 3;
                    }
                    else {
                        StatusOfDoc = 2;
                    }
                }
                else {
                    StatusOfDoc = 1;
                }

            }else{

              StatusOfDoc = 0;

            }

            return StatusOfDoc;
  
        }
        
        /*
        /// <summary>
        ///Получение информации о разработчике документа
        /// </summary>         
        /// <returns>0 - Фамилия;
        /// 1 - Имя;
        /// 2 - Отчество;
        /// 3 - Телефон;
        /// 3 - Отдел;</returns> 
        public static  intGetInfoRazrab()
        {            
                       
        }*/


        /// <summary>
        ///Получение вида роли;
        /// </summary>
        /// <param name="typeOfRole">        
        /// Получение типа доступа к программе
        /// 0-Администратор;
        /// 1-Кладовщица;
        /// 2-Технолог;
        /// 3-Начальник ТБ;
        /// 4-Начальник отд. УГТ;</param>      
        /// <returns></returns>  
        public static bool GetRLType(int typeOfRole)
        {
           string role = SQLOracle.ParamQuerySelect("SELECT RL FROM PDM_USR WHERE USR = :USR", "USR", SQLOracle._user);

           if (typeOfRole == 0)
           {
               if ((String.Compare(role.Substring(92, 1), "1") == 0) && String.Compare(role.Substring(91, 1), "1") == 0)
               {                   
                   return true;
               }                 
           }

           if (typeOfRole == 1)
           {
               if (String.Compare(role.Substring(91, 1), "1") == 0)
               {                   
                   return true;
               }
           }

           if (typeOfRole == 2)
           {
               if ((String.Compare(role.Substring(92, 1), "1") == 0) || String.Compare(role.Substring(233, 1), "1") == 0)
               {                   
                   return true;
               }
           }

           if (typeOfRole == 3)
           {
               if ((String.Compare(role.Substring(235, 1), "1") == 0))
               {                  
                   return true;
               }
           }
            
           if (typeOfRole == 4)
           {
               if ((String.Compare(role.Substring(232, 1), "1") == 0))
               {                  
                   return true;
               }
           }

           return false;


        }

        
        /// <summary>
        ///Проверка подписи документа
        /// </summary>          
        /// <returns>true - права технолога;
        /// false - отсутствие права технолога;
        /// </returns>  
        public static bool GetEditRights(string idDoc)
        {
            if (SQLOracle.exist("PDM_DOC_PODP", "USR IS NOT NULL AND ID_DOC = '" + idDoc+ "'"))
            {
                return true;
            }
            else
            {
                return false;                
            }

        }

        
        /// <summary>
        ///Проверка отдела создателя документа
        /// </summary>          
        /// <returns>true - отделы совпадают;
        /// false - отделы разные;
        /// </returns>  
        public static bool GetOtdAccess(string idDoc)
        {
            string OtdCreater = SQLOracle.ParamQuerySelectObject("SELECT PDM_USR.OTD FROM PDM_USR WHERE PDM_USR.USR = (SELECT PDM_DOC.USR FROM PDM_DOC WHERE PDM_DOC.ID_DOC = :ID_DOC)", "ID_DOC", idDoc);
            string otdAccesser = SQLOracle.ParamQuerySelectObject("SELECT OTD FROM PDM_USR WHERE USR = :USR","USR",SQLOracle._user).ToString();
           
            if (String.Compare(OtdCreater, otdAccesser) == 0)
            {
                return true;
            }
            else {
               
                return false;
            }
        }
 

        

        /// <summary>
        ///Получение прав технолога;
        /// </summary>          
        /// <returns>true - права технолога;
        /// false - отсутствие права технолога;
        /// </returns>  
        public static bool GetTehRights()
        {
            string role = SQLOracle.ParamQuerySelect("SELECT RL FROM PDM_USR WHERE USR = :USR", "USR", SQLOracle._user);

            if ((String.Compare(role.Substring(92, 1), "1") == 0) || (String.Compare(role.Substring(233, 1), "1") == 0)
                || (String.Compare(role.Substring(235, 1), "1") == 0) || (String.Compare(role.Substring(232, 1), "1") == 0))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        ///Права на просмотр докумета;
        /// </summary>          
        /// <returns>true - права на просмотр;
        /// false - отсутствие права на просмотр;
        /// </returns>  
        public static bool GetViewRights(string idDoc)
        {
            //если документ не подписан всеми представителями
            if (SQLOracle.exist("PDM_DOC_PODP", "USR IS NULL AND ID_DOC = '" + idDoc + "'"))
            {
                string role = SQLOracle.ParamQuerySelect("SELECT RL FROM PDM_USR WHERE USR = :USR", "USR", SQLOracle._user);
                //если документ просматривают начальики
                if ((String.Compare(role.Substring(235, 1), "1") == 0) || (String.Compare(role.Substring(232, 1), "1") == 0))
                {
                    return true;
                }//если документ просматривают разработчики - технологи с правами доступа
                else if ((String.Compare(role.Substring(92, 1), "1") == 0) || (String.Compare(role.Substring(233, 1), "1") == 0))
                {
                    if (GetOtdAccess(idDoc))//если документ просматривают разработчики из того же отделаб что и сам документ
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else {

                    return false;
                }
                
            }
            else
            {
                return true;
            }


        }


        public static string GetUsrDeveloperOtd(string idDoc)
        {
          return  SQLOracle.ParamQuerySelectObject("SELECT PDM_USR.OTD FROM PDM_USR WHERE PDM_USR.USR = (SELECT PDM_DOC.USR FROM PDM_DOC WHERE PDM_DOC.ID_DOC = :ID_DOC)", "ID_DOC", idDoc);
        }
    }
}
