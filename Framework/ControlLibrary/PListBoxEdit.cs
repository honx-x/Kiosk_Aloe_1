﻿using System.Data;
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
    public partial class PListBoxEdit : DevExpress.XtraEditors.ListBoxControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// ListBox Control을 생성합니다.
        /// </summary>
        public PListBoxEdit()
        {
            InitializeComponent();
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitData(+2 Overloading) :: ListBoxEdit에 값을 넣습니다.

        /// <summary>
        /// ListBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="valueList">Value가 될 배열</param>
        /// <param name="displayList">Text가 될 배열</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(object[] valueList, string[] displayList)
        {
            if (valueList.Length != displayList.Length)
                return;

            using (DataTable dt = new DataTable())
            {
                dt.Columns.Add(AppConfig.VALUEMEMBER);
                dt.Columns.Add(AppConfig.DISPLAYMEMBER);
                for (int idx = 0; idx < valueList.Length; idx++)
                {
                    DataRow dr = dt.NewRow();
                    dr[AppConfig.VALUEMEMBER] = valueList[idx];
                    dr[AppConfig.DISPLAYMEMBER] = displayList[idx];
                    dt.Rows.Add(dr);
                }
                this.InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
            }
        }

        /// <summary>
        /// ListBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(DataTable dt)
        {
            this.InitData(dt, AppConfig.VALUEMEMBER, AppConfig.DISPLAYMEMBER);
        }

        /// <summary>
        /// ListBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <param name="dt">Datasource 가 될 DataTable</param>
        /// <param name="valueMember">ValueMember 명</param>
        /// <param name="displayMember">DisplayMemeber 명</param>
        /// <remarks>
        /// 2008-12-17 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitData(DataTable dt, string valueMember, string displayMember)
        {
            this.DataSource = dt;
            this.ValueMember = valueMember;
            this.DisplayMember = displayMember;
        }

        #endregion
    }
}
