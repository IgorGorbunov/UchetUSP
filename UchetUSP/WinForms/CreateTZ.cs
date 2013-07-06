using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.WinForms
{
    public partial class CreateTZ : Form
    {
        private System.Collections.Generic.Dictionary<string, string> D = new System.Collections.Generic.Dictionary<string, string>();

        public CreateTZ()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
              
                this.SCETCH.ImageLocation = openFileDialog1.FileName;

                this.SCETCH.SizeMode = PictureBoxSizeMode.CenterImage;

            }
        }

        private void ÒÓı‡ÌËÚ¸¬¡ƒToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            /*  SQLOracle.InitConnectionString();
            if (SQLOracle.CheckConnection())
             {
                 D.Add("NUMBER_TZ", NUMBER_TZ.Text);
                 D.Add("PRODUCT_CODE", PRODUCT_CODE.Text);
                 D.Add("PART_TITLE", PART_TITLE.Text);
                 D.Add("PART_NUMBER", PART_NUMBER.Text);
                 D.Add("SECTION_CODE", SECTION_CODE.Text);
                 D.Add("SCETCH", SCETCH.ImageLocation.ToString());
                 D.Add("OPERATION_TITLE", OPERATION_TITLE.Text);
                 D.Add("CONDITIONS", CONDITIONS.Text);
                 D.Add("EQ_NAME", EQ_NAME.Text);
                 D.Add("EQ_MODEL", EQ_MODEL.Text);
                 D.Add("TABLE_SIZE", TABLE_SIZE.Text);
                 D.Add("DEVELOPER_SIGN_DATA", DEVELOPER_SIGN_DATA.Text);
                 D.Add("CHECKER_SIGN_DATA", CHECKER_SIGN_DATA.Text);
                 D.Add("SIGN_DATA", SIGN_DATA.Text);
                
                 //ƒŒ¡¿¬»“‹ LOGIN œŒ 3Ã œŒ«»÷»ﬂÃ.
             
             }
             SQLOracle.DispConnectionString();*/
            

            
            
                     
        }

        private void SCETCH_Click(object sender, EventArgs e)
        {

        }

       
    }
}