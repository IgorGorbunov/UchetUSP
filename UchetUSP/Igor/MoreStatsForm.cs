using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    public partial class MoreStatsForm : Form
    {
        string _title;

        /// <summary>
        /// Окно с информацией об элементе и сборках, в которых он участвует
        /// </summary>
        /// <param name="elementTitle">Обозначение элемента</param>
        public MoreStatsForm(string elementTitle) : this(elementTitle, null, true)
        {

        }
        /// <summary>
        /// Окно с информацией об элементе и сборках, в которых он участвует
        /// </summary>
        /// <param name="elementTitle">Обозначение элемента</param>
        /// <param name="isHot">да, если статистика горячая</param>
        public MoreStatsForm(string elementTitle, bool isHot) : this(elementTitle, null, isHot)
        {

        }
        /// <summary>
        /// Окно с информацией об элементе и сборках конкретного участка сборки, в которых он участвует
        /// </summary>
        /// <param name="elementTitle">Обозначение элемента</param>
        /// <param name="sector">Участок сборки УСПО</param>
        /// <param name="isHot">да, если статистика горячая</param>
        public MoreStatsForm(string elementTitle, string sector, bool isHot)
        {
            InitializeComponent();

            _title = elementTitle;
            this.Text = _ELEMENTS.getName(_title);

            fillLabels();

            object pic = SQLOracle.getBlobImageWithBuffer("select DET from DB_DATA where OBOZN = :OBOZN", _title);;
            if (pic != null)
            {
                pBElement.Image = (Image)pic;
            }
            else
            {
                pBElement.Image = pBElement.ErrorImage;
                pBElement.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            Dictionary<string, string> Dict = new Dictionary<string, string>();

            DataTable DT;

            if (isHot)
            {
                if (sector == null)
                {
                    Dict.Add("ELEMENT_TITLE", elementTitle);
                    DT = SQLOracle.getDT("SELECT O.num, PART_TITLE, ASSEMBLY_NUM, S.title, SUM(ELEMENTS_COUNT), ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, O.WORKSHOP_CODE " +
                                         "FROM USP_ASSEMBLY_ORDERS O, USP_STATUS S, USP_HOT_STATS H " +
                                         "WHERE H.ORDER_NUM = O.NUM and H.ELEMENT_TITLE = :ELEMENT_TITLE and O.DOC_STATUS = S.id and O.NUM = ANY (select ORDER_NUM from USP_HOT_STATS where ELEMENT_TITLE = :ELEMENT_TITLE) " +
                                         "GROUP BY O.num, PART_TITLE, ASSEMBLY_NUM, S.title, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, O.WORKSHOP_CODE", Dict);
                }
                else
                {
                    Dict.Add("ASSEMBLY_SECTOR_NUM", sector);
                    Dict.Add("ELEMENT_TITLE", elementTitle);
                    DT = SQLOracle.getDT("SELECT O.num, OB_O, ASSEMBLY_NUM, title, SUM(ELEMENTS_COUNT), DT_I, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, T.CE " +
                                         "FROM VPP_TZ20 T, USP_ASSEMBLY_ORDERS O, VPP_POZ20 V, USP_STATUS S, USP_HOT_STATS H " +
                                         "WHERE V.N_VD = T.N_VD and O.ASSEMBLY_SECTOR_NUM = :ASSEMBLY_SECTOR_NUM and H.ORDER_NUM = O.NUM and H.ELEMENT_TITLE = :ELEMENT_TITLE and O.VPP_NUM = V.N_VD and O.DOC_STATUS = S.id and O.NUM = ANY (select ORDER_NUM from USP_HOT_STATS where ELEMENT_TITLE = :ELEMENT_TITLE) " +
                                         "GROUP BY O.num, OB_O, ASSEMBLY_NUM, title, DT_I, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, T.CE", Dict);
                }
            }
            else
            {
                Dict.Add("ELEMENT_NUM", elementTitle);
                //DT = SQLOracle.getDT("SELECT O.num, OB_O, ASSEMBLY_NUM, title, SUM(ELEMENTS_COUNT), DT_I, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, T.CE " +
                //                     "FROM VPP_TZ20 T, USP_ASSEMBLY_ORDERS O, VPP_POZ20 V, USP_STATUS S, USP_ASSEMBLY_ELEMENTS E " +
                //                     "WHERE V.N_VD = T.N_VD and E.ELEMENT_NUM= :ELEMENT_NUM and O.VPP_NUM = V.N_VD and O.DOC_STATUS = S.id and O.ASSEMBLY_ID = ANY (select ASSEMBLY_ID from USP_ASSEMBLY_ELEMENTS where ELEMENT_NUM = :ELEMENT_NUM) " +
                //                     "GROUP BY O.num, OB_O, ASSEMBLY_NUM, title, DT_I, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, T.CE", Dict);

                DT = SQLOracle.getDT("SELECT O.num, PART_TITLE, ASSEMBLY_NUM, S.title, SUM(ELEMENTS_COUNT), ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, O.WORKSHOP_CODE " +
                    "FROM USP_ASSEMBLY_ORDERS O, USP_STATUS S, USP_ASSEMBLY_ELEMENTS E " + 
                    "WHERE E.ASSEMBLY_ID = O.ASSEMBLY_ID and E.ELEMENT_NUM = :ELEMENT_NUM and O.DOC_STATUS = S.id and O.ASSEMBLY_ID = ANY (select ASSEMBLY_ID from USP_ASSEMBLY_ELEMENTS where ELEMENT_NUM = :ELEMENT_NUM) " +
                    "GROUP BY O.num, PART_TITLE, ASSEMBLY_NUM, S.title, ASSEMBLY_PLANNED_RETURN_DATE, ASSEMBLY_SECTOR_NUM, O.WORKSHOP_CODE", Dict);

            }

            DT.Columns[0].ColumnName = "Номер заказа";
            DT.Columns[1].ColumnName = "Обозначение УСПО";
            DT.Columns[2].ColumnName = "Номер сборки";
            DT.Columns[3].ColumnName = "Состояние";
            DT.Columns[4].ColumnName = "Количество в сборке";
            //DT.Columns[5].ColumnName = "Плановая дата изготовления сборки";
            DT.Columns[5].ColumnName = "Плановая дата возврата";
            DT.Columns[6].ColumnName = "Участок сборки УСПО";
            DT.Columns[7].ColumnName = "Цех заказчик";

            dGVOrders.DataSource = DT;

            dGVOrders.Columns[0].Width = 50;
            dGVOrders.Columns[1].Width = 200;
            dGVOrders.Columns[2].Width = 50;
            dGVOrders.Columns[3].Width = 200;
            dGVOrders.Columns[4].Width = 70;
            dGVOrders.Columns[5].Width = 70;
            dGVOrders.Columns[6].Width = 60;
            dGVOrders.Columns[7].Width = 60;
        }

        void fillLabels()
        {
            lblTitle.Text = _title;
            lblName.Text = _ELEMENTS.getName(_title);
            lblGOST.Text = _ELEMENTS.getGOST(_title);
            lblWeight.Text = _ELEMENTS.getWeight(_title);

            lblAllN.Text = _ELEMENTS.getAllN(_title).ToString();
            lblBusy.Text = _ELEMENTS.getBusyN(_title).ToString();
            lblFree.Text = _ELEMENTS.getFreeN(_title).ToString();

            lblGroup.Text = _ELEMENTS.getGroup(_title);
            lblKatalog.Text = _ELEMENTS.getKatalog(_title);
        }

        private void dGVOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGVOrders.RowCount > 0)
            {
                if (dGVOrders["Номер заказа", dGVOrders.CurrentCell.RowIndex].Value != null)
                {
                    xlsAssemblyOrder Order = new xlsAssemblyOrder(dGVOrders["Номер заказа", dGVOrders.CurrentCell.RowIndex].Value.ToString());
                    Order.createDocument();
                }
            }
        }
    }
}