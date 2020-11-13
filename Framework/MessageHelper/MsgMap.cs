using System;

namespace TLF.Framework.MessageHelper
{
    /// <summary>
    /// System에서 사용할 Message를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-19 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class MsgMap
    {
        #region :: Confirm :: 확인 후 진행 하는 관련 Message MAP

        /// <summary>
        /// 저장하시겠습니까?
        /// </summary>
        public const string CF_SAVE = "저장하시겠습니까?";
        
        /// <summary>
        /// 승인하시겠습니까?
        /// </summary>
        public const string CF_CONF = "승인하시겠습니까?";
        
        /// <summary>
        /// 등록하시겠습니까?
        /// </summary>
        public const string CF_REGIST = "등록하시겠습니까?";

        /// <summary>
        /// 출력하시겠습니까?
        /// </summary>
        public const string CF_PRINT = "출력하시겠습니까?";

        /// <summary>
        /// 삭제하시겠습니까?
        /// </summary>
        public const string CF_DELETE = "삭제하시겠습니까?";

        /// <summary>
        /// 처리하시겠습니까?
        /// </summary>
        public const string CF_PROCESS = "처리하시겠습니까?";

        /// <summary>
        /// 창을 닫으시겠습니까?
        /// </summary>
        public const string CF_CLOSE = "창을 닫으시겠습니까?";

        /// <summary>
        /// 종료하시겠습니까?
        /// </summary>
        public const string CF_EXIT = "종료하시겠습니까?";

        /// <summary>
        /// 파일을 저장하시겠습니까?
        /// </summary>
        public const string CF_FILE_SAVE = "파일을 저장하시겠습니까?";

        /// <summary>
        /// 확인 하시겠습니까?
        /// </summary>
        public const string CF_CONFIRM = "확인 하시겠습니까?";

        /// <summary>
        /// 취소 하시겠습니까?
        /// </summary>
        public const string CF_CONFIRM_CANCLE = "취소 하시겠습니까?";

        #endregion

        #region :: Check Validate :: Validate 관련 Message MAP

        /// <summary>
        /// (은)는 필수 입력 항목입니다.
        /// </summary>
        public const string CK_MUST = " (은)는 필수 입력 항목입니다.";
        
        /// <summary>
        /// 기본 KEY가 중복되었습니다
        /// </summary>
        public const string CK_DUPKEY = "기본 KEY가 중복되었습니다";

        /// <summary>
        /// 가(이) 없습니다.
        /// </summary>
        public const string CK_VALUE = " 가(이) 없습니다.";

        /// <summary>
        /// 을(를) 입력하십시오.
        /// </summary>
        public const string CK_PARAM = " 을(를) 입력하십시오.";

        /// <summary>
        /// 을(를) 선택하십시오.
        /// </summary>
        public const string CK_SELECT = " 을(를) 선택하십시오.";

        /// <summary>
        /// 중복된 데이타가 존재 합니다.
        /// </summary>
        public const string CK_CREATE = "중복된 데이타가 존재 합니다.";

        /// <summary>
        /// 이미 처리된 자료입니다.
        /// </summary>
        public const string CK_PROCESS = "이미 처리된 자료입니다.";

        #endregion

        #region :: Check Compare :: 비교 관련 Message MAP
        
        /// <summary>
        /// 필드와 값이 다릅니다.
        /// </summary>
        public const string CK_EQUAL = "필드와 값이 다릅니다.";

        /// <summary>
        /// 필드의 값보다 작거나 같은 값을 입력하였습니다.
        /// </summary>
        public const string CK_GREAT = "필드의 값보다 작거나 같은 값을 입력하였습니다.";

        /// <summary>
        /// 필드의 값보다 작은 값을 입력하였습니다.
        /// </summary>
        public const string CK_GREATTHEN = "필드의 값보다 작은 값을 입력하였습니다.";

        /// <summary>
        /// 필드의 값보다 크거나 같은 값을 입력하였습니다.
        /// </summary>
        public const string CK_LESS = "필드의 값보다 크거나 같은 값을 입력하였습니다.";

        /// <summary>
        /// 필드의 값보다 큰 값을 입력하였습니다.
        /// </summary>
        public const string CK_LESSTHEN = "필드의 값보다 큰 값을 입력하였습니다.";

        /// <summary>
        /// 필드와 값이 동일합니다.
        /// </summary>
        public const string CK_NOTEQUAL = "필드와 값이 같지 않습니다.";

        #endregion

        #region :: Error :: Error 관련 Message MAP

        /// <summary>
        /// 등록 중 Error 가 발생했습니다.	
        /// </summary>
        public const string ER_REGIST = "등록 중 Error 가 발생했습니다.";

        /// <summary>
        /// 로드 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_LOAD = "로드 중 Error 가 발생했습니다.";

        /// <summary>
        /// 조회 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_SELECT = "조회 중 Error 가 발생했습니다.";

        /// <summary>
        /// 저장 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_SAVE = "저장 중 Error 가 발생했습니다.";

        /// <summary>
        /// 승인 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_CONF = "승인 중 Error 가 발생했습니다.";

        /// <summary>
        /// 삭제 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_DELETE = "삭제 중 Error 가 발생했습니다.";

        /// <summary>
        /// 취소 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_CANCEL = "취소 중 Error 가 발생했습니다.";

        /// <summary>
        /// 처리 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_PROCESS = "처리 중 Error 가 발생했습니다.";

        /// <summary>
        /// Report 중 Error 가 발생했습니다.
        /// </summary>
        public const string ER_REPORT = "Report 중 Error 가 발생했습니다.";

        #endregion

        #region :: Process :: Process 관련 Message MAP

        /// <summary>
        /// 를(을) 먼저 진행하십시오.
        /// </summary>
        public const string FT_PROCESS = " 를(을) 먼저 진행하십시오.";

        /// <summary>
        /// 이(가) 존재하지 않습니다.
        /// </summary>
        public const string NO_EXIST = " 이(가) 존재하지 않습니다.";

        /// <summary>
        /// 요청하신 작업을 처리중입니다...
        /// </summary>
        public const string PC_ING = "요청하신 작업을 처리중입니다...";

        #endregion

        #region :: No Data :: Data 관련 Message MAP

        /// <summary>
        /// 조회된 데이터가 없습니다.
        /// </summary>
        public const string NO_SELECT_DATA = "조회된 데이터가 없습니다.";

        /// <summary>
        /// 저장할 자료가 없습니다.
        /// </summary>
        public const string NO_SAVE_DATA = "저장할 자료가 없습니다.";

        /// <summary>
        /// 승인할 자료가 없습니다.
        /// </summary>
        public const string NO_CONF_DATA = "승인할 자료가 없습니다.";

        /// <summary>
        /// 삭제할 자료가 없습니다.
        /// </summary>
        public const string NO_DELETE_DATA = "삭제할 자료가 없습니다.";

        /// <summary>
        /// 변경된 자료가 없습니다.
        /// </summary>
        public const string NO_CHG_DATA = "변경된 자료가 없습니다.";

        /// <summary>
        /// 처리할 데이타가 없습니다.
        /// </summary>
        public const string NO_PROCESS_DATA = "처리할 데이타가 없습니다.";

        /// <summary>
        /// 엑셀로 변환할 자료가 없습니다.
        /// </summary>
        public const string NO_EXCEL_DATA = "엑셀로 변환할 자료가 없습니다.";

        /// <summary>
        /// 엑셀파일이 없습니다.
        /// </summary>
        public const string NO_EXCEL_FILE = "엑셀파일이 없습니다.";

        /// <summary>
        /// 출력할 자료가 없습니다.
        /// </summary>
        public const string NO_PRINT_DATA = "출력할 자료가 없습니다.";

        /// <summary>
        /// 권한이 없습니다.
        /// </summary>
        public const string NO_AUTH = "권한이 없습니다.";

        /// <summary>
        /// 환경설정이 없습니다.
        /// </summary>
        public const string NO_CONFIG = "환경설정이 없습니다.";

        #endregion

        #region :: Operation :: Operation 관련 Message MAP
        
        /// <summary>
        /// 정상으로 로드되었습니다.
        /// </summary>
        public const string OK_LOAD = "정상으로 로드되었습니다.";

        /// <summary>
        /// 정상으로 조회되었습니다.
        /// </summary>
        public const string OK_SELECT = "정상으로 조회되었습니다.";

        /// <summary>
        /// 정상으로 저장되었습니다.
        /// </summary>
        public const string OK_SAVE = "정상으로 저장되었습니다.";

        /// <summary>
        /// 정상으로 승인되었습니다.
        /// </summary>
        public const string OK_CONF = "정상으로 승인되었습니다.";

        /// <summary>
        /// 정상으로 삭제되었습니다.
        /// </summary>
        public const string OK_DELETE = "정상으로 삭제되었습니다.";

        /// <summary>
        /// 정상으로 처리되었습니다.
        /// </summary>
        public const string OK_PROCESS = "정상으로 처리되었습니다.";

        #endregion

        #region :: Check Query :: 조회 Query 관련 Message MAP

        /// <summary>
        /// 조회 후 저장하십시오.
        /// </summary>
        public const string QF_SAVE = "조회 후 저장하십시오.";

        /// <summary>
        /// 조회 후 승인하십시오.
        /// </summary>
        public const string QF_CONF = "조회 후 승인하십시오.";

        /// <summary>
        /// 조회 후 삭제하십시오.
        /// </summary>
        public const string QF_DELETE = "조회 후 삭제하십시오.";

        #endregion


        #region :: Information :: 정보 관련 Message MAP

        /// <summary>
        /// 개발 중인 기능입니다.
        /// </summary>
        public const string IF_DEV_ING = "개발 중인 기능입니다.";

        #endregion


        #region :: Excel :: Excel Export 관련 Message MAP

        /// <summary>
        /// EXCEL 변환 성공하였습니다.
        /// </summary>
        public const string OK_EXCEL = "EXCEL 변환 성공하였습니다.";

        /// <summary>
        /// EXCEL 업로드 성공하였습니다.
        /// </summary>
        public const string OK_EXCEL_UPLOAD = "EXCEL 업로드 성공하였습니다.";

        /// <summary>
        /// EXCEL 업로드 실패하였습니다.
        /// </summary>
        public const string ER_EXCEL_UPLOAD = "EXCEL 업로드 실패하였습니다.";

        /// <summary>
        /// EXCEL 다운로드 성공하였습니다.
        /// </summary>
        public const string OK_EXCEL_DOWNLOAD = "EXCEL 다운로드 성공하였습니다.";

        /// <summary>
        /// EXCEL 다운로드 실패하였습니다.
        /// </summary>
        public const string ER_EXCEL_DOWNLOAD = "EXCEL 다운로드 실패하였습니다.";

        /// <summary>
        /// Excel Export 작업이 성공하였습니다.
        /// </summary>
        public const string OK_EXCEL_EXPORT = "Excel Export 작업이 성공하였습니다.";

        #endregion

        #region :: Word :: Word Export 관련 Message MAP

        /// <summary>
        /// WORD 변환 성공하였습니다.
        /// </summary>
        public const string OK_WORD = "WORD 변환 성공하였습니다.";

        /// <summary>
        /// WORD 업로드 성공하였습니다.
        /// </summary>
        public const string OK_WORD_UPLOAD = "WORD 업로드 성공하였습니다.";

        /// <summary>
        /// WORD 업로드 실패하였습니다.
        /// </summary>
        public const string ER_WORD_UPLOAD = "WORD 업로드 실패하였습니다.";

        /// <summary>
        /// WORD 다운로드 성공하였습니다.
        /// </summary>
        public const string OK_WORD_DOWNLOAD = "WORD 다운로드 성공하였습니다.";

        /// <summary>
        /// WORD 다운로드 실패하였습니다.
        /// </summary>
        public const string ER_WORD_DOWNLOAD = "WORD 다운로드 실패하였습니다.";

        #endregion


        #region :: Report :: Report 관련 Message MAP

        /// <summary>
        /// 리포트 출력 성공하였습니다.
        /// </summary>
        public const string OK_REPORT_LOAD = "리포트 출력 성공하였습니다.";

        /// <summary>
        /// 리포트 출력 실패하였습니다.
        /// </summary>
        public const string ER_REPORT_LOAD = "리포트 출력 실패하였습니다.";

        #endregion

        #region :: Chart :: Chart 관련 Message MAP

        /// <summary>
        /// 차트 출력 성공하였습니다.
        /// </summary>
        public const string OK_CHART_LOAD = "차트 출력 성공하였습니다.";

        /// <summary>
        /// 차트 출력 실패하였습니다.
        /// </summary>
        public const string ER_CHART_LOAD = "차트 출력 실패하였습니다.";

        #endregion


        #region :: Help Message :: 도움말 관련 Message MAP
        
        /// <summary>
        /// 도움말 LOAD가 성공하였습니다.
        /// </summary>
        public const string OK_HELP_LOAD = "도움말 LOAD가 성공하였습니다.";

        /// <summary>
        /// 도움말 LOAD가 실패하였습니다.
        /// </summary>
        public const string ER_HELP_LOAD = "도움말 LOAD가 실패하였습니다.";

        #endregion

        #region :: File :: File 관련 Message MAP

        /// <summary>
        /// 파일 사이즈가 초과되었습니다.
        /// </summary>
        public const string CK_FILE_SIZE = "파일 사이즈가 초과되었습니다.";

        /// <summary>
        /// 파일형식이 옳지 않습니다.
        /// </summary>
        public const string CK_FILE_FORMAT = "파일형식이 옳지 않습니다.";

        /// <summary>
        /// 파일 업로드가 성공하였습니다.
        /// </summary>
        public const string OK_FILE_UPLOAD = "파일 업로드가 성공하였습니다.";

        /// <summary>
        /// 파일 업로드가 실패하였습니다.
        /// </summary>
        public const string ER_FILE_UPLOAD = "파일 업로드가 실패하였습니다.";

        /// <summary>
        /// 파일 다운로드가 성공하였습니다.
        /// </summary>
        public const string OK_FILE_DOWNLOAD = "파일 다운로드가 성공하였습니다.";

        /// <summary>
        /// 파일 다운로드가 실패하였습니다.
        /// </summary>
        public const string ER_FILE_DOWNLOAD = "파일 다운로드가 실패하였습니다.";

        /// <summary>
        /// 이미 첨부된 파일입니다.
        /// </summary>
        public const string CK_FILE_OVERLAP = "이미 첨부된 파일입니다.";

        /// <summary>
        /// 첨부파일 수가 초과하였습니다.
        /// </summary>
        public const string CK_FILE_COUNT = "첨부파일 수가 초과하였습니다.";

        #endregion

        #region :: Check Modify :: 수정사항 Check 관련 Message MAP
        
        /// <summary>
        /// 저장되지 않은 데이터가 존재합니다. 계속하시겠습니까?
        /// </summary>
        public const string CK_DATA_MODIFY_CONTINUE = "저장되지 않은 데이터가 존재합니다. 계속하시겠습니까?";

        /// <summary>
        /// 변경된 데이타가 존재합니다. 변경 데이터 저장 후 Data가 재조회됩니다. 저장하시겠습니까?
        /// </summary>
        public const string CK_DATA_MODIFY_UPDATE = "변경된 데이타가 존재합니다. 변경 데이터 저장 후 Data가 재조회됩니다. 저장하시겠습니까?";

        /// <summary>
        /// 저장되지 않은 데이터가 존재합니다. 창을 닫으시겠습니까?
        /// </summary>
        public const string CK_DATA_MODIFY_CLOSE = "저장되지 않은 데이터가 존재합니다. 창을 닫으시겠습니까?";

        #endregion

        #region :: Print :: 인쇄 관련 Message MAP
        
        /// <summary>
        /// 프린트 출력에 성공하였습니다.
        /// </summary>
        public const string OK_PRINT = "프린트 출력에 성공하였습니다.";

        /// <summary>
        /// 프린트 출력에 실패하였습니다.
        /// </summary>
        public const string ER_PRINT = "프린트 출력에 실패하였습니다.";

        #endregion

        #region :: Keyboard :: Keyboard 관련 Message MAP
        
        /// <summary>
        /// 【Caps Lock】이 켜져 있는지 확인하십시요. 대소문자를 구별합니다.
        /// </summary>
        public const string CK_CAPS_LOCK = "【Caps Lock】이 켜져 있는지 확인하십시요. 대소문자를 구별합니다.";

        #endregion
    }
}
