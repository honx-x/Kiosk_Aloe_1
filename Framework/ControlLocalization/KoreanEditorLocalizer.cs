using DevExpress.XtraEditors.Controls;

namespace TLF.Framework.ControlLocalization
{
    /// <summary>
    /// EditControl Library를 한국어로 설정합니다.
    /// </summary>
    public class KoreanEditorLocalizer : DevExpress.XtraEditors.Controls.Localizer
    {
        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public KoreanEditorLocalizer()
        {

        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetLocalizedString :: Editor Control에서 보여지는 Text를 설정합니다.

        /// <summary>
        /// Editor Control에서 보여지는 Text를 설정합니다.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override string GetLocalizedString(StringId id)
        {
            switch (id)
            {
                case StringId.OK: return "확인";
                case StringId.Cancel: return "취소";

                case StringId.FilterClauseAnyOf: return "Is Between";
                case StringId.FilterClauseBeginsWith: return "Is Between";
                case StringId.FilterClauseBetween: return "Is Between";
                case StringId.FilterClauseContains: return "포함";
                case StringId.FilterClauseDoesNotContain: return "포함하지 않음";
                case StringId.FilterClauseDoesNotEqual: return "같지 않음";
                case StringId.FilterClauseEndsWith: return "끝 문자";
                case StringId.FilterClauseEquals: return "같음";
                case StringId.FilterClauseGreater: return "큼";
                case StringId.FilterClauseGreaterOrEqual: return "크거나 같음";
                case StringId.FilterClauseIsNotNull: return "빈값 아님";
                case StringId.FilterClauseIsNull: return "빈 값";
                case StringId.FilterClauseLess: return "작음";
                case StringId.FilterClauseLessOrEqual: return "작거나 같음";
                case StringId.FilterClauseLike: return "비슷함";
                case StringId.FilterClauseNoneOf: return "Is None of";
                case StringId.FilterClauseNotBetween: return "Is Not Between";
                case StringId.FilterClauseNotLike: return "비슷하지 않음";
                case StringId.FilterGroupAnd: return "그리고";
                case StringId.FilterGroupOr: return "또는";
                case StringId.FilterMenuConditionAdd: return "조건 추가";


                //MessageBox 관련
                case StringId.XtraMessageBoxAbortButtonText: return "중단";
                case StringId.XtraMessageBoxCancelButtonText: return "취소";
                case StringId.XtraMessageBoxIgnoreButtonText: return "무시";
                case StringId.XtraMessageBoxNoButtonText: return "아니오";
                case StringId.XtraMessageBoxOkButtonText: return "확인";
                case StringId.XtraMessageBoxRetryButtonText: return "재시도";
                case StringId.XtraMessageBoxYesButtonText: return "예";

                //DateTime Edit 관련
                case StringId.DateEditToday: return "오늘";
                case StringId.DateEditClear: return "Clear";

                case StringId.PictureEditMenuCopy: return "복사";
                case StringId.PictureEditMenuCut: return "잘라내기";
                case StringId.PictureEditMenuDelete: return "삭제";
                case StringId.PictureEditMenuLoad: return "불러오기";
                case StringId.PictureEditMenuPaste: return "붙여넣기";
                case StringId.PictureEditMenuSave: return "저장";
                case StringId.PictureEditOpenFileTitle: return "Image 열기";
                case StringId.PictureEditSaveFileTitle: return "Image 저장";

                case StringId.TextEditMenuCopy: return "복사";
                case StringId.TextEditMenuCut: return "잘라내기";
                case StringId.TextEditMenuDelete: return "삭제";
                case StringId.TextEditMenuPaste: return "붙여넣기";
                case StringId.TextEditMenuSelectAll: return "전체선택";
                case StringId.TextEditMenuUndo: return "되돌리기";
                
                case StringId.NavigatorAppendButtonHint: return "추가";
                case StringId.NavigatorCancelEditButtonHint: return "취소";
                case StringId.NavigatorEditButtonHint: return "수정";
                case StringId.NavigatorEndEditButtonHint: return "수정완료";
                case StringId.NavigatorFirstButtonHint: return "처음";
                case StringId.NavigatorLastButtonHint: return "마지막";
                case StringId.NavigatorNextButtonHint: return "다음";
                case StringId.NavigatorNextPageButtonHint: return "다음 페이지";
                case StringId.NavigatorPreviousButtonHint: return "이전";
                case StringId.NavigatorPreviousPageButtonHint: return "이전 페이지";
                case StringId.NavigatorRemoveButtonHint: return "삭제";

            }
            return base.GetLocalizedString(id);
        }

        #endregion
    }
}
