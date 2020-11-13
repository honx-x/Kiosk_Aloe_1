namespace TLF.Framework.ControlLibrary
{
	partial class PChkSpn
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
			this.SpnFrom = new TLF.Framework.ControlLibrary.PSpinEdit();
			this.panel3 = new System.Windows.Forms.Panel();
			this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
			this.panel4 = new System.Windows.Forms.Panel();
			this.SpnTo = new TLF.Framework.ControlLibrary.PSpinEdit();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).BeginInit();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpnFrom.Properties)).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SpnTo.Properties)).BeginInit();
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
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1156, 23);
			this.tableLayoutPanel1.TabIndex = 5;
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
			this.panel2.Controls.Add(this.SpnFrom);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(90, 0);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(528, 23);
			this.panel2.TabIndex = 1;
			// 
			// SpnFrom
			// 
			this.SpnFrom.CheckModify = false;
			this.SpnFrom.DecimalPlace = 0;
			this.SpnFrom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SpnFrom.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.SpnFrom.EnableClear = false;
			this.SpnFrom.Location = new System.Drawing.Point(0, 0);
			this.SpnFrom.Name = "SpnFrom";
			this.SpnFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.SpnFrom.Properties.Mask.EditMask = "n0";
			this.SpnFrom.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.SpnFrom.Size = new System.Drawing.Size(528, 20);
			this.SpnFrom.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.labelControl1);
			this.panel3.Location = new System.Drawing.Point(618, 0);
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
			this.panel4.Controls.Add(this.SpnTo);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(628, 0);
			this.panel4.Margin = new System.Windows.Forms.Padding(0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(528, 23);
			this.panel4.TabIndex = 3;
			// 
			// SpnTo
			// 
			this.SpnTo.CheckModify = false;
			this.SpnTo.DecimalPlace = 0;
			this.SpnTo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SpnTo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
			this.SpnTo.EnableClear = false;
			this.SpnTo.Location = new System.Drawing.Point(0, 0);
			this.SpnTo.Name = "SpnTo";
			this.SpnTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
			this.SpnTo.Properties.Mask.EditMask = "n0";
			this.SpnTo.Properties.Mask.UseMaskAsDisplayFormat = true;
			this.SpnTo.Size = new System.Drawing.Size(528, 20);
			this.SpnTo.TabIndex = 1;
			// 
			// PChkSpn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "PChkSpn";
			this.Size = new System.Drawing.Size(1156, 23);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.chk.Properties)).EndInit();
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SpnFrom.Properties)).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SpnTo.Properties)).EndInit();
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
		private PSpinEdit SpnFrom;
		private PSpinEdit SpnTo;
	}
}
