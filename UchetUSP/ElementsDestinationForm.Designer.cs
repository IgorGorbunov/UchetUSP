namespace UchetUSP
{
    partial class ElementsDestinationForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.����ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.��������ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tBElemTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVElems = new System.Windows.Forms.DataGridView();
            this.dGVDest = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDest)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.����ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(647, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ����ToolStripMenuItem
            // 
            this.����ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.��������ExcelToolStripMenuItem});
            this.����ToolStripMenuItem.Name = "����ToolStripMenuItem";
            this.����ToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.����ToolStripMenuItem.Text = "����";
            // 
            // ��������ExcelToolStripMenuItem
            // 
            this.��������ExcelToolStripMenuItem.Name = "��������ExcelToolStripMenuItem";
            this.��������ExcelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.��������ExcelToolStripMenuItem.Text = "������� � Excel";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.dGVElems);
            this.pnlRight.Controls.Add(this.label1);
            this.pnlRight.Controls.Add(this.tBElemTitle);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(235, 24);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(412, 248);
            this.pnlRight.TabIndex = 1;
            // 
            // tBElemTitle
            // 
            this.tBElemTitle.Location = new System.Drawing.Point(34, 45);
            this.tBElemTitle.Name = "tBElemTitle";
            this.tBElemTitle.Size = new System.Drawing.Size(126, 20);
            this.tBElemTitle.TabIndex = 0;
            this.tBElemTitle.TextChanged += new System.EventHandler(this.tBElemTitle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "����������� ��������:";
            // 
            // dGVElems
            // 
            this.dGVElems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVElems.Location = new System.Drawing.Point(34, 71);
            this.dGVElems.Name = "dGVElems";
            this.dGVElems.ReadOnly = true;
            this.dGVElems.RowHeadersVisible = false;
            this.dGVElems.Size = new System.Drawing.Size(353, 153);
            this.dGVElems.TabIndex = 2;
            this.dGVElems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVElems_CellDoubleClick);
            // 
            // dGVDest
            // 
            this.dGVDest.AllowUserToAddRows = false;
            this.dGVDest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDest.Location = new System.Drawing.Point(20, 43);
            this.dGVDest.Name = "dGVDest";
            this.dGVDest.RowHeadersVisible = false;
            this.dGVDest.Size = new System.Drawing.Size(197, 205);
            this.dGVDest.TabIndex = 2;
            // 
            // ElementsDestinationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 272);
            this.Controls.Add(this.dGVDest);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "ElementsDestinationForm";
            this.Text = "ElementsDestinationForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ����ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ��������ExcelToolStripMenuItem;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.DataGridView dGVElems;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBElemTitle;
        private System.Windows.Forms.DataGridView dGVDest;
    }
}