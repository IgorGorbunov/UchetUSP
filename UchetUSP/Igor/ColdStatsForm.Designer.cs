namespace UchetUSP
{
    partial class ColdStatsForm
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
            this.dGV = new System.Windows.Forms.DataGridView();
            this.dTPFrom = new System.Windows.Forms.DateTimePicker();
            this.dTPTo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV
            // 
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(40, 31);
            this.dGV.Name = "dGV";
            this.dGV.Size = new System.Drawing.Size(800, 293);
            this.dGV.TabIndex = 0;
            // 
            // dTPFrom
            // 
            this.dTPFrom.Location = new System.Drawing.Point(129, 381);
            this.dTPFrom.Name = "dTPFrom";
            this.dTPFrom.Size = new System.Drawing.Size(126, 20);
            this.dTPFrom.TabIndex = 1;
            this.dTPFrom.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dTPTo
            // 
            this.dTPTo.Location = new System.Drawing.Point(382, 381);
            this.dTPTo.Name = "dTPTo";
            this.dTPTo.Size = new System.Drawing.Size(126, 20);
            this.dTPTo.TabIndex = 2;
            this.dTPTo.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // ColdStatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 461);
            this.Controls.Add(this.dTPTo);
            this.Controls.Add(this.dTPFrom);
            this.Controls.Add(this.dGV);
            this.Name = "ColdStatsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColdStatsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.DateTimePicker dTPFrom;
        private System.Windows.Forms.DateTimePicker dTPTo;
    }
}