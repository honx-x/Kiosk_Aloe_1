
namespace TLF.Framework.Localization
{
    /// <summary>
    /// 다국어코드와 Mapping 될 Enum Class 입니다.
    /// </summary>
    public enum StrId
    {
        /// <summary>
        /// 없음
        /// </summary>
        None = 0,
        /// <summary>
        /// 로트 번호
        /// </summary>
        LotNumber = 1,
        /// <summary>
        /// 제품타입
        /// </summary>
        ProductType = 2,
        /// <summary>
        /// 필름번호
        /// </summary>
        FilmNumber = 3,
        /// <summary>
        /// 관리번호
        /// </summary>
        ManagementCode = 4,
        /// <summary>
        /// 공정
        /// </summary>
        Process = 5,
        /// <summary>
        /// 라인
        /// </summary>
        Line = 7,
        /// <summary>
        /// 거래선
        /// </summary>
        Customer = 8,
        /// <summary>
        /// 제품군
        /// </summary>
        ProductGroup = 11,
        /// <summary>
        /// 현공정
        /// </summary>
        CurrentProcess = 12,
        /// <summary>
        /// 로트 수량
        /// </summary>
        LotCount = 13,
        /// <summary>
        /// 도착예정시간
        /// </summary>
        PrearrangedTime = 18,
        /// <summary>
        /// 수주구분
        /// </summary>
        SalesOrder = 19,
        /// <summary>
        /// 사업장
        /// </summary>
        Plant = 31,
        /// <summary>
        /// 업체
        /// </summary>
        Vendor = 32,

        /// <summary>
        /// 컴퓨터
        /// </summary>
        Computer = 300001,
        /// <summary>
        /// 조회
        /// </summary>
        InquiryCondition = 300002,
        /// <summary>
        /// 컴퓨터 이름
        /// </summary>
        ComputerName = 300003,
        /// <summary>
        /// 컴퓨터 설명
        /// </summary>
        ComputerExplanation = 300004,
        /// <summary>
        /// 설비그룹
        /// </summary>
        StationGroup = 300005,
        /// <summary>
        /// 사용유무
        /// </summary>
        UseYN = 300006,
        /// <summary>
        /// 게더링컴퓨터
        /// </summary>
        GatheringComputer = 300007, 

