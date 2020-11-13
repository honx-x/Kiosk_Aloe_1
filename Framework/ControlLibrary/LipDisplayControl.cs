using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

using System.Text;
using System.Drawing;

namespace LipControl
{
    public partial class LipDisplayControl : DevExpress.XtraEditors.XtraUserControl
    {

        private string _valueType = "";

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("SEMCO")]
        [Description("Value 설정합니다."), Browsable(true)]
        public string ValueType
        {
            get { return _valueType; }
            set 
            {
                _valueType = value;
                setColor();
            }
        }

        #region :: EnableClear :: 일괄 초기화 여부를 설정합니다.

        /// <summary>
        /// 일괄 초기화 여부를 설정합니다.
        /// </summary>
        [Category("SEMCO")]
        [Description("Title을 설정합니다."), Browsable(true)]
        public string Title
        {
            get { return layoutControlGroup2.Text; }
            set
            {
                layoutControlGroup2.Text = value;
            }
        }

        [Category("SEMCO")]
        [Description("UCL 값을 설정합니다."), Browsable(true)]
        public string UCL
        {
            get
            {
            	return textUCL.Text;
            }
            set
            {
                textUCL.Text = value; 
            }
        }

        [Category("SEMCO")]
        [Description("LCL 값을 설정합니다."),Browsable(true)]
        #endregion
        public string LCL
        {
            get
            {
                return textLCL.Text;
            }
            set
            {
                textLCL.Text = value;
            }
        }


        [Category("SEMCO")]
        [Description("분석값을 값을 설정합니다."),Browsable(true)]        
        public string AnalysisValue
        {
            get
            {
                return textValue.Text;
            }

            set
            {
                textValue.Text = value;
            }
        }

        public void setColor()
        {
            if (_valueType=="OOS")
            {
                textValue.AppearanceItemCaption.BackColor = Color.Red;
            }
            else if (_valueType=="OOC")
            {
                textValue.AppearanceItemCaption.BackColor = Color.Yellow;
            }
            else
            {
                textValue.AppearanceItemCaption.BackColor = Color.Green ;
            }

        }


        public LipDisplayControl()
        {
            InitializeComponent();
        }

    }
}
