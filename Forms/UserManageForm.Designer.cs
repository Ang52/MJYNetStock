namespace MJYNetStock.Forms
{
    partial class UserManageForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.DataGridView dgvUsers;

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
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            
            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(1000, 120);
            
            var lblUsername = new System.Windows.Forms.Label { Text = "用户名：", Location = new System.Drawing.Point(20, 18), AutoSize = true };
            var lblPassword = new System.Windows.Forms.Label { Text = "密码：", Location = new System.Drawing.Point(20, 58), AutoSize = true };
            var lblRealName = new System.Windows.Forms.Label { Text = "姓名：", Location = new System.Drawing.Point(280, 18), AutoSize = true };
            var lblRole = new System.Windows.Forms.Label { Text = "角色：", Location = new System.Drawing.Point(280, 58), AutoSize = true };
            var lblPhone = new System.Windows.Forms.Label { Text = "电话：", Location = new System.Drawing.Point(480, 18), AutoSize = true };
            
            this.txtUsername.Location = new System.Drawing.Point(90, 15);
            this.txtUsername.Size = new System.Drawing.Size(150, 23);
            
            this.txtPassword.Location = new System.Drawing.Point(90, 55);
            this.txtPassword.Size = new System.Drawing.Size(150, 23);
            this.txtPassword.PasswordChar = '*';
            
            this.txtRealName.Location = new System.Drawing.Point(330, 15);
            this.txtRealName.Size = new System.Drawing.Size(120, 23);
            
            this.cmbRole.Location = new System.Drawing.Point(330, 55);
            this.cmbRole.Size = new System.Drawing.Size(120, 23);
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            
            this.txtPhone.Location = new System.Drawing.Point(530, 15);
            this.txtPhone.Size = new System.Drawing.Size(150, 23);
            
            this.chkIsActive.Location = new System.Drawing.Point(530, 58);
            this.chkIsActive.Text = "启用";
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            
            this.btnAdd.Location = new System.Drawing.Point(750, 10);
            this.btnAdd.Size = new System.Drawing.Size(80, 35);
            this.btnAdd.Text = "添加";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Click += btnAdd_Click;
            
            this.btnUpdate.Location = new System.Drawing.Point(850, 10);
            this.btnUpdate.Size = new System.Drawing.Size(80, 35);
            this.btnUpdate.Text = "修改";
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(100, 181, 246);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Click += btnUpdate_Click;
            
            this.btnDelete.Location = new System.Drawing.Point(750, 50);
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.Text = "删除";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Click += btnDelete_Click;
            
            this.btnResetPassword.Location = new System.Drawing.Point(850, 50);
            this.btnResetPassword.Size = new System.Drawing.Size(80, 35);
            this.btnResetPassword.Text = "重置密码";
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Click += btnResetPassword_Click;
            
            this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblUsername, lblPassword, lblRealName, lblRole, lblPhone,
                this.txtUsername, this.txtPassword, this.txtRealName, this.cmbRole, 
                this.txtPhone, this.chkIsActive, this.btnAdd, this.btnUpdate, 
                this.btnDelete, this.btnResetPassword
            });
            
            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.CellClick += dgvUsers_CellClick;
            
            // UserManageForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panelTop);
            this.Name = "UserManageForm";
            this.Text = "用户管理";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
