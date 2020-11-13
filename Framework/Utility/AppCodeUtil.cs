using System.Data;
using TLF.Business.WSBiz;
using TLF.Framework.Config;

namespace TLF.Framework.Utility
{
    /// <summary>
    /// Application에서 사용할 Code(Database : SystemCode) Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-12 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class AppCodeUtil
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // 전체 시스템 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

		#region :: GetCodeMaster :: Code Master를 가져옵니다.

		/// <summary>
		/// Code Master를 가져옵니다.
		/// </summary>
		/// <param name="pCodeValue">대구분 코드</param>
		/// <param name="codeValue">소구분 코드</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable GetCodeMaster(string pCodeValue, string codeValue)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.CodeMaster_Get";

				string[] paramList = new string[] { "@PCodeValue", 
                                                    "@CodeValue" };
				object[] valueList = new object[] { pCodeValue,
                                                    codeValue };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}

		#endregion

		#region :: GetCodeMaster :: Code Master를 가져옵니다.

		/// <summary>
		/// Code Master를 가져옵니다.
		/// </summary>
		/// <param name="pCodeValue">대구분 코드</param>
		/// <param name="codeValue">소구분 코드</param>
		/// <param name="bDispCode">코드표시여부</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable GetCodeMaster(string pCodeValue, string codeValue,bool bDispCode)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.CodeMaster_Get";
                /*
				string[] paramList = new string[] { "@PCodeValue", 
                                                    "@CodeValue", 
                                                    "@DispCode" 
												  };
				object[] valueList = new object[] { pCodeValue,
                                                    codeValue,
													bDispCode
				                                  };
                */
                string[] paramList = new string[] { "@PCodeValue",
                                                    "@CodeValue",
                                                  };
                object[] valueList = new object[] { pCodeValue,
                                                    codeValue,
                                                  };
                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}

        #endregion

        #region :: GetInspCode :: 검사항목코드를 가져옵니다.
        /// <summary>
        /// Code Master를 가져옵니다.
        /// </summary>
        /// <param name="pCodeValue">대구분 코드</param>
        /// <param name="codeValue">소구분 코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetInspCode(string pCodeValue, string codeValue)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.MESDB))
            {
                string query = "dbo.usp_MdInspCode_CRUD";

                string[] paramList = new string[] {
                    "@iOp1",
                    "@iOp2",
                    "@pCodeValue"
                 };

                object[] valueList = new object[] {
                    "R",
                    "3",
                    pCodeValue
                };

                dt = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetAssemblyID :: AssemblyID 를 가져옵니다.

        /// <summary>
        /// AssemblyID 를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetAssemblyID()
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.AssemblyID_Get";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion
        
		#region :: GetUserId :: 사용자 목록 자겨오기
		/// <summary>
        /// 사용자 목록 자겨오기
        /// </summary>
        /// <param name="VendCd"></param>
        /// <param name="PlantCd"></param>
        /// <param name="UserId"></param>
        /// <param name="UserNm"></param>
        /// <returns></returns>
		public static DataTable GetUserId(string VendCd, string PlantCd, string UserId, string UserNm)
        {
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(UserId) CodeValue,rtrim(UserId)+' : '+UserName DisplayValue from dbo.UserInfo where Vendor like '{0}%' and PlantCode like '{1}%' and UserId like '{2}%' and UserName like '{3}%' and UseFlag=1 order by UserId "
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , UserId.Trim()
												   , UserNm.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

        #endregion
        
    }
}
