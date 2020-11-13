using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Windows.Forms;
using TLF.Business.WSBiz;
using TLF.Framework.Config;
using TLF.Framework.ControlLibrary;
using TLF.Framework.ExceptionHelper;
using TLF.Framework.MessageHelper;
using TLF.Framework.PopUp;
using TLF.Framework.Utility;

namespace TLF.Framework.PopUp
{
    /// <summary>
    /// 공정 팝업
    /// </summary>
    /// <remarks>
    /// 2020-11-02 최초생성 : 신명수
    /// </remarks>
    public partial class ProcInfoPopup : TLF.Framework.BaseFrame.UIFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// PU_ORDER_REQ Form을 생성합니다.
        /// </summary>
        public ProcInfoPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private DataRow _ProcData;
        private string _ProcNm;

        public DataRow ProcData
        {
            get { return _ProcData; }
            set { _ProcData = value; }
        }

        public string ProcNm
        {
            get { return _ProcNm; }
            set { _ProcNm = value; }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: _Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Load(object sender, EventArgs e)
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

        #region :: _Selection :: MainForm의 조회 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 조회 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Selection(object sender, EventArgs e)
        {
            try
            {
                if (CheckSelectionCondition())
                {
                    SelectionData();
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: _New :: MainForm의 신규 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 신규 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _New(object sender, EventArgs e)
        {
            try
            {
                if (CheckNewCondition())
                {
                    NewData();
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: _Delete :: MainForm의 삭제 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 삭제 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Delete(object sender, EventArgs e)
        {
            try
            {
                if (CheckDeleteCondition())
                {
                    DeleteData();

                    // 삭제 후 조회를 실행해야 한다면 주석을 제거하세요.
                    SelectionData();
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: _Save :: MainForm의 저장 Button을 Click 하면 발생합니다.

        /// <summary>
        /// MainForm의 저장 Button을 Click 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _Save(object sender, EventArgs e)
        {
            try
            {
                if (CheckSaveCondition())
                {

                }
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
            view_Process.BeginInit();

            view_Process.InitGridColumn("ProcSeq     ", "공정일련번호    ", 100, 0, false, false, ColumnDataType.Default, HorzAlignment.Center);
            view_Process.InitGridColumn("ProcCd      ", "공정코드        ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Center);
            view_Process.InitGridColumn("ProcNm      ", "공정명          ", 150, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            view_Process.InitGridColumn("ProcEngNm   ", "공정명(영문)    ", 180, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            view_Process.InitGridColumn("ProcGb      ", "공정구분        ", 150, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            view_Process.InitGridColumn("Remark      ", "비고            ", 250, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            view_Process.InitGridColumn("UseYn       ", "사용여부        ", 250, 0, false, true, ColumnDataType.CheckEdit, HorzAlignment.Near);

            view_Process.InitComboBoxColumn("ProcGb       ", MesCodeUtil.GetCodeMaster("PROCGB", ""), false, false);

            view_Process.EndInit();
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
            txtProcNm_Srch.EditValue = _ProcNm;
        }

        #endregion

        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            try
            {
                DataSet ds;

                using (var wb = new WsBiz(AppConfig.MESDB))
                {
                    var query = "usp_MdProcess_CRUD";

                    var paramList = new string[] {"@iOp1",
                                                  "@iOp2",
                                                  "@ProcCd",
                                                  "@ProcNm",
                                                  "@ProcGb",
                                                  "@UseYn"
                    };

                    var valueList = new object[] { "R"
                                                  ,"1"
                                                  ,txtProcCd_Srch.EditValue
                                                  ,txtProcNm_Srch.EditValue
                                                  ,cmbProcGb_Srch.EditValue
                                                  ,1
                    };

                    ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                    view_Process.FillGrid(ds);
                }
            }
            catch (Exception ex)
            {
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
        private void SaveData(DataTable dt)
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
            //if (!CurrentUser.IsAdmin) return false;

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
            //if (!CurrentUser.IsAdmin) return false;
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
            //if (!CurrentUser.IsAdmin) return false;

            return true;
        }

        private void riBtnCheckEmpNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        }

        private void viewEqCheckHs_InitNewRow(object sender, InitNewRowEventArgs e)
        {
        }

        #endregion

        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: DoubleClick :: Grid view Double Click

        private void _viewDoubleClick(object sender, EventArgs e)
        {
            try
            {
                ProcData = view_Process.GetFocusedDataRow();

                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: _viewKeyDown :: Grid view KeyDown

        private void _viewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Enter:
                        ProcData = view_Process.GetFocusedDataRow();

                        this.Close();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: _btnSearchClick :: 검색 Button Click

        private void _btnSearchClick(object sender, EventArgs e)
        {
            SelectionData();
        }

        #endregion

        #region :: _SearchKeyDown :: 검색 KeyDown

        private void _SearchKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectionData();
                    break;
            }
        }

        #endregion

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }
    }
}
