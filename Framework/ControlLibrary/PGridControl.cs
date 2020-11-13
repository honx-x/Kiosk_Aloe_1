using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using TLF.Framework.Config;
using TLF.Framework.BaseFrame;
using TLF.Framework.Utility;
using System.ComponentModel;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;

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
    public partial class PGridControl : DevExpress.XtraGrid.GridControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Grid Control을 생성합니다.
        /// </summary>
        public PGridControl()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkAll = false;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: EnableClear :: 일괄 초기화 여부를 설정합니다.

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("일괄 초기화 여부를 설정합니다."), Browsable(true)]
        public bool EnableClear
        {
            get { return _enableClear; }
            set
            {
                _enableClear = value;

                Tag = _enableClear ? AppConfig.CLEARTAG : null;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FillGrid(+1 Overloading) :: GridControl의 데이터를 채웁니다.

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        public void FillGrid()
        {
            using (DataSet ds = new DataSet())
            {
                DataTable dt = AppUtil.MakeDataTableScheme(ds, (DefaultView as PGridView).GetColumnFields());
                ds.Tables.Add(dt);
                FillGrid(ds, ds.Tables[0].TableName);
            }
        }

        /// <summary>
        /// GridControl의 데이터를 채웁니다.
        /// </summary>
        /// <param name="ds">GridControl의 DataSource</param>
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
            DataMember = ds.Tables[tableName].TableName;

            _checkAll = false;

            foreach (GridColumn col in (DefaultView as GridView).Columns)
            {
                if (col.ColumnEdit is RepositoryItemCheckEdit)
                {
                    if (ds.Tables[tableName].Columns.Contains(col.FieldName))
                        ds.Tables[tableName].Columns[col.FieldName].DataType = Type.GetType("System.Boolean");
                    else
                        ds.Tables[tableName].Columns.Add(col.FieldName, Type.GetType("System.Boolean"));
                }
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateDefaultView :: Default GridView를 생성합니다.

        /// <summary>
        /// Default GridView를 생성합니다.
        /// </summary>
        /// <returns></returns>
        protected override DevExpress.XtraGrid.Views.Base.BaseView CreateDefaultView()
        {
            return CreateView("PGridView");
        }

        #endregion

        #region :: RegisterAvailableViewsCore :: GridView 정보를 등록합니다.

        /// <summary>
        /// GridContorl 정보를 등록합니다.
        /// </summary>
        /// <param name="collection"></param>
        protected override void RegisterAvailableViewsCore(DevExpress.XtraGrid.Registrator.InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new PGridInfoRegistrator());
            collection.Add(new PBandedGridInfoRegistrator());
            collection.Add(new AdvPBandedGridInfoRegistrator());
        }

        #endregion

        #region :: OnClick :: 그리드의 Check Column 클릭했을 때 발생시킵니다.

        /// <summary>
        /// 그리드의 Check Column 클릭했을 때 발생시킵니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hi =
                (MainView as GridView).CalcHitInfo((this as Control).PointToClient(Control.MousePosition));

            if (hi.Column == null || DefaultView.RowCount == 0) return;

            if (hi.Column.FieldName == AppConfig.CHECKCOLUMNNAME && hi.RowHandle < 0)
            {
                hi.Column.SortOrder = DevExpress.Data.ColumnSortOrder.None;

                for (int rowCount = 0; rowCount < DefaultView.RowCount; rowCount++)
                {
                    (DefaultView as GridView).SetRowCellValue(rowCount, AppConfig.CHECKCOLUMNNAME, !_checkAll);
                    (DefaultView as GridView).GetDataRow(rowCount).AcceptChanges();
                }

                _checkAll = !_checkAll;
            }

            base.OnClick(e);
        }

        #endregion
    }
}
