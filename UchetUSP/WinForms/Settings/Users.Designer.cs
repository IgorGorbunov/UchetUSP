namespace UchetUSP.WinForms.Settings
{
    partial class Users
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.DeleteUser = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AcsseptUserGroup = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ComboNameOfGroup = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DeleteGroupName = new System.Windows.Forms.ComboBox();
            this.DeleteName = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.EditNameOfGroup = new System.Windows.Forms.ComboBox();
            this.EditRights = new System.Windows.Forms.Button();
            this.EditGroup = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AddRightsForGroup = new System.Windows.Forms.Button();
            this.AddGroup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AddNameOfGroup = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AddGroupOfUser = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddNameOfUser = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 249);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(647, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(25, 100);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(647, 249);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(539, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пользователи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(364, 235);
            this.dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(367, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 235);
            this.panel1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.DeleteUser);
            this.groupBox6.Location = new System.Drawing.Point(6, 121);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(158, 54);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Удалить пользователя";
            // 
            // DeleteUser
            // 
            this.DeleteUser.Location = new System.Drawing.Point(9, 19);
            this.DeleteUser.Name = "DeleteUser";
            this.DeleteUser.Size = new System.Drawing.Size(143, 23);
            this.DeleteUser.TabIndex = 6;
            this.DeleteUser.Text = "Удалить";
            this.DeleteUser.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AcsseptUserGroup);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.ComboNameOfGroup);
            this.groupBox3.Location = new System.Drawing.Point(6, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 111);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Редактировать группу пользователя";
            // 
            // AcsseptUserGroup
            // 
            this.AcsseptUserGroup.Location = new System.Drawing.Point(9, 75);
            this.AcsseptUserGroup.Name = "AcsseptUserGroup";
            this.AcsseptUserGroup.Size = new System.Drawing.Size(143, 23);
            this.AcsseptUserGroup.TabIndex = 6;
            this.AcsseptUserGroup.Text = "Назначить";
            this.AcsseptUserGroup.UseVisualStyleBackColor = true;
            this.AcsseptUserGroup.Click += new System.EventHandler(this.AcsseptUserGroup_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Группа";
            // 
            // ComboNameOfGroup
            // 
            this.ComboNameOfGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboNameOfGroup.Location = new System.Drawing.Point(9, 48);
            this.ComboNameOfGroup.Name = "ComboNameOfGroup";
            this.ComboNameOfGroup.Size = new System.Drawing.Size(143, 21);
            this.ComboNameOfGroup.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(104, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(539, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Внести пользователя";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.DeleteGroupName);
            this.groupBox5.Controls.Add(this.DeleteName);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(276, 128);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 80);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Удалить группу";
            // 
            // DeleteGroupName
            // 
            this.DeleteGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeleteGroupName.Location = new System.Drawing.Point(128, 19);
            this.DeleteGroupName.Name = "DeleteGroupName";
            this.DeleteGroupName.Size = new System.Drawing.Size(107, 21);
            this.DeleteGroupName.TabIndex = 8;
            // 
            // DeleteName
            // 
            this.DeleteName.Location = new System.Drawing.Point(9, 46);
            this.DeleteName.Name = "DeleteName";
            this.DeleteName.Size = new System.Drawing.Size(227, 23);
            this.DeleteName.TabIndex = 5;
            this.DeleteName.Text = "Удалить";
            this.DeleteName.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Наименование группы";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.EditNameOfGroup);
            this.groupBox4.Controls.Add(this.EditRights);
            this.groupBox4.Controls.Add(this.EditGroup);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(6, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 107);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Редактировать группу";
            // 
            // EditNameOfGroup
            // 
            this.EditNameOfGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EditNameOfGroup.Location = new System.Drawing.Point(127, 19);
            this.EditNameOfGroup.Name = "EditNameOfGroup";
            this.EditNameOfGroup.Size = new System.Drawing.Size(108, 21);
            this.EditNameOfGroup.TabIndex = 7;
            this.EditNameOfGroup.SelectedIndexChanged += new System.EventHandler(this.EditNameOfGroup_SelectedIndexChanged);
            // 
            // EditRights
            // 
            this.EditRights.Location = new System.Drawing.Point(8, 46);
            this.EditRights.Name = "EditRights";
            this.EditRights.Size = new System.Drawing.Size(227, 23);
            this.EditRights.TabIndex = 6;
            this.EditRights.Text = "Назначить права";
            this.EditRights.UseVisualStyleBackColor = true;
            this.EditRights.Click += new System.EventHandler(this.EditRights_Click);
            // 
            // EditGroup
            // 
            this.EditGroup.Location = new System.Drawing.Point(8, 75);
            this.EditGroup.Name = "EditGroup";
            this.EditGroup.Size = new System.Drawing.Size(227, 23);
            this.EditGroup.TabIndex = 5;
            this.EditGroup.Text = "Редактировать";
            this.EditGroup.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Наименование группы";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AddRightsForGroup);
            this.groupBox2.Controls.Add(this.AddGroup);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.AddNameOfGroup);
            this.groupBox2.Location = new System.Drawing.Point(276, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(248, 114);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Добавить группу";
            // 
            // AddRightsForGroup
            // 
            this.AddRightsForGroup.Location = new System.Drawing.Point(8, 46);
            this.AddRightsForGroup.Name = "AddRightsForGroup";
            this.AddRightsForGroup.Size = new System.Drawing.Size(227, 23);
            this.AddRightsForGroup.TabIndex = 6;
            this.AddRightsForGroup.Text = "Назначить права";
            this.AddRightsForGroup.UseVisualStyleBackColor = true;
            this.AddRightsForGroup.Click += new System.EventHandler(this.AddRightsForGroup_Click);
            // 
            // AddGroup
            // 
            this.AddGroup.Location = new System.Drawing.Point(9, 80);
            this.AddGroup.Name = "AddGroup";
            this.AddGroup.Size = new System.Drawing.Size(227, 23);
            this.AddGroup.TabIndex = 5;
            this.AddGroup.Text = "Добавить";
            this.AddGroup.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Наименование группы";
            // 
            // AddNameOfGroup
            // 
            this.AddNameOfGroup.Location = new System.Drawing.Point(134, 19);
            this.AddNameOfGroup.MaxLength = 50;
            this.AddNameOfGroup.Name = "AddNameOfGroup";
            this.AddNameOfGroup.Size = new System.Drawing.Size(102, 20);
            this.AddNameOfGroup.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.AddGroupOfUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AddNameOfUser);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить пользователя";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddGroupOfUser
            // 
            this.AddGroupOfUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AddGroupOfUser.FormattingEnabled = true;
            this.AddGroupOfUser.Location = new System.Drawing.Point(115, 50);
            this.AddGroupOfUser.Name = "AddGroupOfUser";
            this.AddGroupOfUser.Size = new System.Drawing.Size(121, 21);
            this.AddGroupOfUser.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Группа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя пользователя";
            // 
            // AddNameOfUser
            // 
            this.AddNameOfUser.Location = new System.Drawing.Point(115, 22);
            this.AddNameOfUser.MaxLength = 50;
            this.AddNameOfUser.Name = "AddNameOfUser";
            this.AddNameOfUser.Size = new System.Drawing.Size(121, 20);
            this.AddNameOfUser.TabIndex = 0;
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 271);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Users";
            this.Text = "Пользователи";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox AddGroupOfUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AddNameOfUser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button AddRightsForGroup;
        private System.Windows.Forms.Button AddGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox AddNameOfGroup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ComboNameOfGroup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button EditRights;
        private System.Windows.Forms.Button EditGroup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AcsseptUserGroup;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox DeleteGroupName;
        private System.Windows.Forms.Button DeleteName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox EditNameOfGroup;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button DeleteUser;
    }
}