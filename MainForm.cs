using MJYNetStock.Models;

namespace MJYNetStock
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object? sender, EventArgs e)
        {
            lblUserInfo.Text = $"欢迎：{currentUser.RealName} ({currentUser.Role})";
            
            // 根据角色显示功能按钮
            if (currentUser.Role != "管理员")
            {
                btnUserManage.Visible = false;
            }
        }

        // 物料管理
        private void btnMaterial_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.MaterialForm());
        }

        // 仓库管理
        private void btnWarehouse_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.WarehouseForm());
        }

        // 入库管理
        private void btnInStock_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.InStockForm(currentUser.RealName));
        }

        // 出库管理
        private void btnOutStock_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.OutStockForm(currentUser.RealName));
        }

        // 库存查询
        private void btnStockQuery_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.StockQueryForm());
        }

        // 报表统计
        private void btnReport_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.ReportForm());
        }

        // 用户管理
        private void btnUserManage_Click(object? sender, EventArgs e)
        {
            LoadForm(new Forms.UserManageForm());
        }

        // 退出系统
        private void btnExit_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // 加载子窗体到内容区域
        private void LoadForm(Form form)
        {
            panelContent.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}
