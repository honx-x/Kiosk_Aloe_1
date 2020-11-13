using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Management;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TLF.Framework.Config;
using TLF.Framework.MessageHelper;
using System.Collections;
using System.ComponentModel;
using Microsoft.Win32.SafeHandles;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using TLF.Framework.Class;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraGrid;
using TLF.Framework.Utility;
using DevExpress.Utils;

namespace TLF.Framework.Utility
{
    /// <summary>
    /// Application에서 사용할 Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public static class AppUtil
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function & Interop - Define
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateInstanceForm :: Form을 생성합니다.

        /// <summary>
        /// Form을 생성합니다.
        /// </summary>
        /// <param name="dllPath">DLL 명</param>
        /// <param name="className">Class 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static Form CreateInstanceForm(string dllPath, string className)
        {
            Form form;

            string assemblyFile = AppDomain.CurrentDomain.BaseDirectory + dllPath;

            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            Type formType = assembly.GetType(className);

            form = (Form)Activator.CreateInstance(formType);

            return form;
        } 

        #endregion

        #region :: CreateInstanceUserControl :: User Control을 생성합니다.

        /// <summary>
        /// User Control을 생성합니다.
        /// </summary>
        /// <param name="dllPath">DLL 명</param>
        /// <param name="className">Class 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static UserControl CreateInstanceUserControl(string dllPath, string className)
        {
            UserControl uc;

            string assemblyFile = AppDomain.CurrentDomain.BaseDirectory + dllPath;

            Assembly assembly = Assembly.LoadFrom(assemblyFile);
            Type formType = assembly.GetType(className);

            uc = (UserControl)Activator.CreateInstance(formType);

            return uc;
        }  

        #endregion

        #region :: ExecuteMethod(+1 Overloading) :: Form의 Method를 실행합니다.

        /// <summary>
        /// Form의 Method를 실행합니다.
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="methodName">Method 이름</param>
        /// <returns></returns>
        public static object ExecuteMethod(Form form, string methodName)
        {
            return ExecuteMethod(form, methodName, null);
        }

        /// <summary>
        /// Form의 Method를 실행합니다.
        /// </summary>
        /// <param name="form">Form</param>
        /// <param name="methodName">Method 이름</param>
        /// <param name="methodParam">Method Parameters</param>
        /// <returns></returns>
        public static object ExecuteMethod(Form form, string methodName, object[] methodParam)
        {
            object obj;
            MethodInfo mInfo = form.GetType().GetMethod(methodName);

            if (mInfo != null)
                obj = mInfo.Invoke(form, methodParam);
            else
                obj = null;

            return obj;
        } 

        #endregion

        #region :: FindControl :: 지정한 형식의 Control을 찾습니다.
        
        /// <summary>
        /// 지정한 형식의 Control을 찾습니다.
        /// </summary>
        /// <param name="ctrlList"></param>
        /// <param name="control"></param>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static void FindControl(List<Control> ctrlList, Control control, string controlType)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl.GetType().FullName == controlType && (ctrl.Focused || ctrl.Parent.Focused))
                        ctrlList.Add(ctrl);

