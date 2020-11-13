using System.ComponentModel;
using DevExpress.XtraEditors.Controls;
using TLF.Framework.Config;
using System;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 2008-12-16 최초생성 : 황준혁
    /// 변경내역
    /// 
    /// </remarks>
    public partial class PMultiButtonEdit : DevExpress.XtraEditors.ButtonEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::
        
        /// <summary>
        /// Multi Button Control을 생성합니다.
        /// </summary>
        public PMultiButtonEdit()
        {
            InitializeComponent();
        } 

        #endregion
        
        #region :: 전역변수 ::

        private string[] _buttonCaptions = null;
        
        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Properties
        ///////////////////////////////////////////////////////////////////////////////////////////////
        
        #region :: ButtonCaptions :: 버튼의 Caption을 설정합니다.(Caption 수만큼 Button이 생성됩니다.)
        
        /// <summary>
        /// 버튼의 Caption을 설정합니다.
        /// Caption 수만큼 Button이 생성됩니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("버튼의 Caption을 설정합니다.\nCaption 수만큼 Button이 생성됩니다."), Browsable(true)]
        public string[] ButtonCaptions
        {
            get { return _buttonCaptions; }
            set { 
                _buttonCaptions = value;
                InitButtons();
            }
        } 

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Public)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: InitButtons :: ButtonCaptions 를 참조하여 Button을 생성합니다.
        
        /// <summary>
        /// ButtonCaptions 를 참조하여 Button을 생성합니다.
        /// </summary>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void InitButtons()
        {
            this.BeginUpdate();

            this.Properties.Buttons.Clear();

            if (_buttonCaptions == null)
                return;

            Array.ForEach(_buttonCaptions, str =>
            {
                EditorButton eb = new EditorButton { Kind = ButtonPredefines.Glyph, Caption = str };
                this.Properties.Buttons.Add(eb);
            });

            this.EndUpdate();
        }

        #endregion

        #region :: SetButtonCaption :: 버튼의 Caption을 설정합니다.

        /// <summary>
        /// 버튼의 Caption을 설정합니다.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="caption"></param>
        /// <remarks>
        /// 2009-03-05 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetButtonCaption(int index, string caption)
        {
            this.Properties.Buttons[index].Caption = caption;
        }

        #endregion

        #region :: SetButtonEnable(+1 Overloading) :: 버튼의 활성화를 설정합니다.

        /// <summary>
        /// 버튼의 활성화를 설정합니다.
        /// </summary>
        /// <param name="enable">활성화 여부</param>
        /// <param name="captions">설정할 Caption</param>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetButtonEnable(bool enable, params string[] captions)
        {
            foreach (EditorButton eb in this.Properties.Buttons)
            {
                //eb.Enabled = !enable;
                for (int i = 0; i < captions.Length; i++)
                {
                    if (eb.Caption == captions[i])
                        eb.Enabled = enable;
                }
            }
        }

        /// <summary>
        /// 버튼의 활성화를 설정합니다.
        /// </summary>
        /// <param name="enable">활성화 여부</param>
        /// <param name="indexs">설정할 Index</param>
        /// <remarks>
        /// 2009-02-04 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetButtonEnable(bool enable, params int[] indexs)
        {
            foreach (EditorButton eb in this.Properties.Buttons)
            {
                //eb.Enabled = !enable;
                for (int i = 0; i < indexs.Length; i++)
                {
                    if (eb.Index == indexs[i])
                        eb.Enabled = enable;
                }
            }
        }

        #endregion

        #region :: SetButtonVisible(+1 Overloading) :: 버튼의 숨김/보임을 설정합니다.

        /// <summary>
        /// 버튼의 숨김/보임을 설정합니다.
        /// </summary>
        /// <param name="visible">숨김/보임</param>
        /// <param name="captions">설정할 Captions</param>
        /// <remarks>
        /// 2008-12-16 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetButtonVisible(bool visible, params string[] captions)
        {
            foreach (EditorButton eb in this.Properties.Buttons)
            {
                //eb.Visible = !visible;
                for (int i = 0; i < captions.Length; i++)
                {
                    if (eb.Caption == captions[i])
                        eb.Visible = visible;
                }
            }
        }

        /// <summary>
        /// 버튼의 숨김/보임을 설정합니다.
        /// </summary>
        /// <param name="visible">숨김/보임</param>
        /// <param name="indexs">설정할 Index</param>
        /// <remarks>
        /// 2009-02-04 최초생성 : 황준혁
        /// 변경내역
        /// 
        /// </remarks>
        public void SetButtonVisible(bool visible, params int[] indexs)
        {
            foreach (EditorButton eb in this.Properties.Buttons)
            {
                //eb.Visible = !visible;
                for (int i = 0; i < indexs.Length; i++)
                {
                    if (eb.Index == indexs[i])
                        eb.Visible = visible;
                }
            }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnCreateControl :: Multi Button Control 이 처음 생성될 때 처리됩니다.

        /// <summary>
        /// Multi Button Control 이 처음 생성될 때 처리됩니다.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            InitButtons();
        }

        #endregion
    }
}
