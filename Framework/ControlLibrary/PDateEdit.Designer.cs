namespace TLF.Framework.ControlLibrary
{
    partial class PDateEdit
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            this.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.Properties.ShowClear = false;
            this.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.Properties.AppearanceDropDown.Font = ControlConfig.DEFAULTFONT;
            this.Properties.AppearanceDropDownHeader.Font = ControlConfig.DEFAULTFONT;
            this.Properties.AppearanceDropDownHeaderHighlight.Font = ControlConfig.DEFAULTFONT;
            this.Properties.AppearanceDropDownHighlight.Font = ControlConfig.DEFAULTFONT;
            this.Properties.AppearanceWeekNumber.Font = ControlConfig.DEFAULTFONT;
            this.Properties.AppearanceWeekNumber.ForeColor = System.Drawing.Color.Teal;

            this.Properties.Mask.EditMask = "yyyy-MM-dd";//TLF.Framework.Config.AppConfig.DEFAULTDATEFORMAT;
        }

        #endregion
    }
}