                    FindControl(ctrlList, ctrl, controlType);
                }
            }
        } 

        #endregion

        #region :: GetConnectType :: IP Address가 166, 16.3, 16.4, 16.100, 16.161 일 경우 사내 아닐 경우 사외로 구분

        /// <summary>
        /// IP Address가 166, 16.3, 16.4, 16.100, 16.161 일 경우 사내 아닐 경우 사외로 구분
        /// </summary>
        /// <param name="ip">IP Address</param>
        /// <returns>사내일 경우 IntraNet, 사외일 경우 DMZ</returns>
        public static string GetConnectType(object ip)
        {
            //if (ip.Length > 4)
            //{
            //    if (ip.Substring(0, 3) == "166" || ip.Substring(0, 4) == "16.3" || ip.Substring(0, 4) == "16.4"
            //    || ip.Substring(0, 6) == "16.100" || ip.Substring(0, 6) == "16.161")
            //        return "IntraNet";
            //    else if (ip.Substring(0, 7) == "109.100")
            //        return "Kunshan";
            //    else
            //        return "DMZ";
            //}
            //else
            return "IntraNet";
        }

        #endregion

        #region :: GetImage :: Image를 가져옵니다.

        /// <summary>
        /// Image를 가져옵니다.
        /// </summary>
        /// <param name="rootPath">Root Path</param>
        /// <param name="subPath">Sub Path</param>
        /// <param name="fileName">File 명</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static Image GetImage(string rootPath, string subPath, string fileName)
        {
            Image image = null;

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    Stream stream = webClient.OpenRead(String.Format("{0}{1}/{2}", rootPath, subPath, fileName));
                    image = Image.FromStream(stream);
                    stream.Dispose();
                }
            }
            catch
            {
                throw;
            }

            return image;
        }

        #endregion

        #region :: GetBlankParam :: 빈공간의 파라미터를 만들때 사용합니다.

        /// <summary>
        /// 빈공간의 파라미터를 만들때 사용합니다.
        /// </summary>
        /// <param name="length">파라미터 길이</param>
        /// <returns></returns>
        public static string GetBlankParam(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
                sb.Insert(i, "X");

            return sb.ToString();
        }

        #endregion

        #region :: GetMacAddress :: 로컬 컴퓨터의 MAC Address를 가져옵니다.

        /// <summary>
        /// 로컬 컴퓨터의 MAC Address를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static string GetMacAddress()
        {
            string macAddr = string.Empty;
            try
            {
                ObjectQuery oq = new ObjectQuery("SELECT NetConnectionStatus, MacAddress FROM Win32_NetworkAdapter");

                using (ManagementObjectSearcher query1 = new ManagementObjectSearcher(oq))
                {
                    foreach (ManagementObject mo in query1.Get())
                    {
                        if (mo["NetConnectionStatus"] == Convert.DBNull)
                            continue;

                        if (Convert.ToInt32(mo["NetConnectionStatus"]) == 2)
                        {
                            macAddr = mo["MACAddress"].ToString();
                            break;
                        }
                    }
                }
            }
            catch
            {
                macAddr = string.Empty;
            }

            return macAddr;
        } 

        #endregion

        #region :: GetProperty :: Form의 Property Data를 가져옵니다.

        /// <summary>
        /// Form의 Property Data를 가져옵니다.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static object GetProperty(Form form, string propertyName)
        {
            PropertyInfo propertyInfo = form.GetType().GetProperty(propertyName);
            return propertyInfo.GetValue(form, null);
        }

        #endregion

        #region :: OpenFile :: 파일 실행
        
        /// <summary>
        /// 파일 실행
        /// </summary>
        /// <param name="fileName">파일명</param>
        public static void OpenFile(string fileName)
        {
            if (MsgBox.Show("이 파일을 실행 하시겠습니까?", "File 실행 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                {
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Verb = "Open";
                    process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                    process.Start();
                }
            }
            catch
            {
                throw;
            }
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // DataSet 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AddColumn :: DataTable에 컬럼을 추가합니다.

        /// <summary>
        ///  DataTable에 컬럼을 추가합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cols"></param>
        public static void AddColumn(DataTable dt, string[] cols)
        {
            if (dt == null) dt = new DataTable();

            Array.ForEach(cols, col =>
            {
                if (!dt.Columns.Contains(col))
                    dt.Columns.Add(col);
            });

            dt.AcceptChanges();
        }

        #endregion
                
        #region :: AddDataColumnWithValue :: DataTable에 컬럼을 추가하면서 일괄적으로 값을 입력합니다.

        /// <summary>
        /// DataTable에 컬럼을 추가하면서 일괄적으로 값을 입력합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cols"></param>
        /// <param name="values"></param>
        public static void AddDataColumnWithValue(DataTable dt, string[] cols, object[] values)
        {
            if (dt == null) dt = new DataTable();

            Array.ForEach(cols, col =>
            {
                if (!dt.Columns.Contains(col))
                    dt.Columns.Add(col);
            });

            foreach (DataRow row in dt.Rows)
            {
                for (int idx = 0; idx < cols.Length; idx++)
                    row[cols[idx]] = values[idx];
            }

            dt.AcceptChanges();
        }

        #endregion

        #region :: CheckDataTableValue :: 데이터 테이블의 값을 검사하여 같은 값이 있으면 False를 Return합니다.

        /// <summary>
        /// 데이터 테이블의 값을 검사하여 같은 값이 있으면 False를 Return합니다.
        /// </summary>
        /// <param name="dt">대상 DataTable</param>
        /// <param name="cols">검사할 Columns</param>
        /// <param name="value">검사 Value</param>
        /// <param name="check">같은 값 : True, 다른 값 : False</param>
        /// <returns></returns>
        public static bool CheckDataTableValue(DataTable dt, string[] cols, object value, bool check)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (string col in cols)
                {
                    if ((dr[col].ToString() == value.ToString()) == check)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region :: CopyColumnData :: Column Data를 복사합니다.

        /// <summary>
        /// Column Data를 복사합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void CopyColumnData(DataTable dt, string source, string target)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr[target] = dr[source];
            }
            dt.AcceptChanges();
        }

        #endregion

        #region :: GetColumnsFromDataTable :: DataTable에서 Column을 가져옵니다.

        /// <summary>
        /// DataTable에서 Column을 가져옵니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string[] GetColumnsFromDataTable(DataTable dt)
        {
            List<string> columnFields = new List<string>();

            foreach (DataColumn dc in dt.Columns)
            {
                columnFields.Add(dc.ColumnName);
            }

            return columnFields.ToArray();
        }

        #endregion

        #region :: MakeDataTableScheme :: DataTable Scheme를 생성합니다.

        /// <summary>
        /// DataTable Scheme를 생성합니다.
        /// </summary>
        /// <param name="ds">기본으로 생성된 DataSet</param>
        /// <param name="cols">Column Field</param>
        /// <returns></returns>
        public static DataTable MakeDataTableScheme(DataSet ds, params string[] cols)
        {
            DataTable dt = new DataTable();

            Array.ForEach(cols, col =>
            {
                dt.Columns.Add(col);
                if (col == AppConfig.CHECKCOLUMNNAME)
                    dt.Columns[col].DataType = typeof(bool);
            });

            if (ds != null)
            {
                foreach (DataTable dsTable in ds.Tables)
                    dt.Merge(dsTable, false, MissingSchemaAction.Ignore);
            }

            return dt;
        }

        /// <summary>
        /// DataTable Scheme를 생성합니다.
        /// </summary>
        /// <param name="dt">기본으로 생성된 DataTable</param>
        /// <param name="cols">Column Field</param>
        /// <returns></returns>
        public static DataTable MakeDataTableScheme(DataTable dt, params string[] cols)
        {
            DataTable dataTable = new DataTable();

            Array.ForEach(cols, col => dataTable.Columns.Add(col));

            if (dt != null)
                dataTable.Merge(dt, false, MissingSchemaAction.Ignore);

            return dataTable;
        }

        #endregion

        #region :: RemoveDataColumn :: DataTable 컬럼을 삭제합니다.

        /// <summary>
        /// DataTable 컬럼을 삭제합니다.
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="match"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static DataTable RemoveDataColumn(DataTable dt, bool match, params string[] cols)
        {
            DataTable dataTable = dt.Clone();

            dataTable.Merge(dt, false, MissingSchemaAction.Ignore);

            foreach (DataColumn colm in dt.Columns)
            {
                Array.ForEach(cols, col =>
                {
                    if (match == colm.ColumnName.Contains(col))
                        dataTable.Columns.Remove(colm.ColumnName);
                });
            }

            return dataTable;
        }

        #endregion

        #region :: RemoveDataRow :: DataTable의 Columns에서 같은 값을 찾아 있으면 해당 Row를 삭제합니다.

        /// <summary>
        /// DataTable의 Columns에서 같은 값을 찾아 있으면 해당 Row를 삭제합니다.
        /// </summary>
        /// <param name="dt">해당 DataTable</param>
        /// <param name="column">해당 컬럼</param>
        /// <param name="value">찾을 값</param>
        public static void RemoveDataRow(DataTable dt, string column, object value)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[column].ToString() == value.ToString())
                    dr.Delete();
            }
            dt.AcceptChanges();
        }

        #endregion

        #region :: SetColumnValue :: DataTable의 특정 컬럼에 지정한 값을 입력합니다.

        /// <summary>
        /// DataTable의 특정 컬럼에 지정한 값을 입력합니다.
        /// </summary>
        /// <param name="dt">대상 DataTable</param>
        /// <param name="col">Column Name</param>
        /// <param name="value">Value</param>
        public static void SetColumnValue(DataTable dt, string col, object value)
        {
            foreach (DataRow row in dt.Rows)
            {
                row[col] = value;
            }
            dt.AcceptChanges();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Path 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateFolder :: Folder Path를 확인하여 없으면 Folder를 만듭니다.

        /// <summary>
        /// Folder Path를 확인하여 없으면 Folder를 만듭니다.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFolder(string path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(path);

            if (dInfo.Exists) return;

            dInfo.Create();
        }

        #endregion

        #region :: GetAppFullPath :: 현재 프로그램의 전체 경로를 가져옵니다.

        /// <summary>
        /// 현재 프로그램의 전체 경로를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        public static String GetAppFullPath()
        {
            string fullAppFolderPath = string.Empty;

            string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;
            string fullAppPath = Path.GetDirectoryName(fullAppName);
            fullAppFolderPath = fullAppPath;

            return fullAppFolderPath;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Internet 연결 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InterNetAble :: Internet 연결 상태를 확인하여 ON / OFF Line 여부를 반환합니다.

        /// <summary>
        /// Internet 연결 상태를 확인하여 ON / OFF Line 여부를 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static string InterNetAble()
        {
            InternetConnectionState flags = 0;
            string strInetState = (Win32Util.InternetGetConnectedState(ref flags, 0) ? "ON-LINE" : "OFF-LINE");

            return strInetState;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Security 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: GetMD5Hash :: 암호화 된 MD5 Text를 가져옵니다.

        /// <summary>
        /// 암호화 된 MD5 Text를 가져옵니다..
        /// </summary>
        /// <param name="input">입력값</param>
        /// <returns></returns>
        public static string GetMD5Hash(string input)
        {
            MD5 md = MD5.Create();
            byte[] data = md.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int idx = 0; idx < data.Length; idx++)
                sb.Append(data[idx].ToString("x2"));

            return sb.ToString();
        }

        #endregion

        #region :: ValidateMd5Hash :: MD5를 검증합니다.

        /// <summary>
        /// MD5를 검증합니다.
        /// </summary>
        /// <param name="input">입력값</param>
        /// <param name="hash">해쉬 코드값(DB 저장 값)</param>
        /// <returns></returns>
        public static bool ValidateMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMD5Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash) ? true : false;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // String 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Left(+1 Overloading) :: 해당 문자열을 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.

        /// <summary>
        /// 해당 문자열을 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <returns></returns>
        public static string Left(string s, int length)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            return s.Substring(0, length);
        }

        /// <summary>
        /// 해당 문자열을 지정된 Encoding에 맞춰 왼쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <param name="isAscii">ASCII 코드 길이로 계산할지 지정합니다.</param>
        /// <returns></returns>
        public static string Left(string s, int length, bool isAscii)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            if (!isAscii) return s.Substring(0, length);

            byte[] sBuff = Encoding.Unicode.GetBytes(s);
            byte[] uBuff = Encoding.Convert(Encoding.Unicode, Encoding.Default, sBuff);

            return uBuff.Length < length ? Encoding.Default.GetString(uBuff) : Encoding.Default.GetString(uBuff, 0, length);
        }

        #endregion

        #region :: Right :: 해당 문자열을 오른쪽에서부터 지정된 길이만큼 나누어 반환합니다.

        /// <summary>
        /// 해당 문자열을 오른쪽에서부터 지정된 길이만큼 나누어 반환합니다.
        /// </summary>
        /// <param name="s">해당 문자열</param>
        /// <param name="length">문자열을 나눌 길이</param>
        /// <returns></returns>
        public static string Right(string s, int length)
        {
            if (String.IsNullOrEmpty(s) || length > s.Length || length < 0)
                return s;

            return s.Substring(s.Length - length);
        }

        #endregion

        #region :: Split :: 해당 문자열을 Split 하여 문자열 배열로 반환합니다.

        /// <summary>
        /// 해당 문자열을 Split 하여 문자열 배열로 반환합니다.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string[] Split(string s, string separator)
        {
            return s.Split(separator.ToCharArray());
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Validate 관련
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ValidateCRN :: 법인번호 Validation

        /// <summary>
        /// 법인번호 Validation
        /// </summary>
        /// <param name="value">법인번호</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-19 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static bool ValidateCRN(string value)
        {
            int total = 0;
            int key = 1;
            string sValue = value.Replace("-", "");

            if (sValue.Length != 13)
                return false;

            char[] arrayCRN = sValue.ToCharArray();

            for (int i = 0; i < 12; i++)
            {
                key = i % 10 == 0 ? 1 : 2;

                total += Convert.ToInt32(arrayCRN[i].ToString()) * key;
            }

            total = (10 - (total % 10)) % 10;

            return Convert.ToInt32(arrayCRN[12].ToString()) == total ? true : false;
        } 

        #endregion

        #region :: ValidateERN :: 사업자등록번호 Validation

        /// <summary>
        /// 사업자등록번호 Validation
        /// </summary>
        /// <param name="value">사업자등록번호</param>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-19 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static bool ValidateERN(string value)
        {
            int[] arrayKey = new int[] { 1, 3, 7, 1, 3, 7, 1, 3, 5 };
            int[] arrayERN = new int[10];
            int[] arrayTemp = new int[10];
            int total = 0;
            int flag;

            string sValue = value.Replace("-", "");

            if (sValue.Length != 10)
                return false;

            for (int i = 0; i < 10; i++)
                arrayERN[i] = Convert.ToInt32(sValue[i].ToString());

            for (int i = 0; i < 9; i++)
            {
                if (i == 8 && arrayTemp[i] >= 10)
                {
                    string temp = arrayTemp[i].ToString();
                    arrayTemp[i] = 0;
                    arrayTemp[i] += Convert.ToInt32(temp.Substring(0, 1));
                    arrayTemp[i] += Convert.ToInt32(temp.Substring(1, 1));
                }
                arrayTemp[i] = arrayTemp[i] >= 10 ? arrayTemp[i] % 10 : arrayERN[i] * arrayKey[i];

                total += arrayTemp[i];
            }

            flag = total % 10 != 0 ? 10 - (total % 10) : 0;

            return flag == arrayERN[9] ? true : false;
        } 

        #endregion

        #region :: ValidateRRN :: 주민등록번호 Validation

        /// <summary>
        /// 주민등록번호 Validation
        /// </summary>
        /// <param name="value">주민등록번호</param>
        /// <returns>True : 맞음, False : 틀림</returns>
        /// <remarks>
        /// 2009-01-19 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static bool ValidateRRN(string value)
        {
            int total = 0;
            string sValue = value.Replace("-", "");

            if (sValue.Length != 13)
                return false;

            char[] arrayRRN = sValue.ToCharArray();

            for (int i = 0; i < 12; i++)
            {
                total += i < 8 ? Convert.ToInt32(arrayRRN[i].ToString()) * (i + 2) : Convert.ToInt32(arrayRRN[i].ToString()) * (i - 8 + 2);
            }

            total = (11 - (total % 11)) % 10;

            return Convert.ToInt32(arrayRRN[12].ToString()) == total ? true : false;
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Etc
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PlaySound :: Sound를 Play 합니다.

        /// <summary>
        /// Sound를 Play 합니다.
        /// </summary>
        /// <param name="soundFilePath">Path(파일명.확장자 포함)</param>
        public static void PlaySound(string soundFilePath)
        {
            Win32Util.PlaySound(soundFilePath, IntPtr.Zero, (int)(PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_ASYNC));
        }

        #endregion

        #region :: GetWeekNum :: 입력받은 날짜의 주차를 계산한다.(일욜 기준)
        /// <summary>
        /// 입력 받은 날짜의 주차 계산(일요일을 시작점으로 잡음)
        /// </summary>
        /// <param name="curDateTime">입력 날짜</param>
        /// <returns></returns>
        public static int GetWeekNum(DateTime curDateTime)
        {
            int intDayNumber = curDateTime.DayOfYear;
            int intDayStartNumber = 0;
            DateTime WeekStartDate = new DateTime();
            DateTime WeekEndDate = new DateTime();
            int WeekNumber;

            switch (curDateTime.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    intDayStartNumber = intDayNumber;
                    WeekStartDate = curDateTime;
                    WeekEndDate = curDateTime.AddDays(6);
                    break;
                case DayOfWeek.Monday:
                    intDayStartNumber = intDayNumber - 1;
                    WeekStartDate = curDateTime.AddDays(-1);
                    WeekEndDate = curDateTime.AddDays(5);
                    break;
                case DayOfWeek.Tuesday:
                    intDayStartNumber = intDayNumber - 2;
                    WeekStartDate = curDateTime.AddDays(-2);
                    WeekEndDate = curDateTime.AddDays(4);
                    break;
                case DayOfWeek.Wednesday:
                    intDayStartNumber = intDayNumber - 3;
                    WeekStartDate = curDateTime.AddDays(-3);
                    WeekEndDate = curDateTime.AddDays(3);
                    break;
                case DayOfWeek.Thursday:
                    intDayStartNumber = intDayNumber - 4;
                    WeekStartDate = curDateTime.AddDays(-4);
                    WeekEndDate = curDateTime.AddDays(2);
                    break;
                case DayOfWeek.Friday:
                    intDayStartNumber = intDayNumber - 5;
                    WeekStartDate = curDateTime.AddDays(-5);
                    WeekEndDate = curDateTime.AddDays(1);
                    break;
                case DayOfWeek.Saturday:
                    intDayStartNumber = intDayNumber - 6;
                    WeekStartDate = curDateTime.AddDays(-6);
                    WeekEndDate = curDateTime;
                    break;
            }

            WeekNumber = intDayStartNumber / 7;

            if (WeekStartDate.Year > curDateTime.AddYears(-1).Year)
            {
                WeekNumber += 1;

                int intDivideWeekNumber = intDayStartNumber % 7;

                if (intDivideWeekNumber != 0)
                    WeekNumber += 1;

                if (curDateTime.Year == WeekEndDate.AddYears(-1).Year)
                {
                    WeekEndDate = WeekEndDate.AddDays((-1) * WeekEndDate.DayOfYear);
                }
            }
            else
            {
                WeekNumber = 1;
                intDayStartNumber = (-1) * intDayStartNumber + 1;
                WeekStartDate = WeekStartDate.AddDays(intDayStartNumber);
            }

            return WeekNumber;
        }
        #endregion

		/// <summary>
		/// ZPL 코드를 라벨발행기로 출력
		/// </summary>
		/// <param name="strPort">발행포트</param>
		/// <param name="strZPL">ZPL내용</param>
		/// <returns></returns>
		public static void PrintZPL(string strPort, string strZPL)
		{
			switch (strPort.Substring(0, 3))
			{
				case "USB":
					RawPrinterHelper.SendStringToPrinter(strPort, strZPL);
					break;
				case "COM":
					SerialPort SP = new System.IO.Ports.SerialPort(strPort, 9600, Parity.None, 8, StopBits.One);
					try
					{
						SP.Open();
					}
					catch (Exception ex)
					{
						return;
					}
					StringBuilder DataString = new StringBuilder();
					try
					{
						if (!SP.IsOpen) SP.Open();
					}
					catch (Exception ex)
					{
						return;
					}
					DataString.Append(strZPL);
					try
					{
						SP.WriteLine(DataString.ToString());
					}
					catch (Exception ex)
					{
						return;
					}
					break;
				case "LPT":
					TextWriter sw = new StreamWriter(@"C:\ZPL.TXT");
					sw.WriteLine(strZPL);
					sw.Close();

					System.Diagnostics.Process process = new System.Diagnostics.Process();
					System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
					startInfo.FileName = "CMD.exe";
					startInfo.WorkingDirectory = @"D:\";

					startInfo.UseShellExecute = false;
					startInfo.RedirectStandardInput = true;
					startInfo.RedirectStandardOutput = true;
					startInfo.RedirectStandardError = true;
					startInfo.CreateNoWindow = true;
					startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

					process.EnableRaisingEvents = false;
					process.StartInfo = startInfo;
					process.Start();
					process.StandardInput.Write(@"COPY C:\ZPL.TXT " + strPort + Environment.NewLine);
					process.StandardInput.Close();

					process.WaitForExit();
					process.Close();
					break;
				case "SCR":
					MsgBox.Show(strZPL, "ZPL 출력 내용", MessageBoxButtons.OK);
					break;
				default:
					RawPrinterHelper.SendStringToPrinter(strPort, strZPL);
					break;

			}
		}

		/// <summary>
		/// 현재 포커스된 컨트롤 확인
		/// </summary>
		/// <param name="strPort">container</param>
		/// <returns>Control</returns>
		public static Control FindFocusedControl(Control container)
		{
			foreach (Control childControl in container.Controls)
			{
				if (childControl.Focused)
				{
					return childControl;
				}
			}

			foreach (Control childControl in container.Controls)
			{
				Control maybeFocusedControl = FindFocusedControl(childControl);
				if (maybeFocusedControl != null)
				{
					return maybeFocusedControl;
				}
			}
			return null; // Couldn't find any, darn!
		}

		/// <summary>
		/// 현재 포커스된 그리드 확인
		/// </summary>
		/// <param name="strPort">Control</param>
		/// <returns>string 그리드명</returns>
		public static string GetFocusedGridName(Control control)
		{
			string strControlName = string.Empty;

			List<Control> gridList = new List<Control>();

			FindControl(gridList, control, "TLF.Framework.ControlLibrary.PGridControl");
			FindControl(gridList, control, "TLF.Framework.ControlLibrary.PPivotGridControl");

			foreach (Control grid in gridList)
			{
				//if (grid is GridControl)
				//	strControlName = (grid as GridControl).Name;
				//if (grid is PivotGridControl)
				//	strControlName = (grid as PivotGridControl).Name;
				strControlName = grid.Name;
			}
			return strControlName;
		}

        /// <summary>
        /// 파일경로를 가져와서 Byte 배열로 return
        /// </summary>
        /// <param name="filePath">실제 파일이 있는 경로</param>
        /// <returns></returns>
        public static byte[] GetFileToByteArr(string filePath)
        {
            byte[] fByte = null;

            FileStream fStream = null;
            BinaryReader bReader = null;

            if (!string.IsNullOrEmpty(filePath))
            {
                fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                bReader = new BinaryReader(fStream);
                //fByte = bReader.ReadBytes(Convert.ToInt32(fStream.Length));
                fByte = bReader.ReadBytes(Convert.ToInt32(fStream.Length));
            }

            return fByte;


        }
    }
}
