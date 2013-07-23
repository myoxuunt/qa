namespace HDC.FluxQuery
{
    partial class frmHDQuery
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
            this.ucCondition1 = new Xdgk.UI.Forms.UCCondition();
            this.ucDataGridView1 = new Xdgk.UI.Forms.UCDataGridView();
            this.SuspendLayout();
            // 
            // ucCondition1
            // 
            this.ucCondition1.Begin = new System.DateTime(2013, 5, 7, 0, 0, 0, 0);
            this.ucCondition1.End = new System.DateTime(2013, 5, 8, 0, 0, 0, 0);
            this.ucCondition1.Location = new System.Drawing.Point(0, 12);
            this.ucCondition1.Name = "ucCondition1";
            this.ucCondition1.Size = new System.Drawing.Size(218, 204);
            this.ucCondition1.TabIndex = 1;
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDataGridView1.Location = new System.Drawing.Point(224, 12);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Size = new System.Drawing.Size(448, 286);
            this.ucDataGridView1.TabIndex = 2;
            // 
            // frmHDQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 310);
            this.Controls.Add(this.ucDataGridView1);
            this.Controls.Add(this.ucCondition1);
            this.Name = "frmHDQuery";
            this.Text = "frmHDQuery";
            this.Load += new System.EventHandler(this.frmHDQuery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Xdgk.UI.Forms.UCCondition ucCondition1;
        private Xdgk.UI.Forms.UCDataGridView ucDataGridView1;
    }
}