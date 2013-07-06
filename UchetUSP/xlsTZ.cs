 using System;

    class xlsTZ : ExcelClass 
    {
        private int verticalDisplacement = 52;
        private string templateName = @"TZ.xlt";

        private System.Collections.Generic.Dictionary<string, string> D = new System.Collections.Generic.Dictionary<string, string>();
        private int listCount = 4;

        public xlsTZ()
        {           
            D.Add("number1", "02");
            D.Add("workShopCode1", "221");
            D.Add("productCode1", "007600");
            D.Add("VPPNumber1", "47617539");
            D.Add("queue1", "1");
            D.Add("classficCode1", "4012");
            D.Add("equipTitle1", "Оправка гибочная");
            D.Add("drawingTitle1", "чертеж");
            D.Add("deliveryCondition1", "поставка");
            D.Add("manufactLocation1", "см. эскиз");
            D.Add("plantList1", "оборудование");
            D.Add("basing1", "базирование");
            D.Add("techRequirements1", "технические требования");
            D.Add("position1", "1");

            D.Add("number2", "02");
            D.Add("workShopCode2", "221");
            D.Add("productCode2", "007600");
            D.Add("VPPNumber2", "47617539");
            D.Add("queue2", "1");
            D.Add("classficCode2", "4012");
            D.Add("equipTitle2", "Оправка гибочная");
            D.Add("drawingTitle2", "чертеж");
            D.Add("deliveryCondition2", "поставка");
            D.Add("manufactLocation2", "см. эскиз");
            D.Add("plantList2", "оборудование");
            D.Add("basing2", "базирование");
            D.Add("techRequirements2", "технические требования");
            D.Add("position2", "2");

            D.Add("number3", "02");
            D.Add("workShopCode3", "221");
            D.Add("productCode3", "007600");
            D.Add("VPPNumber3", "47617539");
            D.Add("queue3", "1");
            D.Add("classficCode3", "4012");
            D.Add("equipTitle3", "Оправка гибочная");
            D.Add("drawingTitle3", "чертеж");
            D.Add("deliveryCondition3", "поставка");
            D.Add("manufactLocation3", "см. эскиз");
            D.Add("plantList3", "оборудование");
            D.Add("basing3", "базирование");
            D.Add("techRequirements3", "технические требования");
            D.Add("position3", "3");

            D.Add("number4", "02");
            D.Add("workShopCode4", "221");
            D.Add("productCode4", "007600");
            D.Add("VPPNumber4", "47617539");
            D.Add("queue4", "1");
            D.Add("classficCode4", "4012");
            D.Add("equipTitle4", "Оправка гибочная");
            D.Add("drawingTitle4", "чертеж");
            D.Add("deliveryCondition4", "поставка");
            D.Add("manufactLocation4", "см. эскиз");
            D.Add("plantList4", "оборудование");
            D.Add("basing4", "базирование");
            D.Add("techRequirements4", "технические требования");
            D.Add("position4", "4");
        }

        //СОЗДАТЬ НОВЫЙ ДОКУМЕНТ
        public void createDocument()
        {
            NewDocument(templateName);

            for (int i = 1; i <= listCount; i++)
            {
                if (i != 1)
                    copyList(i);
                fillDocument(i);
            }

            Visible = true;
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
        }

        private void writeNumber(int listNumber)
        {
            if (D.ContainsKey("number" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("L" + adress, D["number" + listNumber]);
            }
        }

        private void writeWorkShopCode(int listNumber)
        {
            if (D.ContainsKey("workShopCode" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("P" + adress, D["workShopCode" + listNumber]);
            }
        }

        private void writeProductCode(int listNumber)
        {
            if (D.ContainsKey("productCode" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 3 + disp;
                WriteDataToCell("R" + adress, D["productCode" + listNumber]);
            }
        }

        private void writeVPPNumber(int listNumber)
        {
            if ((D.ContainsKey("VPPNumber" + listNumber))
                && (D.ContainsKey("position" + listNumber)))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("L" + adress, D["VPPNumber" + listNumber]
                    + "-" + D["position" + listNumber]);
            }
        }

        private void writeQueue(int listNumber)
        {
            if (D.ContainsKey("queue" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("P" + adress, D["queue" + listNumber]);
            }
        }

        private void writeClassficCode(int listNumber)
        {
            if (D.ContainsKey("classficCode" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 5 + disp;
                WriteDataToCell("R" + adress, D["classficCode" + listNumber]);
            }
        }

        private void writeEquipTitle(int listNumber)
        {
            if (D.ContainsKey("equipTitle" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 4 + disp;
                WriteDataToCell("C" + adress, D["equipTitle" + listNumber]);
            }
        }

        private void writeDrawingTitle(int listNumber)
        {
            if (D.ContainsKey("drawingTitle" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 6 + disp;
                WriteDataToCell("J" + adress, D["drawingTitle" + listNumber]);
            }
        }

        private void writeDeliveryCondition(int listNumber)
        {
            if (D.ContainsKey("deliveryCondition" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 11 + disp;
                WriteDataToCell("J" + adress, D["deliveryCondition" + listNumber]);
            }
        }

        private void writeManufactLocation(int listNumber)
        {
            if (D.ContainsKey("manufactLocation" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 17 + disp;
                WriteDataToCell("J" + adress, D["manufactLocation" + listNumber]);
            }
        }

        private void writePlantList(int listNumber)
        {
            if (D.ContainsKey("plantList" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 24 + disp;
                WriteDataToCell("J" + adress, D["plantList" + listNumber]);
            }
        }

        private void writeBasing(int listNumber)
        {
            if (D.ContainsKey("basing" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 31 + disp;
                WriteDataToCell("J" + adress, D["basing" + listNumber]);
            }
        }

        private void writeTechRequirements(int listNumber)
        {
            if (D.ContainsKey("techRequirementsr" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 34 + disp;
                WriteDataToCell("J" + adress, D["techRequirements" + listNumber]);
            }
        }

        private void writeListNumber(int listNumber)
        {
            if (D.ContainsKey("position" + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = 48 + disp;
                WriteDataToCell("T" + adress, D["position" + listNumber]);
            }
        }

        private void writeFromD(string key, string firstH, int firstV, int listNumber)
        {
            if (D.ContainsKey(key + listNumber))
            {
                int disp = verticalDisplacement * (listNumber - 1);
                int adress = firstV + disp;
                WriteDataToCell(firstH + adress, D[key + listNumber]);
            }
        }

        private void writeListCount(int listNumber)
        {
            int disp = verticalDisplacement * (listNumber - 1);
            int adress = 51 + disp;
            WriteDataToCell("T" + adress, listCount.ToString());
        }

        private void copyList(int listNumber)
        {
            SelectCells("A1", "T51");
            int disp = verticalDisplacement * (listNumber - 1);
            int adress = 1 + disp;
            CopyTo("A" + adress);
        }
    }