using System.Data;
using TLF.Business.WSBiz;
using TLF.Framework.Config;

namespace TLF.Framework.Utility
{
    /// <summary>
    /// 물류이동시스템(PMMS)에서 사용할 Code Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2009-10-20 최초생성 : 김정우(삼성전기)
    /// </remarks>
    public class PmmsCodeUtil
    {
        #region :: GetPostCode :: PostCode를 가져옵니다.

        /// <summary>
        /// PostCode를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-10-20 최초생성 : 김정우(삼성전기)
        /// </remarks>
        public static DataTable GetPostCode()
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.PostCode_Get";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetPostProcessCode :: 각 Post에 해당되는 ProcessCode를 가져옵니다.

        /// <summary>
        /// 각 Post에 해당되는 ProcessCode를 가져옵니다.
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        /// <remark>
        /// 2009-10-20 최초생성 : 김정우(삼성전기)
        /// </remark>
        public static DataTable GetPostProcessCode(int post)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.PostProcessCode_Get";

                string[] paramList = new string[] { "@Post" };
                object[] valueList = new object[] { post };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetDeliverCode :: DeliverCode를 가져옵니다.

        /// <summary>
        /// DeliverCode를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remark>
        /// 2009-10-22 최초생성 : 김정우(삼성전기)
        /// </remark>
        public static DataTable GetDeliverCode()
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.DeliverCode_Get";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetNOTPostProcessCode :: 포스트 등록가능 공정 가져 오기

        /// <summary>
        /// 포스트 등록가능 공정 가져 오기
        /// </summary>
        /// <param name="Post">포스트번호</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-10-21 최초생성 유효진
        /// </remarks>
        public static DataTable GetNOTPostProcessCode(int Post)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.NOTPostProcessCode_Get";

                string[] paramList = new string[] { "@Post" };
                object[] valueList = new object[] { Post };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetProcessStationCode :: 해당공정의 사내설비를 가져옮니다.

        /// <summary>
        /// 해당공정의 사내설비를 가져옮니다.
        /// </summary>
        /// <param name="gProcessCode">공정코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-10-21 최초생성 유효진
        /// </remarks>
        public static DataTable GetProcessStationCode(string gProcessCode)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.PostStationCode_Get";

                string[] paramList = new string[] { "@Value" };
                object[] valueList = new object[] { gProcessCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetProcessStationCode :: 해당공정의 포스트를 가져옮니다.

        /// <summary>
        /// 해당공정의 post를 가져온다.
        /// </summary>
        /// <param name="gProcessCode">공정코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2010-1-15 최초생성 최경수
        /// </remarks>
        public static DataTable GetProcessPost(string gProcessCode)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.ProcessPost_Get";

                string[] paramList = new string[] { "@ProcessCode" };
                object[] valueList = new object[] { gProcessCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }


        #endregion

        #region :: GetNotProcessesStations :: 해당공정의 등록되지 않은사내설비를 가져옮니다.

        /// <summary>
        /// 해당공정의 등록되지 않은사내설비를 가져옮니다.
        /// </summary>
        /// <param name="nProcessCode">공정코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-10-21 최초생성 유효진
        /// </remarks>
        public static DataTable GetNotPostProcessesStations(string nProcessCode)
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.NOTPostStationCode_Get";

                string[] paramList = new string[] { "@Value" };
                object[] valueList = new object[] { nProcessCode };

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, paramList, valueList).Tables[0];
            }

            return dt;
        }

        #endregion

        #region :: GetPosetStatus :: 물류이동 시스템에서 사용하는 Status를 가져옵니다.

        /// <summary>
        /// Status를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2010-04-26 최초생성 : 김태호(삼성전기)
        /// </remarks>
        public static DataTable GetPostStatus()
        {
            DataTable dt = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "pmms.PostHistoryStatus";

                dt = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTMESDB, query, AppConfig.COMMANDSP, null, null).Tables[0];
            }

            return dt;
        }

        #endregion

    }
}