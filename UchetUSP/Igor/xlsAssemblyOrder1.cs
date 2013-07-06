using System.Collections.Generic;

/// <summary>
/// Класс для генерации первой части листа заказа
/// </summary>
class xlsAssemblyOrder1 : ExcelClass
{
    private string _templateName = @"assemblyOrder1.XLT";

    private Dictionary<string, string> _D;
    

    /// <summary>
    /// Конструктор принимает данные для генерации документа из Dictionary
    /// </summary>
    /// <param name="Dict">Dictionary с данными для генерации документа</param>
    public xlsAssemblyOrder1(Dictionary<string, string> Dict)
    {
        this._D = new Dictionary<string, string>(Dict);
        
    }

    /// <summary>
    /// Метод генерирует и открывает документ
    /// </summary>
    public void createDocument()
    {
        UchetUSP.HashCode.HashCode.CheckFileByHash(_templateName);

        if (System.IO.File.Exists(UchetUSP.Program.PathString + "\\" + _templateName))
        {
            NewDocument(_templateName);

            _fillDocument();

            this.Visible = true;
        }
    }

    void _fillDocument()
    {
        _writeFromD("NUM", "I4");
        _writeFromD("CREATION_DATE", "K4");
        _writeFromD("DEMAND_DATE", "W8");
        _writeFromD("TZ_NUM", "H8");
        _writeFromD("WORKSHOP_CODE", "O4");
        _writeFromD("PRODUCT_CODE", "R8");
        _writeFromD("PART_NAME", "A8");
        _writeFromD("PART_TITLE", "R4");
        _writeFromD("TECH_OPERATION_NAME", "K8");
        _writeFromD("PARTS_COUNT", "T8");
        _writeFromD("CUSTOMER_POSITION", "A19");
        _writeFromD("CUSTOMER_SURNAME", "M19");
        _writeFromD("CREATOR_SURNAME", "W19");

        if (_D.ContainsKey("TECH_CONDITIONS"))
        {
            addValueToCell("B23", _D["TECH_CONDITIONS"]);
        }
        _writeFromD("TECH_CONDITIONS_POSITION", "A29");
        _writeFromD("TECH_CONDITIONS_SURNAME", "R29");

        _writeFromD("ASSEMBLY_CREATION_DATE", "A36");
        _writeFromD("SECTOR_NUM", "F36");
        _writeFromD("ASSEMBLY_NUM", "H36");

        _writeFromD("ASSEMBLY_ELEMENTS_COUNT", "J36");
        _writeFromD("ASSEMBLY_STRAPS_COUNT", "M36");
        _writeFromD("ASSEMBLY_NUTS_COUNT", "P36");
        _writeFromD("ASSEMBLY_SPECIAL_DOWELS_COUNT", "R36");
        _writeFromD("ASSEMBLY_SPECIAL_ELEMEN_COUNT", "T36");
        _writeFromD("ASSEMBLY_DIMENSIONS_COUNT", "W36");
        _writeFromD("ASSEMBLY_DIFFICULTY_GROUP", "Y36");

        _writeFromD("ASSEMBLY_CREATOR_SURNAME", "I40");
        _writeFromD("BRIGADIER_SURNAME", "U40");
    }

    void _writeFromD(string key, string adress)
    {
        if (_D.ContainsKey(key))
            WriteDataToCell(adress, _D[key]);
    }
}