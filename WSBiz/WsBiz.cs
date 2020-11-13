using System;
using System.Data;
using TLF.Framework.Compaction;
using TLF.Data.Factory;

namespace TLF.Business.WSBiz
{
    /// <summary>
    /// Web Service Business를 담당할 Class입니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-08 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class WsBiz : IDisposable
    {
        #region :: 생성자 ::
        
        /// <summary>
        /// Web Biz를 생성합니다.
        /// </summary>
        /// <param name="url">Web Service URL입니다.</param>
        public WsBiz(string url)
        {
            _webUrl = url;
        } 

        #endregion

        #region :: 전역변수 ::

        private string _webUrl = string.Empty;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Interface Implementation(IDisposable Member)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Dispose ::

        /// <summary>
        /// Ws Biz 종료자를 호출하지 않도록 합니다.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Assembly 관련)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AssemblyUpload :: Assembly를 Web Server로 전송합니다.
        
        /// <summary>
        /// Assembly를 Web Server로 전송합니다.
        /// </summary>
        /// <param name="uploadPath">UploadPath 정보</param>
        /// <param name="fileName">파일명</param>
        /// <param name="fileByte">Byte Array</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        //public int AssemblyUpload(string uploadPath, string fileName, byte[] fileByte)
        //{
        //    try
        //    {
        //        using (SqlFactory wsProxy = new SqlFactory(_webUrl))
        //        {
        //            return wsProxy.AssemblyUpload(uploadPath, fileName, fileByte);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //} 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Database Query 관련)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        //#region :: NTx_ExecuteDataSet(+1 Overloading) :: 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        
        ///// <summary>
        ///// 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        ///// </summary>
        ///// <param name="dbName">DB 연결정보</param>
        ///// <param name="command">Command String</param>
        ///// <param name="cmdType">Command Type</param>
        ///// <param name="paramList">Command Parameters</param>
        ///// <param name="valueList">Command Parameters Values</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 2009-01-08 최초생성 : 황준혁
        ///// 변경내역
        ///// 
        ///// </remarks>
        //public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        //{
        //    try
        //    {
        //        using (WSProxy wsProxy = new WSProxy(_webUrl))
        //        {
        //            object[] outValue = new object[] { };

        //            return wsProxy.NTx_ExecuteDataSet(dbName, command, cmdType, paramList, valueList, null, ref outValue);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}         

        ///// <summary>
        ///// 쿼리를 실행하여 DataSet을 반환하는 Web Method를 실행합니다.
        ///// </summary>
        ///// <param name="dbName">DB 연결정보</param>
        ///// <param name="command">Command String</param>
        ///// <param name="cmdType">Command Type</param>
        ///// <param name="paramList">Command Parameters</param>
        ///// <param name="valueList">Command Parameters Values</param>
        ///// <param name="outParam"></param>
        ///// <param name="outValue"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 2009-01-08 최초생성 : 황준혁
        ///// 변경내역
        ///// 
        ///// </remarks>
        //public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        //{
        //    try
        //    {
        //        using (WSProxy wsProxy = new WSProxy(_webUrl))
        //        {
        //            return wsProxy.NTx_ExecuteDataSet(dbName, command, cmdType, paramList, valueList, outParam, ref outValue);
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //#endregion

        #region :: NTx_ExecuteDataSet(+1 Overloading) :: 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                object[] outValue = new object[] { };

                return wsProxy.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, null, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 DataSet을 압축하여 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataSet NTx_ExecuteDataSet(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);

                return wsProxy.NTx_ExecuteDataSet(command, cmdType, paramList, valueList, outParam, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        #endregion



        #region :: NTx_ExecuteScalar(+1 Overloading) :: 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                object[] outValue = new object[] { };

                return wsProxy.NTx_ExecuteScalar(command, cmdType, paramList, valueList, null, ref outValue);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 object을 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public object NTx_ExecuteScalar(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                return wsProxy.NTx_ExecuteScalar(command, cmdType, paramList, valueList, outParam, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: Tx_ExecuteNonQuery(+1 Overloading) :: 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                object[] outValue = new object[] { };

                return wsProxy.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList, null, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 쿼리를 실행하여 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam"></param>
        /// <param name="outValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public int Tx_ExecuteNonQuery(string dbName, string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                return wsProxy.Tx_ExecuteNonQuery(command, cmdType, paramList, valueList, outParam, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: Tx_ExecuteNonQueryByDataTable :: DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string dbName, string command, string cmdType, string[] paramList, DataTable dt)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                object[] outValue = new object[] { };

                return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, null, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DataTable을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <param name="outParam">Output Parameters</param>
        /// <param name="outValue">Output ParametersValue</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string dbName, string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);
            }
            catch
            {
                throw;
            }
        } 

        #endregion


        #region :: Tx_ExecuteNonQueryByDataRow :: DataRow을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.

        /// <summary>
        /// DataRow을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataRow)</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataRow(string dbName, string command, string cmdType, string[] paramList, DataRow dr)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                object[] outValue = new object[] { };

                DataTable dt = new DataTable();
                dt = dr.Table.Clone();
                dt.ImportRow(dr);

                return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, null, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DataRow을 사용하여 쿼리를 실행하여 Multi 처리하고 영향을 받은 Row 수를 반환하는 Web Method를 실행합니다.
        /// </summary>
        /// <param name="dbName">DB 연결정보</param>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataRow)</param>
        /// <param name="outParam">Output Parameters</param>
        /// <param name="outValue">Output ParametersValue</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataRow(string dbName, string command, string cmdType, string[] paramList, DataRow dr, string[] outParam, ref object[] outValue)
        {
            try
            {
                SqlFactory wsProxy = new SqlFactory(_webUrl);
                DataTable dt = new DataTable();
                dt = dr.Table.Clone();
                dt.ImportRow(dr);

                return wsProxy.Tx_ExecuteNonQueryByDataTable(command, cmdType, paramList, dt, outParam, ref outValue);
            }
            catch
            {
                throw;
            }
        }

        #endregion
    
    }
}

namespace TLF.Business.WSBiz
{
    public class WsBiz : IDisposable
    {
        private object dEFAULTDB;

        public WsBiz(object dEFAULTDB)
        {
            this.dEFAULTDB = dEFAULTDB;
        }
    }
}