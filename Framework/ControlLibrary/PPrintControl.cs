using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;

namespace TLF.Framework.ControlLibrary
{
    public partial class PPrintControl : DevExpress.XtraPrinting.Control.PrintControl
    {
        public PrintBarManager fPrintBarManager;
        
        public PPrintControl()
        {
            InitializeComponent();
            fPrintBarManager = CreatePrintBarManager();
        }

        public void CreateReport(XtraReport report)
        {
            report.PrintingSystem.ClearContent();
            Invalidate();
            Update();
            PrintingSystem = report.PrintingSystem;
            report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
            report.CreateDocument(true);
        }

        private PrintBarManager CreatePrintBarManager()
        {
            PrintBarManager pManager = new PrintBarManager { Form = this };
            pManager.Initialize(this);
            pManager.MainMenu.Visible = false;
            pManager.AllowCustomization = false;
            return pManager;
        }
    }
}
