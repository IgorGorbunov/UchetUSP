using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UchetUSP.WinForms.Settings
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            ViewUsers();
            FillGroupBoxOfGroup(true, ref ComboNameOfGroup);
            FillGroupBoxOfGroup(true, ref AddGroupOfUser);
            FillGroupBoxOfGroup(false,ref  EditNameOfGroup);
            FillGroupBoxOfGroup(false, ref DeleteGroupName);
        }


        private void ViewUsers()
        {
            dataGridView1.DataSource = SQLOracle.getDS("SELECT USERLOGIN AS LOGIN, NAMEOFGROUP as Группа FROM USP_USERS WHERE ID <> '1'").Tables[0];            
        }

        /// <summary>
        /// Заполнение GroupBox группами
        /// </summary>
        /// <param name="type">true - все группы, false - все кроме базовых</param>
        /// <returns></returns>
        private void FillGroupBoxOfGroup(bool type,ref ComboBox comBox)
        {
            if (type)
            {
                List<string> data = SQLOracle.selectListStr("SELECT NAME FROM USP_CREATE_GROUP WHERE BASE <> '2' ");
                for (int i = 0; i < data.Count; i++)
                {
                    comBox.Items.Add(data[i]);
                }
                comBox.SelectedIndex = 0;
                data.Clear();
            }
            else {

                List<string> data = SQLOracle.selectListStr("SELECT NAME FROM USP_CREATE_GROUP WHERE BASE <> '1' AND BASE <> '2'");
                
                for (int i = 0; i < data.Count; i++)
                {
                    comBox.Items.Add(data[i]);
                }

                comBox.SelectedIndex = 0;
                data.Clear();
                    
            }
            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AcsseptUserGroup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите поменять группу пользователя?", "Предупреждение!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> param = new List<string>();
                List<string> value = new List<string>();
                param.Add("NAMEOFGROUP");
                value.Add(ComboNameOfGroup.SelectedItem.ToString());
                param.Add("USERLOGIN");
                value.Add(dataGridView1[0, dataGridView1.SelectedCells[0].RowIndex].Value.ToString());              
                SQLOracle.UpdateQuery("UPDATE USP_USERS SET NAMEOFGROUP = :NAMEOFGROUP WHERE USERLOGIN = :USERLOGIN",param,value);
                ViewUsers();
                param.Clear();
                value.Clear();
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void AddRightsForGroup_Click(object sender, EventArgs e)
        {
            
        }

        private void EditNameOfGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EditRights_Click(object sender, EventArgs e)
        {
            using (AccessUser SetUserRights = new AccessUser(SQLOracle.GetStrFromBD("*", "USP_CREATE_GROUP", "NAME", EditNameOfGroup.SelectedItem.ToString())))
            {
                SetUserRights.ShowDialog();

            }
        }
    }
}