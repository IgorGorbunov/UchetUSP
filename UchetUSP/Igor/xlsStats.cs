using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace UchetUSP
{
    /// <summary>
    ///  ласс создани€ excel-документов со статистикой
    /// </summary>
    class xlsStats : ExcelClass
    {
        DataTable _DT;
        string[] _header;
        string[,] _arr;

        /// <summary>
        ///  онструктор создани€ таблицы из DataTable
        /// </summary>
        /// <param name="DT">DataTable со статистикой</param>
        public xlsStats(DataTable DT)
        {
            this._DT = DT;
            _setHeader();
            _setArr();
            _generateXLS();
        }

        void _setHeader()
        {
            int count = _DT.Columns.Count;
            _header = new string[count];

            for (int i = 0; i < count; i++)
            {
                _header[i] = _DT.Columns[i].ColumnName;
            }
        }

        void _setArr()
        {
            _arr = new string[_DT.Rows.Count, _DT.Columns.Count];

            for (int i = 0; i < _DT.Rows.Count; i++)
            {
                object[] row = _DT.Rows[i].ItemArray;
                for (int j = 0; j < _DT.Columns.Count; j++)
                {
                    _arr[i, j] = row[j].ToString();
                }
            }
        }

        void _generateXLS()
        {
            this.NewDocument();

            _writeHeader();
            char c = (char)(_header.Length + 66);
            setBold("B2", c + "2");

            _writeArr();

            setAutoFit("A:" + c);

            this.Visible = true;
        }

        void _writeHeader()
        {
            for (int i = 0; i < _header.Length; i++)
            {
                char c = (char)(i + 66);
                WriteDataToCell(c + "2", _header[i]);
            }
        }

        void _writeArr()
        {
            for (int i = 0; i < _arr.Length / _header.Length; i++)
            {
                for (int j = 0; j < _header.Length; j++)
                {
                    char c = (char)(j + 66);
                    string row = (i + 3).ToString();
                    string cell = c + row;

                    WriteDataToCell(cell, _arr[i, j].ToString());
                    this.SetBorderStyle(0, Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin);
                }
            }
        }
    }
}
