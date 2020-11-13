using DevExpress.XtraLayout.Localization;

namespace TLF.Framework.ControlLocalization
{
    /// <summary>
    /// Layout Control Library를 한국어로 설정합니다.
    /// </summary>
    public class KoreanLayoutLocalizer : DevExpress.XtraLayout.Localization.LayoutLocalizer
    {
        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public KoreanLayoutLocalizer()
        {

        }

        #endregion

        #region :: GetLocalizedString :: Layout Control에서 보여지는 Text를 설정합니다.

        /// <summary>
        /// Layout Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(LayoutStringId id)
        {
            switch (id)
            {
                case LayoutStringId.CustomizationFormTitle: return "사용자 정의 Layout";
            }

            return base.GetLocalizedString(id);
        }

        #endregion
    }
}
