namespace MJYNetStock.Forms
{
    partial class WarehouseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvWarehouses;

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
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.lblManager = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.dgvWarehouses = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).BeginInit();
            this.SuspendLayout();
            
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelTop.Controls.Add(this.txtRemark);
            this.panelTop.Controls.Add(this.lblRemark);
            this.panelTop.Controls.Add(this.btnDelete);
            this.panelTop.Controls.Add(this.btnUpdate);
            this.panelTop.Controls.Add(this.btnAdd);
            this.panelTop.Controls.Add(this.txtManager);
            this.panelTop.Controls.Add(this.lblManager);
            this.panelTop.Controls.Add(this.txtLocation);
            this.panelTop.Controls.Add(this.lblLocation);
            this.panelTop.Controls.Add(this.txtName);
            this.panelTop.Controls.Add(this.lblName);
            this.panelTop.Controls.Add(this.txtCode);
            this.panelTop.Controls.Add(this.lblCode);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 120);
            
            // Controls positioning
            this.lblCode.Location = new System.Drawing.Point(20, 18);
            this.lblCode.Text = "仓库编号：";
            this.txtCode.Location = new System.Drawing.Point(100, 15);
            this.txtCode.Size = new System.Drawing.Size(150, 23);
            
            this.lblName.Location = new System.Drawing.Point(20, 58);
            this.lblName.Text = "仓库名称：";
            this.txtName.Location = new System.Drawing.Point(100, 55);
            this.txtName.Size = new System.Drawing.Size(150, 23);
            
            this.lblLocation.Location = new System.Drawing.Point(270, 18);
            this.lblLocation.Text = "位置：";
            this.txtLocation.Location = new System.Drawing.Point(330, 15);
            this.txtLocation.Size = new System.Drawing.Size(200, 23);
            
            this.lblManager.Location = new System.Drawing.Point(270, 58);
            this.lblManager.Text = "管理员：";
            this.txtManager.Location = new System.Drawing.Point(330, 55);
            this.txtManager.Size = new System.Drawing.Size(200, 23);
            
            this.lblRemark.Location = new System.Drawing.Point(550, 18);
            this.lblRemark.Text = "备注：";
            this.txtRemark.Location = new System.Drawing.Point(610, 15);
            this.txtRemark.Size = new System.Drawing.Size(200, 60);
            this.txtRemark.Multiline = true;
            
            this.btnAdd.Location = new System.Drawing.Point(850, 10);
            this.btnAdd.Size = new System.Drawing.Size(80, 35);
            this.btnAdd.Text = "添加";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            
            this.btnUpdate.Location = new System.Drawing.Point(850, 50);
            this.btnUpdate.Size = new System.Drawing.Size(80, 35);
            this.btnUpdate.Text = "修改";
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(100, 181, 246);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            
            this.btnDelete.Location = new System.Drawing.Point(850, 90);
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.Text = "删除";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            
            // dgvWarehouses
            this.dgvWarehouses.AllowUserToAddRows = false;
            this.dgvWarehouses.AllowUserToDeleteRows = false;
            this.dgvWarehouses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouses.BackgroundColor = System.Drawing.Color.White;
            this.dgvWarehouses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWarehouses.ReadOnly = true;
            this.dgvWarehouses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWarehouses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWarehouses_CellClick);
            
            // WarehouseForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvWarehouses);
            this.Controls.Add(this.panelTop);
            this.Name = "WarehouseForm";
            this.Text = "仓库管理";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouses)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
