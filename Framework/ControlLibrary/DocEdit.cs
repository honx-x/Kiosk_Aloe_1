using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TLF.Framework.ExceptionHelper;
using TLF.Framework.Config;
using TLF.Framework.BaseFrame;
using DevExpress.XtraRichEdit.API.Native;

namespace TLF.Framework.ControlLibrary
{
	public partial class DocEdit : DevExpress.XtraEditors.XtraUserControl
	{
		public DocEdit()
		{
			InitializeComponent();
		}


		#region :: 전역변수 ::

		private bool _enableClear = false;
		private bool _checkModify = false;
		private bool _enterKeySelectEvent = false;

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

		#region :: EnterKeySelectEvent :: Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.

		/// <summary>
		/// Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다.
		/// </summary>
		[Category(AppConfig.CONTROLCATEGORY)]
		[Description("Enter Key를 누르면 조회 이벤트를 발생시킬지 여부를 설정합니다."), Browsable(true)]
		public bool EnterKeySelectEvent
		{
			get { return _enterKeySelectEvent; }
			set
			{
				_enterKeySelectEvent = value;
			}
		}

		#endregion


		///////////////////////////////////////////////////////////////////////////////////////////////
		// Method(Public)
		///////////////////////////////////////////////////////////////////////////////////////////////

		public void CreateNewDocument()
		{
			try
			{
				richEdit.CreateNewDocument();
				richEdit.Document.Sections[0].Page.PaperKind = System.Drawing.Printing.PaperKind.A2;
				richEdit.Document.Sections[0].Page.Landscape = false;
				richEdit.Document.Sections[0].Margins.Left = 0;

				richEdit.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
				richEdit.ActiveView.ZoomFactor = 1.0f;

				return;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return;
			}
		}

		public void PaperKind(System.Drawing.Printing.PaperKind paperKind)
		{
			try
			{
				richEdit.Document.Sections[0].Page.PaperKind = paperKind;
				richEdit.Document.Sections[0].Page.Landscape = false;
				richEdit.Document.Sections[0].Margins.Left = 0;

				richEdit.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;
				richEdit.ActiveView.ZoomFactor = 1.0f;

				return;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return;
			}
		}

		public bool LoadDocu()
		{
			try
			{
				richEdit.LoadDocument();
				return true;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return false;
			}
		}


		public bool SaveDocument(string FileName, DevExpress.XtraRichEdit.DocumentFormat DocFormat)
		{
			try
			{
				richEdit.Document.SaveDocument(FileName, DocFormat);
				return true;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return false;
			}
		}


		public byte[] GetOpenXmlBytes()
		{
			byte[] bytes;
			try
			{
				bytes = richEdit.Document.GetOpenXmlBytes(richEdit.Document.Range);
				return bytes;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return null;
			}
		}


		public bool SetOpenXmlBytes(byte[] bytes)
		{
			try
			{
				richEdit.Document.HtmlText = bytes.ToString();
				richEdit.Document.OpenXmlBytes = bytes;
				return true;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return false;
			}
		}


		public bool OpenDocument(byte[] bytes, string strDocType)
		{
			try
			{
				switch (strDocType)
				{
					case "HTML":
						richEdit.Document.HtmlText = System.Text.Encoding.Unicode.GetString(bytes).Replace("\n\r","<br>");

						break;
					case "RTM":
						richEdit.Document.OpenXmlBytes = bytes;
						break;
				}
				return true;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
				return false;
			}
		}


		public void SetRibbonVisible(bool bVisible)
		{
			try
			{
				ribbon.Visible = bVisible;
			}
			catch (Exception ex)
			{
				ExceptionBox.Show(ex);
			}
		}



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
				//				if (IsModified)
				{
					(FindForm() as UIFrame).IsModified = true;
				}
			}
		}

		#endregion        

	}
}
