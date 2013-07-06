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
            D.Add("equipTitle1", "������� ��������");
            D.Add("drawingTitle1", "������");
            D.Add("deliveryCondition1", "��������");
            D.Add("manufactLocation1", "��. �����");
            D.Add("plantList1", "������������");
            D.Add("basing1", "�����������");
            D.Add("techRequirements1", "����������� ����������");
            D.Add("position1", "1");

            D.Add("number2", "02");
            D.Add("workShopCode2", "221");
            D.Add("productCode2", "007600");
            D.Add("VPPNumber2", "47617539");
            D.Add("queue2", "1");
            D.Add("classficCode2", "4012");
            D.Add("equipTitle2", "������� ��������");
            D.Add("drawingTitle2", "������");
            D.Add("deliveryCondition2", "��������");
            D.Add("manufactLocation2", "��. �����");
            D.Add("plantList2", "������������");
            D.Add("basing2", "�����������");
            D.Add("techRequirements2", "����������� ����������");
            D.Add("position2", "2");

            D.Add("number3", "02");
            D.Add("workShopCode3", "221");
            D.Add("productCode3", "007600");
            D.Add("VPPNumber3", "47617539");
            D.Add("queue3", "1");
            D.Add("classficCode3", "4012");
            D.Add("equipTitle3", "������� ��������");
            D.Add("drawingTitle3", "������");
            D.Add("deliveryCondition3", "��������");
            D.Add("manufactLocation3", "��. �����");
            D.Add("plantList3", "������������");
            D.Add("basing3", "�����������");
            D.Add("techRequirements3", "����������� ����������");
            D.Add("position3", "3");

            D.Add("number4", "02");
            D.Add("workShopCode4", "221");
            D.Add("productCode4", "007600");
            D.Add("VPPNumber4", "47617539");
            D.Add("queue4", "1");
            D.Add("classficCode4", "4012");
            D.Add("equipTitle4", "������� ��������");
            D.Add("drawingTitle4", "������");
            D.Add("deliveryCondition4", "��������");
            D.Add("manufactLocation4", "��. �����");
            D.Add("plantList4", "������������");
            D.Add("basing4", "�����������");
            D.Add("techRequirements4", "����������� ����������");
            D.Add("position4", "4");
        }

        //������� ����� ��������
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