using System.Data;
using TLF.Business.WSBiz;
using TLF.Framework.Config;


namespace TLF.Framework.Utility
{
    /// <summary>
    /// MES 시스템에서 사용할 Code Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2009-06-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class MesCodeUtil
    {
        #region :: GetCodeMaster :: Code Master를 가져옵니다.

        /// <summary>
        /// Code Master
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

		#region :: ExecuteSqlQuery :: Sql쿼리를 직접실행합니다.

		/// <summary>
		/// ExecuteSqlQuery
		/// </summary>
		/// <param name="SqlQuery">고객코드</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable ExecuteSqlQuery(string SqlQuery)
		{
			if (SqlQuery.Trim().Equals("")) return null;

			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, SqlQuery, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

        #endregion


        #region :: ExecuteStoredProcedure :: 저장프로시져를 실행합니다.

        /// <summary>
        /// ExecuteStoredProcedure
        /// </summary>
        /// <param name="query">저장프로시져명</param>
        /// <param name="paramList">호출파라미터</param>
        /// <param name="valueList">호출값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable ExecuteStoredProcedure(string query, string[] paramList, object[] valueList)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}

		#endregion


		#region :: GetCustomer :: 고객정보를 가져옵니다.

		/// <summary>
		/// GetCustomer
		/// </summary>
		/// <param name="CustCd">고객코드</param>
		/// <param name="CustNm">고객명</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable GetCustomer(string CustCd, string CustNm)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_Customer_CRUD";

				string[] paramList = new string[] { "@iOp1", 
                                                    "@iOp2",
                                                    "@CustCd",
                                                    "@CustNm" };
				object[] valueList = new object[] { "R",
                                                    "3",
                                                    CustCd,
                                                    CustNm};

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}

		#endregion


        #region :: GetCustomer_Type :: 고객 유형별(1:판매,2:수입,3:공통) 고객정보를 가져옵니다.

        /// <summary>
        /// GetCustomer_Type
        /// </summary>
        /// <param name="CustType">고객유형</param>
        /// <param name="IsCodeDisplay">명에 코드 포함 여부</param>
        /// <returns></returns>
        /// <remarks>
        /// 2014-02-27 최초생성 : 황준혁
        /// 콤보박스용으로 CodeValue,DisplayValue를  기본 코드용으로 CustCd,CustNm 필드 정의
        /// 
        /// </remarks>
        public static DataTable GetCustomer_Type(string CustType,bool IsCodeDisplay=false)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = string.Empty;
                if(IsCodeDisplay)
                     query = string.Format(@"select distinct rtrim(CustCd) CodeValue ,rtrim(CustCd)+' : '+rtrim(CustNm) DisplayValue from Customer where charindex(CustType,'{0}')>0 order by rtrim(CustCd)", CustType);
                else query = string.Format(@"select distinct rtrim(CustCd) CodeValue ,rtrim(CustNm)                       DisplayValue from Customer where charindex(CustType,'{0}')>0 order by rtrim(CustCd)", CustType);

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
            }

            return dt;
        }

        #endregion


		#region :: GetMatSupplier :: 자재 공급처정보를 가져옵니다.

		/// <summary>
		/// GetMatSupplier
		/// </summary>
		/// <param name="VendCd">업체코드</param>
		/// <param name="PlantCd">사업장코드</param>
		/// <param name="DivCd">사업부코드</param>
		/// <param name="MatCd">자재코드</param>
		/// <param name="SupplierCd">고객코드</param>
		/// <param name="CustNm">고객명</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable GetMatSupplier(string VendCd, string PlantCd, string DivCd, string MatCd, string SupplierCd, string CustNm)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"

select distinct 
       rtrim(mmph.SupplierCd) CodeValue
      ,mmph.SupplierCd+' : '+c.CustNm DisplayValue
  from MH_MatPrcHs mmph
 inner join HIMES.dbo.Customer c
    on mmph.SupplierCd = c.CustCd
 where mmph.VendCd	   like '{0}%' 
   and mmph.PlantCd	   like '{1}%' 
   and mmph.DivCd	   like '{2}%'
   and mmph.MatCd      like '{3}%'
   and mmph.SupplierCd like '{4}%'
   and c.CustNm        like '{5}%'
   and mmph.IsUse      = 1
