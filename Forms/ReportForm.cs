using MJYNetStock.DAL;

namespace MJYNetStock.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.Load += ReportForm_Load;
        }

        private void ReportForm_Load(object? sender, EventArgs e)
        {
            dtpYear.Value = DateTime.Now;
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1;
            LoadReport();
        }

        private void LoadReport()
        {
            int year = dtpYear.Value.Year;
            int month = cmbMonth.SelectedIndex + 1;

            // 加载月入库汇总
            dgvInStock.DataSource = ReportDAL.GetMonthlyInStock(year, month);
            if (dgvInStock.Columns.Count > 0)
            {
                dgvInStock.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvInStock.Columns["MaterialName"].HeaderText = "物资名称";
                dgvInStock.Columns["MaterialSpec"].HeaderText = "规格";
                dgvInStock.Columns["MaterialUnit"].HeaderText = "单位";
                dgvInStock.Columns["TotalQuantity"].HeaderText = "总数量";
                dgvInStock.Columns["TotalAmount"].HeaderText = "总金额";
            }

            // 加载月出库汇总
            dgvOutStock.DataSource = ReportDAL.GetMonthlyOutStock(year, month);
            if (dgvOutStock.Columns.Count > 0)
            {
                dgvOutStock.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvOutStock.Columns["MaterialName"].HeaderText = "物资名称";
                dgvOutStock.Columns["MaterialSpec"].HeaderText = "规格";
                dgvOutStock.Columns["MaterialUnit"].HeaderText = "单位";
                dgvOutStock.Columns["TotalQuantity"].HeaderText = "总数量";
                dgvOutStock.Columns["TotalAmount"].HeaderText = "总金额";
            }

            // 加载当前库存
            dgvCurrentStock.DataSource = ReportDAL.GetCurrentStock();
            if (dgvCurrentStock.Columns.Count > 0)
            {
                dgvCurrentStock.Columns["MaterialCode"].HeaderText = "物资编号";
                dgvCurrentStock.Columns["MaterialName"].HeaderText = "物资名称";
                dgvCurrentStock.Columns["MaterialSpec"].HeaderText = "规格";
                dgvCurrentStock.Columns["MaterialUnit"].HeaderText = "单位";
                dgvCurrentStock.Columns["WarehouseName"].HeaderText = "仓库";
                dgvCurrentStock.Columns["Quantity"].HeaderText = "库存数量";
                dgvCurrentStock.Columns["Amount"].HeaderText = "库存金额";
            }

            // 加载统计数据
            var summary = ReportDAL.GetMonthlySummary(year, month);
            if (summary.Rows.Count > 0)
            {
                var row = summary.Rows[0];
                lblInAmount.Text = $"¥{Convert.ToDecimal(row["InAmount"]):N2}";
                lblOutAmount.Text = $"¥{Convert.ToDecimal(row["OutAmount"]):N2}";
                lblStockAmount.Text = $"¥{Convert.ToDecimal(row["StockAmount"]):N2}";
            }
        }

        private void btnQuery_Click(object? sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnExport_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV文件|*.csv",
                FileName = $"月度报表_{dtpYear.Value.Year}年{cmbMonth.SelectedIndex + 1}月_{DateTime.Now:yyyyMMddHHmmss}.csv"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        sw.WriteLine($"月度统计报表 - {dtpYear.Value.Year}年{cmbMonth.SelectedIndex + 1}月");
                        sw.WriteLine();
                        sw.WriteLine($"入库总金额,{lblInAmount.Text}");
                        sw.WriteLine($"出库总金额,{lblOutAmount.Text}");
                        sw.WriteLine($"库存总金额,{lblStockAmount.Text}");
                        sw.WriteLine();
                        
                        sw.WriteLine("月入库汇总");
                        ExportDataGridView(sw, dgvInStock);
                        sw.WriteLine();
                        
                        sw.WriteLine("月出库汇总");
                        ExportDataGridView(sw, dgvOutStock);
                        sw.WriteLine();
                        
                        sw.WriteLine("当前库存");
                        ExportDataGridView(sw, dgvCurrentStock);
                    }
                    MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportDataGridView(StreamWriter sw, DataGridView dgv)
        {
            List<string> headers = new List<string>();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    headers.Add(column.HeaderText);
                }
            }
            sw.WriteLine(string.Join(",", headers));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<string> values = new List<string>();
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (column.Visible)
                    {
                        values.Add(row.Cells[column.Index].Value?.ToString() ?? "");
                    }
                }
                sw.WriteLine(string.Join(",", values));
            }
        }
    }
}
