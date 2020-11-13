using System;
using System.Data;

namespace TLF.Framework.Interface
{
    /// <summary>
    /// Web Service에서 사용할 Method를 정의한 Interface입니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-30 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public interface IWebMethod
    {
        /// <summary>
        /// 시스템 코드를 가져옵니다.
        /// </summary>
        /// <param name="group">대그룹 코드</param>
        /// <param name="condition">소그룹 코드</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-30 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        DataTable GetSystemCode(string group, string condition);
    }
}
