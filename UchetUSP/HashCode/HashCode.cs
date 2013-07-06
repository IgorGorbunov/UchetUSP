using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace UchetUSP.HashCode
{
    class HashCode
    {
        public static void CheckFileByHash(string name)
        { 
            UpdateFile(name);
        }

        private static string GetHashOfFile(string name)
        { 
            MD5 myHashh = new MD5CryptoServiceProvider();
            FileStream fss = new FileStream(Program.PathString + "\\" + name, FileMode.Open, FileAccess.Read);
            BinaryReader brr = new BinaryReader(fss);
            myHashh.ComputeHash(brr.ReadBytes((int)fss.Length));
                   
            IDisposable d = (IDisposable)fss;
            d.Dispose();
            IDisposable b = (IDisposable)brr;
            b.Dispose();

            return Convert.ToBase64String(myHashh.Hash);            
        }

        private static string GetHashOfBD(string name)
        {            
            return SQLOracle.ParamQuerySelectObject("SELECT HASHFILE FROM USP_TEMPLATES WHERE NAMEFILE = :NAMEFILE","NAMEFILE",name);
        }

        private static bool CompareHashCode(string name)
        {
            if (String.Compare(GetHashOfBD(name), GetHashOfFile(name)) == 0)
            {               
                return true;
            }else
            {               
                return false;
            }
        }

        private static void UpdateFile(string name)
        {
            if (File.Exists(Program.PathString + "\\" + name))
            {
                if (CompareHashCode(name) == false)
                {
                    File.Delete(Program.PathString + "\\" + name);
                    SQLOracle.UnloadDoc(name);
                }
            }
            else {
                SQLOracle.UnloadDoc(name);
            }
        }


    }
}
