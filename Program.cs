using MJYNetStock.Forms;

namespace MJYNetStock
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // 显示登录窗体
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // 登录成功，显示主窗体
                Application.Run(new MainForm(loginForm.CurrentUser!));
            }
        }
    }
}