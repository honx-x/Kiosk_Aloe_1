using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using DevExpress.XtraCharts;


namespace TLF.Framework.ControlLibrary
{
    public partial class PChartTypeComboEdit : TLF.Framework.ControlLibrary.PMultiComboBoxEdit 
    {
        public PChartTypeComboEdit()
        {
            InitializeComponent();
        }


        /// <summary>
        /// MultiComboBoxEdit에 값을 넣습니다.
        /// </summary>
        /// <remarks>
        /// 2010-03-11 최초생성 : 최경수
        /// 변경내역
        /// Chart Type을 만들기위한 콤보
        /// </remarks>
        public void InitData()
        {

            List<object> CharType = new List<object>();

            CharType.Add(ViewType.Area);
            CharType.Add(ViewType.Bar);
            CharType.Add(ViewType.FullStackedArea);
            CharType.Add(ViewType.Funnel);
            CharType.Add(ViewType.Line);
            CharType.Add(ViewType.Point);
            CharType.Add(ViewType.RadarArea);
            CharType.Add(ViewType.SideBySideGantt);
            CharType.Add(ViewType.StepLine);

            CharType.Add(ViewType.StackedBar);
            CharType.Add(ViewType.StackedBar3D);
            CharType.Add(ViewType.Stock);
            CharType.Add(ViewType.SplineArea);
            CharType.Add(ViewType.RadarLine);

            this.InitData(CharType.ToArray(), new string[] { "Area", "Bar", "FullStackedArea", "Funnel", "Line", "Point", "RadarArea", "SideBySideGantt", "StepLine", "StackedBar", "StackedBar3D", "Stock", "SplineArea", "RadarLine" });

        }

    }
}
