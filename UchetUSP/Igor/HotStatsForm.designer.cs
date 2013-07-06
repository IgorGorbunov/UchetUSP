namespace UchetUSP
{
    partial class HotStatsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotStatsForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ôàéëToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ýêñïîðòÂExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGVElements = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ôàéëToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(631, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ôàéëToolStripMenuItem
            // 
            this.ôàéëToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ýêñïîðòÂExcelToolStripMenuItem});
            this.ôàéëToolStripMenuItem.Name = "ôàéëToolStripMenuItem";
            this.ôàéëToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.ôàéëToolStripMenuItem.Text = "Ôàéë";
            // 
            // ýêñïîðòÂExcelToolStripMenuItem
            // 
            this.ýêñïîðòÂExcelToolStripMenuItem.Name = "ýêñïîðòÂExcelToolStripMenuItem";
            this.ýêñïîðòÂExcelToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ýêñïîðòÂExcelToolStripMenuItem.Text = "Ýêñïîðò â Excel";
            this.ýêñïîðòÂExcelToolStripMenuItem.Click += new System.EventHandler(this.ýêñïîðòÂExcelToolStripMenuItem_Click);
            // 
            // dGVElements
            // 
            this.dGVElements.AllowUserToAddRows = false;
            this.dGVElements.AllowUserToDeleteRows = false;
            this.dGVElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVElements.Location = new System.Drawing.Point(0, 24);
            this.dGVElements.MultiSelect = false;
            this.dGVElements.Name = "dGVElements";
            this.dGVElements.ReadOnly = true;
            this.dGVElements.RowHeadersVisible = false;
            this.dGVElements.Size = new System.Drawing.Size(631, 267);
            this.dGVElements.TabIndex = 2;
            this.dGVElements.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVElements_CellDoubleClick);
            // 
            // HotStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 291);
            this.Controls.Add(this.dGVElements);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "HotStatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ñòàòèñòèêà ýëåìåíòîâ â òåêóùèõ ñáîðêàõ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ôàéëToolStripMenuItem;
        private System.Windows.Forms.DataGridView dGVElements;
        private System.Windows.Forms.ToolStripMenuItem ýêñïîðòÂExcelToolStripMenuItem;

    }
}