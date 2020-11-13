using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraTreeList;
using TLF.Business.WSBiz;
using TLF.Framework.Applications;
using TLF.Framework.Authentication;
using TLF.Framework.Collections;
using TLF.Framework.Config;
using TLF.Framework.ExceptionHelper;
using TLF.Framework.Localization;
using TLF.Framework.MessageHelper;
using TLF.Framework.Utility;
using TLF.UI.Developer.Design;

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
    public partial class MainFrame : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// MainFrame을 생성합니다.
        /// </summary>
        public MainFrame()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        UserInformation _currentUser;
        TLF.Framework.Localization.Localizer _localization;

        private bool _isSetMessage = true;
        private bool _isUiModifyClear = true;

        //private string _culture = "ko-KR";        
        private string _updateUrl = @"http://61.83.27.100/CO/TLFSetup/TLF.Solutions.MesUpdater.application";

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ClassCaption :: Class Caption을 설정합니다.

        /// <summary>
        /// Class Caption을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Class Caption을 설정합니다."), Browsable(false)]
        public string ClassCaption
        {
            get { return siClass.Caption; }
            set { siClass.Caption = GetClassCaption(value); }
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
            get { return _currentUser; }
            set { _currentUser = value; }
        }

        #endregion

        #region :: DepartmentCaption :: Department Caption을 설정합니다.

        /// <summary>
        /// Department Caption을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Department Caption을 설정합니다."), Browsable(false)]
        public string DepartmentCaption
        {
            get { return siDepartment.Caption; }
            set { siDepartment.Caption = value; }
        }

        #endregion

        #region :: LoginTimeCaption :: Login Time Caption을 설정합니다.

        /// <summary>
        /// Login Time Caption을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Login Time Caption을 설정합니다."), Browsable(false)]
        public string LoginTimeCaption
        {
            get { return siTime.Caption; }
            set { siTime.Caption = value; }
        }

        #endregion

        #region :: IsModified :: UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다.

        /// <summary>
        /// UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("UI 수정여부를 Check 하여 수정여부를 Caption에 표시합니다."), Browsable(false)]
        public bool IsModified
        {
            set { siModified.Caption = value == true ? "   Modified   " : ""; }
        }

        #endregion

        #region :: IsSetMessage :: Status Bar 메시지 처리 여부를 설정합니다.

        /// <summary>
        /// Status Bar 메시지 처리 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Status Bar 메시지 처리 여부를 설정합니다."), Browsable(false)]
        public bool IsSetMessage
        {
            get { return _isSetMessage; }
            set { _isSetMessage = value; }
        }

        #endregion

        #region :: IsUiModifyClear :: UI의 변경 내역을 Clear 할지 정합니다.

        /// <summary>
        /// UI의 변경 내역을 Clear 할지 정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("UI의 변경 내역을 Clear 할지 정합니다."), Browsable(false)]
        public bool IsUiModifyClear
        {
            get { return _isUiModifyClear; }
            set { _isUiModifyClear = value; }
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
            get { return siMessage.Caption; }
            set { siMessage.Caption = value; }
        } 

        #endregion

        #region :: UserCaption :: User Caption을 설정합니다.
        
        /// <summary>
        /// User Caption을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("User Caption을 설정합니다."), Browsable(false)]
        public string UserCaption
        {
            get { return siUser.Caption; }
            set { siUser.Caption = value; }
        } 

        #endregion

        #region :: ShowProgressLabel :: Progress Label 숨김/보임을 설정합니다.
        
        /// <summary>
        /// Progress Label 숨김/보임을 설정합니다.
        /// </summary>
        public bool ShowProgressLabel
        {
            set
            {
                siProgress.Visibility = value == true ? BarItemVisibility.Always : BarItemVisibility.Never;
            }
        } 

        #endregion

        #region :: ShowMoveAlert :: 치공구 불출이동알림을 설정을 가져옵니다.

        /// <summary>
        /// 치공구 불출이동알림을 설정을 가져옵니다.
        /// </summary>
        public bool ShowMoveAlert
        {
            get { return Convert.ToBoolean(iMoveAlert.EditValue); }
        }

        #endregion

        //#region :: Culture :: 다국어 문화권

        ///// <summary>
        ///// 다국어 문화권
        ///// </summary>
        //[Category(AppConfig.CONTROLCATEGORY)]
        //[Description("다국어 문화권"), Browsable(false)]
        //public string Culture
        //{
        //    get { return _culture; }
        //    set
        //    {
        //        _culture = value;
                
        //    }
        //}

        //#endregion

        #region :: localizer :: 다국어 지원을 가능하게 하는 Localizer

        /// <summary>
        /// 다국어 지원을 가능하게 하는 Localizer
        /// </summary>
        protected internal TLF.Framework.Localization.Localizer localizer
        {
            get { return _localization; }
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: alertControl_BeforeFormShow :: Alert Control이 보이기 전에 사이즈를 설정합니다.

        /// <summary>
        /// Alert Control이 보이기 전에 사이즈를 설정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alertControl_BeforeFormShow(object sender, DevExpress.XtraBars.Alerter.AlertFormEventArgs e)
        {
            e.AlertForm.Size = new Size(Convert.ToInt32(iAlertWidth.EditValue), Convert.ToInt32(iAlertHeight.EditValue));
        }

        #endregion
        
        #region :: iTimerInterval_EditValueChanged ::

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iTimerInterval_EditValueChanged(object sender, EventArgs e)
        {
            SetTimerInterval(Convert.ToInt32(iTimerInterval.EditValue));
        }

        #endregion

        #region :: rgbiSkins_GalleryItemClick :: Skin을 선택할 때 발생합니다.

        /// <summary>
        /// Skin을 선택할 때 발생합니다.
        /// </summary>
        private void rgbiSkins_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(e.Item.Caption);
            Win32Util.WritePrivateProfileString("Skin", "SkinName", e.Item.Caption, AppConfig.SETTINGFILEPATH);
        }

        #endregion

        #region :: rgbiSkins_GalleryInitDropDownGallery :: DropDown Skin Gallery를 초기화합니다.

        /// <summary>
        /// DropDown Skin Gallery를 초기화합니다.
        /// </summary>
        private void rgbiSkins_GalleryInitDropDownGallery(object sender, InplaceGalleryEventArgs e)
        {
            e.PopupGallery.CreateFrom(rgbiSkins.Gallery);
            e.PopupGallery.AllowFilter = false;
            e.PopupGallery.ShowItemText = true;
            e.PopupGallery.ShowGroupCaption = true;
            e.PopupGallery.AllowHoverImages = false;
            foreach (GalleryItemGroup galleryGroup in e.PopupGallery.Groups)
            {
                foreach (GalleryItem item in galleryGroup.Items)
                    item.Image = item.HoverImage;
            }
            e.PopupGallery.ColumnCount = 2;
            e.PopupGallery.ImageSize = new Size(70, 36);
        }

        #endregion

        #region :: rgiDatabase_EditValueChanged :: Database 를 변경하면 Setting File에 저장합니다.

        /// <summary>
        /// Database 를 변경하면 Setting File에 저장합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rgiDatabase_EditValueChanged(object sender, EventArgs e)
        {
            Win32Util.WritePrivateProfileString("Database", "Default", rgiDatabase.EditValue.ToString(), AppConfig.SETTINGFILEPATH);
            ChangeDefaultDatabase(rgiDatabase.EditValue.ToString());
        }

        #endregion

        #region :: ribbon_ItemClick :: Ribbon Item을 Click 하면 UIFrame의 Event를 발생시킵니다.

        /// <summary>
        /// Ribbon Item을 Click 하면 UIFrame의 Event를 발생시킵니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ribbon_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                switch (e.Item.Name)
                {
                    case "iMenuReload":
                        if (CurrentUser != null) InitUserMenu();
                        break;
                    case "iToggle":
                        break;
                    case "iFloat":
                        pnlMenu.MakeFloat();
                        break;
                    case "iClose":
                        if(ActiveMdiChild != null) ActiveMdiChild.Close();
                        break;
                    case "iCapture":
                        CaptureImage();
                        break;
                    case "iExit":
                        Close();
                        break;
                    case "iSignOn":
                        SignIn();
                        break;
                    case "iHelpDesk":
                        //Process.Start("IExplore", "http://16.3.63.35/mesportal/helpdesk/error/errlist.aspx");
                        ShowHelpDesk();
                        break;
                    case "iFavorites":
                        RegistorFavorites();
                        break;
                    case "iUpdate":
                        UpdateSystem();
                        break;
                    case "iAbout":
                        ShowAboutForm();
                        break;
                    case "iAuthenticationProgram":
                        //ExecuteUI("iSystemUser", "사용자 관리", "TLF.UI.Management.Systems.dll", "TLF.UI.Management.Systems.SystemMenu", "", null);
                        break;
                    case "iSystemUser":
                        //ExecuteUI("iSystemUser", "사용자 관리", "TLF.UI.Management.Systems.dll", "TLF.UI.Management.Systems.SystemMenu", "", null);
                        break;
                    case "iSystemMenu":
                        //ExecuteUI("iSystemMenu", "시스템 메뉴 관리", "TLF.UI.Management.Systems.dll", "TLF.UI.Management.Systems.SystemMenu", "", null);
                        break;
                    case "iWebPage":
                        //MessageCaption = MsgMap.IF_DEV_ING;
                        ShowAlertMessage("개발 중...", MsgMap.IF_DEV_ING, "");
                        break;
                }

                UIFrame uiFrame = ActiveMdiChild as UIFrame;

                if (uiFrame == null)
                {
                    _isSetMessage = false;
                    return;
                }

                ShowProgressLabel = true;
                Application.DoEvents();

                MessageCaption = MsgMap.PC_ING;

                //ICommand uiCommand = uiFrame;

                switch (e.Item.Name)
                {
                    case "iSelect":
                        if (uiFrame.CheckModify())
                            uiFrame.OperationItem_Click(e.Item.Name);
                        else
                        {
                            _isSetMessage = false;
                            _isUiModifyClear = false;
                        }
                        break;
                    case "iNew":
                    case "iSave":
                    case "iDelete":
					case "iImport":
						uiFrame.OperationItem_Click(e.Item.Name);
                        break;
                    case "iPrint":
                        uiFrame.OperationItem_Click(e.Item.Name);
//                        ShowAlertMessage("개발 중...", MsgMap.IF_DEV_ING, "");
                        break;
                    case "iExcel":
                        ExportTo(ExportType.Excel, uiFrame);
                        break;
                    case "iHelp":
                        //System.Diagnostics.Process.Start("chrome.exe", uiFrame.HelpPath);
                        helper_test helper_test = new helper_test();
                        helper_test.cut = uiFrame.CurrentUser;
                        helper_test.menuid = uiFrame.MenuID;
                        helper_test.ShowDialog();
                        break;
                    case "iSync":
                        uiFrame.RefreshInitData();
                        break;
                }

                uiFrame.IsModified = !_isUiModifyClear;
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
            finally
            {
                if (_isSetMessage)
                {
                    if (e.Item == iSelect)
                        MessageCaption = MsgMap.OK_SELECT;
                    else if (e.Item == iNew)
                        MessageCaption = MsgMap.OK_PROCESS;
                    else if (e.Item == iSave)
                        MessageCaption = MsgMap.OK_SAVE;
                    else if (e.Item == iDelete)
                        MessageCaption = MsgMap.OK_DELETE;
                    else if (e.Item == iExcel)
                        MessageCaption = MsgMap.OK_EXCEL_EXPORT;
                    else
                        MessageCaption = "준비";
                }

                _isSetMessage = true;
                _isUiModifyClear = true;

                ShowProgressLabel = false;
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #region :: tlMenu_MouseDoubleClick :: Mouse를 Double Click 하면 해당 UI를 실행합니다.
        
        /// <summary>
        /// Mouse를 Double Click 하면 해당 UI를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tlMenu.FocusedNode != null)
            {
                ExecuteUI((tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"], null);
            }
        } 

        #endregion

        #region :: tlMenu_FocusedNodeChanged :: 메뉴의 Focused Node가 변경되면 해당 UI를 실행합니다.

        /// <summary>
        /// 메뉴의 Focused Node가 변경되면 해당 UI를 실행합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.OldNode == null)
                return;

            //ExecuteUI((tlMenu.GetDataRecordByNode(e.Node) as DataRowView).Row["MenuId"], null);
        }

        #endregion

        #region :: tlMenu_GetStateImage :: 메뉴의 기본 Image를 가져와 설정합니다.

        /// <summary>
        /// 메뉴의 기본 Image를 가져와 설정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            e.Node.ImageIndex = e.Node.GetDisplayText("ImageIdx") == "" ? 0 : Convert.ToInt32(e.Node.GetDisplayText("ImageIdx"));
        }

        #endregion

        #region :: tlMenu_GetSelectImage :: 메뉴의 선택 Image를 가져와 설정합니다.

        /// <summary>
        /// 메뉴의 선택 Image를 가져와 설정합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_GetSelectImage(object sender, DevExpress.XtraTreeList.GetSelectImageEventArgs e)
        {
            e.Node.SelectImageIndex = e.Node.GetDisplayText("SelectImageIdx") == "" ? 0 : Convert.ToInt32(e.Node.GetDisplayText("SelectImageIdx"));
        }

        #endregion

        #region :: xtraTabbedMdiManager_SelectedPageChanged :: Active Mdi Child가 변경되면 발생합니다.

        /// <summary>
        /// Active Mdi Child가 변경되면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager_SelectedPageChanged(object sender, EventArgs e)
        {
            MessageCaption = "준비";
            ClassCaption = "";
            IsModified = false;

            //(this.MdiParent as Framework.BaseFrame.MainFrame).DelCusTomButton();

            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Show();
                ClassCaption = (ActiveMdiChild as UIFrame).ClassName;
                IsModified = (ActiveMdiChild as UIFrame).IsModified;
            }
        }

        #endregion

        #region :: xtraTabbedMdiManager_PageRemoved :: Mdi Child가 닫힐 때 발생합니다.
        
        /// <summary>
        /// Mdi Child가 닫힐 때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabbedMdiManager_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            if (e.Page.MdiChild != null) e.Page.MdiChild.Close();

            if (MdiChildren.Length != 0)
                return;

            Ribbon.Items["iSelect"].Enabled = false;
            Ribbon.Items["iNew"].Enabled = false;
            Ribbon.Items["iSave"].Enabled = false;
            Ribbon.Items["iDelete"].Enabled = false;
            Ribbon.Items["iPrint"].Enabled = false;
            Ribbon.Items["iImport"].Enabled = false;

            ClassCaption = "";
        } 

        #endregion

        
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CaptureImage :: 현재 화면을 Capture 합니다.

        /// <summary>
        /// 현재 화면을 Capture 합니다.
        /// </summary>
        public void CaptureImage()
        {
            Rectangle rect = new Rectangle(Location, Size);

            Bitmap bMap = CaptureBitmap(CreateGraphics(), rect);

            if (Clipboard.ContainsImage()) Clipboard.Clear();
            Clipboard.SetImage(bMap);

            //2020-03-11 다이얼로그를 띄어 캡쳐한 이미지 저장
            //작성자 : 이상윤
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPeg Image|*.jpg";
            saveFileDialog.Title = "캡쳐 이미지 저장";

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                bMap.Save(fileName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Bitmap CaptureBitmap(Graphics g, Rectangle rect)
        {
            Bitmap image;

            using (Graphics graphics = g)
            {
                image = new Bitmap(rect.Width, rect.Height, graphics);

                using (Graphics memoryGrahics = Graphics.FromImage(image))
                {
                    memoryGrahics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
                }
            }

            return image;
        }

        #endregion

        #region :: ExecuteUI(+1 Overloading) :: UI를 실행합니다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuID"></param>
        /// <param name="linkParams"></param>
        public void ExecuteUI(object menuID, LinkEventParams linkParams)
        {
            DataRowView drv = tlMenu.GetDataRecordByNode(tlMenu.FindNodeByKeyID(menuID)) as DataRowView;

            if (drv == null) return;

            string dllPath = drv.Row["DllName"].ToString();
            string className = drv.Row["ClassName"].ToString();

			if (dllPath.ToUpper().IndexOf(".EXE") > 0)
			{
				if (System.IO.File.Exists(dllPath))
				{
					Process.Start(dllPath, className);
				}
				return;
			}
            if (dllPath == "" || className == "") return;

            string text = drv.Row["MenuName"].ToString();
            string helpPath = drv.Row["helpPath"].ToString();

            bool[] eventAuth = new bool[7];
            eventAuth[0] = Convert.ToBoolean(drv.Row["SelectAuth"]);
            eventAuth[1] = Convert.ToBoolean(drv.Row["NewAuth"]);
            eventAuth[2] = Convert.ToBoolean(drv.Row["SaveAuth"]);
            eventAuth[3] = Convert.ToBoolean(drv.Row["DelAuth"]);
            eventAuth[4] = Convert.ToBoolean(drv.Row["PrintAuth"]);
            eventAuth[5] = Convert.ToBoolean(drv.Row["ImportAuth"]);
            eventAuth[6] = Convert.ToBoolean(drv.Row["DownAuth"]);

            ExecuteUI(menuID.ToString(), text, dllPath, className, helpPath, linkParams, eventAuth);
        }

        /// <summary>
        /// UI를 실행합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="text">Form 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="helpPath">도움말 경로</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <param name="eventAuth">이벤트 권한 설정(1,1,1,1,1,1,1) 7개로 구성된 Event 권한을 반드시 넘겨야 한다.</param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void ExecuteUI(string menuID, string text, string dllPath, string className, string helpPath, LinkEventParams linkParams, bool[] eventAuth)
        {
            if (!CheckExecuteUI(menuID, linkParams))
                CreateUI(menuID, text, dllPath, className, helpPath, linkParams, eventAuth);
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
            alertControl.Show(FindForm(), caption, text, hotTrackedText);
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Protected)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateUserMenu :: 사용자 권한에 따라 TreeList의 데이터를 채웁니다.

        /// <summary>
        /// 사용자 권한에 따라 TreeList의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">TreeList의 DataSource</param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        protected void CreateUserMenu(DataSet ds)
        {
            tlMenu.DataSource = ds;
            tlMenu.DataMember = ds.Tables[0].TableName;
			tlMenu.ExpandAll();
        } 

        #endregion
        
        #region :: InitSkinGallery :: Skin Gallery를 초기화합니다.

        /// <summary>
        /// Skin Gallery를 초기화합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-19 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected void InitSkinGallery()
        {
            using (SimpleButton imageButton = new SimpleButton())
            {
                foreach (SkinContainer cnt in SkinManager.Default.Skins)
                {
                    imageButton.LookAndFeel.SetSkinStyle(cnt.SkinName);
                    GalleryItem gItem = new GalleryItem();
                    int groupIndex = 0;
                    if (cnt.SkinName.IndexOf("Office") > -1)
                        groupIndex = 1;
                    if (cnt.SkinName.IndexOf("Stardust") > -1)
                        groupIndex = 2;
                    if (cnt.SkinName.IndexOf("Coffee") > -1)
                        groupIndex = 2;
                    if (cnt.SkinName.IndexOf("Liquid") > -1)
                        groupIndex = 2;
                    if (cnt.SkinName.IndexOf("London") > -1)
                        groupIndex = 2;
                    if (cnt.SkinName.IndexOf("Glass") > -1)
                        groupIndex = 2;
                    if (cnt.SkinName.IndexOf("Xmas") > -1)
                        groupIndex = 2;
                    rgbiSkins.Gallery.Groups[groupIndex].Items.Add(gItem);
                    gItem.Caption = cnt.SkinName;
                    gItem.Image = GetSkinImage(imageButton, 32, 17, 2);
                    gItem.HoverImage = GetSkinImage(imageButton, 70, 36, 5);
                    gItem.Caption = cnt.SkinName;
                    gItem.Hint = cnt.SkinName;
                }
            }
        } 

        #endregion
        
        #region :: SetDefaultDBFromSetting :: 사용자가 선택한 Database로 설정합니다.

        /// <summary>
        /// 사용자가 선택한 Database로 설정합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected void SetDefaultDBFromSetting()
        {
            StringBuilder sb = new StringBuilder(32);
            Win32Util.GetPrivateProfileString("Database", "Default", "", sb, 32, AppConfig.SETTINGFILEPATH);
            if (sb.ToString() != string.Empty)
                rgiDatabase.EditValue = sb.ToString();
        }

        #endregion

        #region :: SetSkinStyleFromSetting :: 사용자가 선택한 Skin으로 설정합니다.

        /// <summary>
        /// 사용자가 선택한 Skin으로 설정합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-19 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected void SetSkinStyleFromSetting()
        {
            StringBuilder sb = new StringBuilder(32);
            Win32Util.GetPrivateProfileString("Skin", "SkinName", "", sb, 32, AppConfig.SETTINGFILEPATH);
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(sb.ToString());
        }

        #endregion
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="culture"></param>
        protected void SetCulture(string culture)
        {
            _localization = new Localizer(culture);

            iMenuReload.Caption = _localization.GetLocalizedString(StrId.Refresh);
            iFloat.Caption = _localization.GetLocalizedString(StrId.Floating);
            iSelect.Caption = _localization.GetLocalizedString(StrId.Inquiry);
            iNew.Caption = _localization.GetLocalizedString(StrId.New);
            iSave.Caption = _localization.GetLocalizedString(StrId.Save);
            iDelete.Caption = _localization.GetLocalizedString(StrId.Delete);
            iPrint.Caption = _localization.GetLocalizedString(StrId.Print);
            iCapture.Caption = _localization.GetLocalizedString(StrId.CaptureScreen);
            iClose.Caption = _localization.GetLocalizedString(StrId.Close);
            iExit.Caption = _localization.GetLocalizedString(StrId.Exit);
            iSync.Caption = _localization.GetLocalizedString(StrId.Synchronize);
        }

        #region :: ShowOptionForm :: Option Form을 실행합니다.
        
        /// <summary>
        /// Option Form을 실행합니다.
        /// </summary>
        protected void ShowOptionForm()
        {
            //frmOptions fOption = new frmOptions();
            //fOption.ShowDialog();
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ChangeDefaultDatabase :: Default Database를 변경합니다.
        
        /// <summary>
        /// Default Database를 변경합니다.
        /// </summary>
        /// <param name="option">TEST / RUN</param>
        private void ChangeDefaultDatabase(string option)
        {
            if (option == "TEST")
            {
                Text += " (TEST MODE)";
                if(AppConfig.DEFAULTJIGDB == AppConfig.JIGDB)
                    AppConfig.DEFAULTJIGDB = AppConfig.JIGDB + "_TEST";

                if (AppConfig.DEFAULTWMSDB == AppConfig.WMSDB)
                    AppConfig.DEFAULTWMSDB = AppConfig.WMSDB + "_TEST";


                AppConfig.DEFAULTMESDB = AppConfig.DEFAULTDB + "_TEST";
                AppConfig.DEFAULTWORKPLACE = AppConfig.MESDB_RPT + "_TEST";
                AppConfig.DEFAULTAIDB = AppConfig.AIDB + "_TEST";
            }
            else
            {
                Text = Text.Replace(" (TEST MODE)", "");
                if (AppConfig.DEFAULTJIGDB == AppConfig.JIGDB + "_TEST")
                    AppConfig.DEFAULTJIGDB = AppConfig.JIGDB;

                if (AppConfig.DEFAULTWMSDB == AppConfig.WMSDB + "_TEST")
                    AppConfig.DEFAULTWMSDB = AppConfig.WMSDB;


                AppConfig.DEFAULTMESDB = AppConfig.DEFAULTDB;
                AppConfig.DEFAULTWORKPLACE = AppConfig.MESDB_RPT;
                AppConfig.DEFAULTAIDB = AppConfig.AIDB ;
            }
        }

        #endregion

        #region :: CheckExecuteUI :: 실행 중인 UI 가 있는지를 검사합니다.
        
        /// <summary>
        /// 실행 중인 UI 가 있는지를 검사합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private bool CheckExecuteUI(string menuID, LinkEventParams linkParams)
        {
            if (MdiChildren.Length == 0) return false;

            foreach (Form childForm in MdiChildren)
            {
                if ((childForm as UIFrame).MenuID != menuID)
                    continue;

                childForm.BringToFront();

                if (childForm is UIFrame)
                {
                    (childForm as UIFrame).LinkParams = linkParams;
                    (childForm as UIFrame).OnLinkEvent();
                }
                ActivateMdiChild(childForm);

                return true;
            }

            return false;
        } 

        #endregion

        #region :: CreateUI :: Form을 생성하고 실행합니다.
        
        /// <summary>
        /// Form을 생성하고 실행합니다.
        /// </summary>
        /// <param name="menuID">MENU ID</param>
        /// <param name="text">Form 제목</param>
        /// <param name="dllPath">Dll 경로</param>
        /// <param name="className">Class 명</param>
        /// <param name="helpPath">도움말 경로</param>
        /// <param name="linkParams">Link Event Parameters</param>
        /// <param name="eventAuth">이벤트 권한 설정(1,1,1,1,1,1,1) 7개로 구성된 Event 권한을 반드시 넘겨야 한다.</param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void CreateUI(string menuID, string text, string dllPath, string className, string helpPath, LinkEventParams linkParams, bool[] eventAuth)
        {
            using (frmProgress fProgress = new frmProgress())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    fProgress.ProgramName = String.Format("[ {0} ] Loading...", text);
                    fProgress.Show();
                    Form uiFrame = AppUtil.CreateInstanceForm(dllPath, className);
                    Application.DoEvents();

                    //if (menuID == "PMS16")
                    //{
                    //    fProgress.Close();

                    //    //uiFrame.StartPosition = FormStartPosition.Manual;
                    //    //uiFrame.Location = new Point(0, 0);

                    //    //Size FullScreenSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                    //    //uiFrame.MaximumSize = FullScreenSize;
                    //    //uiFrame.Size = FullScreenSize;

                    //    uiFrame.WindowState = FormWindowState.Maximized;
                    //    uiFrame.FormBorderStyle = FormBorderStyle.FixedDialog;

                    //    uiFrame.Show();
                    //}
                    //else
                    //{
                    //}
                    uiFrame.Text = text;
                    uiFrame.MdiParent = this;

                    if (uiFrame is UIFrame)
                    {
                        (uiFrame as UIFrame).SelectAuth = eventAuth[0];
                        (uiFrame as UIFrame).NewAuth = eventAuth[1];
                        (uiFrame as UIFrame).SaveAuth = eventAuth[2];
                        (uiFrame as UIFrame).DelAuth = eventAuth[3];
                        (uiFrame as UIFrame).PrintAuth = eventAuth[4];
                        (uiFrame as UIFrame).ImportAuth = eventAuth[5];
                        (uiFrame as UIFrame).DownAuth = eventAuth[6];

                        (uiFrame as UIFrame).MenuID = menuID;
                        (uiFrame as UIFrame).ClassName = className;
                        (uiFrame as UIFrame).LinkParams = linkParams;
                        (uiFrame as UIFrame).HelpPath = helpPath;

                        uiFrame.Show();

                        (uiFrame as UIFrame).OnLinkEvent();
                        (uiFrame as UIFrame).OnAuthenticationEvent();
                    }

                    if (!Debugger.IsAttached)
                        SaveMenuExecuteLog(menuID);
                }
                catch (Exception ex)
                {
                    ExceptionBox.Show(ex);
                }
                finally
                {
                    fProgress.Close();
                    Cursor = Cursors.Default;
                }
            }
        } 

        #endregion

        #region :: ExportTo :: GridView Data를 Export 합니다.

        ///// <summary>
        ///// GridView Data를 Export 합니다.
        ///// </summary>
        ///// <param name="eType"></param>
        ///// <param name="control"></param>
        ///// <remarks>
        ///// 2009-01-07 최초생성 : 황준혁
        ///// 변경내역
        ///// 
        ///// </remarks>
        //private void ExportTo(ExportType eType, Control control)
        //{
        //    List<Control> gridList = new List<Control>();
        //    AppUtil.FindControl(gridList, control, "TLF.Framework.ControlLibrary.PGridControl");

        //    if (gridList.Count == 0)
        //    {
        //        MessageCaption = "Export 작업을 처리할 Grid를 찾지 못했습니다.";
        //        _isSetMessage = false;
        //        return;
        //    }

        //    string strPdfExtension = "Adobe PDF 문서|*.pdf";
        //    string strTextExtension = "텍스트 문서|*.txt";
        //    string strHtmlExtension = "HTM 웹 페이지|*.htm|HTML 웹페이지|*.html";
        //    string strExcelExtension = "Excel 통합 문서|*.xls";

        //    using (SaveFileDialog fd = new SaveFileDialog())
        //    {
        //        switch (eType)
        //        {
        //            case ExportType.Excel:
        //                fd.Filter = strExcelExtension;
        //                break;
        //            case ExportType.Pdf:
        //                fd.Filter = strPdfExtension;
        //                break;
        //            case ExportType.Html:
        //                fd.Filter = strHtmlExtension;
        //                break;
        //            case ExportType.Rtf:
        //                break;
        //            default:
        //                fd.Filter = strTextExtension;
        //                break;
        //        }
        //        foreach (Control grid in gridList)
        //        {
        //            if (!(grid is GridControl))
        //                continue;

        //            fd.FileName = String.Format("{0}({1:yyyy-MM-dd_HHmmss})", control.Text.Replace(" / ", ""), DateTime.Now);
                    
        //            if (fd.ShowDialog() != DialogResult.OK)
        //                continue;

        //            switch (eType)
        //            {
        //                case ExportType.Excel:
        //                    ExportTo(new ExportXlsProvider(fd.FileName), grid);
        //                    break;
        //                case ExportType.Pdf:
        //                    fd.Filter = strPdfExtension;
        //                    break;
        //                case ExportType.Html:
        //                    fd.Filter = strHtmlExtension;
        //                    break;
        //                case ExportType.Rtf:
        //                    break;
        //                default:
        //                    break;
        //            }
        //            AppUtil.OpenFile(fd.FileName);
        //        }
        //    }
        //}
                
        /// <summary>
        /// Grid를 Export 합니다.
        /// </summary>
        /// <param name="eType"></param>
        /// <param name="control"></param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private void ExportTo(ExportType eType, Control control)
        {
            List<Control> gridList = new List<Control>();

            AppUtil.FindControl(gridList, control, "TLF.Framework.ControlLibrary.PGridControl");
            AppUtil.FindControl(gridList, control, "TLF.Framework.ControlLibrary.PPivotGridControl");
            
            if (gridList.Count == 0)
            {
                ShowAlertMessage("작업 오류", "Export 작업을 처리할 Grid를 찾지 못했습니다.", "");
                return;
            }

            string strPdfExtension = "Adobe PDF 문서|*.pdf";
            string strTextExtension = "텍스트 문서|*.txt";
            string strHtmlExtension = "HTM 웹 페이지|*.htm|HTML 웹페이지|*.html";
            string strExcelExtension = "Excel 통합 문서|*.xls";
            //string strAllExtension = "All files (*.*)|*.*";

            using (SaveFileDialog fd = new SaveFileDialog())
            {
                switch (eType)
                {
                    case ExportType.Excel:
                        fd.Filter = strExcelExtension;
                        break;
                    case ExportType.Pdf:
                        fd.Filter = strPdfExtension;
                        break;
                    case ExportType.Html:
                        fd.Filter = strHtmlExtension;
                        break;
                    case ExportType.Rtf:
                        break;
                    default:
                        fd.Filter = strTextExtension;
                        break;
                }
                foreach (Control grid in gridList)
                {
                    fd.FileName = String.Format("{0}({1:yyyy-MM-dd_HHmmss})", control.Text.Replace(" / ", ""), DateTime.Now);
                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        FileInfo fi = new FileInfo(fd.FileName);

                        if (grid is GridControl)
                            (grid as GridControl).ExportToXls(fi.FullName);
                        if (grid is PivotGridControl)
                            (grid as PivotGridControl).ExportToXls(fi.FullName);
                        AppUtil.OpenFile(fd.FileName);
                    }
                }
            }
        }

        #endregion

        #region :: GetClassCaption :: Class Caption을 가져옵니다.

        /// <summary>
        /// Class Caption을 가져옵니다.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private string GetClassCaption(string className)
        {
            string cName = string.Empty;

            try
            {
                cName = className.Substring(className.LastIndexOf(".") + 1);
            }
            catch
            {
                cName = "";
            }

            return cName;
        }

        #endregion

        #region :: GetSkinImage :: Skin의 Image를 가져옵니다.

        /// <summary>
        /// Skin의 Image를 가져옵니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-19 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        private Bitmap GetSkinImage(SimpleButton button, int width, int height, int indent)
        {
            Bitmap image = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(image))
            {
                StyleObjectInfoArgs info = new StyleObjectInfoArgs(new GraphicsCache(g));

                info.Bounds = new Rectangle(0, 0, width, height);
                button.LookAndFeel.Painter.GroupPanel.DrawObject(info);
                button.LookAndFeel.Painter.Border.DrawObject(info);
                info.Bounds = new Rectangle(indent, indent, width - indent * 2, height - indent * 2);
                button.LookAndFeel.Painter.Button.DrawObject(info);
            }

            return image;
        } 

        #endregion        

        #region :: RegistorFavorites :: 자주 쓰는 메뉴를 등록합니다.

        /// <summary>
        /// 자주 쓰는 메뉴를 등록합니다.
        /// </summary>
        private void RegistorFavorites()
        {
            if (ActiveMdiChild == null)
                return;

            string pgmId = string.Empty;

            UIFrame uiFrame = ActiveMdiChild as UIFrame;

            pgmId = uiFrame.MenuID;

            if (MsgBox.Show(String.Format("[ {0} ] 를(을) 자주 쓰는 메뉴로 등록하시겠습니까?", uiFrame.Text), "자주 쓰는 메뉴 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (RegistorFavoritesMenu(pgmId) > 0)
                {
                    MsgBox.Show(String.Format("[ {0} ] 가(이) 자주 쓰는 메뉴로 등록되었습니다. 등록한 메뉴는 다음 로그인 때 반영됩니다.", uiFrame.Text), "자주 쓰는 메뉴 등록");
                }
            }
        }

        #endregion

        #region :: ShowHelpDesk :: Help Desk를 연결합니다.

        /// <summary>
        /// Help Desk를 연결합니다.
        /// </summary>
        private void ShowHelpDesk()
        {
            UIFrame uf = new UIFrame { MdiParent = this, Text = "HELP DESK" };
            WebBrowser wb = new WebBrowser { Dock = DockStyle.Fill, IsWebBrowserContextMenuEnabled = false, WebBrowserShortcutsEnabled = false };
            wb.Navigate("http://16.3.63.35/mesportal/helpdesk/error/errlist.aspx");
            uf.Controls.Add(wb);
            uf.Show();
        }

        #endregion

        #region :: UpdateSystem :: System을 Update 합니다.

        /// <summary>
        /// System을 Update 합니다.
        /// </summary>
        public void UpdateSystem()
        {
            try
            {
                System.Diagnostics.ProcessStartInfo pi = new System.Diagnostics.ProcessStartInfo { FileName = "IExplore.exe", Arguments = _updateUrl, WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden };
                
                System.Diagnostics.Process.Start(pi);

                Array.ForEach(MdiChildren, f => f.Close());
                Application.Exit();
            }
            catch
            {
                throw;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Virtual)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitUserMenu :: 사용자 메뉴를 초기화 합니다.

        /// <summary>
        /// 사용자 메뉴를 초기화 합니다.
        /// </summary>
        protected virtual void InitUserMenu()
        {
            throw new InvalidOperationException("Must Override InitUserMenu()");
        } 

        #endregion
        
        #region :: RegistorFavoritesMenu :: 자주 쓰는 메뉴를 등록합니다.

        /// <summary>
        /// 자주 쓰는 메뉴를 등록합니다.
        /// </summary>
        /// <param name="menuID">프로그램 ID</param>
        protected virtual int RegistorFavoritesMenu(string menuID)
        {
            throw new InvalidOperationException("Must Override RegistorFavoritesMenu()");
        }

        /// <summary>
        /// 자주 쓰는 메뉴를 삭제합니다.
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        protected virtual int DeleteFavoritesMenu(string menuID)
        {
            throw new InvalidOperationException("Must Override DeleteFavoritesMenu()");
        }

        /// <summary>
        /// 자동 시작 메뉴를 등록합니다.
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        protected virtual int InsertAutoRunMenu(string menuID)
        {
            throw new InvalidOperationException("Must Override InsertAutoRunMenu()");
        }

        /// <summary>
        /// 자동 시작 메뉴를 삭제합니다.
        /// </summary>
        /// <param name="menuID"></param>
        /// <returns></returns>
        protected virtual int DeleteAutoRunMenu(string menuID)
        {
            throw new InvalidOperationException("Must Override DeleteAutoRunMenu()");
        }

        #endregion

        #region :: SaveSigninLog :: Database에 사용자 Sign In Log를 저장합니다.

        /// <summary>
        /// Database에 사용자 Sign In Log를 저장합니다.
        /// </summary>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected virtual void SaveSigninLog()
        {
            throw new InvalidOperationException("Must Override SaveSigninLog()");
        } 

        #endregion

        #region :: SaveSignOutLog :: Database에 사용자 Sign Out Log를 저장합니다.
        
        /// <summary>
        /// Database에 사용자 Sign Out Log를 저장합니다.
        /// </summary>
        /// <remarks>
        /// 2009-01-08 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected virtual void SaveSignOutLog()
        {
            throw new InvalidOperationException("Must Override SaveSignOutLog()");
        }  

        #endregion

        #region :: SaveMenuExecuteLog :: Database에 Menu 실행 Log를 저장합니다.

        /// <summary>
        /// Database에 Menu 실행 Log를 저장합니다.
        /// </summary>
        /// <param name="menuId">실행한 MENU ID</param>
        protected virtual void SaveMenuExecuteLog(string menuId)
        {
            throw new InvalidOperationException("Must Override SaveMenuExecuteLog()");
        } 

        #endregion

        #region :: ShowAboutForm :: 정보창을 보여줍니다.

        /// <summary>
        /// 정보창을 보여줍니다.
        /// </summary>
        private void ShowAboutForm()
        {
            using (frmAbout fAbout = new frmAbout())
            {
                fAbout.ShowDialog();
            }
        }

        #endregion

        #region :: SignIn :: 사용자 Sign IN 처리합니다.
        
        /// <summary>
        /// 사용자 Sign IN 처리합니다.
        /// </summary>
        /// <returns></returns>
        protected virtual void SignIn()
        {
            throw new InvalidOperationException("Must Override SignIn()");
        } 

        #endregion

        #region :: SetTimeInterval :: 불출이동 Time의 Interval을 설정합니다.

        /// <summary>
        /// 불출이동 Time의 Interval을 설정합니다.
        /// </summary>
        /// <param name="interval">설정 시간</param>
        protected virtual void SetTimerInterval(int interval)
        {
            throw new InvalidOperationException("Must Override SetTimerInterval()");
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////
    
        #region :: OnLoad :: 처음 Loading 때 Skin을 등록합니다.

        /// <summary>
        /// 처음 Loading 때 Skin을 등록합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-19 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected override void OnLoad(EventArgs e)
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.UserSkins.OfficeSkins.Register();

            base.OnLoad(e);
        } 

        #endregion

        #region :: OnFormClosing :: Main Form이 닫힐 때 발생합니다.
        
        /// <summary>
        /// Form이 닫힐 때 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        /// <remarks>
        /// 2009-01-07 최초생성 : 황준혁
        /// 변경내역
        /// </remarks>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason != CloseReason.UserClosing)
                return;

            if (MsgBox.Show("HIMES 를 종료하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                 DialogResult.Yes)
            {
                Array.ForEach(MdiChildren, f => f.Close());

                if (MdiChildren.Length != 0)
                    e.Cancel = true;
            }
            else
                e.Cancel = true;
        } 

        #endregion
        
        /// <summary>
        /// 2020-03-06
        /// 작성자 : 이상윤
        /// 메뉴 아이템 우클릭 시 발생할 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tlMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            TreeListHitInfo info = tlMenu.CalcHitInfo(new Point(e.X, e.Y));

            if(info.HitInfoType == HitInfoType.Cell)
            {
                tlMenu.FocusedNode = info.Node;
                int level = tlMenu.FocusedNode.Level;
                string rootName = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode.RootNode) as DataRowView).Row["MenuName"].ToString();
                DataTable dt = getAutoRunPages();

                ContextMenu m = new ContextMenu();
                MenuItem menuItem1 = new MenuItem();
                MenuItem menuItem2 = new MenuItem();

                if (level >= 1 && rootName.Equals("즐겨찾는 메뉴"))
                {
                    menuItem1.Text = "즐겨찾기 삭제";
                    menuItem1.Click += MenuItem1_delete_Click;
                }
                else
                {
                    menuItem1.Text = "즐겨찾기 추가";
                    menuItem1.Click += MenuItem1_insert_Click;
                }

                menuItem2.Text = "자동 시작 추가";
                string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();
                foreach (DataRow a in dt.Rows)
                {
                    if (a["MenuId"].Equals(menuId))
                    {
                        menuItem2.Text = "자동 시작 삭제";
                        break;
                    }
                }
                if(menuItem2.Text.Equals("자동 시작 추가"))
                {
                    menuItem2.Click += MenuItem2_insert_Click;
                }
                else if(menuItem2.Text.Equals("자동 시작 삭제"))
                {
                    menuItem2.Click += MenuItem2_delete_Click;
                }

                m.MenuItems.Add(menuItem1);
                m.MenuItems.Add(menuItem2);
                m.Show(tlMenu, e.Location);
            }
        }

        /// <summary>
        /// 2020-03-07
        /// 작성자 : 이상윤
        /// </summary>
        protected virtual DataTable getAutoRunPages()
        {
            throw new InvalidOperationException("Must Override getAutoRunPages()");
        }

        private void MenuItem2_insert_Click(object sender, EventArgs e)
        {
            string menuName = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuName"].ToString();
            string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();

            //자동시작 추가 부분 소스
            if (MsgBox.Show(String.Format("[ {0} ] 를(을) 자동 시작 메뉴로 등록하시겠습니까?", menuName), "자동 시작 메뉴 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (InsertAutoRunMenu(menuId) > 0)
                {
                    MsgBox.Show(String.Format("[ {0} ] 가(이) 자동 시작 메뉴로 등록되었습니다.", menuName), "자동 시작 메뉴 등록");
                }
            }
        }

        private void MenuItem2_delete_Click(object sender, EventArgs e)
        {
            string menuName = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuName"].ToString();
            string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();

            //자동시작 삭제 부분 소스
            if (MsgBox.Show(String.Format("[ {0} ] 를(을) 자동 시작 메뉴 삭제하시겠습니까?", menuName), "자동 시작 메뉴 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (DeleteAutoRunMenu(menuId) > 0)
                {
                    MsgBox.Show(String.Format("[ {0} ] 가(이) 자동 시작 메뉴 삭제되었습니다.", menuName), "자동 시작 메뉴 삭제");
                }
            }
        }

        private void MenuItem1_insert_Click(object sender, EventArgs e)
        {
            string menuName = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuName"].ToString();
            string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();

            //즐겨찾기 추가 부분 소스
            if (MsgBox.Show(String.Format("[ {0} ] 를(을) 자주 쓰는 메뉴로 등록하시겠습니까?", menuName), "자주 쓰는 메뉴 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (RegistorFavoritesMenu(menuId) > 0)
                {
                    MsgBox.Show(String.Format("[ {0} ] 가(이) 자주 쓰는 메뉴로 등록되었습니다.", menuName), "자주 쓰는 메뉴 등록");
                }
            }
            InitUserMenu();
        }

        private void MenuItem1_delete_Click(object sender, EventArgs e)
        {
            string menuName = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuName"].ToString();
            string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();
            menuId = menuId.Substring(0, menuId.Length - 1);
            //즐겨찾기 삭제 부분 소스
            if (MsgBox.Show(String.Format("[ {0} ] 를(을) 자주 쓰는 메뉴 삭제하시겠습니까?", menuName), "자주 쓰는 메뉴 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                if (DeleteFavoritesMenu(menuId) > 0)
                {
                    MsgBox.Show(String.Format("[ {0} ] 가(이) 자주 쓰는 메뉴 삭제되었습니다.", menuName), "자주 쓰는 메뉴 삭제");
                }
            }
            InitUserMenu();
        }

        internal void AddCustomButton(DataSet ds)
        {
            if(ds.Tables[0].Rows.Count != 0)
            {
                RibbonPageGroup customRpg = new RibbonPageGroup();
                customRpg.Text = "customButton";
                customRpg.Name = "customButton";
                customRpg.ShowCaptionButton = false;

                string menuId = (tlMenu.GetDataRecordByNode(tlMenu.FocusedNode) as DataRowView).Row["MenuId"].ToString();

                foreach (DataRow drTemp in ds.Tables[0].Rows)
                {
                    BarButtonItem bbi = new BarButtonItem();
                    bbi.Caption = drTemp["BtnCaption"].ToString();
                    bbi.Name = drTemp["BtnNm"].ToString();

                    ribbon.Items.Add(bbi);

                    Bitmap bmp = new Bitmap(@"Resources\Document.png");

                    bbi.ImageOptions.LargeImage = bmp; 

                    customRpg.ItemLinks.Add(bbi);

                    bbi.ItemClick += Bbi_ItemClick;

                }
                ribbonPage1.Groups.Add(customRpg);
            }
            // Manually add the created item to the item collection of the RibbonControl. 
            //ribbon.Items.Add(bbi);
            //if (spb.BtGb == "USERBTGB01")
            //{
            //    //화면이동
            //    bbi.ImageOptions.SvgImage = global::TLF.Framework.BaseFrame.Properties.Resources.changeview;
            //    bbi.Hint = "화면이동";
            //}
            //else if (spb.BtGb == "USERBTGB02")
            //{
            //    //프로시저
            //    bbi.ImageOptions.SvgImage = global::TLF.Framework.BaseFrame.Properties.Resources.floatingobjectbringinfrontoftext;
            //    bbi.Hint = "프로시져";
            //}
            //else if (spb.BtGb == "USERBTGB03")
            //{
            //    //출력
            //    bbi.ImageOptions.SvgImage = global::TLF.Framework.BaseFrame.Properties.Resources.;
            //    bbi.Hint = "출력";
            //}
            //else
            //{
            //    bbi.ImageOptions.SvgImage = global::TLF.Framework.BaseFrame.Properties.Resources.floatingobjectbringinfrontoftext;
            //}
        }

        private void Bbi_ItemClick(object sender, ItemClickEventArgs e)
        {
            UIFrame uiFrame = ActiveMdiChild as UIFrame;

            uiFrame.CustomButtonClick(e.Item as BarButtonItem);
        }

        internal void DelCustomButton()
        {
            RibbonPageGroup customrpg = ribbonPage1.GetGroupByName("customButton");
            ribbonPage1.Groups.Remove(customrpg);
        }
    }
}