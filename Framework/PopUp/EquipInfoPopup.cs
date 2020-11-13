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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Mask;

namespace TLF.Framework.PopUp
{
    /// <summary>
    /// 공지사항을 저장하고 조회하는 Form입니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-09 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class EquipInfoPopup : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ItemInfoPopup Form을 생성합니다.
        /// </summary>
        public EquipInfoPopup()
        {
            DevExpress.Utils.AppearanceObject.DefaultFont = new Font("맑은 고딕", 9);
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        DataTable dtDataSource = new DataTable();
        RepositoryItemLookUpEdit lueCust = new RepositoryItemLookUpEdit();
        RepositoryItemLookUpEdit lueUser = new RepositoryItemLookUpEdit();
        RepositoryItemSpinEdit spinPrice = new RepositoryItemSpinEdit();

        private DataRow _EqData;
        private string _EqNm;


        public string EqNm
        {
            get { return _EqNm; }
            set { _EqNm = value; }
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
                    DataTable dt = viewGetEqEquipmentInfo.GetAddedModifedData();

                    if (dt != null)
                        SaveData(dt);

                    // 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                    SelectionData();
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
        }
        #endregion

        #region :: view_L_PP0321InitNewRow :: 신규로 생성되는 Row의 기본값을 정의합니다.

        /// <summary>
        /// 신규로 생성되는 Row의 기본값을 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_L_PP0321InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
        }

        #endregion

        #region :: view_L_PP0321FocusedRowChanged :: Master View Focused Row가 변경되면 해당 상세내용을 MemoEdit에 보여줍니다.

