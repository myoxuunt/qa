namespace QA
{
    partial class frmContentManager
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
            this.lstContent = new System.Windows.Forms.ListBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(357, 430);
            this.okButton.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(445, 430);
            this.cancelButton.Text = "关闭";
            // 
            // lstContent
            // 
            this.lstContent.FormattingEnabled = true;
            this.lstContent.ItemHeight = 12;
            this.lstContent.Location = new System.Drawing.Point(12, 12);
            this.lstContent.Name = "lstContent";
            this.lstContent.Size = new System.Drawing.Size(505, 148);
            this.lstContent.TabIndex = 19;
            this.lstContent.SelectedIndexChanged += new System.EventHandler(this.lstContent_SelectedIndexChanged);
            // 
            // txtContent
            // 
            this.txtContent.BackColor = System.Drawing.Color.White;
            this.txtContent.Location = new System.Drawing.Point(12, 166);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ReadOnly = true;
            this.txtContent.Size = new System.Drawing.Size(505, 242);
            this.txtContent.TabIndex = 20;
            // 
            // frmContentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 466);
            this.Controls.Add(this.lstContent);
            this.Controls.Add(this.txtContent);
            this.Name = "frmContentManager";
            this.Text = "插件";
            this.Load += new System.EventHandler(this.frmContentManager_Load);
            this.Controls.SetChildIndex(this.txtContent, 0);
            this.Controls.SetChildIndex(this.lstContent, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstContent;
        private System.Windows.Forms.TextBox txtContent;
    }
}