using System;
using System.ComponentModel;
using System.Data;
using DevExpress.XtraEditors.Controls;
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
    public partial class PImageComboBoxEdit : DevExpress.XtraEditors.ImageComboBoxEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Image ComboBox Control을 생성합니다.
        /// </summary>
        public PImageComboBoxEdit()
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

        #region :: InitData(+1 Overloading) :: ImageComboBoxEdit에 값을 넣습니다.

        /// <summary>
        /// ImageComboBoxEdit에 값을 넣습니다.
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
                this.InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// ImageComboBoxEdit에 값을 넣습니다.
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
            this.BeginUpdate();
            for(int idx = 0;idx<dt.Rows.Count;idx++)
            {
                ImageComboBoxItem icbi = new ImageComboBoxItem();
                icbi.Value = dt.Rows[idx][valueMember];
                icbi.Description = dt.Rows[idx][displayMember].ToString();

                if (this.Properties.SmallImages != null)
                    icbi.ImageIndex = idx;

                this.Properties.Items.Add(icbi);
            }
            this.EndUpdate();
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
