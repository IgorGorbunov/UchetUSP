using System;
using System.Collections.Generic;

namespace UchetUSP
{
    /// <summary>
    /// Класс для формирования листов ТЗ
    /// </summary>
    class xlsTZ : ExcelClass, IDisposable
    {
        private int _verticalDisplacement = 53;
        private string _templateName = @"TZ.xlt";

        private Dictionary<string, string> _D;
        //private int _listCount = 4;

        /// <summary>
        /// Конструктор для передачи данных
        /// </summary>
        /// <param name="Dict">Dictionary с данными листов ТЗ</param>
        public xlsTZ(Dictionary<string, string> Dict)
        {
            _D = Dict;
        }

        /// <summary>
        /// Метод создает и выводит на экран созданный документ
        /// </summary>
        public void createDocument()
        {
            HashCode.HashCode.CheckFileByHash(_templateName);

            if (System.IO.File.Exists(Program.PathString + "\\" + _templateName))
            {
                NewDocument(_templateName);
                
                /*for (int i = 1; i <= _listCount; i++)
                {
                    if (i != 1)
                        copyList(i);
                }
                for (int i = 1; i <= _listCount; i++)
                {
                    fillDocument(i);
                }*/
                fillDocument(1);
                Visible = true;



                if (_D.ContainsKey("SKETCH_PATH"))
                {
                    OpenDocument(_D["SKETCH_PATH"]);
                }
            }




            
            
            
        }

        private void fillDocument(int listNumber)
        {
            writeNumber(listNumber);
            writeWorkShopCode(listNumber);
            writeProductCode(listNumber);
            writeVPPNumber(listNumber);
            writeQueue(listNumber);
            writeClassficCode(listNumber);
            writeEquipTitle(listNumber);
            writeDrawingTitle(listNumber);
            writeDeliveryCondition(listNumber);
            writeManufactLocation(listNumber);
            writePlantList(listNumber);
            writeBasing(listNumber);
            writeTechRequirements(listNumber);
            writeListNumber(listNumber);
            writeListCount(listNumber);

            //this.AddNewPageAtTheEnd("Эскиз");

            /*WriteDataToCell("E2", _D["productCode1"]);
            WriteDataToCell("H2", _D["workShopCode1"]);
            WriteDataToCell("L2", _D["number1"]);
            WriteDataToCell("R2", _D["VPPnumber1"]);
            WriteDataToCell("H3", "1");*/



        }

        private void writeNumber(int listNumber)
        {
            if (_D.ContainsKey("number" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("L" + adress, _D["number" + listNumber]);
            }
        }

        private void writeWorkShopCode(int listNumber)
        {
            if (_D.ContainsKey("workShopCode" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("P" + adress, _D["workShopCode" + listNumber]);
            }
        }

        private void writeProductCode(int listNumber)
        {
            if (_D.ContainsKey("productCode" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("R" + adress, _D["productCode" + listNumber]);
            }
        }

        private void writeVPPNumber(int listNumber)
        {
            if ((_D.ContainsKey("VPPNumber" + listNumber))
                && (_D.ContainsKey("position" + listNumber)))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("L" + adress, _D["VPPNumber" + listNumber]
                    + "-" + _D["position" + listNumber]);
            }
        }

        private void writeQueue(int listNumber)
        {
            if (_D.ContainsKey("queue" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("P" + adress, _D["queue" + listNumber]);
            }
        }

        private void writeClassficCode(int listNumber)
        {
            if (_D.ContainsKey("classficCode" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("R" + adress, _D["classficCode" + listNumber]);
            }
        }

        private void writeEquipTitle(int listNumber)
        {
            if (_D.ContainsKey("equipTitle" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 4 + disp;
                WriteDataToCell("C" + adress, _D["equipTitle" + listNumber]);
            }
        }

        private void writeDrawingTitle(int listNumber)
        {
            if (_D.ContainsKey("drawingTitle" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 6 + disp;
                WriteDataToCell("J" + adress, _D["drawingTitle" + listNumber]);
            }
        }

        private void writeDeliveryCondition(int listNumber)
        {
            if (_D.ContainsKey("deliveryCondition" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 11 + disp;
                WriteDataToCell("J" + adress, _D["deliveryCondition" + listNumber]);
            }
        }

        private void writeManufactLocation(int listNumber)
        {
            if (_D.ContainsKey("manufactLocation" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 17 + disp;
                WriteDataToCell("J" + adress, _D["manufactLocation" + listNumber]);
            }
        }

        private void writePlantList(int listNumber)
        {
            if (_D.ContainsKey("plantList" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 24 + disp;
                WriteDataToCell("J" + adress, _D["plantList" + listNumber]);
            }
        }

        private void writeBasing(int listNumber)
        {
            if (_D.ContainsKey("basing" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 31 + disp;
                WriteDataToCell("J" + adress, _D["basing" + listNumber]);
            }
        }

        private void writeTechRequirements(int listNumber)
        {
            if (_D.ContainsKey("techRequirements" + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = 34 + disp;
                WriteDataToCell("J" + adress, _D["techRequirements" + listNumber]);
            }
        }

        private void writeListNumber(int listNumber)
        {
            int disp = _verticalDisplacement * (listNumber - 1);
            int adress = 48 + disp;
            WriteDataToCell("T" + adress, "1");
        }

        private void writeFromD(string key, string firstH, int firstV, int listNumber)
        {
            if (_D.ContainsKey(key + listNumber))
            {
                int disp = _verticalDisplacement * (listNumber - 1);
                int adress = firstV + disp;
                WriteDataToCell(firstH + adress, _D[key + listNumber]);
            }
        }

        private void writeListCount(int listNumber)
        {
            int disp = _verticalDisplacement * (listNumber - 1);
            int adress = 51 + disp;
            WriteDataToCell("T" + adress, "1");
        }

        private void copyList(int listNumber)
        {
            int disp = _verticalDisplacement * (listNumber - 1) + 1;
            copyCells("A1", "T51", "A" + disp);
        }

    }
}