using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace TLF.Framework.Utility
{
	public class ExcelReader
	{
		#region Properties

		/// <summary>
		/// Sheet의 첫 번째 행에 데이터가 아닌 열 이름이 있음을 설정하거나, 가져온다.
		/// </summary>
		public bool HasHeader
		{
			get { return _hasHeader; }
			set { _hasHeader = value; }
		}
		protected bool _hasHeader = true;

		/// <summary>
		/// Excel 파일명을 설정하거나, 가져온다.
		/// </summary>
		public string File
		{
			get { return _file; }
			set { _file = value; }
		}
		protected string _file = string.Empty;


		public bool IsOpen
		{
			get { return _oleConn != null && _oleConn.State == ConnectionState.Open; }
		}
		/// <summary>
		/// Excel 파일과 연결하기 위한 객체
		/// </summary>
		protected OleDbConnection _oleConn = null;

		/// <summary>
		/// 마지막으로 수행된 처리에서 발생한 오류 내용을 가져온다.
		/// </summary>
		public Exception LastError
		{
			get { return _lastError; }
		}
		protected Exception _lastError = null;
		#endregion Properties

		#region Construction

		public ExcelReader()
		{
		}

		#endregion Construction


		#region Implementation

		/// <summary>
		/// Excel 문서를 열기위한 연결 문자열을 생성한다.
		/// </summary>
		/// <param name="excelFile">대상 Excel 파일 명</param>
		/// <param name="hasHeader">첫번째 열의 데이터가 열 이름인지 여부</param>
		/// <returns>연결 문자열</returns>
		protected string GetConnectionString(string excelFile, bool hasHeader)
		{
			//Office 3.0: 1992. 8. 30. 
			//Office 4.0: 1994. 1. 17. 
			//Office 4.3: 1994. 6. 2. 
			//Office 95: 1995. 8. 30. (7.0 버전) 
			//Office 97: 1996. 12. 30. (8.0 버전) 
			//Office 2000: 1999. 1. 27. (9.0 버전) 
			//Office XP: 2001. 5. 31. (10.0 버전. Excel 등 단품은 Excel 2002 식으로 명명되었다.) 
			//Office 2003: 2003. 11. 17. (11.0 버전) 
			//Office 2007: 2007. 1. 30. (12.0 버전)
			//버전 알아내기
			//Excel관련 Dll 포함 Interop.Excel, Interop.Microsoft.Office.Core, Interop.Office
			//Dll버전
			//namespace ==> using System.Runtime.InteropServices;
			//Excel.Application app = new Excel.Application();
			//string version = app.Version;
			//Marshal.ReleaseComObject(app);
			//GC.Collect();


			//Excel 95 통합 문서(Excel 7.0 버전)에 대해서는 Excel 5.0을 지정하고 
			//Excel 97, Excel 2000 또는 Excel 2002(XP) 통합 문서(Excel 8.0, 9.0 및 10.0 버전)에 대해서는 Excel 8.0을 지정합니다.
			//float fver = 0f;
			//if (float.TryParse(version, out fver) == false)
			//    fver = 8.0f;

			//if (fver < 8.0f) 
			//    version = "5.0";
			//else
			//    version = "8.0";

			return string.Format
			(
				  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};"
				+ "Extended Properties=\"Excel 8.0;HDR={1}\"",
				excelFile, hasHeader ? "YES" : "NO"
			);
		}

		/// <summary>
		/// Excel 문서를 열기위한 연결 문자열을 생성한다.
		/// </summary>
		protected string GetConnectionString()
		{
			return GetConnectionString(_file, _hasHeader);
		}

		/// <summary>
		/// 입력된 범위 문자열이 Excel 양식에 부합하는지 검사한다.
		/// </summary>
		/// <param name="range">범위 지정 문자열</param>
		/// <returns>검사 결과</returns>
		protected bool RangeCheck(string range)
		{
			bool isConform = true;

			string formats = string.Format
			(
				"{0}|{1}|{2}|{3}",
				"\\D{1,2}\\d{1,5}:\\D{1,2}\\d{1,5}",
				"\\d{1,5}:\\d{1,5}",
				"\\D{1,2}:\\D{1,2}",
				"\\D{1,2}\\d{1,5}"
			);

			string[] splits;
			string spfmt = ":";
			string min = string.Empty;
			string max = string.Empty;

			Match match = Regex.Match(range, formats);

			if (match.Length > 0)
			{
				splits = Regex.Split(range, spfmt);

				min = splits[0];
				max = splits.Length > 1 ? splits[1] : null;

				isConform = true;
			}

			return isConform;
		}

		#endregion Implementation

		#region Methods

		/// <summary>
		/// 지정된 Excel 문서를 연다.
		/// </summary>
		/// <param name="excelFile">대상 Excel 파일 명</param>
		/// <param name="hasHeader">첫번째 행의 데이터가 열 이름인지 여부</param>
		/// <returns>성공 여부</returns>
		public bool Open(string excelFile, bool hasHeader)
		{
			// Excel 파일 존재 여부 확인
			if (System.IO.File.Exists(excelFile) == false)
			{
				_lastError = new Exception("Excel file '" + excelFile + "' could not be found.");
				return false;
			}

			bool isOpen = false;

			try
			{
				Close();

				_oleConn = new OleDbConnection();
				_oleConn.ConnectionString = GetConnectionString(excelFile, hasHeader);
				_oleConn.Open();

				_file = excelFile;
				_hasHeader = hasHeader;

				isOpen = true;
			}
			catch (Exception ex)
			{
				_lastError = ex;
			}

			return isOpen;
		}

		/// <summary>
		/// 지정된 Excel 문서를 연다.
		/// 
		/// 주의 :
		///  첫번째 행의 데이터는 열 이름으로 인지하지 않는다.
		///  첫번째 행의 데이터를 열 이름으로 지정할 경우 
		///   
		///     Open(string excelFile, bool hasHeader)
		/// 
		///  함수를 사용하고, hasHeader 인자를 true로 설정한다.
		/// </summary>
		/// <param name="excelFile">대상 Excel 파일 명</param>
		/// <returns>성공 여부</returns>
		public bool Open(string excelFile)
		{
			return Open(excelFile, false);
		}

		/// <summary>
		/// 지정된 Excel 문서를 연다.
		/// 
		/// 주의 :
		///  첫번째 행의 데이터는 열 이름으로 인지하지 않는다.
		///  첫번째 행의 데이터를 열 이름으로 지정할 경우 
		///   
		///     Open(string excelFile, bool hasHeader)
		/// 
		///  함수를 사용하고, hasHeader 인자를 true로 설정한다.
		/// </summary>
		public bool Open()
		{
			return Open(_file, _hasHeader);
		}

		/// <summary>현재 열려진 Excel 문서를 닫는다.</summary>
		public void Close()
		{
			if (_oleConn != null)
			{
				if (_oleConn.State == ConnectionState.Open)
					_oleConn.Close();

				_oleConn.Dispose();
				_oleConn = null;
			}
		}

		/// <summary>
		/// 현재 열려진 Excel 문서 내 존재하는 Sheet들의 이름을 가져온다.
		/// </summary>
		/// <returns>Excel 문서 내 존재하는 Sheet들의 이름 목록</returns>
		public string[] GetSheetNames()
		{
			List<string> sheets = new List<string>();

			if (IsOpen)
			{
				DataTable dt = _oleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						string sheetName = row["TABLE_NAME"].ToString();

						sheetName = sheetName.Replace("'", "");
						sheetName = sheetName.Replace("$", "");

						sheets.Add(sheetName);
					}
				}
			}

			return sheets.ToArray();
		}

		/// <summary>
		/// 지정된 Sheet의 지정 범위내 포함된 데이터를 가져온다.
		/// </summary>
		/// <param name="sheetName">데이터를 포함하고 있는 Sheet 이름</param>
		/// <param name="range">데이터를 획득할 Sheet내 범위</param>
		/// <returns>데이터 테이블</returns>
		public DataTable GetSheet(string sheetName, string range)
		{
			DataTable dt = null;

			if (!IsOpen)
			{
				_lastError = new Exception("Excel 파일이 Open되지 않았습니다.");
				return null;
			}

			if (!RangeCheck(range))
			{
				_lastError = new Exception
				(
					string.Format("지정된 범위 '{0}' 는 형식에 부합되지 않습니다.", range)
				);
				return null;
			}

			try
			{
				if (range == string.Empty)
					range = "A:IU";

				//string query = string.Format
				//(
				//      "SELECT *\n"
				//    + "  FROM [{0}${1}]",
				//    sheetName, range
				//);
				string query = "select * from [Sheet1$A:IU]";

				OleDbCommand oleCmd = new OleDbCommand(query, _oleConn);

				OleDbDataAdapter oleAdapter = new OleDbDataAdapter();
				oleAdapter.SelectCommand = oleCmd;

				dt = new DataTable(sheetName);
				oleAdapter.FillSchema(dt, SchemaType.Source);
				oleAdapter.Fill(dt);
			}
			catch (Exception ex)
			{
				_lastError = ex;

				if (dt != null)
				{
					dt.Dispose();
					dt = null;
				}
			}

			return dt;
		}

		/// <summary>
		/// 지정된 Sheet에 포함된 데이터를 가져온다.
		/// </summary>
		/// <param name="sheetName">데이터를 포함하고 있는 Sheet 이름</param>
		/// <returns>데이터 테이블</returns>
		public DataTable GetSheet(string sheetName)
		{
			return GetSheet(sheetName, "");
		}

		#endregion Methods

	}
}
