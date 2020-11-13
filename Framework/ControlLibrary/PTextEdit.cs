using System;
using System.ComponentModel;
using TLF.Framework.Config;
using TLF.Framework.BaseFrame;
using DevExpress.Utils;
using System.Drawing;

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
    public partial class PTextEdit : DevExpress.XtraEditors.TextEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextEdit Control을 생성합니다.
        /// </summary>
        public PTextEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;
        private bool _enterKeySelectEvent = false;

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

        #region :: EnterKeySelectEvent :: Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.

        /// <summary>
        /// Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다."), Browsable(true)]
        public bool EnterKeySelectEvent
        {
            get { return _enterKeySelectEvent; }
            set { 
                _enterKeySelectEvent = value;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetSuperToolTip :: ToolTip을 설정합니다.

        /// <summary>
        /// ToolTip을 설정합니다.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="contents"></param>
        public void SetSuperToolTip(string title, string contents)
        {
            SuperToolTip sTip = new SuperToolTip();
            ToolTipTitleItem tTitle = new ToolTipTitleItem();
            ToolTipItem tContents = new ToolTipItem();
            tTitle.Text = title;
            tContents.Text = contents;
            tContents.LeftIndent = 6;
            sTip.Items.Add(tTitle);
            sTip.Items.Add(tContents); SuperTip = sTip;

        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown :: Enter Key를 입력하면 조회 이벤트를 실행합니다.

        /// <summary>
        /// Enter Key를 입력하면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!_enterKeySelectEvent || e.KeyCode != System.Windows.Forms.Keys.Enter) return;

            (FindForm() as UIFrame).OnSelectionEvent();
        }

        #endregion        
        
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
                if (IsModified)
                {
                    (FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion        
    }
}