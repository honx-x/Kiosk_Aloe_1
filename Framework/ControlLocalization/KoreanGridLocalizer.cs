using DevExpress.XtraGrid.Localization;

namespace TLF.Framework.ControlLocalization
{
    /// <summary>
    /// Grid Control Library를 한국어로 설정합니다.
    /// </summary>
    public class KoreanGridLocalizer : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public KoreanGridLocalizer()
        {

        }

        #endregion

        #region :: GetLocalizedString :: Editor Control에서 보여지는 Text를 설정합니다.

        /// <summary>
        /// Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                case GridStringId.MenuColumnBestFit: return "최적너비";
                case GridStringId.MenuColumnBestFitAllColumns: return "최적너비(전체 컬럼)";
                case GridStringId.MenuColumnClearFilter: return "필터링 해제";
                case GridStringId.MenuColumnClearSorting: return "정렬 제거";
                case GridStringId.MenuColumnColumnCustomization: return "컬럼 사용자지정";
                case GridStringId.MenuColumnFilter: return "필터링";
                case GridStringId.MenuColumnFilterEditor: return "필터링 편집";
                case GridStringId.MenuColumnGroup: return "그룹핑";
                case GridStringId.MenuColumnGroupBox: return "그룹박스 사용";
                case GridStringId.MenuColumnRemoveColumn: return "컬럼 제거";
                case GridStringId.MenuColumnSortAscending: return "오름차순 정렬";
                case GridStringId.MenuColumnSortDescending: return "내림차순 정렬";
                case GridStringId.MenuColumnSortGroupBySummaryMenu: return "컬럼으로 그룹 지정";
                case GridStringId.MenuColumnUnGroup: return "그룹핑 제거";

                case GridStringId.MenuGroupPanelFullCollapse: return "전체 접기";
                case GridStringId.MenuGroupPanelFullExpand: return "전체 펼침";
                case GridStringId.MenuGroupPanelClearGrouping: return "그룹 해제";

                case GridStringId.GridGroupPanelText: return "그룹으로 지정할 컬럼을 이 공간으로 끌어 놓으세요";
            }
            return base.GetLocalizedString(id);
        }

        #endregion
    }
}
