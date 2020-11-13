using System;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// Form의 업무내용을 기술합니다.
    /// </summary>
    /// <remarks>
    /// (생성일자 입력) 최초생성 : 개발자명(회사명)
    /// 변경내역
    /// 
    /// </remarks>
    internal partial class ImageForm : TLF.Framework.BaseFrame.PopupFrame
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ImageForm Form을 생성합니다.
        /// </summary>
        public ImageForm()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private object _imageData = null;

        #endregion

        #region :: ImageData :: Viewer 에서 사용할 ImageData

        /// <summary>
        /// Viewer 에서 사용할 ImageData
        /// </summary>
        public object ImageData
        {
            get { return _imageData; }
            set { _imageData = value; }
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////




        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Handler(Common Event)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: ImageForm_Load :: Form이 Load 시 발생합니다.

        /// <summary>
        /// Form이 Load 시 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitControls();

                // Form Load 후 조회를 실행해야 한다면 주석을 제거하세요.
                //SelectionData();
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

        #region :: imgViewer_Click :: Image를 Click 하면 Form을 닫습니다.

        /// <summary>
        /// Image를 Click 하면 Form을 닫습니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgViewer_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        // Initialize 관련 Method

        #region :: InitGlobalInstance :: 전역변수 Initialize

        /// <summary>
        /// 전역변수 Initialize
        /// </summary>
        private void InitGlobalInstance()
        {
        }

        #endregion

        #region :: InitGridControl :: Grid Control Initialize

        /// <summary>
        /// Grid Control Initialize
        /// </summary>
        private void InitGridControl()
        {
        }

        #endregion

        #region :: InitComboBox :: ComboBox Initialize

        /// <summary>
        /// ComboBox Initialize
        /// </summary>
        private void InitComboBox()
        {
        }

        #endregion

        #region :: InitControls :: 기타 Control Initialize

        /// <summary>
        /// 기타 Control Initialize
        /// </summary>
        private void InitControls()
        {
            if (_imageData == null) return;

            imgViewer.EditValue = _imageData;
        }

        #endregion

        // 사용자 권한 처리 Method

        // 기타 Control Event 처리 Method는 아래에 기술하세요.

        #region :: SetFormLayout :: Form의 Layout을 변경합니다.

        /// <summary>
        /// Form의 Layout을 변경합니다.
        /// </summary>
        private void SetFormLayout()
        {
        }

        #endregion

        #region :: SetGridLayout :: Grid의 Layout을 변경합니다.

        /// <summary>
        /// Grid의 Layout을 변경합니다.
        /// </summary>
        private void SetGridLayout()
        {
        }

        #endregion
    }
}
