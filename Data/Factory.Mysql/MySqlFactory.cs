using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Configuration;
using System.Windows;
using System.Windows.Forms;

namespace TLF.Data.Factory.Mysql
{
    /// <summary>
    /// 실제 Transaction을 발생시키는 Sql Factory 클래스입니다.
    /// Microsoft.Practices.EnterpriseLibrary 4.1을 사용합니다.
    /// </summary>
    /// <remarks>
    /// 2019-07-25 최초생성 : 김성제
    /// 변경내역
    /// 
    /// </remarks>
    public class MySqlFactory
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Sql Helper를 생성합니다.
        /// </summary>
        /// <param name="connectionStr">연결문자열</param>
        public MySqlFactory(string connectionStr)
        {
            // db = DatabaseFactory.CreateDatabase(connectionStr);
            try {
                string connectString = "Database=Test;Server=localhost;UID=root;Pwd=2357;";

                myconn = new MySqlConnection();

                if (connectionStr != null)
                {
                    myconn.ConnectionString = connectionStr;
                }
                else
                {
                    myconn.ConnectionString = connectString;
                }
                
                // 오류 내용 : 구성 시스템을 초기화하지 못했습니다.
                // myconn.ConnectionString = ConfigurationManager.ConnectionStrings[connectionStr].ConnectionString;
                // db = DatabaseFactory.CreateDatabase(connectString);

            }
            catch (ConfigurationErrorsException eee)
            {
                MessageBox.Show(eee.Message);
            }

            
            // ConfigurationSettings.AppSettings[]

            
        }

        #endregion

        #region :: 전역변수 ::

        // private Database db = null;

        private MySqlConnection myconn = null;

        #endregion

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