        /// <summary>
        /// 치공구번호
        /// </summary>
        JigNumber = 400001,
        /// <summary>
        /// 치공구종류
        /// </summary>
        JigType = 400002,
        /// <summary>
        /// 작업면
        /// </summary>
        JigFace = 400003,
        /// <summary>
        /// 공유번호
        /// </summary>
        PublicCode = 400004,
        /// <summary>
        /// 스펙유무
        /// </summary>
        HasSpec = 400005,
        /// <summary>
        /// 전기검사유무
        /// </summary>
        CheckerType = 400006,
        /// <summary>
        /// 현재상태
        /// </summary>
        CurrentStatus = 400007,
        /// <summary>
        /// 전체사양조회
        /// </summary>
        AllSpecInquiry = 400008,
        /// <summary>
        /// 치공구제작(검사) 우선순위 설정
        /// </summary>
        Changethemakeorderofpriority = 400009,
        /// <summary>
        /// 우선순위
        /// </summary>
        Orderofpriority = 400010,
        /// <summary>
        /// 필름위치정보
        /// </summary>
        FilmLocation = 400011,
        /// <summary>
        /// 재공매수
        /// </summary>
        RunningSheet = 400012,
        /// <summary>
        /// 신청적요코드
        /// </summary>
        RequestCode = 400013,
        /// <summary>
        /// 최소회로폭
        /// </summary>
        MinSpace = 400014,
        /// <summary>
        /// 최종폐기이력
        /// </summary>
        LastDisuseNote = 400015,
        /// <summary>
        /// 치공구
        /// </summary>
        JIG = 400016,
        /// <summary>
        /// 제작(검사)공정구분
        /// </summary>
        MakeInspectProcessSection = 400017,
        /// <summary>
        /// 제작(검사)공정
        /// </summary>
        MakeInspectProcess = 400018,
        /// <summary>
        /// 이전위치
        /// </summary>
        PrevLocation = 400019,
        /// <summary>
        /// 샘플구분
        /// </summary>
        SampleFlag = 400020,
        /// <summary>
        /// 단독분리
        /// </summary>
        SelfSeparation = 400021,
        /// <summary>
        /// 그룹분리
        /// </summary>
        GroupSeparation = 400022,
        /// <summary>
        /// SOLD(BACK) 동일적용
        /// </summary>
        SOLDBACKSameApply = 400023,
        /// <summary>
        /// 대표공정코드
        /// </summary>
        ProcessClass = 400024,
        /// <summary>
        /// 대표제작공정
        /// </summary>
        MakeProcessClass = 400025,
        /// <summary>
        /// 제작공정
        /// </summary>
        MakeProcess = 400026,
        /// <summary>
        /// 제작공정명
        /// </summary>
        MakeProcessName = 400027,
        /// <summary>
        /// 제작Routing코드
        /// </summary>
        MakeRoutingCode = 400028,
        /// <summary>
        /// 제작Routing명
        /// </summary>
        MakeRoutingName = 400029,
        /// <summary>
        /// 사용율
        /// </summary>
        UseRate = 400030,
        /// <summary>
        /// 부모관리번호
        /// </summary>
        ParentFilmNumber = 400031,
        /// <summary>
        /// [ {0} ] 면으로 복사
        /// </summary>
        CopyJigFace = 400032,
        /// <summary>
        /// 의뢰취소로 인한 치공구 폐기
        /// </summary>
        JigDisuseCausedByRequestCancellation = 400033,
        /// <summary>
        /// 불출이동
        /// </summary>
        MoveInOut = 400034,
        /// <summary>
        /// 요청랙 일괄 지정
        /// </summary>
        RequestRackBatchSelection = 400035,
        /// <summary>
        /// 최대 사용수량 Over (조회 속도가 느려질 수 있습니다.)
        /// </summary>
        MaximumUseCountOver = 400036,
        /// <summary>
        /// 제작(검사)
        /// </summary>
        MakeInspect = 400037,
        /// <summary>
        /// 검사장비 없음
        /// </summary>
        NoInspectEquipment = 400038,
        /// <summary>
        /// 잔여공정수
        /// </summary>
        RemainProcessCount = 400039,
        /// <summary>
        /// 시작
        /// </summary>
        Begin = 700001,
        /// <summary>
        /// 완료
        /// </summary>
        End = 700002,
        /// <summary>
        /// 작업자
        /// </summary>
        Worker = 700003,
        /// <summary>
        /// 시간
        /// </summary>
        Time = 700004,
        /// <summary>
        /// 수량
        /// </summary>
        Count = 700005,
        /// <summary>
        /// 구분
        /// </summary>
        Flag = 700006,
        /// <summary>
        /// 검사
        /// </summary>
        Inspect = 700007,
        /// <summary>
        /// 설비
        /// </summary>
        Station = 700008,
        /// <summary>
        /// 제작
        /// </summary>
        Make = 700009,
        /// <summary>
        /// 순서
        /// </summary>
        Seq = 700010,
        /// <summary>
        /// 작업
        /// </summary>
        Work = 700011,
        /// <summary>
        /// 번호
        /// </summary>
        Number = 700012,
        /// <summary>
        /// 보유
        /// </summary>
        Possess = 700013,
        /// <summary>
        /// 총
        /// </summary>
        Total = 700014,
        /// <summary>
        /// 단위
        /// </summary>
        Unit = 700015,
        /// <summary>
        /// 공차
        /// </summary>
        Tolerance = 700016,
        /// <summary>
        /// 비고
        /// </summary>
        Note = 700017,
        /// <summary>
        /// 재작업
        /// </summary>
        Rework = 700018,
        /// <summary>
        /// 면적
        /// </summary>
        Area = 700019,
        /// <summary>
        /// 사양
        /// </summary>
        Spec = 700020,
        /// <summary>
        /// 유
        /// </summary>
        Y = 700021,
        /// <summary>
        /// 무
        /// </summary>
        N = 700022,
        /// <summary>
        /// 값
        /// </summary>
        Value = 700023,
        /// <summary>
        /// 기준
        /// </summary>
        Base = 700024,
        /// <summary>
        /// 사용
        /// </summary>
        Use = 700025,
        /// <summary>
        /// 상태
        /// </summary>
        Status = 700026,
        /// <summary>
        /// 요청
        /// </summary>
        Request = 700027,
        /// <summary>
        /// 입고
        /// </summary>
        Stock = 700028,
        /// <summary>
        /// 변경
        /// </summary>
        Change = 700029,
        /// <summary>
        /// 위치
        /// </summary>
        Location = 700030,
        /// <summary>
        /// 랙
        /// </summary>
        Rack = 700031,
        /// <summary>
        /// 조회
        /// </summary>
        Inquiry = 700032,
        /// <summary>
        /// 일자
        /// </summary>
        Date = 700033,
        /// <summary>
        /// 구분
        /// </summary>
        Section = 700034,
        /// <summary>
        /// 코드
        /// </summary>
        Code = 700035,
        /// <summary>
        /// 매수
        /// </summary>
        Sheet = 700036,
        /// <summary>
        /// 재공
        /// </summary>
        WIP = 700037,
        /// <summary>
        /// 제품명
        /// </summary>
        ProductName = 700038,
        /// <summary>
        /// 조건
        /// </summary>
        Option = 700039,
        /// <summary>
        /// 일시
        /// </summary>
        Datetime = 700040,
        /// <summary>
        /// 사용율
        /// </summary>
        MPU = 700041,
        /// <summary>
        /// 선택
        /// </summary>
        Select = 700042,
        /// <summary>
        /// 인쇄
        /// </summary>
        Print = 700043,
        /// <summary>
        /// 폐기
        /// </summary>
        Disuse = 700044,
        /// <summary>
        /// 중지
        /// </summary>
        Stop = 700045,
        /// <summary>
        /// 취소
        /// </summary>
        Cancel = 700046,
        /// <summary>
        /// 특이사항
        /// </summary>
        Peculiar = 700047,
        /// <summary>
        /// 등록
        /// </summary>
        Register = 700048,
        /// <summary>
        /// 바코드
        /// </summary>
        Barcode = 700049,
        /// <summary>
        /// 해제
        /// </summary>
        Cancellation = 700050,
        /// <summary>
        /// 완료
        /// </summary>
        Completion = 700051,
        /// <summary>
        /// 수정
        /// </summary>
        Modification = 700052,
        /// <summary>
        /// 정보
        /// </summary>
        Information = 700053,
        /// <summary>
        /// 상세
        /// </summary>
        Detail = 700054,
        /// <summary>
        /// 기타
        /// </summary>
        Etc = 700055,
        /// <summary>
        /// 항목
        /// </summary>
        Item = 700056,
        /// <summary>
        /// 측정
        /// </summary>
        Measurement = 700057,
        /// <summary>
        /// 결과
        /// </summary>
        Result = 700058,
        /// <summary>
        /// 반출
        /// </summary>
        CarryOut = 700059,
        /// <summary>
        /// 반입
        /// </summary>
        CarryIn = 700060,
        /// <summary>
        /// 이력
        /// </summary>
        History = 700061,
        /// <summary>
        /// 이동
        /// </summary>
        Move = 700062,
        /// <summary>
        /// 불출
        /// </summary>
        InOut = 700063,
        /// <summary>
        /// 수리
        /// </summary>
        Repair = 700064,
        /// <summary>
        /// 새로고침
        /// </summary>
        Refresh = 700065,
        /// <summary>
        /// 플로팅
        /// </summary>
        Floating = 700066,
        /// <summary>
        /// 신규
        /// </summary>
        New = 700067,
        /// <summary>
        /// 저장
        /// </summary>
        Save = 700068,
        /// <summary>
        /// 삭제
        /// </summary>
        Delete = 700069,
        /// <summary>
        /// 화면캡쳐
        /// </summary>
        CaptureScreen = 700070,
        /// <summary>
        /// 닫기
        /// </summary>
        Close = 700071,
        /// <summary>
        /// 종료
        /// </summary>
        Exit = 700072,
        /// <summary>
        /// 사용자 Sign On
        /// </summary>
        UserSignOn = 700073,
        /// <summary>
        /// 동기화
        /// </summary>
        Synchronize = 700074,
        /// <summary>
        /// 사용자 전환
        /// </summary>
        ChangeUser = 700075,
        /// <summary>
        /// 추가
        /// </summary>
        Add = 700076,
        /// <summary>
        /// 연결
        /// </summary>
        Link = 700077,
        /// <summary>
        /// 검색
        /// </summary>
        Search = 700078,
        /// <summary>
        /// 등록자
        /// </summary>
        Recorder = 700079,
        /// <summary>
        /// 지정
        /// </summary>
        Appointment = 700080,
        /// <summary>
        /// 일괄
        /// </summary>
        Batch = 700081,
        /// <summary>
        /// 입력
        /// </summary>
        Input = 700082,
        /// <summary>
        /// 데이터
        /// </summary>
        Data = 700083,
        /// <summary>
        /// 형식
        /// </summary>
        Type = 700084,
        /// <summary>
        /// 자리수
        /// </summary>
        Cipher = 700085,
        /// <summary>
        /// 소수점
        /// </summary>
        DecimalPoint = 700086,
        /// <summary>
        /// Routing
        /// </summary>
        Routing = 700087,
        /// <summary>
        /// 명
        /// </summary>
        Name = 700088,
        /// <summary>
        /// 반복
        /// </summary>
        Repeat = 700089,
        /// <summary>
        /// 실적
        /// </summary>
        ActualResult = 700090,
        /// <summary>
        /// 그룹
        /// </summary>
        Group = 700091,
        /// <summary>
        /// 시스템코드
        /// </summary>
        SystemCode = 700092,
        /// <summary>
        /// 대분류
        /// </summary>
        LargeCategory = 700093,
        /// <summary>
        /// 중분류
        /// </summary>
        MediumCategory = 700094,
        /// <summary>
        /// 소분류
        /// </summary>
        SmallCategory = 700095,
        /// <summary>
        /// 분류
        /// </summary>
        Category = 700096,
        /// <summary>
        /// 관리
        /// </summary>
        Management = 700097,
        /// <summary>
        /// 사용자
        /// </summary>
        User = 700098,
        /// <summary>
        /// 층
        /// </summary>
        Layer = 700099,
        /// <summary>
        /// 최소
        /// </summary>
        Min = 700100,
        /// <summary>
        /// 최대
        /// </summary>
        Max = 700101,
        /// <summary>
        /// 잉크
        /// </summary>
        Ink = 700102,
        /// <summary>
        /// 두께
        /// </summary>
        Thickness = 700103,
        /// <summary>
        /// 최종
        /// </summary>
        Final = 700104,
        /// <summary>
        /// 보기
        /// </summary>
        view = 700105,
        /// <summary>
        /// 사유
        /// </summary>
        Cause = 700106,
        /// <summary>
        /// 확인
        /// </summary>
        Confirm = 700107,
        /// <summary>
        /// 필름
        /// </summary>
        Film = 700108,
        /// <summary>
        /// 공유
        /// </summary>
        Public = 700109,
        /// <summary>
        /// 내층
        /// </summary>
        InnerLayer = 700110,
        /// <summary>
        /// 외층
        /// </summary>
        OuterLayer = 700111,
        /// <summary>
        /// 권한
        /// </summary>
        Authority = 700112,
        /// <summary>
        /// 전체
        /// </summary>
        All = 700113,
        /// <summary>
        /// 전체선택
        /// </summary>
        SelectAll = 700114,
        /// <summary>
        /// 칸
        /// </summary>
        Position = 700115,
        /// <summary>
        /// 내용
        /// </summary>
        Contents = 700116,
        /// <summary>
        /// 차트
        /// </summary>
        Chart = 800001,
        /// <summary>
        /// 일
        /// </summary>
        Day = 800002,
        /// <summary>
        /// 월
        /// </summary>
        Month = 800003,
        /// <summary>
        /// 목록(리스트)
        /// </summary>
        List = 800004,
        /// <summary>
        /// 체크
        /// </summary>
        Check = 800005,
        /// <summary>
        /// 청화금
        /// </summary>
        Au = 800006,
        /// <summary>
        /// 결제
        /// </summary>
        Settlement = 800007,
        /// <summary>
        /// 무게
        /// </summary>
        Weight = 800008,
        /// <summary>
        /// 전
        /// </summary>
        Before = 800009,
        /// <summary>
        /// 가동
        /// </summary>
        Operation = 800010,
        /// <summary>
        /// 공통
        /// </summary>
        Common = 800011,
        /// <summary>
        /// 회수
        /// </summary>
        Recovery = 800012,
        /// <summary>
        /// 이온
        /// </summary>
        Ion = 800013,
        /// <summary>
        /// 수지
        /// </summary>
        Resin = 800014,
        /// <summary>
        /// 최초(처음)
        /// </summary>
        First = 800015,
        /// <summary>
        /// 최후(마지막)
        /// </summary>
        Last = 800016,
        /// <summary>
        /// 분석
        /// </summary>
        Analysises = 800017,
        /// <summary>
        /// 도구
        /// </summary>
        Tool = 800018,
        /// <summary>
        /// 큐브
        /// </summary>
        Cube = 800019,
        /// <summary>
        /// 총합
        /// </summary>
        Sum = 800020,
        /// <summary>
        /// 파트
        /// </summary>
        Part = 800021,
        /// <summary>
        /// 년
        /// </summary>
        Year = 800022,
        /// <summary>
        /// 복사
        /// </summary>
        Copy = 800023,
        /// <summary>
        /// 라인별 회수방법별 회수율 경향
        /// </summary>
        Recoverypercentagetendencybywithdrawalmethodbyline = 900002,
        /// <summary>
        /// 회수방법별 총계
        /// </summary>
        Totalbywithdrawalmethod = 900003
    }
}
