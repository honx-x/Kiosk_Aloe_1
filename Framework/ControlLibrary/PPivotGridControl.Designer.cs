using System.Drawing;
namespace TLF.Framework.ControlLibrary
{
    partial class PPivotGridControl
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

            this.Appearance.HeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.DataHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.FieldHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.FieldValue.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.FieldValueTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.FieldValueGrandTotal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.RowHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Appearance.ColumnHeaderArea.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            
            this.Appearance.HeaderArea.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.DataHeaderArea.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.FieldHeader.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.RowHeaderArea.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.Cell.Font = ControlConfig.DEFAULTFONT;
            this.Appearance.ColumnHeaderArea.Font = ControlConfig.DEFAULTFONT;

            this.Appearance.GrandTotalCell.BackColor = Color.FromArgb(50, 230, 230, 230);
        }

        #endregion
    }
}
