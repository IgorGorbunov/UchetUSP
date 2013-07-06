namespace UchetUSP.WinForms.settings
{
    partial class setings
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.MD_ELEM_DOC = new System.Windows.Forms.CheckBox();
            this.MD_ELEM_OPER = new System.Windows.Forms.CheckBox();
            this.MD_ELEM_NALICH = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.MD_ASSEM_STAT = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.MD_TZ = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MD_OL_HIS_OR = new System.Windows.Forms.CheckBox();
            this.MD_OL_GET_OR = new System.Windows.Forms.CheckBox();
            this.MD_OL_GIVE_OR = new System.Windows.Forms.CheckBox();
            this.MD_OL_CONF_OR = new System.Windows.Forms.CheckBox();
            this.MD_OL_NEW_OR = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.FORM_SAVE = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.CS_ELEM = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CS_DEP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CS_MN = new System.Windows.Forms.TextBox();
            this.CS_NAME = new System.Windows.Forms.TextBox();
            this.CS_SUR = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(104, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(578, 328);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Модули";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(520, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Сохранить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.MD_ELEM_DOC);
            this.groupBox6.Controls.Add(this.MD_ELEM_OPER);
            this.groupBox6.Controls.Add(this.MD_ELEM_NALICH);
            this.groupBox6.Location = new System.Drawing.Point(29, 218);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(520, 63);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Сборки УСП";
            // 
            // MD_ELEM_DOC
            // 
            this.MD_ELEM_DOC.AutoSize = true;
            this.MD_ELEM_DOC.Location = new System.Drawing.Point(292, 19);
            this.MD_ELEM_DOC.Name = "MD_ELEM_DOC";
            this.MD_ELEM_DOC.Size = new System.Drawing.Size(156, 17);
            this.MD_ELEM_DOC.TabIndex = 2;
            this.MD_ELEM_DOC.Text = "Операции с документами";
            this.MD_ELEM_DOC.UseVisualStyleBackColor = true;
            // 
            // MD_ELEM_OPER
            // 
            this.MD_ELEM_OPER.AutoSize = true;
            this.MD_ELEM_OPER.Location = new System.Drawing.Point(21, 42);
            this.MD_ELEM_OPER.Name = "MD_ELEM_OPER";
            this.MD_ELEM_OPER.Size = new System.Drawing.Size(151, 17);
            this.MD_ELEM_OPER.TabIndex = 1;
            this.MD_ELEM_OPER.Text = "Операции с элементами";
            this.MD_ELEM_OPER.UseVisualStyleBackColor = true;
            // 
            // MD_ELEM_NALICH
            // 
            this.MD_ELEM_NALICH.AutoSize = true;
            this.MD_ELEM_NALICH.Location = new System.Drawing.Point(21, 19);
            this.MD_ELEM_NALICH.Name = "MD_ELEM_NALICH";
            this.MD_ELEM_NALICH.Size = new System.Drawing.Size(185, 17);
            this.MD_ELEM_NALICH.TabIndex = 0;
            this.MD_ELEM_NALICH.Text = "Элементы в наличии на складе";
            this.MD_ELEM_NALICH.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.MD_ASSEM_STAT);
            this.groupBox5.Location = new System.Drawing.Point(29, 163);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(520, 49);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Сборки УСП";
            // 
            // MD_ASSEM_STAT
            // 
            this.MD_ASSEM_STAT.AutoSize = true;
            this.MD_ASSEM_STAT.Location = new System.Drawing.Point(21, 19);
            this.MD_ASSEM_STAT.Name = "MD_ASSEM_STAT";
            this.MD_ASSEM_STAT.Size = new System.Drawing.Size(84, 17);
            this.MD_ASSEM_STAT.TabIndex = 0;
            this.MD_ASSEM_STAT.Text = "Статистика";
            this.MD_ASSEM_STAT.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.MD_TZ);
            this.groupBox4.Location = new System.Drawing.Point(29, 108);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(520, 49);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Техническое задание";
            // 
            // MD_TZ
            // 
            this.MD_TZ.AutoSize = true;
            this.MD_TZ.Location = new System.Drawing.Point(21, 19);
            this.MD_TZ.Name = "MD_TZ";
            this.MD_TZ.Size = new System.Drawing.Size(146, 17);
            this.MD_TZ.TabIndex = 0;
            this.MD_TZ.Text = "Работа с тех. заданием";
            this.MD_TZ.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MD_OL_HIS_OR);
            this.groupBox3.Controls.Add(this.MD_OL_GET_OR);
            this.groupBox3.Controls.Add(this.MD_OL_GIVE_OR);
            this.groupBox3.Controls.Add(this.MD_OL_CONF_OR);
            this.groupBox3.Controls.Add(this.MD_OL_NEW_OR);
            this.groupBox3.Location = new System.Drawing.Point(29, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(520, 94);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Заказ";
            // 
            // MD_OL_HIS_OR
            // 
            this.MD_OL_HIS_OR.AutoSize = true;
            this.MD_OL_HIS_OR.Location = new System.Drawing.Point(292, 42);
            this.MD_OL_HIS_OR.Name = "MD_OL_HIS_OR";
            this.MD_OL_HIS_OR.Size = new System.Drawing.Size(138, 17);
            this.MD_OL_HIS_OR.TabIndex = 4;
            this.MD_OL_HIS_OR.Text = "Завершенные заказы";
            this.MD_OL_HIS_OR.UseVisualStyleBackColor = true;
            // 
            // MD_OL_GET_OR
            // 
            this.MD_OL_GET_OR.AutoSize = true;
            this.MD_OL_GET_OR.Location = new System.Drawing.Point(292, 19);
            this.MD_OL_GET_OR.Name = "MD_OL_GET_OR";
            this.MD_OL_GET_OR.Size = new System.Drawing.Size(148, 17);
            this.MD_OL_GET_OR.TabIndex = 3;
            this.MD_OL_GET_OR.Text = "Принять сборку из цеха";
            this.MD_OL_GET_OR.UseVisualStyleBackColor = true;
            // 
            // MD_OL_GIVE_OR
            // 
            this.MD_OL_GIVE_OR.AutoSize = true;
            this.MD_OL_GIVE_OR.Location = new System.Drawing.Point(21, 65);
            this.MD_OL_GIVE_OR.Name = "MD_OL_GIVE_OR";
            this.MD_OL_GIVE_OR.Size = new System.Drawing.Size(131, 17);
            this.MD_OL_GIVE_OR.TabIndex = 2;
            this.MD_OL_GIVE_OR.Text = "Выдать сборку в цех";
            this.MD_OL_GIVE_OR.UseVisualStyleBackColor = true;
            // 
            // MD_OL_CONF_OR
            // 
            this.MD_OL_CONF_OR.AutoSize = true;
            this.MD_OL_CONF_OR.Location = new System.Drawing.Point(21, 42);
            this.MD_OL_CONF_OR.Name = "MD_OL_CONF_OR";
            this.MD_OL_CONF_OR.Size = new System.Drawing.Size(200, 17);
            this.MD_OL_CONF_OR.TabIndex = 1;
            this.MD_OL_CONF_OR.Text = "Подтвердить исполнение заказов";
            this.MD_OL_CONF_OR.UseVisualStyleBackColor = true;
            // 
            // MD_OL_NEW_OR
            // 
            this.MD_OL_NEW_OR.AutoSize = true;
            this.MD_OL_NEW_OR.Location = new System.Drawing.Point(21, 19);
            this.MD_OL_NEW_OR.Name = "MD_OL_NEW_OR";
            this.MD_OL_NEW_OR.Size = new System.Drawing.Size(156, 17);
            this.MD_OL_NEW_OR.TabIndex = 0;
            this.MD_OL_NEW_OR.Text = "Просмотр новых заказов";
            this.MD_OL_NEW_OR.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(104, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Общие настройки";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.FORM_SAVE);
            this.groupBox8.Location = new System.Drawing.Point(323, 152);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(215, 63);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Размер окна";
            // 
            // FORM_SAVE
            // 
            this.FORM_SAVE.AutoSize = true;
            this.FORM_SAVE.Location = new System.Drawing.Point(12, 26);
            this.FORM_SAVE.Name = "FORM_SAVE";
            this.FORM_SAVE.Size = new System.Drawing.Size(147, 17);
            this.FORM_SAVE.TabIndex = 0;
            this.FORM_SAVE.Text = "Сохранять размер окна";
            this.FORM_SAVE.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(485, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Save_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.CS_ELEM);
            this.groupBox7.Location = new System.Drawing.Point(53, 152);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(235, 63);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Элементы УСП";
            // 
            // CS_ELEM
            // 
            this.CS_ELEM.AutoSize = true;
            this.CS_ELEM.Location = new System.Drawing.Point(19, 19);
            this.CS_ELEM.Name = "CS_ELEM";
            this.CS_ELEM.Size = new System.Drawing.Size(163, 30);
            this.CS_ELEM.TabIndex = 0;
            this.CS_ELEM.Text = "Не отображать элементы, \r\nкоторых нет на складе";
            this.CS_ELEM.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CS_DEP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(323, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 102);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Участок сборки УСПО";
            // 
            // CS_DEP
            // 
            this.CS_DEP.Location = new System.Drawing.Point(64, 42);
            this.CS_DEP.MaxLength = 100;
            this.CS_DEP.Name = "CS_DEP";
            this.CS_DEP.Size = new System.Drawing.Size(134, 20);
            this.CS_DEP.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Участок";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CS_MN);
            this.groupBox1.Controls.Add(this.CS_NAME);
            this.groupBox1.Controls.Add(this.CS_SUR);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(53, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Мастер участка УСПО";
            // 
            // CS_MN
            // 
            this.CS_MN.Location = new System.Drawing.Point(78, 73);
            this.CS_MN.MaxLength = 100;
            this.CS_MN.Name = "CS_MN";
            this.CS_MN.Size = new System.Drawing.Size(129, 20);
            this.CS_MN.TabIndex = 5;
            // 
            // CS_NAME
            // 
            this.CS_NAME.Location = new System.Drawing.Point(78, 45);
            this.CS_NAME.MaxLength = 100;
            this.CS_NAME.Name = "CS_NAME";
            this.CS_NAME.Size = new System.Drawing.Size(129, 20);
            this.CS_NAME.TabIndex = 4;
            // 
            // CS_SUR
            // 
            this.CS_SUR.Location = new System.Drawing.Point(78, 19);
            this.CS_SUR.MaxLength = 100;
            this.CS_SUR.Name = "CS_SUR";
            this.CS_SUR.Size = new System.Drawing.Size(129, 20);
            this.CS_SUR.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ItemSize = new System.Drawing.Size(25, 100);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(686, 336);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // setings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 336);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(694, 370);
            this.MinimumSize = new System.Drawing.Size(694, 370);
            this.Name = "setings";
            this.Text = "Настройки пользователя";
            
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox MD_ELEM_DOC;
        private System.Windows.Forms.CheckBox MD_ELEM_OPER;
        private System.Windows.Forms.CheckBox MD_ELEM_NALICH;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox MD_ASSEM_STAT;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox MD_TZ;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox MD_OL_HIS_OR;
        private System.Windows.Forms.CheckBox MD_OL_GET_OR;
        private System.Windows.Forms.CheckBox MD_OL_GIVE_OR;
        private System.Windows.Forms.CheckBox MD_OL_CONF_OR;
        private System.Windows.Forms.CheckBox MD_OL_NEW_OR;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox CS_DEP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox CS_MN;
        private System.Windows.Forms.TextBox CS_NAME;
        private System.Windows.Forms.TextBox CS_SUR;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox CS_ELEM;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox FORM_SAVE;
        private System.Windows.Forms.Button button2;


    }
}