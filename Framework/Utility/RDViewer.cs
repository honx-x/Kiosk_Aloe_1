using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TLF.Framework.Utility
{
    public partial class RdViewer : Form
    {
        public RdViewer()
        {
            InitializeComponent();
        }
        public void Open(string FileName, string Parameter)
        {
            string FullPath = GetReportPath(FileName);

  //          if (ConfigInfo.Instance.ReportZoomRatio <= 0)
  //          {
  //              axRdViewer.ZoomPage();
  //          }
  //          else
  //          {
  //              axRdViewer.AutoAdjust = 0;
  ////              axRdViewer.ZoomRatio = ConfigInfo.Instance.ReportZoomRatio;
  //          }
            axRdViewer.FileOpen(FullPath, Parameter);
        }

        private string GetReportPath(string fileName)
        {
            string Kind = fileName.Substring(0, 1);
            switch (Kind)
            {
                case "M":
                    return Application.StartupPath + "\\report\\mat\\" + fileName;
                case "P":
                    return Application.StartupPath + "\\report\\prd\\" + fileName;
                case "Q":
                    return Application.StartupPath + "\\report\\qa\\" + fileName;
                case "S":
                    return Application.StartupPath + "\\report\\biz\\" + fileName;
                case "N": // 설계관리
                    return Application.StartupPath + "\\report\\dgn\\" + fileName;
                case "E": //견적
                    return Application.StartupPath + "\\report\\est\\" + fileName;
                case "C": //공통
                    return Application.StartupPath + "\\report\\cmm\\" + fileName;
                default: //알수없는 파일명은 공통에서 찾는다.
                    return Application.StartupPath + "\\" + fileName;

            }
//            return string.Empty;
        }
    }
}