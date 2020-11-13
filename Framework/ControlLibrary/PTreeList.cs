using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;
using TLF.Framework.Config;
using TLF.Framework.Utility;
using System.Collections.Generic;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-18 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PTreeList : DevExpress.XtraTreeList.TreeList
    {
        #region :: 생성자 ::
        
        /// <summary>
        /// TreeList를 생성합니다.
        /// </summary>
        public PTreeList()
        {
            InitializeComponent();
        }

        /// <summary>
        /// TreeList를 생성합니다.
        /// </summary>
        /// <param name="ignore"></param>
        protected PTreeList(object ignore)
            : base(ignore)
        {
            InitializeComponent();
        }          

        #endregion

        #region :: 전역변수 ::

        private string[] _mandatoryColumns = null;
        
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Editable :: 수정 가능 여부를 설정합니다.
        
        /// <summary>
        /// 수정 가능 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("수정 가능 여부를 설정합니다."), Browsable(true)]
        public bool Editable
        {
            get { return OptionsBehavior.Editable; }
            set { OptionsBehavior.Editable = value; }
        } 

        #endregion

        #region :: ShowColumns :: Column 숨김/보임을 설정합니다.
        
        /// <summary>
        /// Column 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Column 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowColumns
        {
            get { return OptionsView.ShowColumns; }
            set { OptionsView.ShowColumns = value; }
        } 

        #endregion

        #region :: ShowHorzLines :: Horzental Line 숨김/보임을 설정합니다.
        
        /// <summary>
        /// Horzental Line 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Horzental Line 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowHorzLines
        {
            get { return OptionsView.ShowHorzLines; }
            set { OptionsView.ShowHorzLines = value; }
        } 

        #endregion

        #region :: ShowIndicator :: Indicator 숨김/보임을 설정합니다.
        
        /// <summary>
        /// Indicator 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Indicator 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowIndicator
        {
            get { return OptionsView.ShowIndicator; }
            set { OptionsView.ShowIndicator = value; }
        } 

        #endregion

        #region :: ShowVertLines :: Vertical Line 숨김/보임을 설정합니다.
        
        /// <summary>
        /// Vertical Line 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Vertical Line 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowVertLines
        {
            get { return OptionsView.ShowVertLines; }
            set { OptionsView.ShowVertLines = value; }
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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FillTreeList :: Tree List의 데이터를 채웁니다.

        /// <summary>
        /// Tree List의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">TreeList의 DataSource</param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillTreeList(DataSet ds)
        {
            DataSource = ds;
            DataMember = ds.Tables[0].TableName;
        }

        /// <summary>
        /// Tree List의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">TreeList의 DataSource</param>
        /// <param name="tableName"></param>
        /// <remarks>
        /// 2008-12-22 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void FillTreeList(DataSet ds, string tableName)
        {
            DataSource = ds;
            DataMember = ds.Tables[tableName].TableName;
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
            CheckValidateFocusNode();
            
            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : DataSource as DataSet;

            if (ds == null) return null;

            DataTable dt = ds.Tables[DataMember].Clone();

            foreach (DataRow dr in ds.Tables[DataMember].Rows)
            {
                if (dr.RowState == DataRowState.Added || dr.RowState == DataRowState.Modified || dr.RowState == DataRowState.Detached)
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

            DataSet ds = DataSource is DataView ? (DataSource as DataView).DataViewManager.DataSet : DataSource as DataSet;

            if (ds == null) return null;

            DataTable dt = ds.Tables[DataMember].Copy();

            return dt;
        }

        #endregion

        #region :: InitTreeListColumn(+5 Overloading) :: TreeList Column을 초기화합니다.

        /// <summary>
        /// TreeList Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitTreeListColumn(string fieldName, string caption)
        {
            InitTreeListColumn(fieldName, caption, 75, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// TreeList Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="width">Column 너비</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitTreeListColumn(string fieldName, string caption, int width)
        {
            InitTreeListColumn(fieldName, caption, width, 0, false, true, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// TreeList Column을 초기화합니다.
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
        public void InitTreeListColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible)
        {
            InitTreeListColumn(fieldName, caption, width, maxLength, allowEdit, visible, ColumnDataType.Default, HorzAlignment.Near);
        }

        /// <summary>
        /// TreeList Column을 초기화합니다.
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
        public void InitTreeListColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType)
        {
            InitTreeListColumn(fieldName, caption, width, maxLength, allowEdit, visible, dataType, HorzAlignment.Near);
        }

        /// <summary>
        /// TreeList Column을 초기화합니다.
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
        public void InitTreeListColumn(string fieldName, string caption, int width, int maxLength, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
            InitTreeListColumn(fieldName, caption, width, maxLength, 0, allowEdit, visible, dataType, horzAlign);
        }

        /// <summary>
        /// TreeList Column을 초기화합니다.
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
        public void InitTreeListColumn(string fieldName, string caption, int width, int maxLength, int decimalPlace, bool allowEdit, bool visible, ColumnDataType dataType, HorzAlignment horzAlign)
        {
            TreeListColumn column;

            fieldName = fieldName.Trim();
            caption = caption.Trim();

            bool existColumn = base.Columns[fieldName] == null ? false : true;

            column = existColumn ? base.Columns[fieldName] : new TreeListColumn();

            column.FieldName = fieldName;
            column.Caption = caption;
            column.OptionsColumn.AllowEdit = allowEdit;
            column.Width = width;

            if (!existColumn) column.VisibleIndex = base.Columns.Count == 0 ? base.Columns.Count : base.Columns.Count - 1;

            column.Visible = visible;

            if (!existColumn) Columns.AddRange(new TreeListColumn[] { column });

            SetColumnDataType(column, dataType, maxLength, decimalPlace);

            if (column.ColumnEdit != null)
            {
                if (column.ColumnEdit.EditorTypeName == "CheckEdit")
                {
                    column.OptionsColumn.AllowSort = false;
                    column.OptionsColumn.FixedWidth = true;
                }
            }

            column.AppearanceCell.TextOptions.HAlignment = horzAlign;
        }

        #endregion

        #region :: InitComboBoxColumn(+2 Overloading) :: ComboBoxColumn에 값을 넣습니다.

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
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitComboBoxColumn(string fieldName, DataTable dt, bool showAllItemVisible, bool showCodeColumnVisible)
        {
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
            TreeListColumn treeColumn = Columns[fieldName];

            if (treeColumn == null) return;

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
            string[] columns = AppUtil.GetColumnsFromDataTable(dt);
            
            Array.ForEach(columns, column =>
            {
                edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            });
            edit.ShowHeader = edit.Columns.Count < 3 ? false : true;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;
            treeColumn.ColumnEdit = edit;

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

        #region :: SetColumnDataType :: Column의 DataType을 정의합니다.

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="treeColumn">TreeList Column</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="maxLength">Data의 최대 길이, 0이면 설정 안 함</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private void SetColumnDataType(TreeListColumn treeColumn, ColumnDataType dataType, int maxLength, int decimalPlace)
        {
            if (dataType == ColumnDataType.Default)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.MaxLength = maxLength;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Text)
            {
                RepositoryItemMemoEdit edit = new RepositoryItemMemoEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.MaxLength = maxLength;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.CheckEdit)
            {
                RepositoryItemCheckEdit edit = new RepositoryItemCheckEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
                edit.ValueChecked = true;
                edit.ValueUnchecked = false;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Date)
            {
                RepositoryItemDateEdit edit = new RepositoryItemDateEdit { HighlightHolidays = true };

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.NullDate = "";
                edit.Mask.EditMask = "d";
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.Mask.UseMaskAsDisplayFormat = true;
                treeColumn.ColumnEdit = edit;
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
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Time)
            {
                RepositoryItemTimeEdit edit = new RepositoryItemTimeEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
                edit.Mask.EditMask = "t";
                edit.Mask.UseMaskAsDisplayFormat = true;
                edit.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Optimistic;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Numeric)
            {
                RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.MaxLength = maxLength;
                edit.Mask.UseMaskAsDisplayFormat = !treeColumn.OptionsColumn.AllowEdit;
                treeColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Decimal)
            {
                RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.MaxLength = maxLength;
                edit.Mask.UseMaskAsDisplayFormat = !treeColumn.OptionsColumn.AllowEdit;
                treeColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Currency)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.EditMask = "c" + decimalPlace;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.MaxLength = maxLength;
                edit.Mask.UseMaskAsDisplayFormat = !treeColumn.OptionsColumn.AllowEdit;
                treeColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Percentage) { }
            else if (dataType == ColumnDataType.Popup) { }
            else if (dataType == ColumnDataType.Button) { }
            else if (dataType == ColumnDataType.LinkButton)
            {
                RepositoryItemHyperLinkEdit edit = new RepositoryItemHyperLinkEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                treeColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Near;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.ColorSelect)
            {
                RepositoryItemColorEdit edit = new RepositoryItemColorEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                treeColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Image)
            {
                RepositoryItemImageEdit edit = new RepositoryItemImageEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Picture)
            {
                RepositoryItemPictureEdit edit = new RepositoryItemPictureEdit();

                edit.SizeMode = PictureSizeMode.Stretch;
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.Password)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.PasswordChar = '*';
                edit.MaxLength = maxLength;
                treeColumn.ColumnEdit = edit;
            }
            else if (dataType == ColumnDataType.ImageCombo) { }
            else if (dataType == ColumnDataType.File) { }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: PTreeList_CustomDrawNodeCell :: Cell이 추가/수정/삭제 되면 Color를 변경합니다.

        /// <summary>
        /// Cell이 추가/수정/삭제 되면 Color를 변경합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PTreeList_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            try
            {
                //if (e.RowHandle < 0)
                //    return;

                //if (base.GetRow(e.RowHandle) == null)
                //    return;

                DataRowView drv = base.GetDataRecordByNode(e.Node) as DataRowView;

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
    }
}
