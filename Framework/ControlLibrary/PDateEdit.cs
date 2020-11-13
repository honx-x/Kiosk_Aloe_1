using System;
using System.ComponentModel;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;
using System.Windows.Forms;

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
    public partial class PDateEdit : DevExpress.XtraEditors.DateEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Date Edit Control을 생성합니다.
        /// </summary>
        public PDateEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private Control _toDateControl = null;
        private bool _enableClear = false;
        private bool _checkModify = false;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ToDateControl :: 종료일 Control을 지정합니다.
        
        /// <summary>
        /// 종료일 Control을 지정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("종료일 Control을 지정합니다."), Browsable(true)]
        public Control ToDateControl
        {
            get { return _toDateControl; }
            set { _toDateControl = value; }
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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnEditValueChanged :: 종료일 컨트롤이 지정됐을 경우 시작일이 종료일보다 크면 시작일을 종료일로 설정합니다.

        /// <summary>
        /// 종료일 컨트롤이 지정됐을 경우 시작일이 종료일보다 크면 시작일을 종료일로 설정합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            if (_toDateControl != null)
            {
                PDateEdit de = _toDateControl as PDateEdit;

                if (DateTime > de.DateTime)
                    de.DateTime = DateTime;
            }
            base.OnEditValueChanged();
        }

        #endregion

        #region :: OnEditorLeave :: Focus를 잃을 때 현재값과 이전값을 비교한다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEditorLeave(EventArgs e)
        {
            base.OnEditorLeave(e);

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
