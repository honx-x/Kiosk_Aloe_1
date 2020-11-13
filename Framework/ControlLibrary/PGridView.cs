using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.Grid;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;
using TLF.Framework.MessageHelper;
using TLF.Framework.Utility;
using DevExpress.Accessibility;
using DevExpress.Data.Details;
using DevExpress.Data.Filtering;
using DevExpress.Data.Summary;
using DevExpress.Utils.Controls;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Editors;
using DevExpress.Utils.Gesture;
using DevExpress.Utils.Serializing;
using DevExpress.Utils.Serializing.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Drawing;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Tab;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.Customization;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Printing;
using DevExpress.XtraTab.ViewInfo;
using System.Collections;
using System.Drawing.Design;
using DevExpress.XtraPrinting;

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
    public partial class PGridView : DevExpress.XtraGrid.Views.Grid.GridView
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// GridView를 생성합니다.
        /// </summary>
        public PGridView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GridView를 생성합니다.
        /// </summary>
        /// <param name="grid"></param>
        public PGridView(DevExpress.XtraGrid.GridControl grid)
            : base(grid)
        {
            InitializeComponent();
        }

        #endregion        

        #region :: 전역변수 ::

        private bool _checkDataSource = false;
        private bool _enableSaveLayout = false;
        private bool _isCheck = false;

        private string[] _keyColumns = null;
        private string[] _mandatoryColumns = null;
        private string[] _newRowEnableColumns = null;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AllowEdit :: Grid Cell 수정여부를 설정합니다.

        /// <summary>
        /// Grid Cell 수정여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Grid Cell 수정여부를 설정합니다."), Browsable(true)]
        public bool AllowEdit
        {
            get { return OptionsBehavior.Editable; }
            set { OptionsBehavior.Editable = value;}
        }

        #endregion

        #region :: CheckDataSource :: DataSource의 Row Count를 표시 여부를 설정합니다.

        /// <summary>
        /// DataSource의 Row Count를 표시 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("DataSource의 Row Count를 표시 여부를 설정합니다."), Browsable(true)]
        public bool CheckDataSource
        {
            get { return _checkDataSource; }
            set { _checkDataSource = value; }
        }

        #endregion

        #region :: ColumnAutoWidth :: 컬럼 너비의 자동맞춤을 설정합니다.

        /// <summary>
        /// 컬럼 너비의 자동맞춤을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("컬럼 너비의 자동맞춤을 설정합니다."), Browsable(true)]
        public bool ColumnAutoWidth
        {
            get { return OptionsView.ColumnAutoWidth; }
            set { OptionsView.ColumnAutoWidth = value; }
        }

        #endregion

        #region :: ColumnHeaderAlignment :: Column Header의 정렬을 지정합니다.

        /// <summary>
        /// Column Header의 정렬을 지정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Column Header의 정렬을 지정합니다."), Browsable(true)]
        public HorzAlignment ColumnHeaderAlignment
        {
            get { return Appearance.HeaderPanel.TextOptions.HAlignment; }
            set { Appearance.HeaderPanel.TextOptions.HAlignment = value; }
        }

        #endregion

        #region :: ColumnHeight :: 컬럼의 높이를 설정합니다.

        /// <summary>
        /// 컬럼의 높이를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("컬럼의 높이를 설정합니다."), Browsable(true)]
        public int ColumnHeight
        {
            get { return ColumnPanelRowHeight; }
            set { ColumnPanelRowHeight = value; }
        }

        #endregion        

        #region :: IsCheck :: Check Column 사용여부를 설정합니다.

        /// <summary>
        /// Check Column 사용여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Check Column 사용여부를 설정합니다."), Browsable(true)]
        public bool IsCheck
        {
            get { return _isCheck; }
            set { _isCheck = value; }
        }

        #endregion

        #region :: KeyColumns :: Primary Key 컬럼을 정의합니다.

        /// <summary>
        /// Primary Key 컬럼을 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Primary Key 컬럼을 정의합니다."), Browsable(true)]
        public string[] KeyColumns
        {
            get { return _keyColumns; }
            set { _keyColumns = value; }
        } 

        #endregion

        #region :: MandatoryColumns :: 필수입력항목 컬럼을 정의합니다.
        
        /// <summary>
        /// 필수입력항목 컬럼을 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("필수입력항목 컬럼을 정의합니다."), Browsable(true)]
        public string[] MandatoryColumns
        {
            get { return _mandatoryColumns; }
            set { _mandatoryColumns = value; }
        } 

        #endregion

        #region :: NewItemPosition :: 신규 Row의 위치를 설정합니다.

        /// <summary>
        /// 신규 Row의 위치를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("신규 Row의 위치를 설정합니다."), Browsable(true)]
        public NewItemRowPosition NewItemPosition
        {
            get { return OptionsView.NewItemRowPosition; }
            set { OptionsView.NewItemRowPosition = value; }
        } 

        #endregion

        #region :: NewRowEnableColumns :: 신규 Row의 Enable 컬럼을 설정합니다.

        /// <summary>
        /// 신규 Row의 Enable 컬럼을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("신규 Row의 Enable 컬럼을 설정합니다."), Browsable(true)]
        public string[] NewRowEnableColumns
        {
            get { return _newRowEnableColumns; }
            set { _newRowEnableColumns = value; }
        }

        #endregion

        #region :: EnableSaveLayout :: Layout 저장 여부를 설정합니다.

        /// <summary>
        /// Layout 저장 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Layout을 저장 여부를 설정합니다."), Browsable(true)]
        public bool EnableSaveLayout
        {
            get { return _enableSaveLayout; }
            set { _enableSaveLayout = value; }
        }

        #endregion

        #region :: ShowGroupPanel :: Group Panel의 숨김/보임을 설정합니다.

        /// <summary>
        /// Group Panel의 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Group Panel의 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowGroupPanel
        {
            get { return OptionsView.ShowGroupPanel; }
            set { OptionsView.ShowGroupPanel = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AcceptChanges :: Table의 변경된 내용을 확정합니다.

        /// <summary>
        /// Table의 변경된 내용을 확정합니다.
        /// </summary>
        public void AcceptChanges()
        {
            GetDataTableByDataSource().AcceptChanges();
        } 

        #endregion

        #region :: AddNewRow :: 새로운 Row를 추가합니다.
        
        /// <summary>
        /// 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void AddNewRow(string colName)
        {
            AddNewRow();
            FocusedColumn = Columns[colName] ?? null;
            FocusedRowHandle = GridControl.NewItemRowHandle;
            ShowEditor();
        } 

        #endregion

        #region :: AddDataRow :: DataSource에 새로운 Row를 추가합니다.
        
        /// <summary>
        /// DataSource에 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="dr">추가할 DataRow</param>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void AddDataRow(DataRow dr)
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return;

            ds.Tables[GridControl.DataMember].Rows.Add(dr);
        } 

        #endregion

        #region :: ClearStyleFormat :: 현재 View의 Style을 모두 제거합니다.

        /// <summary>
        /// 현재 View의 Style을 모두 제거합니다.
        /// </summary>
        /// <remarks>
        /// 2009-09-23 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void ClearStyleFormat()
        {
            FormatConditions.Clear();
        }

        #endregion

        #region :: CopyDataRow :: 대상 ROW를 신규 ROW로 복사합니다.

        /// <summary>
        /// 대상 ROW를 신규 ROW로 복사합니다.
        /// </summary>
        /// <param name="sourceRowHandle">대상 로우 Handle</param>
        public void CopyDataRow(int sourceRowHandle)
        {
            DataRow dr = GetDataTableByDataSource().NewRow();

            if (GetDataRow(sourceRowHandle) == null) return;

            for (int idx = 0; idx < GetDataRow(sourceRowHandle).ItemArray.Length; idx++)
            {
                dr[idx] = GetDataRow(sourceRowHandle).ItemArray[idx];
            }
            AddDataRow(dr);
            dr.AcceptChanges();
        }

        #endregion

        #region :: FillGrid(+2 Overloading) :: GridContorl의 데이터를 채웁니다.

        /// <summary>
        /// GridContorl의 데이터를 채웁니다.
        /// </summary>
        /// <remarks>
        /// 2009-09-23 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillGrid()
        {
            (GridControl as PGridControl).FillGrid();
        }

        /// <summary>
        /// GridContorl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">데이터를 채울 DataSet</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillGrid(DataSet ds)
        {
            (GridControl as PGridControl).FillGrid(ds);
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">GridControl의 DataSource</param>
        /// <param name="tableName">DataTable 이름</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillGrid(DataSet ds, string tableName)
        {
            (GridControl as PGridControl).FillGrid(ds, tableName);
        }

        #endregion

        #region :: ExportToExcel :: GridView Data를 Excel로 Export합니다.

        /// <summary>
        /// GridView Data를 Excel로 Export합니다.
        /// </summary>
        /// <param name="fileName"></param>
        public void ExportToExcel(string fileName)
        {
            if (fileName == string.Empty)
                return;
            ExportToXls(fileName, new XlsExportOptions(TextExportMode.Value));
            //ExportTo(new ExportXlsProvider(fileName));      190507 Version Change
            AppUtil.OpenFile(fileName);
        }

        /// <summary>
        /// GridView Data를 Excel로 Export합니다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="OpenAsk"></param>
        public void ExportToExcel(string fileName, bool OpenAsk)
        {
            if (fileName == string.Empty)
                return;
            ExportToXls(fileName, new XlsExportOptions(TextExportMode.Value));
            //ExportTo(new ExportXlsProvider(fileName));      190507 Version Change
            if (OpenAsk)AppUtil.OpenFile(fileName);
        }

        #endregion

        #region :: GetAddedModifedData :: Grid에서 추가 및 수정된 데이터를 가져옵니다.

        /// <summary>
        /// Grid에서 추가 및 수정된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetAddedModifedData()
        {
            CloseEditor(true);
            
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Detached)
                    dt.ImportRow(dr);
            }

            return dt;
        }

        #endregion

        #region :: GetAllUpdateData :: Grid에서 추가 및 수정, 삭제, Check 된 데이터를 가져옵니다.

        /// <summary>
        /// Grid에서 추가 및 수정, 삭제, Check 된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetAllUpdateData()
        {
            CloseEditor(true);
            
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr["isCheck"].Equals(true))
                    dr.Delete();
            }

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Deleted || dr.RowState == DataRowState.Detached)
                    dt.ImportRow(dr);
            }
            return dt;
        }

        #endregion

        #region :: GetColumnFields :: Column Filed를 가져옵니다.

        /// <summary>
        /// Column Filed를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public string[] GetColumnFields()
        {
            List<string> columnFields = new List<string>();

            foreach (GridColumn gc in Columns)
            {
                columnFields.Add(gc.FieldName);
            }

            return columnFields.ToArray();
        }

        #endregion

        #region :: GetCheckedData :: 삭제할 데이터를 가져옵니다.

        /// <summary>
        /// 삭제할 데이터를 가져옵니다.(CheckedColumn)
        /// </summary>
        /// <param name="columnName">CheckedColumn 컬럼명</param>
        /// <param name="isChecked">선택 여부</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetCheckedData(string columnName, bool isChecked)
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr[columnName].Equals(isChecked))
                    dt.ImportRow(dr);
            }

            return dt;
        } 

        #endregion

        #region :: GetDeletedData :: Grid에서 삭제된 데이터를 가져옵니다.
        
        /// <summary>
        /// Grid에서 삭제된 데이터를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDeletedData()
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr.RowState == DataRowState.Deleted)
                    dt.ImportRow(dr);
            }

            return dt;
        } 

        #endregion

        #region :: GetDataByRowState :: 정의된 상태의 데이터를 가져옵니다.
        
        /// <summary>
        /// 정의된 상태의 데이터를 가져옵니다.
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataByRowState(DataRowState state)
        {
            CloseEditor(true);
            
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr.RowState == state)
                    dt.ImportRow(dr);
            }

            return dt;
        } 

        #endregion

        #region :: GetDataTableByDataSource :: DataSource를 DataTable로 반환합니다..
        
        /// <summary>
        /// DataSource를 DataTable로 반환합니다..
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByDataSource()
        {
            CloseEditor(true);
            
            DataTable dt = DataSource is DataView ? (DataSource as DataView).Table : base.GridControl.DataSource as DataTable;

            UpdateCurrentRow();

            return dt ?? null;
        } 

        #endregion

        #region :: GetDataTableByColumnValue :: 컬럼의 데이터를 Check 하여 같은 값이 있는 Row를 Return합니다.

        /// <summary>
        /// 컬럼의 데이터를 Check 하여 같은 값이 있는 Row를 Return합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <param name="value">비교 값</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetDataTableByColumnValue(string colName, object value)
        {
            CloseEditor(true);

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            DataTable dt = ds.Tables[GridControl.DataMember].Clone();

            foreach (DataRow dr in ds.Tables[GridControl.DataMember].Rows)
            {
                if (dr[colName].ToString() != value.ToString()) continue;

                dt.ImportRow(dr);
            }

            return dt;
        }

        #endregion
        
        #region :: InitGridColumn(+6 Overloading) :: Grid Column을 초기화합니다.

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption)
        {
			fieldName = fieldName.Trim();
			caption = caption.Trim();
			InitGridColumn(fieldName, caption, 75, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption, int width)
        {
			fieldName = fieldName.Trim();
			caption = caption.Trim();
			InitGridColumn(fieldName, caption, width, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible)
        {
			fieldName = fieldName.Trim();
			caption = caption.Trim();
			InitGridColumn(fieldName, caption, width, maxLength, allowEdit, visible, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType)
        {
			fieldName = fieldName.Trim();
			caption = caption.Trim();
			InitGridColumn(fieldName, caption, width, maxLength, allowEdit, visible, dataType, HorzAlignment.Near);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
			fieldName = fieldName.Trim();
			caption = caption.Trim();
			InitGridColumn(fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string fieldName, string caption, int width, int maxLength, int decimalPlace, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
            GridColumn gridColumn;

            fieldName = fieldName.Trim();
            caption = caption.Trim();

            bool existColumn = base.Columns[fieldName] == null ? false : true;

            gridColumn = existColumn ? base.Columns[fieldName] : new GridColumn();

            gridColumn.FieldName = fieldName.Trim();
            gridColumn.Caption = caption.Trim();
            gridColumn.OptionsColumn.AllowEdit = allowEdit;
            gridColumn.Width = width;

            if (!existColumn)
                Columns.Add(gridColumn);

            if (!existColumn) gridColumn.VisibleIndex = base.Columns.Count - 1;

            gridColumn.Visible = visible;

            SetColumnDataType(gridColumn, dataType, maxLength, decimalPlace);

            if (gridColumn.ColumnEdit != null)
            {
                if (gridColumn.ColumnEdit.EditorTypeName == "CheckEdit")
                {
                    gridColumn.OptionsColumn.AllowSort = DefaultBoolean.False;
                    gridColumn.OptionsColumn.FixedWidth = true;
                }
            }

            gridColumn.AppearanceCell.TextOptions.HAlignment = horzAlign;

            if (fieldName == AppConfig.CHECKCOLUMNNAME)
                _isCheck = true;
        }

        #endregion

        #region :: GetSelectedDataTable() :: 선택된 DataTable 가져오기

        /// <summary>
        /// 선택된 DataTable 가져오기
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2019-11-15 최초생성 : 민우식
        /// 변경내역
        /// 
        /// </remarks>
        public DataTable GetSelectedDataTable()
        {
            DataTable dt = null;

            try
            {
                dt = GetDataTableByDataSource().Clone();

                foreach (int i in GetSelectedRows())
                {
                    if (i >= 0) dt.ImportRow(GetDataRow(i));
                }
            }
            catch
            {
                dt = null;
            }

            return dt;
        }

        #endregion


        #region :: InitComboBoxColumn(+4 Overloading) :: ComboBoxColumn에 값을 넣습니다.

        /// <summary>
        /// ComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, object[] valueList, string[] displayList)
        {
			fieldName = fieldName.Trim();
			InitComboBoxColumn(fieldName, valueList, displayList, false, false);
        }

        /// <summary>
        /// ComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, object[] valueList, string[] displayList, bool showAllItemVisible, bool showCodeColumnVisible)
        {
			fieldName = fieldName.Trim();
			if (valueList.Length != displayList.Length)
                return;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx].Trim();
                    dt.Rows.Add(dr);
                }
                InitComboBoxColumn(fieldName, dt, showAllItemVisible, showCodeColumnVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// ComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt)
        {
			fieldName = fieldName.Trim();
			InitComboBoxColumn(fieldName, dt, false, false, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        } 

        /// <summary>
        /// ComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool showAllItemVisible, bool showCodeColumnVisible)
        {
			fieldName = fieldName.Trim();
            InitComboBoxColumn(fieldName, dt, showAllItemVisible, showCodeColumnVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        } 

        /// <summary>
        /// ComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool showAllItemVisible, bool showCodeColumnVisible, string valueMember, string displayMember)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            DataRow dr;
            if (showAllItemVisible)
            {
                dr = dt.NewRow();
                dr[valueMember] = "";
                dr[displayMember] = "전체";
                dt.Rows.InsertAt(dr, 0);
            }
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";
            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            string[] columns = AppUtil.GetColumnsFromDataTable(dt);
            Array.ForEach(columns, column =>
            {
                edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            });
            edit.ShowHeader = edit.Columns.Count < 3 ? false : true;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridColumn.ColumnEdit = edit;            
        }

        #endregion


        #region :: InitSpinEditColumn(+1 Overloading) :: SpinEditColumn에 값을 넣습니다.

        /// <summary>
        /// SpinEditColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="increment"></param>
        /// <param name="maxValue"></param>
        /// <param name="minValue"></param>
        public void InitSpinEditColumn(string fieldName, int[] increment, int[] maxValue, int[] minValue)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];

            if (gridColumn == null) return;

            if (!(gridColumn.ColumnEdit is RepositoryItemSpinEdit)) return;

            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).Increment = new decimal(increment);
            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).MaxValue = new decimal(maxValue);
            (gridColumn.ColumnEdit as RepositoryItemSpinEdit).MinValue = new decimal(minValue);
        }

        #endregion



        #region :: InitCheckedComboBoxColumn(+1 Overloading) :: CheckedComboBoxColumn에 값을 넣습니다.

        /// <summary>
        /// CheckedComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, object[] valueList, string[] displayList, bool showAllItemVisible)
        {
			fieldName = fieldName.Trim();
			if (valueList.Length != displayList.Length)
                return;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx];
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx];
                    dt.Rows.Add(dr);
                }

                InitCheckedComboBoxColumn(fieldName.Trim(), dt, showAllItemVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// CheckedComboBoxColumn에 값을 넣습니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitCheckedComboBoxColumn(string fieldName, DataTable dt, bool showAllItemVisible, string valueMember, string displayMember)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName];

            if (gridColumn == null) return;

            RepositoryItemCheckedComboBoxEdit edit = new RepositoryItemCheckedComboBoxEdit { SelectAllItemCaption = "전체선택", SelectAllItemVisible = showAllItemVisible };

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";

            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            gridColumn.ColumnEdit = edit;
        } 

        #endregion

        #region :: NewDataRow :: DataSource에서 새로운 Row를 생성합니다.
        
        /// <summary>
        /// DataSource에서 새로운 Row를 생성합니다.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public DataRow NewDataRow()
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return null;

            return ds.Tables[GridControl.DataMember].NewRow();
        } 

        #endregion

        #region :: PasteData :: ClipBoard의 데이터를 GridView에 복사하여 넣습니다.

        /// <summary>
        /// ClipBoard의 데이터를 GridView에 복사하여 넣습니다.
        /// </summary>
        /// <remarks>
        /// 2009-09-15 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void PasteData()
        {
            IDataObject iData = Clipboard.GetDataObject();

            // Text형식으로 변환이 불가능하면 Return 후 작업 종료
            if (!iData.GetDataPresent(DataFormats.Text)) return;

            int columnIndex = FocusedColumn.AbsoluteIndex;
            int rowIndex = FocusedRowHandle;

            string text = iData.GetData(DataFormats.Text) as string;

            string[] lines = text.Split('\n');

            if (RowCount - FocusedRowHandle < lines.Length - 1)
            {
                MsgBox.Show("입력할 데이터가 ROW 수보다 많습니다. 확인하세요", "현재 ROW 확인");
                return;
            }

            foreach (string line in lines)
            {
                if (line == string.Empty) continue;

                string[] datas = line.Split('\t');

                foreach (string data in datas)
                {
                    SetFocusedRowCellValue(FocusedColumn.FieldName, data.Trim());
                    FocusedColumn = Columns[FocusedColumn.AbsoluteIndex + 1];
                    //if (columnIndex < VisibleColumns.Count - 1)
                    //    FocusedColumn = Columns[FocusedColumn.VisibleIndex + 1];
                    //else
                    //    break;
                }

                if (rowIndex < RowCount - 1)
                {
                    MoveNext();
                    FocusedColumn = Columns[columnIndex];
                }
                else
                    break;
            }
            if (rowIndex >= 0)
                FocusedRowHandle = rowIndex;
            if (columnIndex >= 0)
                FocusedColumn = Columns[columnIndex];
        }

        #endregion

        #region :: RemoveCheckedRow :: Check 된 DataRow를 삭제합니다.

        /// <summary>
        /// Check 된 DataRow를 삭제합니다.
        /// </summary>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void RemoveCheckedRow()
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return;

            for (int i = 0; i < ds.Tables[GridControl.DataMember].Rows.Count; i++)
            {
                if (!ds.Tables[GridControl.DataMember].Rows[i][AppConfig.CHECKCOLUMNNAME].Equals(true))
                    continue;

                ds.Tables[GridControl.DataMember].Rows.Remove(ds.Tables[GridControl.DataMember].Rows[i]);
                i--;
            }
        } 

        #endregion

        #region :: SetCellMerge :: Cell을 Merge 합니다.
        
        /// <summary>
        /// Cell을 Merge 합니다.
        /// </summary>
        /// <param name="columns">Merge를 실행할 Columns</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetCellMerge(params string[] columns)
        {
            OptionsView.AllowCellMerge = true;

            foreach (GridColumn gc in Columns)
                gc.OptionsColumn.AllowMerge = DefaultBoolean.False;

            Array.ForEach(columns, column => Columns[column].OptionsColumn.AllowMerge = DefaultBoolean.True);
        } 

        #endregion

        #region :: SetFixedColumn :: Fixed Column을 설정합니다.
        
        /// <summary>
        /// Fixed Column을 설정합니다.
        /// </summary>
        /// <param name="columnName">Fix 할 컬럼명</param>
        /// <param name="style">Fix Style</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetFixedColumn(string columnName, FixedStyle style)
        {
            if (Columns[columnName] == null) return;

            GridColumn col = Columns[columnName.Trim()];
            col.Fixed = style;
        } 

        #endregion

        #region :: SetColumnCaption :: Grid Column Caption을 설정합니다.

        /// <summary>
        /// Grid Column Caption을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">변경할 Caption</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnCaption(string fieldName, string caption)
        {
			caption = caption.Trim();
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];

            gridColumn.Caption = caption;
        } 

        #endregion

        #region :: SetColumnHAlign :: Grid Column의 정렬을 설정합니다.
        
        /// <summary>
        /// Grid Column의 정렬을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="align">정렬 설정</param>
        /// <remarks>
        /// 2008-12-31 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnHAlign(string fieldName, HorzAlignment align)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];
            gridColumn.AppearanceCell.TextOptions.HAlignment = align;
        } 

        #endregion

		#region :: SetColumnSummary :: Grid Column의 Summary를 설정합니다.

		/// <summary>
		/// Grid Column의 Summary를 설정합니다.
		/// </summary>
		/// <param name="fieldName">Column Field 명</param>
		/// <param name="type">Summary Type</param>
		/// <remarks>
		/// 2008-12-31 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public void SetColumnSummary(string fieldName, SummaryItemType type)
		{
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];
			gridColumn.SummaryItem.SummaryType = type;

			switch (type)
			{
				case SummaryItemType.Sum:
					gridColumn.SummaryItem.DisplayFormat = "합계 : {0}";
					break;
			}

			OptionsView.ShowFooter = true;
		}

		#endregion

		#region :: SetColumnSummary :: Grid Column의 Summary를 설정합니다.

		/// <summary>
		/// Grid Column의 Summary를 설정합니다.
		/// </summary>
		/// <param name="fieldName">Column Field 명</param>
		/// <param name="type">Summary Type</param>
		/// <remarks>
		/// 2008-12-31 최초생성 : 황준혁
		/// 변경내역
		/// 
		/// </remarks>
		public void SetColumnSummary(string fieldName, SummaryItemType type, string FormatString)
		{
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];
			gridColumn.SummaryItem.SummaryType = type;

			switch (type)
			{
				case SummaryItemType.Sum:
					gridColumn.SummaryItem.DisplayFormat = FormatString ;
					break;
			}

			OptionsView.ShowFooter = true;
		}

		#endregion

		#region :: SetColumnVisible :: Grid Column 숨김/보임 여부를 설정합니다.

        /// <summary>
        /// Grid Column 숨김/보임 여부를 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="visible">숨김/보임 여부</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnVisible(string fieldName, bool visible)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];

            gridColumn.Visible = visible;
        } 

        #endregion

        #region :: SetColumnAllowEdit :: Grid Column 수정 가능 여부를 설정합니다.
        
        /// <summary>
        /// Grid Column 수정 가능 여부를 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="allowEdit">수정 가능 여부</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetColumnAllowEdit(string fieldName, bool allowEdit)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColumn = Columns[fieldName.Trim()];

            gridColumn.OptionsColumn.AllowEdit = allowEdit;
        } 

        #endregion

        #region :: SetStyleFormat(+4 Overloading) :: Grid Column의 Style을 설정합니다.

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <remarks>
        /// 2009-01-06 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1)
        {
			fieldName = fieldName.Trim();
			SetStyleFormat(fieldName, backColor, Color.Black, ControlConfig.DEFAULTFONT, formatCondition, value1, null);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2009-01-06 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, FormatConditionEnum formatCondition, object value1, bool applyToRow)
        {
			fieldName = fieldName.Trim();
			SetStyleFormat(fieldName, backColor, Color.Black, ControlConfig.DEFAULTFONT, formatCondition, value1, null, applyToRow);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2009-01-06 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, object value1, object value2)
        {
			fieldName = fieldName.Trim();
			SetStyleFormat(fieldName, backColor, Color.Black, ControlConfig.DEFAULTFONT, FormatConditionEnum.Between, value1, value2);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <remarks>
        /// 2009-01-06 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2)
        {
			fieldName = fieldName.Trim();
			SetStyleFormat(fieldName.Trim(), backColor, foreColor, font, formatCondition, value1, value2, false);
        }

        /// <summary>
        /// Grid Column의 Style을 설정합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="backColor">설정할 Back Color</param>
        /// <param name="foreColor">설정할 Fore Color</param>
        /// <param name="font">설정할 Font</param>
        /// <param name="formatCondition">Format Condition</param>
        /// <param name="value1">비교값1</param>
        /// <param name="value2">비교값2</param>
        /// <param name="applyToRow">Row에 색을 표시할지를 설정합니다.</param>
        /// <remarks>
        /// 2009-01-06 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetStyleFormat(string fieldName, Color backColor, Color foreColor, Font font, FormatConditionEnum formatCondition, object value1, object value2, bool applyToRow)
        {
			fieldName = fieldName.Trim();
			GridColumn gridColum = Columns[fieldName.Trim()];

            StyleFormatCondition sfc = new StyleFormatCondition();
            sfc.Appearance.Font = font;
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.UseFont = true;

            sfc.Column = gridColum;
            sfc.ApplyToRow = applyToRow;
            sfc.Condition = formatCondition;
            sfc.Value1 = value1;
            sfc.Value2 = value2;

            FormatConditions.Add(sfc);
        }

        #endregion

        #region :: Validate :: 필수입력 컬럼의 데이터 신뢰성을 검증합니다.

        /// <summary>
        /// 필수입력 컬럼의 데이터 신뢰성을 검증합니다.
        /// </summary>
        /// <param name="value">체크할 값</param>
        /// <param name="check">체크할 값과 같은지 여부</param>
        /// <returns></returns>
        public bool Validate(object value, bool check)
        {
            bool bResult = true;
            for (int i = 0; i < RowCount; i++)
            {
                Array.ForEach(_mandatoryColumns, column =>
                {
                    if ((GetRowCellValue(i, column) == value) == check)
                        bResult = false;
                });
            }

            return bResult;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        #region :: CreateColumn :: LookUpColumn을 만듭니다.

        /// <summary>
        /// LookUpColumn을 만듭니다.
        /// </summary>
        /// <param name="fieldName">Field 명</param>
        /// <param name="caption">Column Caption 명</param>
        /// <param name="width">Column 너비</param>
        /// <param name="align">Column 정렬</param>
        /// <param name="visible">Column 숨김/보임</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private LookUpColumnInfo CreateColumn(string fieldName, string caption, int width, HorzAlignment align, bool visible)
        {
			caption = caption.Trim();
			fieldName = fieldName.Trim();
			LookUpColumnInfo column = new LookUpColumnInfo { FieldName = fieldName.Trim(), Caption = caption.Trim(), Width = width, Alignment = align, Visible = visible };

            return column;
        }

        #endregion

        #region :: DoShowMenu :: PGridViewColumnButtonMenu 를 보여줍니다.

        /// <summary>
        /// PGridViewColumnButtonMenu 를 보여줍니다.
        /// </summary>
        /// <param name="hi"></param>
        private void DoShowMenu(DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi)
        {
            if (hi.HitTest != DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.ColumnButton)
                return;

            DevExpress.XtraGrid.Menu.GridViewMenu menu = new PGridViewContextMenu(this);
            menu.Init(hi);
            menu.Show(hi.HitPoint);
        }

        #endregion

        #region :: ExportTo :: GridView Data를 Export 합니다.
        
        /// <summary>
        /// GridView Data를 Export 합니다.
        /// </summary>
        /// <param name="provider"></param>
        private void ExportTo(IExportProvider provider)
        {
            BaseExportLink link = CreateExportLink(provider);
            (link as GridViewExportLink).ExpandAll = false;
            link.ExportTo(true);
            provider.Dispose();
        } 

        #endregion

        #region :: SetColumnDataType :: Column의 DataType을 정의합니다.

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="gridColumn">Grid Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private void SetColumnDataType(GridColumn gridColumn, ColumnDataType dataType, int maxLength, int decimalPlace)
        {
            if (dataType == ColumnDataType.Default)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.MaxLength = maxLength;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Text)
            {
                RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.MaxLength = maxLength;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.CheckEdit)
            {
                RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.NullStyle = StyleIndeterminate.Unchecked;
                edit.ValueChecked = true;
                edit.ValueUnchecked = false;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Date)
            {
                RepositoryItemDateEdit edit = new RepositoryItemDateEdit { HighlightHolidays = true };

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.NullDate = "";
                edit.Mask.EditMask = "d";
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.Mask.UseMaskAsDisplayFormat = true;
                gridColumn.ColumnEdit = edit;
            }
			else if (dataType == ColumnDataType.DateTime)
			{
				RepositoryItemDateEdit edit = new RepositoryItemDateEdit { HighlightHolidays = true };

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				edit.NullDate = "";
				edit.NullText = "";
				edit.Mask.MaskType = MaskType.DateTime;
				edit.Mask.EditMask = AppConfig.DEFAULTDATEFORMAT;
				edit.Mask.AutoComplete = AutoCompleteType.Optimistic;
				edit.Mask.UseMaskAsDisplayFormat = true;
				gridColumn.ColumnEdit = edit;
			}
			else if (dataType == ColumnDataType.Time)
			{
				RepositoryItemTimeEdit edit = new RepositoryItemTimeEdit();

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				edit.Mask.MaskType = MaskType.DateTime;
				edit.Mask.EditMask = "HH:mm:ss";
				edit.Mask.UseMaskAsDisplayFormat = true;
				edit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
				gridColumn.ColumnEdit = edit;
			}
			else if (dataType == ColumnDataType.Minute)
			{
				RepositoryItemDateEdit edit = new RepositoryItemDateEdit { HighlightHolidays = true };

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				edit.NullDate = "";
				edit.NullText = "";
				edit.Mask.MaskType = MaskType.Custom;
				edit.Mask.EditMask = "HH:mm";
				edit.Mask.AutoComplete = AutoCompleteType.Optimistic;
				edit.Mask.UseMaskAsDisplayFormat = true;
				gridColumn.ColumnEdit = edit;
			}
			else if (dataType == ColumnDataType.Numeric)
            {
//				RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();
				RepositoryItemTextEdit edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = MaskType.Numeric;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.MaxLength = maxLength;
                edit.Mask.UseMaskAsDisplayFormat = !gridColumn.OptionsColumn.AllowEdit;
				
                gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Decimal)
            {
                RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.MaxLength = maxLength;
                edit.Mask.UseMaskAsDisplayFormat = !gridColumn.OptionsColumn.AllowEdit;
                gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                gridColumn.ColumnEdit = edit;                
            }
			else if (dataType == ColumnDataType.Currency)
			{
				RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				edit.Mask.EditMask = "c" + decimalPlace;
				edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
				edit.MaxLength = maxLength;
				edit.Mask.UseMaskAsDisplayFormat = !gridColumn.OptionsColumn.AllowEdit;
				gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
				gridColumn.ColumnEdit = edit;
			}
			else if (dataType == ColumnDataType.MemoEdit)
			{
				RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				edit.MaxLength = maxLength;
				gridColumn.ColumnEdit = edit;
			}
			else if (dataType == ColumnDataType.Percentage) { }
            else if (dataType == ColumnDataType.Popup) { }
            else if (dataType == ColumnDataType.Button)
			{
				RepositoryItemButtonEdit edit = new RepositoryItemButtonEdit();

				edit.Appearance.Font = ControlConfig.DEFAULTFONT;
				gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
				gridColumn.AppearanceCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
				gridColumn.AppearanceCell.BackColor = Color.LightGray;
				gridColumn.AppearanceCell.ForeColor = Color.Black;
				gridColumn.ColumnEdit = edit;
			}
            else if (dataType == ColumnDataType.LinkButton)
            {
                RepositoryItemHyperLinkEdit edit = new RepositoryItemHyperLinkEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.ColorSelect)
            {
                RepositoryItemColorEdit edit = new RepositoryItemColorEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Image)
            {
                RepositoryItemImageEdit edit = new RepositoryItemImageEdit();

                edit.SizeMode = PictureSizeMode.Stretch;
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Picture)
            {
                RepositoryItemPictureEdit edit = new RepositoryItemPictureEdit();

                edit.SizeMode = PictureSizeMode.Stretch;
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Password)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.PasswordChar = '*';
                edit.MaxLength = maxLength;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Progress)
            {
                RepositoryItemProgressBar edit = new RepositoryItemProgressBar();
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                edit.ShowTitle = true;
                edit.PercentView = true;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.ImageCombo) { }
            else if (dataType == ColumnDataType.File) { }
        }

        #endregion

        #region :: SetKeyColumns :: DataTable의 Primary Key를 설정합니다.

        /// <summary>
        /// DataTable의 Primary Key를 설정합니다.
        /// </summary>
        private void SetKeyColumns()
        {
            if (_keyColumns == null) return;

            DataTable dt = GetDataTableByDataSource();

            if (dt == null) return;

            List<DataColumn> dc = new List<DataColumn>();

            Array.ForEach(_keyColumns, keyColumn => dc.Add(dt.Columns[keyColumn]));

            dt.PrimaryKey = dc.ToArray();
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        #region :: CopyToClipboard :: 현재 CELL 값을 복사하여 ClipBoard에 넣습니다.

        /// <summary>
        /// 현재 CELL 값을 복사하여 ClipBoard에 넣습니다.
        /// </summary>
        public override void CopyToClipboard()
        {
            if (OptionsSelection.MultiSelect)
                base.CopyToClipboard();
            else
                Clipboard.SetText(FocusedValue.ToString());
        }

        #endregion

        #region :: OnDataController_DataSourceChanged :: Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.

        /// <summary>
        /// Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnDataController_DataSourceChanged(object sender, EventArgs e)
        {
            base.OnDataController_DataSourceChanged(sender, e);

            SetKeyColumns();

            if (DataSource != null && _checkDataSource)
            {
                DataSet ds = null;
                if (DataSource is DataViewManager)
                    ds = (DataSource as DataViewManager).DataSet;
                else if (DataSource is DataView)
                    ds = (DataSource as DataView).DataViewManager.DataSet;

                (GridControl.FindForm() as UIFrame).MessageCaption = ds.Tables[GridControl.DataMember].Rows.Count < 1 ? MsgMap.NO_SELECT_DATA : MsgMap.OK_SELECT;
            }

            base.RaiseFocusedRowChanged(FocusedRowHandle, FocusedRowHandle);

            if((GridControl.FindForm() as UIFrame) == null) return;

            string keyName = String.Format("{0}{1}", (GridControl.FindForm() as UIFrame).MenuID, Name);

            StringBuilder sb = new StringBuilder(128);
            Win32Util.GetPrivateProfileString("GridLayout", keyName, "", sb, 128, AppConfig.SETTINGFILEPATH);
                        
            if (sb.ToString() == string.Empty || !File.Exists(sb.ToString())) return;

            RestoreLayoutFromXml(sb.ToString());
        }

        #endregion

        #region :: PGridView_CustomDrawCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.

        /// <summary>
        /// Cell이 추가/수정/삭제 되면 Color를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                if (e.RowHandle < 0)
                    return;

                if (base.GetRow(e.RowHandle) == null)
                    return;

                DataRowView drv = base.GetRow(e.RowHandle) as DataRowView;               

                switch (drv.Row.RowState)
                {
                    case DataRowState.Added:
                        e.Appearance.ForeColor = ControlConfig.ADDEDROWCOLOR;
                        break;
                    case DataRowState.Modified:
                        e.Appearance.ForeColor = ControlConfig.MODIFIEDROWCOLOR;
                        break;
                    //case DataRowState.Unchanged:
                    //    e.Appearance.ForeColor = Color.Black;
                    //    break;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region :: PGridView_MouseDown :: 마우스 오른쪽 버튼을 누르면 ContextMenu를 보여줍니다.

        /// <summary>
        /// 마우스 오른쪽 버튼을 누르면 ContextMenu를 보여줍니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PGridView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && _enableSaveLayout)
                DoShowMenu(CalcHitInfo(new Point(e.X, e.Y)));
        }

        #endregion

        #region :: RaiseCellValueChanging :: Cell Value가 변경할 때마다 발생합니다.

        /// <summary>
        /// Cell Value가 변경할 때마다 발생합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCellValueChanging(DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (base.FocusedRowHandle > -1)
                {
                    if (e.Column.ColumnType == typeof(bool) && e.Column.FieldName == AppConfig.CHECKCOLUMNNAME)
                    {
                        base.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                        GetFocusedDataRow().AcceptChanges();
                        //object value = base.GetRowCellValue(e.RowHandle, e.Column);

                        //bool isCheckedColumn = value.ToString() == string.Empty ? true : Convert.ToBoolean(value);

                        //if (!isCheckedColumn)
                        //{
                        //    DataRowView dr = base.GetRow(e.RowHandle) as DataRowView;

                        //    dr.Row.CancelEdit();

                        //    if (dr.Row.RowState == DataRowState.Unchanged)
                        //    {
                        //        base.SetRowCellValue(e.RowHandle, e.Column, e.Value);

                        //        dr.Row.AcceptChanges();
                        //    }
                        //    else
                        //        base.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                        //        dr.Row.AcceptChanges();
                        //}
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                base.RaiseCellValueChanging(e);
            }
        }

        #endregion

        #region :: RaiseCustomDrawRowIndicator :: Indicator 에 Row Number를 표시합니다.

        /// <summary>
        /// Indicator 에 Row Number를 표시합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseCustomDrawRowIndicator(RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (!OptionsView.ShowIndicator) return;

                if (e.RowHandle == GridControl.InvalidRowHandle && _enableSaveLayout)
                {
                    e.Handled = true;
                    e.Painter.DrawObject(e.Info);

                    Rectangle r = e.Bounds;
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), r);
                    r.Height--; r.Width--;
                    e.Graphics.DrawRectangle(Pens.Red, r);
                }

                if (!e.Info.IsRowIndicator) return;
                if (e.RowHandle < 0) return;

                base.IndicatorWidth = 35;
                e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Row;
                e.Info.Appearance.TextOptions.VAlignment = VertAlignment.Center;
                e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
            catch
            {
                throw;
            }

            //base.RaiseCustomDrawRowIndicator(e);
        }

        #endregion

        #region :: RaiseFocusedRowChanged :: Focused Row가 변경되면 NewRowEnableColumns의 AllowEdit 를 True로 변경합니다.

        /// <summary>
        /// Focused Row가 변경되면 NewRowEnableColumns의 AllowEdit 를 True로 변경합니다.
        /// </summary>
        /// <param name="prevFocused"></param>
        /// <param name="focusedRowHandle"></param>
        protected override void RaiseFocusedRowChanged(int prevFocused, int focusedRowHandle)
        {
            if (focusedRowHandle == GridControl.NewItemRowHandle)
            {
                if (_newRowEnableColumns != null)
                {
                    Array.ForEach(_newRowEnableColumns, column => Columns[column].OptionsColumn.AllowEdit = true);
                }
            }
            if (GetFocusedDataRow() != null)
            {
                if (_newRowEnableColumns != null && _newRowEnableColumns.Length > 0)
                {
                    if (GetFocusedDataRow().RowState == DataRowState.Added || GetFocusedDataRow().RowState == DataRowState.Detached)
                    {
                        Array.ForEach(_newRowEnableColumns, column => Columns[column].OptionsColumn.AllowEdit = true);
                    }
                    else
                    {
                        Array.ForEach(_newRowEnableColumns, column => Columns[column].OptionsColumn.AllowEdit = false);
                    }
                }
            }

            base.RaiseFocusedRowChanged(prevFocused, focusedRowHandle);
        }

        #endregion

        #region :: RaiseInvalidRowException :: 예외가 발생하면 Message를 표시하지 않습니다.

        /// <summary>
        /// 예외가 발생하면 Message를 표시하지 않습니다.
        /// </summary>
        /// <param name="ex"></param>
        protected override void RaiseInvalidRowException(DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs ex)
        {
            ex.ExceptionMode = ExceptionMode.NoAction;
            base.RaiseInvalidRowException(ex);

            if (ex.ErrorText != string.Empty)
            {
                if (_keyColumns != null)
                {
                    Array.ForEach(_keyColumns, key =>
                    {
                        if (ex.ErrorText.Contains(key))
                            SetColumnError(Columns[key], ex.ErrorText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    });
                }
            }
        } 

        #endregion

        #region :: RaiseValidateRow :: 신규 Row의 필수 입력값을 강제로 정의합니다.
        
        /// <summary>
        /// 신규 Row의 필수 입력값을 강제로 정의합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void RaiseValidateRow(DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (_mandatoryColumns == null) return;

            List<GridColumn> cList = new List<GridColumn>();

            if (e.Row != null)
            {
                Array.ForEach(_mandatoryColumns, column =>
                {
                    if ((e.Row as DataRowView).Row[column].ToString() == string.Empty)
                        cList.Add(Columns[column]);
                });
            }

            if (cList.Count > 0)
            {
                string message = "필수입력 항목입니다. 값을 입력 하세요.\r\n작업을 취소하려면 [ESC]를 눌러주세요";
                cList.ForEach(gc => SetColumnError(gc, message, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning));
                e.Valid = false;
            }

            base.RaiseValidateRow(e);
        } 

        #endregion

		//
		// 요약:
		//     Returns information about View elements located at a specified point.
		//
		// 매개 변수:
		//   pt:
		//     A System.Drawing.Point structure specifying test point coordinates relative
		//     to the grid control's top-left corner.
		//
		// 반환 값:
		//     A DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo object that contains
		//     information about View elements located at the test point.
		public DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo CalcHitInfo(Point pt)
		{
			return base.CalcHitInfo(pt);
		}
		//
		// 요약:
		//     Returns information about the View elements located at the specified point.
		//
		// 매개 변수:
		//   x:
		//     An integer representing the X coordinate of the test point relative to the
		//     top-left corner of the grid control.
		//
		//   y:
		//     An integer representing the Y coordinate of the test point relative to the
		//     top-left corner of the grid control.
		//
		// 반환 값:
		//     A DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo object that contains
		//     information about View elements located at the test point.
		public DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo CalcHitInfo(int x, int y)
		{
			return base.CalcHitInfo(x, y);
		}

		//
		// 요약:
		//     Returns a specific cell's display value from the current View.
		//
		// 매개 변수:
		//   rowHandle:
		//     An integer value specifying the handle of the row where the desired cell
		//     resides.
		//
		//   column:
		//     A DevExpress.XtraGrid.Columns.GridColumn object or descendant representing
		//     a column containing the desired cell.
		//
		// 반환 값:
		//     A System.String value representing a cell's display text.
		public virtual string GetRowCellDisplayText(int rowHandle, GridColumn column)
		{
			return base.GetRowCellDisplayText(rowHandle, column);
		}
		//
		// 요약:
		//     Gets the display value of the specified cell.
		//
		// 매개 변수:
		//   rowHandle:
		//     An integer value specifying the handle of the row in which the desired cell
		//     resides.
		//
		//   fieldName:
		//     A string representing the field name of the column that contains the required
		//     cell. A System.ArgumentNullException exception will be thrown if the current
		//     View does not contain a column with the specified field name.
		//
		// 반환 값:
		//     A string representing the required cell's display text.
		public string GetRowCellDisplayText(int rowHandle, string fieldName)
		{
			return base.GetRowCellDisplayText(rowHandle, fieldName);
		}

		protected virtual string GetRowCellDisplayText(int rowHandle, GridColumn column, object value)
		{
			return base.GetRowCellDisplayText(rowHandle, column, value);
		}
	
	}
}