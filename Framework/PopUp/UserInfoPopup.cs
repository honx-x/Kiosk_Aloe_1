using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using TLF.Business.WSBiz;
using TLF.Framework.Config;
using TLF.Framework.ExceptionHelper;
using TLF.Framework.MessageHelper;
using TLF.Framework.Utility;
using DevExpress.Utils;
using System.Drawing;
using TLF.Framework.Collections;

namespace TLF.Framework.PopUp
{
    /// <summary>
    /// 사용자 정보를 보여주는 PopUp 입니다.
    /// </summary>
    /// <remarks>
    /// (2009-10-01) 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class UserInfoPopup : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// GetUserInfoPopup Form을 생성합니다.
        /// </summary>
        public UserInfoPopup(DataSet ds)
        {
            _userData = ds;
            InitializeComponent();
        }

        /// <summary>
        /// 생성자
        /// </summary>
        public UserInfoPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private DataSet _userData;
        private string userId = string.Empty;
        private string departmentName = string.Empty;
        private string userName = string.Empty;
        private string emailAddress = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UserData :: 사용자정보 데이터

        /// <summary>
        /// 이동할 데이터
        /// </summary>
        public DataSet UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }

        /// <summary>
        /// 사번
        /// </summary>
        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        /// <summary>
        /// 부서이름
        /// </summary>
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        /// <summary>
        /// 사용자이름
        /// </summary>
        public string USERName
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// 사용자이메일
        /// </summary>
        public string Email
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UserInfoPopup_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Load(object sender, EventArgs e)
        {
            try
            {
                InitGlobalInstance();
                InitGridControl();
                InitComboBox();
                InitControls();

                // Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                SelectionData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Authentication(object sender, EventArgs e)
        {
            try
            {
                UserAuthProcess();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Selection(object sender, EventArgs e)
        {
            try
            {
                if (!CheckSelectionCondition()) return;

                SetFormLayout();
                SetGridLayout();
                SelectionData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_New(object sender, EventArgs e)
        {
            try
            {
                if (!CheckNewCondition()) return;

                NewData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Delete(object sender, EventArgs e)
        {
            try
            {
                if (!CheckDeleteCondition()) return;

                DeleteData();

                // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                //SelectionData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Save(object sender, EventArgs e)
        {
            try
            {
                if (!CheckSaveCondition()) return;

                SaveData();

                // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                //SelectionData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Print :: MainForm의 인쇄 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 인쇄 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Print(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPrintCondition()) return;

                PrintData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: UserInfoPopup_Chart :: MainForm의 Chart Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 Chart Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInfoPopup_Chart(object sender, EventArgs e)
        {
            try
            {
                if (!CheckChartCondition()) return;

                ChartData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ComboBox_EditValueChanged :: ComboBox 값을 변경하면 발생합니다.

        /// <summary>
        /// ComboBox 값을 변경하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_EditValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: GridView_InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {

        }

        #endregion

        #region :: viewGetUserInfo_DoubleClick :: 선택된 행을 더블클릭하여 원하는 인사정보를 넘긴다.

        /// <summary>
        /// 선택된 행을 더블클릭하여 원하는 인사정보를 넘긴다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewGetUserInfo_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = viewGetUserInfo.GetFocusedDataRow();

            if (dr != null)
            {
                userId = dr["UserId"].ToString();
                departmentName = dr["DepartmentName"].ToString();
                userName = dr["UserName"].ToString();
                emailAddress = dr["EmailAddress"].ToString();

                DialogResult = DialogResult.OK;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        #region :: InitGlobalInstance :: 전역변수 Initialize

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewGetUserInfo.BeginInit();

            viewGetUserInfo.InitGridColumn("UserId", "사용자 사번", 80, 0, false, true, ColumnDataType.Default);
            viewGetUserInfo.InitGridColumn("UserName", "사용자 명", 100, 0, false, true, ColumnDataType.Default);
            viewGetUserInfo.InitGridColumn("DepartmentName", "부서명", 170, 0, false, true, ColumnDataType.Default);
            viewGetUserInfo.InitGridColumn("EmailAddress", "이메일주소", 170, 0, false, true, ColumnDataType.Default);

            viewGetUserInfo.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txt_UserNm_Srch.EditValue = userName;
        }

        #endregion

        // 사용자 권한 처리 Method

        #region :: UserAuthProcess :: 사용자 권한 처리

        /// <summary>
        /// 사용자 권한 처리
        /// </summary>
        private void UserAuthProcess()
        {
        }

        #endregion

        // Form 간 Data 전송 처리 Method

        #region :: LinkData :: Form 간 Data 전송 처리

        /// <summary>
        /// Form 간 Data 전송 처리
        /// </summary>
        private void LinkData()
        {
        }

        #endregion

        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            using (var wb = new WsBiz(AppConfig.MESDB))
            {
                var query = "dbo.UserInfo_Select";
                var paramList = new string[] { "@UserId",
                                               "@UserName",
                };
                var valueList = new object[] { txt_UserId_Srch.EditValue,
                                               txt_UserNm_Srch.EditValue
                };

                UserData = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);
            }

            gridGetUserInfo.FillGrid(UserData);
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData()
        {
        }

        #endregion

        #region :: PrintData :: 인쇄 처리 Method

        /// <summary>
        /// 인쇄 처리 Method
        /// </summary>
        private void PrintData()
        {
        }

        #endregion

        #region :: ChartData :: Chart 처리 Method

        /// <summary>
        /// Chart 처리 Method
        /// </summary>
        private void ChartData()
        {
        }

        #endregion


        // Common Event 처리 Method 조건 Check

        #region :: CheckSelectionCondition :: 조회 조건 Check Method

        /// <summary>
        /// 조회 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckSelectionCondition()
        {
            return true;
        }

        #endregion

        #region :: CheckNewCondition :: 신규 조건 Check Method

        /// <summary>
        /// 신규 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckNewCondition()
        {
            return true;
        }

        #endregion

        #region :: CheckDeleteCondition :: 삭제 조건 Check Method

        /// <summary>
        /// 삭제 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckDeleteCondition()
        {
            return true;
        }

        #endregion

        #region :: CheckSaveCondition :: 저장 조건 Check Method

        /// <summary>
        /// 저장 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckSaveCondition()
        {
            return true;
        }

        #endregion

        #region :: CheckPrintCondition :: 인쇄 조건 Check Method

        /// <summary>
        /// 인쇄 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckPrintCondition()
        {
            return true;
        }

        #endregion

        #region :: CheckChartCondition :: Chart 조건 Check Method

        /// <summary>
        /// Chart 조건 Check Method
        /// </summary>
        /// <returns></returns>
        private bool CheckChartCondition()
        {
            return true;
        }

        #endregion


        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: SetFormLayout :: Form의 Layout을 변경합니다.

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        #endregion

        #region :: SetGridLayout :: Grid의 Layout을 변경합니다.

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        #endregion

        #region :: Srch_KeyDown :: 검색 KeyDown

        private void Srch_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        SelectionData();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: btn_Srch_Click :: 검색 Button Click

        private void btn_Srch_Click(object sender, EventArgs e)
        {
            try
            {
                SelectionData();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
