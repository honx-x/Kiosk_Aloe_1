namespace TLF.Framework.ControlLibrary
{
	partial class PChkDate
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk = new DevExpress.XtraEditors.CheckEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DateFrom = new TLF.Framework.ControlLibrary.PDateEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DateTo = new TLF.Framework.ControlLibrary.PDateEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1279, 23);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 22);
            this.panel1.TabIndex = 0;
            // 
            // chk
            // 
            this.chk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chk.Location = new System.Drawing.Point(0, 0);
            this.chk.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.chk.Name = "chk";
            this.chk.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.chk.Properties.Caption = "Label";
            this.chk.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chk.Size = new System.Drawing.Size(88, 23);
            this.chk.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DateFrom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(90, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 23);
            this.panel2.TabIndex = 1;
            // 
            // DateFrom
            // 
            this.DateFrom.CheckModify = false;
            this.DateFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateFrom.EditValue = null;
            this.DateFrom.EnableClear = false;
            this.DateFrom.Location = new System.Drawing.Point(0, 0);
            this.DateFrom.Margin = new System.Windows.Forms.Padding(0);
            this.DateFrom.Name = "DateFrom";
            this.DateFrom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateFrom.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.DateFrom.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.DateFrom.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateFrom.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.DateFrom.Size = new System.Drawing.Size(589, 20);
            this.DateFrom.TabIndex = 0;
            this.DateFrom.ToDateControl = null;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelControl1);
            this.panel3.Location = new System.Drawing.Point(679, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 20);
            this.panel3.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(9, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "~";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.DateTo);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(689, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(590, 23);
            this.panel4.TabIndex = 3;
            // 
            // DateTo
            // 
            this.DateTo.CheckModify = false;
            this.DateTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTo.EditValue = null;
            this.DateTo.EnableClear = false;
            this.DateTo.Location = new System.Drawing.Point(0, 0);
            this.DateTo.Margin = new System.Windows.Forms.Padding(0);
            this.DateTo.Name = "DateTo";
            this.DateTo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DateTo.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.DateTo.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.DateTo.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.DateTo.Properties.WeekNumberRule = DevExpress.XtraEditors.Controls.WeekNumberRule.FirstFullWeek;
            this.DateTo.Size = new System.Drawing.Size(590, 20);
            this.DateTo.TabIndex = 1;
            this.DateTo.ToDateControl = null;
            // 
            // PChkDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PChkDate";
            this.Size = new System.Drawing.Size(1279, 23);
            this.Load += new System.EventHandler(this.PChkDate_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateFrom.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DateTo.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private DevExpress.XtraEditors.CheckEdit chk;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private System.Windows.Forms.Panel panel4;
		private PDateEdit DateFrom;
		private PDateEdit DateTo;
	}
}
