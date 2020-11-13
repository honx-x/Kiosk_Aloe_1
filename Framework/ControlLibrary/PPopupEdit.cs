using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using TLF.Business.WSBiz;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public partial class PPopupEdit : DevExpress.XtraEditors.ButtonEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextButtonEdit Control을 생성합니다.
        /// </summary>
        public PPopupEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;

        private int _displayValueWidth = 100;

        private string _connection = AppConfig.DEFAULTDB;

        private string _formTitle = "Code Helper";
        private int _formWidth = 600;
        private int _formHeight = 450;

        private string[] _columnHeader;
        private ColumnDataType[] _columnType;
        private int[] _columnWidth;

        private string[] _selectList;
        private string _fromTable = string.Empty;
        private string _where = string.Empty;

        private string _valueColumnName = string.Empty;
        private string _displayColumnName = string.Empty;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: DisplayValueWidth :: DisplayValue의 너비를 설정합니다.

        /// <summary>
        /// DisplayValue의 너비를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("DisplayValue의 너비를 설정합니다."), Browsable(true)]
        public int DisplayValueWidth
        {
            get { return this._displayValueWidth; }
            set { 
                this._displayValueWidth = value;
                this.displayButton.Width = value;
            }
        }

        #endregion

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

        #region :: CheckModify :: EditValue의 변경 Check 여부를 설정합니다.

        /// <summary>
        /// EditValue의 변경 Check 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("EditValue의 변경 Check 여부를 설정합니다."), Browsable(true)]
        public bool CheckModify
        {
            get { return _checkModify; }
            set { _checkModify = value; }
        }

        #endregion

        #region :: Connection :: DB 연결을 설정합니다.

        /// <summary>
        /// DB 연결을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("DB 연결을 설정합니다."), Browsable(true)]
        public string Connection
        {
            get { return _connection; }
            set
            {
                _connection = value;
            }
        }

        #endregion

        #region :: FormTitle :: PopUp Form의 Title을 설정합니다.

        /// <summary>
        /// PopUp Form의 Title을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 Title을 설정합니다."), Browsable(true)]
        public string FormTitle
        {
            get { return _formTitle; }
            set { _formTitle = value; }
        }

        #endregion

        #region :: FormWidth :: PopUp Form의 너비를 설정합니다.
        
        /// <summary>
        /// PopUp Form의 너비를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 너비를 설정합니다."), Browsable(true)]
        public int FormWidth
        {
            get { return _formWidth; }
            set { _formWidth = value; }
        }

        #endregion

        #region :: FormHeight :: PopUp Form의 높이를 설정합니다.

        /// <summary>
        /// PopUp Form의 높이를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 높이를 설정합니다."), Browsable(true)]
        public int FormHeight
        {
            get { return _formHeight; }
            set { _formHeight = value; }
        }

        #endregion


        #region :: ColumnHeader :: PopUp Form의 Column Header를 정의합니다.

        /// <summary>
        /// PopUp Form의 Column Header를 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 Column Header를 정의합니다."), Browsable(true)]
        public string[] ColumnHeader
        {
            get { return _columnHeader; }
            set { _columnHeader = value; }
        }

        #endregion

        #region :: ColumnWidth :: PopUp Form의 Column 너비를 정의합니다.

        /// <summary>
        /// PopUp Form의 Column 너비를 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 Column 너비를 정의합니다."), Browsable(true)]
        public int[] ColumnWidth
        {
            get { return _columnWidth; }
            set { _columnWidth = value; }
        }

        #endregion

        #region :: ColumnType :: PopUp Form의 Column DataType을 정의합니다.

        /// <summary>
        /// PopUp Form의 Column DataType을 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PopUp Form의 Column DataType을 정의합니다."), Browsable(true)]
        public ColumnDataType[] ColumnType
        {
            get { return _columnType; }
            set { _columnType = value; }
        }

        #endregion

        #region :: SelectList :: 조회할 컬럼을 정의합니다.

        /// <summary>
        /// 조회할 컬럼을 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("조회할 컬럼을 정의합니다."), Browsable(true)]
        public string[] SelectList
        {
            get { return _selectList; }
            set { _selectList = value; }
        }

        #endregion

        #region :: FromTable :: 실행할 테이블을 정의합니다.

        /// <summary>
        /// 실행할 테이블을 정의합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("실행할 테이블을 정의합니다."), Browsable(true)]
        public string FromTable
        {
            get { return _fromTable; }
            set { _fromTable = value; }
        }

        #endregion

        #region :: Where :: Where 조건을 설정합니다.

        /// <summary>
        /// Where 조건을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Where 조건을 설정합니다."), Browsable(true)]
        public string Where
        {
            get { return _where; }
            set { _where = value; }
        }

        #endregion


        #region :: ValueColumnName :: 값으로 사용할 Column 명입니다.

        /// <summary>
        /// 값으로 사용할 Column 명입니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Value String Column Name"), Browsable(true)]
        public string ValueColumnName
        {
            get { return _valueColumnName; }
            set { _valueColumnName = value; }
        }

        #endregion

        #region :: DisplayColumnName :: 설명으로 사용할 Column 명입니다.

        /// <summary>
        /// 설명으로 사용할 Column 명입니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Display String Column Name"), Browsable(true)]
        public string DisplayColumnName
        {
            get { return _displayColumnName; }
            set { _displayColumnName = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////


        private void PPopupEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index != 0)
                return;

            try
            {
                using (PopupHelp ph = new PopupHelp())
                {
                    GridColumnInit(ph.gridView);
                    ph.gridView.FillGrid(this.GridDataSource());
                    
                    if (ph.ShowDialog() != DialogResult.OK || ph.gridView.GetFocusedDataRow() == null)
                        return;

                    this.EditValue = ph.gridView.GetFocusedDataRow()[_valueColumnName];
                    this.Properties.Buttons[1].Caption = ph.gridView.GetFocusedDataRow()[_displayColumnName].ToString();
                }
            }
            catch
            {
                throw;
            }
        }

        private void GridColumnInit(PGridView view)
        {
            for (int i = 0; i < _columnHeader.Length; i++)
            {
                view.InitGridColumn(_selectList[i], _columnHeader[i], _columnWidth[i], 300, false, true, _columnType[i]);
            }
        }

        private string MakeQueryString()
        {
            StringBuilder query = new StringBuilder(256);
            query.AppendLine(" SELECT ");

            for (int i = 0; i < _selectList.GetLength(0); i++)
            {
                query.Append(SelectList[i]);

                query.Append(SelectList.Length - 1 != i ? ", " : " FROM ");
            }
            query.AppendLine(FromTable);
            query.AppendLine(Where == string.Empty ? "" : String.Format(" WHERE {0}", Where));

            return query.ToString();
        }

        #region :: GridDataSource :: Grid DataSource를 가져옵니다.

        /// <summary>
        /// Grid DataSource를 가져옵니다.
        /// </summary>
        /// <returns></returns>
        private DataSet GridDataSource()
        {
            DataSet ds = null;

            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                ds = wb.NTx_ExecuteDataSet(_connection, MakeQueryString(), AppConfig.COMMANDTEXT, null, null);
            }

            return ds;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnLostFocus :: Focus를 잃을 때 현재값과 이전값을 비교한다.

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);

            if (_checkModify)
            {
                if (this.IsModified)
                {
                    (this.FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion
    }
}
