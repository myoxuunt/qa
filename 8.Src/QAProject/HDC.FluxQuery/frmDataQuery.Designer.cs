namespace HDC.FluxQuery
{
    partial class frmDataQuery
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
            this.ucDataGridView1 = new HDC.FluxQuery.UCDataGridView();
            this.ucCondition1 = new HDC.FluxQuery.UCCondition();
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDataGridView1.Location = new System.Drawing.Point(224, 12);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Size = new System.Drawing.Size(493, 295);
            this.ucDataGridView1.TabIndex = 1;
            // 
            // ucCondition1
            // 
            this.ucCondition1.IsAddAll = true;
            this.ucCondition1.Location = new System.Drawing.Point(0, 12);
            this.ucCondition1.Name = "ucCondition1";
            this.ucCondition1.Size = new System.Drawing.Size(218, 204);
            this.ucCondition1.TabIndex = 0;
            // 
            // frmDataQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 319);
            this.Controls.Add(this.ucDataGridView1);
            this.Controls.Add(this.ucCondition1);
            this.Name = "frmDataQuery";
            this.Text = "frmDataQuery";
            this.Load += new System.EventHandler(this.frmDataQuery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UCCondition ucCondition1;
        private UCDataGridView ucDataGridView1;
    }
}