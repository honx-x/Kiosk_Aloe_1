using System.ComponentModel;
using TLF.Framework.Config;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2009-01-10 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PLabelEdit : DevExpress.XtraEditors.LabelControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Label Edit를 생성합니다.
        /// </summary>
        public PLabelEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: EnableClear :: 일괄 초기화 여부를 설정합니다.

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("일괄 초기화 여부를 설정합니다."), Browsable(true)]
        public bool EnableClear
        {
            get { return _enableClear; }
            set
            {
                _enableClear = value;

                Tag = _enableClear ? AppConfig.CLEARTAG : null;
            }
        }

        #endregion
    }
}
