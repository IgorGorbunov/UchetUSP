namespace UchetUSP
{
    partial class ElementCountForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElementCountForm));
            this.label1 = new System.Windows.Forms.Label();
            this.nUDElementsN = new System.Windows.Forms.NumericUpDown();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUDElementsN)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество элементов";
            // 
            // nUDElementsN
            // 
            this.nUDElementsN.Location = new System.Drawing.Point(36, 42);
            this.nUDElementsN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDElementsN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDElementsN.Name = "nUDElementsN";
            this.nUDElementsN.Size = new System.Drawing.Size(43, 20);
            this.nUDElementsN.TabIndex = 1;
            this.nUDElementsN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Image = global::UchetUSP.Properties.Resources.cancel_16x16;
            this.bttnCancel.Location = new System.Drawing.Point(21, 99);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 3;
            this.bttnCancel.Text = "Отмена";
            this.bttnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnOK
            // 
            this.bttnOK.Image = global::UchetUSP.Properties.Resources.galochka_check_16x16;
            this.bttnOK.Location = new System.Drawing.Point(21, 70);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 2;
            this.bttnOK.Text = "ОК";
            this.bttnOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // ElementCountForm
            // 
            this.AcceptButton = this.bttnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(116, 129);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.nUDElementsN);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ElementCountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.nUDElementsN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nUDElementsN;
        private System.Windows.Forms.Button bttnOK;
        private System.Windows.Forms.Button bttnCancel;
    }
}