using System;
using System.Data;

namespace UchetUSP
{
    /// <summary>
    /// Класс, создающий, генерирующий и отправляющий на печать карту учета сборок УСП
    /// </summary>
    class xlsAccountingCard : ExcelClass, IDisposable
    {
        DataSet _DS;

        DateTime _necessaryDate;

        string templateName = "assAccountingCard.xlt";

        public xlsAccountingCard(DateTime date)
        {
            _necessaryDate = date;
        }

        void createHeader()
        {
            WriteDataToCell("AP4", _necessaryDate.ToShortDateString());
            WriteDataToCell("BC4", AssemblyOrders.getBrigadierSurnameSettings());
        }
        void createDataSet()
        {
            _DS = AssemblyOrders.getAssembliesInfo(_necessaryDate);
        }

        /// <summary>
        /// Метод, создающий новый документ
        /// </summary>
        public void createDocument()
        {
            HashCode.HashCode.CheckFileByHash(templateName);

            if (System.IO.File.Exists(Program.PathString + "\\" + templateName))
            {
                createDataSet();

                NewDocument(templateName);
                fillDocument();

                this.Visible = true;
            }
        }

        void fillDocument()
        {
            createHeader();

            string[] colLetters = {"G", "M", "S", "V", "Z", "AD", "AH", "AL", "AW", "BJ", "BR", "BW", "CA"};
            object[] valArr;

            int colCount = _DS.Tables[0].Columns.Count;
            int rowCount = _DS.Tables[0].Rows.Count;

            int nAsses = AssemblyOrders.getNAssesInYear(_necessaryDate);
            int xlsRow = 14;
            for (int i = 0; i < rowCount; i++)
            {
                valArr = _DS.Tables[0].Rows[i].ItemArray;

                int row = i + 1;
                WriteDataToCell("D" + xlsRow, row.ToString());
                int row2 = nAsses + row;
                WriteDataToCell("A" + xlsRow, row2.ToString());
                for (int j = 0; j < colCount; j++)
			    {
                    WriteDataToCell(colLetters[j] + xlsRow, valArr[j].ToString().Trim());
			    }
                xlsRow += 2;
            }
        }
    }
}
