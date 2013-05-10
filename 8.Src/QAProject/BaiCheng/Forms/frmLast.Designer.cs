namespace BaiCheng
{
    partial class frmLast
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
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Location = new System.Drawing.Point(12, 12);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Size = new System.Drawing.Size(280, 241);
            this.ucDataGridView1.TabIndex = 0;
            // 
            // frmLast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 265);
            this.Controls.Add(this.ucDataGridView1);
            this.Name = "frmLast";
            this.Text = "最新数据";
            this.Load += new System.EventHandler(this.frmLast_Load);
            this.Activated += new System.EventHandler(this.frmLast_Activated);
            this.ResumeLayout(false);

        }

        #endregion

        private Xdgk.UI.Forms.UCDataGridView ucDataGridView1;


    }
}