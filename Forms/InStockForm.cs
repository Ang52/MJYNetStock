using MJYNetStock.DAL;
using MJYNetStock.Models;
using System.Data;

namespace MJYNetStock.Forms
{
    public partial class InStockForm : Form
    {
        private string operatorName;

        public InStockForm(string operatorName)
        {
            InitializeComponent();
            this.operatorName = operatorName;
            this.Load += InStockForm_Load;
        }

        private void InStockForm_Load(object? sender, EventArgs e)
        {
            LoadMaterials();
            LoadWarehouses();
            LoadData();
            txtCode.Text = InStockDAL.GenerateInStockCode();
            txtOperator.Text = operatorName;
            dtpInTime.Value = DateTime.Now;
        }

        private void LoadMaterials()
        {
            var dt = MaterialDAL.GetAllMaterials();
            cmbMaterial.DataSource = dt;
            cmbMaterial.DisplayMember = "Name";
            cmbMaterial.ValueMember = "Id";
        }

        private void LoadWarehouses()
        {
            var dt = WarehouseDAL.GetAllWarehouses();
            cmbWarehouse.DataSource = dt;
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.ValueMember = "Id";
        }

        private void LoadData()
        {
            dgvInStocks.DataSource = InStockDAL.GetAllInStocks();
            if (dgvInStocks.Columns.Count > 0)
            {
                dgvInStocks.Columns["Id"].HeaderText = "编号";
                dgvInStocks.Columns["Code"].HeaderText = "入库单号";
                dgvInStocks.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvInStocks.Columns["MaterialName"].HeaderText = "物资名称";
                dgvInStocks.Columns["WarehouseName"].HeaderText = "仓库";
                dgvInStocks.Columns["Quantity"].HeaderText = "数量";
                dgvInStocks.Columns["Price"].HeaderText = "单价";
                dgvInStocks.Columns["Amount"].HeaderText = "金额";
                dgvInStocks.Columns["Supplier"].HeaderText = "供应商";
                dgvInStocks.Columns["InTime"].HeaderText = "入库时间";
                dgvInStocks.Columns["Operator"].HeaderText = "操作员";
                dgvInStocks.Columns["Remark"].HeaderText = "备注";
                dgvInStocks.Columns["MaterialId"].Visible = false;
                dgvInStocks.Columns["WarehouseId"].Visible = false;
                dgvInStocks.Columns["CreateTime"].Visible = false;
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            InStock inStock = new InStock
            {
                Code = txtCode.Text.Trim(),
                MaterialId = Convert.ToInt32(cmbMaterial.SelectedValue),
                WarehouseId = Convert.ToInt32(cmbWarehouse.SelectedValue),
                Quantity = decimal.Parse(txtQuantity.Text.Trim()),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Amount = decimal.Parse(txtAmount.Text.Trim()),
                Supplier = txtSupplier.Text.Trim(),
                InTime = dtpInTime.Value,
                Operator = operatorName,
                Remark = txtRemark.Text.Trim()
            };

            if (InStockDAL.AddInStock(inStock))
            {
                MessageBox.Show("入库成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
                txtCode.Text = InStockDAL.GenerateInStockCode();
            }
        }

        private void txtQuantity_TextChanged(object? sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void txtPrice_TextChanged(object? sender, EventArgs e)
        {
            CalculateAmount();
        }

        private void CalculateAmount()
        {
            if (decimal.TryParse(txtQuantity.Text, out decimal quantity) && 
                decimal.TryParse(txtPrice.Text, out decimal price))
            {
                txtAmount.Text = (quantity * price).ToString("F2");
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            DateTime? startDate = chkStartDate.Checked ? dtpStartDate.Value.Date : null;
            DateTime? endDate = chkEndDate.Checked ? dtpEndDate.Value.Date : null;
            
            dgvInStocks.DataSource = InStockDAL.SearchInStocks(
                txtSearchCode.Text.Trim(), 
                txtSearchMaterial.Text.Trim(), 
                startDate, 
                endDate);
        }

        private bool ValidateInput()
        {
            if (cmbMaterial.SelectedValue == null)
            {
                MessageBox.Show("请选择物料！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbWarehouse.SelectedValue == null)
            {
                MessageBox.Show("请选择仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtQuantity.Text, out _))
            {
                MessageBox.Show("请输入正确的数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("请输入正确的单价！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtQuantity.Clear();
            txtPrice.Clear();
            txtAmount.Clear();
            txtSupplier.Clear();
            txtRemark.Clear();
        }
    }
}
