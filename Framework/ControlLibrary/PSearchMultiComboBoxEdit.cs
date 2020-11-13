using DevExpress.XtraGrid.Columns;
using System;
using System.ComponentModel;
using System.Data;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;
using TLF.Framework.Utility;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2019-10-04 최초생성 : 김성제
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PSearchMultiComboBoxEdit : DevExpress.XtraEditors.SearchLookUpEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// SearchMultiComboEdit Control을 생성합니다.
        /// </summary>
        public PSearchMultiComboBoxEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SearchMultiComboEdit Control을 생성합니다.
        /// </summary>
        /// <param name="container"></param>
        public PSearchMultiComboBoxEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;
        private string _selectAllItemCaption = "전체선택";
        private bool _selectAllItemVisible = false;
        private bool _codeColumnVisible = false;

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

        #region :: SelectAllItemCaption :: '전체선택' Text를 설정합니다.

        /// <summary>
        /// '전체선택' Text를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("'전체선택' Text를 설정합니다."), Browsable(true)]
        public string SelectAllItemCaption
        {
            get { return _selectAllItemCaption; }
            set { _selectAllItemCaption = value; }
        }

        #endregion
        
        #region :: SelectAllItemVisible :: '전체선택' 숨김/보임을 설정합니다.

        /// <summary>
        /// '전체선택' 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("'전체선택' 숨김/보임을 설정합니다."), Browsable(true)]
        public bool SelectAllItemVisible
        {
            get { return _selectAllItemVisible; }
            set { _selectAllItemVisible = value; }
        }

        #endregion

        #region :: CodeColumnVisible :: Code Column 숨김/보임을 설정합니다.

        /// <summary>
        /// Code Column 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Code Column 숨김/보임을 설정합니다."), Browsable(true)]
        public bool CodeColumnVisible
        {
            get { return _codeColumnVisible; }
            set { _codeColumnVisible = value; }
        }

        #endregion

        #region :: ShowFooter :: Column Footer 숨김/표시 여부를 설정합니다.

        /// <summary>
        /// Column Footer 숨김/표시 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Column Footer 숨김/표시 여부를 설정합니다."), Browsable(true)]
        public bool ShowFooter
        {
            get { return Properties.ShowFooter; }
            set { Properties.ShowFooter = value; }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitData(+2 Overloading) :: MultiComboBoxEdit에 값을 넣습니다.

        /// <summary>
        /// MultiComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(object[] valueList, string[] displayList)
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
                InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// MultiComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 2019-11-29 변경 : 민우식
        /// 
        /// </remarks>
        public void InitData(DataTable dt)
        {
            //InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            InitData(dt, dt.Columns[0].ToString(), dt.Columns[1].ToString());
        }

        /// <summary>
        /// MultiComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            Properties.View.Columns.Clear();
            EditValue = "";

            DataRow dr;

            if (_selectAllItemVisible)
            {
                dr = dt.NewRow();

                if (dt.Columns[valueMember].DataType == Type.GetType("System.String"))
                    dr[valueMember] = "";
                else
                    dr[valueMember] = -1;

                dr[displayMember] = _selectAllItemCaption;
                dt.Rows.InsertAt(dr, 0);
            }

            Properties.DataSource = dt;
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;

            string[] columns = AppUtil.GetColumnsFromDataTable(dt);

            /*Array.ForEach(columns, column =>
            {
                Properties.View.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, _codeColumnVisible) : CreateColumn(column, column, 120, true));
            });
            */
            // Properties.ShowHeader = Properties.View.Columns.Count < 3 ? false : true;

            if (dt.Rows.Count == 0)
            {
                EditValue = "";
            }
            else
            {
                EditValue = dt.Rows[0][valueMember];
            }
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
        /// <param name="visible">Column 숨김/보임</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private GridColumn CreateColumn(string fieldName, string caption, int width, bool visible)
        {
            GridColumn column = new GridColumn { FieldName = fieldName, Caption = caption, Width = width, Visible = visible };

            return column;
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
                if (IsModified)
                {
                    (FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion

    }
}
