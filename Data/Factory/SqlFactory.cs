using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TLF.Data.Factory
{
    /// <summary>
    /// 실제 Transaction을 발생시키는 Sql Factory 클래스입니다.
    /// Microsoft.Practices.EnterpriseLibrary 4.1을 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-08 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class SqlFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Sql Helper를 생성합니다.
        /// </summary>
        /// <param name="connectionStr">연결문자열</param>
        public SqlFactory(string connectionStr)
        {
            db = DatabaseFactory.CreateDatabase(connectionStr);
        } 

        #endregion
        
        #region :: 전역변수 ::

        private Database db = null;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: NTx_ExecuteDataSet :: Transaction이 없는 일반 Query로 DataSet을 Return 하는 Method입니다.
        
        /// <summary>
        /// Transaction이 없는 일반 Query 및 SP 를 담당하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public DataSet NTx_ExecuteDataSet(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            DataSet ds = new DataSet();

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 300;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
					if(valueList[idx] != null && paramList[idx] != null)
						db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
					db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                }
            }

            ds = db.ExecuteDataSet(dbCommand);

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                }
            }

            return ds;
        } 

        #endregion

        #region :: NTx_ExecuteScalar ::  Transaction이 없는 일반 Query로 단일 값을 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 없는 일반 Query로 단일 값을 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public object NTx_ExecuteScalar(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            object retObject = null;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 300;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
					if (valueList[idx] != null && paramList[idx] != null)
						db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
					db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                }
            }

            retObject = db.ExecuteScalar(dbCommand);

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                }
            }

            return retObject;
        }

        #endregion

        #region :: Tx_ExecuteNonQuery ::  Transaction이 있는 Query로 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 단일 Query로 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="valueList">Command Parameters Values</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQuery(string command, string cmdType, string[] paramList, object[] valueList, string[] outParam, ref object[] outValue)
        {
            int retValue = -1;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 300;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
					if (valueList[idx] != null && paramList[idx] != null)
						db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t",""), GetParameterDbType(valueList[idx]), valueList[idx]);
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
					db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                }
            }

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction dbTran = connection.BeginTransaction();

                try
                {
                    retValue = db.ExecuteNonQuery(dbCommand, dbTran);

                    dbTran.Commit();
                }
                catch
                {
                    dbTran.Rollback();

                    throw;
                }

                connection.Close();
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                }
            }

            return retValue;
        }

        #endregion

        #region :: Tx_ExecuteNonQueryByDataTable :: Transaction이 있는 Query로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.

        /// <summary>
        /// Transaction이 있는 Query로 DataTable을 사용하여 Multi 처리하고 영향을 받은 Row 수를 Return 하는 Method입니다.
        /// </summary>
        /// <param name="command">Command String</param>
        /// <param name="cmdType">Command Type</param>
        /// <param name="paramList">Command Parameters</param>
        /// <param name="dt">Command Parameters Values(DataTable)</param>
        /// <param name="outParam">Command Out Parameters</param>
        /// <param name="outValue">Command Out Parameters Values</param>
        /// <returns></returns>
        public int Tx_ExecuteNonQueryByDataTable(string command, string cmdType, string[] paramList, DataTable dt, string[] outParam, ref object[] outValue)
        {
            int retValue = 0;

            DbCommand dbCommand = null;

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand = db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 300;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction dbTran = connection.BeginTransaction();

                try
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (paramList != null)
                        {
                            for (int idx = 0; idx < paramList.Length; idx++)
                            {
								if (paramList[idx] != null && paramList[idx].Length!=0)
									db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(dt.Columns[paramList[idx].Replace("@", "").Trim()]), dr[paramList[idx].Replace("@", "").Trim()]);
                            }
                        }

                        if (outParam != null)
                        {
                            for (int idx = 0; idx < outParam.Length; idx++)
                            {
								if (outValue[idx] != null)
									db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx].Trim(), DataRowVersion.Current, outValue[idx]);
                            }
                        }

                        retValue += db.ExecuteNonQuery(dbCommand, dbTran);

                        if (outParam != null)
                        {
                            for (int idx = 0; idx < outParam.Length; idx++)
                            {
                                outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx].ToString());
                            }
                        }

                        if (dbCommand.Parameters.Count > 0)
                            dbCommand.Parameters.Clear();
                    }
                    dt.AcceptChanges();
                    dbTran.Commit();
                }
                catch
                {
                    dbTran.Rollback();

                    throw;
                }

                connection.Close();
            }

            return retValue;
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetParameterDbType :: 파라미터의 값에 따라 DbType을 정의합니다.
        
        /// <summary>
        /// 파라미터의 값에 따라 DbType을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private DbType GetParameterDbType(DataColumn value)
        {
			try
			{
				if (value.DataType.Equals(Type.GetType("System.Byte[]")))
				{
					return DbType.Binary;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
				{
					return DbType.Decimal;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
				{
					return DbType.Int64;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
				{
					return DbType.Int32;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
				{
					return DbType.Int16;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
				{
					return DbType.Single;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
				{
					return DbType.DateTime;
				}
				else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
				{
					return DbType.Boolean;
				}
				else
				{
					return DbType.String;
				}
			}
			catch
			{
				throw;
			}
        }

        /// <summary>
        /// 파라미터의 값에 따라 DbType을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private DbType GetParameterDbType(object value)
        {
			try
			{
				if (value.GetType().Equals(Type.GetType("System.Byte[]")))
				{
					return DbType.Binary;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
				{
					return DbType.Decimal;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
				{
					return DbType.Int64;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
				{
					return DbType.Int32;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
				{
					return DbType.Int16;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
				{
					return DbType.DateTime;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
				{
					return DbType.Single;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
				{
					return DbType.Boolean;
				}
				else
				{
					return DbType.String;
				}
			}
			catch
			{
				throw;
			}

        } 

        #endregion

        #region :: GetParameterSize :: 파라미터의 값에 따라 Size을 정의합니다.
        
        /// <summary>
        /// 파라미터의 값에 따라 Size을 정의합니다.
        /// </summary>
        /// <param name="value">파라미터의 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private int GetParameterSize(object value)
        {
			try
			{
				if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.String))))
				{
					return value.ToString().Length;
				}
				else if (value.GetType().Equals(Type.GetType("System.Byte[]")))
				{
					return 8000;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
				{
					return 8;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
				{
					return 4;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
				{
					return 2;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
				{
					return 8;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
				{
					return 8;
				}
				else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
				{
					return 1;
				}
				else
				{
					return value.ToString().Length;
				}
			}
			catch
			{
				throw;
			}

        } 

        #endregion
    }
}
