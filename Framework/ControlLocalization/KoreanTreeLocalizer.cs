using DevExpress.XtraTreeList.Localization;

namespace TLF.Framework.ControlLocalization
{
    /// <summary>
    /// TreeList Control을 한국어로 설정합니다.
    /// </summary>
    public class KoreanTreeLocalizer : DevExpress.XtraTreeList.Localization.TreeListLocalizer
    {
        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public KoreanTreeLocalizer()
        {

        }

        #endregion

        #region :: GetLocalizedString :: Editor Control에서 보여지는 Text를 설정합니다.

        /// <summary>
        /// Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(TreeListStringId id)
        {
            switch (id)
            {
                case TreeListStringId.ColumnCustomizationText: return "컬럼 사용자지정";
                case TreeListStringId.MenuColumnBestFit: return "최적너비";
                case TreeListStringId.MenuColumnBestFitAllColumns: return "최적너비(전체 컬럼)";
                case TreeListStringId.MenuColumnSortAscending: return "오름차순 정렬";
                case TreeListStringId.MenuColumnSortDescending: return "내림차순 정렬";
                case TreeListStringId.MenuColumnColumnCustomization: return "컬럼 사용자지정";
            }
            return base.GetLocalizedString(id);
        }

        #endregion
    }
}
