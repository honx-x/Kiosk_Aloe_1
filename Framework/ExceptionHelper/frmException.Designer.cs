namespace TLF.Framework.ExceptionHelper
{
    internal partial class frmException
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
            this.picException = new DevExpress.XtraEditors.PictureEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDesc = new DevExpress.XtraEditors.MemoEdit();
            this.txtDetail = new DevExpress.XtraEditors.MemoEdit();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnResize = new DevExpress.XtraEditors.SimpleButton();
            this.btnReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picException.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picException
            // 
            this.picException.EditValue = global::TLF.Framework.ExceptionHelper.Properties.Resources.Error;
            this.picException.Location = new System.Drawing.Point(12, 12);
            this.picException.Name = "picException";
            this.picException.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picException.Properties.Appearance.Options.UseBackColor = true;
            this.picException.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picException.Properties.ShowMenu = false;
            this.picException.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picException.Size = new System.Drawing.Size(100, 100);
            this.picException.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(427, 118);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 21);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "확인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.Appearance.Options.UseFont = true;
            this.btnDetail.Location = new System.Drawing.Point(12, 118);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(95, 21);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "자세히 >>";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(118, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(280, 26);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "프로그램에서 예상하지 못한 오류가 발생하였습니다.\r\n오류 메시지는 다음과 같습니다.";
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(118, 44);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Properties.Appearance.Options.UseFont = true;
            this.txtDesc.Properties.ReadOnly = true;
            this.txtDesc.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDesc.Properties.WordWrap = false;
            this.txtDesc.Size = new System.Drawing.Size(404, 69);
            this.txtDesc.TabIndex = 5;
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(12, 145);
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.Properties.Appearance.Options.UseFont = true;
            this.txtDetail.Properties.ReadOnly = true;
            this.txtDetail.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetail.Properties.WordWrap = false;
            this.txtDetail.Size = new System.Drawing.Size(510, 192);
            this.txtDetail.TabIndex = 9;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.Location = new System.Drawing.Point(124, 343);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 21);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "종료";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnResize
            // 
            this.btnResize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResize.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResize.Appearance.Options.UseFont = true;
            this.btnResize.Location = new System.Drawing.Point(205, 343);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(75, 21);
            this.btnResize.TabIndex = 4;
            this.btnResize.Text = "크게";
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Appearance.Options.UseFont = true;
            this.btnReport.Location = new System.Drawing.Point(286, 343);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(132, 21);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "서버로 전송(DB 저장)";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Appearance.Options.UseFont = true;
            this.btnCopy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCopy.Location = new System.Drawing.Point(424, 343);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 21);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "클립보드에 복사";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // frmException
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 376);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.picException);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "예외발생";
            this.Load += new System.EventHandler(this.frmException_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picException.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDetail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picException;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtDesc;
        private DevExpress.XtraEditors.MemoEdit txtDetail;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnResize;
        private DevExpress.XtraEditors.SimpleButton btnReport;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
    }
}