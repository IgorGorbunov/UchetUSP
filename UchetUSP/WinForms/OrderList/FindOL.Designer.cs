namespace UchetUSP.WinForms.OrderList
{
    partial class FindOL
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.AND = new System.Windows.Forms.RadioButton();
            this.OR = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Not = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 26);
            this.textBox1.MaxLength = 60;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "1";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер ВПП:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(15, 106);
            this.textBox4.MaxLength = 60;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(165, 20);
            this.textBox4.TabIndex = 7;
            this.textBox4.Tag = "4";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Номер ТЗ:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(15, 147);
            this.textBox5.MaxLength = 60;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(165, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Tag = "5";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 27);
            this.label6.TabIndex = 10;
            this.label6.Text = "Обозначение детали:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 275);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 25);
            this.button1.TabIndex = 22;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AND
            // 
            this.AND.AutoSize = true;
            this.AND.Location = new System.Drawing.Point(15, 252);
            this.AND.Name = "AND";
            this.AND.Size = new System.Drawing.Size(33, 17);
            this.AND.TabIndex = 23;
            this.AND.TabStop = true;
            this.AND.Text = "И";
            this.AND.UseVisualStyleBackColor = true;
            // 
            // OR
            // 
            this.OR.AutoSize = true;
            this.OR.Location = new System.Drawing.Point(71, 252);
            this.OR.Name = "OR";
            this.OR.Size = new System.Drawing.Size(49, 17);
            this.OR.TabIndex = 24;
            this.OR.TabStop = true;
            this.OR.Text = "ИЛИ";
            this.OR.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(186, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Tag = "1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(186, 69);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 27;
            this.checkBox3.Tag = "3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(186, 109);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 28;
            this.checkBox4.Tag = "4";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(186, 150);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(15, 14);
            this.checkBox5.TabIndex = 29;
            this.checkBox5.Tag = "5";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 35);
            this.label2.TabIndex = 36;
            this.label2.Text = "Используйте символ  % для поиска приблизительных значений";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(15, 66);
            this.textBox3.MaxLength = 60;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(165, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Tag = "3";
            // 
            // Not
            // 
            this.Not.AutoSize = true;
            this.Not.Location = new System.Drawing.Point(139, 254);
            this.Not.Name = "Not";
            this.Not.Size = new System.Drawing.Size(15, 14);
            this.Not.TabIndex = 37;
            this.Not.UseVisualStyleBackColor = true;
            this.Not.CheckedChanged += new System.EventHandler(this.Not_CheckedChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(159, 254);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(21, 13);
            this.label23.TabIndex = 38;
            this.label23.Text = "Не";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(186, 191);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(15, 14);
            this.checkBox6.TabIndex = 41;
            this.checkBox6.Tag = "6";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(15, 188);
            this.textBox6.MaxLength = 60;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(165, 20);
            this.textBox6.TabIndex = 39;
            this.textBox6.Tag = "6";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 27);
            this.label5.TabIndex = 40;
            this.label5.Text = "Цех заказчик:";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(186, 232);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(15, 14);
            this.checkBox7.TabIndex = 44;
            this.checkBox7.Tag = "7";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(15, 229);
            this.textBox7.MaxLength = 60;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(165, 20);
            this.textBox7.TabIndex = 42;
            this.textBox7.Tag = "7";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(168, 27);
            this.label7.TabIndex = 43;
            this.label7.Text = "Владелец:";
            // 
            // FindOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 336);
            this.Controls.Add(this.checkBox7);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Not);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.OR);
            this.Controls.Add(this.AND);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.MaximumSize = new System.Drawing.Size(226, 370);
            this.MinimumSize = new System.Drawing.Size(226, 370);
            this.Name = "FindOL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton AND;
        private System.Windows.Forms.RadioButton OR;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.CheckBox Not;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
    }
}