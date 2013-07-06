using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MSO.Excel
{
    public class Excel : IDisposable
    {
        public const string UID = "Excel.Application";
        object oExcel = null;
        object WorkBooks, WorkBook, WorkSheets, WorkSheet, Range, Interior;

        // ŒÕ—“–” “Œ–  À¿——¿
        public Excel()
        {
            oExcel = Activator.CreateInstance(Type.GetTypeFromProgID(UID));
        }

        //¬»ƒ»ÃŒ—“‹ EXCEL
        public bool Visible
        {
            set
            {
                if (false == value)
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { false });

                else
                    oExcel.GetType().InvokeMember("Visible", BindingFlags.SetProperty,
                        null, oExcel, new object[] { true });
            }
        }

        //Œ“ –€“‹ ƒŒ ”Ã≈Õ“
        public void OpenDocument(string name)
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Open", BindingFlags.InvokeMethod, null, WorkBooks, new object[] { name, true });
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            // Range = WorkSheet.GetType().InvokeMember("Range",BindingFlags.GetProperty,null,WorkSheet,new object[1] { "A1" });
        }

        //—Œ«ƒ¿“‹ ÕŒ¬€… ƒŒ ”Ã≈Õ“
        public void NewDocument()
        {
            WorkBooks = oExcel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, oExcel, null);
            WorkBook = WorkBooks.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, WorkBooks, null);
            WorkSheets = WorkBook.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, WorkBook, null);
            WorkSheet = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, WorkSheet, new object[1] { "A1" });
        }

        //«¿ –€“‹ ƒŒ ”Ã≈Õ“
        public void CloseDocument()
        {
            WorkBook.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, WorkBook, new object[] { true });
        }

        //—Œ’–¿Õ»“‹ ƒŒ ”Ã≈Õ“
        public void SaveDocument(string name)
        {
          

            if (File.Exists(name))
                WorkBook.GetType().InvokeMember("Save", BindingFlags.InvokeMethod, null,
                    WorkBook, null);
            else
            { 
                string sFilename = name;
                Object[] Parameters = new Object[12];
                Parameters[0] = sFilename;
                Parameters[1] = 39;//Excel.XlFileFormat.xlExcel8;
                Parameters[2] = Missing.Value;
                Parameters[3] = Missing.Value;
                Parameters[4] = false;
                Parameters[5] = false;
                Parameters[6] = 1;//Excel.XlSaveAsAccessMode.xlNoChange;
                Parameters[7] = Missing.Value;
                Parameters[8] = Missing.Value;
                Parameters[9] = Missing.Value;
                Parameters[10] = Missing.Value;
                Parameters[11] = Missing.Value;

                WorkBook.GetType().InvokeMember("SaveAs", BindingFlags.InvokeMethod, null,
                        WorkBook, Parameters);
                
            
            }
                
        }

        //”—“¿ÕŒ¬ ¿ ÷¬≈“¿ ‘ŒÕ¿ ﬂ◊≈… »
        public void SetColor(string range, int color)
        {
            //Range.Interior.ColorIndex
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });

            Interior = Range.GetType().InvokeMember("Interior", BindingFlags.GetProperty,
                null, Range, null);

            Range.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null,
                Interior, new object[] { color });
        }

        //Œ–»≈Õ“¿÷»» —“–¿Õ»÷€
        public enum XlPageOrientation
        {
            xlPortrait = 1, // ÌËÊÌ˚È
            xlLandscape = 2 // ¿Î¸·ÓÏÌ˚È
        }

        //”—“¿ÕŒ¬ ¿ Œ–»≈Õ“¿÷»» —“–¿Õ»÷€
        public void SetOrientation(XlPageOrientation Orientation)
        {
            //Range.Interior.ColorIndex
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("Orientation", BindingFlags.SetProperty,
                null, PageSetup, new object[] { 2 });
        }

        //”—“¿ÕŒ¬ ¿ –¿«Ã≈–Œ¬ œŒÀ≈… À»—“¿
        public void SetMargin(double Left, double Right, double Top, double Bottom)
        {
            //Range.PageSetup.LeftMargin - À≈¬Œ≈
            //Range.PageSetup.RightMargin - œ–¿¬Œ≈ 
            //Range.PageSetup.TopMargin - ¬≈–’Õ≈≈
            //Range.PageSetup.BottomMargin - Õ»∆Õ≈≈
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("LeftMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Left });
            PageSetup.GetType().InvokeMember("RightMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Right });
            PageSetup.GetType().InvokeMember("TopMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Top });
            PageSetup.GetType().InvokeMember("BottomMargin", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Bottom });
        }

        //–¿«Ã≈–€ À»—“¿
        public enum xlPaperSize
        {
            xlPaperA4 = 9,
            xlPaperA4Small = 10,
            xlPaperA5 = 11,
            xlPaperLetter = 1,
            xlPaperLetterSmall = 2,
            xlPaper10x14 = 16,
            xlPaper11x17 = 17,
            xlPaperA3 = 9,
            xlPaperB4 = 12,
            xlPaperB5 = 13,
            xlPaperExecutive = 7,
            xlPaperFolio = 14,
            xlPaperLedger = 4,
            xlPaperLegal = 5,
            xlPaperNote = 18,
            xlPaperQuarto = 15,
            xlPaperStatement = 6,
            xlPaperTabloid = 3
        }

        //”—“¿ÕŒ¬ ¿ –¿«Ã≈–¿ À»—“¿
        public void SetPaperSize(xlPaperSize Size)
        {
            //Range.PageSetup.PaperSize - –¿«Ã≈– À»—“¿
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("PaperSize", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Size });
        }

        //”—“¿ÕŒ¬ ¿ Ã¿—ÿ“¿¡¿ œ≈◊¿“»
        public void SetZoom(int Percent)
        {
            //Range.PageSetup.Zoom - Ã¿—ÿ“¿¡ œ≈◊¿“»
            object PageSetup = WorkSheet.GetType().InvokeMember("PageSetup", BindingFlags.GetProperty,
                null, WorkSheet, null);

            PageSetup.GetType().InvokeMember("Zoom", BindingFlags.SetProperty,
                null, PageSetup, new object[] { Percent });
        }

        //œ≈–≈»Ã≈ÕŒ¬¿“‹ À»—“
        public void ReNamePage(int n, string Name)
        {
            //Range.Interior.ColorIndex
            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { n });

            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty,
                null, Page, new object[] { Name });
        }

        //ƒŒ¡¿¬À≈Õ»≈ À»—“¿
        public void AddNewPage(string Name)
        {
            //Worksheet.Add.Item
            //Name - Õ‡Á‚‡ÌËÂ ÒÚ‡ÌËˆ˚
            WorkSheet = WorkSheets.GetType().InvokeMember("Add", BindingFlags.GetProperty, null, WorkSheets, null);

            object Page = WorkSheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, WorkSheets, new object[] { 1 });
            Page.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, Page, new object[] { Name });
        }

        //œ–»Ã≈Õ≈Õ»≈ ÿ–»‘“¿   ﬂ◊≈… ≈
        public void SetFont(string range, Font font)
        {
            //Range.Font.Name
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });

            object Font = Range.GetType().InvokeMember("Font", BindingFlags.GetProperty,
                null, Range, null);

            Range.GetType().InvokeMember("Name", BindingFlags.SetProperty, null,
                Font, new object[] { font.Name });

            Range.GetType().InvokeMember("Size", BindingFlags.SetProperty, null,
                Font, new object[] { font.Size });
        }

        //«¿œ»—‹ «Õ¿◊≈Õ»ﬂ ¬ ﬂ◊≈… ”
        public void SetValue(string range, string value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, Range, new object[] { value });
        }

        //Œ¡⁄≈ƒ»Õ≈Õ»≈ ﬂ◊≈≈ 
        public void SetMerge(string range, bool MergeCells)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            Range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, Range, new object[] { MergeCells });
        }

        //”—“¿ÕŒ¬ ¿ ÿ»–»Õ€ —“ŒÀ¡÷Œ¬
        public void SetColumnWidth(string range, double Width)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Width };
            Range.GetType().InvokeMember("ColumnWidth", BindingFlags.SetProperty, null, Range, args);
        }

        //”—“¿ÕŒ¬ ¿ Õ¿œ–¿¬À≈Õ»ﬂ “≈ —“¿
        public void SetTextOrientation(string range, int Orientation)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Orientation };
            Range.GetType().InvokeMember("Orientation", BindingFlags.SetProperty, null, Range, args);
        }

        //¬€–¿—Õ»¬¿Õ»≈ “≈ —“¿ ¬ ﬂ◊≈… ≈ œŒ ¬≈–“» ¿À»
        public void SetVerticalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("VerticalAlignment", BindingFlags.SetProperty, null, Range, args);
        }

        //¬€–¿¬Õ»¬¿Õ»≈ “≈ —“¿ ¬ ﬂ◊≈… ≈ œŒ √Œ–»«ŒÕ“¿À»
        public void SetHorisontalAlignment(string range, int Alignment)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Alignment };
            Range.GetType().InvokeMember("HorizontalAlignment", BindingFlags.SetProperty, null, Range, args);
        }


        //‘Œ–Ã¿“»–Œ¬¿Õ»≈ ” ¿«¿ÕÕŒ√Œ “≈ —“¿ ¬ ﬂ◊≈… ≈
        public void SelectText(string range, int Start, int Length, int Color, string FontStyle, int FontSize)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Start, Length };
            object Characters = Range.GetType().InvokeMember("Characters", BindingFlags.GetProperty, null, Range, args);
            object Font = Characters.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, Characters, null);
            Font.GetType().InvokeMember("ColorIndex", BindingFlags.SetProperty, null, Font, new object[] { Color });
            Font.GetType().InvokeMember("FontStyle", BindingFlags.SetProperty, null, Font, new object[] { FontStyle });
            Font.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, Font, new object[] { FontSize });

        }

        //œ≈–≈ÕŒ— —ÀŒ¬ ¬ ﬂ◊≈… ≈
        public void SetWrapText(string range, bool Value)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Value };
            Range.GetType().InvokeMember("WrapText", BindingFlags.SetProperty, null, Range, args);
        }

        //”—“¿ÕŒ¬ ¿ ¬€—Œ“€ —“–Œ »
        public void SetRowHeight(string range, double Height)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { Height };
            Range.GetType().InvokeMember("RowHeight", BindingFlags.SetProperty, null, Range, args);
        }

        //”—“¿ÕŒ¬ ¿ ¬»ƒ¿ √–¿Õ»÷
        public void SetBorderStyle(string range, int Style)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            object[] args = new object[] { 1 };
            object[] args1 = new object[] { 1 };
            object Borders = Range.GetType().InvokeMember("Borders", BindingFlags.GetProperty, null, Range, null);
            Borders = Range.GetType().InvokeMember("LineStyle", BindingFlags.SetProperty, null, Borders, args);
        }

        //◊“≈Õ»≈ «Õ¿◊≈Õ»ﬂ »« ﬂ◊≈… »
        public string GetValue(string range)
        {
            Range = WorkSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty,
                null, WorkSheet, new object[] { range });
            return Range.GetType().InvokeMember("Value", BindingFlags.GetProperty,
                null, Range, null).ToString();
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

        //”Õ»◊“Œ∆≈Õ»≈ Œ¡⁄≈ “¿ EXCEL
        public void Dispose()
        {         

            releaseObject(oExcel);
            GC.GetTotalMemory(true);
        }
    }
}
