using System.ComponentModel;
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
    public partial class PButtonEdit : DevExpress.XtraEditors.SimpleButton
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// SimpleButton Control을 생성합니다.
        /// </summary>
        public PButtonEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::
        
        ButtonType _buttonType = ButtonType.Default; 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ButtonType :: 버튼의 타입을 설정합니다.

        /// <summary>
        /// 버튼의 타입을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("버튼의 타입을 설정합니다."), Browsable(true)]
        public ButtonType ButtonType
        {
            get { return _buttonType; }
            set
            {
                _buttonType = value;
                SetButtonType();
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetButtonType :: 버튼의 타입을 설정

        /// <summary>
        /// 버튼의 타입을 설정합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        private void SetButtonType()
        {
            // TODO : 버튼 타입에 따라 이미지가 변할 수 있도록 코딩해야 함.(긴급도 100, 완료예정일 : 없음) 황준혁(2008-12-16)
            switch (_buttonType)
            {
                case ButtonType.Default:
                    break;
                case ButtonType.Add:
                    break;
                case ButtonType.Delete:
                    break;
                case ButtonType.Save:
                    break;
                case ButtonType.Search:
                    break;
            }
        }
        #endregion
    }
}
