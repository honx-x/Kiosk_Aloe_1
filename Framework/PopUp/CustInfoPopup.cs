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
    public partial class CustInfoPopup : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// MD_CustInfoPopup1 Form을 생성합니다.
        /// </summary>
        public CustInfoPopup()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        DataTable dtDataSource = new DataTable();
        private DataRow _custData;
        private string _CustNm;
        private string _Gubun;
        private string _SetData;

        public string CustNm
        {
            get { return _CustNm; }
            set { _CustNm = value; }
        }

        public string CustGubun
        {
            get { return _Gubun; }
            set { _Gubun = value; }
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
            viewGetCustInfo.BeginInit();

            viewGetCustInfo.InitGridColumn("UseYN        ", "사용 여부         ",  60, 0, false, false, ColumnDataType.CheckEdit, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("CustSeq      ", "거래처 일련번호  ", 100, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("CustNm       ", "거래처명        ", 100, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("BizNo        ", "사업자 번호      ",  90, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("PresidentNm  ", "대표이사명       ",  80, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("CompClass    ", "업태 코드         ",  80, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("CompType     ", "종목 코드         ",  80, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Tel          ", "전화번호         ",  90, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Fax          ", "팩스 번호         ",  90, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Zipcode      ", "우편번호         ",  60, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Address1     ", "주소             ", 200, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Address2     ", "상세주소         ",  60, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("CustGb       ", "거래처 구분       ",  80, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("TracBank     ", "거래은행         ",  80, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("BankNo       ", "계좌번호         ", 120, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("AccNm        ", "예금주명         ",  60, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("ManagerNm    ", "담당자명        ",  75, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("ManagerTel   ", "담당자 전화번호  ",  90, 0, false, false, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("ManagerMobile", "담당자 휴대폰 번호", 120, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("ManagerMail  ", "담당자 메일      ", 200, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);
            viewGetCustInfo.InitGridColumn("Remark       ", "비고             ", 100, 0, false,  true, ColumnDataType.Default, HorzAlignment.Near);


            viewGetCustInfo.InitComboBoxColumn("TracBank      ", MesCodeUtil.GetCodeMaster("Bank", ""), false, false);
            viewGetCustInfo.InitComboBoxColumn("CustGb        ", MesCodeUtil.GetCodeMaster("MD_CustGb", ""), false, false);

            viewGetCustInfo.EndInit();
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
            cmb_SLCustGb.InitData(AppCodeUtil.GetCodeMaster("MD_CustGb", ""));
            cmb_SLCustGb.EditValue = string.Empty;
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            if (_SetData != null)
            {
                txt_SLCustNm.EditValue = _SetData;
            }
            else if (_CustNm != null)
            {
                txt_SLCustNm.EditValue = _CustNm;
            }

            if (CustGubun != null)
            {
                cmb_SLCustGb.EditValue = CustGubun;
            }

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

                var query = "usp_MdCust_CRUD";
                var paramList = new string[] { "@iOp1",
                                               "@iOp2",
                                               "@CustNm",
                                               "@BizNo",
                                               "@CustGb",
                                               "@UseYn"
                };
                var valueList = new object[] { "R",
                                               "1",
                                               txt_SLCustNm.Text,
                                               txt_SLBizNo.Text,
                                               cmb_SLCustGb.EditValue,
                                               1
                };

                ds = wb.NTx_ExecuteDataSet(AppConfig.MESDB, query, AppConfig.COMMANDSP, paramList, valueList);

                gridGetCustInfo.FillGrid(ds);
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
            //    string query = " DELETE FROM CustInfoPopup WHERE Seq = @Seq ";

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
        
        public DataRow CustData
        {
            get { return _custData; }
            set { _custData = value; }
        }

        private void viewGetCustInfo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataRow dr = viewGetCustInfo.GetFocusedDataRow();
                CustData = dr;

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                ExceptionBox.Show(ex);
            }
        }

        public string GetData
        {
            get { return _SetData; }
            set { _SetData = value; }
        }

        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: Srch_KeyDown :: 검색 KeyDown

        private void Srch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    SelectionData();
                    break;
            }
        }

        #endregion

        #region :: SearchBtn_Click :: 검색 Button Click

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SelectionData();
        }

        #endregion

        private void pButtonEdit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
