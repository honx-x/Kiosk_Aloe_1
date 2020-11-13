using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TLF.Framework.Config;
using DevExpress.Utils;
using TLF.Framework.MessageHelper;
using TLF.Framework.Localization;

namespace TLF.Framework.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmPopup : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// Popup Form을 생성합니다.
        /// </summary>
        public frmPopup(Localizer localizer)
        {
            InitializeComponent();
            _localizer = localizer;
        }

        #endregion

        #region :: 전역변수 ::

        private string _codeValue = string.Empty;
        private DataSet _codeDataSet = null;
        private string _description = string.Empty;
        private Localizer _localizer;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CodeValue :: 선택한 Code 값입니다.

        /// <summary>
        /// 선택한 Code 값입니다.
        /// </summary>
        public string CodeValue
        {
            get { return _codeValue; }
            set { _codeValue = value; }
        }

        #endregion

        #region :: CodeDataSet :: Code List에 사용할 DataSource 입니다.

        /// <summary>
        /// Code List에 사용할 DataSource 입니다.
        /// </summary>
        public DataSet CodeDataSet
        {
            get { return _codeDataSet; }
            set
            {
                _codeDataSet = value;

                if (value != null)
                {
                    Height = 500;
                    pnlCodeList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                }
                else
                {
                    Height = 200;
                    pnlCodeList.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                }
            }
        }

        #endregion

        #region :: Description :: 상세정보 값입니다.

        /// <summary>
        /// 상세정보 값입니다.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

        #region :: localizer :: 다국어 지원에 사용할 Localizer

        /// <summary>
        /// 다국어 지원에 사용할 Localizer
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("다국어 지원에 사용할 Localizer"), Browsable(false)]
        public Localizer localizer
        {
            get { return _localizer; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: frmPopup_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPopup_Load(object sender, EventArgs e)
        {
            try
            {                
                InitLocalization();

                if (_codeDataSet != null)
                {
                    gridPopup.DataSource =_codeDataSet;
                    gridPopup.DataMember = _codeDataSet.Tables[0].TableName;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Control Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: btnOK_Click :: 확인버튼을 클릭하면 발생합니다.

        /// <summary>
        /// 확인버튼을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!CheckCondition())
                return;

            if (_codeDataSet != null)
                _codeValue = viewPopup.GetFocusedDataRow()["CodeValue"].ToString();

            _description = txtDescription.EditValue.ToString();

            DialogResult = DialogResult.OK;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        private void InitLocalization()
        {
            pnlCodeList.Text = String.Format("{0}{1}", localizer.GetLocalizedString(StrId.Code), localizer.GetLocalizedString(StrId.List));
            pnlDescription.Text = String.Format("{0}{1}", Text, localizer.GetLocalizedString(StrId.Cause));
            btnOK.Text = localizer.GetLocalizedString(StrId.Confirm);
            btnCancel.Text = localizer.GetLocalizedString(StrId.Cancel);
        }

        // Common Event 처리 Method 조건 Check

        #region :: CheckCondition :: 확인 버튼을 눌렀을 때 조건을 Check합니다.

        /// <summary>
        /// 확인 버튼을 눌렀을 때 조건을 Check합니다.
        /// </summary>
        /// <returns></returns>
        private bool CheckCondition()
        {
            if (_codeDataSet != null)
            {
                if (viewPopup.GetFocusedDataRow() == null)
                {
                    MsgBox.Show(String.Format("{0}{1}", localizer.GetLocalizedMessage(MsgId.IF_Select), localizer.GetLocalizedString(StrId.Code)));
                    viewPopup.Focus();
                    return false;
                }
            }

            if (txtDescription.EditValue.ToString().Trim() == string.Empty)
            {
                MsgBox.Show(String.Format(localizer.GetLocalizedMessage(MsgId.IF_EssentialItem), pnlDescription.Text), localizer.GetLocalizedString(StrId.Confirm));
                txtDescription.Select();
                return false;
            }

            return true;
        }

        #endregion
    }
}