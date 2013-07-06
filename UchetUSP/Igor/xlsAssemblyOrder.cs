using System.Collections.Generic;
using System;

namespace UchetUSP
{
    class xlsAssemblyOrder : ExcelClass
    {
        private string templateName = @"assemblyOrder.XLT";

        private string _orderNum;
        Dictionary<string, string> _D = new Dictionary<string, string>();


        public xlsAssemblyOrder(string num)
        {
            _orderNum = num;
        }

        //—Œ«ƒ¿“‹ ÕŒ¬€… ƒŒ ”Ã≈Õ“
        public void createDocument()
        {
            HashCode.HashCode.CheckFileByHash(templateName);

            if (System.IO.File.Exists(Program.PathString + "\\" + templateName))
            {
                NewDocument(templateName);

                getProperties();
                fillDocument();
                Dictionary<string, string> DictElements = new Dictionary<string, string>();
                DictElements = _ASSEMBLY_ELEMENTS.getElementsDict(AssemblyOrders.getAssId(_orderNum));
                _fillElements(DictElements);

                this.Visible = true;
            }
        }


        void getProperties()
        {
            _D.Add("NUM", _orderNum);
            _D.Add("CREATION_DATE", AssemblyOrders.getCreationDate(_orderNum).ToShortDateString());
            _D.Add("DEMAND_DATE", AssemblyOrders.getDemandDate(_orderNum).ToShortDateString());
            _D.Add("TZ_NUM", AssemblyOrders.getTZnumber(_orderNum));

            int wSCode = AssemblyOrders.getWorkshopCode(_orderNum);
            if (wSCode != 0)
            {
                _D.Add("WORKSHOP_CODE", wSCode.ToString());
            }

            if (AssemblyOrders.isTZ(_orderNum))
            {
                string idDoc = AssemblyOrders.getTZId(_orderNum);
                string productCode = AssemblyOrders.getProductCode_TZ(idDoc);
                if (productCode != "0")
                {
                    _D.Add("PRODUCT_CODE", productCode);
                }
                _D.Add("PART_TITLE", AssemblyOrders.getPartTitle_TZ(idDoc));
            }
            else
            {
                _D.Add("PRODUCT_CODE", AssemblyOrders.getProductCode(_orderNum).ToString());
                _D.Add("PART_TITLE", AssemblyOrders.getPartTitle(_orderNum));
            }
            
            _D.Add("PART_NAME", AssemblyOrders.getPartName(_orderNum));
            
            _D.Add("TECH_OPERATION_NAME", AssemblyOrders.getTechOperationName(_orderNum));
            _D.Add("PARTS_COUNT", AssemblyOrders.getPartsCount(_orderNum).ToString());
            _D.Add("CUSTOMER_POSITION", AssemblyOrders.getCustomerPosition(_orderNum));
            _D.Add("CUSTOMER_SURNAME", AssemblyOrders.getCustomerSurname(_orderNum));
            _D.Add("CREATOR_SURNAME", AssemblyOrders.getCreatorSurname(_orderNum));

            int assNum = AssemblyOrders.getAssNum(_orderNum);
            if (assNum != 0)
	        {
                 _D.Add("ASSEMBLY_NUM", assNum.ToString());
	        }

            DateTime nullDate = new DateTime(1, 1, 1);
            DateTime date = AssemblyOrders.getAssDeliveryDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_DELIVERY_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_GETER_POSITION", AssemblyOrders.getAssGeterPosition(_orderNum));
            _D.Add("ASSEMBLY_GETER_SURNAME", AssemblyOrders.getAssGeterSurname(_orderNum));

            date = AssemblyOrders.getAssPlannedReturnDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_PLANNED_RETURN_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_CREATOR_SURNAME", AssemblyOrders.getAssCreatorSurname(_orderNum));
            _D.Add("ASSEMBLY_GIVER_SURNAME", AssemblyOrders.getAssGiverSurname(_orderNum));
            _D.Add("TECH_CONDITIONS", AssemblyOrders.getTechConditions(_orderNum));
            _D.Add("TECH_CONDITIONS_POSITION", AssemblyOrders.getTechConditionsPosition(_orderNum));
            _D.Add("TECH_CONDITIONS_SURNAME", AssemblyOrders.getTechConditionsSurname(_orderNum));

            date = AssemblyOrders.getAssCreationDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_CREATION_DATE", date.ToShortDateString());
            }

            _D.Add("ASSEMBLY_SECTOR_NUM", AssemblyOrders.getAssSectorNum(_orderNum));

            date = AssemblyOrders.getAssReturnDate(_orderNum);
            if (date != nullDate)
            {
                _D.Add("ASSEMBLY_RETURN_DATE", date.ToShortDateString());
            }

            setUSPParams();
            _D.Add("BRIGADIER_SURNAME", AssemblyOrders.getBrigadierSurname(_orderNum));

            _D.Add("ASSEMBLY_RETURN_GIVER_SURNAME", AssemblyOrders.getAssReturnGiverSurname(_orderNum).ToString());
            _D.Add("ASSEMBLY_RETURN_GETER_SURNAME", AssemblyOrders.getAssReturnGeterSurname(_orderNum).ToString());
        }

