
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraPivotGrid;
using TLF.Framework.Config;
using TLF.Framework.Utility;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2009-06-01 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PPivotGridControl : DevExpress.XtraPivotGrid.PivotGridControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자(+1 Overloading) ::

        /// <summary>
        /// PivotGridControl 을 생성합니다.
        /// </summary>
        public PPivotGridControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewInfoData"></param>
        protected PPivotGridControl(DevExpress.XtraPivotGrid.Data.PivotGridViewInfoData viewInfoData)
            : base(viewInfoData)
        {
            InitializeComponent();
        }
         

        #endregion        

        #region :: 전역변수 ::

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ExportToExcel :: GridView Data를 Excel로 Export합니다.

        /// <summary>
        /// GridView Data를 Excel로 Export합니다.
        /// </summary>
        /// <param name="fileName"></param>
        public void ExportToExcel(string fileName)
        {
            if (fileName == string.Empty)
                return;
            ExportToExcel(fileName);

            AppUtil.OpenFile(fileName);
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
            FillGrid(ds, ds.Tables[0].TableName);
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
            DataSource = ds;
            DataMember = tableName;
        }

        #endregion

        #region :: InitGridField(+3 Overloading) :: Grid Field를 초기화합니다.

        /// <summary>
        /// Grid Field을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Field Field 명</param>
        /// <param name="caption">Field Header Text</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridField(string fieldName, string caption)
        {
            InitGridField(fieldName, caption, PivotArea.FilterArea);
        }

        /// <summary>
        /// Grid Column을 초기화합니다.
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="area">Field 위치</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridField(string fieldName, string caption, PivotArea area)
        {
            InitGridField(fieldName, caption, area, ColumnDataType.Numeric);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="area">Field 위치</param>
        /// <param name="dataType">Data Type</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridField(string fieldName, string caption, PivotArea area, ColumnDataType dataType)
        {
            InitGridField(fieldName, caption, 0, area, dataType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldName">Column Field 명</param>
        /// <param name="caption">Column Header Text</param>
        /// <param name="decimalPlace">소숫점 자리수</param>
        /// <param name="area">Field 위치</param>
        /// <param name="dataType">Data Type</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitGridField(string fieldName, string caption, int decimalPlace, PivotArea area, ColumnDataType dataType)
        {
            PivotGridField gridField;

            bool existField = base.Fields[fieldName] == null ? false : true;

            gridField = existField ? base.Fields[fieldName] : new PivotGridField();

            gridField.FieldName = fieldName;
            gridField.Caption = caption;
            gridField.Options.AllowEdit = false;

            if (!existField)
                Fields.Add(gridField);

            if (!existField) gridField.AreaIndex = base.Fields.Count - 1;

            SetColumnDataType(gridField, dataType, decimalPlace);

            gridField.Area = area;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetColumnDataType :: Column의 DataType을 정의합니다.

        /// <summary>
        /// Column의 DataType을 정의합니다.
        /// </summary>
        /// <param name="gridField">Column Field 명</param>
        /// <param name="dataType">Column Data Type</param>
        /// <param name="decimalPlace">소숫점 길이 수, 기본값 0</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private void SetColumnDataType(PivotGridField gridField, ColumnDataType dataType, int decimalPlace)
        {
            if (dataType == ColumnDataType.Numeric)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.Mask.UseMaskAsDisplayFormat = true;
                gridField.FieldEdit = edit;
            }
            else if (dataType == ColumnDataType.Decimal)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.EditMask = "n" + decimalPlace;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.UseMaskAsDisplayFormat = true;
                gridField.FieldEdit = edit;
            }
            else if (dataType == ColumnDataType.Currency)
            {
                RepositoryItemTextEdit edit = new RepositoryItemTextEdit();

                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Mask.EditMask = "c" + decimalPlace;
                edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                edit.Mask.UseMaskAsDisplayFormat = true;
                gridField.FieldEdit = edit;
            }
            else if (dataType == ColumnDataType.Progress)
            {
                RepositoryItemProgressBar edit = new RepositoryItemProgressBar();
                edit.Appearance.Font = ControlConfig.DEFAULTFONT;
                edit.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
                edit.ShowTitle = true;
                edit.PercentView = true;
                gridField.FieldEdit = edit;
            }
        }

        #endregion
    }
}
