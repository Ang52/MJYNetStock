using MJYNetStock.DAL;
using MJYNetStock.Models;

namespace MJYNetStock.Forms
{
    public partial class WarehouseForm : Form
    {
        public WarehouseForm()
        {
            InitializeComponent();
            this.Load += WarehouseForm_Load;
        }

        private void WarehouseForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvWarehouses.DataSource = WarehouseDAL.GetAllWarehouses();
            dgvWarehouses.Columns["Id"].HeaderText = "编号";
            dgvWarehouses.Columns["Code"].HeaderText = "仓库编号";
            dgvWarehouses.Columns["Name"].HeaderText = "仓库名称";
            dgvWarehouses.Columns["Location"].HeaderText = "位置";
            dgvWarehouses.Columns["Manager"].HeaderText = "管理员";
            dgvWarehouses.Columns["Remark"].HeaderText = "备注";
            dgvWarehouses.Columns["CreateTime"].HeaderText = "创建时间";
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Warehouse warehouse = new Warehouse
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                Manager = txtManager.Text.Trim(),
                Remark = txtRemark.Text.Trim()
            };

            if (WarehouseDAL.AddWarehouse(warehouse))
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvWarehouses.CurrentRow == null)
            {
                MessageBox.Show("请选择要修改的仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            Warehouse warehouse = new Warehouse
            {
                Id = Convert.ToInt32(dgvWarehouses.CurrentRow.Cells["Id"].Value),
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Location = txtLocation.Text.Trim(),
                Manager = txtManager.Text.Trim(),
                Remark = txtRemark.Text.Trim()
            };

            if (WarehouseDAL.UpdateWarehouse(warehouse))
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvWarehouses.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要删除该仓库吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvWarehouses.CurrentRow.Cells["Id"].Value);
                if (WarehouseDAL.DeleteWarehouse(id))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void dgvWarehouses_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvWarehouses.Rows[e.RowIndex];
                txtCode.Text = row.Cells["Code"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtLocation.Text = row.Cells["Location"].Value?.ToString() ?? "";
                txtManager.Text = row.Cells["Manager"].Value?.ToString() ?? "";
                txtRemark.Text = row.Cells["Remark"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请输入仓库编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入仓库名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtCode.Clear();
            txtName.Clear();
            txtLocation.Clear();
            txtManager.Clear();
            txtRemark.Clear();
        }
    }
}