        void setUSPParams()
        {
            int assElCount = AssemblyOrders.getElementsCount(_orderNum);
            if (assElCount != 0)
            {
                _D.Add("ASSEMBLY_ELEMENTS_COUNT", assElCount.ToString());
            }

            int nStraps = AssemblyOrders.getStrapsCount(_orderNum);
            if (nStraps != 0)
            {
                _D.Add("ASSEMBLY_STRAPS_COUNT", nStraps.ToString());
            }

            int nNuts = AssemblyOrders.getNutsCount(_orderNum);
            if (nNuts != 0)
            {
                _D.Add("ASSEMBLY_NUTS_COUNT", nNuts.ToString());
            }

            int nSpElem = AssemblyOrders.getSpecialDowelsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_SPECIAL_DOWELS_COUNT", nSpElem.ToString());
            }

            nSpElem = AssemblyOrders.getSpecialElementsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_SPECIAL_ELEME_COUNT", nSpElem.ToString());
            }

            nSpElem = AssemblyOrders.getDimensionsCount(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_DIMENSIONS_COUNT", nSpElem.ToString());
            }

            nSpElem = AssemblyOrders.getDifficultyGroup(_orderNum);
            if (nSpElem != 0)
            {
                _D.Add("ASSEMBLY_DIFFICULTY_GROUP", nSpElem.ToString());
            }
        }

        void fillDocument()
        {
            _writeFromD("NUM", "E4");
            _writeFromD("NUM", "D24");
            _writeFromD("CREATION_DATE", "G4");
            _writeFromD("CREATION_DATE", "A39");
            _writeFromD("DEMAND_DATE", "K8");
            _writeFromD("DEMAND_DATE", "C39");
            _writeFromD("TZ_NUM", "D8");
            _writeFromD("TZ_NUM", "D27");
            _writeFromD("WORKSHOP_CODE", "H4");
            _writeFromD("WORKSHOP_CODE", "H24");
            _writeFromD("PRODUCT_CODE", "I8");
            _writeFromD("PRODUCT_CODE", "I24");
            _writeFromD("PART_NAME", "A8");
            _writeFromD("PART_NAME", "A27");
            _writeFromD("PART_TITLE", "I4");
            _writeFromD("PART_TITLE", "J24");
            _writeFromD("TECH_OPERATION_NAME", "G8");
            _writeFromD("TECH_OPERATION_NAME", "G27");
            _writeFromD("PARTS_COUNT", "J8");
            _writeFromD("PARTS_COUNT", "I27");
            _writeFromD("CUSTOMER_POSITION", "A19");
            _writeFromD("CUSTOMER_SURNAME", "G19");
            _writeFromD("CUSTOMER_SURNAME", "K27");
            _writeFromD("CREATOR_SURNAME", "K19");
            _writeFromD("ASSEMBLY_NUM", "G24");
            _writeFromD("ASSEMBLY_NUM", "U15");
            _writeFromD("ASSEMBLY_DELIVERY_DATE", "A36");
            _writeFromD("ASSEMBLY_GETER_POSITION", "D36");
            _writeFromD("ASSEMBLY_GETER_SURNAME", "I36");
            _writeFromD("ASSEMBLY_PLANNED_RETURN_DATE", "K36");
            _writeFromD("ASSEMBLY_CREATOR_SURNAME", "F39");
            _writeFromD("ASSEMBLY_GIVER_SURNAME", "K39");
            if (_D.ContainsKey("TECH_CONDITIONS"))
            {
                addValueToCell("O3", _D["TECH_CONDITIONS"]);
            }
            _writeFromD("TECH_CONDITIONS_POSITION", "N8");
            _writeFromD("TECH_CONDITIONS_SURNAME", "AE8");
            _writeFromD("ASSEMBLY_CREATION_DATE", "N15");
            _writeFromD("ASSEMBLY_SECTOR_NUM", "S15");

            _writeFromD("ASSEMBLY_ELEMENTS_COUNT", "W15");
            _writeFromD("ASSEMBLY_STRAPS_COUNT", "Z15");
            _writeFromD("ASSEMBLY_NUTS_COUNT", "AC15");
            _writeFromD("ASSEMBLY_SPECIAL_DOWELS_COUNT", "AE15");
            _writeFromD("ASSEMBLY_SPECIAL_ELEMEN_COUNT", "AG15");
            _writeFromD("ASSEMBLY_DIMENSIONS_COUNT", "AJ15");
            _writeFromD("ASSEMBLY_DIFFICULTY_GROUP", "AL15");

            _writeFromD("ASSEMBLY_CREATOR_SURNAME", "V19");
            _writeFromD("BRIGADIER_SURNAME", "AG19");

            _writeFromD("ASSEMBLY_RETURN_DATE", "N37");
            _writeFromD("ASSEMBLY_RETURN_DATE", "AA37");
            _writeFromD("ASSEMBLY_RETURN_GIVER_SURNAME", "V37");
            _writeFromD("ASSEMBLY_RETURN_GETER_SURNAME", "AJ37");
        }

        void _fillElements(Dictionary<string, string> Dict)
        {
            int id = 1;
            int firstRow = 25; 

            string letter1 = "N";
            string letter2 = "P";
            string letter3 = "V";

            int row = firstRow;
            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                WriteDataToCell(letter1 + row, id.ToString());
                WriteDataToCell(letter2 + row, Pair.Key);
                WriteDataToCell(letter3 + row, Pair.Value);

                row++;
                if (id == 18)
                {
                    row = firstRow;
                    letter1 = "AF";
                    letter2 = "AG";
                    letter3 = "AM";
                }
                else
                {
                    if (id == 9)
                    {
                        row = firstRow;
                        letter1 = "W";
                        letter2 = "X";
                        letter3 = "AE";
                    }
                }
                id++;
            }
        }

        void _writeFromD(string key, string adress)
        {
            if (_D.ContainsKey(key))
                WriteDataToCell(adress, _D[key].Trim());
        }
    }
}