using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UchetUSP.LOG
{
     class Log
    {
        /// <summary>
        ///������ ����;
        /// </summary>
        /// <param name="CodError">        
        ///��� ������</param>
        /// <param name="Message">
        ///��������� �� ������</param>
        ///<param name="Line">
        ///������</param>
        ///<param name="File">
        ///���� </param>
        /// <returns></returns>  
         public static void WriteLog(Exception exept)
        {
            DirectoryInfo LogDir = new DirectoryInfo(Path.GetTempPath() + "LogsUchetUSP");

            if (!LogDir.Exists)
            {
                LogDir.Create();
            }
           
            StreamWriter str;
     
            if (!File.Exists((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log")))
            {
                str = new StreamWriter((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log"));
            }
            else
            {
                str = File.AppendText((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log"));
            }

            str.WriteLine();
            str.WriteLine("�����: " + DateTime.Now);                    
            str.WriteLine("************************");          
            str.WriteLine("������: " + exept.ToString());
            str.WriteLine("************************"); 
            str.WriteLine();

            str.Close();

            IDisposable d = (IDisposable)str;  
            d.Dispose();           
            str.Dispose();
            
             

            

        }

         public static void WriteLog(string exept)
         {
             DirectoryInfo LogDir = new DirectoryInfo(Path.GetTempPath() + "LogsUchetUSP");

             if (!LogDir.Exists)
             {
                 LogDir.Create();
             }

             StreamWriter str;

             if (!File.Exists((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log")))
             {
                 str = new StreamWriter((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log"));
             }
             else
             {
                 str = File.AppendText((LogDir.FullName + "\\logfile " + DateTime.Today.ToLongDateString() + ".log"));
             }

             str.WriteLine();
             str.WriteLine("�����: " + DateTime.Now);
             str.WriteLine("************************");
             str.Write("������: " + exept);
             str.WriteLine("************************");
             str.WriteLine();

             str.Close();

             IDisposable d = (IDisposable)str;
             d.Dispose();
             str.Dispose();





         }
    }
}
