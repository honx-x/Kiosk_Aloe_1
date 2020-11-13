namespace TLF.Framework.ControlLibrary
{
    partial class PPopupEdit
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

            this.defaultButton = new DevExpress.XtraEditors.Controls.EditorButton();
            this.displayButton = new DevExpress.XtraEditors.Controls.EditorButton();

            //
            // defaultButton
            //
            defaultButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis;

            //
            // displayButton
            //
            displayButton.Appearance.Font = ControlConfig.DEFAULTFONT;
            displayButton.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
            displayButton.Enabled = false;
            displayButton.Width = 100;

            this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] 
                {
                    defaultButton,
                    displayButton
                });

            this.Font = ControlConfig.DEFAULTFONT;

            this.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(PPopupEdit_ButtonClick);
        }

        #endregion

        private DevExpress.XtraEditors.Controls.EditorButton displayButton;
        private DevExpress.XtraEditors.Controls.EditorButton defaultButton;
    }
}
