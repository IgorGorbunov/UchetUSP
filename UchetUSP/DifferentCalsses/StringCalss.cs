using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.DifferentCalsses
{
    class StringCalss
    {
        /// <summary>
        ///�������� ��������� 3 ������� (�������, �������� � �.�.)
        /// </summary>
        /// <param name="sentence">���������</param>
        /// <returns>������������ ������</returns>
        public static string CutLastLetter(string sentence)
        {
            if (sentence.Length > 2)
            {
                sentence = sentence.Remove(sentence.Length - 2);
            }

            return sentence;
        }


        /// <summary>
        ///����������� bool checkbox.checked � 0 � 1
        /// </summary>
        /// <param name="chCox">�������������� CheckBox</param>
        /// <returns>0 - false;
        /// 1- true;</returns>
        public static string ReturnCheckedStatus(CheckBox chBox)
        {
            if (chBox.Checked == true)
            {
                return "1";
            }
            else {
                return "0";
            }

        }

        /// <summary>
        ///����������� string � bool 
        /// </summary>
        /// <param name="chCox">�������������� CheckBox</param>
        /// <returns>0 - false;
        /// 1- true;</returns>
        public static bool ReturnCheckedStatus(string chBox)
        {
            if (String.Compare(chBox,"0")==0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
