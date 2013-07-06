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
        ///��������� ������ ���������;
        /// </summary>          
        /// <returns>����� ��</returns>  
        private static string GetDocId()
        {
            return "2005695";
        }


        /// <summary>
        ///�������� ��������� �� �������������� �������� ������������ � ������������ ��������������;
        /// </summary>          
        /// <returns>true  - �������� ����������� �������� ������������ 
        /// false - �������� �� ����������� �������� ������������</returns>  
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
        ///��������� ������� ���������� ���������
        /// </summary>         
        /// <returns>0 - ������;
        /// 1 - �������� �����������;
        /// 2 - �������� ��������� ��;
        /// 3 - �������� ��������� ���. ���;</returns> 
        private static int GetStatusOfDoc()
        {
            if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = '�����������'"),null)==0)
            {
                if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = '��������'"), null) == 0)
                {
                    if (String.Compare(SQLOracle.selectStr("SELECT USR FROM PDM_DOC_PODP WHERE ID_DOC = '" + GetDocId() + "' AND WNM = '�������'"), null) == 0)
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
        ///��������� ���������� � ������������ ���������
        /// </summary>         
        /// <returns>0 - �������;
        /// 1 - ���;
        /// 2 - ��������;
        /// 3 - �������;
        /// 3 - �����;</returns> 
        public static  intGetInfoRazrab()
        {            
                       
        }*/


        /// <summary>
        ///��������� ���� ����;
        /// </summary>
        /// <param name="typeOfRole">        
        /// ��������� ���� ������� � ���������
        /// 0-�������������;
        /// 1-����������;
        /// 2-��������;
        /// 3-��������� ��;
        /// 4-��������� ���. ���;</param>      
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
        ///�������� ������� ���������
        /// </summary>          
        /// <returns>true - ����� ���������;
        /// false - ���������� ����� ���������;
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
        ///�������� ������ ��������� ���������
        /// </summary>          
        /// <returns>true - ������ ���������;
        /// false - ������ ������;
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
        ///��������� ���� ���������;
        /// </summary>          
        /// <returns>true - ����� ���������;
        /// false - ���������� ����� ���������;
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
        ///����� �� �������� ��������;
        /// </summary>          
        /// <returns>true - ����� �� ��������;
        /// false - ���������� ����� �� ��������;
        /// </returns>  
        public static bool GetViewRights(string idDoc)
        {
            //���� �������� �� �������� ����� ���������������
            if (SQLOracle.exist("PDM_DOC_PODP", "USR IS NULL AND ID_DOC = '" + idDoc + "'"))
            {
                string role = SQLOracle.ParamQuerySelect("SELECT RL FROM PDM_USR WHERE USR = :USR", "USR", SQLOracle._user);
                //���� �������� ������������� ���������
                if ((String.Compare(role.Substring(235, 1), "1") == 0) || (String.Compare(role.Substring(232, 1), "1") == 0))
                {
                    return true;
                }//���� �������� ������������� ������������ - ��������� � ������� �������
                else if ((String.Compare(role.Substring(92, 1), "1") == 0) || (String.Compare(role.Substring(233, 1), "1") == 0))
                {
                    if (GetOtdAccess(idDoc))//���� �������� ������������� ������������ �� ���� �� ������� ��� � ��� ��������
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
