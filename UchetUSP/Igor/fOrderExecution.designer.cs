namespace UchetUSP
{
    partial class fOrderExecution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fOrderExecution));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage0 = new System.Windows.Forms.TabPage();
            this.pBFrontImage = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.tBBrigadierSurname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tBAssemblyCreatorSurname = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tBAssemblyNum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBSectorNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dTPCreationDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.bttnDelEl = new System.Windows.Forms.Button();
            this.dGVElements = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tBAddElement = new System.Windows.Forms.TextBox();
            this.lBAddedElements = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.tabPage2.SuspendLayout();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage0);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-7, -24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(467, 278);
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
            this.tabPage0.Size = new System.Drawing.Size(459, 252);
            this.tabPage0.TabIndex = 0;
            this.tabPage0.Text = "tabPage0";
            this.tabPage0.UseVisualStyleBackColor = true;
            // 
            // pBFrontImage
            // 
            this.pBFrontImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBFrontImage.Image = global::UchetUSP.Properties.Resources.masterImage;
            this.pBFrontImage.Location = new System.Drawing.Point(-46, 0);
            this.pBFrontImage.Name = "pBFrontImage";
            this.pBFrontImage.Size = new System.Drawing.Size(160, 231);
            this.pBFrontImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBFrontImage.TabIndex = 6;
            this.pBFrontImage.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(135, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Этот мастер поможет подтвердить исполнение заказа на сборку УСПО по форме 2424.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(135, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "Для продолжения нажмите кнопку \"Далее\".";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(135, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "Мастер подтверждения исполнения заказа на сборку УСПО";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pnl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 252);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.tBBrigadierSurname);
            this.pnl1.Controls.Add(this.label8);
            this.pnl1.Controls.Add(this.tBAssemblyCreatorSurname);
            this.pnl1.Controls.Add(this.label7);
            this.pnl1.Controls.Add(this.tBAssemblyNum);
            this.pnl1.Controls.Add(this.label6);
            this.pnl1.Controls.Add(this.tBSectorNum);
            this.pnl1.Controls.Add(this.label5);
            this.pnl1.Controls.Add(this.dTPCreationDate);
            this.pnl1.Controls.Add(this.label4);
            this.pnl1.Location = new System.Drawing.Point(15, 60);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(415, 161);
            this.pnl1.TabIndex = 0;
            // 
            // tBBrigadierSurname
            // 
            this.tBBrigadierSurname.Location = new System.Drawing.Point(214, 128);
            this.tBBrigadierSurname.Name = "tBBrigadierSurname";
            this.tBBrigadierSurname.Size = new System.Drawing.Size(158, 20);
            this.tBBrigadierSurname.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(180, 33);
            this.label8.TabIndex = 8;
            this.label8.Text = "Фамилия мастера участка сборки УСПО";
            // 
            // tBAssemblyCreatorSurname
            // 
            this.tBAssemblyCreatorSurname.Location = new System.Drawing.Point(214, 90);
            this.tBAssemblyCreatorSurname.Name = "tBAssemblyCreatorSurname";
            this.tBAssemblyCreatorSurname.Size = new System.Drawing.Size(158, 20);
            this.tBAssemblyCreatorSurname.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 27);
            this.label7.TabIndex = 6;
            this.label7.Text = "Фамилия исполнителя сборки приспособления УСПО";
            // 
            // tBAssemblyNum
            // 
            this.tBAssemblyNum.Location = new System.Drawing.Point(351, 48);
            this.tBAssemblyNum.Name = "tBAssemblyNum";
            this.tBAssemblyNum.Size = new System.Drawing.Size(36, 20);
            this.tBAssemblyNum.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(211, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "Номер сборки приспособления УСПО";
            // 
            // tBSectorNum
            // 
            this.tBSectorNum.Location = new System.Drawing.Point(147, 48);
            this.tBSectorNum.Name = "tBSectorNum";
            this.tBSectorNum.Size = new System.Drawing.Size(36, 20);
            this.tBSectorNum.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 27);
            this.label5.TabIndex = 2;
            this.label5.Text = "Номер участка сборки приспособления УСПО";
            // 
            // dTPCreationDate
            // 
            this.dTPCreationDate.Location = new System.Drawing.Point(147, 3);
            this.dTPCreationDate.Name = "dTPCreationDate";
            this.dTPCreationDate.Size = new System.Drawing.Size(253, 20);
            this.dTPCreationDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата изготовления приспособления УСПО";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.pnl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 252);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.bttnDelEl);
            this.pnl2.Controls.Add(this.dGVElements);
            this.pnl2.Controls.Add(this.label10);
            this.pnl2.Controls.Add(this.tBAddElement);
            this.pnl2.Controls.Add(this.lBAddedElements);
            this.pnl2.Controls.Add(this.label9);
            this.pnl2.Location = new System.Drawing.Point(-4, 36);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(475, 197);
            this.pnl2.TabIndex = 0;
            // 
            // bttnDelEl
            // 
            this.bttnDelEl.Location = new System.Drawing.Point(348, 162);
            this.bttnDelEl.Name = "bttnDelEl";
            this.bttnDelEl.Size = new System.Drawing.Size(107, 23);
            this.bttnDelEl.TabIndex = 4;
            this.bttnDelEl.Text = "Удалить элемент";
            this.bttnDelEl.UseVisualStyleBackColor = true;
            this.bttnDelEl.Click += new System.EventHandler(this.bttnDelEl_Click);
            // 
            // dGVElements
            // 
            this.dGVElements.AllowUserToAddRows = false;
            this.dGVElements.AllowUserToDeleteRows = false;
            this.dGVElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVElements.Location = new System.Drawing.Point(16, 67);
            this.dGVElements.MultiSelect = false;
            this.dGVElements.Name = "dGVElements";
            this.dGVElements.ReadOnly = true;
            this.dGVElements.RowHeadersVisible = false;
            this.dGVElements.Size = new System.Drawing.Size(327, 119);
            this.dGVElements.TabIndex = 3;
            this.dGVElements.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVElements_CellDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Введите обозначение элемента";
            // 
            // tBAddElement
            // 
            this.tBAddElement.Location = new System.Drawing.Point(16, 36);
            this.tBAddElement.Name = "tBAddElement";
            this.tBAddElement.Size = new System.Drawing.Size(101, 20);
            this.tBAddElement.TabIndex = 1;
            this.tBAddElement.TextChanged += new System.EventHandler(this.tBAddElement_TextChanged);
            // 
            // lBAddedElements
            // 
            this.lBAddedElements.AllowDrop = true;
            this.lBAddedElements.FormattingEnabled = true;
            this.lBAddedElements.HorizontalScrollbar = true;
            this.lBAddedElements.Location = new System.Drawing.Point(349, 65);
            this.lBAddedElements.MultiColumn = true;
            this.lBAddedElements.Name = "lBAddedElements";
            this.lBAddedElements.Size = new System.Drawing.Size(106, 95);
            this.lBAddedElements.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.Location = new System.Drawing.Point(346, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 39);
            this.label9.TabIndex = 1;
            this.label9.Text = "Добавленные элементы:";
            this.label9.Visible = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.bttnPrev);
            this.pnlFooter.Controls.Add(this.bttnNext);
            this.pnlFooter.Controls.Add(this.bttnCancel);
            this.pnlFooter.Location = new System.Drawing.Point(-7, 225);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(467, 55);
            this.pnlFooter.TabIndex = 3;
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
            this.pnlHeader.Location = new System.Drawing.Point(-7, -40);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(467, 89);
            this.pnlHeader.TabIndex = 5;
            this.pnlHeader.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeader.Location = new System.Drawing.Point(16, 48);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(432, 39);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Введите данные исполнения заказа";
            // 
            // fOrderExecution
            // 
            this.AcceptButton = this.bttnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(454, 275);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fOrderExecution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Мастер подтверждения исполнения заказа";
            this.tabControl1.ResumeLayout(false);
            this.tabPage0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBFrontImage)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dTPCreationDate;
        private System.Windows.Forms.TextBox tBSectorNum;
        private System.Windows.Forms.TextBox tBAssemblyNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tBAssemblyCreatorSurname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBBrigadierSurname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pBFrontImage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.ListBox lBAddedElements;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dGVElements;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBAddElement;
        private System.Windows.Forms.Button bttnDelEl;
    }
}