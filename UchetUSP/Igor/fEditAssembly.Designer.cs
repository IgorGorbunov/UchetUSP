namespace UchetUSP
{
    partial class fEditAssembly
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEditAssembly));
            this.bttnDelEl = new System.Windows.Forms.Button();
            this.dGVElements = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tBAddElement = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dGVFirstElements = new System.Windows.Forms.DataGridView();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstElements)).BeginInit();
            this.SuspendLayout();
            // 
            // bttnDelEl
            // 
            this.bttnDelEl.Location = new System.Drawing.Point(348, 280);
            this.bttnDelEl.Name = "bttnDelEl";
            this.bttnDelEl.Size = new System.Drawing.Size(207, 23);
            this.bttnDelEl.TabIndex = 10;
            this.bttnDelEl.Text = "Удалить элемент";
            this.bttnDelEl.UseVisualStyleBackColor = true;
            this.bttnDelEl.Click += new System.EventHandler(this.bttnDelEl_Click);
            // 
            // dGVElements
            // 
            this.dGVElements.AllowUserToAddRows = false;
            this.dGVElements.AllowUserToDeleteRows = false;
            this.dGVElements.BackgroundColor = System.Drawing.Color.White;
            this.dGVElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVElements.Location = new System.Drawing.Point(16, 61);
            this.dGVElements.MultiSelect = false;
            this.dGVElements.Name = "dGVElements";
            this.dGVElements.ReadOnly = true;
            this.dGVElements.RowHeadersVisible = false;
            this.dGVElements.Size = new System.Drawing.Size(327, 242);
            this.dGVElements.TabIndex = 9;
            this.dGVElements.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVElements_CellDoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Введите обозначение элемента";
            // 
            // tBAddElement
            // 
            this.tBAddElement.Location = new System.Drawing.Point(15, 34);
            this.tBAddElement.Name = "tBAddElement";
            this.tBAddElement.Size = new System.Drawing.Size(166, 20);
            this.tBAddElement.TabIndex = 6;
            this.tBAddElement.TextChanged += new System.EventHandler(this.tBAddElement_TextChanged);
            // 
            // label9
            // 
            this.label9.AllowDrop = true;
            this.label9.Location = new System.Drawing.Point(346, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 39);
            this.label9.TabIndex = 7;
            this.label9.Text = "Входящие элементы:";
            this.label9.Visible = false;
            // 
            // dGVFirstElements
            // 
            this.dGVFirstElements.AllowUserToAddRows = false;
            this.dGVFirstElements.AllowUserToDeleteRows = false;
            this.dGVFirstElements.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVFirstElements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVFirstElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVFirstElements.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVFirstElements.Location = new System.Drawing.Point(349, 61);
            this.dGVFirstElements.MultiSelect = false;
            this.dGVFirstElements.Name = "dGVFirstElements";
            this.dGVFirstElements.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVFirstElements.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dGVFirstElements.RowHeadersVisible = false;
            this.dGVFirstElements.Size = new System.Drawing.Size(206, 213);
            this.dGVFirstElements.TabIndex = 11;
            // 
            // bttnCancel
            // 
            this.bttnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bttnCancel.Location = new System.Drawing.Point(16, 317);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 12;
            this.bttnCancel.Text = "Отмена";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnOK
            // 
            this.bttnOK.Location = new System.Drawing.Point(480, 317);
            this.bttnOK.Name = "bttnOK";
            this.bttnOK.Size = new System.Drawing.Size(75, 23);
            this.bttnOK.TabIndex = 13;
            this.bttnOK.Text = "Завершить";
            this.bttnOK.UseVisualStyleBackColor = true;
            this.bttnOK.Click += new System.EventHandler(this.bttnOK_Click);
            // 
            // fEditAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bttnCancel;
            this.ClientSize = new System.Drawing.Size(567, 356);
            this.Controls.Add(this.bttnOK);
            this.Controls.Add(this.bttnCancel);
            this.Controls.Add(this.dGVFirstElements);
            this.Controls.Add(this.bttnDelEl);
            this.Controls.Add(this.dGVElements);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tBAddElement);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fEditAssembly";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Исправление состава сборки УСПО";
            this.Load += new System.EventHandler(this.fEditAssembly_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fEditAssembly_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dGVElements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFirstElements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnDelEl;
        private System.Windows.Forms.DataGridView dGVElements;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tBAddElement;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dGVFirstElements;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnOK;
    }
}