using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace TLF.Framework.BaseFrame
{
	
	public partial class XtraReportViewer : Form
	{
		public XtraReportViewer()
		{
			InitializeComponent();
		}

		public void ShowReport(DevExpress.XtraReports.IReport rpt)
		{
			ReportPrintTool pt = new ReportPrintTool(rpt);
			pt.ShowPreviewDialog();
			//pt.ShowPreview(UserLookAndFeel.Default);
		}

	}
}
