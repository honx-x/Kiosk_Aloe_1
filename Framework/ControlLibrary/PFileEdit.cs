using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using TLF.Framework.BaseFrame;
using TLF.Framework.Config;

namespace TLF.Framework.ControlLibrary
{
    /// <summary>
    /// File Up / Download를 지원하는 Text Edit 입니다.
    /// </summary>
    public partial class PFileEdit : DevExpress.XtraEditors.ButtonEdit
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Constructor & Global Instance
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: 생성자 ::

        /// <summary>
        /// TextButtonEdit Control을 생성합니다.
        /// </summary>
        public PFileEdit()
        {
            InitializeComponent();
        }

        #endregion

        #region :: 전역변수 ::

        private bool _enableClear = false;
        private object _fileData = null;
        private string _fileName = string.Empty;
        private bool _checkModify = false;

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

        #region :: FileData :: 파일 데이터를 설정합니다.

        /// <summary>
        /// 파일 데이터를 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("파일 데이터를 설정합니다."), Browsable(false)]
        public object FileData
        {
            get { return _fileData; }
            set
            {
                _fileData = value;
            }
        }

        #endregion

        #region :: FileName :: 파일명을 설정합니다.

        /// <summary>
        /// 파일명을 설정합니다.
        /// </summary>
        [Category(AppConfig.CONTROLCATEGORY)]
        [Description("파일명을 설정합니다."), Browsable(false)]
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Event Delegate
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: FileSave :: 파일 다운로드 시에 사용합니다.

        /// <summary>
        /// 파일 다운로드 시에 사용합니다.
        /// </summary>
        [Category(AppConfig.EVENTCATEGORY)]
        [Description("파일 다운로드 시에 사용합니다."), Browsable(true)]
        public event EventHandler FileSave;

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Method(Private)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OpenFile :: 파일을 찾습니다.

        /// <summary>
        /// 파일을 찾습니다.
        /// </summary>
        private void OpenFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Multiselect = false, InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    EditValue = ofd.FileName;
                    FileData = null;
                }
            }
        }

        #endregion

        #region :: OnFileSave :: FileDownload Event를 강제로 발생시킵니다.

        /// <summary>
        /// FileDownload Event를 강제로 발생시킵니다.
        /// </summary>
        private void OnFileSave()
        {
            if (FileSave != null) { FileSave(this, new EventArgs()); }
        }

        #endregion


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Override(Event, Properties, Method...)
        ///////////////////////////////////////////////////////////////////////////////////////////////

        #region :: OnEditValueChanged :: EditValue가 변경되면 발생합니다.

        /// <summary>
        /// EditValue가 변경되면 발생합니다.
        /// </summary>
        protected override void OnEditValueChanged()
        {
            if (Properties.Buttons.Count < 3) return;

            if (EditValue == null || EditValue.ToString() != string.Empty)
            {
                Properties.Buttons[1].Enabled = true;
                Properties.Buttons[2].Enabled = true;
            }
            else
            {
                Properties.Buttons[1].Enabled = false;
                Properties.Buttons[2].Enabled = false;
            }

            Refresh();
        }

        #endregion

        #region :: OnCreateControl :: PFileEdit가 생성될 때 버튼을 만듭니다.

        /// <summary>
        /// PFileEdit가 생성될 때 버튼을 만듭니다.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            if (Properties.Buttons.Count > 0) Properties.Buttons.Clear();

            EditorButton eb1 = new EditorButton { ToolTip = "파일찾기..." };
            Properties.Buttons.Add(eb1);
            EditorButton eb2 = new EditorButton { Kind = ButtonPredefines.Plus, ToolTip = "파일 다운로드..." };
            Properties.Buttons.Add(eb2);
            EditorButton eb3 = new EditorButton { Kind = ButtonPredefines.Delete, ToolTip = "파일 삭제..." };
            Properties.Buttons.Add(eb3);

            EditValue = string.Empty;
        }

        #endregion

        #region :: OnClickButton :: 버튼을 클릭하면 발생합니다.

        /// <summary>
        /// 버튼을 클릭하면 발생합니다.
        /// </summary>
        /// <param name="buttonInfo"></param>
        protected override void OnClickButton(DevExpress.XtraEditors.Drawing.EditorButtonObjectInfoArgs buttonInfo)
        {
            switch (buttonInfo.Button.Index)
            {
                case 0:
                    OpenFile();
                    break;
                case 1:
                    OnFileSave();
                    break;
                case 2:
                    EditValue = string.Empty;
                    _fileData = null;
                    break;
            }
            base.OnClickButton(buttonInfo);
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
                if (IsModified)
                {
                    (FindForm() as UIFrame).IsModified = true;
                }
            }
        }

        #endregion
    }
}
