namespace MJYNetStock.Database
{
    /// <summary>
    /// 数据库配置类
    /// </summary>
    public class DbConfig
    {
        public static string Server { get; set; } = "dbserver.erosli.com";
        public static string Port { get; set; } = "3306";
        public static string Database { get; set; } = "MJYNetStock";
        public static string UserId { get; set; } = "MJYNetStock";
        public static string Password { get; set; } = "123456";

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string GetConnectionString()
        {
            return $"Server={Server};Port={Port};Database={Database};Uid={UserId};Pwd={Password};CharSet=utf8mb4;";
        }
    }
}
