using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TLF.Framework.MessageHelper
{
    /// <summary>
    /// MessageBox를 만듭니다.
    /// </summary>
    /// <remarks>
    /// 2008-12-19 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class MsgBox
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function & Interop - Define
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Show(+8 Overloading) :: MessageBox를 보여줍니다.

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <returns></returns>
        public static DialogResult Show(string text)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show("<size=9><font=맑은 고딕>" + text + "</size></font>");
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show("<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>");
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show("<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>", buttons);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show("<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>", buttons, icon);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <param name="defaultButton">처음에 Focuse를 가질 Button</param>
        /// <returns></returns>
        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show("<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>", buttons, icon, defaultButton);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        public static DialogResult Show(IWin32Window owner, string text)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show(owner, "<size=9><font=맑은 고딕>" + text + "</size></font>");
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show(owner,"<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>");
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show(owner,"<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>", buttons);
        }

        /// <summary>
        /// MessageBox를 보여줍니다.
        /// </summary>
        /// <param name="owner">Owner Form</param>
        /// <param name="text">보여질 Message</param>
        /// <param name="caption">MessageBox Caption</param>
        /// <param name="buttons">Button 종류</param>
        /// <param name="icon">Icon 종류</param>
        /// <returns></returns>
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            XtraMessageBox.AllowHtmlText = true;
            return XtraMessageBox.Show(owner,"<size=9><font=맑은 고딕>" + text + "</size></font>", "<size=9><font=맑은 고딕>" + caption + "</size></font>", buttons, icon);
        } 
        #endregion
    }
}
