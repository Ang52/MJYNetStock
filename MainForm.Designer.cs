namespace MJYNetStock
{
    partial class MainForm
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

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnStockQuery = new System.Windows.Forms.Button();
            this.btnOutStock = new System.Windows.Forms.Button();
            this.btnInStock = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnMaterial = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.panelTop.Controls.Add(this.lblUserInfo);
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Controls.Add(this.btnUserManage);
            this.panelTop.Controls.Add(this.btnReport);
            this.panelTop.Controls.Add(this.btnStockQuery);
            this.panelTop.Controls.Add(this.btnOutStock);
            this.panelTop.Controls.Add(this.btnInStock);
            this.panelTop.Controls.Add(this.btnWarehouse);
            this.panelTop.Controls.Add(this.btnMaterial);
            this.panelTop.Controls.Add(this.lblLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 80);
            this.panelTop.TabIndex = 0;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUserInfo.Location = new System.Drawing.Point(1050, 10);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(100, 20);
            this.lblUserInfo.TabIndex = 9;
            this.lblUserInfo.Text = "欢迎：管理员";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExit.Location = new System.Drawing.Point(1100, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 35);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.BackColor = System.Drawing.Color.White;
            this.btnUserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManage.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnUserManage.Location = new System.Drawing.Point(710, 35);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(100, 35);
            this.btnUserManage.TabIndex = 7;
            this.btnUserManage.Text = "用户管理";
            this.btnUserManage.UseVisualStyleBackColor = false;
            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnReport.Location = new System.Drawing.Point(600, 35);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(100, 35);
            this.btnReport.TabIndex = 6;
            this.btnReport.Text = "报表统计";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnStockQuery
            // 
            this.btnStockQuery.BackColor = System.Drawing.Color.White;
            this.btnStockQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStockQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockQuery.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnStockQuery.Location = new System.Drawing.Point(490, 35);
            this.btnStockQuery.Name = "btnStockQuery";
            this.btnStockQuery.Size = new System.Drawing.Size(100, 35);
            this.btnStockQuery.TabIndex = 5;
            this.btnStockQuery.Text = "库存查询";
            this.btnStockQuery.UseVisualStyleBackColor = false;
            this.btnStockQuery.Click += new System.EventHandler(this.btnStockQuery_Click);
            // 
            // btnOutStock
            // 
            this.btnOutStock.BackColor = System.Drawing.Color.White;
            this.btnOutStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOutStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutStock.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOutStock.Location = new System.Drawing.Point(380, 35);
            this.btnOutStock.Name = "btnOutStock";
            this.btnOutStock.Size = new System.Drawing.Size(100, 35);
            this.btnOutStock.TabIndex = 4;
            this.btnOutStock.Text = "出库管理";
            this.btnOutStock.UseVisualStyleBackColor = false;
            this.btnOutStock.Click += new System.EventHandler(this.btnOutStock_Click);
            // 
            // btnInStock
            // 
            this.btnInStock.BackColor = System.Drawing.Color.White;
            this.btnInStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInStock.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnInStock.Location = new System.Drawing.Point(270, 35);
            this.btnInStock.Name = "btnInStock";
            this.btnInStock.Size = new System.Drawing.Size(100, 35);
            this.btnInStock.TabIndex = 3;
            this.btnInStock.Text = "入库管理";
            this.btnInStock.UseVisualStyleBackColor = false;
            this.btnInStock.Click += new System.EventHandler(this.btnInStock_Click);
            // 
            // btnWarehouse
            // 
            this.btnWarehouse.BackColor = System.Drawing.Color.White;
            this.btnWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWarehouse.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnWarehouse.Location = new System.Drawing.Point(160, 35);
            this.btnWarehouse.Name = "btnWarehouse";
            this.btnWarehouse.Size = new System.Drawing.Size(100, 35);
            this.btnWarehouse.TabIndex = 2;
            this.btnWarehouse.Text = "仓库管理";
            this.btnWarehouse.UseVisualStyleBackColor = false;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);
            // 
            // btnMaterial
            // 
            this.btnMaterial.BackColor = System.Drawing.Color.White;
            this.btnMaterial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaterial.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnMaterial.Location = new System.Drawing.Point(50, 35);
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.Size = new System.Drawing.Size(100, 35);
            this.btnMaterial.TabIndex = 1;
            this.btnMaterial.Text = "物料管理";
            this.btnMaterial.UseVisualStyleBackColor = false;
            this.btnMaterial.Click += new System.EventHandler(this.btnMaterial_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLogo.Location = new System.Drawing.Point(20, 10);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(200, 26);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "📦 仓储管理系统";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1200, 620);
            this.panelContent.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仓储管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnMaterial;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnInStock;
        private System.Windows.Forms.Button btnOutStock;
        private System.Windows.Forms.Button btnStockQuery;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblUserInfo;
    }
}
