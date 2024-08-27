
namespace Metro1
{
    partial class TableForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableForm));
            this.Table1DGV = new System.Windows.Forms.DataGridView();
            this.Finishlabel = new System.Windows.Forms.Label();
            this.Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F1j = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F2i = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Table1DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Table1DGV
            // 
            this.Table1DGV.AllowUserToDeleteRows = false;
            this.Table1DGV.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Table1DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table1DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Operator,
            this.j,
            this.F1j,
            this.Operand,
            this.i,
            this.F2i});
            this.Table1DGV.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Table1DGV.Location = new System.Drawing.Point(0, 0);
            this.Table1DGV.Name = "Table1DGV";
            this.Table1DGV.ReadOnly = true;
            this.Table1DGV.RowHeadersVisible = false;
            this.Table1DGV.RowHeadersWidth = 62;
            this.Table1DGV.RowTemplate.Height = 33;
            this.Table1DGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Table1DGV.Size = new System.Drawing.Size(965, 520);
            this.Table1DGV.TabIndex = 0;
            // 
            // Finishlabel
            // 
            this.Finishlabel.AutoSize = true;
            this.Finishlabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Finishlabel.Location = new System.Drawing.Point(317, 542);
            this.Finishlabel.Name = "Finishlabel";
            this.Finishlabel.Size = new System.Drawing.Size(0, 32);
            this.Finishlabel.TabIndex = 1;
            // 
            // Operator
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Operator.DefaultCellStyle = dataGridViewCellStyle7;
            this.Operator.HeaderText = "Оператор";
            this.Operator.MinimumWidth = 8;
            this.Operator.Name = "Operator";
            this.Operator.ReadOnly = true;
            this.Operator.Width = 120;
            // 
            // j
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.j.DefaultCellStyle = dataGridViewCellStyle8;
            this.j.HeaderText = "j";
            this.j.MinimumWidth = 8;
            this.j.Name = "j";
            this.j.ReadOnly = true;
            this.j.Width = 280;
            // 
            // F1j
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.F1j.DefaultCellStyle = dataGridViewCellStyle9;
            this.F1j.HeaderText = "F1j";
            this.F1j.MinimumWidth = 8;
            this.F1j.Name = "F1j";
            this.F1j.ReadOnly = true;
            this.F1j.Width = 80;
            // 
            // Operand
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Operand.DefaultCellStyle = dataGridViewCellStyle10;
            this.Operand.HeaderText = "Операнд";
            this.Operand.MinimumWidth = 8;
            this.Operand.Name = "Operand";
            this.Operand.ReadOnly = true;
            this.Operand.Width = 120;
            // 
            // i
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.i.DefaultCellStyle = dataGridViewCellStyle11;
            this.i.HeaderText = "i";
            this.i.MinimumWidth = 8;
            this.i.Name = "i";
            this.i.ReadOnly = true;
            this.i.Width = 280;
            // 
            // F2i
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.F2i.DefaultCellStyle = dataGridViewCellStyle12;
            this.F2i.HeaderText = "F2i";
            this.F2i.MinimumWidth = 8;
            this.F2i.Name = "F2i";
            this.F2i.ReadOnly = true;
            this.F2i.Width = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(828, 572);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(104, 98);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 695);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Finishlabel);
            this.Controls.Add(this.Table1DGV);
            this.MaximizeBox = false;
            this.Name = "TableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableForm";
            ((System.ComponentModel.ISupportInitialize)(this.Table1DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table1DGV;
        private System.Windows.Forms.Label Finishlabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operator;
        private System.Windows.Forms.DataGridViewTextBoxColumn j;
        private System.Windows.Forms.DataGridViewTextBoxColumn F1j;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operand;
        private System.Windows.Forms.DataGridViewTextBoxColumn i;
        private System.Windows.Forms.DataGridViewTextBoxColumn F2i;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}