namespace MJYNetStock.Forms
{
    partial class StockQueryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtMaterialCode;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvStocks;

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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.txtMaterialCode = new System.Windows.Forms.TextBox();
            this.dgvStocks = new System.Windows.Forms.DataGridView();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocks)).BeginInit();
            this.SuspendLayout();
            
            // panelSearch
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Size = new System.Drawing.Size(1000, 60);
            
            var lblMaterialCode = new System.Windows.Forms.Label { Text = "物资编号：", Location = new System.Drawing.Point(20, 18), AutoSize = true };
            var lblMaterialName = new System.Windows.Forms.Label { Text = "物资名称：", Location = new System.Drawing.Point(240, 18), AutoSize = true };
            var lblWarehouse = new System.Windows.Forms.Label { Text = "仓库：", Location = new System.Drawing.Point(460, 18), AutoSize = true };
            
            this.txtMaterialCode.Location = new System.Drawing.Point(100, 15);
            this.txtMaterialCode.Size = new System.Drawing.Size(120, 23);
            
            this.txtMaterialName.Location = new System.Drawing.Point(320, 15);
            this.txtMaterialName.Size = new System.Drawing.Size(120, 23);
            
            this.cmbWarehouse.Location = new System.Drawing.Point(510, 15);
            this.cmbWarehouse.Size = new System.Drawing.Size(120, 23);
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            this.btnSearch.Location = new System.Drawing.Point(650, 13);
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.Text = "查询";
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(100, 181, 246);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += btnSearch_Click;
            
            this.btnRefresh.Location = new System.Drawing.Point(750, 13);
            this.btnRefresh.Size = new System.Drawing.Size(80, 30);
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Click += btnRefresh_Click;
            
            this.btnExport.Location = new System.Drawing.Point(850, 13);
            this.btnExport.Size = new System.Drawing.Size(80, 30);
            this.btnExport.Text = "导出";
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Click += btnExport_Click;
            
            this.panelSearch.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblMaterialCode, lblMaterialName, lblWarehouse,
                this.txtMaterialCode, this.txtMaterialName, this.cmbWarehouse,
                this.btnSearch, this.btnRefresh, this.btnExport
            });
            
            // dgvStocks
            this.dgvStocks.AllowUserToAddRows = false;
            this.dgvStocks.AllowUserToDeleteRows = false;
            this.dgvStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStocks.BackgroundColor = System.Drawing.Color.White;
            this.dgvStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStocks.ReadOnly = true;
            this.dgvStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            
            // StockQueryForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvStocks);
            this.Controls.Add(this.panelSearch);
            this.Name = "StockQueryForm";
            this.Text = "库存查询";
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
