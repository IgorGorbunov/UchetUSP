using System;
using System.Drawing;
using System.IO;
using System.Reflection;

using Excel =  Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

    public class ExcelClass
    {   
        
        private FolderBrowserDialog folderBrowserDialog1;
        Excel.ApplicationClass xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Workbooks xlWorkBooks;
        Excel.Worksheet xlWorkSheet;
        Excel.Worksheets xlWorkSheets;
        Excel.Range range;
        private object misValue = Type.Missing;

        private string templatePath = @"D:\USP\UchetUSP\Templates\";

        public ExcelClass()
        {
            xlApp = new Excel.ApplicationClass();
        }


        //ÂÈÄÈÌÎÑÒÜ EXCEL
        public bool Visible
        {
            set
            {
                if (false == value)
                    xlApp.Visible = false;

                else
                    xlApp.Visible = true;
            }
        }

     

        //ÑÎÇÄÀÒÜ ÍÎÂÛÉ ÄÎÊÓÌÅÍÒ
        public void NewDocument()
        {

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
         
            MessageBox.Show("Excel file created!");

        }

        //ÑÎÇÄÀÒÜ ÍÎÂÛÉ ÄÎÊÓÌÅÍÒ C ØÀÁËÎÍÎÌ
        public void NewDocument(string templateName)
        {

            xlWorkBook = xlApp.Workbooks.Add(templatePath + templateName);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            MessageBox.Show("Excel file created!");

        }

        //ÎÒÊĞÛÒÜ ÄÎÊÓÌÅÍÒ
        public void OpenDocument(string name)
        {
            xlWorkBook = xlApp.Workbooks.Open(name, misValue, misValue, misValue, misValue,
                misValue, misValue, misValue, misValue, misValue, misValue,
                misValue, misValue, misValue, misValue);
            xlApp.Visible = true;
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        }


        //ÑÎÕĞÀÍÈÒÜ ÄÎÊÓÌÅÍÒ
        public void SaveDocument(string name)
        {
            xlApp.DisplayAlerts = true;
            if (File.Exists(name))
            {
                DialogResult result = MessageBox.Show("Òàêîé ôàéë óæå ñóùåñòâóåò! Çàìåíèòü åãî?", "Error",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);

                 if (result == DialogResult.Yes)
                {
                    File.Delete(name);
                    xlWorkBook.SaveAs(name, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                }
            }else
            {
                xlWorkBook.SaveAs(name, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            }      
            
        }

        //Âûäåëèòü ÿ÷åéêè
        public void SelectCells(Object start, Object end)
        {
            if (start == null)
            {
                start = misValue;
            }

            if (end == null)
            {
                start = misValue;
            }            
            range = xlWorkSheet.get_Range(start, end);
        }

        //Ñêîïèğîâàòü âûäåëåííûå ÿ÷åéêè
        public void CopyTo(Object cell)
        {
            Excel.Range rangeDest = xlWorkSheet.get_Range(cell, misValue);
            range.Copy(rangeDest);
        }

        //Âûäåëèòü ëèñò
        public void SelectWorksheet(int count)
        {
            if (count <= xlWorkBook.Worksheets.Count)
            {
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(count);
            }
            else {

                MessageBox.Show("Ïğîèçîøëà îøèáêà â êîäå! Âûäåëåí íåñóùåñòâóşùèé ëèñò!");

            }
            
        }



        //ÓÑÒÀÍÎÂÊÀ ÖÂÅÒÀ ÔÎÍÀ ß×ÅÉÊÈ

        public void SetColor(int color)
        {            
            range.Interior.Color = color;
            range.Interior.PatternColorIndex = Excel.Constants.xlAutomatic;
        }

        //ÎĞÈÅÍÒÀÖÈÈ ÑÒĞÀÍÈÖÛ
       
        public void SetOrientation(Excel.XlPageOrientation Orientation)
        {
            xlWorkSheet.PageSetup.Orientation = Orientation;
        }

        //ÓÑÒÀÍÎÂÊÀ ĞÀÇÌÅĞÎÂ ÏÎËÅÉ ËÈÑÒÀ
        public void SetMargin(double Left, double Right, double Top, double Bottom)
        {
            //Range.PageSetup.LeftMargin - ËÅÂÎÅ
            //Range.PageSetup.RightMargin - ÏĞÀÂÎÅ 
            //Range.PageSetup.TopMargin - ÂÅĞÕÍÅÅ
            //Range.PageSetup.BottomMargin - ÍÈÆÍÅÅ

            xlWorkSheet.PageSetup.RightMargin = Right;
            xlWorkSheet.PageSetup.LeftMargin = Left;
            xlWorkSheet.PageSetup.TopMargin = Top;
            xlWorkSheet.PageSetup.BottomMargin = Bottom;

        }


        //ÓÑÒÀÍÎÂÊÀ ĞÀÇÌÅĞÀ ËÈÑÒÀ
        public void SetPaperSize(Excel.XlPaperSize Size)
        {
            xlWorkSheet.PageSetup.PaperSize = Size;
        }

        //ÓÑÒÀÍÎÂÊÀ ÌÀÑØÒÀÁÀ ÏÅ×ÀÒÈ
        public void SetZoom(int percent)
        {
            xlWorkSheet.PageSetup.Zoom = percent;
                    
        }

        
        //ÏÅĞÅÈÌÅÍÎÂÀÒÜ ËÈÑÒ
        public void ReNamePage(int n, string Name)
        {

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(n);

            xlWorkSheet.Name = Name;
        }

        //ÄÎÁÀÂËÅÍÈÅ ËÈÑÒÀ Â ÍÀ×ÀËÎ ÑÏÈÑÊÀ
        public void AddNewPageAtTheStart(string Name)
        {          
           xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(misValue, misValue, misValue, misValue);

           this.ReNamePage(xlWorkSheet.Index, Name); 
           
        }

        //ÄÎÁÀÂËÅÍÈÅ ËÈÑÒÀ Â Êîíåö Ñïèñêà
        public void AddNewPageAtTheEnd(string Name)
        {
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Add(misValue, xlWorkBook.Worksheets.get_Item(xlWorkBook.Worksheets.Count), 1, misValue);

            this.ReNamePage(xlWorkSheet.Index, Name);

        }

        //ÏĞÈÌÅÍÅÍÈÅ ØĞÈÔÒÀ Ê ß×ÅÉÊÅ
        public void SetFont(Font font,int colorIndex)
        {            
            range.Font.Size = font.Size;
            range.Font.Bold = font.Bold;
            range.Font.Italic = font.Italic;
            range.Font.Name = font.Name;
            range.Font.ColorIndex = colorIndex;
        }


        //ÇÀÏÈÑÜ ÇÍÀ×ÅÍÈß Â ß×ÅÉÊÓ
        public void WriteDataToCell(string value)
        {
            range.Value2 = value;
        }

        public void WriteDataToCell(string cell, string value)
        {
            range = xlWorkSheet.get_Range(cell, misValue);
            range.Value2 = value;
        }

        //ÎÁÚÅÄÈÍÅÍÈÅ ß×ÅÅÊ
        public void SetMerge()
        {
            range.Merge(misValue);
        }

        //ÓÑÒÀÍÎÂÊÀ ØÈĞÈÍÛ ÑÒÎËÁÖÎÂ
        public void SetColumnWidth(double Width)
        {
            range.ColumnWidth = Width;           
        }

        //ÓÑÒÀÍÎÂÊÀ ÍÀÏĞÀÂËÅÍÈß ÒÅÊÑÒÀ
        public void SetTextOrientation(int Orientation)
        {
            range.Orientation = Orientation;           
        }

        //ÂÛĞÀÂÍÈÂÀÍÈÅ ÒÅÊÑÒÀ Â ß×ÅÉÊÅ ÏÎ ÂÅĞÒÈÊÀËÈ
        public void SetVerticalAlignment(int Alignment)
        {
            range.VerticalAlignment = Alignment;
        }

        //ÂÛĞÀÂÍÈÂÀÍÈÅ ÒÅÊÑÒÀ Â ß×ÅÉÊÅ ÏÎ ÃÎĞÈÇÎÍÒÀËÈ
        public void SetHorisontalAlignment(int Alignment)
        {
            range.HorizontalAlignment = Alignment;   
        }



        //ÏÅĞÅÍÎÑ ÑËÎÂ Â ß×ÅÉÊÅ
        public void SetWrapText(bool Value)
        {
            range.WrapText = Value;            
        }

        //ÓÑÒÀÍÎÂÊÀ ÂÛÑÎÒÛ ÑÒĞÎÊÈ
        public void SetRowHeight(double Height)
        {
            range.RowHeight = Height;         
        }

        //ÓÑÒÀÍÎÂÊÀ ÂÈÄÀ ÃĞÀÍÈÖ
        public void SetBorderStyle(int color, Excel.XlLineStyle LineStyle, Excel.XlBorderWeight Weight)
        {
            range.Borders.ColorIndex = color;
            range.Borders.LineStyle = LineStyle;
            range.Borders.Weight = Weight;
        }

        //×ÒÅÍÈÅ ÇÍÀ×ÅÍÈß ÈÇ ß×ÅÉÊÈ
        public string GetValue()
        {
            return range.Value2.ToString();
        }



        //Çàêğûòü äîêóìåíò
        public void closeDocument()
        {            
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();            
        }

        //Çàâåğøèòü ïğîöåññ
        public void exit()
        {
            xlApp.Quit();
        }

        //Óíè÷òîæåíèå îáúåêòà
        public void Dispose()
        {
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);         
            GC.GetTotalMemory(true);
        }
 
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
