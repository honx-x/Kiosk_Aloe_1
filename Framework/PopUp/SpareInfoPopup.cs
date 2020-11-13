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
    /// 공지사항을 저장하고 조회하는 Form입니다.
    /// </summary>
    /// <remarks>
    /// 2009-01-09 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class SpareInfoPopup : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// MD_CustInfoPopup1 Form을 생성합니다.
        /// </summary>
        public SpareInfoPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        DataTable dtDataSource = new DataTable();
        private DataRow _SpareData;
        private string _SpareNm;

        public string SpareNm
        {
            get { return _SpareNm; }
            set { _SpareNm = value; }
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
                    //DataTable dt = viewGetItemInfo.GetAddedModifedData();

                    //if (dt != null)
                    //    SaveData(dt);

                    //// 저장 후 조회를 실행해야 한다면 주석을 제거하세요.
                    //SelectionData();
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
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            view_get_spare_info.BeginInit();

            view_get_spare_info.InitGridColumn("EqSpareSeq         ", "예비품 일련번호        ", 120, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);;
            view_get_spare_info.InitGridColumn("EqSpareNm          ", "예비품명              ", 120, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);;
            view_get_spare_info.InitGridColumn("EqCd               ", "설비번호              ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("EqSpareCls1        ", "대분류                ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("EqSpareCls2        ", "중분류                ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("CustSeq            ", "거래처 일련번호        ", 120, 0, false, false, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("Material           ", "재질                  ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("UnitCd             ", "단위                  ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("CustNm             ", "거래처명              ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("Weight             ", "무게                  ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("BaseQty            ", "기초재고              ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("Spec               ", "규격                  ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("RegUserId          ", "등록자 ID             ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("RegDt              ", "등록 일시             ", 120, 0, false, true, ColumnDataType.DateTime, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("ModUserId          ", "수정자 ID             ", 70, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("ModDt              ", "수정 일시             ", 120, 0, false, true, ColumnDataType.DateTime, HorzAlignment.Near);
            view_get_spare_info.InitGridColumn("Remark             ", "비고                  ", 300, 0, false, true, ColumnDataType.Text, HorzAlignment.Near);
            view_get_spare_info.InitComboBoxColumn("EqSpareCls1", MesCodeUtil.GetCodeMaster("EqSpareCls1", ""), false, false);
            view_get_spare_info.InitComboBoxColumn("EqSpareCls2", MesCodeUtil.GetCodeMaster("EqSpareCls2", ""), false, false);
            view_get_spare_info.InitComboBoxColumn("UnitCd", MesCodeUtil.GetCodeMaster("UnitCd", ""), false, false);
            view_get_spare_info.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            mcbEqSpareCls1_Search.InitData(AppCodeUtil.GetCodeMaster("EqSpareCls1", ""));
            mcbEqSpareCls1_Search.EditValue = string.Empty;
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtEqSpareNm_Search.EditValue = _SpareNm;
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
                DataSet ds;

                var query = "usp_EqSpare_CRUD";

                var paramList = new string[] { "@iOp1            "
                                             , "@iOp2            "
                                             , "@EqSpareNm       "
                                             , "@CustNm          "
                                             , "@EqNm            "
                                             , "@EqSpareCls1     "
                                             , "@DeleteYn        "      
                                             

                                             };
                var valueList = new object[] { "R"
                                             , "1"
                                             , String.IsNullOrEmpty(txtEqSpareNm_Search.Text) ? "" : txtEqSpareNm_Search.Text
                                             , String.IsNullOrEmpty(txtCustNm_Search.Text) ? "" : txtCustNm_Search.Text
                                             , String.IsNullOrEmpty(txtEqNm_Search.Text) ? "" : txtEqNm_Search.Text
                                             , mcbEqSpareCls1_Search.EditValue
                                             , 0
                                             };

                ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                grid_get_spare_info.FillGrid(ds);
            }
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            //viewGetItemInfo.AddNewRow();
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            //using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            //{
            //    string query = " DELETE FROM SpareInfoPopup1 WHERE Seq = @Seq ";

            //    string[] paramList = new string[] { "@Seq" };

            //    object[] valueList = new object[] { Convert.ToInt64(viewGetItemInfo.GetFocusedDataRow()["Seq"]) };

            //    wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, paramList, valueList);
            //}
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData(DataTable dt)
        {
            //using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            //{
            //    string query = "dbo._Save";

            //    string[] paramList = new string[] { "@Seq",
            //                                        "@PlantCode",
            //                                        "@NoticeType",
            //                                        "@Title",
            //                                        "@MenuId",
            //                                        "@Contents",
            //                                        "@NoticePriority",
            //                                        "@REG_EMP",
            //                                        "@REG_DT",
            //                                        "@FgCd" };

            //    wb.Tx_ExecuteNonQueryByDataTable(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, dt);
            //}
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
            return true;
            //if (!CurrentUser.IsAdmin) return false;

            //if (viewGetItemInfo.GetFocusedDataRow() == null)
            //{
            //    MsgBox.Show("삭제할 공지사항을 선택해 주세요", "삭제 확인");
            //    return false;
            //}

            //string message = String.Format("공지사항 [ {0} ] 을(를) 삭제하시겠습니까?", viewGetItemInfo.GetFocusedDataRow()["Title"]);

            //return MsgBox.Show(message, "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? true : false;
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


        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SelectionData();
        }

        public DataRow SpareData
        {
            get { return _SpareData; }
            set { _SpareData = value; }
        }

        private void txtItemNm_Srch_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void viewGetCustInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = view_get_spare_info.GetFocusedDataRow();
                SpareData = dr;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        private void Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectionData();
            }
        }

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        // 기타 Control Event 처리 Method는 아래에 기술하세요.
    }
}
