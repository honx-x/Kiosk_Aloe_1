using System;
using System.ComponentModel;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-17 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PTextButtonEdit : DevExpress.XtraEditors.ButtonEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextButtonEdit Control을 생성합니다.
        /// </summary>
        public PTextButtonEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;

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

        #region :: CheckModify :: EditValue의 변경 Check 여부를 설정합니다.

        /// <summary>
        /// EditValue의 변경 Check 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("EditValue의 변경 Check 여부를 설정합니다."), Browsable(true)]
        public bool CheckModify
        {
            get { return _checkModify; }
            set { _checkModify = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLostFocus :: Focus를 잃을 때 현재값과 이전값을 비교한다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (_checkModify)
            {
                if (this.IsModified)
                {
                    (this.FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion
    }
}
