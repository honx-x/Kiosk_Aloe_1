using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Export;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraPrinting;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;
using TLF.Framework.MessageHelper;
using TLF.Framework.Utility;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public partial class AdvPBandedGridView : DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    {
        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// 
        /// </summary>
        public AdvPBandedGridView()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerGrid"></param>
        public AdvPBandedGridView(DevExpress.XtraGrid.GridControl ownerGrid)
            : base(ownerGrid)
        {

        }

        #endregion

        #region :: 전역변수 ::

        private bool _checkDataSource = false;

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
            set
            {
                OptionsBehavior.Editable = value;
            }
        }

        #endregion

        #region :: BandHeaderAlignment :: Column Header의 정렬을 지정합니다.

        /// <summary>
        /// Band Header의 정렬을 지정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Band Header의 정렬을 지정합니다."), Browsable(true)]
        public HorzAlignment BandHeaderAlignment
        {
            get { return Appearance.BandPanel.TextOptions.HAlignment; }
            set { Appearance.BandPanel.TextOptions.HAlignment = value; }
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

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: AddNewRow :: 새로운 Row를 추가합니다.

        /// <summary>
        /// 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="colName">컬럼명</param>
        /// <remarks>
        /// 2009-01-20 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void AddNewRow(string colName)
        {
            AddNewRow();
            FocusedColumn = Columns["colName"] != null ? Columns["colName"] : null;
            FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle;
            ShowEditor();
        }

        #endregion

        #region :: AddDataRow :: DataSource에 새로운 Row를 추가합니다.

        /// <summary>
        /// DataSource에 새로운 Row를 추가합니다.
        /// </summary>
        /// <param name="dr">추가할 DataRow</param>
        /// <remarks>
        /// 2009-01-20 최초생성 : 황준혁
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

        #region :: FillGrid :: GridContorl의 데이터를 채웁니다.

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
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified)
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
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Deleted)
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

            foreach (BandedGridColumn gc in Columns)
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
            
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            UpdateCurrentRow();

            if (ds == null) return null;

            return ds.Tables[GridControl.DataMember];
        }

        #endregion

        #region :: GetRowByColumnValue :: 컬럼의 데이터를 Check 하여 같은 값이 있는 Row를 Return합니다.

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
        public DataRowView GetRowByColumnValue(string colName, object value)
        {
            DataRowView dr = null;

            for (int i = 0; i < RowCount; i++)
            {
                if (GetRowCellValue(i, Columns[colName]).Equals(value))
                    dr = GetRow(i) as DataRowView;
            }

            return dr;
        }

        #endregion

        #region :: InitGridBand :: Grid Band를 초기화합니다.

        /// <summary>
        /// Grid Band를 초기화합니다.
        /// </summary>
        /// <param name="name">Band 명</param>
        /// <param name="caption">Band Header Text</param>
        /// <param name="width">Band 너비</param>
        public void InitGridBand(string name, string caption, int width)
        {
            GridBand gBand = new GridBand { Name = name, Caption = caption, Width = width };

            Bands.Add(gBand);
        }

        #endregion

        #region :: InitGridColumn(+5 Overloading) :: Grid Column을 초기화합니다.

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string bandName, string fieldName, string caption)
        {
            InitGridColumn(bandName, fieldName, caption, 75);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridColumn(string bandName, string fieldName, string caption, int width)
        {
            InitGridColumn(bandName, 0, fieldName, caption, width, 0, false, true);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="rowIndex">Column Row Index</param>
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
        public void InitGridColumn(string bandName, int rowIndex, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible)
        {
            InitGridColumn(bandName, rowIndex, fieldName, caption, width, maxLength, allowEdit, visible, ColumnDataType.Default, HorzAlignment.Default);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="rowIndex">Column Row Index</param>
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
        public void InitGridColumn(string bandName, int rowIndex, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType)
        {
            InitGridColumn(bandName, rowIndex, fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, HorzAlignment.Default);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">Band 명</param>
        /// <param name="rowIndex">Column Row Index</param>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="allowEdit">Column Cell 수정 여부</param>
        /// <param name="visible">Column 숨김/보임 여부</param>
        /// <param name="dataType">Column DataType</param>
        /// <param name="horzAlign">Column Cell 정렬</param>
        public void InitGridColumn(string bandName, int rowIndex, string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
            InitGridColumn(bandName, rowIndex, fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="bandName">BAND 명</param>
        /// <param name="rowIndex">Column Row Index</param>
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
        public void InitGridColumn(string bandName, int rowIndex, string fieldName, string caption, int width, int maxLength, int decimalPlace, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
            GridBand gBand = Bands[bandName];

            BandedGridColumn gridColumn;

            bool existColumn = base.Columns[fieldName] == null ? false : true;

            gridColumn = existColumn ? base.Columns[fieldName] : new BandedGridColumn();

            gridColumn.FieldName = fieldName;
            gridColumn.Caption = caption;
            gridColumn.OptionsColumn.AllowEdit = allowEdit;
            gridColumn.Width = width;

            if (!existColumn) gridColumn.VisibleIndex = base.Columns.Count == 0 ? base.Columns.Count : base.Columns.Count - 1;

            gridColumn.Visible = visible;
            gridColumn.RowIndex = rowIndex;

            if (!existColumn)
                Columns.Add(gridColumn);

            gridColumn.AppearanceCell.TextOptions.HAlignment = horzAlign;
            gridColumn.AutoFillDown = true;

            SetColumnDataType(gridColumn, dataType, maxLength, decimalPlace);

            gBand.Columns.Add(gridColumn);
        }

        #endregion

        #region :: InitComboBoxColumn(+1 Overloading) :: ComboBoxColumn에 값을 넣습니다.

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
                InitComboBoxColumn(fieldName, dt, showAllItemVisible, showCodeColumnVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
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
            BandedGridColumn gridColumn = Columns[fieldName];

            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            DataRow dr;
            if (showAllItemVisible)
            {
                dr = dt.NewRow();
                dr[valueMember] = "";
                dr[displayMember] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";
            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            edit.Columns.Add(CreateColumn(valueMember, "코드", 70, HorzAlignment.Center, showCodeColumnVisible));
            edit.Columns.Add(CreateColumn(displayMember, "코드명", 120, HorzAlignment.Near, true));
            edit.ShowHeader = false;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            gridColumn.ColumnEdit = edit;
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
                InitCheckedComboBoxColumn(fieldName, dt, showAllItemVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
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
            BandedGridColumn gridColumn = Columns[fieldName];

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

        #region :: RemoveDataRow :: DataRow를 삭제합니다.

        /// <summary>
        /// DataRow를 삭제합니다.
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <param name="isChecked">선택 여부</param>
        /// <remarks>
        /// 2009-01-13 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void RemoveDataRow(string columnName, bool isChecked)
        {
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : base.GridControl.DataSource as DataSet;

            if (ds == null) return;

            for (int i = 0; i < ds.Tables[GridControl.DataMember].Rows.Count; i++)
            {
                if (!ds.Tables[GridControl.DataMember].Rows[i][columnName].Equals(isChecked))
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

            foreach (BandedGridColumn gc in Columns)
            {
                Array.ForEach(columns, column =>
                {
                    if (gc.FieldName == column)
                        gc.OptionsColumn.AllowMerge = DefaultBoolean.True;
                });
            }
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

            BandedGridColumn col = Columns[columnName];
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
            BandedGridColumn gridColumn = Columns[fieldName];

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
            BandedGridColumn gridColumn = Columns[fieldName];
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
            BandedGridColumn gridColumn = Columns[fieldName];
            gridColumn.SummaryItem.SummaryType = type;

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
            BandedGridColumn gridColumn = Columns[fieldName];

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
            BandedGridColumn gridColumn = Columns[fieldName];

            gridColumn.OptionsColumn.AllowEdit = allowEdit;
        }

        #endregion

        #region :: SetStyleFormat(+2 Overloading) :: Grid Column의 Style을 설정합니다.

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
            SetStyleFormat(fieldName, backColor, Color.Black, ControlConfig.DEFAULTFONT, formatCondition, value1, null);
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
            BandedGridColumn gridColum = Columns[fieldName];

            StyleFormatCondition sfc = new StyleFormatCondition();
            sfc.Appearance.Font = font;
            sfc.Appearance.BackColor = backColor;
            sfc.Appearance.ForeColor = foreColor;

            sfc.Appearance.Options.UseBackColor = true;
            sfc.Appearance.Options.UseForeColor = true;
            sfc.Appearance.Options.UseFont = true;

            sfc.Column = gridColum;
            sfc.Condition = formatCondition;
            sfc.Value1 = value1;
            sfc.Value2 = value2;

            FormatConditions.Add(sfc);
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
            LookUpColumnInfo column = new LookUpColumnInfo { FieldName = fieldName, Caption = caption, Width = width, Alignment = align, Visible = visible };

            return column;
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
        private void SetColumnDataType(BandedGridColumn gridColumn, ColumnDataType dataType, int maxLength, int decimalPlace)
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
                edit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
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
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.Mask.EditMask = AppConfig.DEFAULTDATEFORMAT;
                edit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
                edit.Mask.UseMaskAsDisplayFormat = true;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Time)
            {
                RepositoryItemTimeEdit edit = new RepositoryItemTimeEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.Mask.EditMask = "t";
                edit.Mask.UseMaskAsDisplayFormat = true;
                edit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
                gridColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Numeric)
            {
                RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
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
            else if (dataType == ColumnDataType.Button) { }
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
            else if (dataType == ColumnDataType.ImageCombo) { }
            else if (dataType == ColumnDataType.File) { }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnDataController_DataSourceChanged :: Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.

        /// <summary>
        /// Datasource가 변경되면 RowCount를 Check하여 MainForm에 정보를 표시합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnDataController_DataSourceChanged(object sender, EventArgs e)
        {
            base.OnDataController_DataSourceChanged(sender, e);

            if (DataSource != null)
            {
                if (_checkDataSource)
                {
                    DataSet ds = null;
                    if (DataSource is DataViewManager)
                        ds = (DataSource as DataViewManager).DataSet;
                    else if (DataSource is DataView)
                        ds = (DataSource as DataView).DataViewManager.DataSet;


                    (GridControl.FindForm() as UIFrame).MessageCaption = ds.Tables[GridControl.DataMember].Rows.Count < 1 ? MsgMap.NO_SELECT_DATA : MsgMap.OK_SELECT;
                }
            }
            FocusedRowHandle = -1;
        }

        #endregion

        #region :: PBandedGridView_CustomDrawCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.

        /// <summary>
        /// Cell이 추가/수정/삭제 되면 Color를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdvPBandedGridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
                    case DataRowState.Unchanged:
                        e.Appearance.ForeColor = Color.Black;
                        break;
                }
            }
            catch
            {
                throw;
            }
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
                bool isCheckedColumn = true;

                if (base.FocusedRowHandle > -1)
                {
                    if (e.Column.ColumnType == typeof(bool) && e.Column.FieldName == AppConfig.CHECKCOLUMNNAME)
                    {
                        object value = base.GetRowCellValue(e.RowHandle, e.Column);

                        isCheckedColumn = value.ToString() == string.Empty ? true : Convert.ToBoolean(value);

                        if (!isCheckedColumn)
                        {
                            DataRowView dr = base.GetRow(e.RowHandle) as DataRowView;

                            dr.Row.CancelEdit();

                            if (dr.Row.RowState == DataRowState.Unchanged)
                            {
                                base.SetRowCellValue(e.RowHandle, e.Column, e.Value);

                                dr.Row.AcceptChanges();
                            }
                            else
                                base.SetRowCellValue(e.RowHandle, e.Column, e.Value);
                        }
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
        protected override void RaiseCustomDrawRowIndicator(DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            try
            {
                if (OptionsView.ShowIndicator)
                {
                    if (e.Info.IsRowIndicator)
                    {
                        if (e.RowHandle > -1)
                        {
                            base.IndicatorWidth = 35;
                            e.Info.DisplayText = Convert.ToString(e.RowHandle + 1);
                            e.Info.Kind = DevExpress.Utils.Drawing.IndicatorKind.Row;
                            e.Info.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            e.Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            base.RaiseCustomDrawRowIndicator(e);
        }

        #endregion

        #region :: RaiseInvalidRowException :: 예외가 발생하면 무시합니다.

        /// <summary>
        /// 예외가 발생하면 무시합니다.
        /// </summary>
        /// <param name="ex"></param>
        protected override void RaiseInvalidRowException(DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs ex)
        {
            ex.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
            base.RaiseInvalidRowException(ex);
        }

        #endregion
    }
}
