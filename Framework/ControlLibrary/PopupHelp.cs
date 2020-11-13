using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class PopupHelp : DevExpress.XtraEditors.XtraForm
    {
        #region :: 생성자 ::
        
        /// <summary>
        /// 
        /// </summary>
        internal PopupHelp()
        {
            InitializeComponent();
        } 

        #endregion
        
        internal PGridView gridView
        {
            get
            {
                return this.viewPopup;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}