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
    public partial class CheckPopUp : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// 생성자
        /// </summary>
        public CheckPopUp()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::
        private DataRow dr = null;
        private string CodeValue = string.Empty;
        private string DisPlayValue = string.Empty;
        private int USE_FLAG = 1;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: UserData :: 사용자정보 데이터

        /// <summary>
        /// CodeValue
        /// </summary>
        public string GetCode
        {
            get { return CodeValue; }
            set { CodeValue = value; }
        }

        /// <summary>
        /// DisplayValue
        /// </summary>
        public string GetDisp
        {
            get { return DisPlayValue; }
            set { DisPlayValue = value; }
        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CheckPopUp_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Load(object sender, EventArgs e)
        {
            try
            {
                InitGlobalInstance();
                InitGridControl();
                InitComboBox();
                InitControls();

                // Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                SelectionData();

                //Grid_Master.FillGrid();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: CheckPopUp_Authentication :: 사용자 권한 처리 시 발생합니다.

        /// <summary>
        /// 사용자 권한 처리 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Authentication(object sender, EventArgs e)
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

        #region :: CheckPopUp_Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Selection(object sender, EventArgs e)
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

        #region :: CheckPopUp_New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_New(object sender, EventArgs e)
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

        #region :: CheckPopUp_Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Delete(object sender, EventArgs e)
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

        #region :: CheckPopUp_Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Save(object sender, EventArgs e)
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

        #region :: CheckPopUp_Print :: MainForm의 인쇄 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 인쇄 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Print(object sender, EventArgs e)
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

        #region :: CheckPopUp_Chart :: MainForm의 Chart Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 Chart Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckPopUp_Chart(object sender, EventArgs e)
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
            DataRow dr = View_Master.GetFocusedDataRow();

            if (dr != null)
            {
                CodeValue = dr["CodeValue"].ToString();
                DisPlayValue = dr["DisPlayValue"].ToString();

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
            View_Master.BeginInit();

            View_Master.InitGridColumn("CodeValue      ",    "항목 코드",   80, 0, false, true, ColumnDataType.Default);
            View_Master.InitGridColumn("DisplayValue   ",    "항목 명  ",   100, 0, false, true, ColumnDataType.Default);

            View_Master.EndInit();
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
            Disp_Srch.Text = GetDisp;
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
            DataSet ds = null; 

            using (var wb = new WsBiz(AppConfig.MESDB))
            {
                var query = "dbo.usp_EqChecklist_CRUD";
                var paramList = new string[] {
                                               "iOp1",
                                               "iOp2",
                                               "@CodeValue",
                                               "@DisplayValue",
                };
                var valueList = new object[] {
                                               "R",
                                               "4",
                                               Code_Srch.Text,
                                               Disp_Srch.Text
                };

                ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                View_Master.FillGrid(ds);
            }
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

        private void Disp_Srch_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    SelectionData();
                    break;
            }
        }

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
