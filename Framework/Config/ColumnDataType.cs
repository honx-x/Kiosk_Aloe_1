
namespace TLF.Framework.Config
{
    #region :: ColumnDataType :: GridView의 컬럼 Data Type

    /// <summary>
    /// GridView의 Column Data Type을 정의합니다.
    /// </summary>
    public enum ColumnDataType
    {
        /// <summary>
        /// 기본(String) 형식
        /// </summary>
        Default,
        /// <summary>
        /// Check 형식
        /// </summary>
        CheckEdit,
        /// <summary>
        /// CheckedComboBoxEdit 형식
        /// </summary>
        CheckedComboBox,
        /// <summary>
        /// ComboBoxEdit 형식
        /// </summary>
        ComboBox,
        /// <summary>
        /// 날짜형식 yyyy-MM-dd
        /// </summary>
        Date,
        /// <summary>
        /// 날짜형식 yyyy-MM-dd HH:mm:ss
        /// </summary>
        DateTime,
		/// <summary>
		/// 시간형식 HH:mm:ss
		/// </summary>
		Time,
		/// <summary>
		/// 시간형식 HH:mm
		/// </summary>
		Minute,
		/// <summary>
        /// 숫자형식 소수점 가능
        /// </summary>
        Numeric,
        /// <summary>
        /// 10진수 형식 소수점 불가
        /// </summary>
        Decimal,
        /// <summary>
        /// 통화 형식
        /// </summary>
        Currency,
        /// <summary>
        /// 퍼센트 형식
        /// </summary>
        Percentage,
        /// <summary>
        /// 팝업 컨트롤 형식
        /// </summary>
        Popup,
        /// <summary>
        /// ButtonEdit 형식
        /// </summary>
        Button,
        /// <summary>
        /// LinkButtonEdit 형식
        /// </summary>
        LinkButton,
        /// <summary>
        /// Color 선택 형식
        /// </summary>
        ColorSelect,
        /// <summary>
        /// 그림 형식
        /// </summary>
        Image,
        /// <summary>
        /// 그림형식(미리보기)
        /// </summary>
        Picture,
        /// <summary>
        /// ImageComboEdit 형식
        /// </summary>
        ImageCombo,
        /// <summary>
        /// 파일 경로 형식(FileOpenDialog 사용)
        /// </summary>
        File,
        /// <summary>
        /// Text 형식(Memo Edit 사용)
        /// </summary>
        Text,
        /// <summary>
        /// 비밀번호 형식(******)
        /// </summary>
		Password,
		/// <summary>
		/// ProgessBar 형태
		/// </summary>
		Progress,
		/// <summary>
		/// MemoEdit 형태
		/// </summary>
		MemoEdit
    }

    #endregion
}
