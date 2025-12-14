using MJYNetStock.DAL;
using MJYNetStock.Models;
using System.Data;

namespace MJYNetStock.Forms
{
    public partial class OutStockForm : Form
    {
        private string operatorName;

        public OutStockForm(string operatorName)
        {
            InitializeComponent();
            this.operatorName = operatorName;
            this.Load += OutStockForm_Load;
        }

        private void OutStockForm_Load(object? sender, EventArgs e)
        {
            LoadMaterials();
            LoadWarehouses();
            LoadData();
            txtCode.Text = OutStockDAL.GenerateOutStockCode();
            txtOperator.Text = operatorName;
            dtpOutTime.Value = DateTime.Now;
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
            dgvOutStocks.DataSource = OutStockDAL.GetAllOutStocks();
            if (dgvOutStocks.Columns.Count > 0)
            {
                dgvOutStocks.Columns["Id"].HeaderText = "编号";
                dgvOutStocks.Columns["Code"].HeaderText = "出库单号";
                dgvOutStocks.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvOutStocks.Columns["MaterialName"].HeaderText = "物资名称";
                dgvOutStocks.Columns["WarehouseName"].HeaderText = "仓库";
                dgvOutStocks.Columns["Quantity"].HeaderText = "数量";
                dgvOutStocks.Columns["Price"].HeaderText = "单价";
                dgvOutStocks.Columns["Amount"].HeaderText = "金额";
                dgvOutStocks.Columns["Receiver"].HeaderText = "领用人";
                dgvOutStocks.Columns["OutTime"].HeaderText = "出库时间";
                dgvOutStocks.Columns["Operator"].HeaderText = "操作员";
                dgvOutStocks.Columns["Remark"].HeaderText = "备注";
                dgvOutStocks.Columns["MaterialId"].Visible = false;
                dgvOutStocks.Columns["WarehouseId"].Visible = false;
                dgvOutStocks.Columns["CreateTime"].Visible = false;
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            OutStock outStock = new OutStock
            {
                Code = txtCode.Text.Trim(),
                MaterialId = Convert.ToInt32(cmbMaterial.SelectedValue),
                WarehouseId = Convert.ToInt32(cmbWarehouse.SelectedValue),
                Quantity = decimal.Parse(txtQuantity.Text.Trim()),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Amount = decimal.Parse(txtAmount.Text.Trim()),
                Receiver = txtReceiver.Text.Trim(),
                OutTime = dtpOutTime.Value,
                Operator = operatorName,
                Remark = txtRemark.Text.Trim()
            };

            if (OutStockDAL.AddOutStock(outStock))
            {
                MessageBox.Show("出库成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                LoadData();
                txtCode.Text = OutStockDAL.GenerateOutStockCode();
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
            
            dgvOutStocks.DataSource = OutStockDAL.SearchOutStocks(
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
            if (string.IsNullOrEmpty(txtReceiver.Text.Trim()))
            {
                MessageBox.Show("请输入领用人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtQuantity.Clear();
            txtPrice.Clear();
            txtAmount.Clear();
            txtReceiver.Clear();
            txtRemark.Clear();
        }
    }
}
