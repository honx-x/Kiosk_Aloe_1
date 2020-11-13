using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Text;
using System.Drawing;
using TLF.Framework.BaseFrame;
using TLF.Framework.Collections;


namespace LipControl
{
    public partial class LipGroup : DevExpress.XtraEditors.XtraUserControl
    {

        public LipGroup()
        {
            InitializeComponent();
        }

        private int cnt;
        private string LayerCode;
        private string frDate;
        private string toDate;
        private string setUserGroup;

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("SEMCO")]
        [Description("설비명을 설정합니다."), Browsable(true)]
        public string GroupName
        {
            get { return ButtonTitle.Text; }
            set
            {
                ButtonTitle.Text = value;
            }
        }


        [Category("SEMCO")]
        [Description("액조값을 설정합니다."), Browsable(true)]
        public string Title
        {
            get
            {
                return textLiqGroup.Text;
            }
            set
            {
                textLiqGroup.Text = value;
            }
        }
        [Category("SEMCO")]
        [Description("Detail 컨트롤 수를 받는다."), Browsable(true)]
        public int ConCount
        {
            get
            {
                return cnt;
            }
            set
            {
                cnt = value;
            }
        }
        [Category("SEMCO")]
        [Description("액조코드 값을 설정합니다."), Browsable(true)]
        public string LiqLayerCode
        {
            get { return LayerCode; }
            set
            {
                LayerCode = value;
            }
        }

        [Category("SEMCO")]
        [Description("FromDate값 설정"), Browsable(true)]
        public string FromDate
        {
            get { return frDate; }
            set
            {
                frDate = value;
            }
        }

        [Category("SEMCO")]
        [Description("ToDate값 설정"), Browsable(true)]
        public string ToDate
        {
            get { return toDate; }
            set
            {
                toDate = value;
            }
        }

        [Category("SEMCO")]
        [Description("UserGroup 설정"), Browsable(true)]
        public string UserGroup
        {
            get { return setUserGroup; }
            set
            {
                setUserGroup = value;
            }
        }

        public void LiqDisplay(string[] title, string[] UCL, string[] LCL, string[] Value, string[] AlarmFlag)
        {

           
            int iOneWidth = 0;
            if (ConCount < 3)
            {
                iOneWidth= panelControl1.Width / 3;
            }
            else
            {
                iOneWidth = panelControl1.Width / ConCount;
            }


            int iOneHeight = panelControl1.Height - 5;
            int pnlWidth = panelControl1.Width;

            int iFirstPosition = 0;

            int iPos = 0;

            for (int i = 0; i < cnt; i++)
            {
                LipDisplayControl tmpLst = new LipDisplayControl();
                this.panelControl1.Controls.Add(tmpLst);
                iPos = tmpLst.Width;



                //if (i == 0)
                //{
                //    tmpLst.Location = new Point(3, 5);
                //}
                //else
                //{
                //    //tmpLst.Location = new Point(iPos * i, 5);
                //    //ehhong modify 
                //    tmpLst.Location = new Point(iOneWidth * i, 5);
                //}

                //가운데로 배치 하기 위해서 ( 갯수가 3개 이하일경우 처음 위치 조정)
                if (ConCount == 1)
                {
                    iFirstPosition = (pnlWidth - tmpLst.Width) / 2;
                    tmpLst.Location = new Point(iFirstPosition, 3);
                }
                else if (ConCount == 2)
                {
                    iFirstPosition = (pnlWidth - tmpLst.Width * 2) / 2;
                    tmpLst.Location = new Point(iOneWidth * i + iFirstPosition, 3);

                }
                else
                {

                   
                    tmpLst.Location = new Point(iOneWidth * i-1, 3);
                }


             
                tmpLst.Size = new Size(iOneWidth, iOneHeight);

                tmpLst.Title = title[i];

                tmpLst.UCL = UCL[i];
                tmpLst.LCL = LCL[i];
                tmpLst.AnalysisValue = Value[i];
                tmpLst.ValueType = AlarmFlag[i];
            }
        }

        private void ButtonTitle_Click(object sender, EventArgs e)
        {
            LinkEventParams linkParam = new LinkEventParams();
            linkParam["LayerCode"] = LayerCode;
            linkParam["FromDate"] = frDate;
            linkParam["ToDate"] = toDate;
            linkParam["GroupName"] = setUserGroup;

            (this.ParentForm as UIFrame).ExecuteUI("Liq03", linkParam);
        }


    }
}
