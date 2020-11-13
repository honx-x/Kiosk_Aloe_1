using System;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PCheckButtonEdit : DevExpress.XtraEditors.CheckButton
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Check Button Control을 생성합니다.
        /// </summary>
        /// <param name="check"></param>
        public PCheckButtonEdit(bool check)
            : base(check)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Check Button Control을 생성합니다.
        /// </summary>
        public PCheckButtonEdit()
        {
            InitializeComponent();
        }

        #endregion
    }
}
