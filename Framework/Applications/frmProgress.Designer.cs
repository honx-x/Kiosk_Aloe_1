namespace TLF.Framework.Applications
{
    partial class frmProgress
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
            this.lblPgmName = new DevExpress.XtraEditors.LabelControl();
            this.pPictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pPictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPgmName
            // 
            this.lblPgmName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPgmName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPgmName.Appearance.Options.UseFont = true;
            this.lblPgmName.Appearance.Options.UseTextOptions = true;
            this.lblPgmName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPgmName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblPgmName.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblPgmName.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.lblPgmName.LineVisible = true;
            this.lblPgmName.Location = new System.Drawing.Point(12, 12);
            this.lblPgmName.Name = "lblPgmName";
            this.lblPgmName.Size = new System.Drawing.Size(276, 13);
            this.lblPgmName.TabIndex = 7;
            this.lblPgmName.Text = "lblMessage";
            // 
            // pPictureEdit1
            // 
            this.pPictureEdit1.EditValue = global::TLF.Framework.Applications.Properties.Resources.Loading;
            this.pPictureEdit1.Location = new System.Drawing.Point(96, 38);
            this.pPictureEdit1.Name = "pPictureEdit1";
            this.pPictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pPictureEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pPictureEdit1.Properties.Appearance.Options.UseFont = true;
            this.pPictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pPictureEdit1.Properties.ShowMenu = false;
            this.pPictureEdit1.Size = new System.Drawing.Size(108, 62);
            this.pPictureEdit1.TabIndex = 8;
            // 
            // frmProgress
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(300, 112);
            this.Controls.Add(this.pPictureEdit1);
            this.Controls.Add(this.lblPgmName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgress";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pPictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblPgmName;
        private DevExpress.XtraEditors.PictureEdit pPictureEdit1;
    }
}