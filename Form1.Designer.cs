
namespace Replication
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Dgv_Table = new System.Windows.Forms.DataGridView();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TbName = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.Btn_Publication = new System.Windows.Forms.Button();
            this.LbTips = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Table)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Dgv_Table);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 408);
            this.panel1.TabIndex = 0;
            // 
            // Dgv_Table
            // 
            this.Dgv_Table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_Table.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected});
            this.Dgv_Table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Dgv_Table.Location = new System.Drawing.Point(0, 0);
            this.Dgv_Table.Name = "Dgv_Table";
            this.Dgv_Table.RowHeadersWidth = 51;
            this.Dgv_Table.RowTemplate.Height = 27;
            this.Dgv_Table.Size = new System.Drawing.Size(1009, 408);
            this.Dgv_Table.TabIndex = 0;
            // 
            // selected
            // 
            this.selected.HeaderText = "选择";
            this.selected.MinimumWidth = 6;
            this.selected.Name = "selected";
            this.selected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selected.Width = 125;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LbTips);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TbName);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.Btn_Publication);
            this.panel2.Location = new System.Drawing.Point(12, 426);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1009, 130);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(432, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "发布名称：";
            // 
            // TbName
            // 
            this.TbName.Location = new System.Drawing.Point(534, 56);
            this.TbName.Name = "TbName";
            this.TbName.Size = new System.Drawing.Size(135, 25);
            this.TbName.TabIndex = 2;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(282, 82);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 19);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Text = "选中不同步";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(282, 57);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(88, 19);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "选中同步";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(282, 32);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(88, 19);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全部同步";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Btn_Publication
            // 
            this.Btn_Publication.Location = new System.Drawing.Point(66, 41);
            this.Btn_Publication.Name = "Btn_Publication";
            this.Btn_Publication.Size = new System.Drawing.Size(113, 50);
            this.Btn_Publication.TabIndex = 0;
            this.Btn_Publication.Text = "一键发布订阅";
            this.Btn_Publication.UseVisualStyleBackColor = true;
            this.Btn_Publication.Click += new System.EventHandler(this.Btn_Publication_Click);
            // 
            // LbTips
            // 
            this.LbTips.AutoSize = true;
            this.LbTips.Font = new System.Drawing.Font("楷体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LbTips.Location = new System.Drawing.Point(712, 57);
            this.LbTips.Name = "LbTips";
            this.LbTips.Size = new System.Drawing.Size(110, 24);
            this.LbTips.TabIndex = 4;
            this.LbTips.Text = "等待发布";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "数据库订阅发布";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Table)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView Dgv_Table;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Btn_Publication;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.Label LbTips;
    }
}

