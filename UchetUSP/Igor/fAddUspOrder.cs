using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace UchetUSP
{
    /// <summary>
    /// ����� �������� ����� ������
    /// </summary>
    public partial class AddUspOrder : Form
    {
        byte _page;
        byte _lastPage;

        bool _isBttnOk, _isExecuteFromRightClick, _isWithoutProject, _demandDateIsEdited, _isTZ = false;

        int _docStatus;
        string _VPPNumber, _TZnumber, _idDoc = null;

        int _TZpoz;

        string _assemblyTitle = "";

        string _creator;
        string _technolog;

        int _nElements;

        Dictionary<string, string> _D, _Dexcel, _Elements;

        /// <summary>
        /// ������� ����� ��-��������� (� ������� ��)
        /// </summary>
        public AddUspOrder()
            : this(null, null, 0, 0, "", null)
        {
            _isExecuteFromRightClick = false;
        }
        /// <summary>
        /// ������� ����� ��� ����������� ��
        /// </summary>
        /// <param name="VPPNumber">����� ���/���/��� �� ���������</param>
        /// <param name="TZNumber">����� ��</param>
        /// <param name="TZpoz">������� �� � ���</param>
        /// <param name="docType">��� ��������� (1 - ���, 2 - ���, 3 - ��� �� ���������)</param>
        /// <param name="technolog">����� ��������� ��</param>
        /// <param name="Elements">Dictionary � ���������� ��� ������, ������ ������� ��� ��������� �������</param>
        public AddUspOrder(string VPPNumber, string TZNumber, int TZpoz, int docType, string technolog, Dictionary<string, string> Elements)
        {
            InitializeComponent();

            _page = 0;
            _lastPage = 6;

            _isBttnOk = false;

            string assTitle = _ASSEMBLIES.getAssemblyTitle(VPPNumber, TZpoz);
            if (assTitle != "")
            {
                _isWithoutProject = false;
            }
            else
            {
                _isWithoutProject = true;
            }

            _D = new Dictionary<string, string>();
            _Dexcel = new Dictionary<string, string>();

            _docStatus = docType;
            _VPPNumber = VPPNumber;
            _TZnumber = TZNumber;
            _TZpoz = TZpoz;

            _isExecuteFromRightClick = true;
            _demandDateIsEdited = false;

            _creator = _USR.getCurrSurname();
            _technolog = technolog;
            _Elements = Elements;



            //� ���������������
            if (!_isWithoutProject)
            {
                _assemblyTitle = _ASSEMBLIES.getAssemblyTitle(_VPPNumber, _TZpoz);
                _setDict(_D, "PROJECT", "1");
                if (_assemblyTitle.Equals(""))
                {
                    _isWithoutProject = true;
                    _lastPage--;
                    _setDict(_D, "PROJECT", "0");
                }
            }
            else
            {
                _isWithoutProject = true;
                _lastPage--;
                _setDict(_D, "PROJECT", "0");
            }

            if (_Elements != null)
            {
                _assemblyTitle = "";
                _lastPage--;
                _setDict(_D, "PROJECT", "0");
            }
        }

        public AddUspOrder(string idDoc, string technolog) : this(idDoc, null, 0, 1, technolog, null)
        {
            _isWithoutProject = true;
            _isTZ = true;
            _idDoc = idDoc;
        }

        //���������� ������� �� ������� ��
        void _getTZToDGV(string number)
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict.Add("num", number + "%");

            string cmdQuery = "select N_VD, N_TZ, POZ, CH from VPP_TZ20 where N_VD = ANY (" + //������� ������
                "SELECT N_VD FROM VPP_POZ20 WHERE N_VD = ANY (" + //��� ������ �� �������� ���
                "select N_VD from VPP_TIT20 where N_VD LIKE :num and "; //������ � ��� ������ �� ��������� ����
            string docColumnCaption = "";

            switch (_docStatus) //�������� 
            {
                case 1://���
                    cmdQuery += "PR2 = 0";
                    docColumnCaption = "����� ���";
                    break;
                case 2://���
                    cmdQuery += "PR2 = 1";
                    docColumnCaption = "����� ���";
                    break;
                case 3://��� �� ���������
                    cmdQuery += "PR3 = 1";
                    docColumnCaption = "����� ��� �� ���������";
                    break;
            }
            cmdQuery += ") and PR1 = 1)" + //�������� ���
                " and N_VD not in (select VPP_NUM from USP_ASSEMBLY_ORDERS)"; //�� ����������� � �������(��� �� ��� ��� ������)

            DataSet DS = SQLOracle.getDS(cmdQuery, Dict);
            DataSet GoodDS = DS.Copy();
            GoodDS.Tables[0].Columns[0].ColumnName = docColumnCaption;
            GoodDS.Tables[0].Columns[1].ColumnName = "����� ��";
            GoodDS.Tables[0].Columns[2].ColumnName = "������� ��";
            GoodDS.Tables[0].Columns[3].ColumnName = "����������� �������������� ������";
            dGVTZ.DataSource = GoodDS.Tables[0];
            dGVTZ.Columns[0].Width = 70;
            dGVTZ.Columns[1].Width = 70;
            dGVTZ.Columns[2].Width = 70;
            dGVTZ.Columns[3].Width = 170;
        }

        void _threadBD() //FIXME
        {

        }

        //��������� ������� ������
        void _setBorderPages(byte page)
        {
            if (page == 0)
                bttnPrev.Enabled = false;
            else
                bttnPrev.Enabled = true;

            if (page == _lastPage)
            {
                _modifyLastPage();
            }
            else
            {
                bttnNext.Text = "����� >";
                _isBttnOk = false;
            }
        }

        void _modifyLastPage()
        {
            bttnNext.Text = "������";
            _isBttnOk = true;
        }

        //��������� ��� ��������� n-�� ��������
        void _setPage0()
        {
            pnlHeader.Visible = false;

            _setBorderPages(0);
        }
        void _setPage1()
        {
            lblHeader.Text = "�������� ����� ������ ������������ �������";
            pnlHeader.Visible = true;

            bttnNext.Enabled = true; //��� �������� �� ����. �������� �����


            if ("".Equals(tBOrderNumber.Text))//��� ������ ������ ������
                tBOrderNumber.Text = (SQLOracle.getMaxIndexInt("NUM", "USP_ASSEMBLY_ORDERS")
                        + 1).ToString();

            _setBorderPages(1);
        }
        void _setPage2()
        {
            //this._threadBD(); //FIXME
            //_getTZ();
            lblHeader.Text = "�������� ����������� ����������� �������";

            if (!_Dexcel.ContainsKey("NUM_TZ"))
                bttnNext.Enabled = false;

            _setBorderPages(2);
        }
        void _setPage3()
        {
            lblHeader.Text = "������� ������ ���������";

            bttnNext.Enabled = true;

            if (!_demandDateIsEdited)
            {
                if (_isTZ == true)
                {
                    DateTime date = AssemblyOrders.getPlanProductionDate_TZnumber(_idDoc);
                    if (date.Date != new DateTime(1, 1, 1))
                    {
                        dTPDemand.Value = date;
                    }
                }
                else
                {
                    dTPDemand.Value = AssemblyOrders.getPlanProductionDate_VPPnumber(_VPPNumber);
                }
            }

            

            _setBorderPages(3);
        }
        void _setPage4()
        {
            lblHeader.Text = "������� �������������� ����������� ������� (���� ���������)";

            bttnNext.Enabled = true;

            _setBorderPages(4);
        }
        void _setPage5()
        {
            lblHeader.Text = "��������� ������";

            _createDictionary();
            _showData();

            _setBorderPages(5);
        }
        void _setPage6()
        {
            lblHeader.Text = "��������� � ������� �������������� �������������� ����";

            _getUSPParams();

            _setBorderPages(6);
        }

        //��������� ����������� ��������
        void _setNextPage()
        {
            switch (_page)
            {
                case 0:
                    _setNextPage1();
                    break;
                case 1:
                    _setNextPage2();
                    break;
                case 2:
                    _setPage3();
                    _page++;
                    tabControl1.SelectedIndex = _page;
                    break;
                case 3:
                    _setNextPage4();
                    break;
                case 4:
                    _setNextPage5();
                    break;
                case 5:
                    _setNextPage6();
                    break;
            }
        }

        //��������� ������� ������������� ���������
        void _setDocStatus()
        {
            if (rBVPPSearch.Checked)
                _docStatus = 1;//VPP
            else if (rBVZDSearch.Checked)
                _docStatus = 2;//VZD
            else if (rBVPPDSearch.Checked)
                _docStatus = 3;//VPP na dorabotku
            else _docStatus = 0;
        }

        //������� ���������� ����� NEXT, �� �� �������� ����� �������
        void _setNextPage1()
        {
            if (_isExecuteFromRightClick)
            {
                lblFindTZ.Visible = false;
                rBVPPSearch.Visible = false;
                rBVZDSearch.Visible = false;
                rBVPPDSearch.Visible = false;
            }
            _setPage1();
            _page++;
            tabControl1.SelectedIndex = _page;
        }
        void _setNextPage2()
        {
            int numeric;
            bool isNum = Int32.TryParse(tBOrderNumber.Text, out numeric);

            if (isNum)
                if (!SQLOracle.exist("USP_ASSEMBLY_ORDERS",
                            "num = '" + tBOrderNumber.Text + "'"))
                {
                    if (_isExecuteFromRightClick)
                    {
                        
                        if (_isTZ)
                        {
                            _setBothDict("VPP_NUM", "");
                            _setBothDict("TZ_NUM", AssemblyOrders.getTZnum(_idDoc));
                            _setDict(_D, "ID_TZ", _VPPNumber);
                        }
                        else
                        {
                            _setBothDict("TZ_NUM", _TZnumber);
                            _setBothDict("VPP_NUM", _VPPNumber);
                            _setDict(_D, "TZ_POS", _TZpoz.ToString());
                            _setDict(_D, "ID_TZ", "0");
                        }

                        _setPage3();
                        _page += 2;
                    }
                    else
                    {
                        _setDocStatus();
                        _setPage2();
                        _page++;
                    }
                    _setDict(_D, "DOC_STATUS", _docStatus.ToString());

                    tabControl1.SelectedIndex = _page;
                }
                else
                {
                    MessageBox.Show("������! ����� ����� ������ ��� ����������!",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else
                MessageBox.Show("������! ����� ������ ������ ���� ������!",
                            "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void _setNextPage4()
        {
            int numeric;
            bool isNum = Int32.TryParse(tBPartsCount.Text, out numeric);

            if (isNum)
            {
                if (numeric != 0)
                {
                    if (dTPDate.Value.Date <= dTPDemand.Value.Date)
                    {
                        if (!tBCustomerSurname.Text.Equals(""))
                        {
                            if (!tBCustomerPosition.Text.Equals(""))
                            {
                                _setBothDict("CUSTOMER_SURNAME", tBCustomerSurname.Text);
                                _setBothDict("CUSTOMER_POSITION", tBCustomerPosition.Text);

                                _setPage4();
                                _page++;
                                tabControl1.SelectedIndex = _page;
                            }
                            else
                            {
                                MessageBox.Show("���������� ������ ��������� ���������!",
                                        "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("���������� ������ ������� ���������!",
                                    "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("���� ������������� �� ����� ���� ������ ���� ������!",
                                "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("���������� ������� �� ����� ���� �������!",
                            "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("���������� ������ ���������� �������!",
                            "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void _setNextPage5()
        {
            if (!chBTechConditions.Checked)
            {
                if ((!rTBTechConditions.Text.Equals("")) && (!tBTCposition.Text.Equals("")) && (!tBTCSurname.Text.Equals("")))
                {
                    _setTechConditions();

                    _setPage5();
                    _page++;
                    tabControl1.SelectedIndex = _page;
                }
                else
                    MessageBox.Show("������� ������!", "������!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _cancelTechConditions();

                _setPage5();
                _page++;
                tabControl1.SelectedIndex = _page;
            }
        }
        void _setNextPage6()
        {
            _setPage6();
            _page++;
            tabControl1.SelectedIndex = _page;
        }

        //������ � Dictionary
        void _createDictionary()
        {
            _setNumber();
            _setTZParams(_D["VPP_NUM"], _TZpoz);
            _setDates();
            _setPartName();
            _setPartsCount();
            _setTechOperationName();
            _setBothDict("CREATOR_SURNAME", _creator);
            _setDict(_D, "PART_TITLE", _Dexcel["PART_TITLE"]);
            _setDict(_D, "WORKSHOP_CODE", _Dexcel["WORKSHOP_CODE"]);
            _setDict(_D, "TECHNOLOG", _technolog.ToString());
            _setDict(_D, "PRODUCT_CODE", _Dexcel["PRODUCT_CODE"]);

            if (_isTZ)
            {
                _setDict(_D, "EQUIP_TITLE", _TZ__VPP.getEquipTitle(_idDoc));
            }
            else
            {
                if (_nElements == null)
                {
                    _setDict(_D, "EQUIP_TITLE", _VPP_TZ.getEquipTitle(_VPPNumber));
                }
                else
                {
                    _setDict(_D, "EQUIP_TITLE", "");
                }
            }

            _setDict(_Dexcel, "BRIGADIER_SURNAME", AssemblyOrders.getBrigadierSurnameSettings());
        }

        //������ �������������
        void _getUSPParams()
        {
            tBElementsCount.Text = _ASSEMBLIES.getElementsCount(_assemblyTitle).ToString();
            tBStrapsCount.Text = _ASSEMBLIES.getStrapsCount(_assemblyTitle).ToString();
            tBNutsCount.Text = _ASSEMBLIES.getNutsCount(_assemblyTitle).ToString();
            tbSpecialElementsCount.Text = _ASSEMBLIES.getSpecialElementsCount(_assemblyTitle).ToString();
        }
        //������ �������������
        void _setUSPParams()
        {
            _setBothDict("ASSEMBLY_ELEMENTS_COUNT", tBElementsCount.Text);
            _setBothDict("ASSEMBLY_STRAPS_COUNT", tBStrapsCount.Text);
            _setBothDict("ASSEMBLY_NUTS_COUNT", tBNutsCount.Text);
            _setBothDict("ASSEMBLY_SPECIAL_DOWELS_COUNT", tBSpecialDowelsCount.Text);
            _setBothDict("ASSEMBLY_SPECIAL_ELEMEN_COUNT", tbSpecialElementsCount.Text);
            _setBothDict("ASSEMBLY_DIMENSIONS_COUNT", tBDimensionsCount.Text);
            _setBothDict("ASSEMBLY_DIFFICULTY_GROUP", tBDifficultGroup.Text);
        }
        void _unsetUSPparams()
        {
            _unsetBothDict("ASSEMBLY_ELEMENTS_COUNT");
            _unsetBothDict("ASSEMBLY_STRAPS_COUNT");
            _unsetBothDict("ASSEMBLY_NUTS_COUNT");
            _unsetBothDict("ASSEMBLY_SPECIAL_DOWELS_COUNT");
            _unsetBothDict("ASSEMBLY_SPECIAL_ELEMEN_COUNT");
            _unsetBothDict("ASSEMBLY_DIMENSIONS_COUNT");
            _unsetBothDict("ASSEMBLY_DIFFICULTY_GROUP");
        }

        void _showData()
        {
            lblNumber.Text = _D["NUM"];
            lblOrderDate.Text = dTPDate.Value.ToShortDateString();
            lblWorkShopCustomer.Text = _Dexcel["WORKSHOP_CODE"];
            lblPartName.Text = _Dexcel["PART_NAME"];
            lblPartTitle.Text = _Dexcel["PART_TITLE"];
            /*if (_isTZ == true)
            {
                lblTZNumber.Text = _ASSEMBLY_ORDERS.getTZnum(_idDoc);
            }
            else
            {*/
                lblTZNumber.Text = _Dexcel["TZ_NUM"];
            //}
            lblProductCode.Text = _Dexcel["PRODUCT_CODE"];
            lblDemandDate.Text = _D["DEMAND_DATE"];
        }
        //������ � ��
        void _writeToDB()
        {
            _writeUSP();

            string keys = "(";
            string values = "(";

            bool notFirst = false;
            foreach (KeyValuePair<string, string> pair in _D)
            {
                if (notFirst)
                {
                    keys += ", ";
                    values += ", ";
                }
                else
                    notFirst = true;

                keys += pair.Key;
                values += ":" + pair.Key;
            }
            keys += ")";
            values += ")";

            string cmdInsert = "insert into USP_ASSEMBLY_ORDERS " + keys + " values " + values;
            SQLOracle.insert(cmdInsert, _D);

            if (!_isTZ)
            {
                string cmdUpdate = "update USP_ASSEMBLY_ORDERS set CREATION_DATE = " + SQLOracle.getDateTime(dTPDate.Value) + " where VPP_NUM = '" + _D["VPP_NUM"] + "' and TZ_NUM = '" + _D["TZ_NUM"] + "' and TZ_POS = '" + _D["TZ_POS"] + "'";
                SQLOracle.update(cmdUpdate);
            }
            else
            {
                string cmdUpdate = "update USP_ASSEMBLY_ORDERS set CREATION_DATE = " + SQLOracle.getDateTime(dTPDate.Value) + " where ID_TZ = '" + _idDoc + "'";
                SQLOracle.update(cmdUpdate);
            }
            _D.Clear();
        }

        void _writeUSP()
        {
            if (_idDoc == null)
            {
                //c ���������������
                if (!_isWithoutProject)
                {
                    int assId = 0;

                    //������ ������ �� �������������� �������
                    if (_Elements == null)
                    {
                        _Elements = _ASSEMBLIES.getElements(_assemblyTitle);
                        _nElements = _ASSEMBLIES.getElementsCount(_assemblyTitle);
                        assId = _ASSEMBLIES.getId(_assemblyTitle);
                    }
                    else
                    {
                        _nElements = Instrumentary.getSumListValues(_Elements);
                        _setBothDict("ASSEMBLY_ELEMENTS_COUNT", _nElements);
                    }

                    //����� ��� � ��������������� ��������������� ��� �� ���������������, �� ������ ����� �� ����
                    if (assId == 0)
                    {
                        assId = _ASSEMBLY_ELEMENTS.getMaxAssId() + 1;
                    }

                    _writeElements(assId, _Elements);

                    _setDict(_D, "ASSEMBLY_ID", assId.ToString());
                }
            }
        }

        void _writeElements(int assId, Dictionary<string, string> ElementsDict)
        {
            bool assIdExist = false;
            if (!SQLOracle.exist(assId, "ID", "USP_ASSEMBLIES"))
            {
                _writeAss(assId);
            }
            else
            {
                assIdExist = true;
            }

            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            string cmdInsert1 = "insert into USP_ASSEMBLY_ELEMENTS (ASSEMBLY_ID, ELEMENT_NUM, ELEMENTS_COUNT) values (:ASSEMBLY_ID, :ELEMENT_NUM, :ELEMENTS_COUNT)";
            string cmdInsert2 = "insert into USP_HOT_STATS (ORDER_NUM, ELEMENT_TITLE, ELEMENTS_COUNT) values (:ORDER_NUM, :ELEMENT_TITLE, :ELEMENTS_COUNT)";

            foreach (KeyValuePair<string, string> Pair in ElementsDict)
            {
                if (!assIdExist)
                {
                    ParamsDict.Add("ASSEMBLY_ID", assId.ToString());
                    ParamsDict.Add("ELEMENT_NUM", Pair.Key);
                    ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                    SQLOracle.insert(cmdInsert1, ParamsDict);
                    ParamsDict.Clear();
                }

                ParamsDict.Add("ORDER_NUM", _D["NUM"]);
                ParamsDict.Add("ELEMENT_TITLE", Pair.Key);
                ParamsDict.Add("ELEMENTS_COUNT", Pair.Value);

                SQLOracle.insert(cmdInsert2, ParamsDict);
                ParamsDict.Clear();
            }
        }

        void _writeAss(int id)
        {
            Dictionary<string, string> ParamsDict = new Dictionary<string, string>();
            ParamsDict.Add("ID", id.ToString());
            ParamsDict.Add("NUM", _assemblyTitle);
            ParamsDict.Add("ELEMENTS_COUNT", _nElements.ToString());

            string cmdInsert = "insert into USP_ASSEMBLIES (ID, NUM, ELEMENTS_COUNT) values (:ID, :NUM, :ELEMENTS_COUNT)";
            SQLOracle.insert(cmdInsert, ParamsDict);
        }

        //��������� ���������
        void _generateOrder()
        {
            xlsAssemblyOrder1 Order1 = new xlsAssemblyOrder1(_Dexcel);
            Order1.createDocument();
            _Dexcel.Clear();
        }

        //��������� ������ ������
        void _setNumber()
        {
            int number = Int32.Parse(tBOrderNumber.Text);

            _setDict(_Dexcel, "NUM", number.ToString());
            _setDict(_D, "NUM", number.ToString());
        }
        void _setDates()
        {
            _setDict(_D, "DEMAND_DATE", dTPDemand.Value.ToShortDateString());
            _setDict(_Dexcel, "DEMAND_DATE", dTPDemand.Value.ToShortDateString());

            _setDict(_Dexcel, "CREATION_DATE", dTPDate.Value.ToShortDateString());
        }
        void _setPartName()
        {
            _setDict(_Dexcel, "PART_NAME", _getPartName(_Dexcel["PART_TITLE"]));
            _setDict(_D, "PART_NAME", _getPartName(_Dexcel["PART_TITLE"]));
        }
        void _setPartsCount()
        {
            _setDict(_D, "PARTS_COUNT", tBPartsCount.Text);
            _setDict(_Dexcel, "PARTS_COUNT", tBPartsCount.Text);
        }

        void _cancelTechConditions()
        {
            _unsetBothDict("TECH_CONDITIONS");
            _unsetBothDict("TECH_CONDITIONS_POSITION");
            _unsetBothDict("TECH_CONDITIONS_SURNAME");
        }
        void _setTechConditions()
        {
            _setBothDict("TECH_CONDITIONS", rTBTechConditions.Text);
            _setBothDict("TECH_CONDITIONS_POSITION", tBTCposition.Text);
            _setBothDict("TECH_CONDITIONS_SURNAME", tBTCSurname.Text);
        }

        void _setTechOperationName()
        {
            _setDict(_D, "TECH_OPERATION_NAME", tBTechOperation.Text);
            _setDict(_Dexcel, "TECH_OPERATION_NAME", tBTechOperation.Text);
        }

        void _setTZParams(string VPPnum, int TZpoz)
        {
            //REFACTORME
            string key;

            if (_isTZ == true)
            {
                key = "WORKSHOP_CODE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, AssemblyOrders.getWorkshopCode_TZ(_idDoc));

                key = "PRODUCT_CODE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, AssemblyOrders.getProductCode_TZ(_idDoc));

                key = "PART_TITLE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, AssemblyOrders.getPartTitle_TZ(_idDoc).Trim());
            }
            else
            {
                key = "WORKSHOP_CODE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, _getWorkShopCode(VPPnum, TZpoz).ToString());

                key = "PRODUCT_CODE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, _getProductCode(VPPnum, TZpoz).ToString());

                key = "PART_TITLE";
                if (_Dexcel.ContainsKey(key))
                    _Dexcel.Remove(key);
                _Dexcel.Add(key, _getPartTitle(VPPnum, TZpoz).Trim());
            }
        }

        void _setDict(Dictionary<string, string> Dict, string key, object value)
        {
            if (Dict.ContainsKey(key))
                Dict[key] = value.ToString();
            else
                Dict.Add(key, value.ToString());
        }
        void _setBothDict(string key, object value)
        {
            _setDict(_D, key, value);
            _setDict(_Dexcel, key, value);
        }

        void _unsetDict(Dictionary<string, string> Dict, string key)
        {
            if (Dict.ContainsKey(key))
                Dict.Remove(key);
        }
        void _unsetBothDict(string key)
        {
            _unsetDict(_D, key);
            _unsetDict(_Dexcel, key);
        }

        //------------------------------- SQL -----------------------------

        int _getLastNumber()
        {
            int number = SQLOracle.getMaxIndexInt("NUM", "USP_ASSEMBLY_ORDERS");

            return number;
        }
        string _getNumTZ(string numberVPP)
        {
            string TZnum = SQLOracle.selectStr("SELECT N_TZ FROM VPP_TZ20 WHERE N_VD = '" + numberVPP + "'");
            return TZnum;
        }

        int _getWorkShopCode(string VPPnum, int TZpoz)
        {
            return SQLOracle.selectInt("SELECT ce FROM vpp_tz20 WHERE N_VD = '" + VPPnum + "' and POZ = '" + TZpoz + "'");
        }
        int _getProductCode(string VPPnum, int TZpoz)
        {
            return SQLOracle.selectInt("SELECT ki FROM vpp_tz20 WHERE N_VD = '" + VPPnum + "' and POZ = '" + TZpoz + "'");
        }
        string _getPartTitle(string VPPnum, int TZpoz)
        {
            string cmdQuery = "SELECT ob_d FROM VPP_POZ20 WHERE N_VD = '" + VPPnum + "' and POZ = " + TZpoz;
            return SQLOracle.selectStr(cmdQuery);
        }
        string _getPartName(string partTitle)
        {
            return SQLOracle.selectStr("SELECT NM from model_attr20 where hd = '" + partTitle + "'");
        }

        //-------------------------------------------------------------------

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bttnNext_Click(object sender, EventArgs e)
        {

            if (_isBttnOk)
            {
                //c ���������������
                if (!_isWithoutProject)
                {
                    _setUSPParams();
                }

                _writeToDB();
                MessageBox.Show("���� ������ ������!", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _generateOrder();
                this.Close();
            }
            else
            {
                _setNextPage();
            }

        }
        private void bttnPrev_Click(object sender, EventArgs e)
        {
            _page--;

            switch (_page)
            {
                case 0:
                    _setPage0();
                    tabControl1.SelectedIndex = _page;
                    break;
                case 1:
                    tBTZNumber.Text = "";
                    dGVTZ.DataSource = null;
                    _setPage1();
                    tabControl1.SelectedIndex = _page;
                    break;
                case 2:
                    if (_isExecuteFromRightClick)
                    {
                        _page--;
                        _setPage1();
                    }
                    else
                    {
                        _setPage2();
                    }
                    tabControl1.SelectedIndex = _page;
                    break;
                case 3:
                    _setPage3();
                    tabControl1.SelectedIndex = _page;
                    break;
                case 4:
                    _setPage4();
                    tabControl1.SelectedIndex = _page;
                    break;
                case 5:
                    _setPage5();
                    tabControl1.SelectedIndex = _page;
                    break;
            }
        }

        private void tBTZNumber_TextChanged(object sender, EventArgs e)
        {
            //_threadBD(); //FIXME
            if ((sender as TextBox).Text.Length > 2) //REFACTORME
                _getTZToDGV((sender as TextBox).Text);
            else
                dGVTZ.DataSource = null;
        }

        private void chBCreateOrderNumber_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                tBOrderNumber.Enabled = false;
                tBOrderNumber.Text = (SQLOracle.getMaxIndexInt("NUM", "USP_ASSEMBLY_ORDERS")
                        + 1).ToString();
            }
            else
            {
                tBOrderNumber.Enabled = true;
            }
        }

        private void dGVTZ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //FIXME

            DataGridViewRow row = (sender as DataGridView).CurrentRow;

            if (row != null)
            {
                bttnNext.Enabled = true;

                string value = row.Cells[0].Value.ToString();

                string numTZ = _getNumTZ(value);

                _setDict(_Dexcel, "TZ_NUM", numTZ);
                _setDict(_D, "TZ_NUM", numTZ);
                _setDict(_Dexcel, "VPP_NUM", value);
                _setDict(_D, "VPP_NUM", value);

                _VPPNumber = _D["VPP_NUM"];
                _TZpoz = Int32.Parse(row.Cells[2].Value.ToString().Trim());

                _demandDateIsEdited = false;
            }
        }

        private void chBTechConditions_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                pnl4.Enabled = false;
            }
            else
            {
                pnl4.Enabled = true;
            }
        }

        private void dTPDemand_ValueChanged(object sender, EventArgs e)
        {
            _demandDateIsEdited = true;
        }

    }

}