using System;
using System.Windows.Forms;

namespace TLF.Framework.ExceptionHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-23 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public class ExceptionBox
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Static Member & Function & Interop - Define
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: Show :: Exception Form을 보여줍니다.

        /// <summary>
        /// Exception Form을 보여줍니다.
        /// </summary>
        /// <param name="ex"></param>
        public static void Show(Exception ex)
        {
            using (frmException exForm = new frmException())
            {
                try
                {
                    exForm.Exception = ex;

                    DialogResult result = exForm.ShowDialog();

                    if (result == DialogResult.Abort)
                        Application.Exit();
                }
                finally
                {
                    exForm.Dispose();
                }
            }
        } 

        #endregion
    }
}
