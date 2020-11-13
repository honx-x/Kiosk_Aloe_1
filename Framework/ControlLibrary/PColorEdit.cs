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
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PColorEdit : DevExpress.XtraEditors.ColorEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// ColorEdit Control을 생성합니다.
        /// </summary>
        public PColorEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private object _oldValue = null;
        private bool _checkModify = false;

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

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

        #region :: OnEditorEnter :: Focus를 가지면 _oldValue에 현재값을 넣는다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnEditorEnter(EventArgs e)
        {
            base.OnEditorEnter(e);

            this._oldValue = this.EditValue;
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
                if (_oldValue != this.EditValue)
                {
                    (this.FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion
    }
}
