using System;

namespace TLF.Framework.Interface
{
    /// <summary>
    /// Command 관련 Interface입니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-07 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public interface ICommand
    {
        /// <summary>
        /// Item을 클릭했을 때 발생합니다.
        /// </summary>
        /// <param name="itemName">Item Name</param>
        void Item_Click(string itemName);
    }
}
