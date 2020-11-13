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
    public partial class MatInfoPopup : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// MatInfoPopup Form을 생성합니다.
        /// </summary>
        public MatInfoPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        DataTable dtDataSource = new DataTable();
        private DataRow _matData;
        private string setData;
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
                    DataTable dt = viewGetMatInfo.GetAddedModifedData();

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
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
            viewGetMatInfo.BeginInit();

            viewGetMatInfo.InitGridColumn("ItemSeq                      ", "No                      ", 70, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("CustSeq                      ", "거래처번호              ", 70, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("CustNm                       ", "거래처명                ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemNo                       ", "자재 번호                ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemNm                       ", "자재명                  ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemGB                       ", "자재 구분                ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ModelCd                      ", "모델                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemCls1                     ", "대분류                  ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemCls2                     ", "중분류                  ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("ItemCls3                     ", "소분류                  ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("UnitCd                       ", "단위                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("Spec                         ", "규격                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("MaterialCd                   ", "재질                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("Thickness                    ", "두께                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("Weight                       ", "무게                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("Remark                       ", "비고                    ", 70, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("UseYn                        ", "사용 여부                ", 70, 0, false, true, ColumnDataType.CheckEdit, HorzAlignment.Near);
            viewGetMatInfo.InitGridColumn("InspYn                       ", "검사 여부                ", 70, 0, false, false, ColumnDataType.CheckEdit, HorzAlignment.Near);
            viewGetMatInfo.InitComboBoxColumn("ItemGB", MesCodeUtil.GetCodeMaster("MD_ITEMGB", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("ItemCls1", MesCodeUtil.GetCodeMaster("MD_ItemCls1", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("ItemCls2", MesCodeUtil.GetCodeMaster("MD_ItemCls2", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("ItemCls3", MesCodeUtil.GetCodeMaster("MD_ItemCls3", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("UnitCd", MesCodeUtil.GetCodeMaster("UnitCd", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("ModelCd", MesCodeUtil.GetCodeMaster("MD_ModelCd", ""), false, false);
            viewGetMatInfo.InitComboBoxColumn("MaterialCd", MesCodeUtil.GetCodeMaster("MD_MaterialCd", ""), false, false);

            viewGetMatInfo.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            DataTable dt = AppCodeUtil.GetCodeMaster("MD_ItemGB", string.Empty);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["CodeValue"].ToString() == "ITEMGB01" || dr["CodeValue"].ToString() == "ITEMGB02")
                {
                    dr.Delete();
                }
            }
            dt.AcceptChanges();
            matGBSearch.InitData(dt);
            ComboCls1_Srch.InitData(AppCodeUtil.GetCodeMaster("MD_ItemCls1", string.Empty));
            ComboCls2_Srch.InitData(AppCodeUtil.GetCodeMaster("MD_ItemCls2", string.Empty));
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            txtMatNm_Srch.EditValue = GetData;
        }

        #endregion


        // Common Event 처리 Method

        #region :: SelectionData :: 조회 처리 Method

        /// <summary>
        /// 조회 처리 Method
        /// </summary>
        private void SelectionData()
        {
            string chkSearch = "1";
            
            using (var wb = new WsBiz(AppConfig.MESDB))
            {
                DataSet ds;

                var query = "dbo.usp_MdItem_CRUD";

                var paramList = new string[] {
                                                "@iOp1"
                                               ,"@iOp2"
                                               ,"@CustNm"
                                               ,"@ItemNo"
                                               ,"@ItemNm"
                                               ,"@ItemGB"
                                               ,"@ItemCls1"
                                               ,"@ItemCls2"
                                               ,"@UseYn"
                                            };

                var valueList = new object[] {
                                                 "R"
                                                ,"4"
                                                ,btnCustNmSearch.EditValue
                                                ,txtMatNo_Srch.EditValue
                                                ,txtMatNm_Srch.EditValue
                                                ,matGBSearch.EditValue
                                                ,ComboCls1_Srch.EditValue
                                                ,ComboCls2_Srch.EditValue
                                                ,chkSearch
                                            };

                ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                gridGetMatInfo.FillGrid(ds);
                viewGetMatInfo.BestFitColumns();
            }
        }

        #endregion

        #region :: NewData :: 신규 처리 Method

        /// <summary>
        /// 신규 처리 Method
        /// </summary>
        private void NewData()
        {
            viewGetMatInfo.AddNewRow();
        }

        #endregion

        #region :: DeleteData :: 삭제 처리 Method

        /// <summary>
        /// 삭제 처리 Method
        /// </summary>
        private void DeleteData()
        {
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = " DELETE FROM MatInfoPopup WHERE Seq = @Seq ";

                string[] paramList = new string[] { "@Seq" };

                object[] valueList = new object[] { Convert.ToInt64(viewGetMatInfo.GetFocusedDataRow()["Seq"]) };

                wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDTEXT, paramList, valueList);
            }
        }

        #endregion

        #region :: SaveData :: 저장 처리 Method

        /// <summary>
        /// 저장 처리 Method
        /// </summary>
        private void SaveData(DataTable dt)
        {
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo._Save";

                string[] paramList = new string[] { "@Seq",
                                                    "@PlantCode",
                                                    "@NoticeType",
                                                    "@Title",
                                                    "@MenuId",
                                                    "@Contents",
                                                    "@NoticePriority",
                                                    "@REG_EMP",
                                                    "@REG_DT",
                                                    "@FgCd" };

                wb.Tx_ExecuteNonQueryByDataTable(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, dt);
            }
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

            if (viewGetMatInfo.GetFocusedDataRow() == null)
            {
                MsgBox.Show("삭제할 공지사항을 선택해 주세요", "삭제 확인");
                return false;
            }

            string message = String.Format("공지사항 [ {0} ] 을(를) 삭제하시겠습니까?", viewGetMatInfo.GetFocusedDataRow()["Title"]);

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

        private void view_L_PP0321_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
        }

        private void view_L_PP0321_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                DataSet dataSet;
                DataRow dr = viewGetMatInfo.GetFocusedDataRow();

                using (var wb = new WsBiz(AppConfig.MESDB))
                {

                    var query = "dbo.usp_MdItem_CRUD";

                    var paramList = new string[] {
                                                "@iOp1"
                                               ,"@iOp2"
                                               ,"@ItemNo"
                                               ,"@ItemNm"
                                               ,"@ItemCls1"
                                               ,"@ItemCls2"
                                            };

                    var valueList = new object[] {
                                                 "R"
                                                ,"4"
                                                ,dr["ItemNo"]
                                                ,dr["ItemNm"]
                                                ,dr["ItemCls1"]
                                                ,dr["ItemCls2"]
                                            };

                    dataSet = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                }

                MatData = dataSet.Tables[0].Rows[0];

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SelectionData();
            InitGridControl();
        }

        public DataRow MatData
        {
            get { return _matData; }
            set { _matData = value; }
        }

        public string GetData
        {
            get { return setData; }
            set { setData = value; }
        }

        private void btnCustNmSearch_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (btnCustNmSearch.ReadOnly) return;
            using (CustInfoPopup iip = new CustInfoPopup())
            {
                if (iip.ShowDialog(this) == DialogResult.OK)
                {
                    DataRow dr = iip.CustData;
                    btnCustNmSearch.EditValue = dr["CustNm"].ToString();
                }
            }
        }

        private void btnCustNmSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //엔터 입력시 Selectiondata() - 자재번호, 자재명
        private void Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SelectionData();
            }
        }
        
    }
    

   


}
