using MJYNetStock.DAL;
using MJYNetStock.Models;

namespace MJYNetStock.Forms
{
    public partial class UserManageForm : Form
    {
        public UserManageForm()
        {
            InitializeComponent();
            this.Load += UserManageForm_Load;
        }

        private void UserManageForm_Load(object? sender, EventArgs e)
        {
            cmbRole.Items.AddRange(new string[] { "管理员", "操作员" });
            cmbRole.SelectedIndex = 1;
            LoadData();
        }

        private void LoadData()
        {
            dgvUsers.DataSource = UserDAL.GetAllUsers();
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Id"].HeaderText = "编号";
                dgvUsers.Columns["Username"].HeaderText = "用户名";
                dgvUsers.Columns["RealName"].HeaderText = "姓名";
                dgvUsers.Columns["Role"].HeaderText = "角色";
                dgvUsers.Columns["Phone"].HeaderText = "电话";
                dgvUsers.Columns["IsActive"].HeaderText = "启用";
                dgvUsers.Columns["CreateTime"].HeaderText = "创建时间";
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            User user = new User
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                RealName = txtRealName.Text.Trim(),
                Role = cmbRole.Text,
                Phone = txtPhone.Text.Trim(),
                IsActive = chkIsActive.Checked
            };

            if (UserDAL.AddUser(user))
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("请选择要修改的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateUpdateInput()) return;

            User user = new User
            {
                Id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value),
                RealName = txtRealName.Text.Trim(),
                Role = cmbRole.Text,
                Phone = txtPhone.Text.Trim(),
                IsActive = chkIsActive.Checked
            };

            if (UserDAL.UpdateUser(user))
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要删除该用户吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                if (UserDAL.DeleteUser(id))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void btnResetPassword_Click(object? sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("请选择要重置密码的用户！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要重置该用户密码为123456吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                if (UserDAL.ChangePassword(id, "123456"))
                {
                    MessageBox.Show("密码重置成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvUsers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtUsername.ReadOnly = true;
                txtPassword.Clear();
                txtRealName.Text = row.Cells["RealName"].Value?.ToString() ?? "";
                cmbRole.Text = row.Cells["Role"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtRealName.Text.Trim()))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateUpdateInput()
        {
            if (string.IsNullOrEmpty(txtRealName.Text.Trim()))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtUsername.Clear();
            txtUsername.ReadOnly = false;
            txtPassword.Clear();
            txtRealName.Clear();
            txtPhone.Clear();
            cmbRole.SelectedIndex = 1;
            chkIsActive.Checked = true;
        }
    }
}
