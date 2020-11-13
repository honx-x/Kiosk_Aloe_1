using System;
using System.ComponentModel;
using TLF.Framework.Config;
using TLF.Framework.BaseFrame;

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
    public partial class PSpinEdit : DevExpress.XtraEditors.SpinEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SpinEdit Control을 생성합니다.
        /// </summary>
        public PSpinEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;

        private int _decimalPlace = 0;

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

        #region :: DecimalPlace :: 소숫점 자리수를 설정합니다.

        /// <summary>
        /// 소숫점 자리수를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("소숫점 자리수를 설정합니다."), Browsable(true)]
        public int DecimalPlace
        {
            get { return _decimalPlace; }
            set { _decimalPlace = value;
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            Properties.Mask.EditMask = "n" + _decimalPlace;
            }
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

            if (!_checkModify || !IsModified) return;
            
            (FindForm() as UIFrame).IsModified = true;
        }

        #endregion
    }
}
