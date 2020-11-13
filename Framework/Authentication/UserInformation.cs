using System;
using System.Data;
using System.Net;

namespace TLF.Framework.Authentication
{
    /// <summary>
    /// 사용자 정보를 저장하고 있는 Class 입니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-22 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
	public class UserInformation
	{
		///////////////////////////////////////////////////////////////////////////////////////////////
		// Constructor & Global Instance
		///////////////////////////////////////////////////////////////////////////////////////////////

		#region :: 생성자 ::

		/// <summary>
		/// User Inforatmion을 생성합니다.
		/// </summary>
		public UserInformation()
		{
			_isAdmin = true;

			_userID = "SYSTEM";
			_userName = "개발자";

			_employeeNum = "SYSTEM";
			_employeeName = "개발자";

			_departmentCode = "SYSTEM";
			_departmentName = "개발부";

			_phoneNum = "";
			_officephoneNum = "";
			_cellphoneNum = "";

			_eMail = "";
			_culture = "ko-KR";

            _CompSeq = 1;


            Array.ForEach(Dns.GetHostAddresses(Dns.GetHostName()), ipAddress =>
			{
				if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					_ip = ipAddress.ToString();
			});
		}

		/// <summary>
		/// User Inforatmion을 생성합니다.
		/// </summary>
		/// <param name="dr"></param>
		public UserInformation(DataRow dr)
		{
            _isAdmin = dr["AdminFlag"].ToString() == "True" ? true : false;

            //_userNum = dr["member_num"].ToString().Trim();
			_userID = dr["UserId"].ToString().Trim();
			_userName = dr["UserName"].ToString().Trim();
			_pwd = dr["PWD"].ToString().Trim();

            //_employeeNum = "junhyeok";
            //_employeeName = "Hwang JunHyeok";

            _departmentCode = dr["DepartmentCode"].ToString().Trim();
            _departmentName = dr["DepartmentName"].ToString().Trim();

            _phoneNum = dr["Phone"].ToString().Trim();
            _officephoneNum = dr["OfficePhone"].ToString().Trim();
            _cellphoneNum = dr["CellPhone"].ToString().Trim();

            _Outsea = dr["Outsea"].ToString().Trim();

            _eMail = dr["EMailAddress"].ToString().Trim();

            Array.ForEach(Dns.GetHostAddresses(Dns.GetHostName()), ipAddress =>
			{
				if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
					_ip = ipAddress.ToString();
			});
		}

		#endregion

		#region :: 전역변수 ::

		private readonly bool _isAdmin = false;
		private int _signInSeq = 0;

        private readonly string _userNum = string.Empty;
		private readonly string _userID = string.Empty;
        private readonly string _userName = string.Empty;

        private string _pwd = string.Empty;

		private readonly string _employeeNum = string.Empty;
		private readonly string _employeeName = string.Empty;

		private readonly string _departmentCode = string.Empty;
		private readonly string _departmentName = string.Empty;

		private string _Outsea = string.Empty;

		private readonly string _phoneNum = string.Empty;
		private readonly string _officephoneNum = string.Empty;
		private readonly string _cellphoneNum = string.Empty;

		private readonly string _eMail = string.Empty;

		private string _ip = string.Empty;
		private string _culture = string.Empty;

		private readonly string[] _processAuth = null;
		private string _restrictions = string.Empty;

        private int _CompSeq = 0;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region : Readonly Properties :

        /// <summary>
        /// Admin 권한 여부
        /// </summary>
        public bool IsAdmin { get { return _isAdmin; } }

		/// <summary>
		/// Login Seq
		/// </summary>
		public int SignInSeq
		{
			get { return _signInSeq; }
			set { _signInSeq = value; }
		}

        /// <summary>
        /// 사용자 사번
        /// </summary>
        public string UserNum { get { return _userNum; } }

		/// <summary>
		/// 사용자 ID
		/// </summary>
		public string UserID { get { return _userID; } }

        /// <summary>
        /// 사용자 명
        /// </summary>
        public string UserName { get { return _userName; } }
        
        /// <summary>
        /// 비밀번호
        /// </summary>
        public string Pwd
		{
			get { return _pwd; }
			set { _pwd = value; }
		}

		/// <summary>
		/// 사번
		/// </summary>
		public string EmployeeNum { get { return _employeeNum; } }

		/// <summary>
		/// 사원명
		/// </summary>
		public string EmployeeName { get { return _employeeName; } }

		/// <summary>
		/// 부서코드
		/// </summary>
		public string DepartmentCode { get { return _departmentCode; } }

		/// <summary>
		/// 부서명
		/// </summary>
		public string DepartmentName { get { return _departmentName; } }
        
		/// <summary>
		/// 해외 구분
		/// </summary>
		public string Outsea
		{
			get { return _Outsea; }
		}

		/// <summary>
		/// 사용 언어
		/// </summary>
		//public string Culture
		//{
		//	get { return _culture; }
		//	set { _culture = value; }
		//}

		/// <summary>
		/// 기본 전화번호
		/// </summary>
		public string PhoneNum { get { return _phoneNum; } }

		/// <summary>
		/// 사내 전화번호
		/// </summary>
		public string OfficephoneNum { get { return _officephoneNum; } }

		/// <summary>
		/// 휴대폰 전화번호
		/// </summary>
		public string CellphoneNum { get { return _cellphoneNum; } }

		/// <summary>
		/// E mail
		/// </summary>
		public string EMail { get { return _eMail; } }

		/// <summary>
		/// IP Address
		/// </summary>
		public string Ip { get { return _ip; } }

		/// <summary>
		/// 공정 권한
		/// </summary>
		public string[] ProcessAuth { get { return _processAuth; } }

		/// <summary>
		/// 예외 권한
		/// </summary>
		public string Restrictions { set { _restrictions = value; } }

        public int CompSeq { set { _CompSeq = value; } get { return _CompSeq; } }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // PublicMethod
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckRestrictionsAuth :: 예외 권한을 체크합니다.

        /// <summary>
        /// 예외 권한을 체크합니다.
        /// </summary>
        /// <param name="checkAuth">체크할 예외 권한</param>
        /// <returns></returns>
        public bool CheckRestrictionsAuth(string checkAuth)
		{
			string[] restrictionsAuth = _restrictions.Split(',');

			foreach (string auth in restrictionsAuth)
			{
				if (auth == checkAuth)
					return true;
			}
			return false;
		}

        #endregion

	}
}
