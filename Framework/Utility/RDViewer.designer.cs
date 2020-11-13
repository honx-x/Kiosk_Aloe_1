namespace TLF.Framework.Utility
{
    partial class RdViewer
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RdViewer));
            this.axRdViewer = new AxRDVIEWER50Lib.AxRdviewer50();
            ((System.ComponentModel.ISupportInitialize)(this.axRdViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // axRdViewer
            // 
            this.axRdViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRdViewer.Enabled = true;
            this.axRdViewer.Location = new System.Drawing.Point(0, 0);
            this.axRdViewer.Name = "axRdViewer";
            this.axRdViewer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRdViewer.OcxState")));
            this.axRdViewer.Size = new System.Drawing.Size(639, 596);
            this.axRdViewer.TabIndex = 0;
            // 
            // RdViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 596);
            this.Controls.Add(this.axRdViewer);
            this.Name = "RdViewer";
            this.Text = "ReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.axRdViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxRDVIEWER50Lib.AxRdviewer50 axRdViewer;
    }
}