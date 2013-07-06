namespace UchetUSP
{
    partial class fAssemblyInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAssemblyInfo));
            this.pnlProject = new System.Windows.Forms.Panel();
            this.pnlCreation = new System.Windows.Forms.Panel();
            this.pnlDowntime = new System.Windows.Forms.Panel();
            this.pnlInWork = new System.Windows.Forms.Panel();
            this.lblAssemblyStatys = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCreationVPPdate = new System.Windows.Forms.Label();
            this.lblProjectDate = new System.Windows.Forms.Label();
            this.lblCreationOrderDate = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.lblDeliveryDate = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lBElements = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAssDiffic = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAssCount = new System.Windows.Forms.Label();
            this.dGVOrders = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProject
            // 
            this.pnlProject.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pnlProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProject.Location = new System.Drawing.Point(521, 364);
            this.pnlProject.Name = "pnlProject";
            this.pnlProject.Size = new System.Drawing.Size(80, 20);
            this.pnlProject.TabIndex = 0;
            this.pnlProject.Visible = false;
            // 
            // pnlCreation
            // 
            this.pnlCreation.BackColor = System.Drawing.Color.Red;
            this.pnlCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCreation.Location = new System.Drawing.Point(607, 364);
            this.pnlCreation.Name = "pnlCreation";
            this.pnlCreation.Size = new System.Drawing.Size(69, 20);
            this.pnlCreation.TabIndex = 1;
            this.pnlCreation.Visible = false;
            // 
            // pnlDowntime
            // 
            this.pnlDowntime.BackColor = System.Drawing.Color.Gold;
            this.pnlDowntime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDowntime.Location = new System.Drawing.Point(680, 364);
            this.pnlDowntime.Name = "pnlDowntime";
            this.pnlDowntime.Size = new System.Drawing.Size(55, 20);
            this.pnlDowntime.TabIndex = 2;
            this.pnlDowntime.Visible = false;
            // 
            // pnlInWork
            // 
            this.pnlInWork.BackColor = System.Drawing.Color.LimeGreen;
            this.pnlInWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlInWork.Location = new System.Drawing.Point(735, 364);
            this.pnlInWork.Name = "pnlInWork";
            this.pnlInWork.Size = new System.Drawing.Size(116, 20);
            this.pnlInWork.TabIndex = 3;
            this.pnlInWork.Visible = false;
            // 
            // lblAssemblyStatys
            // 
            this.lblAssemblyStatys.AutoSize = true;
            this.lblAssemblyStatys.ForeColor = System.Drawing.Color.Black;
            this.lblAssemblyStatys.Location = new System.Drawing.Point(134, 324);
            this.lblAssemblyStatys.Name = "lblAssemblyStatys";
            this.lblAssemblyStatys.Size = new System.Drawing.Size(90, 13);
            this.lblAssemblyStatys.TabIndex = 6;
            this.lblAssemblyStatys.Text = "lblAssemblyStatys";
            this.lblAssemblyStatys.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Состояние сборки - ";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Дата создания ВПП -";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(517, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Дата проектирования УСПО -";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(517, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Дата оформления листа заказа -";
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 280);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Дата создания УСПО -";
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(517, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Дата поставки УСПО -";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(517, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Дата возврата УСПО -";
            this.label7.Visible = false;
            // 
            // lblCreationVPPdate
            // 
            this.lblCreationVPPdate.AutoSize = true;
            this.lblCreationVPPdate.Location = new System.Drawing.Point(639, 213);
            this.lblCreationVPPdate.Name = "lblCreationVPPdate";
            this.lblCreationVPPdate.Size = new System.Drawing.Size(35, 13);
            this.lblCreationVPPdate.TabIndex = 14;
            this.lblCreationVPPdate.Text = "label8";
            this.lblCreationVPPdate.Visible = false;
            // 
            // lblProjectDate
            // 
            this.lblProjectDate.AutoSize = true;
            this.lblProjectDate.Location = new System.Drawing.Point(683, 236);
            this.lblProjectDate.Name = "lblProjectDate";
            this.lblProjectDate.Size = new System.Drawing.Size(35, 13);
            this.lblProjectDate.TabIndex = 15;
            this.lblProjectDate.Text = "label8";
            this.lblProjectDate.Visible = false;
            // 
            // lblCreationOrderDate
            // 
            this.lblCreationOrderDate.AutoSize = true;
            this.lblCreationOrderDate.Location = new System.Drawing.Point(700, 258);
            this.lblCreationOrderDate.Name = "lblCreationOrderDate";
            this.lblCreationOrderDate.Size = new System.Drawing.Size(35, 13);
            this.lblCreationOrderDate.TabIndex = 16;
            this.lblCreationOrderDate.Text = "label8";
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Location = new System.Drawing.Point(647, 280);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(35, 13);
            this.lblCreationDate.TabIndex = 17;
            this.lblCreationDate.Text = "label8";
            this.lblCreationDate.Visible = false;
            // 
            // lblDeliveryDate
            // 
            this.lblDeliveryDate.AutoSize = true;
            this.lblDeliveryDate.Location = new System.Drawing.Point(647, 302);
            this.lblDeliveryDate.Name = "lblDeliveryDate";
            this.lblDeliveryDate.Size = new System.Drawing.Size(35, 13);
            this.lblDeliveryDate.TabIndex = 18;
            this.lblDeliveryDate.Text = "label8";
            this.lblDeliveryDate.Visible = false;
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(647, 324);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(35, 13);
            this.lblReturnDate.TabIndex = 19;
            this.lblReturnDate.Text = "label8";
            this.lblReturnDate.Visible = false;
            // 
            // lBElements
            // 
            this.lBElements.FormattingEnabled = true;
            this.lBElements.Location = new System.Drawing.Point(521, 141);
            this.lBElements.Name = "lBElements";
            this.lBElements.Size = new System.Drawing.Size(153, 121);
            this.lBElements.TabIndex = 21;
            this.lBElements.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lBElements_MouseDoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(63, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Сложность сборки";
            // 
            // lblAssDiffic
            // 
            this.lblAssDiffic.AutoSize = true;
            this.lblAssDiffic.Location = new System.Drawing.Point(283, 50);
            this.lblAssDiffic.Name = "lblAssDiffic";
            this.lblAssDiffic.Size = new System.Drawing.Size(41, 13);
            this.lblAssDiffic.TabIndex = 23;
            this.lblAssDiffic.Text = "label10";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Количество использований сборки";
            // 
            // lblAssCount
            // 
            this.lblAssCount.AutoSize = true;
            this.lblAssCount.Location = new System.Drawing.Point(283, 76);
            this.lblAssCount.Name = "lblAssCount";
            this.lblAssCount.Size = new System.Drawing.Size(41, 13);
            this.lblAssCount.TabIndex = 25;
            this.lblAssCount.Text = "label11";
            // 
            // dGVOrders
            // 
            this.dGVOrders.AllowUserToAddRows = false;
            this.dGVOrders.AllowUserToDeleteRows = false;
            this.dGVOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVOrders.Location = new System.Drawing.Point(31, 124);
            this.dGVOrders.Name = "dGVOrders";
            this.dGVOrders.ReadOnly = true;
            this.dGVOrders.RowHeadersVisible = false;
            this.dGVOrders.Size = new System.Drawing.Size(480, 147);
            this.dGVOrders.TabIndex = 26;
            this.dGVOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVOrders_CellDoubleClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(518, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Входящие элементы:";
            // 
            // fAssemblyInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 282);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dGVOrders);
            this.Controls.Add(this.lblAssCount);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblAssDiffic);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lBElements);
            this.Controls.Add(this.lblReturnDate);
            this.Controls.Add(this.lblDeliveryDate);
            this.Controls.Add(this.lblCreationDate);
            this.Controls.Add(this.lblCreationOrderDate);
            this.Controls.Add(this.lblProjectDate);
            this.Controls.Add(this.lblCreationVPPdate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAssemblyStatys);
            this.Controls.Add(this.pnlInWork);
            this.Controls.Add(this.pnlDowntime);
            this.Controls.Add(this.pnlCreation);
            this.Controls.Add(this.pnlProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fAssemblyInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Информация о сборке";
            ((System.ComponentModel.ISupportInitialize)(this.dGVOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlProject;
        private System.Windows.Forms.Panel pnlCreation;
        private System.Windows.Forms.Panel pnlDowntime;
        private System.Windows.Forms.Panel pnlInWork;
        private System.Windows.Forms.Label lblAssemblyStatys;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCreationVPPdate;
        private System.Windows.Forms.Label lblProjectDate;
        private System.Windows.Forms.Label lblCreationOrderDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Label lblDeliveryDate;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.ListBox lBElements;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblAssDiffic;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAssCount;
        private System.Windows.Forms.DataGridView dGVOrders;
        private System.Windows.Forms.Label label11;
    }
}