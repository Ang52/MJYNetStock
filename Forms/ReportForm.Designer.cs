namespace MJYNetStock.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.DateTimePicker dtpYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblInAmount;
        private System.Windows.Forms.Label lblOutAmount;
        private System.Windows.Forms.Label lblStockAmount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabInStock;
        private System.Windows.Forms.TabPage tabOutStock;
        private System.Windows.Forms.TabPage tabCurrentStock;
        private System.Windows.Forms.DataGridView dgvInStock;
        private System.Windows.Forms.DataGridView dgvOutStock;
        private System.Windows.Forms.DataGridView dgvCurrentStock;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblStockAmount = new System.Windows.Forms.Label();
            this.lblOutAmount = new System.Windows.Forms.Label();
            this.lblInAmount = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInStock = new System.Windows.Forms.TabPage();
            this.dgvInStock = new System.Windows.Forms.DataGridView();
            this.tabOutStock = new System.Windows.Forms.TabPage();
            this.dgvOutStock = new System.Windows.Forms.DataGridView();
            this.tabCurrentStock = new System.Windows.Forms.TabPage();
            this.dgvCurrentStock = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabInStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStock)).BeginInit();
            this.tabOutStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStock)).BeginInit();
            this.tabCurrentStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentStock)).BeginInit();
            this.SuspendLayout();
            
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 50);
            
            var lblYear = new System.Windows.Forms.Label { Text = "年份：", Location = new System.Drawing.Point(20, 16), AutoSize = true };
            var lblMonth = new System.Windows.Forms.Label { Text = "月份：", Location = new System.Drawing.Point(240, 16), AutoSize = true };
            
            this.dtpYear.Location = new System.Drawing.Point(80, 13);
            this.dtpYear.Size = new System.Drawing.Size(150, 23);
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.ShowUpDown = true;
            
            this.cmbMonth.Location = new System.Drawing.Point(300, 13);
            this.cmbMonth.Size = new System.Drawing.Size(100, 23);
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.Items.Add("1月");
            this.cmbMonth.Items.Add("2月");
            this.cmbMonth.Items.Add("3月");
            this.cmbMonth.Items.Add("4月");
            this.cmbMonth.Items.Add("5月");
            this.cmbMonth.Items.Add("6月");
            this.cmbMonth.Items.Add("7月");
            this.cmbMonth.Items.Add("8月");
            this.cmbMonth.Items.Add("9月");
            this.cmbMonth.Items.Add("10月");
            this.cmbMonth.Items.Add("11月");
            this.cmbMonth.Items.Add("12月");
            
            this.btnQuery.Location = new System.Drawing.Point(430, 11);
            this.btnQuery.Size = new System.Drawing.Size(80, 30);
            this.btnQuery.Text = "查询";
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(100, 181, 246);
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Click += btnQuery_Click;
            
            this.btnExport.Location = new System.Drawing.Point(530, 11);
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.Text = "导出报表";
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Click += btnExport_Click;
            
            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblYear, lblMonth, this.dtpYear, this.cmbMonth, this.btnQuery, this.btnExport
            });
            
            // panelSummary
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSummary.Size = new System.Drawing.Size(1000, 80);
            
            var panelIn = new System.Windows.Forms.Panel { 
                BackColor = System.Drawing.Color.FromArgb(76, 175, 80),
                Location = new System.Drawing.Point(50, 10),
                Size = new System.Drawing.Size(250, 100)
            };
            var lblInTitle = new System.Windows.Forms.Label { 
                Text = "月入库总额", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 10F),
                Location = new System.Drawing.Point(10, 10),
                AutoSize = true
            };
            this.lblInAmount = new System.Windows.Forms.Label { 
                Text = "¥0.00", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 35),
                AutoSize = true
            };
            panelIn.Controls.AddRange(new System.Windows.Forms.Control[] { lblInTitle, this.lblInAmount });
            
            var panelOut = new System.Windows.Forms.Panel { 
                BackColor = System.Drawing.Color.FromArgb(255, 152, 0),
                Location = new System.Drawing.Point(350, 10),
                Size = new System.Drawing.Size(250, 100)
            };
            var lblOutTitle = new System.Windows.Forms.Label { 
                Text = "月出库总额", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 10F),
                Location = new System.Drawing.Point(10, 10),
                AutoSize = true
            };
            this.lblOutAmount = new System.Windows.Forms.Label { 
                Text = "¥0.00", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 35),
                AutoSize = true
            };
            panelOut.Controls.AddRange(new System.Windows.Forms.Control[] { lblOutTitle, this.lblOutAmount });
            
            var panelStock = new System.Windows.Forms.Panel { 
                BackColor = System.Drawing.Color.FromArgb(100, 181, 246),
                Location = new System.Drawing.Point(650, 10),
                Size = new System.Drawing.Size(250, 100)
            };
            var lblStockTitle = new System.Windows.Forms.Label { 
                Text = "当前库存总额", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 10F),
                Location = new System.Drawing.Point(10, 10),
                AutoSize = true
            };
            this.lblStockAmount = new System.Windows.Forms.Label { 
                Text = "¥0.00", 
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold),
                Location = new System.Drawing.Point(10, 35),
                AutoSize = true
            };
            panelStock.Controls.AddRange(new System.Windows.Forms.Control[] { lblStockTitle, this.lblStockAmount });
            
            this.panelSummary.Controls.AddRange(new System.Windows.Forms.Control[] { panelIn, panelOut, panelStock });
            
            // tabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            
            // tabInStock
            this.tabInStock.Text = "月入库汇总";
            this.dgvInStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInStock.AllowUserToAddRows = false;
            this.dgvInStock.AllowUserToDeleteRows = false;
            this.dgvInStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvInStock.ReadOnly = true;
            this.dgvInStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabInStock.Controls.Add(this.dgvInStock);
            
            // tabOutStock
            this.tabOutStock.Text = "月出库汇总";
            this.dgvOutStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutStock.AllowUserToAddRows = false;
            this.dgvOutStock.AllowUserToDeleteRows = false;
            this.dgvOutStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvOutStock.ReadOnly = true;
            this.dgvOutStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabOutStock.Controls.Add(this.dgvOutStock);
            
            // tabCurrentStock
            this.tabCurrentStock.Text = "当前库存";
            this.dgvCurrentStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCurrentStock.AllowUserToAddRows = false;
            this.dgvCurrentStock.AllowUserToDeleteRows = false;
            this.dgvCurrentStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCurrentStock.BackgroundColor = System.Drawing.Color.White;
            this.dgvCurrentStock.ReadOnly = true;
            this.dgvCurrentStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tabCurrentStock.Controls.Add(this.dgvCurrentStock);
            
            this.tabControl.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.tabInStock, this.tabOutStock, this.tabCurrentStock
            });
            
            // ReportForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelTop);
            this.Name = "ReportForm";
            this.Text = "报表统计";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabInStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStock)).EndInit();
            this.tabOutStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStock)).EndInit();
            this.tabCurrentStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentStock)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
