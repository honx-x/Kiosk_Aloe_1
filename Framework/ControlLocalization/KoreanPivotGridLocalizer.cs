using DevExpress.XtraPivotGrid.Localization;

namespace TLF.Framework.ControlLocalization
{
    /// <summary>
    /// 
    /// </summary>
    public class KoreanPivotGridLocalizer : DevExpress.XtraPivotGrid.Localization.PivotGridLocalizer
    {
        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public KoreanPivotGridLocalizer()
        {

        }

        #endregion

        #region :: GetLocalizedString :: Editor Control에서 보여지는 Text를 설정합니다.

        /// <summary>
        /// Grid Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(PivotGridStringId id)
        {
            switch (id)
            {
                case PivotGridStringId.DataFieldCaption: return "Data Field를 이 공간으로 끌어 놓으세요";
                case PivotGridStringId.FilterArea: return "Filter Field를 이 공간으로 끌어 놓으세요";
                case PivotGridStringId.GrandTotal: return "총계";
                case PivotGridStringId.Total: return "소계";
            }

            return base.GetLocalizedString(id);
        }

        #endregion
    }
}
