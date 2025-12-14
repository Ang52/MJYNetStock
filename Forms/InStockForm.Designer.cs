namespace MJYNetStock.Forms
{
    partial class InStockForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.dgvInStocks = new System.Windows.Forms.DataGridView();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.dtpInTime = new System.Windows.Forms.DateTimePicker();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.txtSearchMaterial = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.chkStartDate = new System.Windows.Forms.CheckBox();
            this.chkEndDate = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStocks)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 140);
            this.panelTop.TabIndex = 0;
            // 
            // panelSearch
            // 
            this.panelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 140);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(1000, 50);
            this.panelSearch.TabIndex = 1;
            // 
            // dgvInStocks
            // 
            this.dgvInStocks.AllowUserToAddRows = false;
            this.dgvInStocks.AllowUserToDeleteRows = false;
            this.dgvInStocks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInStocks.BackgroundColor = System.Drawing.Color.White;
            this.dgvInStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInStocks.Location = new System.Drawing.Point(0, 190);
            this.dgvInStocks.Name = "dgvInStocks";
            this.dgvInStocks.ReadOnly = true;
            this.dgvInStocks.RowTemplate.Height = 25;
            this.dgvInStocks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInStocks.Size = new System.Drawing.Size(1000, 410);
            this.dgvInStocks.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(100, 15);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(150, 23);
            this.txtCode.TabIndex = 0;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(100, 55);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(150, 25);
            this.cmbMaterial.TabIndex = 1;
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(340, 15);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(80, 25);
            this.cmbWarehouse.TabIndex = 2;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(340, 55);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(80, 23);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.TextChanged += new System.EventHandler(this.txtQuantity_TextChanged);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(500, 15);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(80, 23);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(500, 55);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(80, 23);
            this.txtAmount.TabIndex = 5;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(100, 95);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(150, 23);
            this.txtSupplier.TabIndex = 6;
            // 
            // dtpInTime
            // 
            this.dtpInTime.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInTime.Location = new System.Drawing.Point(360, 95);
            this.dtpInTime.Name = "dtpInTime";
            this.dtpInTime.Size = new System.Drawing.Size(150, 23);
            this.dtpInTime.TabIndex = 7;
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(600, 95);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.ReadOnly = true;
            this.txtOperator.Size = new System.Drawing.Size(100, 23);
            this.txtOperator.TabIndex = 8;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(660, 15);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 60);
            this.txtRemark.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(850, 15);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "入库";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Location = new System.Drawing.Point(70, 13);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(100, 23);
            this.txtSearchCode.TabIndex = 0;
            // 
            // txtSearchMaterial
            // 
            this.txtSearchMaterial.Location = new System.Drawing.Point(250, 13);
            this.txtSearchMaterial.Name = "txtSearchMaterial";
            this.txtSearchMaterial.Size = new System.Drawing.Size(100, 23);
            this.txtSearchMaterial.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(430, 13);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(120, 23);
            this.dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(630, 13);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(120, 23);
            this.dtpEndDate.TabIndex = 5;
            // 
            // chkStartDate
            // 
            this.chkStartDate.AutoSize = true;
            this.chkStartDate.Location = new System.Drawing.Point(370, 15);
            this.chkStartDate.Name = "chkStartDate";
            this.chkStartDate.Size = new System.Drawing.Size(63, 21);
            this.chkStartDate.TabIndex = 2;
            this.chkStartDate.Text = "开始：";
            this.chkStartDate.UseVisualStyleBackColor = true;
            // 
            // chkEndDate
            // 
            this.chkEndDate.AutoSize = true;
            this.chkEndDate.Location = new System.Drawing.Point(570, 15);
            this.chkEndDate.Name = "chkEndDate";
            this.chkEndDate.Size = new System.Drawing.Size(63, 21);
            this.chkEndDate.TabIndex = 4;
            this.chkEndDate.Text = "结束：";
            this.chkEndDate.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(181)))), ((int)(((byte)(246)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(770, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            
            // Labels for panelTop
            var lblCode = new System.Windows.Forms.Label();
            lblCode.AutoSize = true;
            lblCode.Location = new System.Drawing.Point(20, 18);
            lblCode.Name = "lblCode";
            lblCode.Size = new System.Drawing.Size(68, 17);
            lblCode.TabIndex = 11;
            lblCode.Text = "入库单号：";
            
            var lblMaterial = new System.Windows.Forms.Label();
            lblMaterial.AutoSize = true;
            lblMaterial.Location = new System.Drawing.Point(20, 58);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new System.Drawing.Size(44, 17);
            lblMaterial.TabIndex = 12;
            lblMaterial.Text = "物料：";
            
            var lblWarehouse = new System.Windows.Forms.Label();
            lblWarehouse.AutoSize = true;
            lblWarehouse.Location = new System.Drawing.Point(280, 18);
            lblWarehouse.Name = "lblWarehouse";
            lblWarehouse.Size = new System.Drawing.Size(44, 17);
            lblWarehouse.TabIndex = 13;
            lblWarehouse.Text = "仓库：";
            
            var lblQuantity = new System.Windows.Forms.Label();
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new System.Drawing.Point(280, 58);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new System.Drawing.Size(44, 17);
            lblQuantity.TabIndex = 14;
            lblQuantity.Text = "数量：";
            
            var lblPrice = new System.Windows.Forms.Label();
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(440, 18);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new System.Drawing.Size(44, 17);
            lblPrice.TabIndex = 15;
            lblPrice.Text = "单价：";
            
            var lblAmount = new System.Windows.Forms.Label();
            lblAmount.AutoSize = true;
            lblAmount.Location = new System.Drawing.Point(440, 58);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(44, 17);
            lblAmount.TabIndex = 16;
            lblAmount.Text = "金额：";
            
            var lblSupplier = new System.Windows.Forms.Label();
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new System.Drawing.Point(20, 98);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new System.Drawing.Size(56, 17);
            lblSupplier.TabIndex = 17;
            lblSupplier.Text = "供应商：";
            
            var lblInTime = new System.Windows.Forms.Label();
            lblInTime.AutoSize = true;
            lblInTime.Location = new System.Drawing.Point(280, 98);
            lblInTime.Name = "lblInTime";
            lblInTime.Size = new System.Drawing.Size(68, 17);
            lblInTime.TabIndex = 18;
            lblInTime.Text = "入库时间：";
            
            var lblOperator = new System.Windows.Forms.Label();
            lblOperator.AutoSize = true;
            lblOperator.Location = new System.Drawing.Point(540, 98);
            lblOperator.Name = "lblOperator";
            lblOperator.Size = new System.Drawing.Size(56, 17);
            lblOperator.TabIndex = 19;
            lblOperator.Text = "操作员：";
            
            var lblRemark = new System.Windows.Forms.Label();
            lblRemark.AutoSize = true;
            lblRemark.Location = new System.Drawing.Point(600, 18);
            lblRemark.Name = "lblRemark";
            lblRemark.Size = new System.Drawing.Size(44, 17);
            lblRemark.TabIndex = 20;
            lblRemark.Text = "备注：";
            
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.txtRemark);
            this.panelTop.Controls.Add(this.txtOperator);
            this.panelTop.Controls.Add(this.dtpInTime);
            this.panelTop.Controls.Add(this.txtSupplier);
            this.panelTop.Controls.Add(this.txtAmount);
            this.panelTop.Controls.Add(this.txtPrice);
            this.panelTop.Controls.Add(this.txtQuantity);
            this.panelTop.Controls.Add(this.cmbWarehouse);
            this.panelTop.Controls.Add(this.cmbMaterial);
            this.panelTop.Controls.Add(this.txtCode);
            this.panelTop.Controls.Add(lblCode);
            this.panelTop.Controls.Add(lblMaterial);
            this.panelTop.Controls.Add(lblWarehouse);
            this.panelTop.Controls.Add(lblQuantity);
            this.panelTop.Controls.Add(lblPrice);
            this.panelTop.Controls.Add(lblAmount);
            this.panelTop.Controls.Add(lblSupplier);
            this.panelTop.Controls.Add(lblInTime);
            this.panelTop.Controls.Add(lblOperator);
            this.panelTop.Controls.Add(lblRemark);
            
            // Labels for panelSearch
            var lblSearchCode = new System.Windows.Forms.Label();
            lblSearchCode.AutoSize = true;
            lblSearchCode.Location = new System.Drawing.Point(20, 16);
            lblSearchCode.Name = "lblSearchCode";
            lblSearchCode.Size = new System.Drawing.Size(44, 17);
            lblSearchCode.TabIndex = 7;
            lblSearchCode.Text = "单号：";
            
            var lblSearchMaterial = new System.Windows.Forms.Label();
            lblSearchMaterial.AutoSize = true;
            lblSearchMaterial.Location = new System.Drawing.Point(200, 16);
            lblSearchMaterial.Name = "lblSearchMaterial";
            lblSearchMaterial.Size = new System.Drawing.Size(44, 17);
            lblSearchMaterial.TabIndex = 8;
            lblSearchMaterial.Text = "物料：";
            
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.chkEndDate);
            this.panelSearch.Controls.Add(this.chkStartDate);
            this.panelSearch.Controls.Add(this.dtpEndDate);
            this.panelSearch.Controls.Add(this.dtpStartDate);
            this.panelSearch.Controls.Add(this.txtSearchMaterial);
            this.panelSearch.Controls.Add(this.txtSearchCode);
            this.panelSearch.Controls.Add(lblSearchCode);
            this.panelSearch.Controls.Add(lblSearchMaterial);
            // 
            // InStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvInStocks);
            this.Controls.Add(this.panelSearch);
            this.Controls.Add(this.panelTop);
            this.Name = "InStockForm";
            this.Text = "入库管理";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInStocks)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.DateTimePicker dtpInTime;
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
        private System.Windows.Forms.DataGridView dgvInStocks;
    }
}
