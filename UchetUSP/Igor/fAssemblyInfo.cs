using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP
{
    /// <summary>
    /// Форма для просмотра информации о сборке
    /// </summary>
    public partial class fAssemblyInfo : Form
    {
        DateTime _creationVPPdate, _projectDate, _creationOrderDate, _creationDate, _deliveryDate, _returnDate;
        TimeSpan _projectTime, _creationTime, _downTime, _workTime;
        //int _projectProc, _creationProc, _downProc, _workProc;

        //string _VPPnumber;
        int _assId;

        //int _uspParam;

        int _lengthLifeLine = 300;
        int _heightLifeLine = 20;

        int _startYposition = 252;


        /// <summary>
        /// Запуск формы по id сборки
        /// </summary>
        /// <param name="assId">id сборки</param>
        public fAssemblyInfo(int assId)
        {
            _assId = assId;

            InitializeComponent();

            //doMagic();
            _fillList();

            int assDiffic = AssemblyOrders.getAssDiffic(assId);
            if (assDiffic == 0)
            {
                lblAssDiffic.Text = "Не задано";
            }
            else
            {
                lblAssDiffic.Text = assDiffic.ToString();
            }

            lblAssCount.Text = _ASSEMBLIES.getN(_assId).ToString();

            DataTable DT = SQLOracle.getDT("select O.NUM, trunc(to_number(ASSEMBLY_CREATION_DATE - CREATION_DATE), 3) * 24 * 60, trunc(to_number(ASSEMBLY_DELIVERY_DATE - ASSEMBLY_CREATION_DATE), 3) * 24 * 60, trunc(to_number(ASSEMBLY_RETURN_DATE - ASSEMBLY_DELIVERY_DATE), 3) * 24, S.TITLE, O.WORKSHOP_CODE from USP_STATUS S, USP_ASSEMBLY_ORDERS O where S.ID = O.DOC_STATUS and O.ASSEMBLY_ID = " + assId + "");

            DT.Columns[0].ColumnName = "Номер заказа";
            DT.Columns[1].ColumnName = "Время создания сборки (мин)";
            DT.Columns[2].ColumnName = "Время ожидания сборки (мин)";
            DT.Columns[3].ColumnName = "Время в цеху (час)";
            DT.Columns[4].ColumnName = "Состояние сборки";
            DT.Columns[5].ColumnName = "Цех заказчик";

            dGVOrders.DataSource = DT;

            dGVOrders.Columns[0].Width = 46;
            dGVOrders.Columns[1].Width = 100;
            dGVOrders.Columns[2].Width = 100;
            dGVOrders.Columns[3].Width = 55;
            dGVOrders.Columns[4].Width = 120;
            dGVOrders.Columns[5].Width = 60;

            //_setStatys();
        }

        void _setStatys()
        {
            DateTime nullDate = new DateTime(1, 1, 1);
            if (nullDate != _returnDate)
            {
                lblAssemblyStatys.Text = "возвращена на склад УСПО";
                lblAssemblyStatys.ForeColor = Color.Black;
            }
            else if (nullDate != _deliveryDate)
            {
                //lblAssemblyStatys.Text = "в цехе " + _ASSEMBLY_ORDERS.getWorkshopCode_VPPnumber(_VPPnumber);
                lblAssemblyStatys.ForeColor = Color.ForestGreen;
            }
            else if (nullDate != _creationDate)
            {
                lblAssemblyStatys.Text = "на столе заказов";
                lblAssemblyStatys.ForeColor = Color.DarkGoldenrod;
            }
            else if (nullDate != _creationOrderDate)
            {
                lblAssemblyStatys.Text = "в процессе сборки";
                lblAssemblyStatys.ForeColor = Color.Red;
            }
            else
            {
                lblAssemblyStatys.Text = "спроектирована";
                lblAssemblyStatys.ForeColor = Color.Blue;
            }

            
        }

        void _setDates(string VPPnum)
        {
            int orderNumber = getOrderNumber(VPPnum);

            _creationVPPdate = getCreationVPPdate(VPPnum);
            _projectDate = getProectDate(VPPnum);
            _creationOrderDate = getCreationOrderDate(orderNumber);
            _creationDate = getCreationDate(orderNumber);
            _deliveryDate = getDeliveryDate(orderNumber);
            _returnDate = getReturnDate(orderNumber);
        }
        void _setLabelDates()
        {
            _setLabelDate(_creationVPPdate, lblCreationVPPdate);
            _setLabelDate(_projectDate, lblProjectDate);
            _setLabelDate(_creationOrderDate, lblCreationOrderDate);
            _setLabelDate(_creationDate, lblCreationDate);
            _setLabelDate(_deliveryDate, lblDeliveryDate);
            _setLabelDate(_returnDate, lblReturnDate);
        }
        void _setLabelDate(DateTime DT, Label lbl)
        {
            DateTime nullValue = new DateTime(1, 1, 1);

            if (nullValue.Date == DT.Date)
                lbl.Text = "Не задано";
            else
                lbl.Text = DT.ToShortDateString();
        }

        void _setTimeSpan()
        {
            _projectTime = _projectDate - _creationVPPdate;
            _creationTime = _creationDate - _creationOrderDate;
            _downTime = _deliveryDate - _creationDate;
            _workTime = _returnDate - _deliveryDate;
        }

        int _setPanel(Panel pnl, int lengthProcent, int Xposition)
        {
            int newXposition;

            pnl.Location = new Point(Xposition, _startYposition);

            int width = (lengthProcent * (_lengthLifeLine / 100)); //100 - это 100%
            pnl.Size = new Size(width, _heightLifeLine);

            newXposition = Xposition + width;

            return newXposition;
        }
        void _setPanelLabels()
        {
            Label lblProjet = new Label();
            //_setPanelLabel(lblProjet, "lblProject", "проектирование", );
        }
        void _setPanelLabel(Label lbl, string name, string text, Point p, int len)
        {
            p.X = p.X - (len / 2); 
            lbl.AutoSize = true;
            lbl.ForeColor = System.Drawing.Color.Black;
            lbl.Location = p;
            lbl.Name = name;
            //lbl.Size = new System.Drawing.Size(90, 13);
            lbl.Text = text;
        }

        int _getMinutes(TimeSpan ts)
        {
            return (int)ts.TotalMinutes;
        }

        //---------------------------------------------------------------------
        int getOrderNumber(string VPPnumber)
        {
            return SQLOracle.selectInt("select NUM from USP_ASSEMBLY_ORDERS where VPP_NUM = " + VPPnumber);
        }

        static public int getUspParam(string VPPnumber)
        {
            return SQLOracle.selectInt("select PR1 from VPP_POZ20 where N_VD = '" + VPPnumber + "'", -1);
        }

        DateTime getCreationVPPdate(string VPPnumber)
        {
            return SQLOracle.selectDate("select DT_R from VPP_TIT20 where N_VD = '" + VPPnumber + "'");
        }
        DateTime getProectDate(string VPPnumber)
        {
            return SQLOracle.selectDate("select DT_P from VPP_POZ20 where N_VD = '" + VPPnumber + "'");
        }
        DateTime getCreationOrderDate(int orderNumber)
        {
            return SQLOracle.selectDate("select CREATION_DATE from USP_ASSEMBLY_ORDERS where NUM = " + orderNumber);
        }
        DateTime getCreationDate(int orderNumber)
        {
            return SQLOracle.selectDate("select ASSEMBLY_CREATION_DATE from USP_ASSEMBLY_ORDERS where NUM = " + orderNumber);
        }
        DateTime getDeliveryDate(int orderNumber)
        {
            return SQLOracle.selectDate("select ASSEMBLY_DELIVERY_DATE from USP_ASSEMBLY_ORDERS where NUM = " + orderNumber);
        }
        DateTime getReturnDate(int orderNumber)
        {
            return SQLOracle.selectDate("select ASSEMBLY_RETURN_DATE from USP_ASSEMBLY_ORDERS where NUM = " + orderNumber);
        }

        //--------------------------------------------------------------
        void doMagic()
        {

            /*MessageBox.Show("Дата оформления листа заказа - " + getCreationOrderDate(_orderNumber).ToString());
            MessageBox.Show("Дата создания сборки - " + getCreationDate(_orderNumber).ToString());
            MessageBox.Show("Дата поставки сборки - " + getDeliveryDate(_orderNumber).ToString());
            MessageBox.Show("Дата вовзврата сборки - " + getReturnDate(_orderNumber).ToString());*/

            //_setDates(_VPPnumber);
            _setLabelDates();

            _setTimeSpan();

            /*long lifeTime = _getMinutes(_projectTime) + _getMinutes(_creationTime) + _getMinutes(_downTime) + _getMinutes(_workTime);
            double oneProcent = lifeTime / 100;

            _projectProc = (int)(_getMinutes(_projectTime) / oneProcent);
            _creationProc = (int)(_getMinutes(_creationTime) / oneProcent);
            _downProc = (int)(_getMinutes(_downTime) / oneProcent);
            _workProc = (int)(_getMinutes(_workTime) / oneProcent);

            int Xposition;
            
            Xposition = _setPanel(pnlProject, _projectProc, _startXposition);
            Xposition = _setPanel(pnlCreation, _projectProc, Xposition);
            Xposition = _setPanel(pnlDowntime, _downProc, Xposition);
            Xposition = _setPanel(pnlInWork, _workProc, Xposition);*/
        }

        void _fillList()
        {
            Dictionary<string, string> Dict = new Dictionary<string, string>();
            Dict = _ASSEMBLIES.getElements(_assId);

            foreach (KeyValuePair<string, string> Pair in Dict)
            {
                lBElements.Items.Add(Pair.Key + " - " + Pair.Value + "шт.");
            }
        }

        private void lBElements_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lBElements.SelectedItem != null)
            {
                string[] split = lBElements.SelectedItem.ToString().Split(' ');
                MoreStatsForm MF = new MoreStatsForm(split[0], false);
                MF.ShowDialog();
            }
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