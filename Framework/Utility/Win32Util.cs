using System;
using System.Runtime.InteropServices;
using System.Text;
using TLF.Framework.Config;

namespace TLF.Framework.Utility
{
    /// <summary>
    /// Application에서 사용할 Win32 Util Method를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class Win32Util
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function & Interop - Define
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Private Profile String :: 파일에 설정을 읽거나 씁니다.

        /// <summary>
        /// 설정을 파일에 저장합니다.
        /// </summary>
        /// <param name="lpAppName">대분류</param>
        /// <param name="lpKeyName">소분류</param>
        /// <param name="lpString">저장 값</param>
        /// <param name="lpFileName">파일 경로(전체)</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// 설정을 파일에서 가져옵니다.
        /// </summary>
        /// <param name="lpAppName">대분류</param>
        /// <param name="lpKeyName">소분류</param>
        /// <param name="lpDefault">기본값</param>
        /// <param name="lpReturnedString">읽어올 값을 저장할 StringBuilder</param>
        /// <param name="nSize">값의 크기</param>
        /// <param name="lpFileName">파일 경로(전체)</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        #endregion

        #region :: InternetGetConnectedState :: 인터넷 연결 상태를 확인합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpdwFlags"></param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        [DllImport("WININET", CharSet = CharSet.Auto)]
        public static extern bool InternetGetConnectedState(ref InternetConnectionState lpdwFlags, int dwReserved);

        #endregion

        #region :: PlaySound ::

        /// <summary>
        /// Play Sound
        /// </summary>
        /// <param name="szPath"></param>
        /// <param name="hModule"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        [DllImport("coredll.dll")]
        public static extern int PlaySound(string szPath, IntPtr hModule, int flags);
        
        #endregion
    }
}
