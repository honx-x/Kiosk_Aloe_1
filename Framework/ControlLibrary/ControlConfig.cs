using System.Drawing;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// Control Library에서 사용할 Configuration 정보를 정의합니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    internal class ControlConfig
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Font 및 Color, Width, Height
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Font And Color, Width, Height ::

        /// <summary>
        /// Application에서 사용할 기본 Font입니다.
        /// Value : new Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)))
        /// </summary>
        internal static readonly Font DEFAULTFONT = new Font("맑은 고딕", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color ADDEDROWCOLOR = Color.FromArgb(50, 192, 50);
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color MODIFIEDROWCOLOR = Color.FromArgb(160, 160, 160);
        /// <summary>
        /// 
        /// </summary>
        internal static readonly Color FOCUSEDROWCOLOR = Color.FromArgb(50, 0, 0, 230);

        /// <summary>
        /// Contorl의 기본 높이
        /// Value : 21
        /// </summary>
        internal const int DEFAULTHEIGHT = 21;

        /// <summary>
        /// Control의 기본 너비
        /// Value : 120
        /// </summary>
        internal const int DEFAULTWIDTH = 120;

        #endregion
    }
}
