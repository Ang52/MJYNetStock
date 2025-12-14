namespace MJYNetStock.Database
{
    /// <summary>
    /// 数据库配置类
    /// </summary>
    public class DbConfig
    {
        public static string Server { get; set; } = "localhost";
        public static string Port { get; set; } = "3306";
        public static string Database { get; set; } = "MJYNetStock";
        public static string UserId { get; set; } = "MJYNetStock";
        public static string Password { get; set; } = "123456";

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public static string GetConnectionString()
        {
            // MySQL 8.0 及以上配置
            return $"Server={Server};Port={Port};Database={Database};Uid={UserId};Pwd={Password};CharSet=utf8mb4;";
            // MySQL 5.7 兼容配置
            //return $"Server={Server};Port={Port};Database={Database};Uid={UserId};Pwd={Password};CharSet=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=True;";
        }
    }
}
