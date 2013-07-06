using System.Collections.Generic;

class xlsAssemblyOrder2 : ExcelClass
{
    private string templateName = @"assemblyOrder2.XLT";

    Dictionary<string, string> D;
    Dictionary<string, string> elementsDict;


    public xlsAssemblyOrder2(Dictionary<string, string> Dict, Dictionary<string, string> Elements)
    {
        this.D = new Dictionary<string, string>(Dict);
        this.elementsDict = Elements;
    }

    //янгдюрэ мнбши днйслемр
    public void createDocument()
    {
        UchetUSP.HashCode.HashCode.CheckFileByHash(templateName);

        if (System.IO.File.Exists(UchetUSP.Program.PathString + "\\" + templateName))
        {
            NewDocument(templateName);

            _fillDocument();

            this.Visible = true;
        }
    }

    void _fillDocument()
    {
        _writeFromD("NUM", "I4");
        _writeFromD("CREATION_DATE", "A19");
        _writeFromD("DEMAND_DATE", "G19");
        _writeFromD("TZ_NUM", "I7");
        _writeFromD("WORKSHOP_CODE", "P4");
        _writeFromD("PRODUCT_CODE", "R4");
        _writeFromD("PART_NAME", "A7");
        _writeFromD("PART_TITLE", "T4");
        _writeFromD("TECH_OPERATION_NAME", "M7");
        _writeFromD("PARTS_COUNT", "S7");
        _writeFromD("CUSTOMER_SURNAME", "W7");
        _writeFromD("CREATOR_SURNAME", "W19");
        _writeFromD("ASSEMBLY_NUM", "M4");
        _writeFromD("ASSEMBLY_CREATOR_SURNAME", "K19");
        _writeFromD("ASSEMBLY_GIVER_SURNAME", "W19");
        _writeFromD("ASSEMBLY_DELIVERY_DATE", "A16");
        _writeFromD("ASSEMBLY_GETER_POSITION", "H16");
        _writeFromD("ASSEMBLY_GETER_SURNAME", "R16");
        _writeFromD("ASSEMBLY_PLANNED_RETURN_DATE", "W16");

        _fillElements(elementsDict);
    }

    void _fillElements(Dictionary<string, string> Dict)
    {
        int id = 1;
        int firstRow = 25;

        string letter1 = "A";
        string letter2 = "C";
        string letter3 = "I";

        int row = firstRow;
        foreach (KeyValuePair<string, string> pair in Dict)
        {
            WriteDataToCell(letter1 + row, id.ToString());
            WriteDataToCell(letter2 + row, pair.Key);
            WriteDataToCell(letter3 + row, pair.Value);

            row++;
            if (id == 18)
            {
                row = firstRow;
                letter1 = "S";
                letter2 = "T";
                letter3 = "Z";
            }
            else
            {
                if (id == 9)
                {
                    row = firstRow;
                    letter1 = "J";
                    letter2 = "K";
                    letter3 = "R";
                }
            }
            id++;
        }
    }


    void _writeFromD(string key, string adress)
    {
        if (D.ContainsKey(key))
            WriteDataToCell(adress, D[key]);
    }
}