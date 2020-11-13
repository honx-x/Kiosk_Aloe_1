using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TLF.Framework.Config;
using TLF.Framework.Authentication;
using TLF.Framework.Localization;

namespace TLF.Framework.BaseFrame
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2009-04-27 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PopupFrame : DevExpress.XtraEditors.XtraForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// 생성자
        /// </summary>
        public PopupFrame()
        {
            InitializeComponent();
        }

        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CurrentUser :: 현재 사용자의 정보를 설정합니다.

        /// <summary>
        /// 현재 사용자의 정보를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("현재 사용자의 정보를 설정합니다."), Browsable(false)]
        public UserInformation CurrentUser
        {
            get { return (Owner as MainFrame).CurrentUser; }
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
            get { return (Owner as MainFrame).localizer; }
        }

        #endregion
    }
}