        /// <summary>
        /// Master View Focused Row가 변경되면 해당 상세내용을 MemoEdit에 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_L_PP0321FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //DataRow dr = view_L_PP0321.GetFocusedDataRow();
            //if (dr != null && dr["FgCd"].ToString() != "")
            //{
            //}
        }

        #endregion

        #region :: txtContents_EditValueChanged :: 공지사항 상세 내용이 바뀌면 DataSource에도 반영합니다.

        /// <summary>
        /// 공지사항 상세 내용이 바뀌면 DataSource에도 반영합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContents_EditValueChanged(object sender, EventArgs e)
        {
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
            try
            {
                #region :: 구매처 ::

                using (var wb = new WsBiz(AppConfig.MESDB))
                {
                    DataSet ds;

                    var query = "dbo.usp_MdCust_CRUD";

                    var paramList = new string[] { "@iOp1           "
                                                  ,"@iOp2           "
                    };

                    var valueList = new object[] { "R"
                                                  ,"4"
                    };

                    ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                    lueCust.DataSource = ds.Tables[0];
                    lueCust.DisplayMember = "CustNm";
                    lueCust.ValueMember = "CustSeq";
                    lueCust.NullText = string.Empty;
                }

                #endregion

                #region :: 사용자 정보 ::

                using (var wb = new WsBiz(AppConfig.MESDB))
                {
                    DataSet ds;

                    var query = "dbo.UserInfo_Select";
                    var paramList = new string[] { "@UserId",
                                                   "@UserName",
                    };
                    var valueList = new object[] { "",
                                                   ""
                    };

                    ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                    lueUser.DataSource = ds.Tables[0];
                    lueUser.DisplayMember = "UserName";
                    lueUser.ValueMember = "UserId";
                    lueUser.NullText = string.Empty;
                }

                #endregion

                #region :: 가격 ::

                spinPrice.Mask.MaskType = MaskType.Numeric;
                spinPrice.Mask.UseMaskAsDisplayFormat = true;
                spinPrice.Mask.EditMask = "c";

                #endregion
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            try
            {
                viewGetEqEquipmentInfo.BeginInit();

                viewGetEqEquipmentInfo.InitGridColumn("EqSeq             ", "설비 Seq       ", 60, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("EqCd              ", "설비 코드       ", 60, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("EqNm              ", "설비명        ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("EqCls             ", "설비 구분       ", 80, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("Spec              ", "규격           ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("CountryCd         ", "제조국가       ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("MakerNm           ", "제조사명      ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("PuCust            ", "구매처 명      ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("PuDt              ", "구매 일자       ", 80, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("PuPrice           ", "구매가격       ", 110, 0, false, true, ColumnDataType.Default, HorzAlignment.Far);
                viewGetEqEquipmentInfo.InitGridColumn("OilType           ", "유류 타입       ", 80, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("OilExchCycle      ", "유류 교환 주기   ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Far);
                viewGetEqEquipmentInfo.InitGridColumn("ManagerEmpNo      ", "관리자 사번    ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("WorkerEmpNo       ", "부관리자 사번  ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("InspCycle         ", "점검 주기(월)  ", 80, 0, false, true, ColumnDataType.Default, HorzAlignment.Far);
                viewGetEqEquipmentInfo.InitGridColumn("LastInspDt        ", "마지막 점검 일자", 90, 0, false, true, ColumnDataType.DateTime, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("StatusCd          ", "상태 코드       ", 60, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("UseYN             ", "사용 여부       ", 60, 0, false, true, ColumnDataType.CheckEdit, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("Image             ", "설비 이미지     ", 100, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("RegUserId         ", "등록자 ID       ", 60, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("RegDt             ", "등록일시       ", 80, 0, false, true, ColumnDataType.DateTime, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("ModUserId         ", "수정자 ID       ", 60, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("ModDt             ", "수정일시       ", 80, 0, false, true, ColumnDataType.DateTime, HorzAlignment.Near);
                viewGetEqEquipmentInfo.InitGridColumn("Remark            ", "비고           ", 100, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);

                viewGetEqEquipmentInfo.InitComboBoxColumn("EqCls", AppCodeUtil.GetCodeMaster("EQ_Type", ""));
                viewGetEqEquipmentInfo.InitComboBoxColumn("CountryCd", AppCodeUtil.GetCodeMaster("COUNTRY", ""));
                viewGetEqEquipmentInfo.InitComboBoxColumn("OilType", AppCodeUtil.GetCodeMaster("OilType", ""));
                viewGetEqEquipmentInfo.InitComboBoxColumn("StatusCd", AppCodeUtil.GetCodeMaster("EqStateCd", ""));
                viewGetEqEquipmentInfo.Columns["PuCust"].ColumnEdit = lueCust;
                viewGetEqEquipmentInfo.Columns["ManagerEmpNo"].ColumnEdit = lueUser;
                viewGetEqEquipmentInfo.Columns["WorkerEmpNo"].ColumnEdit = lueUser;
                viewGetEqEquipmentInfo.Columns["RegUserId"].ColumnEdit = lueUser;
                viewGetEqEquipmentInfo.Columns["ModUserId"].ColumnEdit = lueUser;
                viewGetEqEquipmentInfo.Columns["PuPrice"].ColumnEdit = spinPrice;

                RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
                textEdit.DisplayFormat.FormatType = FormatType.DateTime;
                textEdit.DisplayFormat.FormatString = "yyyy-MM-dd";
                viewGetEqEquipmentInfo.Columns["PuDt"].ColumnEdit = textEdit;
                viewGetEqEquipmentInfo.Columns["LastInspDt"].ColumnEdit = textEdit;
                viewGetEqEquipmentInfo.Columns["RegDt"].ColumnEdit = textEdit;
                viewGetEqEquipmentInfo.Columns["ModDt"].ColumnEdit = textEdit;

                viewGetEqEquipmentInfo.EndInit();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            #region :: 설비 구분 ::

            ComboEqGB_Srch.InitData(AppCodeUtil.GetCodeMaster("EQ_Type", ""));

            #endregion
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtEqNmSearch.EditValue = _EqNm;
        }

        #endregion

        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            DataSet ds;

            using (var wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                var query = "dbo.usp_MdEquipment_CRUD";

                var paramList = new string[] { "@iOp1       "
                                              ,"@iOp2       "
                                              ,"@EqCd       "
                                              ,"@EqNm       "
                                              ,"@EqCls      "
                                              ,"@PuDt_Start "
                                              ,"@PuDt_End   "
                                              ,"@UseYN      "
                };

                var valueList = new object[] { "R"
                                              ,"1"
                                              ,txtEqNo_Srch.EditValue
                                              ,txtEqNmSearch.EditValue
                                              ,ComboEqGB_Srch.EditValue
                                              ,dtPuDt_Search.EditValueFrom == null ? "" : dtPuDt_Search.EditValueFrom
                                              ,dtPuDt_Search.EditValueTo == null ? "" : dtPuDt_Search.EditValueTo
                                              ,1
                };

                ds = wb.NTx_ExecuteDataSet(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);

                if (ds.Tables[0].Rows.Count <= 0)
                {
                    NewData();
                }

                gridGetEqEquipmentInfo.FillGrid(ds);
                viewGetEqEquipmentInfo.BestFitColumns();
            }
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            viewGetEqEquipmentInfo.AddNewRow();
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

            if (viewGetEqEquipmentInfo.GetFocusedDataRow() == null)
            {
                MsgBox.Show("삭제할 공지사항을 선택해 주세요", "삭제 확인");
                return false;
            }

            string message = String.Format("공지사항 [ {0} ] 을(를) 삭제하시겠습니까?", viewGetEqEquipmentInfo.GetFocusedDataRow()["Title"]);

            return MsgBox.Show(message, "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
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

        #endregion

        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: view_L_PP0321_DoubleClick :: 그리드 더블 클릭 Event

        private void view_L_PP0321_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataSet dataSet;
                DataRow dr = viewGetEqEquipmentInfo.GetFocusedDataRow();

                using (var wb = new WsBiz(AppConfig.MESDB))
                {

                    var query = "dbo.usp_MdEquipment_CRUD";

                    var paramList = new string[] {
                                                "@iOp1"
                                               ,"@iOp2"
                                               ,"@EqCd"
                                            };

                    var valueList = new object[] {
                                                 "R"
                                                ,"2"
                                                ,dr["EqCd"]
                                            };

                    dataSet = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                }

                EqData = dataSet.Tables[0].Rows[0];

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        #region :: SearchBtn_Click :: 검색 Button Click

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                SelectionData();
                InitGridControl();
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        #endregion

        public DataRow EqData
        {
            get { return _EqData; }
            set { _EqData = value; }
        }
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

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
