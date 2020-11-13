using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TLF.Framework.Config;
using TLF.Business.WSBiz;

namespace TLF.Framework.ExceptionHelper
{
    /// <summary>
    /// System에서 발생하는 예외를 담당하는 Form입니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-23 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    internal partial class frmException : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Exception Form 생성합니다.
        /// </summary>
        public frmException()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::
        
        private const int _stdFormWidth = 540;
        private const int _stdFormHeight = 400;
        private const int _stdDetailWidth = 510;
        private const int _stdDetailHeight = 192;

        private Exception _exception;

        private DateTime _exceptionTime;

        private bool _enlarged = false;
        private bool _detailVisible = false; 

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Exception :: 예외를 설정합니다.

        /// <summary>
        /// 예외를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("예외를 설정합니다."), Browsable(false)]
        public Exception Exception
        {
            set { _exception = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: HideDetail :: Detail 구간을 숨김니다.

        /// <summary>
        /// Detail 구간을 숨김니다.
        /// </summary>
        private void HideDetail()
        {
            _detailVisible = false;
            txtDetail.Visible = false;
            btnReport.Visible = false;
            btnCopy.Visible = false;
            btnCopy.Enabled = false;

            btnResize.Visible = false;
            btnResize.Enabled = false;
            btnExit.Visible = false;
            btnExit.Enabled = false;
            btnDetail.Text = "자세히 >>";

            Height = Height - txtDetail.Height - btnCopy.Height - 16;
        }

        #endregion

        #region :: ShowDetail :: Detail 구간을 보입니다.

        /// <summary>
        /// Detail 구간을 보입니다.
        /// </summary>
        private void ShowDetail()
        {
            _detailVisible = true;
            txtDetail.Visible = true;
            btnReport.Visible = true;
            btnCopy.Visible = true;
            btnCopy.Enabled = true;

            btnResize.Visible = true;
            btnResize.Enabled = true;
            btnExit.Visible = false;
            btnExit.Enabled = false;
            btnDetail.Text = "자세히 <<";

            Height = Height + txtDetail.Height + btnCopy.Height + 16;
        }

        #endregion

        #region :: GetCallStack :: Exception의 Call Stack을 가져옵니다.

        /// <summary>
        /// Exception의 Call Stack을 가져옵니다.
        /// </summary>
        /// <param name="_exception"></param>
        /// <param name="callStack"></param>
        private void GetCallStack(Exception _exception, ref StringBuilder callStack)
        {
            if (_exception == null)
                return;

            callStack.AppendLine(_exception.Message);
            callStack.AppendLine(_exception.StackTrace);
            GetCallStack(_exception.InnerException, ref callStack);
        }

        #endregion

        private void ExceptionLogSave()
        {
            using (WsBiz wb = new WsBiz(AppConfig.DEFAULTDB))
            {
                string query = "dbo.ExceptionLog_Save";

                string[] paramList = new string[] { "@Message",
                                                    "@Trace",
                                                    "@Location",
                                                    "@Source"  };

                object[] valueList = new object[] { _exception.Message,
                                                    _exception.StackTrace,
                                                    _exception.TargetSite.ToString(),
                                                    _exception.Source };

                wb.Tx_ExecuteNonQuery(AppConfig.DEFAULTDB, query, AppConfig.COMMANDSP, paramList, valueList);
            }
        }
            
        ///////////////////////////////////////////
        // Event Handler
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        #region :: Load Event ::

        private void frmException_Load(object sender, EventArgs e)
        {
            if (_exception == null)
                _exception = new Exception("표시할 예외 정보가 없습니다.");

            _exceptionTime = DateTime.Now;

            txtDesc.Text = _exception.Message.Replace("\n", Environment.NewLine);

            StringBuilder callStack = new StringBuilder();

            GetCallStack(_exception, ref callStack);

            txtDetail.Text = callStack.ToString();
            HideDetail();

            ExceptionLogSave();
        }

        #endregion

        #region : Ok Button Click Event :

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region : Detail Button Click Event :

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (_detailVisible)
                HideDetail();
            else
                ShowDetail();
        }

        #endregion

        #region : Clipboard Button Click Event :

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtDetail.SelectAll();
            txtDetail.Copy();
        }

        #endregion

        #region : Report Button Click Event :

        private void btnReport_Click(object sender, EventArgs e)
        {
            //TODO: 서버에 오류를 전송할 수 있는 로직 만들기!(긴급도 100)
        }

        #endregion

        #region : Resize Button Click Event :

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (_enlarged)
            {
                Width = _stdFormWidth;
                Height = _stdFormHeight;
                txtDetail.Width = _stdDetailWidth;
                txtDetail.Height = _stdDetailHeight;
                btnResize.Text = "크게";
                _enlarged = false;
            }
            else
            {
                Width = _stdFormWidth + _stdFormWidth / 2;
                Height = _stdFormHeight + _stdFormHeight / 2;
                txtDetail.Width = _stdDetailWidth + _stdFormWidth / 2;
                txtDetail.Height = _stdDetailHeight + _stdFormHeight / 2;
                btnResize.Text = "작게";
                _enlarged = true;
            }

        }

        #endregion

        #region : Exit Button Click Event :

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        #endregion
    }
}