order by rtrim(mmph.SupplierCd)
"
                                                , VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, MatCd.Trim()
												, SupplierCd.Trim()
												, CustNm.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}
		#endregion


		#region :: GetMatMvCd :: 자재업체정보를 가져옵니다.

		/// <summary>
		/// GetMatMvCd
        /// </summary>
		/// <param name="VendCd">업체코드</param>
		/// <param name="PlantCd">사업장코드</param>
		/// <param name="DivCd">사업부코드</param>
		/// <param name="SupplierCd">고객코드</param>
        /// <param name="CustCd"></param>
		/// <param name="MvCd">자재업체코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-12 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
		public static DataTable GetMatMvCd(string VendCd, string PlantCd, string DivCd, string SupplierCd, string CustCd, string MvCd)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
				string query = string.Format(@"

select distinct 
       rtrim(mmph.MvCd) CodeValue
      ,mmph.MvCd+' : '+c.CustNm DisplayValue
  from MH_MatPrcHs mmph
 inner join HIMES.dbo.Customer c
    on mmph.MvCd = c.CustCd
 where mmph.VendCd	   like '{0}%' 
   and mmph.PlantCd	   like '{1}%' 
   and mmph.DivCd	   like '{2}%'
   and mmph.MatCd      like '{3}%'
   and mmph.SupplierCd like '{4}%'
   and mmph.MvCd       like '{5}%'
   and mmph.IsUse      = 1
order by mmph.MvCd
"
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, SupplierCd.Trim()
												, CustCd.Trim()
												, MvCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

            return dt;
        }

        #endregion

		#region :: GetMatPrcRevNo :: 자재업체코드정보를 가져옵니다.

		/// <summary>
		/// GetMatSupplier
		/// </summary>
		/// <param name="VendCd">업체코드</param>
		/// <param name="PlantCd">사업장코드</param>
		/// <param name="DivCd">사업부코드</param>
		/// <param name="MatCd">자재코드</param>
		/// <param name="CustCd">고객코드</param>
		/// <param name="MvCd">자재업체코드</param>
		/// <returns></returns>
		/// <remarks>
		/// 2009-01-12 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public static DataTable GetMatPrcRevNo(string VendCd, string PlantCd, string DivCd, string MatCd, string CustCd, string MvCd)
		{
			DataTable dt = null;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"

select distinct 
       rtrim(RevNo)   CodeValue
      ,UnitPrc DisplayValue
  from MH_MatPrcHs
 where VendCd	   like '{0}%' 
   and PlantCd	   like '{1}%' 
   and DivCd	   like '{2}%'
   and MatCd       like '{3}%'
   and SupplierCd  like '{4}%'
   and MvCd        like '{5}%'
   and IsUse       = 1
order by rtrim(RevNo),UnitPrc

"
                                                , VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, MatCd.Trim()
												, CustCd.Trim()
												, MvCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		#endregion

		#region :: GetOrderCustCd :: 발주처정보를 가져옵니다.

		/// <summary>
		/// 제품마스터에 등록된 발주고객 가져오기
		/// </summary>
		/// <param name="VendCd">업체코드</param>
		/// <param name="PlantCd">사업장코드</param>
		/// <param name="DivCd">사업부코드</param>
		/// <returns></returns>
		public static DataTable GetOrderCustCd(string VendCd, string PlantCd, string DivCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
select distinct 
	   rtrim(pfm.CustCd)   CodeValue
	  ,c.CustNm     DisplayValue 
  from PM_FgMt pfm
 inner join HIMES.dbo.Customer c
    on pfm.CustCd = c.CustCd
 inner join PM_PkgMt ppm
    on ppm.VendCd = pfm.VendCd
   and ppm.PlantCd = pfm.PlantCd
   and ppm.DivCd = pfm.DivCd
   and ppm.FgCd = pfm.FgCd
 where pfm.IsUse	=1
   and c.IsUse		=1
   and ppm.IsUse	=1
   and pfm.VendCd	like '{0}%' 
   and pfm.PlantCd	like '{1}%' 
   and pfm.DivCd	like '{2}%'
order by c.CustNm
"
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}
		#endregion

		#region :: GetOrderRfidCustCd :: 발주처정보를 가져옵니다.

		/// <summary>
		/// 제품마스터에 등록된 발주고객 가져오기
		/// </summary>
		/// <param name="VendCd">업체코드</param>
		/// <param name="PlantCd">사업장코드</param>
		/// <param name="DivCd">사업부코드</param>
		/// <returns></returns>
		public static DataTable GetOrderRfidCustCd(string VendCd, string PlantCd, string DivCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_PM_FgCustMt_CRUD";

				string[] paramList = new string[] {  "@iOp1" 
													,"@iOp2" 
													,"@i_VendCd" 
													,"@i_PlantCd" 
													,"@i_DivCd" 
												};

				object[] valueList = new object[] { "R"
													,"OrderRfidCustCd"
													,VendCd
													,PlantCd
													,DivCd
												};

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}
		#endregion

		/// <summary>
		/// 수주이력에 등록 수주정보 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="OrderCustCd"></param>
        /// <param name="SaleCustCd"></param>
		/// <param name="FgCd"></param>
		/// <returns></returns>
		public static DataTable GetSoNo(string VendCd, string PlantCd, string DivCd, string OrderCustCd, string SaleCustCd, string FgCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct 
													   rtrim(SoNo)   CodeValue
													  ,SoNo   DisplayValue 
												  from SH_SoHs
												 where VendCd      = '{0}'
												   and PlantCd     = '{1}'
												   and DivCd       = '{2}'
												   and OrderCustCd = '{3}'
												   and SaleCustCd  = '{4}'
												   and FgCd        = '{5}'
												   and IsComplete  = 0
												   and IsUse       = 1
												 order by SoNo    

											   ", VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, OrderCustCd.Trim()
												, SaleCustCd.Trim()
												, FgCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


        /// <summary>
        /// 수주이력에 등록 수주정보 가져오기
        /// </summary>
        /// <param name="VendCd"></param>
        /// <param name="PlantCd"></param>
        /// <param name="DivCd"></param>
        /// <param name="OrderCustCd"></param>
        /// <param name="SaleCustCd"></param>
        /// <param name="FgCd"></param>
        /// <param name="SoNo"></param>
        /// <returns></returns>
        public static DataTable GetSoItem(string VendCd, string PlantCd, string DivCd, string OrderCustCd, string SaleCustCd, string FgCd, string SoNo)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct 
													   rtrim(SoItem)   CodeValue
													  ,SoItem   DisplayValue 
												  from SH_SoHs
												 where VendCd      = '{0}'
												   and PlantCd     = '{1}'
												   and DivCd       = '{2}'
												   and OrderCustCd = '{3}'
												   and SaleCustCd  = '{4}'
												   and FgCd        = '{5}'
												   and SoNO        = '{6}'
												   and IsComplete  = 0
												   and IsUse       = 1
												 order by SoItem    

											   ", VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, OrderCustCd.Trim()
												, SaleCustCd.Trim()
												, FgCd.Trim()
												, SoNo.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 포장정보에 등록된 고객 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="CustCd"></param>
		/// <returns></returns>
		public static DataTable GetPkgCustCd(string VendCd, string PlantCd, string DivCd, string CustCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(a.SaleCustCd) CodeValue,rtrim(a.SaleCustCd)+' : '+b.CustNm DisplayValue from PM_FgCustMt a inner join HIMES.dbo.Customer b on a.SaleCustCd=b.CustCd where a.VendCd like '{0}%' and a.PlantCd like '{1}%' and a.DivCd like '{2}%' and a.OrderCustCd like '{3}%' and a.IsUse=1 group by a.SaleCustCd,b.CustNm order by a.SaleCustCd,b.CustNm"
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, CustCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 포장정보에 등록된 고객의 제품 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="OrderCustCd"></param>
		/// <param name="SaleCustCd"></param>
		/// <returns></returns>
		public static DataTable GetPkgCustFgCd(string VendCd, string PlantCd, string DivCd, string OrderCustCd, string SaleCustCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(a.FgCd) CodeValue,rtrim(a.FgCd)+' : '+b.FgNm DisplayValue from PM_FgCustMt a inner join PM_FgMt b on a.FgCd=b.FgCd where a.VendCd like '{0}%' and a.PlantCd like '{1}%' and a.DivCd like '{2}%' and a.OrderCustCd like '{3}%' and a.SaleCustCd like '{4}%' and a.IsUse=1 group by a.FgCd,b.FgNm order by a.FgCd,b.FgNm "
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, OrderCustCd.Trim()
												, SaleCustCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 포장정보에서 RFID룰이 등록된 고객의 제품 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="OrderCustCd"></param>
		/// <param name="SaleCustCd"></param>
		/// <returns></returns>
		public static DataTable GetPkgCustRfidFgCd(string VendCd, string PlantCd, string DivCd, string OrderCustCd, string SaleCustCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_PM_FgCustMt_CRUD";

				string[] paramList = new string[] {  "@iOp1" 
													,"@iOp2" 
													,"@i_VendCd" 
													,"@i_PlantCd" 
													,"@i_DivCd" 
													,"@i_OrderCustCd" 
													,"@i_SaleCustCd" 
												};

				object[] valueList = new object[] { "R"
													,"PkgCustRfidFgCd"
													,VendCd
													,PlantCd
													,DivCd
													,OrderCustCd
													,SaleCustCd
												};

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 포장정보에서 RFID룰이 있는 등록된 고객 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="CustCd"></param>
		/// <returns></returns>
		public static DataTable GetPkgRfidCustCd(string VendCd, string PlantCd, string DivCd, string CustCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_PM_FgCustMt_CRUD";

				string[] paramList = new string[] {  "@iOp1" 
													,"@iOp2" 
													,"@i_VendCd" 
													,"@i_PlantCd" 
													,"@i_DivCd" 
													,"@i_OrderCustCd" 
												};

				object[] valueList = new object[] { "R"
													,"PkgRfidCustCd"
													,VendCd
													,PlantCd
													,DivCd
													,CustCd
												};

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}




        #region :: CodeHelp :: 코드헬퍼를 실행합니다.

        /// <summary>
        /// 코드헬퍼를 실행합니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-06-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable CodeHelp(string CodeHelpId, string QueryParamValue)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.usp_CodeHelp_Run";

                string[] paramList = new string[] { "@CodeHelpId", "@QueryParamValue" };

                object[] valueList = new object[] { CodeHelpId, QueryParamValue };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetPlant :: Plant정보를 가져옵니다.

        /// <summary>
        /// Plant정보를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-06-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetPlant()
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.MES_Plants_Select";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTASSAY, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDefectProcess :: 불량 공정을 가져옵니다.

        /// <summary>
        /// 불량 공정을 가져옵니다.
        /// </summary>
        /// <param name="lotNumber"></param>
        /// <returns></returns>
        public static DataTable GetDefectProcess(string lotNumber)
        {
            DataTable dt = null;
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.upQDefectModify";

                string[] paramList = new string[] { "@Option", "@LotNumber" };

                object[] valueList = new object[] { "ProcessCode", lotNumber };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

            }
            return dt;
        }

        #endregion

        #region :: GetRestrictionEmployees :: RestrictionEmployees 있는 특별권한자 가져오기

        /// <summary>
        /// RestrictionEmployees 있는 특별권한자 가져오기
        /// </summary>
        /// <param name="RestrictionCode"></param>
        /// <returns></returns>
        public static DataTable GetRestrictionEmployees(string RestrictionCode)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.upQRestrictionEmployees";

                string[] paramList = new string[] { "@RestrictionCode" };

                object[] valueList = new object[] { RestrictionCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

            }

            return dt;
        }

        #endregion


        /// <summary>
        /// 불량입력 원인공정 가져오기
        /// </summary>
        /// <param name="LotNumber"></param>
        /// <returns></returns>
        public static DataTable GetCauseProcess(string LotNumber)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.upQGetCauseProcess";

                string[] paramList = new string[] { "@LotNumber" };

                object[] valueList = new object[] { LotNumber };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        /// <summary>
        /// 공정별 입력가능 불량코드 가져오기
        /// </summary>
        /// <param name="ProcessCode"></param>
        /// <returns></returns>

        public static DataTable GetProcessDefectCode(string ProcessCode)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.upQDefectModify";

                string[] paramList = new string[] { "@Option", "@ProcessCode" };

                object[] valueList = new object[] { "DefectProcess", ProcessCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }



        /// <summary>
        /// 공정별 입력가능 불량코드 가져오기
        /// </summary>
        /// <param name="ProcessCode"></param>
        /// <returns></returns>
        public static DataTable GetTPSProcessDefectCode(string ProcessCode)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_DefectCode";

                string[] paramList = new string[] { "@i_ProcessCode"};

                object[] valueList = new object[] {  ProcessCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }


        /// <summary>
        /// Plant별, Line별, 공장별, 공정별 공정코드 가져오기
        /// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="FgType"></param>
		/// <param name="ProcessesCode"></param>
        /// <returns></returns>

		public static DataTable GetProcesses(string VendCd, string PlantCd, string FgType, string ProcessesCode)
        {

            DataTable dt = null;
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.usp_Processes_Get";

                string[] paramList = new string[] { "@Vendor", "@Plant", "@FgType", "@ProcessesCode" };

				object[] valueList = new object[] { VendCd, PlantCd, FgType, ProcessesCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

                return dt;

            }

        }

        /// <summary>
        /// Plant별, Line별, 공장별, 공정별 공정코드 가져오기
        /// CodeValue 와 DisplayValue 리턴
        /// </summary>
		/// <param name="PlantCd"></param>
        /// <param name="Line"></param>
        /// <param name="Factory"></param>
        /// <param name="ProcessesCode"></param>
        /// <returns></returns>

		public static DataTable GetProcesses_DJ(string PlantCd, string Line, string Factory, string ProcessesCode)
        {

            DataTable dt = null;
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_Processes_DJ";

                string[] paramList = new string[] { "@i_Plant", "@i_Line", "@i_Factory", "@i_ProcessCode" };

				object[] valueList = new object[] { PlantCd, Line, Factory, ProcessesCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

                return dt;

            }

        }


		/// <summary>
		/// Plant별, Line별, 공장별, 제품, 생산버젼별 공정코드 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgCd"></param>
		/// <param name="ProdVerNo"></param>
		/// <param name="ProcCd"></param>
		/// <returns></returns>

		public static DataTable GetProdVerProcCd(string VendCd, string PlantCd, string DivCd, string FgCd, string ProdVerNo, string ProcCd)
		{

			DataTable dt = null;
			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.cboProdVerProcCd_Get";

				string[] paramList = new string[] { "@VendCd", "@PlantCd", "@DivCd", "@FgCd", "@ProdVerNo", "@ProcCd" };

				object[] valueList = new object[] { VendCd, PlantCd, DivCd, FgCd, ProdVerNo, ProcCd };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

				return dt;

			}

		}



		/// <summary>
		/// 사업부 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="DivNm"></param>
		/// <returns></returns>
		public static DataTable GetDivision(string VendCd, string PlantCd, string DivCd, string DivNm)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_Division_CRUD";

				string[] paramList = new string[] { "@iOp1", "@iOp2", "@i_VendCd", "@i_PlantCd", "@i_DivCd", "@i_DivNm" };

				object[] valueList = new object[] { "R", "3", VendCd, PlantCd, DivCd, DivNm };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

				return dt;
			}
		}


		/// <summary>
		/// 사업부 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <returns></returns>
		public static DataTable GetDivCd(string VendCd, string PlantCd, string DivCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.cboDivCd_Get";

				string[] paramList = new string[] {"@VendCd", "@PlantCd", "@DivCd"};

				object[] valueList = new object[] { VendCd, PlantCd, DivCd};

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

				return dt;
			}
		}


		/// <summary>
        /// 제품유형 가져오기
        /// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgKindCd"></param>
		/// <param name="FgKindNm"></param>
		/// <returns></returns>
        public static DataTable GetFgType(string VendCd, string PlantCd, string DivCd,string FgKindCd,string FgKindNm)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.usp_FgKind_CRUD";

                string[] paramList = new string[] { "@iOp1", "@iOp2", "@i_VendCd", "@i_PlantCd", "@i_DivCd", "@i_FgKindCd", "@i_FgKindNm" };

                object[] valueList = new object[] { "R", "3", VendCd, PlantCd, DivCd, FgKindCd, FgKindNm };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];

                return dt;
            }
        }



		/// <summary>
		/// 생산버젼 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgCd"></param>
		/// <param name="ProdVerNo"></param>
		/// <returns></returns>
		public static DataTable GetProdVerNo(string VendCd, string PlantCd, string DivCd, string FgCd, string ProdVerNo)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.cboProdVerNo_Get";

				string[] paramList = new string[] { "@VendCd", "@PlantCd", "@DivCd", "@FgCd", "@ProdVerNo" };

				object[] valueList = new object[] { VendCd, PlantCd, DivCd, FgCd, ProdVerNo };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 제품목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgKindCd"></param>
		/// <returns></returns>
		public static DataTable GetFgCode(string VendCd, string PlantCd, string DivCd, string FgKindCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.cboFgCode_Get";

				string[] paramList = new string[] { "@VendCd", "@PlantCd", "@DivCd", "@FgKindCd" };

				object[] valueList = new object[] { VendCd, PlantCd, DivCd, FgKindCd };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 제품목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgType"></param>
		/// <param name="FgCd"></param>
		/// <param name="FgNm"></param>
		/// <returns></returns>
		public static DataTable GetFg(string VendCd, string PlantCd, string DivCd, string FgType, string FgCd, string FgNm)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_PM_fgMt_CRUD";

				string[] paramList = new string[] { "@iOp1", "@iOp2", "@i_VendCd", "@i_PlantCd", "@i_DivCd", "@i_FgKindCd", "@i_FgCd", "@i_FgNm" };

				object[] valueList = new object[] { "R", "3", VendCd, PlantCd, DivCd, FgType, "", "" };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 생산번호별 제품목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FactNo"></param>
		/// <returns></returns>
		public static DataTable GetFg_FactNo(string VendCd, string PlantCd, string DivCd, string FactNo)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct
													   rtrim(FgCd) as CodeValue
													  ,rtrim(FgCd) as DisplayValue
												  from PH_LotHs
												 where VendCd	= '{0}'
												   and PlantCd	= '{1}'
												   and DivCd	= '{2}'
												   and FactNo	= '{3}'
											 	 order by rtrim(FgCd)
											"
											, VendCd.Trim()
											, PlantCd.Trim()
											, DivCd.Trim()
											, FactNo.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}



		/// <summary>
		/// 제품 최종 포장번호 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="OrderCustCd"></param>
		/// <param name="SaleCustCd"></param>
		/// <param name="FgCd"></param>
		/// <returns></returns>
		public static DataTable GetLastPkgLot(string VendCd, string PlantCd, string DivCd, string OrderCustCd, string SaleCustCd, string FgCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.usp_GetLastPkgNo";

				string[] paramList = new string[] { "@VendCd", "@PlantCd", "@DivCd", "@OrderCustCd", "@SaleCustCd", "@FgCd" };

				object[] valueList = new object[] { VendCd, PlantCd, DivCd, OrderCustCd, SaleCustCd, FgCd };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 고객별 제품목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="CustCd"></param>
		/// <returns></returns>
		public static DataTable GetFg_CustCd(string VendCd, string PlantCd, string DivCd, string CustCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct
													   rtrim(FgCd) as CodeValue
													  ,rtrim(FgCd) as DisplayValue
												  from PH_LotHs
												 where VendCd	= '{0}'
												   and PlantCd	= '{1}'
												   and DivCd	= '{2}'
												   and FactNo	= '{3}'
											 	 order by rtrim(FgCd)
											"
											, VendCd.Trim()
											, PlantCd.Trim()
											, DivCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 자재코드 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="MatCd"></param>
		/// <returns></returns>
		public static DataTable GetMatCd(string VendCd, string PlantCd, string DivCd, string MatCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "dbo.cboMatCd_Get";

				string[] paramList = new string[] { "@VendCd", "@PlantCd", "@DivCd", "@MatCd" };

				object[] valueList = new object[] { VendCd, PlantCd, DivCd, MatCd };

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 치공구 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgCd"></param>
		/// <param name="ProcCd"></param>
		/// <param name="JigType"></param>
		/// <returns></returns>
		public static DataTable GetJigNo(string VendCd, string PlantCd, string DivCd, string FgCd, string ProcCd, string JigType)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct 
  													   rtrim(JigCd) CodeValue
													  ,rtrim(JigCd) DisplayValue
												  FROM JM_FgJigMt
												 where JigTypeCd = '1001'
												   and FgCd like '{0}%'
												   and ProcCd like '{1}%'
												 order by rtrim(JigCd)

"
					//, VendCd.Trim()
												//   , PlantCd.Trim()
												//   , DivCd.Trim()
												   , FgCd.Trim()
												   , ProcCd.Trim()
												   //, JigType.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}



		/// <summary>
		/// BOM 자재코드 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="FgCd"></param>
		/// <param name="ProdVerNo"></param>
		/// <param name="ProcCd"></param>
		/// <returns></returns>
		public static DataTable GetBomMatCd(string VendCd, string PlantCd, string DivCd, string FgCd, string ProdVerNo, string ProcCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct
													   rtrim(pb.MatCd) as CodeValue
													  ,rtrim(pb.MatCd) as DisplayValue
												  from PM_BOM pb 
												 inner join MM_Material pm 
													on pm.VendCd	= pb.VendCd  
												   and pm.PlantCd	= pb.PlantCd
												   and pm.DivCd		= pb.DivCd
												   and pm.MatCd		= pb.MatCd
												where pb.VendCd		= '{0}'
												  and pb.PlantCd	= '{1}'
												  and pb.DivCd		= '{2}'
												  and pb.FgCd		= '{3}'
												  and pb.ProdVerNo	= '{4}'
												  and pb.ProcCd		= '{5}'
												order by rtrim(pb.MatCd)
											"
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												   , FgCd.Trim()
												   , ProdVerNo.Trim()
												   , ProcCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 자재 재고 Lot 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="MatCd"></param>
		/// <returns></returns>
		public static DataTable GetMatLotNo_Stock(string VendCd, string PlantCd, string DivCd, string MatCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct
													   rtrim(MatLotNo) CodeValue
													  ,rtrim(MatLotNo) DisplayValue 
												  from MH_MatStockHs 
												 where MatCd='{0}' 
												   and StockQty>0	
												 order by rtrim(MatLotNo)
											", MatCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 검사항목 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <returns></returns>
		public static DataTable GetInspCd(string VendCd, string PlantCd, string DivCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(InspCd) CodeValue,rtrim(InspCd)+':'+rtrim(InspNm) DisplayValue from QM_Inspect where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and IsUse=1 order by InspCd "
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 공정코드 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="ProcCd"></param>
		/// <returns></returns>
		public static DataTable GetProcCd(string VendCd, string PlantCd, string DivCd, string ProcCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				//string query = string.Format("select rtrim(ProcCd) CodeValue,rtrim(ProcCd)+' : '+rtrim(ProcNm) DisplayValue from Process where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and ProcCd like '{3}%' and IsUse=1 order by ProcCd "
				//                                , VendCd.Trim()
				//                                   , PlantCd.Trim()
				//                                   , DivCd.Trim()
				//                                   , ProcCd.Trim()
				//                                  );

				string query = string.Format("select rtrim(ProcCd) CodeValue,rtrim(ProcNm) DisplayValue from Process where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and ProcCd like '{3}%' and IsUse=1 order by ProcCd "
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												   , ProcCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


		/// <summary>
		/// 설비목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="EquipCd"></param>
		/// <returns></returns>
		public static DataTable GetEquipCd(string VendCd, string PlantCd, string DivCd, string EquipCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(EquipCd) CodeValue,rtrim(EquipCd)+' : '+EquipNm DisplayValue from Equipment where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and EquipCd like '{3}%' and IsUse=1 order by EquipCd "
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												   , EquipCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 공정별 설비목록 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="ProcCd"></param>
		/// <param name="EquipCd"></param>
		/// <returns></returns>
		public static DataTable GetEquipCd_Proc(string VendCd, string PlantCd, string DivCd,string ProcCd, string EquipCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format(@"
												select distinct
													   rtrim(ppem.EquipCd)							as CodeValue
													  ,rtrim(ppem.EquipCd)+' : '+rtrim(e.EquipNm)	as DisplayValue
												  from PM_ProcEquipMt ppem 
												 inner join Equipment e 
													on ppem.VendCd	= e.VendCd
												   and ppem.PlantCd	= e.PlantCd
												   and ppem.DivCd	= e.DivCd
												   and ppem.EquipCd	= e.EquipCd
												 where ppem.VendCd	= '{0}'
												   and ppem.PlantCd	= '{1}'
												   and ppem.DivCd	= '{2}'
												   and ppem.ProcCd	= '{3}'
												   and ppem.EquipCd like '%{4}%'
												   and ppem.IsUse	= 1
												order by rtrim(ppem.EquipCd),rtrim(ppem.EquipCd)+' : '+rtrim(e.EquipNm)
												"
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												   , ProcCd.Trim()
												   , EquipCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 손실항목 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <returns></returns>
		public static DataTable GetLossCd(string VendCd, string PlantCd, string DivCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(LossCd) CodeValue,LossNm DisplayValue from PM_Loss where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and IsUse=1 order by LossCd "
												, VendCd.Trim()
												   , PlantCd.Trim()
												   , DivCd.Trim()
												  );

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}


        /// <summary>
        /// 손실항목 가져오기
        /// </summary>
        /// <param name="VendCd"></param>
        /// <param name="PlantCd"></param>
        /// <param name="DivCd"></param>
        /// <param name="bIsCodeDisplay"></param>
        /// <returns></returns>
        public static DataTable GetLossCd(string VendCd, string PlantCd, string DivCd,bool bIsCodeDisplay)
		{
			DataTable dt;
			string query;
			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				if (bIsCodeDisplay)
				{
					query = string.Format("select rtrim(LossCd) CodeValue,rtrim(LossCd)+' : '+LossNm DisplayValue from PM_Loss where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and IsUse=1 order by LossCd "
											, VendCd.Trim()
											, PlantCd.Trim()
											, DivCd.Trim()
										);
				}
				else
				{
					query = string.Format("select rtrim(LossCd) CodeValue,LossNm DisplayValue from PM_Loss where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and IsUse=1 order by LossCd "
											, VendCd.Trim()
											, PlantCd.Trim()
											, DivCd.Trim()
										);
				}
				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// Label 항목 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="PkgKindCd"></param>
		/// <returns></returns>
		public static DataTable GetLabelCd(string VendCd, string PlantCd, string DivCd, string PkgKindCd)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(LabelCd) CodeValue,rtrim(LabelCd)+':'+LabelNm DisplayValue from PM_LabelMt where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and PkgKindCd like '{3}%' and IsUse=1  order by LabelCd "
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, PkgKindCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// Label ItemList 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
		/// <param name="PkgKindCd"></param>
		/// <param name="LabelCd"></param>
		/// <returns></returns>
		public static string GetLabelItemList(string VendCd, string PlantCd, string DivCd, string PkgKindCd, string LabelCd)
		{
			string strItemList=string.Empty;
			DataTable dt;
			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select top 1 ItemList from PM_LabelMt where VendCd = '{0}' and PlantCd = '{1}' and DivCd = '{2}' and PkgKindCd = '{3}' and LabelCd = '{4}' and IsUse=1"
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
												, PkgKindCd.Trim()
												, LabelCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
				if (dt.Rows.Count > 0) strItemList = dt.Rows[0]["ItemList"].ToString();
			}

			return strItemList;
		}


		/// <summary>
		/// ProcMapCd 가져오기
		/// </summary>
		/// <param name="VendCd"></param>
		/// <param name="PlantCd"></param>
		/// <param name="DivCd"></param>
        /// <param name="bIsCodeDisplay"></param>
		/// <returns></returns>
        public static DataTable GetProcMapCd(string VendCd, string PlantCd, string DivCd, bool bIsCodeDisplay)
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = string.Format("select rtrim(ProcMapCd) CodeValue,"+(bIsCodeDisplay?" rtrim(ProcMapCd)+' : '+":"")+" ProcMapNm DisplayValue from PM_ProcMap where VendCd like '{0}%' and PlantCd like '{1}%' and DivCd like '{2}%' and IsUse=1  order by ProcMapCd "
												, VendCd.Trim()
												, PlantCd.Trim()
												, DivCd.Trim()
											);

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return dt;
		}

		/// <summary>
		/// 불량그룹(TriggerPoint) 가져오기
		/// 최초생성: 2009-11-24 김정우
		/// </summary>
		/// <returns></returns>
		public static DataTable GetDefectGroupCode()
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "TriggerPoint.DefectGroupCode_Get";

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
			}

			return dt;
		}

		#region :: GetStationCode :: 설비코드를 가져옵니다.

        /// <summary>
        /// 설비코드를 가져옵니다.
        /// </summary>
        /// <param name="VendCd">VendCd</param>
        /// <param name="processCode">해당공정</param>
        /// <returns></returns>
        /// <remarks>
        /// 2010-04-09 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetStationCode(string VendCd, string processCode)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.StationCode_Get";

                string[] paramList = new string[] { "@VendCd", 
                                                    "@ProcessCode" };

                object[] valueList = new object[] { VendCd,
                                                    processCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion


        #region :: GetStationGroup :: 설비그룹을 가져옵니다.

        /// <summary>
        /// 설비그룹을 가져옵니다.
        /// </summary>
        /// <param name="VendCd">VendCd</param>
        /// <param name="PlantCd">Plant</param>
        /// <param name="line">라인</param>
        /// <param name="cellCode">CELL 코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2010-04-09 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static DataTable GetStationGroup(string VendCd, string PlantCd, string line, string cellCode)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.StationGroup_Get";

                string[] paramList = new string[] { "@VendCd", 
                                                    "@PlantCd", 
                                                    "@Line", 
                                                    "@CellCode" };

                object[] valueList = new object[] { VendCd,
                                                    PlantCd, 
                                                    line, 
                                                    cellCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion


        /// <summary>
        /// 불량그룹(TriggerPoint) 가져오기
        /// 최초생성: 2009-12-08 최경수
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTPMailCode()
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_TPMail";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        /// <summary>
        /// BGA 라인정보 가져오기
        /// 최초생성: 2010-01-27 유효진
        /// </summary>
        /// <returns></returns>
        public static DataTable Get_Lines()
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_Lines";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Plant"></param>
        /// <returns></returns>
        public static DataTable Get_Lines_ALL(string Plant)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_Lines_ALL";

                string[] paramList = new string[] { "@Plant" };

                object[] valueList = new object[] { Plant };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }
        /// <summary>
        /// 개발요청 라인사유 입력 관련 관리번호 그룹 가져오기
        /// 최초생성: 2010-06-14 oyh
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLotResonManageGroup()
        {
            DataTable dt = null;

            using (WsBiz ws = new WsBiz(AppConfig.WEBSERVICEURL))
            {
                string query = "dbo.upQLotResonSearch";
                string[] param = new string[] { "@i_Option" };
                object[] value = new object[] { "GroupSearch" };

                dt = ws.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, param, value).Tables[0];

            }

            return dt;
        }


        /// <summary>
        /// 불량코드 가져오기
        /// </summary>
		/// <param name="Type"></param>
		/// <param name="Value"></param>
		/// <returns></returns>

        public static DataTable GetComboListData(string Type, string Value)
        {
            DataTable dt;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.GET_ComboList_Checker";

                string[] paramList = new string[] { "@Type", "@Value" };

                object[] valueList = new object[] { Type, Value };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public static System.DateTime GetDbTime()
		{
			DataTable dt;

			using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
			{
				string query = "select GetDate() as Now";

				dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, null, null).Tables[0];
			}

			return System.Convert.ToDateTime(dt.Rows[0]["Now"]);
		}
    }
}
