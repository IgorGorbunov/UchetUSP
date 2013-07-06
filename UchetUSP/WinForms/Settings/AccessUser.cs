using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.WinForms.Settings
{
    public partial class AccessUser : Form
    {

        private List<string> value;


        public AccessUser()
        {
            InitializeComponent();
        }

        public AccessUser(List<string> initValue)
        {
            InitializeComponent();
            setSettings(initValue);
        }
        
        

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _TextBrush;

            //Get the item from the collection.
            TabPage _TabPage = tabControl1.TabPages[e.Index];

            //Get the real bound for the tab rectangle.
            Rectangle _TabBound = tabControl1.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {
                //Drow a different background color, and don't paint a focus rectangle.
                _TextBrush = new SolidBrush(Color.Red);
                g.FillRectangle(Brushes.Gray, e.Bounds);

            }
            else
            {

                _TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            //Use own font
            Font _TabFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Pixel);

            //Draw string. Center the text.
            StringFormat _StringFlags = new StringFormat();
            _StringFlags.Alignment = StringAlignment.Center;
            _StringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_TabPage.Text, _TabFont, _TextBrush, _TabBound, new StringFormat(_StringFlags));

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void TZ_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (TZ_DISABLE_ALL.Checked == true)
            {
                TZ_CREATE.Enabled = false;
                TZ_CREATE.Checked = false;

                TZ_EDIT.Enabled = false;
                TZ_EDIT.Checked = false;

                TZ_DELETE.Enabled = false;
                TZ_DELETE.Checked = false;

                TZ_PODP_NACH.Enabled = false;
                TZ_PODP_NACH.Checked = false;

                TZ_PODP_RAZ.Enabled = false;
                TZ_PODP_RAZ.Checked = false;

                TZ_PODP_UTV.Enabled = false;
                TZ_PODP_UTV.Checked = false;

                TZ_ENABLE_ALL.Checked = false;
            }
            else {
                    TZ_CREATE.Enabled = true;
                    TZ_EDIT.Enabled = true;
                    TZ_DELETE.Enabled = true;
                    TZ_PODP_NACH.Enabled = true;
                    TZ_PODP_RAZ.Enabled = true;
                    TZ_PODP_UTV.Enabled = true;                        
                }
        }

        private void TZ_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (TZ_ENABLE_ALL.Checked == true)
            {
                TZ_CREATE.Enabled = true;
                TZ_CREATE.Checked = true;

                TZ_EDIT.Enabled = true;
                TZ_EDIT.Checked = true;

                TZ_DELETE.Enabled = true;
                TZ_DELETE.Checked = true;

                TZ_PODP_NACH.Enabled = true;
                TZ_PODP_NACH.Checked = true;
                                
                TZ_DISABLE_ALL.Checked = false;
            }
           
        }

        private void LZ_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (LZ_DISABLE_ALL.Checked == true)
            {
                LZ_CREATE.Enabled = false;
                LZ_CREATE.Checked = false;

                LZ_EDIT.Enabled = false;
                LZ_EDIT.Checked = false;

                LZ_DELETE.Enabled = false;
                LZ_DELETE.Checked = false;

                LZ_ISP_TRUE.Enabled = false;
                LZ_ISP_TRUE.Checked = false;

                LZ_VIEW_VPP.Enabled = false;
                LZ_VIEW_VPP.Checked = false;

                LZ_GIVE.Enabled = false;
                LZ_GIVE.Checked = false;

                LZ_GET.Enabled = false;
                LZ_GET.Checked = false;

                LZ_HISTORY.Enabled = false;
                LZ_HISTORY.Checked = false;

                LZ_ENABLE_ALL.Checked = false;
            }
            else {

                LZ_CREATE.Enabled = true;
                LZ_EDIT.Enabled = true;
                LZ_DELETE.Enabled = true;
                LZ_ISP_TRUE.Enabled = true;
                LZ_VIEW_VPP.Enabled = true;
                LZ_GIVE.Enabled = true;
                LZ_GET.Enabled = true;
                LZ_HISTORY.Enabled = true;
               
            }
        }

        private void LZ_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (LZ_ENABLE_ALL.Checked == true)
            {
                LZ_CREATE.Enabled = true;
                LZ_CREATE.Checked = true;

                LZ_EDIT.Enabled = true;
                LZ_EDIT.Checked = true;

                LZ_DELETE.Enabled = true;
                LZ_DELETE.Checked = true;

                LZ_ISP_TRUE.Enabled = true;
                LZ_ISP_TRUE.Checked = true;

                LZ_VIEW_VPP.Enabled = true;
                LZ_VIEW_VPP.Checked = true;

                LZ_GIVE.Enabled = true;
                LZ_GIVE.Checked = true;

                LZ_GET.Enabled = true;
                LZ_GET.Checked = true;

                LZ_HISTORY.Enabled = true;
                LZ_HISTORY.Checked = true;

                LZ_DISABLE_ALL.Checked = false;
            }
           
        }

        private void ELEM_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (ELEM_DISABLE_ALL.Checked == true)
            {
                ELEM_ADD.Enabled = false;
                ELEM_ADD.Checked = false;

                ELEM_EDIT.Enabled = false;
                ELEM_EDIT.Checked = false;

                ELEM_DELETE.Enabled = false;
                ELEM_DELETE.Checked = false;

                ELEM_ENABLE_ALL.Checked = false;
            }
            else
            {
                ELEM_ADD.Enabled = true;
                ELEM_EDIT.Enabled = true;
                ELEM_DELETE.Enabled = true;                

            }
        }

        private void ELEM_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (ELEM_ENABLE_ALL.Checked == true)
            {
                ELEM_ADD.Enabled = true;
                ELEM_ADD.Checked = true;

                ELEM_EDIT.Enabled = true;
                ELEM_EDIT.Checked = true;

                ELEM_DELETE.Enabled = true;
                ELEM_DELETE.Checked = true;

                ELEM_DISABLE_ALL.Checked = false;
            }
         
        }

        public List<string> getSettings()
        {
            value.Add(TZ_CREATE.Checked.ToString());
            value.Add(TZ_EDIT.Checked.ToString());
            value.Add(TZ_DELETE.Checked.ToString());
            value.Add(TZ_PODP_RAZ.Checked.ToString());
            value.Add(TZ_PODP_UTV.Checked.ToString());
            value.Add(TZ_PODP_NACH.Checked.ToString());
            value.Add(LZ_CREATE.Checked.ToString());
            value.Add(LZ_EDIT.Checked.ToString());
            value.Add(LZ_DELETE.Checked.ToString());
            value.Add(LZ_VIEW_VPP.Checked.ToString());
            value.Add(LZ_ISP_TRUE.Checked.ToString());
            value.Add(LZ_GIVE.Checked.ToString());
            value.Add(LZ_GET.Checked.ToString());
            value.Add(LZ_HISTORY.Checked.ToString());
            value.Add(ELEM_ADD.Checked.ToString());
            value.Add(ELEM_EDIT.Checked.ToString());
            value.Add(ELEM_DELETE.Checked.ToString());
            value.Add(ACTNAKL_CREATE.Checked.ToString());
            value.Add(ACTNAKL_EDIT.Checked.ToString());
            value.Add(ACTNAKL_DELETE.Checked.ToString());
            value.Add(STAT_CURRENT.Checked.ToString());
            value.Add(STAT_COMMON.Checked.ToString());
            value.Add("0");

            return value;
        }

        public void setSettings(List<string> value)
        {

            TZ_CREATE.Checked = returnBool(value[1]);
            TZ_EDIT.Checked = returnBool(value[2]);
            TZ_DELETE.Checked = returnBool(value[3]);
            TZ_PODP_RAZ.Checked = returnBool(value[4]);
            TZ_PODP_UTV.Checked = returnBool(value[5]);
            TZ_PODP_NACH.Checked = returnBool(value[6]);
            LZ_CREATE.Checked = returnBool(value[7]);
            LZ_EDIT.Checked = returnBool(value[8]);
            LZ_DELETE.Checked = returnBool(value[9]);
            LZ_VIEW_VPP.Checked = returnBool(value[10]);
            LZ_ISP_TRUE.Checked = returnBool(value[11]);
            LZ_GIVE.Checked = returnBool(value[12]);
            LZ_GET.Checked = returnBool(value[13]);
            LZ_HISTORY.Checked = returnBool(value[14]);
            ELEM_ADD.Checked = returnBool(value[15]);
            ELEM_EDIT.Checked = returnBool(value[16]);
            ELEM_DELETE.Checked = returnBool(value[17]);
            ACTNAKL_CREATE.Checked = returnBool(value[18]);
            ACTNAKL_EDIT.Checked = returnBool(value[19]);
            ACTNAKL_DELETE.Checked = returnBool(value[20]);
            STAT_CURRENT.Checked = returnBool(value[21]);
            STAT_COMMON.Checked = returnBool(value[22]);            

        }

        private bool returnBool(string value)
        {
            if (String.Compare(value, "0") == 0)
            {
                return false;
            }
            else if (String.Compare(value, "1") == 0)
            {
                return true;
            }

            return false;
        
        }
        private void STAT_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (STAT_DISABLE_ALL.Checked == true)
            {
                STAT_COMMON.Checked = false;
                STAT_COMMON.Enabled = false;

                STAT_CURRENT.Checked = false;
                STAT_CURRENT.Enabled = false;

                STAT_ENABLE_ALL.Checked = false;
            }
            else {
               
                STAT_COMMON.Enabled = true;
                STAT_CURRENT.Enabled = true;

            }
        }

        private void STAT_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (STAT_ENABLE_ALL.Checked == true)
            {
                STAT_COMMON.Checked = true;
                STAT_COMMON.Enabled = true;

                STAT_CURRENT.Checked = true;
                STAT_CURRENT.Enabled = true;

                STAT_DISABLE_ALL.Checked = false;
            }
         }

        private void ACTNAKL_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (ACTNAKL_DISABLE_ALL.Checked == true)
            {
                ACTNAKL_CREATE.Checked = false;
                ACTNAKL_CREATE.Enabled = false;

                ACTNAKL_EDIT.Checked = false;
                ACTNAKL_EDIT.Enabled = false;

                ACTNAKL_DELETE.Checked = false;
                ACTNAKL_DELETE.Enabled = false;

                ACTNAKL_ENABLE_ALL.Checked = false;

            }
            else {
                
                ACTNAKL_CREATE.Enabled = true;
                ACTNAKL_EDIT.Enabled = true;
                ACTNAKL_DELETE.Enabled = true;
               
            }
        }

        private void ACTNAKL_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (ACTNAKL_ENABLE_ALL.Checked == true)
            {
                ACTNAKL_CREATE.Checked = true;
                ACTNAKL_CREATE.Enabled = true;

                ACTNAKL_EDIT.Checked = true;
                ACTNAKL_EDIT.Enabled = true;

                ACTNAKL_DELETE.Checked = true;
                ACTNAKL_DELETE.Enabled = true;

                ACTNAKL_DISABLE_ALL.Checked = false;

            }
         
        }

        private void POLZ_DISABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (POLZ_DISABLE_ALL.Checked == true)
            {
                POLZ_ALLOW_USER.Checked = false;
                POLZ_ALLOW_USER.Enabled = false;

                POLZ_ALLOW_GROUP.Checked = false;
                POLZ_ALLOW_GROUP.Enabled = false;

                POLZ_ENABLE_ALL.Checked = false;
            }
            else {

                POLZ_ALLOW_USER.Enabled = true;
                POLZ_ALLOW_GROUP.Enabled = true;
            }
        }

        private void POLZ_ENABLE_ALL_CheckedChanged(object sender, EventArgs e)
        {
            if (POLZ_ENABLE_ALL.Checked == true)
            {
                POLZ_ALLOW_USER.Checked = true;
                POLZ_ALLOW_USER.Enabled = true;

                POLZ_ALLOW_GROUP.Checked = true;
                POLZ_ALLOW_GROUP.Enabled = true;

                POLZ_DISABLE_ALL.Checked = false;
            }
        }

        
      

        
    }
}