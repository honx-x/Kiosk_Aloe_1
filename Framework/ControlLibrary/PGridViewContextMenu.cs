using System;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using TLF.Framework.BaseFrame;
using TLF.Framework.Utility;
using TLF.Framework.Config;
using System.Text;
using TLF.Framework.MessageHelper;
using System.IO;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// PGridView에서 사용할 ContextMenu 입니다.
    /// </summary>
    internal class PGridViewContextMenu : GridViewMenu
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// PGridViewContextMenu를 생성합니다.
        /// </summary>
        /// <param name="view"></param>
        public PGridViewContextMenu(DevExpress.XtraGrid.Views.Grid.GridView view)
            : base(view)
        {

        }

        #endregion

        #region :: 전역변수 ::

        #endregion.


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateItems :: Menu Item을 생성합니다.

        /// <summary>
        /// Menu Item을 생성합니다.
        /// </summary>
        protected override void CreateItems()
        {
            Items.Clear();
            string keyName = String.Format("{0}{1}", (View.GridControl.FindForm() as UIFrame).MenuID, View.Name);
            
            StringBuilder sb = new StringBuilder(128);
            Win32Util.GetPrivateProfileString("GridLayout", keyName, "", sb, 128, AppConfig.SETTINGFILEPATH);

            DXSubMenuItem columnsItem = new DXSubMenuItem("Columns");

            Items.Add(columnsItem);
            Items.Add(CreateMenuItem("컬럼 사용자지정", GridMenuImages.Column.Images[5], "Customization", true));

            //Items.Add(CreateMenuItem("컬럼 Layout 불러오기", null, "LayoutLoad", sb.ToString() == string.Empty || !File.Exists(sb.ToString()) ? false : true, true));
            Items.Add(CreateMenuItem("컬럼 Layout 저장", null, "LayoutSave", true));
            Items.Add(CreateMenuItem("컬럼 Layout 삭제", null, "LayoutDelete", sb.ToString() == string.Empty || !File.Exists(sb.ToString()) ? false : true));

            foreach (GridColumn column in View.Columns)
            {
                if (column.OptionsColumn.ShowInCustomizationForm)
                    columnsItem.Items.Add(CreateMenuCheckItem(column.GetTextCaption(), column.VisibleIndex >= 0, null, column, true));
            }
        }

        #endregion

        #region :: OnMenuItemClick :: MenuItem Click Event를 정의합니다.

        /// <summary>
        /// Menu Item Click Event를 정의합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnMenuItemClick(object sender, EventArgs e)
        {
            if (RaiseClickEvent(sender, null)) return;
            DXMenuItem item = sender as DXMenuItem;
            if (item.Tag == null) return;
            if (item.Tag is GridColumn)
            {
                GridColumn column = item.Tag as GridColumn;
                column.VisibleIndex = column.VisibleIndex >= 0 ? -1 : View.VisibleColumns.Count;
            }
            else if (item.Tag.ToString() == "Customization") View.ColumnsCustomization();
            else if (item.Tag.ToString() == "LayoutLoad")
            {
                try
                {
                    string keyName = String.Format("{0}{1}", (View.GridControl.FindForm() as UIFrame).MenuID, View.Name);

                    StringBuilder sb = new StringBuilder(128);
                    Win32Util.GetPrivateProfileString("GridLayout", keyName, "", sb, 128, AppConfig.SETTINGFILEPATH);
                    View.RestoreLayoutFromXml(sb.ToString());
                    //using (OpenFileDialog ofd = new OpenFileDialog { Filter = "XML 문서|*.xml", Multiselect = false })
                    //{
                    //    if (ofd.ShowDialog() == DialogResult.OK)
                    //        View.RestoreLayoutFromXml(ofd.FileName);
                    //}
                }
                catch(Exception ex)
                {
                    Win32Util.WritePrivateProfileString("GridLayout", (View.GridControl.FindForm() as UIFrame).MenuID + View.Name, "", AppConfig.SETTINGFILEPATH);
                    ExceptionHelper.ExceptionBox.Show(ex);
                }
            }
            else if (item.Tag.ToString() == "LayoutSave")
            {
                AppUtil.CreateFolder(AppConfig.GRIDLAYOUTFOLDER);
                string path = Path.Combine(AppConfig.GRIDLAYOUTFOLDER, String.Format("{0}.xml", View.Name));
                View.SaveLayoutToXml(path);
                Win32Util.WritePrivateProfileString("GridLayout", (View.GridControl.FindForm() as UIFrame).MenuID + View.Name, path, AppConfig.SETTINGFILEPATH);
                (View.GridControl.FindForm() as UIFrame).ShowAlertMessage("Layout 저장 완료", String.Format("{0}{1} Layout이 저장되었습니다.", path, Environment.NewLine), "");
            }
            else if (item.Tag.ToString() == "LayoutDelete")
            {
                if (MsgBox.Show("이전 저장된 Layout을 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Win32Util.WritePrivateProfileString("GridLayout", (View.GridControl.FindForm() as UIFrame).MenuID + View.Name, "", AppConfig.SETTINGFILEPATH);
                }
            }
        }

        #endregion
    }
}

