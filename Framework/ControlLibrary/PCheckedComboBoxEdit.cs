using System;
using System.ComponentModel;
using System.Data;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PCheckedComboBoxEdit : DevExpress.XtraEditors.CheckedComboBoxEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Checked ComboBox Edit Control을 생성합니다.
        /// </summary>
        public PCheckedComboBoxEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;

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

        #region :: SelectAllItemVisible :: '전체선택' 숨김/보임을 설정합니다.

        /// <summary>
        /// '전체선택' 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("'전체선택' 숨김/보임을 설정합니다."), Browsable(true)]
        public bool SelectAllItemVisible
        {
            get { return Properties.SelectAllItemVisible; }
            set { Properties.SelectAllItemVisible = value; }
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
            get { return Properties.SelectAllItemCaption; }
            set { Properties.SelectAllItemCaption = value; }
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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitData(+2 Overloading) :: CheckedComboBoxEdit에 값을 넣습니다.

        /// <summary>
        /// CheckedComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
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
        /// CheckedComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(DataTable dt)
        {
            InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// CheckedComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            Properties.DataSource = dt;
            Properties.ValueMember = valueMember;
            Properties.DisplayMember = displayMember;
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
