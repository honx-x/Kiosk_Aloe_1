using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using TLF.Framework.Applications;
using TLF.Framework.Authentication;
using TLF.Framework.Collections;
using TLF.Framework.Config;
using TLF.Framework.MessageHelper;
using TLF.Framework.Utility;
using TLF.Framework.Localization;
using DevExpress.XtraBars;
using TLF.Business.WSBiz;

namespace TLF.Framework.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-19 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class UIFrame : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// UIFrame을 생성합니다.
        /// </summary>
        public UIFrame()
        {
            InitializeComponent();
        } 

        #endregion
        
        #region :: 전역변수 ::

        string _helpPath = string.Empty;
        string _menuID = string.Empty;
        string _className = string.Empty;
        bool _isModified = false;

        bool _selectAuth = false;
        bool _newAuth = false;
        bool _saveAuth = false;
        bool _delAuth = false;
        bool _printAuth = false;
        bool _chartAuth = false;
		bool _downAuth = false;
		bool _ImportAuth = false;

        LinkEventParams _linkParams;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ClassCaption :: Class Caption을 설정합니다.

        /// <summary>
        /// Class Name을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Class Name을 설정합니다."), Browsable(false)]
        public string ClassName
        {
            get { return _className; }
            set {
                _className = value;
                (MdiParent as MainFrame).ClassCaption = value; 
            }
        }

        #endregion

        #region :: CurrentUser :: 현재 사용자의 정보를 설정합니다.
        
        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("현재 사용자의 정보를 설정합니다."), Browsable(false)]
        public UserInformation CurrentUser
        {
            get { return (MdiParent as MainFrame).CurrentUser; }
        } 

        #endregion

        #region :: HelpPath :: 도움말 파일의 경로입니다.
        
        /// <summary>
        /// 도움말 파일의 경로입니다.
        /// </summary>
        public string HelpPath
        {
            get { return _helpPath; }
            set { _helpPath = value; }
        } 

        #endregion

        #region :: LinkParams :: Form 간 통신 시에 사용할 Parameter
        
        /// <summary>
        /// Form 간 통신 시에 사용할 Parameter
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Form 간 통신 시에 사용할 Parameter"), Browsable(false)]
        public LinkEventParams LinkParams
        {
            get { return _linkParams; }
            set { _linkParams = value; }
        } 

        #endregion

        #region :: MessageCaption :: Message Caption을 설정합니다.

        /// <summary>
        /// Message Caption을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Message Caption을 설정합니다."), Browsable(false)]
        public string MessageCaption
        {
            get { return MdiParent == null ? "" : (MdiParent as MainFrame).MessageCaption; }
            set {
                (MdiParent as MainFrame).MessageCaption = value;
                (MdiParent as MainFrame).IsSetMessage = false;
            }
        }

        #endregion

        #region :: MenuID :: MENU ID 입니다.
        
        /// <summary>
        /// MENU ID 입니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("MENU ID 입니다."), Browsable(false)]
        public string MenuID
        {
            get { return _menuID; }
            set { _menuID = value; }
        } 

        #endregion

        #region :: IsModified :: 수정여부를 저장합니다.

        /// <summary>
        /// 수정여부를 저장합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("수정여부를 저장합니다."), Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }
            set
            {
                _isModified = value;
                (MdiParent as MainFrame).IsModified = value;
            }
        } 

        #endregion

        #region :: 권한 설정 ::

        /// <summary>
        /// 조회권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("조회권한을 설정합니다."), Browsable(false)]
        public bool SelectAuth
        {
            get { return _selectAuth; }
            set { _selectAuth = value; }
        }

        /// <summary>
        /// 신규권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("신규권한을 설정합니다."), Browsable(false)]
        public bool NewAuth
        {
            get { return _newAuth; }
            set { _newAuth = value; }
        }

        /// <summary>
        /// 저장권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("저장권한을 설정합니다."), Browsable(false)]
        public bool SaveAuth
        {
            get { return _saveAuth; }
            set { _saveAuth = value; }
        }

        /// <summary>
        /// 삭제권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("삭제권한을 설정합니다."), Browsable(false)]
        public bool DelAuth
        {
            get { return _delAuth; }
            set { _delAuth = value; }
        }

        /// <summary>
        /// 인쇄권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("인쇄권한을 설정합니다."), Browsable(false)]
        public bool PrintAuth
        {
            get { return _printAuth; }
            set { _printAuth = value; }
        }

        /// <summary>
        /// 차트권한을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("차트권한을 설정합니다."), Browsable(false)]
        public bool ChartAuth
        {
            get { return _chartAuth; }
            set { _chartAuth = value; }
        }

		/// <summary>
		/// 파일다운로드 권한을 설정합니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("파일 다운로드 권한을 설정합니다."), Browsable(false)]
		public bool DownAuth
		{
			get { return _downAuth; }
			set { _downAuth = value; }
		}


		/// <summary>
		/// 자료 가져오기 권한을 설정합니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("자료 가져오기 권한을 설정합니다."), Browsable(false)]
		public bool ImportAuth
		{
			get { return _ImportAuth; }
			set { _ImportAuth = value; }
		}

		#endregion

        #region :: localizer :: 다국어 지원에 사용할 Localizer

        /// <summary>
        /// 다국어 지원에 사용할 Localizer
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("다국어 지원에 사용할 Localizer"), Browsable(false)]
        public Localizer localizer
        {
            get { return (MdiParent as MainFrame).localizer; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Delegate
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Authentication :: 사용자 권한 설정 시에 사용합니다.

        /// <summary>
        /// 사용자 권한 설정 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("사용자 권한 설정 시에 사용합니다."), Browsable(true)]
        public event EventHandler Authentication; 

        #endregion

        #region :: Chart :: Chart 출력 이벤트 발생 시에 사용합니다.
        
        /// <summary>
        /// Chart 출력 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("Chart 출력 이벤트 발생 시에 사용합니다."), Browsable(true)]
        public event EventHandler Chart; 

        #endregion

        #region :: Delete :: 삭제 이벤트 발생 시에 사용합니다.
        
        /// <summary>
        /// 삭제 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("삭제 이벤트 발생 시에 사용합니다."), Browsable(true)]
        public event EventHandler Delete; 

        #endregion

        #region :: Link :: Form간 통신시에 사용합니다.

        /// <summary>
        /// Form간 통신시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("Form간 통신 시에 사용합니다."), Browsable(true)]
        public event EventHandler Link;

        #endregion

        #region :: New :: 추가 이벤트 발생 시에 사용합니다.
        
        /// <summary>
        /// 추가 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("추가 이벤트 발생 시에 사용합니다."), Browsable(true)]
        public event EventHandler New; 

        #endregion

        #region :: Print :: 출력 이벤트 발생 시에 사용합니다.
        
        /// <summary>
        /// 출력 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("출력 이벤트 발생 시에 사용합니다."), Browsable(true)]
        public event EventHandler Print; 

        #endregion

        #region :: Save :: 저장 이벤트 발생 시에 사용합니다.
        
        /// <summary>
        /// 저장 이벤트 발생 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("저장 이벤트 발생 시에 사용합니다."), Browsable(true)]
        public event EventHandler Save; 

        #endregion

		#region :: Selection :: 조회 이벤트 발생 시에 사용합니다.

		/// <summary>
		/// 조회 이벤트 발생 시에 사용합니다.
		/// </summary>
		[Category(AppConfig.EVENTCATEGORY)]
		[Description("조회 이벤트 발생 시에 사용합니다."), Browsable(true)]
		public event EventHandler Selection;

		#endregion

		#region :: Import :: 자료 가져오기 이벤트 발생 시에 사용합니다.

		/// <summary>
		/// 자료 가져오기 이벤트 발생 시에 사용합니다.
		/// </summary>
		[Category(AppConfig.EVENTCATEGORY)]
		[Description("자료 가져오기 이벤트 발생 시에 사용합니다."), Browsable(true)]
		public event EventHandler Import;

		#endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckModify :: 변경내역을 Check 하여 변경 내역이 있으면 통보합니다.

        /// <summary>
        /// 변경내역을 Check 하여 변경 내역이 있으면 통보합니다.
        /// </summary>
        /// <returns></returns>
        public bool CheckModify()
        {
            if (!IsModified)
                return true;

            if (MsgBox.Show(MsgMap.CK_DATA_MODIFY_CONTINUE, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
            {
                IsModified = false;
                return true;
            }
            else
                return false;
        }
        #endregion

        #region :: OnAuthenticationEvent :: Authentication Event를 강제로 발생시킵니다.

        /// <summary>
        /// Authentication Event를 강제로 발생시킵니다.
        /// </summary>
        public void OnAuthenticationEvent()
        {
            if (Authentication != null) { Authentication(this, new EventArgs()); }
        }

        #endregion

        #region :: OnSelectionEvent :: Selection Event를 강제로 발생시킵니다.

        /// <summary>
        /// Selection Event를 강제로 발생시킵니다.
        /// </summary>
        public void OnSelectionEvent()
        {
            if (Selection != null) { Selection(this, new EventArgs()); }
        }

        #endregion
        
        #region :: OnLinkEvent :: Link Event를 강제로 발생시킵니다.

        /// <summary>
        /// Link Event를 강제로 발생시킵니다.
        /// </summary>
        public void OnLinkEvent()
        {
            if (Link != null) { Link(this, new EventArgs()); }
        }

        #endregion
                
        #region :: SetRibbonBarButtonEnabled :: 이벤트에 따라 Ribbon Button Enabled 설정하기

        /// <summary>
        /// 이벤트에 따라 Ribbon Button Enabled 설정하기
        /// </summary>
        public void SetRibbonBarButtonEnabled()
        {
            if (MdiParent == null) return;

            (MdiParent as MainFrame).Ribbon.Items["iSelect"].Enabled = (Selection != null && SelectAuth);
            (MdiParent as MainFrame).Ribbon.Items["iNew"].Enabled = (New != null && NewAuth);
            (MdiParent as MainFrame).Ribbon.Items["iSave"].Enabled = (Save != null && SaveAuth);
            (MdiParent as MainFrame).Ribbon.Items["iDelete"].Enabled = (Delete != null && DelAuth);
            (MdiParent as MainFrame).Ribbon.Items["iPrint"].Enabled = (Print != null && PrintAuth);
			(MdiParent as MainFrame).Ribbon.Items["iChart"].Enabled = (Chart != null && ChartAuth);
			(MdiParent as MainFrame).Ribbon.Items["iImport"].Enabled = (Import != null && ImportAuth);
		}

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Protected)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ClearText(+1 Overloading) :: UI Form의 Control을 찾아서 Text를 Cleare 합니다.

        /// <summary>
        /// UI Form의 Control을 찾아서 Text를 Cleare 합니다.
        /// </summary>
        /// <remarks>
        /// 2009-01-10 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        protected void ClearText()
        {
            ClearText(this);
        }

        /// <summary>
        /// 지정한 Control의 하위 Control을 찾아서 Text를 Cleare 합니다.
        /// </summary>
        /// <param name="control">지정 Control</param>
        protected void ClearText(Control control)
        {
            if (control.HasChildren)
            {
                foreach (Control ctrl in control.Controls)
                {
                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PTextEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = "";
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PDateEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = DateTime.Now;
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PPictureEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = null;
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PMultiComboBoxEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = "";
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PCheckedComboBoxEdit")
                    {
                        if (ctrl.Tag == null)
                            continue;

                        if (ctrl.Tag.ToString() != AppConfig.CLEARTAG)
                            continue;

                        (ctrl as CheckedComboBoxEdit).SetEditValue("");
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PComboBoxEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = "";
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PSpinEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = 0;
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PMemoEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = "";
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PFileEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as BaseEdit).EditValue = "";
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PGridControl")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as GridControl).DataSource = null;
                        }
                    }

                    if (ctrl.GetType().FullName == "TLF.Framework.ControlLibrary.PChartEdit")
                    {
                        if (ctrl.Tag != null)
                        {
                            if (ctrl.Tag.ToString() == AppConfig.CLEARTAG)
                                (ctrl as ChartControl).DataSource = null;
                        }
                    }

                    ClearText(ctrl);
                }
            }
            else
                return;
        }

        #endregion

        #region :: ExecutePopup :: Popup Form을 생성합니다.

        /// <summary>
        /// Popup Form을 생성합니다.
        /// </summary>
        /// <param name="text">Form Text</param>
        /// <param name="ds">Code 값으로 사용할 DataSet(없으면 null)</param>
        /// <returns>[0] : 사유, [1] : 코드 (Length가 0 보다 큰지 Check 해야 한다.)</returns>
        public string[] ExecutePopup(string text, DataSet ds)
        {
            List<string> values = new List<string>();

            using (frmPopup fPopup = new frmPopup(localizer) { Text = text, CodeDataSet = ds })
            {
                if (fPopup.ShowDialog(this) != DialogResult.OK)
                    return values.ToArray();

                values.Add(fPopup.Description);
                values.Add(fPopup.CodeValue);
            }

            return values.ToArray();
        }

        #endregion

        #region :: ExecuteUI :: Link UI를 실행합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="linkParams">Link Event Parameters</param>
        public void ExecuteUI(object menuID, LinkEventParams linkParams)
        {
            (MdiParent as MainFrame).ExecuteUI(menuID, linkParams);
        }

        #endregion

        #region :: ShowAlertMessage(+1 Overloading) :: Alert Message를 보여줍니다.
        
        /// <summary>
        /// Alert Message를 보여줍니다.
        /// </summary>
        /// <param name="caption">Alert Control Caption</param>
        /// <param name="text">Alert Message</param>
        /// <param name="hotTrackedText">Hot Tracked Text</param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void ShowAlertMessage(string caption, string text, string hotTrackedText)
        {
            (MdiParent as MainFrame).ShowAlertMessage(caption, text, hotTrackedText);
        }  

        #endregion        


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Internal)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OperationItem_Click :: Main Form의 Operations Item을 클릭하면 발생합니다.

        /// <summary>
        /// Main Form의 Operations Item을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="itemName"></param>
        internal void OperationItem_Click(string itemName)
        {
            try
            {
                switch (itemName)
                {
                    case "iSelect":
                        if (Selection != null) { Selection(this, new EventArgs()); }
                        break;
                    case "iNew":
                        if (New != null) { New(this, new EventArgs()); }
                        break;
                    case "iSave":
                        if (Save != null) { Save(this, new EventArgs()); }
                        break;
                    case "iDelete":
                        if (Delete != null) { Delete(this, new EventArgs()); }
                        break;
                    case "iPrint":
                        if (Print != null) { Print(this, new EventArgs()); }
                        break;
					case "iChart":
						if (Chart != null) { Chart(this, new EventArgs()); }
						break;
					case "iImport":
						if (Import != null) { Import(this, new EventArgs()); }
						break;
				}
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: RefreshInitData :: Form Data를 초기화합니다.

        /// <summary>
        /// Form Data를 초기화합니다.
        /// </summary>
        internal void RefreshInitData()
        {
            // UNDONE : 현재 Public Method만 가능하도록 구현
            // 추후 Private Method도 가능하도록 구현해야 함.
            AppUtil.ExecuteMethod(this, "InitGlobalInstance");
            AppUtil.ExecuteMethod(this, "InitComboBox");
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnActivated :: Form이 Activate 될 때 발생합니다.
        
        /// <summary>
        /// Form이 Activate 될 때 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            if (MdiParent as MainFrame == null) return;
            (MdiParent as MainFrame).DelCustomButton();

            base.OnActivated(e);

            SetRibbonBarButtonEnabled();
            DataSet ds;
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.MenuBtnList_Select";

                string[] paramList = new string[] { "@MenuId" };

                object[] valueList = new object[] { MenuID };

                ds = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
                
            }

            (MdiParent as MainFrame).AddCustomButton(ds);
        }

        protected internal virtual void CustomButtonClick(BarButtonItem bbi)
        {
            throw new InvalidOperationException("Must Override CustomButtonClick()");
        }



        #endregion

        #region :: OnFormClosing :: UI Form이 닫힐 때 발생합니다.

        /// <summary>
        /// UI Form이 닫힐 때 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (!_isModified)
            {
                try
                {
                    (MdiParent as MainFrame).DelCustomButton();
                }
                catch (Exception ex)
                {

                }
                return;
            }

            if (MsgBox.Show(MsgMap.CK_DATA_MODIFY_CLOSE, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                return;

            e.Cancel = true;
            (MdiParent as MainFrame).IsUiModifyClear = false;
        } 

        #endregion
    }
}