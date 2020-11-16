namespace Kiosk_ex1
{
    partial class Kiosk_WorkOrder_Status
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
            System.Windows.Forms.Label label3;
            this.panel_main = new System.Windows.Forms.Panel();
            this.layout_menu1_1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gridView_CL = new System.Windows.Forms.DataGridView();
            this.gridView_OL = new System.Windows.Forms.DataGridView();
            label3 = new System.Windows.Forms.Label();
            this.panel_main.SuspendLayout();
            this.layout_menu1_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OL)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(71)))), ((int)(((byte)(87)))));
            label3.Dock = System.Windows.Forms.DockStyle.Top;
            label3.Font = new System.Drawing.Font("나눔스퀘어_ac Bold", 40F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.White;
            label3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(1129, 150);
            label3.TabIndex = 5;
            label3.Text = "작업현황";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.White;
            this.panel_main.Controls.Add(this.layout_menu1_1);
            this.panel_main.Controls.Add(label3);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(1129, 945);
            this.panel_main.TabIndex = 1;
            // 
            // layout_menu1_1
            // 
            this.layout_menu1_1.ColumnCount = 1;
            this.layout_menu1_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout_menu1_1.Controls.Add(this.label1, 0, 0);
            this.layout_menu1_1.Controls.Add(this.label2, 0, 2);
            this.layout_menu1_1.Controls.Add(this.gridView_CL, 0, 3);
            this.layout_menu1_1.Controls.Add(this.gridView_OL, 0, 1);
            this.layout_menu1_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layout_menu1_1.Location = new System.Drawing.Point(0, 150);
            this.layout_menu1_1.Name = "layout_menu1_1";
            this.layout_menu1_1.RowCount = 4;
            this.layout_menu1_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layout_menu1_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_menu1_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.layout_menu1_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layout_menu1_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.layout_menu1_1.Size = new System.Drawing.Size(1129, 795);
            this.layout_menu1_1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.label1.Size = new System.Drawing.Size(452, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "- 작업지시리스트 (Work Order List)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 20F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 397);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(15, 5, 5, 5);
            this.label2.Size = new System.Drawing.Size(422, 50);
            this.label2.TabIndex = 3;
            this.label2.Text = "- 작업완료내역 (Work Close List)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridView_CL
            // 
            this.gridView_CL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridView_CL.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridView_CL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_CL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView_CL.Location = new System.Drawing.Point(3, 450);
            this.gridView_CL.Name = "gridView_CL";
            this.gridView_CL.RowTemplate.Height = 23;
            this.gridView_CL.Size = new System.Drawing.Size(1123, 342);
            this.gridView_CL.TabIndex = 4;
            // 
            // gridView_OL
            // 
            this.gridView_OL.AllowUserToAddRows = false;
            this.gridView_OL.AllowUserToDeleteRows = false;
            this.gridView_OL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridView_OL.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.gridView_OL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_OL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView_OL.Location = new System.Drawing.Point(3, 53);
            this.gridView_OL.MultiSelect = false;
            this.gridView_OL.Name = "gridView_OL";
            this.gridView_OL.ReadOnly = true;
            this.gridView_OL.RowTemplate.Height = 23;
            this.gridView_OL.Size = new System.Drawing.Size(1123, 341);
            this.gridView_OL.TabIndex = 5;
            // 
            // Kiosk_WorkOrder_Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 945);
            this.Controls.Add(this.panel_main);
            this.Name = "Kiosk_WorkOrder_Status";
            this.Text = "Form1";
            this.panel_main.ResumeLayout(false);
            this.layout_menu1_1.ResumeLayout(false);
            this.layout_menu1_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_OL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.TableLayoutPanel layout_menu1_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView gridView_CL;
        private System.Windows.Forms.DataGridView gridView_OL;
    }
}