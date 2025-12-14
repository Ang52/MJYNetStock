using MJYNetStock.Database;
using MJYNetStock.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 用户数据访问类
    /// </summary>
    public class UserDAL
    {
        /// <summary>
        /// 用户登录验证
        /// </summary>
        public static User? Login(string username, string password)
        {
            string sql = "SELECT * FROM users WHERE Username=@Username AND Password=@Password AND IsActive=1";
            var dt = DbHelper.ExecuteQuery(sql,
                new MySqlParameter("@Username", username),
                new MySqlParameter("@Password", password));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Username = row["Username"].ToString() ?? string.Empty,
                    Password = row["Password"].ToString() ?? string.Empty,
                    RealName = row["RealName"].ToString() ?? string.Empty,
                    Role = row["Role"].ToString() ?? string.Empty,
                    Phone = row["Phone"].ToString() ?? string.Empty,
                    IsActive = Convert.ToBoolean(row["IsActive"]),
                    CreateTime = Convert.ToDateTime(row["CreateTime"])
                };
            }
            return null;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        public static DataTable GetAllUsers()
        {
            string sql = "SELECT Id, Username, RealName, Role, Phone, IsActive, CreateTime FROM users ORDER BY Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        public static bool AddUser(User user)
        {
            string sql = @"INSERT INTO users (Username, Password, RealName, Role, Phone, IsActive, CreateTime) 
                          VALUES (@Username, @Password, @RealName, @Role, @Phone, @IsActive, @CreateTime)";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Username", user.Username),
                new MySqlParameter("@Password", user.Password),
                new MySqlParameter("@RealName", user.RealName),
                new MySqlParameter("@Role", user.Role),
                new MySqlParameter("@Phone", user.Phone),
                new MySqlParameter("@IsActive", user.IsActive),
                new MySqlParameter("@CreateTime", user.CreateTime));
            return result > 0;
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        public static bool UpdateUser(User user)
        {
            string sql = @"UPDATE users SET RealName=@RealName, Role=@Role, Phone=@Phone, IsActive=@IsActive 
                          WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Id", user.Id),
                new MySqlParameter("@RealName", user.RealName),
                new MySqlParameter("@Role", user.Role),
                new MySqlParameter("@Phone", user.Phone),
                new MySqlParameter("@IsActive", user.IsActive));
            return result > 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        public static bool ChangePassword(int userId, string newPassword)
        {
            string sql = "UPDATE users SET Password=@Password WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Id", userId),
                new MySqlParameter("@Password", newPassword));
            return result > 0;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        public static bool DeleteUser(int userId)
        {
            string sql = "DELETE FROM users WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql, new MySqlParameter("@Id", userId));
            return result > 0;
        }
    }
}
