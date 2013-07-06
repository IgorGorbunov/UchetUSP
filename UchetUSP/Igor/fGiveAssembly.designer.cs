namespace UchetUSP
{
    partial class fGiveAssembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGiveAssembly));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.pBFrontImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.dTPPlanedReturnDate = new System.Windows.Forms.DateTimePicker();
            this.tBGiverSurname = new System.Windows.Forms.TextBox();
            this.tBGetterSurname = new System.Windows.Forms.TextBox();
            this.tBGetterPosition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dTPDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.bttnPrev = new System.Windows.Forms.Button();
            this.bttnNext = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBFrontImage)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage0);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(-6, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(449, 259);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage0
            // 
            this.tabPage0.Controls.Add(this.pBFrontImage);
            this.tabPage0.Controls.Add(this.label2);
            this.tabPage0.Controls.Add(this.label3);
            this.tabPage0.Controls.Add(this.label1);
            this.tabPage0.Location = new System.Drawing.Point(4, 22);
            this.tabPage0.Name = "tabPage0";
            this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage0.Size = new System.Drawing.Size(441, 233);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Text = "tabPage0";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // pBFrontImage
            // 
            this.pBFrontImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBFrontImage.Image = global::UchetUSP.Properties.Resources.masterImage;
            this.pBFrontImage.InitialImage = null;
            this.pBFrontImage.Location = new System.Drawing.Point(-39, -4);
            this.pBFrontImage.Name = "pBFrontImage";
            this.pBFrontImage.Size = new System.Drawing.Size(168, 234);
            this.pBFrontImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBFrontImage.TabIndex = 9;
            this.pBFrontImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(150, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "Этот мастер поможет выдать сборку УСПО заказчику с отрывным талоном к форме 2424." +
                "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(150, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "Для продолжения нажмите кнопку \"Далее\".";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(150, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Мастер выдачи сборки УСПО";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pnl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(441, 233);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.dTPPlanedReturnDate);
            this.pnl1.Controls.Add(this.tBGiverSurname);
            this.pnl1.Controls.Add(this.tBGetterSurname);
            this.pnl1.Controls.Add(this.tBGetterPosition);
            this.pnl1.Controls.Add(this.label8);
            this.pnl1.Controls.Add(this.label7);
            this.pnl1.Controls.Add(this.label6);
            this.pnl1.Controls.Add(this.label5);
            this.pnl1.Controls.Add(this.dTPDeliveryDate);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Location = new System.Drawing.Point(16, 68);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(409, 149);
            this.pnl1.TabIndex = 0;
            // 
            // dTPPlanedReturnDate
            // 
            this.dTPPlanedReturnDate.Location = new System.Drawing.Point(219, 125);
            this.dTPPlanedReturnDate.Name = "dTPPlanedReturnDate";
            this.dTPPlanedReturnDate.Size = new System.Drawing.Size(132, 20);
            this.dTPPlanedReturnDate.TabIndex = 9;
            // 
            // tBGiverSurname
            // 
            this.tBGiverSurname.Location = new System.Drawing.Point(219, 96);
            this.tBGiverSurname.Name = "tBGiverSurname";
            this.tBGiverSurname.Size = new System.Drawing.Size(132, 20);
            this.tBGiverSurname.TabIndex = 8;
            // 
            // tBGetterSurname
            // 
            this.tBGetterSurname.Location = new System.Drawing.Point(219, 67);
            this.tBGetterSurname.Name = "tBGetterSurname";
            this.tBGetterSurname.Size = new System.Drawing.Size(132, 20);
            this.tBGetterSurname.TabIndex = 7;
            // 
            // tBGetterPosition
            // 
            this.tBGetterPosition.Location = new System.Drawing.Point(219, 38);
            this.tBGetterPosition.Name = "tBGetterPosition";
            this.tBGetterPosition.Size = new System.Drawing.Size(132, 20);
            this.tBGetterPosition.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Дата возврата";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Фамилия выдающего сборку";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Фамилия получающего сборку";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Должность получающего сборку";
            // 
            // dTPDeliveryDate
            // 
            this.dTPDeliveryDate.Location = new System.Drawing.Point(219, 9);
            this.dTPDeliveryDate.Name = "dTPDeliveryDate";
            this.dTPDeliveryDate.Size = new System.Drawing.Size(132, 20);
            this.dTPDeliveryDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата выдачи";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.bttnPrev);
            this.pnlFooter.Controls.Add(this.bttnNext);
            this.pnlFooter.Controls.Add(this.bttnCancel);
            this.pnlFooter.Location = new System.Drawing.Point(-6, 226);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(535, 69);
            this.pnlFooter.TabIndex = 4;
            // 
            // bttnPrev
            // 
            this.bttnPrev.Enabled = false;
            this.bttnPrev.Location = new System.Drawing.Point(166, 11);
            this.bttnPrev.Name = "bttnPrev";
            this.bttnPrev.Size = new System.Drawing.Size(74, 22);
            this.bttnPrev.TabIndex = 0;
            this.bttnPrev.Text = "< Назад";
            this.bttnPrev.UseVisualStyleBackColor = true;
            this.bttnPrev.Click += new System.EventHandler(this.bttnPrev_Click);
            // 
            // bttnNext
            // 
            this.bttnNext.Location = new System.Drawing.Point(246, 11);
            this.bttnNext.Name = "bttnNext";
            this.bttnNext.Size = new System.Drawing.Size(74, 22);
            this.bttnNext.TabIndex = 1;
            this.bttnNext.Text = "Далее >";
            this.bttnNext.UseVisualStyleBackColor = true;
            this.bttnNext.Click += new System.EventHandler(this.bttnNext_Click);
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(348, 11);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(74, 22);
            this.bttnCancel.TabIndex = 2;
            this.bttnCancel.Text = "Отмена";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.lblHeader);
            this.pnlHeader.Location = new System.Drawing.Point(-6, -39);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(449, 89);
            this.pnlHeader.TabIndex = 6;
            this.pnlHeader.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeader.Location = new System.Drawing.Point(16, 55);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(281, 17);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Введите данные исполнения заказа";
            // 
            // fGiveAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 271);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fGiveAssembly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мастер выдачи сборки УСПО";
            this.tabControl1.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBFrontImage)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage0;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button bttnPrev;
        private System.Windows.Forms.Button bttnNext;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dTPDeliveryDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dTPPlanedReturnDate;
        private System.Windows.Forms.TextBox tBGiverSurname;
        private System.Windows.Forms.TextBox tBGetterSurname;
        private System.Windows.Forms.TextBox tBGetterPosition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pBFrontImage;
    }
}