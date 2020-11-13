
namespace TLF.Framework.Applications
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-22 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class frmProgress : DevExpress.XtraEditors.XtraForm
    {
        #region :: 생성자 ::
        
        /// <summary>
        /// Progress Form을 생성합니다.
        /// </summary>
        public frmProgress()
        {
            InitializeComponent();
        } 

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region :: ProgramName :: Program ID를 설정합니다.

        /// <summary>
        /// Program ID를 설정합니다.
        /// </summary>
        public string ProgramName
        {
            get { return lblPgmName.Text; }
            set { lblPgmName.Text = value; }
        }

        #endregion
    }
}