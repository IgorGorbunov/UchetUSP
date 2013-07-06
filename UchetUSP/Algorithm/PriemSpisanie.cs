using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace UchetUSP.Algorithm
{
    class PriemSpisanie
    {
        public static string IsNullParametr(System.Windows.Forms.TextBox CheckThisBox)
        {
            string NameParametr = "";

            if ((CheckThisBox.Text.Length > 0))
            {

                foreach (char StrName in CheckThisBox.Text)
                {

                    NameParametr = String.Concat(NameParametr, Convert.ToString(StrName));

                }

                return NameParametr;

            }
            else
            {
                return NameParametr = " ";
            }
        }

      
        public static string IsNullParametr(System.Windows.Forms.ComboBox CheckThisBox)
        {
            string NameParametr = "";

            if ((CheckThisBox.Text.Length > 0))
            {

                foreach (char StrName in CheckThisBox.Text)
                {

                    NameParametr = String.Concat(NameParametr, Convert.ToString(StrName));

                }

                return NameParametr;

            }
            else
            {
                return NameParametr = " ";
            }
        }



      


        /// <summary>
        /// ������� �������� ������ �� TextBox
        /// </summary>
        /// <param name="CheckThisBox">       
        ///CheckThisBox.Text == "��������" - ���������� ��� ��������.
        ///CheckThisBox.Text == "" - ���������� 0 ��� ������������� ������ � �������������� ���������.
        ///CheckThisBox.Text == " " - ���������� 0 ��� ������������� ������ � �������������� ��������� (����� ������� ������� ��� �������� �� �� ������ ��������).</param>
        /// <returns></returns>   
        public static string IsEmptyParametr(System.Windows.Forms.TextBox CheckThisBox)
        {
            string NameParametr = "";

            if ((CheckThisBox.Text.Length > 0) && (String.Compare(CheckThisBox.Text," ")!=0))
            {

                foreach (char StrName in CheckThisBox.Text)
                {

                    NameParametr = String.Concat(NameParametr, Convert.ToString(StrName));

                }

                return NameParametr;

            }
            else if ((CheckThisBox.Text.Length > 0) && ((String.Compare(CheckThisBox.Text, "") == 0)))
            {
                return NameParametr = "0";
            }
            else
            {
                return NameParametr = "0";
            }
        }

        public static bool IsNumber(string num)
        {
            System.Text.RegularExpressions.Regex rxNums = new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (rxNums.IsMatch(num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void blockKeyNotNumber(KeyPressEventArgs e, System.Windows.Forms.TextBox textBox)
        {
            if (((int)e.KeyChar) == 22)
            {
                int resulDouble = 0;

                bool isdouble = Int32.TryParse(Clipboard.GetText(TextDataFormat.Text), out resulDouble);

                if (isdouble)
                {
                                        
                    return;

                }
                else
                {

                    MessageBox.Show("������������� ������ �� ������������� ��������� �������!");

                }
            }

            //ctrl+copy
            if (((int)e.KeyChar) == 3)
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return;
            }
            e.Handled = true;

        }


        public static void blockKeyNotNumberExceptPercent(KeyPressEventArgs e, System.Windows.Forms.TextBox textBox)
        {
            if (((int)e.KeyChar) == 22)
            {
                int resulDouble = 0;

                bool isdouble = Int32.TryParse(Clipboard.GetText(TextDataFormat.Text), out resulDouble);

                if (isdouble)
                {

                    return;

                }
                else
                {

                    MessageBox.Show("������������� ������ �� ������������� ��������� �������!");

                }
            }

            //shift+5 (%)
            if (((int)e.KeyChar) == 37)
            {
                return;
            }

            //ctrl+copy
            if (((int)e.KeyChar) == 3)
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return;
            }
            e.Handled = true;

        }

        public static void blockKeyNotNumber(KeyPressEventArgs e, System.Windows.Forms.ComboBox comboBox)
        {
            if (((int)e.KeyChar) == 22)
            {
                int resulDouble = 0;

                bool isdouble = Int32.TryParse(Clipboard.GetText(TextDataFormat.Text), out resulDouble);

                if (isdouble)
                {

                    return;

                }
                else
                {

                    MessageBox.Show("������������� ������ �� ������������� ��������� �������!");

                }
            }

            //ctrl+copy
            if (((int)e.KeyChar) == 3)
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
            }

            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return;
            }
            e.Handled = true;

        }


        public static void blockKeyNotMoney(KeyPressEventArgs e, System.Windows.Forms.TextBox textBox)
        {
            int counDot = 0;

            if (((int)e.KeyChar) == 22)
            {  
                double resulDouble=0;

                bool isdouble = double.TryParse( Clipboard.GetText(TextDataFormat.Text),out resulDouble);

                if (isdouble)
                {

                    textBox.Clear();
                    Clipboard.SetText(Convert.ToString(Math.Round(resulDouble, 2)));
                    return;

                }
                else {

                    MessageBox.Show("������������� ������ �� ������������� ��������� �������!");
       
                 }
            }
            //ctrl+copy
            if (((int)e.KeyChar) == 3)
            {
                return;
            }

            if(e.KeyChar == ',')
            {
                
                foreach (char symb in textBox.Text)
                { 
                    if(symb==',')
                    {
                        counDot++;
                    }
                        
                }

                if (counDot >= 1)
                {
                    MessageBox.Show("������ ������� ������ ����� ������� ��� ����!");
                }
                else {
                        return;
                    
                }

                counDot = 0;
            }
                

            if (e.KeyChar == (char)Keys.Back)
            {
                return;
               
            }

            if ((e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return; 
            }

            e.Handled = true;

        }


        public static void blockKeyNotMoneyLeaveEvent(System.Windows.Forms.TextBox textBox)
        {
    
             double resulDouble = 0;

                bool isdouble = double.TryParse(textBox.Text, out resulDouble);
               
                if (isdouble)
                {
                    textBox.Clear();
                    textBox.Text = Convert.ToString(Math.Round(resulDouble, 2));
                    
                }   
        }

        

    }


}
