using MJYNetStock.DAL;

namespace MJYNetStock.Forms
{
    public partial class StockQueryForm : Form
    {
        public StockQueryForm()
        {
            InitializeComponent();
            this.Load += StockQueryForm_Load;
        }

        private void StockQueryForm_Load(object? sender, EventArgs e)
        {
            LoadWarehouses();
            LoadData();
        }

        private void LoadWarehouses()
        {
            var dt = WarehouseDAL.GetAllWarehouses();
            cmbWarehouse.Items.Add(new { Id = 0, Name = "全部仓库" });
            foreach (System.Data.DataRow row in dt.Rows)
            {
                cmbWarehouse.Items.Add(new { Id = row["Id"], Name = row["Name"] });
            }
            cmbWarehouse.DisplayMember = "Name";
            cmbWarehouse.ValueMember = "Id";
            cmbWarehouse.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvStocks.DataSource = StockDAL.GetAllStocks();
            if (dgvStocks.Columns.Count > 0)
            {
                dgvStocks.Columns["Id"].HeaderText = "编号";
                dgvStocks.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvStocks.Columns["MaterialName"].HeaderText = "物资名称";
                dgvStocks.Columns["MaterialSpec"].HeaderText = "规格";
                dgvStocks.Columns["MaterialUnit"].HeaderText = "单位";
                dgvStocks.Columns["WarehouseName"].HeaderText = "仓库";
                dgvStocks.Columns["Quantity"].HeaderText = "库存数量";
                dgvStocks.Columns["Amount"].HeaderText = "库存金额";
                dgvStocks.Columns["UpdateTime"].HeaderText = "更新时间";
                dgvStocks.Columns["MaterialId"].Visible = false;
                dgvStocks.Columns["WarehouseId"].Visible = false;
            }
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            string materialCode = txtMaterialCode.Text.Trim();
            string materialName = txtMaterialName.Text.Trim();
            int? warehouseId = cmbWarehouse.SelectedValue != null ? Convert.ToInt32(cmbWarehouse.SelectedValue) : null;

            dgvStocks.DataSource = StockDAL.SearchStocks(materialCode, materialName, warehouseId);
        }

        private void btnRefresh_Click(object? sender, EventArgs e)
        {
            txtMaterialCode.Clear();
            txtMaterialName.Clear();
            cmbWarehouse.SelectedIndex = 0;
            LoadData();
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            if (dgvStocks.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可以导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV文件|*.csv",
                FileName = $"库存数据_{DateTime.Now:yyyyMMddHHmmss}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // 写入标题
                        List<string> headers = new List<string>();
                        foreach (DataGridViewColumn column in dgvStocks.Columns)
                        {
                            if (column.Visible)
                            {
                                headers.Add(column.HeaderText);
                            }
                        }
                        sw.WriteLine(string.Join(",", headers));

                        // 写入数据
                        foreach (DataGridViewRow row in dgvStocks.Rows)
                        {
                            List<string> values = new List<string>();
                            foreach (DataGridViewColumn column in dgvStocks.Columns)
                            {
                                if (column.Visible)
                                {
                                    values.Add(row.Cells[column.Index].Value?.ToString() ?? "");
                                }
                            }
                            sw.WriteLine(string.Join(",", values));
                        }
                    }
                    MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
