using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLF.Framework.Config;
using TLF.Framework.BaseFrame;
using DevExpress.Utils;

namespace TLF.Framework.ControlLibrary
{
	public partial class PChkTxt : DevExpress.XtraEditors.XtraUserControl
	{
		public PChkTxt()
		{
			InitializeComponent();
		}

		#region :: 전역변수 ::
		private bool _enableClear = false;
        private bool _checkModify = false;
        private bool _enterKeySelectEvent = false;
		private bool _IsPeriod = true;
		private float _LabelWidth = 90F;
		#endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////

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

		#region :: EditValue :: 시작 EditValue값을 설정 및 가져옵니다.

		/// <summary>
		/// 시작 EditValue값을 설정 및 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("시작 EditValue값을 설정 및 가져옵니다."), Browsable(true)]
		public object EditValue
		{
			get { return chk.Checked ? TxtFrom.EditValue : null; }
			set { TxtFrom.EditValue = value; }
		}

		#endregion

		#region :: EditValue :: 시작 EditValue값을 설정 및 가져옵니다.

		/// <summary>
		/// 시작 EditValue값을 설정 및 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("시작 EditValue값을 설정 및 가져옵니다."), Browsable(true)]
		public object EditValueFrom
		{
			get { return chk.Checked ? TxtFrom.EditValue : null; }
			set { TxtFrom.EditValue = value; }
		}

		#endregion

		#region :: EditValueTo :: 만료 EditValue값을 설정 및 가져옵니다.

		/// <summary>
		/// 만료 EditValue값을 설정 및 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("만료 EditValue값을 설정 및 가져옵니다."), Browsable(true)]
		public object EditValueTo
		{
			get { return chk.Checked ? TxtTo.EditValue : null; }
			set { TxtTo.EditValue = value; }
		}

		#endregion

		#region :: Checked :: EditValue의 사용 여부를 설정합니다.

		/// <summary>
		/// EditValue의 사용 여부를 설정합니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("EditValue의 사용 여부를 설정합니다."), Browsable(true)]
		public bool Checked
		{
			get { return chk.Checked; }
			set { chk.Checked = value; }
		}

		#endregion

		#region :: Label :: Label을 설정 또는 가져옵니다.

		/// <summary>
		/// Label을 설정 또는 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("Label을 설정 또는 가져옵니다."), Browsable(true)]
		public string Label
		{
			get { return chk.Text; }
			set { chk.Text = value; }
		}

		#endregion

		#region :: Label :: Label 넓이를 설정 또는 가져옵니다.

		/// <summary>
		/// Label 넓이를 설정 또는 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("Label 넓이를 설정 또는 가져옵니다."), Browsable(true)]
		public float LabelWidth
		{
			get { return _LabelWidth; }
			set
			{
				_LabelWidth = value;
				if (_IsPeriod)
				{
					tableLayoutPanel1.ColumnStyles[0].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[0].Width = _LabelWidth;
					tableLayoutPanel1.ColumnStyles[1].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[1].Width = 50F;
					tableLayoutPanel1.ColumnStyles[2].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[2].Width = 10F;
					tableLayoutPanel1.ColumnStyles[3].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[3].Width = 50F;
				}
				else
				{
					tableLayoutPanel1.ColumnStyles[0].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[0].Width = _LabelWidth;
					tableLayoutPanel1.ColumnStyles[1].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[1].Width = 100F;
					tableLayoutPanel1.ColumnStyles[2].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[2].Width = 0F;
					tableLayoutPanel1.ColumnStyles[3].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[3].Width = 0F;
				}
			}
		}

		#endregion

		#region :: IsPeriod :: 기간 입력유무를 설정 또는 가져옵니다.

		/// <summary>
		/// 기간 입력유무를 설정 또는 가져옵니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("기간 입력유무를 설정 또는 가져옵니다."), Browsable(true)]
		public bool IsPeriod
		{
			get { return _IsPeriod; }
			set
			{
				_IsPeriod = value;
				if (_IsPeriod)
				{
					tableLayoutPanel1.ColumnStyles[0].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[0].Width = _LabelWidth;
					tableLayoutPanel1.ColumnStyles[1].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[1].Width = 50F;
					tableLayoutPanel1.ColumnStyles[2].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[2].Width = 10F;
					tableLayoutPanel1.ColumnStyles[3].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[3].Width = 50F;
				}
				else
				{
					tableLayoutPanel1.ColumnStyles[0].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[0].Width = _LabelWidth;
					tableLayoutPanel1.ColumnStyles[1].SizeType = System.Windows.Forms.SizeType.Percent;
					tableLayoutPanel1.ColumnStyles[1].Width = 100F;
					tableLayoutPanel1.ColumnStyles[2].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[2].Width = 0F;
					tableLayoutPanel1.ColumnStyles[3].SizeType = System.Windows.Forms.SizeType.Absolute;
					tableLayoutPanel1.ColumnStyles[3].Width = 0F;
				}
			}			
		}

		#endregion


		#region :: EnterKeySelectEvent :: Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.

        /// <summary>
        /// Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다."), Browsable(true)]
        public bool EnterKeySelectEvent
        {
            get { return _enterKeySelectEvent; }
            set { 
                _enterKeySelectEvent = value;
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: SetSuperToolTip :: ToolTip을 설정합니다.

        /// <summary>
        /// ToolTip을 설정합니다.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="contents"></param>
        public void SetSuperToolTip(string title, string contents)
        {
            SuperToolTip sTip = new SuperToolTip();
            ToolTipTitleItem tTitle = new ToolTipTitleItem();
            ToolTipItem tContents = new ToolTipItem();
            tTitle.Text = title;
            tContents.Text = contents;
            tContents.LeftIndent = 6;
            sTip.Items.Add(tTitle);
            sTip.Items.Add(tContents); TxtFrom.SuperTip = sTip;

        }

        #endregion



        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnKeyDown :: Enter Key를 입력하면 조회 이벤트를 실행합니다.

        /// <summary>
        /// Enter Key를 입력하면 조회 이벤트를 실행합니다.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (!_enterKeySelectEvent || e.KeyCode != System.Windows.Forms.Keys.Enter) return;

            (FindForm() as UIFrame).OnSelectionEvent();
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
                if (TxtFrom.IsModified)
                {
                    (FindForm() as UIFrame).IsModified = true;
                }
            }
        }
        #endregion        

  
	}
}
