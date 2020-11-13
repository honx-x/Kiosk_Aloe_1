using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using TLF.Framework.Config;
using TLF.Framework.Utility;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class ControlUtil
    {
        #region :: MakeComboBoxCell(+4 Overloading) :: ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <returns></returns>
        public static RepositoryItem MakeComboBoxCell(object[] valueList, string[] displayList)
        {
            return MakeComboBoxCell(valueList, displayList, false, false);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeComboBoxCell(object[] valueList, string[] displayList, bool showAllItemVisible, bool showCodeColumnVisible)
        {
            if (valueList.Length != displayList.Length)
                return null;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx].ToString().Trim();
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx].Trim();
                    dt.Rows.Add(dr);
                }
                return MakeComboBoxCell(dt, showAllItemVisible, showCodeColumnVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeComboBoxCell(DataTable dt)
        {
            return MakeComboBoxCell(dt, false, false);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public static RepositoryItem MakeComboBoxCell(DataTable dt, bool showAllItemVisible, bool showCodeColumnVisible)
        {
            return MakeComboBoxCell(dt, showAllItemVisible, showCodeColumnVisible, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ComboBox Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="showAllItemVisible">전체선택 숨김/보임</param>
        /// <param name="showCodeColumnVisible">Code Column 숨김/보임</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <returns></returns>
        public static RepositoryItem MakeComboBoxCell(DataTable dt, bool showAllItemVisible, bool showCodeColumnVisible, string valueMember, string displayMember)
        {
            RepositoryItemLookUpEdit edit = new RepositoryItemLookUpEdit();

            DataRow dr;
            if (showAllItemVisible)
            {
                dr = dt.NewRow();
                dr[valueMember] = "";
                dr[displayMember] = "";
                dt.Rows.InsertAt(dr, 0);
            }
            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.NullText = "";
            edit.DataSource = dt;
            edit.ValueMember = valueMember;
            edit.DisplayMember = displayMember;
            string[] columns = AppUtil.GetColumnsFromDataTable(dt);
            Array.ForEach(columns, column =>
            {
                edit.Columns.Add(column == valueMember ? CreateColumn(column, column, 70, HorzAlignment.Center, showCodeColumnVisible) : CreateColumn(column, column, 120, HorzAlignment.Default, true));
            });
            edit.ShowHeader = edit.Columns.Count < 3 ? false : true;
            edit.TextEditStyle = TextEditStyles.DisableTextEditor;

            return edit;
        }

        #endregion

        #region :: MakeSpinEditCell :: SpinEdit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)

        /// <summary>
        /// SpinEdit Cell을 만듭니다.(CustomRowCellEditForEditing Event에서만 사용합니다.)
        /// </summary>
        /// <returns></returns>
        public static RepositoryItem MakeSpinEditCell()
        {
            RepositoryItemSpinEdit edit = new RepositoryItemSpinEdit();

            edit.Appearance.Font = ControlConfig.DEFAULTFONT;
            edit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            //edit.Mask.EditMask = "n" + decimalPlace;
            //edit.MaxLength = maxLength;
            edit.Mask.UseMaskAsDisplayFormat = false;

            return edit;
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: CreateColumn :: LookUpColumn을 만듭니다.

        /// <summary>
        /// LookUpColumn을 만듭니다.
        /// </summary>
        /// <param name="fieldName">Field 명</param>
        /// <param name="caption">Column Caption 명</param>
        /// <param name="width">Column 너비</param>
        /// <param name="align">Column 정렬</param>
        /// <param name="visible">Column 숨김/보임</param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        internal static LookUpColumnInfo CreateColumn(string fieldName, string caption, int width, HorzAlignment align, bool visible)
        {
            LookUpColumnInfo column = new LookUpColumnInfo { FieldName = fieldName, Caption = caption, Width = width, Alignment = align, Visible = visible };

            return column;
        }

        #endregion
    }
}
