namespace MJYNetStock.Forms
{
    partial class OutStockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtReceiver;
        private System.Windows.Forms.DateTimePicker dtpOutTime;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.TextBox txtSearchMaterial;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox chkStartDate;
        private System.Windows.Forms.CheckBox chkEndDate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvOutStocks;

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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.dtpOutTime = new System.Windows.Forms.DateTimePicker();
            this.txtReceiver = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkEndDate = new System.Windows.Forms.CheckBox();
            this.chkStartDate = new System.Windows.Forms.CheckBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearchMaterial = new System.Windows.Forms.TextBox();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.dgvOutStocks = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStocks)).BeginInit();
            this.SuspendLayout();
            
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 140);
            
            var lblCode = new System.Windows.Forms.Label { Text = "出库单号：", Location = new System.Drawing.Point(20, 18), AutoSize = true };
            var lblMaterial = new System.Windows.Forms.Label { Text = "物料：", Location = new System.Drawing.Point(20, 58), AutoSize = true };
            var lblWarehouse = new System.Windows.Forms.Label { Text = "仓库：", Location = new System.Drawing.Point(280, 18), AutoSize = true };
            var lblQuantity = new System.Windows.Forms.Label { Text = "数量：", Location = new System.Drawing.Point(280, 58), AutoSize = true };
            var lblPrice = new System.Windows.Forms.Label { Text = "单价：", Location = new System.Drawing.Point(440, 18), AutoSize = true };
            var lblAmount = new System.Windows.Forms.Label { Text = "金额：", Location = new System.Drawing.Point(440, 58), AutoSize = true };
            var lblReceiver = new System.Windows.Forms.Label { Text = "领用人：", Location = new System.Drawing.Point(20, 98), AutoSize = true };
            var lblOutTime = new System.Windows.Forms.Label { Text = "出库时间：", Location = new System.Drawing.Point(280, 98), AutoSize = true };
            var lblOperator = new System.Windows.Forms.Label { Text = "操作员：", Location = new System.Drawing.Point(540, 98), AutoSize = true };
            var lblRemark = new System.Windows.Forms.Label { Text = "备注：", Location = new System.Drawing.Point(600, 18), AutoSize = true };
            
            this.txtCode.Location = new System.Drawing.Point(100, 15);
            this.txtCode.Size = new System.Drawing.Size(150, 23);
            this.txtCode.ReadOnly = true;
            
            this.cmbMaterial.Location = new System.Drawing.Point(100, 55);
            this.cmbMaterial.Size = new System.Drawing.Size(150, 23);
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            this.cmbWarehouse.Location = new System.Drawing.Point(340, 15);
            this.cmbWarehouse.Size = new System.Drawing.Size(80, 23);
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            this.txtQuantity.Location = new System.Drawing.Point(340, 55);
            this.txtQuantity.Size = new System.Drawing.Size(80, 23);
            this.txtQuantity.TextChanged += txtQuantity_TextChanged;
            
            this.txtPrice.Location = new System.Drawing.Point(500, 15);
            this.txtPrice.Size = new System.Drawing.Size(80, 23);
            this.txtPrice.TextChanged += txtPrice_TextChanged;
            
            this.txtAmount.Location = new System.Drawing.Point(500, 55);
            this.txtAmount.Size = new System.Drawing.Size(80, 23);
            this.txtAmount.ReadOnly = true;
            
            this.txtReceiver.Location = new System.Drawing.Point(100, 95);
            this.txtReceiver.Size = new System.Drawing.Size(150, 23);
            
            this.dtpOutTime.Location = new System.Drawing.Point(360, 95);
            this.dtpOutTime.Size = new System.Drawing.Size(150, 23);
            this.dtpOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            this.txtOperator.Location = new System.Drawing.Point(600, 95);
            this.txtOperator.Size = new System.Drawing.Size(100, 23);
            this.txtOperator.ReadOnly = true;
            
            this.txtRemark.Location = new System.Drawing.Point(660, 15);
            this.txtRemark.Size = new System.Drawing.Size(150, 60);
            this.txtRemark.Multiline = true;
            
            this.btnAdd.Location = new System.Drawing.Point(850, 15);
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.Text = "出库";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += btnAdd_Click;
            
            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblCode, lblMaterial, lblWarehouse, lblQuantity, lblPrice, lblAmount, 
                lblReceiver, lblOutTime, lblOperator, lblRemark,
                this.txtCode, this.cmbMaterial, this.cmbWarehouse, this.txtQuantity, 
                this.txtPrice, this.txtAmount, this.txtReceiver, this.dtpOutTime, 
                this.txtOperator, this.txtRemark, this.btnAdd
            });
            
            // panelSearch
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Size = new System.Drawing.Size(1000, 50);
            
            var lblSearchCode = new System.Windows.Forms.Label { Text = "单号：", Location = new System.Drawing.Point(20, 16), AutoSize = true };
            var lblSearchMaterial = new System.Windows.Forms.Label { Text = "物料：", Location = new System.Drawing.Point(200, 16), AutoSize = true };
            
            this.txtSearchCode.Location = new System.Drawing.Point(70, 13);
            this.txtSearchCode.Size = new System.Drawing.Size(100, 23);
            
            this.txtSearchMaterial.Location = new System.Drawing.Point(250, 13);
            this.txtSearchMaterial.Size = new System.Drawing.Size(100, 23);
            
            this.chkStartDate.Location = new System.Drawing.Point(370, 15);
            this.chkStartDate.Text = "开始：";
            this.chkStartDate.AutoSize = true;
            
            this.dtpStartDate.Location = new System.Drawing.Point(430, 13);
            this.dtpStartDate.Size = new System.Drawing.Size(120, 23);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            this.chkEndDate.Location = new System.Drawing.Point(570, 15);
            this.chkEndDate.Text = "结束：";
            this.chkEndDate.AutoSize = true;
            
            this.dtpEndDate.Location = new System.Drawing.Point(630, 13);
            this.dtpEndDate.Size = new System.Drawing.Size(120, 23);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            
            this.btnSearch.Location = new System.Drawing.Point(770, 10);
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.Text = "查询";
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(100, 181, 246);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Click += btnSearch_Click;
            
            this.panelSearch.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblSearchCode, lblSearchMaterial, this.txtSearchCode, this.txtSearchMaterial,
                this.chkStartDate, this.dtpStartDate, this.chkEndDate, this.dtpEndDate, this.btnSearch
            });
            
            // dgvOutStocks
            this.dgvOutStocks.AllowUserToAddRows = false;
            this.dgvOutStocks.AllowUserToDeleteRows = false;
            this.dgvOutStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutStocks.BackgroundColor = System.Drawing.Color.White;
            this.dgvOutStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutStocks.ReadOnly = true;
            this.dgvOutStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            
            // OutStockForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvOutStocks);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Name = "OutStockForm";
            this.Text = "出库管理";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutStocks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
