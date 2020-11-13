namespace TLF.Framework.Applications
{
    partial class frmOptions
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
            this.wizardOption = new DevExpress.XtraWizard.WizardControl();
            this.welcomeWizardPage1 = new DevExpress.XtraWizard.WelcomeWizardPage();
            this.wizardPage1 = new DevExpress.XtraWizard.WizardPage();
            this.completionWizardPage1 = new DevExpress.XtraWizard.CompletionWizardPage();
            this.wizardPage2 = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage3 = new DevExpress.XtraWizard.WizardPage();
            this.wizardPage4 = new DevExpress.XtraWizard.WizardPage();
            ((System.ComponentModel.ISupportInitialize)(this.wizardOption)).BeginInit();
            this.wizardOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardOption
            // 
            this.wizardOption.Controls.Add(this.welcomeWizardPage1);
            this.wizardOption.Controls.Add(this.wizardPage1);
            this.wizardOption.Controls.Add(this.completionWizardPage1);
            this.wizardOption.Controls.Add(this.wizardPage2);
            this.wizardOption.Controls.Add(this.wizardPage3);
            this.wizardOption.Controls.Add(this.wizardPage4);
            this.wizardOption.Name = "wizardOption";
            this.wizardOption.Pages.AddRange(new DevExpress.XtraWizard.BaseWizardPage[] {
            this.welcomeWizardPage1,
            this.wizardPage1,
            this.wizardPage2,
            this.wizardPage3,
            this.wizardPage4,
            this.completionWizardPage1});
            // 
            // welcomeWizardPage1
            // 
            this.welcomeWizardPage1.IntroductionText = "사용자 설정을 시작합니다.";
            this.welcomeWizardPage1.Name = "welcomeWizardPage1";
            this.welcomeWizardPage1.ProceedText = "다음을 클릭하세요.";
            this.welcomeWizardPage1.Size = new System.Drawing.Size(290, 114);
            // 
            // wizardPage1
            // 
            this.wizardPage1.DescriptionText = "사용자가 해당하는 업체를 선택합니다.";
            this.wizardPage1.Name = "wizardPage1";
            this.wizardPage1.Size = new System.Drawing.Size(475, 102);
            this.wizardPage1.Text = "STEP 1 : 업체 선택(1/4)";
            // 
            // completionWizardPage1
            // 
            this.completionWizardPage1.FinishText = "사용자 설정이 완료되었습니다.";
            this.completionWizardPage1.Name = "completionWizardPage1";
            this.completionWizardPage1.ProceedText = "완료 버튼을 누르면 종료합니다.";
            this.completionWizardPage1.Size = new System.Drawing.Size(290, 114);
            // 
            // wizardPage2
            // 
            this.wizardPage2.DescriptionText = "해당 Plant를 선택합니다.";
            this.wizardPage2.Name = "wizardPage2";
            this.wizardPage2.Size = new System.Drawing.Size(475, 102);
            this.wizardPage2.Text = "Step 2 : PLANT(2/4)";
            // 
            // wizardPage3
            // 
            this.wizardPage3.DescriptionText = "자주 사용하는 공정을 선택합니다.";
            this.wizardPage3.Name = "wizardPage3";
            this.wizardPage3.Size = new System.Drawing.Size(475, 102);
            this.wizardPage3.Text = "Step 3 : Process(3/4)";
            // 
            // wizardPage4
            // 
            this.wizardPage4.DescriptionText = "자주 사용하는 Line을 선택합니다.";
            this.wizardPage4.Name = "wizardPage4";
            this.wizardPage4.Size = new System.Drawing.Size(475, 102);
            this.wizardPage4.Text = "Step 4 : Line(4/4)";
            // 
            // frmOptions
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 247);
            this.Controls.Add(this.wizardOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOptions";
            ((System.ComponentModel.ISupportInitialize)(this.wizardOption)).EndInit();
            this.wizardOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWizard.WizardControl wizardOption;
        private DevExpress.XtraWizard.WelcomeWizardPage welcomeWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage1;
        private DevExpress.XtraWizard.CompletionWizardPage completionWizardPage1;
        private DevExpress.XtraWizard.WizardPage wizardPage2;
        private DevExpress.XtraWizard.WizardPage wizardPage3;
        private DevExpress.XtraWizard.WizardPage wizardPage4;
    }
}