            MySqlCommand dbCommand = new MySqlCommand(command, myconn);

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    dbCommand.CommandType = CommandType.Text;
                    break;
                default:
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
            dbCommand.CommandTimeout = 300;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (valueList[idx] != null && paramList[idx] != null)
                    {
                        dbCommand.Parameters.Add(paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]));
                        dbCommand.Parameters[paramList[idx]].Direction = ParameterDirection.Input;
                        dbCommand.Parameters[paramList[idx]].Value = valueList[idx];
                    }
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    dbCommand.Parameters.Add(outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]));
                    dbCommand.Parameters[outParam[idx]].Value = outValue[idx];
                }
            }

            if (myconn != null && myconn.State == ConnectionState.Closed)
            {
                myconn.Open();
            }

            MySqlDataReader dataReader = dbCommand.ExecuteReader();
            ds.Tables.Add();
            ds.Tables[0].Load(dataReader);

            // ds = db.ExecuteDataSet(dbCommand);

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outParam[idx] = dbCommand.Parameters[outParam[idx]].Value.ToString();
                }
            }

            myconn.Close();

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

            MySqlCommand dbCommand = new MySqlCommand(command, myconn);

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    // dbCommand = (MySqlCommand)db.GetStoredProcCommand(command);
                    break;
                case "Text":
                    dbCommand.CommandType = CommandType.Text;
                    // dbCommand = (MySqlCommand)db.GetSqlStringCommand(command);
                    break;
                default:
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    // dbCommand = (MySqlCommand)db.GetStoredProcCommand(command);
                    break;
            }
            dbCommand.CommandTimeout = 300;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (valueList[idx] != null && paramList[idx] != null)
                    {
                        // db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]), valueList[idx]);
                        dbCommand.Parameters.Add(paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]));
                        dbCommand.Parameters[paramList[idx]].Direction = ParameterDirection.Input;
                        dbCommand.Parameters[paramList[idx]].Value = valueList[idx];
                    }
                        
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    // db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                    dbCommand.Parameters.Add(outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]));
                    dbCommand.Parameters[outParam[idx]].Value = outValue[idx];
                }
            }

            try
            {
                if (myconn != null && myconn.State == ConnectionState.Closed)
                {
                    myconn.Open();
                }

                retObject = dbCommand.ExecuteScalar();
                //retObject = db.ExecuteScalar(dbCommand);
            }
            catch
            {
                throw;
            }

            myconn.Close();

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    // outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx]);
                    outParam[idx] = dbCommand.Parameters[outParam[idx]].Value.ToString();
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

            MySqlCommand dbCommand = new MySqlCommand(command, myconn);

            switch (cmdType)
            {
                case "StoredProcedure":
                    // dbCommand = db.GetStoredProcCommand(command);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    // dbCommand = db.GetSqlStringCommand(command);
                    dbCommand.CommandType = CommandType.Text;
                    break;
                default:
                    // dbCommand = db.GetStoredProcCommand(command);
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
            dbCommand.CommandTimeout = 300;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            if (paramList != null)
            {
                for (int idx = 0; idx < paramList.Length; idx++)
                {
                    if (valueList[idx] != null && paramList[idx] != null)
                    {
                        dbCommand.Parameters.Add(paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]));
                        dbCommand.Parameters[paramList[idx]].Direction = ParameterDirection.Input;
                        dbCommand.Parameters[paramList[idx]].Value = valueList[idx];
                        // db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(valueList[idx]), valueList[idx]);
                    }
                        
                }
            }

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    dbCommand.Parameters.Add(outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]));
                    dbCommand.Parameters[outParam[idx]].Direction = ParameterDirection.Output;
                    // db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx], DataRowVersion.Current, outValue[idx]);
                }
            }

            if (myconn != null && myconn.State == ConnectionState.Closed)
            {
                myconn.Open();
            }

            MySqlTransaction dbTran = myconn.BeginTransaction();

            try
            {
                retValue = dbCommand.ExecuteNonQuery();
                dbTran.Commit();
            }
            catch
            {
                dbTran.Rollback();

                throw;
            }

            //using (DbConnection connection = db.CreateConnection())
            //{
            //    connection.Open();
            //    DbTransaction dbTran = connection.BeginTransaction();

            //    try
            //    {
            //        retValue = db.ExecuteNonQuery(dbCommand, dbTran);

            //        dbTran.Commit();
            //    }
            //    catch
            //    {
            //        dbTran.Rollback();

            //        throw;
            //    }

            //    connection.Close();
            //}

            if (outParam != null)
            {
                for (int idx = 0; idx < outParam.Length; idx++)
                {
                    outValue[idx] = dbCommand.Parameters[outParam[idx]].Value;
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

            //2019-07-30 임시 수정(이상윤)
            //MySqlCommand dbCommand = null;
            MySqlCommand dbCommand = new MySqlCommand(command, myconn);

            switch (cmdType)
            {
                case "StoredProcedure":
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
                case "Text":
                    dbCommand.CommandType = CommandType.Text;
                    break;
                default:
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    break;
            }
            dbCommand.CommandTimeout = 300;
            dbCommand.UpdatedRowSource = UpdateRowSource.Both;

            if (myconn != null && myconn.State == ConnectionState.Closed)
            {
                myconn.Open();
            }

            MySqlTransaction dbTran = myconn.BeginTransaction();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (paramList != null)
                    {
                        for (int idx = 0; idx < paramList.Length; idx++)
                        {
                            if (paramList[idx] != null && paramList[idx].Length != 0)
                            {
                                //2019-07-30 임시 수정(이상윤)
                                //dbCommand.Parameters.Add(paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(dt.Columns[paramList[idx].Replace("@", "").Trim()]));
                                //dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Direction = ParameterDirection.Input;
                                //dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Value = dr[paramList[idx].Replace("@", "").Trim()];
                                dbCommand.Parameters.Add(paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(dt.Columns[paramList[idx].Replace("p_", "").Trim()]));
                                //if (paramList[idx].Replace("p_", "").Trim() == "UserName") {
                                //    MessageBox.Show("나는 " + dr[paramList[idx].Replace("p_", "").Trim()] +  " 입니다.");
                                //}
                                dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Direction = ParameterDirection.Input;

                                // Byte[] byTemp = Encoding.Default.GetBytes(dr[paramList[idx].Replace("p_", "").Trim()].ToString());
                                // String strTemp = Encoding.UTF8.GetString(byTemp);

                                dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Value = dr[paramList[idx].Replace("p_", "").Trim()];

                                // dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Value = dr[paramList[idx].Replace("p_", "").Trim()].ToString();

                                //  dbCommand.Parameters[paramList[idx].Trim().Replace("\t", "")].Value = strTemp;
                            }
                        }
                    }

                    if (outParam != null)
                    {
                        for (int idx = 0; idx < outParam.Length; idx++)
                        {
                            dbCommand.Parameters.Add(outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]));
                            dbCommand.Parameters[outParam[idx]].Direction = ParameterDirection.Output;
                        }
                    }

                    retValue = dbCommand.ExecuteNonQuery();
                    if (outParam != null)
                    {
                        for (int idx = 0; idx < outParam.Length; idx++)
                        {
                            outValue[idx] = dbCommand.Parameters[outParam[idx]].Value;
                        }
                    }

                    if (dbCommand.Parameters.Count > 0)
                    {
                        dbCommand.Parameters.Clear();
                    }

                    dt.AcceptChanges();
                    dbTran.Commit();
                }
            }
            catch
            {
                dbTran.Rollback();
                throw;
            }
            myconn.Close();


            //using (MySqlConnection connection = (MySqlConnection)db.CreateConnection())
            //{
            //    connection.Open();
            //    MySqlTransaction dbTran = connection.BeginTransaction();

            //    try
            //    {
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            if (paramList != null)
            //            {
            //                for (int idx = 0; idx < paramList.Length; idx++)
            //                {
            //                    if (paramList[idx] != null && paramList[idx].Length != 0)
            //                        db.AddInParameter(dbCommand, paramList[idx].Trim().Replace("\t", ""), GetParameterDbType(dt.Columns[paramList[idx].Replace("@", "").Trim()]), dr[paramList[idx].Replace("@", "").Trim()]);
            //                }
            //            }

            //            if (outParam != null)
            //            {
            //                for (int idx = 0; idx < outParam.Length; idx++)
            //                {
            //                    if (outValue[idx] != null)
            //                        db.AddParameter(dbCommand, outParam[idx].Trim().Replace("\t", ""), GetParameterDbType(outValue[idx]), ParameterDirection.InputOutput, outParam[idx].Trim(), DataRowVersion.Current, outValue[idx]);
            //                }
            //            }

            //            retValue += db.ExecuteNonQuery(dbCommand, dbTran);

            //            if (outParam != null)
            //            {
            //                for (int idx = 0; idx < outParam.Length; idx++)
            //                {
            //                    outValue[idx] = db.GetParameterValue(dbCommand, outParam[idx].ToString());
            //                }
            //            }

            //            if (dbCommand.Parameters.Count > 0)
            //                dbCommand.Parameters.Clear();
            //        }
            //        dt.AcceptChanges();
            //        dbTran.Commit();
            //    }
            //    catch
            //    {
            //        dbTran.Rollback();

            //        throw;
            //    }

            //    connection.Close();
            //}

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
        private MySqlDbType GetParameterDbType(DataColumn value)
        {
            try
            {
                if (value.DataType.Equals(Type.GetType("System.Byte[]")))
                {
                    return MySqlDbType.Binary;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
                {
                    return MySqlDbType.Decimal;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
                {
                    return MySqlDbType.Int64;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
                {
                    return MySqlDbType.Int32;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
                {
                    return MySqlDbType.Int16;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
                {
                    return MySqlDbType.Int16;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
                {
                    return MySqlDbType.DateTime;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
                {
                    return MySqlDbType.Int16;
                }
                else
                {
                    return MySqlDbType.String;
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
        private MySqlDbType GetParameterDbType(object value)
        {
            try
            {
                if (value.GetType().Equals(Type.GetType("System.Byte[]")))
                {
                    return MySqlDbType.Binary;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
                {
                    return MySqlDbType.Decimal;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
                {
                    return MySqlDbType.Int64;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
                {
                    return MySqlDbType.Int32;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
                {
                    return MySqlDbType.Int16;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
                {
                    return MySqlDbType.DateTime;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
                {
                    return MySqlDbType.Int16;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
                {
                    return MySqlDbType.Int16;
                }
                else
                {
                    return MySqlDbType.String;
                }
            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region :: GetParameterDbType :: 파라미터의 값에 따라 MySqlDbType을 정의합니다.

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
        private MySqlDbType GetParameterMysqlDbType(DataColumn value)
        {
            try
            {
                if (value.DataType.Equals(Type.GetType("System.Byte[]")))
                {
                    return MySqlDbType.Binary;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
                {
                    return MySqlDbType.Decimal;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
                {
                    return MySqlDbType.Int64;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
                {
                    return MySqlDbType.Int32;
                }
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
                {
                    return MySqlDbType.Int16;
                }
                //else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
                //{
                //     return MySqlDbType.Single;
                //}
                else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
                {
                    return MySqlDbType.DateTime;
                }
                //else if (value.DataType.Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
                //{
                //    return MySqlDbType.Boolean;
                //}
                else
                {
                    return MySqlDbType.String;
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
        private MySqlDbType GetParameterMysqlDbType(object value)
        {
            try
            {
                if (value.GetType().Equals(Type.GetType("System.Byte[]")))
                {
                    return MySqlDbType.Binary;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Decimal))))
                {
                    return MySqlDbType.Decimal;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int64))))
                {
                    return MySqlDbType.Int64;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int32))))
                {
                    return MySqlDbType.Int32;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Int16))))
                {
                    return MySqlDbType.Int16;
                }
                else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.DateTime))))
                {
                    return MySqlDbType.DateTime;
                }
                //else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Single))))
                //{
                //    return MySqlDbType.Single;
                //}
                //else if (value.GetType().Equals(Type.GetType(String.Format("System.{0}", TypeCode.Boolean))))
                //{
                //    return MySqlDbType.Boolean;
                //}
                else
                {
                    return MySqlDbType.String;
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
