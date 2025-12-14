using MJYNetStock.DAL;
using MJYNetStock.Models;

namespace MJYNetStock.Forms
{
    public partial class MaterialForm : Form
    {
        public MaterialForm()
        {
            InitializeComponent();
            this.Load += MaterialForm_Load;
        }

        private void MaterialForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvMaterials.DataSource = MaterialDAL.GetAllMaterials();
            dgvMaterials.Columns["Id"].HeaderText = "编号";
            dgvMaterials.Columns["Code"].HeaderText = "物资编号";
            dgvMaterials.Columns["Name"].HeaderText = "物资名称";
            dgvMaterials.Columns["Spec"].HeaderText = "规格";
            dgvMaterials.Columns["Unit"].HeaderText = "计量单位";
            dgvMaterials.Columns["Category"].HeaderText = "分类";
            dgvMaterials.Columns["Price"].HeaderText = "单价";
            dgvMaterials.Columns["Remark"].HeaderText = "备注";
            dgvMaterials.Columns["CreateTime"].HeaderText = "创建时间";
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            Material material = new Material
            {
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Spec = txtSpec.Text.Trim(),
                Unit = txtUnit.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Remark = txtRemark.Text.Trim()
            };

            if (MaterialDAL.AddMaterial(material))
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnUpdate_Click(object? sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("请选择要修改的物料！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            Material material = new Material
            {
                Id = Convert.ToInt32(dgvMaterials.CurrentRow.Cells["Id"].Value),
                Code = txtCode.Text.Trim(),
                Name = txtName.Text.Trim(),
                Spec = txtSpec.Text.Trim(),
                Unit = txtUnit.Text.Trim(),
                Category = txtCategory.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Remark = txtRemark.Text.Trim()
            };

            if (MaterialDAL.UpdateMaterial(material))
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的物料！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确定要删除该物料吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvMaterials.CurrentRow.Cells["Id"].Value);
                if (MaterialDAL.DeleteMaterial(id))
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                dgvMaterials.DataSource = MaterialDAL.SearchMaterials(keyword);
            }
        }

        private void dgvMaterials_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMaterials.Rows[e.RowIndex];
                txtCode.Text = row.Cells["Code"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtSpec.Text = row.Cells["Spec"].Value?.ToString() ?? "";
                txtUnit.Text = row.Cells["Unit"].Value?.ToString() ?? "";
                txtCategory.Text = row.Cells["Category"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["Price"].Value?.ToString() ?? "";
                txtRemark.Text = row.Cells["Remark"].Value?.ToString() ?? "";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text.Trim()))
            {
                MessageBox.Show("请输入物资编号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("请输入物资名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text.Trim()))
            {
                MessageBox.Show("请输入计量单位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                MessageBox.Show("请输入正确的单价！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtCode.Clear();
            txtName.Clear();
            txtSpec.Clear();
            txtUnit.Clear();
            txtCategory.Clear();
            txtPrice.Clear();
            txtRemark.Clear();
        }
    }
}
