namespace HDC.FluxQuery
{
    partial class frmYearReport
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
            this.ucDataGridView1 = new Xdgk.UI.Forms.UCDataGridView();
            this.ucStationDT1Condition1 = new Xdgk.Common.UI.Forms.UCStationDT1Condition();
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDataGridView1.ColumnConfigFile = null;
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Location = new System.Drawing.Point(238, 12);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Size = new System.Drawing.Size(386, 331);
            this.ucDataGridView1.TabIndex = 3;
            // 
            // ucStationDT1Condition1
            // 
            this.ucStationDT1Condition1.Location = new System.Drawing.Point(12, 12);
            this.ucStationDT1Condition1.Name = "ucStationDT1Condition1";
            this.ucStationDT1Condition1.QueryButtonText = "查询";
            this.ucStationDT1Condition1.SelectedDT1 = new System.DateTime(2013, 7, 15, 14, 43, 31, 783);
            this.ucStationDT1Condition1.Size = new System.Drawing.Size(220, 119);
            this.ucStationDT1Condition1.TabIndex = 2;
            // 
            // frmYearReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 355);
            this.Controls.Add(this.ucDataGridView1);
            this.Controls.Add(this.ucStationDT1Condition1);
            this.Name = "frmYearReport";
            this.Text = "frmYearReport";
            this.Load += new System.EventHandler(this.frmYearReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Xdgk.UI.Forms.UCDataGridView ucDataGridView1;
        private Xdgk.Common.UI.Forms.UCStationDT1Condition ucStationDT1Condition1;
    }
}