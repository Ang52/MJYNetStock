# 数据库迁移指南

本文档说明如何将 MJYNetStock 项目迁移到不同的数据库系统。

## 📊 目录
- [MySQL 5.7 迁移](#mysql-57-迁移)
- [MySQL 8.0+ 配置](#mysql-80-配置)
- [SQL Server 迁移](#sql-server-迁移)
- [PostgreSQL 迁移](#postgresql-迁移)
- [SQLite 迁移](#sqlite-迁移)

---

## MySQL 5.7 迁移

### ✅ 已完成的修改

项目现在已经兼容 MySQL 5.7！主要变更：

1. **数据库连接字符串** (`Database/DbConfig.cs`)
   ```csharp
   // 添加了 SslMode 和 AllowPublicKeyRetrieval 参数
   return $"Server={Server};Port={Port};Database={Database};Uid={UserId};Pwd={Password};CharSet=utf8mb4;SslMode=None;AllowPublicKeyRetrieval=True;";
   ```

2. **初始化脚本** (`Database/init_mysql57.sql`)
   - `BOOLEAN` 类型改为 `TINYINT(1)`
   - 移除 `ON UPDATE CURRENT_TIMESTAMP`（仅 MySQL 8.0+ 支持）
   - 添加触发器自动更新 `UpdateTime`

### 🚀 使用步骤

1. **修改配置文件** `Database/DbConfig.cs`：
   ```csharp
   public static string Server { get; set; } = "localhost";  // 您的服务器地址
   public static string Port { get; set; } = "3306";
   public static string Database { get; set; } = "mjynetstock";
   public static string UserId { get; set; } = "root";       // 您的用户名
   public static string Password { get; set; } = "123456";   // 您的密码
   ```

2. **执行初始化脚本**：
   ```bash
   mysql -u root -p < Database/init_mysql57.sql
   ```

3. **运行项目**，完成！

### 📝 MySQL 5.7 与 8.0 差异

| 特性 | MySQL 5.7 | MySQL 8.0 |
|------|-----------|-----------|
| BOOLEAN 类型 | ❌ 使用 TINYINT(1) | ✅ 原生支持 |
| ON UPDATE CURRENT_TIMESTAMP | ❌ 需要触发器 | ✅ 原生支持 |
| 默认认证插件 | mysql_native_password | caching_sha2_password |
| JSON 函数 | 部分支持 | 完整支持 |

---

## MySQL 8.0+ 配置

### 当前配置已优化

使用原始的 `Database/init.sql` 即可：

```bash
mysql -u root -p < Database/init.sql
```

**连接字符串参数说明**：
- `SslMode=None` - 禁用 SSL（适用于本地开发）
- `AllowPublicKeyRetrieval=True` - 允许公钥检索（适用于 caching_sha2_password）
- `CharSet=utf8mb4` - 使用 UTF-8 编码，支持中文和 Emoji

---

## SQL Server 迁移

### 1. 安装 NuGet 包

```bash
dotnet remove package MySql.Data
dotnet add package Microsoft.Data.SqlClient
```

### 2. 修改 `Database/DbConfig.cs`

```csharp
namespace MJYNetStock.Database
{
    public class DbConfig
    {
        public static string Server { get; set; } = "localhost";
        public static string Database { get; set; } = "MJYNetStock";
        public static string UserId { get; set; } = "sa";
        public static string Password { get; set; } = "YourPassword123!";

        public static string GetConnectionString()
        {
            return $"Server={Server};Database={Database};User Id={UserId};Password={Password};TrustServerCertificate=True;";
        }
    }
}
```

### 3. 修改 `Database/DbHelper.cs`

```csharp
using Microsoft.Data.SqlClient;  // 替换 using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.Database
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()  // 替换 MySqlConnection
        {
            return new SqlConnection(DbConfig.GetConnectionString());
        }

        public static DataTable ExecuteQuery(string sql, SqlParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                using (var cmd = new SqlCommand(sql, conn))  // 替换 MySqlCommand
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    
                    using (var adapter = new SqlDataAdapter(cmd))  // 替换 MySqlDataAdapter
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // ... 其他方法也需要替换为 SqlCommand, SqlParameter 等
    }
}
```

### 4. 创建 SQL Server 初始化脚本

主要差异：
- `AUTO_INCREMENT` → `IDENTITY(1,1)`
- `DATETIME DEFAULT CURRENT_TIMESTAMP` → `DATETIME DEFAULT GETDATE()`
- 数据类型：`TEXT` → `NVARCHAR(MAX)`，`BOOLEAN` → `BIT`

---

## PostgreSQL 迁移

### 1. 安装 NuGet 包

```bash
dotnet remove package MySql.Data
dotnet add package Npgsql
```

### 2. 修改连接字符串

```csharp
public static string GetConnectionString()
{
    return $"Host={Server};Port=5432;Database={Database};Username={UserId};Password={Password};";
}
```

### 3. 主要差异

- `AUTO_INCREMENT` → `SERIAL` 或 `GENERATED ALWAYS AS IDENTITY`
- 参数占位符：`@param` → `@param`（相同）
- 数据类型：`DATETIME` → `TIMESTAMP`

---

## SQLite 迁移

### 1. 安装 NuGet 包

```bash
dotnet remove package MySql.Data
dotnet add package Microsoft.Data.Sqlite
```

### 2. 修改连接字符串

```csharp
public static string GetConnectionString()
{
    return $"Data Source={Database}.db";
}
```

### 3. 注意事项

- ✅ 轻量级，无需服务器
- ❌ 不支持外键级联（需要手动处理）
- ❌ 并发性能较差
- ✅ 适合单用户或小型应用

---

## 🔧 通用迁移步骤

无论迁移到哪个数据库，都需要：

1. **替换 NuGet 包**
2. **修改 `DbConfig.cs` 连接字符串**
3. **修改 `DbHelper.cs` 中的数据库客户端类**
4. **批量替换所有 DAL 文件中的：**
   - `MySqlConnection` → `[新数据库]Connection`
   - `MySqlCommand` → `[新数据库]Command`
   - `MySqlParameter` → `[新数据库]Parameter`
   - `MySqlDataAdapter` → `[新数据库]DataAdapter`
   - `MySqlTransaction` → `[新数据库]Transaction`

5. **转换 SQL 语法差异**
6. **重新创建数据库和表**

---

## 📞 常见问题

### Q: 如何备份当前数据？

**MySQL 备份**：
```bash
mysqldump -u root -p mjynetstock > backup.sql
```

### Q: 如何在 MySQL 5.7 和 8.0 之间切换？

只需更换初始化脚本即可：
- MySQL 5.7：使用 `init_mysql57.sql`
- MySQL 8.0：使用 `init.sql`

连接字符串无需修改。

### Q: 性能建议？

- **开发环境**：SQLite（简单快速）
- **小型应用**：MySQL 5.7/8.0（平衡）
- **企业应用**：SQL Server 或 PostgreSQL（功能强大）
- **高并发**：MySQL 8.0 或 PostgreSQL（优化好）

---

## ✅ 完成检查清单

迁移完成后，请确认：

- [ ] 数据库连接成功
- [ ] 用户登录功能正常
- [ ] 物料管理 CRUD 正常
- [ ] 入库/出库操作正常
- [ ] 库存数据自动更新
- [ ] 报表统计显示正确
- [ ] 中文显示无乱码

---

## 📚 参考资料

- [MySql.Data 文档](https://dev.mysql.com/doc/connector-net/en/)
- [Microsoft.Data.SqlClient 文档](https://docs.microsoft.com/en-us/sql/connect/ado-net/)
- [Npgsql 文档](https://www.npgsql.org/doc/)
- [Microsoft.Data.Sqlite 文档](https://docs.microsoft.com/en-us/dotnet/standard/data/sqlite/)

