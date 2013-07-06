using System;
using System.Windows.Forms;

namespace UchetUSP
{
    static class Program
    {

        private static string InputConnectionString;

        private static string InputPathString;

        private static string InputEditRighsString;

        private static string InputDocIdString;

        private static string InputDocIdUtv;


        /// <summary>
        /// Строка соединения
        /// </summary>
        public static string ConnectionString
        {
            set 
            {
                InputConnectionString = value;
            }   

            get{
                return InputConnectionString;
             }
        }


        /// <summary>
        /// Временное хранилище
        /// </summary>
        public static string PathString
        {
            set
            {
                InputPathString = value;
            }

            get
            {
                return InputPathString;
            }
        }

        /// <summary>
        /// Статус редактирования
        /// </summary>
        public static string EditRighsString
        {
            set
            {
                InputEditRighsString = value;
            }

            get
            {
                return InputEditRighsString;
            }
        }

        /// <summary>
        /// Id документа
        /// </summary>
        public static string DocIdString
        {
            set
            {
                InputDocIdString = value;
            }

            get
            {
                return InputDocIdString;
            }
        }


        /// <summary>
        /// Статус документа
        /// </summary>
        public static string DocIdUtv
        {
            set
            {
                InputDocIdUtv = value;
            }

            get
            {
                return InputDocIdUtv;
            }
        }
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ConnectionString = args[0];                
            }

            if (args.Length >= 1)
            {
                PathString = args[1];                
            }

            
            if (args.Length >= 2)
            {
                EditRighsString = args[2];               
            }
           
            if (args.Length >= 3)
            {
                DocIdString = args[3];                
            }

            if (args.Length >= 4)
            {
                DocIdUtv = args[4];                
            }

            //ConnectionString = "/@";
            //PathString = @"C:\Documents and Settings";
            //EditRighsString = "0";
            //DocIdString = "0";
            //DocIdUtv = "0";

#if(DEBUG)
            ConnectionString = "591014/591000@BASEEOI";
            PathString = @"F:\tmp";
            EditRighsString = "0";
            DocIdString = "0";
            DocIdUtv = "0";
#endif
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (SQLOracle.UnloadDll("Interop.Microsoft.Office.Interop.Excel.dll"))
            {
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Не удалось выгрузить Excel.dll!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}