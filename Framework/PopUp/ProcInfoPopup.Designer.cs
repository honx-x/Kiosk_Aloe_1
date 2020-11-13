namespace TLF.Framework.PopUp
{
    partial class ProcInfoPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.pButtonEdit1 = new TLF.Framework.ControlLibrary.PButtonEdit();
            this.cmbProcGb_Srch = new TLF.Framework.ControlLibrary.PMultiComboBoxEdit();
            this.grid_Process = new TLF.Framework.ControlLibrary.PGridControl();
            this.view_Process = new TLF.Framework.ControlLibrary.PGridView();
            this.btnSearch = new TLF.Framework.ControlLibrary.PButtonEdit();
            this.txtProcCd_Srch = new TLF.Framework.ControlLibrary.PTextEdit();
            this.txtProcNm_Srch = new TLF.Framework.ControlLibrary.PTextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcGb_Srch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Process)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_Process)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcCd_Srch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcNm_Srch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.pButtonEdit1);
            this.layoutControl1.Controls.Add(this.cmbProcGb_Srch);
            this.layoutControl1.Controls.Add(this.grid_Process);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.txtProcCd_Srch);
            this.layoutControl1.Controls.Add(this.txtProcNm_Srch);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.HighlightFocusedItem = true;
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(898, 668);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // pButtonEdit1
            // 
            this.pButtonEdit1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pButtonEdit1.Appearance.Options.UseFont = true;
            this.pButtonEdit1.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.pButtonEdit1.AppearanceDisabled.Options.UseFont = true;
            this.pButtonEdit1.AppearanceHovered.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.pButtonEdit1.AppearanceHovered.Options.UseFont = true;
            this.pButtonEdit1.AppearancePressed.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.pButtonEdit1.AppearancePressed.Options.UseFont = true;
            this.pButtonEdit1.ButtonType = TLF.Framework.Config.ButtonType.Default;
            this.pButtonEdit1.Location = new System.Drawing.Point(871, 3);
            this.pButtonEdit1.MaximumSize = new System.Drawing.Size(24, 0);
            this.pButtonEdit1.MinimumSize = new System.Drawing.Size(24, 0);
            this.pButtonEdit1.Name = "pButtonEdit1";
            this.pButtonEdit1.Size = new System.Drawing.Size(24, 22);
            this.pButtonEdit1.StyleController = this.layoutControl1;
            this.pButtonEdit1.TabIndex = 17;
            this.pButtonEdit1.Text = "X";
            this.pButtonEdit1.Click += new System.EventHandler(this.pButtonEdit1_Click);
            // 
            // cmbProcGb_Srch
            // 
            this.cmbProcGb_Srch.CheckModify = false;
            this.cmbProcGb_Srch.CodeColumnVisible = false;
            this.cmbProcGb_Srch.EditValue = "";
            this.cmbProcGb_Srch.EnableClear = false;
            this.cmbProcGb_Srch.Location = new System.Drawing.Point(404, 52);
            this.cmbProcGb_Srch.MaximumSize = new System.Drawing.Size(120, 0);
            this.cmbProcGb_Srch.MinimumSize = new System.Drawing.Size(120, 0);
            this.cmbProcGb_Srch.Name = "cmbProcGb_Srch";
            this.cmbProcGb_Srch.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmbProcGb_Srch.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.Appearance.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.AppearanceDisabled.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.AppearanceFocused.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cmbProcGb_Srch.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.cmbProcGb_Srch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProcGb_Srch.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.cmbProcGb_Srch.Properties.NullText = "";
            this.cmbProcGb_Srch.Properties.ShowHeader = false;
            this.cmbProcGb_Srch.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProcGb_Srch.SelectAllItemCaption = "전체선택";
            this.cmbProcGb_Srch.SelectAllItemVisible = false;
            this.cmbProcGb_Srch.ShowFooter = true;
            this.cmbProcGb_Srch.ShowHeader = false;
            this.cmbProcGb_Srch.Size = new System.Drawing.Size(120, 22);
            this.cmbProcGb_Srch.StyleController = this.layoutControl1;
            this.cmbProcGb_Srch.TabIndex = 16;
            this.cmbProcGb_Srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._SearchKeyDown);
            // 
            // grid_Process
            // 
            this.grid_Process.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grid_Process.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.grid_Process.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid_Process.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid_Process.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid_Process.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid_Process.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid_Process.EnableClear = false;
            this.grid_Process.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.grid_Process.Location = new System.Drawing.Point(2, 100);
            this.grid_Process.MainView = this.view_Process;
            this.grid_Process.Name = "grid_Process";
            this.grid_Process.Size = new System.Drawing.Size(894, 566);
            this.grid_Process.TabIndex = 15;
            this.grid_Process.UseEmbeddedNavigator = true;
            this.grid_Process.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view_Process});
            // 
            // view_Process
            // 
            this.view_Process.AllowEdit = true;
            this.view_Process.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.view_Process.Appearance.DetailTip.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.DetailTip.Options.UseFont = true;
            this.view_Process.Appearance.EvenRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.EvenRow.Options.UseFont = true;
            this.view_Process.Appearance.FilterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.FilterPanel.Options.UseFont = true;
            this.view_Process.Appearance.FocusedCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.FocusedCell.Options.UseFont = true;
            this.view_Process.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(230)))));
            this.view_Process.Appearance.FocusedRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.FocusedRow.Options.UseBackColor = true;
            this.view_Process.Appearance.FocusedRow.Options.UseFont = true;
            this.view_Process.Appearance.FooterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.FooterPanel.Options.UseFont = true;
            this.view_Process.Appearance.GroupFooter.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.GroupFooter.Options.UseFont = true;
            this.view_Process.Appearance.GroupPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.GroupPanel.Options.UseFont = true;
            this.view_Process.Appearance.GroupRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.GroupRow.Options.UseFont = true;
            this.view_Process.Appearance.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.HeaderPanel.Options.UseFont = true;
            this.view_Process.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.view_Process.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view_Process.Appearance.HideSelectionRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.HideSelectionRow.Options.UseFont = true;
            this.view_Process.Appearance.HotTrackedRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.HotTrackedRow.Options.UseFont = true;
            this.view_Process.Appearance.OddRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.OddRow.Options.UseFont = true;
            this.view_Process.Appearance.Preview.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.Preview.Options.UseFont = true;
            this.view_Process.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.Row.Options.UseFont = true;
            this.view_Process.Appearance.SelectedRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.SelectedRow.Options.UseFont = true;
            this.view_Process.Appearance.TopNewRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.TopNewRow.Options.UseFont = true;
            this.view_Process.Appearance.ViewCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.Appearance.ViewCaption.Options.UseFont = true;
            this.view_Process.AppearancePrint.EvenRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.EvenRow.Options.UseFont = true;
            this.view_Process.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.FilterPanel.Options.UseFont = true;
            this.view_Process.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.view_Process.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.GroupFooter.Options.UseFont = true;
            this.view_Process.AppearancePrint.GroupRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.GroupRow.Options.UseFont = true;
            this.view_Process.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.view_Process.AppearancePrint.Lines.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.Lines.Options.UseFont = true;
            this.view_Process.AppearancePrint.OddRow.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.OddRow.Options.UseFont = true;
            this.view_Process.AppearancePrint.Preview.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.Preview.Options.UseFont = true;
            this.view_Process.AppearancePrint.Row.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.view_Process.AppearancePrint.Row.Options.UseFont = true;
            this.view_Process.CheckDataSource = false;
            this.view_Process.ColumnAutoWidth = false;
            this.view_Process.ColumnHeaderAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.view_Process.ColumnHeight = 25;
            this.view_Process.ColumnPanelRowHeight = 25;
            this.view_Process.EnableSaveLayout = false;
            this.view_Process.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.view_Process.GridControl = this.grid_Process;
            this.view_Process.IsCheck = false;
            this.view_Process.KeyColumns = null;
            this.view_Process.MandatoryColumns = null;
            this.view_Process.Name = "view_Process";
            this.view_Process.NewItemPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
            this.view_Process.NewRowEnableColumns = null;
            this.view_Process.OptionsView.ColumnAutoWidth = false;
            this.view_Process.OptionsView.ShowGroupPanel = false;
            this.view_Process.ShowGroupPanel = false;
            this.view_Process.KeyDown += new System.Windows.Forms.KeyEventHandler(this._viewKeyDown);
            this.view_Process.DoubleClick += new System.EventHandler(this._viewDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSearch.AppearanceDisabled.Options.UseFont = true;
            this.btnSearch.AppearanceHovered.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSearch.AppearanceHovered.Options.UseFont = true;
            this.btnSearch.AppearancePressed.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSearch.AppearancePressed.Options.UseFont = true;
            this.btnSearch.ButtonType = TLF.Framework.Config.ButtonType.Default;
            this.btnSearch.Location = new System.Drawing.Point(854, 51);
            this.btnSearch.MaximumSize = new System.Drawing.Size(40, 0);
            this.btnSearch.MinimumSize = new System.Drawing.Size(40, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "조회";
            this.btnSearch.Click += new System.EventHandler(this._btnSearchClick);
            // 
            // txtProcCd_Srch
            // 
            this.txtProcCd_Srch.CheckModify = false;
            this.txtProcCd_Srch.EditValue = "";
            this.txtProcCd_Srch.EnableClear = false;
            this.txtProcCd_Srch.EnterKeySelectEvent = false;
            this.txtProcCd_Srch.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtProcCd_Srch.Location = new System.Drawing.Point(58, 52);
            this.txtProcCd_Srch.MaximumSize = new System.Drawing.Size(120, 0);
            this.txtProcCd_Srch.MinimumSize = new System.Drawing.Size(120, 0);
            this.txtProcCd_Srch.Name = "txtProcCd_Srch";
            this.txtProcCd_Srch.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcCd_Srch.Properties.Appearance.Options.UseFont = true;
            this.txtProcCd_Srch.Properties.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcCd_Srch.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtProcCd_Srch.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcCd_Srch.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtProcCd_Srch.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcCd_Srch.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtProcCd_Srch.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtProcCd_Srch.Size = new System.Drawing.Size(120, 22);
            this.txtProcCd_Srch.StyleController = this.layoutControl1;
            this.txtProcCd_Srch.TabIndex = 13;
            this.txtProcCd_Srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._SearchKeyDown);
            // 
            // txtProcNm_Srch
            // 
            this.txtProcNm_Srch.CheckModify = false;
            this.txtProcNm_Srch.EditValue = "";
            this.txtProcNm_Srch.EnableClear = false;
            this.txtProcNm_Srch.EnterKeySelectEvent = false;
            this.txtProcNm_Srch.Location = new System.Drawing.Point(225, 52);
            this.txtProcNm_Srch.MaximumSize = new System.Drawing.Size(120, 0);
            this.txtProcNm_Srch.MinimumSize = new System.Drawing.Size(120, 0);
            this.txtProcNm_Srch.Name = "txtProcNm_Srch";
            this.txtProcNm_Srch.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcNm_Srch.Properties.Appearance.Options.UseFont = true;
            this.txtProcNm_Srch.Properties.AppearanceDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcNm_Srch.Properties.AppearanceDisabled.Options.UseFont = true;
            this.txtProcNm_Srch.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcNm_Srch.Properties.AppearanceFocused.Options.UseFont = true;
            this.txtProcNm_Srch.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.txtProcNm_Srch.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.txtProcNm_Srch.Properties.MaxLength = 12;
            this.txtProcNm_Srch.Size = new System.Drawing.Size(120, 22);
            this.txtProcNm_Srch.StyleController = this.layoutControl1;
            this.txtProcNm_Srch.TabIndex = 9;
            this.txtProcNm_Srch.KeyDown += new System.Windows.Forms.KeyEventHandler(this._SearchKeyDown);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.Root.Name = "Root";
            this.Root.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.Root.Size = new System.Drawing.Size(898, 668);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup4,
            this.layoutControlGroup5,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(898, 668);
            this.layoutControlGroup2.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.layoutControlGroup4.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.Header.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceTabPage.Header.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.layoutControlGroup4.AppearanceTabPage.PageClient.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.AppearanceTabPage.PageClient.Options.UseFont = true;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 26);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControlGroup4.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlGroup4.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlGroup4.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup4.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup4.Size = new System.Drawing.Size(896, 51);
            this.layoutControlGroup4.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup4.Text = "조회조건";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem6.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem6.Control = this.txtProcNm_Srch;
            this.layoutControlItem6.Location = new System.Drawing.Point(179, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem6.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem6.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem6.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem6.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem6.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem6.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem6.Size = new System.Drawing.Size(167, 28);
            this.layoutControlItem6.Text = "공정명";
            this.layoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(36, 15);
            this.layoutControlItem6.TextToControlDistance = 5;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(525, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(325, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlItem1.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem1.Control = this.txtProcCd_Srch;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem1.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem1.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem1.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem1.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Size = new System.Drawing.Size(179, 28);
            this.layoutControlItem1.Text = "공정코드";
            this.layoutControlItem1.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 15);
            this.layoutControlItem1.TextToControlDistance = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnSearch;
            this.layoutControlItem2.Location = new System.Drawing.Point(850, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(44, 28);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.cmbProcGb_Srch;
            this.layoutControlItem4.Location = new System.Drawing.Point(346, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem4.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlItem4.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem4.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlItem4.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlItem4.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem4.Size = new System.Drawing.Size(179, 28);
            this.layoutControlItem4.Text = "공정구분";
            this.layoutControlItem4.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.AutoSize;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(48, 15);
            this.layoutControlItem4.TextToControlDistance = 5;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.AppearanceGroup.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.layoutControlGroup5.AppearanceGroup.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.layoutControlGroup5.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceTabPage.Header.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.AppearanceTabPage.Header.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceTabPage.HeaderActive.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.AppearanceTabPage.HeaderActive.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceTabPage.HeaderDisabled.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.AppearanceTabPage.HeaderDisabled.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceTabPage.HeaderHotTracked.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.AppearanceTabPage.HeaderHotTracked.Options.UseFont = true;
            this.layoutControlGroup5.AppearanceTabPage.PageClient.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.AppearanceTabPage.PageClient.Options.UseFont = true;
            this.layoutControlGroup5.ExpandButtonVisible = true;
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 77);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.OptionsPrint.AppearanceGroupCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.OptionsPrint.AppearanceGroupCaption.Options.UseFont = true;
            this.layoutControlGroup5.OptionsPrint.AppearanceItem.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.OptionsPrint.AppearanceItem.Options.UseFont = true;
            this.layoutControlGroup5.OptionsPrint.AppearanceItemControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.OptionsPrint.AppearanceItemControl.Options.UseFont = true;
            this.layoutControlGroup5.OptionsPrint.AppearanceItemText.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.layoutControlGroup5.OptionsPrint.AppearanceItemText.Options.UseFont = true;
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup5.Size = new System.Drawing.Size(896, 589);
            this.layoutControlGroup5.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup5.Text = "조회목록";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grid_Process;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlItem3.Size = new System.Drawing.Size(894, 566);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.pButtonEdit1;
            this.layoutControlItem5.Location = new System.Drawing.Point(868, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(28, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.AppearanceItemCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptySpaceItem2.AppearanceItemCaption.Options.UseFont = true;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(868, 26);
            this.emptySpaceItem2.Text = "공정 팝업";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            this.emptySpaceItem2.TextVisible = true;
            // 
            // ProcInfoPopup
            // 
            this.Appearance.Options.UseFont = true;
            this.ClientSize = new System.Drawing.Size(898, 668);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProcInfoPopup";
            this.Text = "검색";
            this.Delete += new System.EventHandler(this._Delete);
            this.New += new System.EventHandler(this._New);
            this.Save += new System.EventHandler(this._Save);
            this.Selection += new System.EventHandler(this._Selection);
            this.Load += new System.EventHandler(this._Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProcGb_Srch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Process)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view_Process)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcCd_Srch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcNm_Srch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private Framework.ControlLibrary.PTextEdit txtProcNm_Srch;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private Framework.ControlLibrary.PButtonEdit btnSearch;
        private Framework.ControlLibrary.PTextEdit txtProcCd_Srch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private Framework.ControlLibrary.PGridControl grid_Process;
        private Framework.ControlLibrary.PGridView view_Process;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private Framework.ControlLibrary.PMultiComboBoxEdit cmbProcGb_Srch;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private ControlLibrary.PButtonEdit pButtonEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}