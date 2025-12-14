# 仓储管理系统 (MJYNetStock)

## 项目简介
这是一个基于 .NET 8 + WinForms + MySQL 8 开发的仓储管理系统，适用于中小型企业的仓库管理。

## 主要功能
1. **用户管理** - 用户登录、权限管理、密码重置
2. **物料管理** - 物料信息维护（编号、名称、规格、单位等）
3. **仓库管理** - 仓库基本信息设置
4. **入库管理** - 物资入库操作，库存自动更新
5. **出库管理** - 物资出库操作，库存自动扣减
6. **库存查询** - 多条件查询库存信息，支持导出
7. **报表统计** - 月度入库/出库汇总、库存统计

## 技术栈
- **开发框架**: .NET 8 (Windows Forms)
- **数据库**: MySQL 8
- **数据库连接**: MySql.Data
- **开发工具**: Visual Studio 2022
- **设计风格**: 浅蓝色+白色主题，响应式布局

## 系统要求
- Windows 10/11
- .NET 8 SDK
- MySQL 8.0+
- Visual Studio 2022 (可选)

## 安装步骤

### 1. 安装MySQL数据库
确保MySQL服务器已安装并运行。

### 2. 初始化数据库
在MySQL中执行 `Database/init.sql` 脚本：
```bash
mysql -u root -p < Database/init.sql
```

### 3. 配置数据库连接
编辑 `Database/DbConfig.cs` 文件，修改数据库连接参数：
```csharp
public static string Server { get; set; } = "localhost";
public static string Port { get; set; } = "3306";
public static string Database { get; set; } = "mjynetstock";
public static string UserId { get; set; } = "root";
public static string Password { get; set; } = "123456";
```

### 4. 编译运行
```bash
dotnet build
dotnet run
```

或者在 Visual Studio 中打开 `MJYNetStock.sln` 并运行。

## 默认账号
系统初始化后包含两个测试账号：

| 用户名 | 密码 | 角色 | 说明 |
|--------|------|------|------|
| admin  | 123456 | 管理员 | 拥有所有权限 |
| user   | 123456 | 操作员 | 无用户管理权限 |

## 项目结构
```
MJYNetStock/
├── Database/           # 数据库相关
│   ├── DbConfig.cs     # 数据库配置
│   ├── DbHelper.cs     # 数据库辅助类
│   └── init.sql        # 初始化脚本
├── Models/             # 实体模型
│   ├── User.cs         # 用户
│   ├── Material.cs     # 物料
│   ├── Warehouse.cs    # 仓库
│   ├── InStock.cs      # 入库单
│   ├── OutStock.cs     # 出库单
│   └── Stock.cs        # 库存
├── DAL/                # 数据访问层
│   ├── UserDAL.cs      # 用户数据访问
│   ├── MaterialDAL.cs  # 物料数据访问
│   ├── WarehouseDAL.cs # 仓库数据访问
│   ├── InStockDAL.cs   # 入库数据访问
│   ├── OutStockDAL.cs  # 出库数据访问
│   ├── StockDAL.cs     # 库存数据访问
│   └── ReportDAL.cs    # 报表数据访问
├── Forms/              # 窗体界面
│   ├── LoginForm.*     # 登录窗体
│   ├── MaterialForm.*  # 物料管理
│   ├── WarehouseForm.* # 仓库管理
│   ├── InStockForm.*   # 入库管理
│   ├── OutStockForm.*  # 出库管理
│   ├── StockQueryForm.*# 库存查询
│   ├── ReportForm.*    # 报表统计
│   └── UserManageForm.*# 用户管理
├── MainForm.*          # 主窗体
└── Program.cs          # 程序入口

```

## 功能说明

### 1. 登录系统
- 输入用户名和密码登录
- 支持回车键快速登录

### 2. 物料管理
- 添加、修改、删除物料信息
- 支持关键字搜索（编号、名称、规格）
- 字段包括：编号、名称、规格、单位、分类、单价、备注

### 3. 仓库管理
- 维护仓库基本信息
- 包括：编号、名称、位置、管理员、备注

### 4. 入库管理
- 选择物料和仓库
- 输入数量、单价，自动计算金额
- 记录供应商和入库时间
- 自动更新库存数量和金额
- 支持按单号、物料名称、时间范围查询

### 5. 出库管理
- 选择物料和仓库
- 输入数量、单价，自动计算金额
- 记录领用人和出库时间
- 自动扣减库存（库存不足时提示）
- 支持按单号、物料名称、时间范围查询

### 6. 库存查询
- 多条件查询：物资编号、名称、仓库
- 显示当前库存数量和金额
- 支持导出CSV格式报表

### 7. 报表统计
- 按年月查询统计数据
- 月入库汇总：显示各物料入库总数量和总金额
- 月出库汇总：显示各物料出库总数量和总金额
- 当前库存：显示所有物料的库存情况
- 支持导出完整报表

### 8. 用户管理（仅管理员）
- 添加、修改、删除用户
- 设置用户角色（管理员/操作员）
- 启用/禁用用户账号
- 重置用户密码为默认密码(123456)

## 界面特点
- **主题配色**: 浅蓝色(#ADD8E6) + 白色，简洁舒适
- **响应式布局**: 窗口大小自适应，支持最大化
- **上下结构**: 上方功能按钮区域，下方数据显示区域
- **系统LOGO**: 左上角显示📦图标 + 系统名称
- **用户信息**: 右上角显示当前登录用户信息

## 数据库说明
- 数据库名称：mjynetstock
- 字符集：utf8mb4
- 包含6张表：users(用户)、materials(物料)、warehouses(仓库)、instocks(入库)、outstocks(出库)、stocks(库存)
- 使用事务确保入库/出库操作的数据一致性
- 建立索引优化查询性能

## 注意事项
1. 首次使用前必须执行init.sql初始化数据库
2. 确保MySQL服务正常运行
3. 出库时会自动检查库存是否充足
4. 库存金额采用加权平均法计算
5. 删除物料或仓库前请确保没有关联的入库、出库记录
6. 定期备份数据库数据

## 常见问题

### 1. 数据库连接失败
- 检查MySQL服务是否启动
- 确认DbConfig.cs中的连接参数是否正确
- 检查MySQL用户权限

### 2. 编译错误
- 确保已安装.NET 8 SDK
- 检查NuGet包是否正确还原：`dotnet restore`
- 清理并重新生成：`dotnet clean && dotnet build`

### 3. 登录失败
- 确认是否已执行init.sql初始化数据库
- 检查用户名和密码是否正确
- 默认账号：admin/123456

## 开发者信息
- **项目名称**: 仓储管理系统 (MJYNetStock)
- **开发框架**: .NET 8 + WinForms
- **数据库**: MySQL 8
- **开发时间**: 2024年

## 许可证
本项目仅供学习交流使用。

## 更新日志

### v1.0.0 (2024-12-14)
- ✅ 完成用户登录功能
- ✅ 完成物料管理功能
- ✅ 完成仓库管理功能
- ✅ 完成入库管理功能
- ✅ 完成出库管理功能
- ✅ 完成库存查询功能
- ✅ 完成报表统计功能
- ✅ 完成用户管理功能
- ✅ 实现响应式UI布局
- ✅ 支持数据导出CSV

## 联系方式
如有问题或建议，欢迎反馈。
