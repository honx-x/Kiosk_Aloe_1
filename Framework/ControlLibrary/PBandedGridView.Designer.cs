namespace TLF.Framework.ControlLibrary
{
    partial class PBandedGridView
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

            this.CustomDrawCell +=new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(PBandedGridView_CustomDrawCell);

            this.OptionsView.ShowGroupPanel = false;
            this.OptionsView.ColumnAutoWidth = false;
            this.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            this.BandPanelRowHeight = 30;
            this.ColumnPanelRowHeight = 25;

            this.OptionsMenu.EnableColumnMenu = false;
            this.OptionsMenu.EnableFooterMenu = false;
            
            this.Appearance.BandPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.HeaderPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FooterPanel.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FilterPanel.Font = ControlConfig.DEFAULTFONT;

            this.Appearance.Row.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FocusedRow.BackColor = ControlConfig.FOCUSEDROWCOLOR;
        }

        #endregion
    }
}
