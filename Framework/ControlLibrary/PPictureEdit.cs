using System;
using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;

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
    public partial class PPictureEdit : DevExpress.XtraEditors.PictureEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// PictureEdit Control을 생성합니다.
        /// </summary>
        public PPictureEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _checkModify = false;
        private bool _viewDblClick = false;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

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

        #region :: ShowMenu :: PictureEdit의 메뉴 숨김/보임을 설정합니다.
        
        /// <summary>
        /// PictureEdit의 메뉴 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PictureEdit의 메뉴 숨김/보임을 설정합니다."), Browsable(true)]
        public bool ShowMenu
        {
            get { return Properties.ShowMenu; }
            set { Properties.ShowMenu = value; }
        } 

        #endregion

        #region :: SizeMode :: PictureEdit의 Size Mode를 설정합니다.
        /// <summary>
        /// PictureEdit의 Size Mode를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("PictureEdit의 Size Mode를 설정합니다."), Browsable(true)]
        public PictureSizeMode SizeMode
        {
            get { return Properties.SizeMode; }
            set { Properties.SizeMode = value; }
        } 
        #endregion

        #region :: ViewDblClick :: Double Click 시에 Popup 생성여부를 설정합니다.

        /// <summary>
        /// Double Click 시에 Popup 생성여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Double Click 시에 Popup 생성여부를 설정합니다."), Browsable(true)]
        public bool ViewDblClick
        {
            get { return _viewDblClick; }
            set { _viewDblClick = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnDoubleClick :: 더블클릭하면 이미지 원본을 보여줍니다.

        /// <summary>
        /// 더블클릭하면 이미지 원본을 보여줍니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDoubleClick(EventArgs e)
        {
            if (_viewDblClick && base.EditValue != null)
            {
                using (ImageForm imgForm = new ImageForm { Text = "Image Viewer", ImageData = EditValue })
                {
                    System.Drawing.Image img = Image;

                    if (img != null)
                    {
                        imgForm.Height = img.Height + 50;
                        imgForm.Width = img.Width + 20;
                    }
                    imgForm.ShowDialog();
                }
            }
            base.OnDoubleClick(e);
        }

        #endregion

        #region :: EditValue :: Gets or sets editor's value

        /// <summary>
        /// Gets or sets editor's value
        /// </summary>
        public override object EditValue
        {
            get
            {
                return base.EditValue ?? new byte[] { };
            }
            set
            {
                base.EditValue = value;
            }
        }

        #endregion

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
