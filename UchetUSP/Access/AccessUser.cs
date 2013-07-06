using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;


namespace UchetUSP.Access
{
    class Access
    {
         
        public static void GetUserRL()
        {
            MessageBox.Show(SQLOracle.ParamQuerySelect("SELECT RL FROM PDM_USR WHERE USR = :USR", "USR", SQLOracle._user)); 

        }
    }
}
