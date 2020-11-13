using System.ComponentModel;
using TLF.Framework.Config;
using System.Data;
using DevExpress.XtraCharts;
using System;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-24 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PChartEdit : DevExpress.XtraCharts.ChartControl
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Chart Edit Control을 생성합니다.
        /// </summary>
        public PChartEdit()
        {
            InitializeComponent();
        } 

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private bool _lineMarkerVisible = false;

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

        #region :: LineMarkerVisible :: Line Marker의 숨김/보임을 설정합니다.

        /// <summary>
        /// Line Marker의 숨김/보임을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("Line Marker의 숨김/보임을 설정합니다."), Browsable(true)]
        public bool LineMarkerVisible
        {
            get { return _lineMarkerVisible; }
            set { _lineMarkerVisible = value; }
        }
        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FillChart :: Chart Data를 채웁니다.

        /// <summary>
        /// Chart Data를 채웁니다.
        /// </summary>
        /// <param name="dt"></param>
        public void FillChart(DataTable dt)
        {
            DataSource = dt;
        }

        #endregion

        #region :: InitSeries(+1 Overloading) :: Series를 초기화합니다.
        
        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMembers">Value DataMembers</param>
        public void InitSeries(string name, string argumentDataMember, string[] valueDataMembers)
        {
            InitSeries(name, argumentDataMember, valueDataMembers, ViewType.Line, false);
        }

        /// <summary>
        /// Series를 초기화합니다.
        /// </summary>
        /// <param name="name">Series 이름</param>
        /// <param name="argumentDataMember">Argument DataMember</param>
        /// <param name="valueDataMembers">Value DataMembers</param>
        /// <param name="type">Series Type</param>
        /// <param name="labelVisible">Label 숨김/보임</param>
        public void InitSeries(string name, string argumentDataMember, string[] valueDataMembers, ViewType type, bool labelVisible)
        {
            Series series = new Series(name, type) { ArgumentDataMember = argumentDataMember };
            series.ValueDataMembers.AddRange(valueDataMembers);
            series.Label.Visible = labelVisible;
            series.ShowInLegend = true;
            series.ValueScaleType = ScaleType.Numerical;
            series.ArgumentScaleType = ScaleType.Numerical;

            
            switch(type)
            {
                case ViewType.Line:
                case ViewType.Line3D:
                    (series.View as LineSeriesView).LineMarkerOptions.Visible = false;
                    break;
            }

            Series.Add(series);

            //((XYDiagram)Diagram).Rotated = true;
        }

        #endregion
    }
}
