-- 仓储管理系统数据库初始化脚本（MySQL 5.7 兼容版本）
-- 数据库名称：mjynetstock
-- 字符集：utf8mb4

-- 创建数据库
CREATE DATABASE IF NOT EXISTS mjynetstock DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;

USE mjynetstock;

-- 用户表
CREATE TABLE IF NOT EXISTS users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE COMMENT '用户名',
    Password VARCHAR(100) NOT NULL COMMENT '密码',
    RealName VARCHAR(50) NOT NULL COMMENT '真实姓名',
    Role VARCHAR(20) NOT NULL COMMENT '角色：管理员/操作员',
    Phone VARCHAR(20) DEFAULT '' COMMENT '电话',
    IsActive TINYINT(1) DEFAULT 1 COMMENT '是否启用',
    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_username (Username)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='用户表';

-- 物料表
CREATE TABLE IF NOT EXISTS materials (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Code VARCHAR(50) NOT NULL UNIQUE COMMENT '物资编号',
    Name VARCHAR(100) NOT NULL COMMENT '物资名称',
    Spec VARCHAR(100) DEFAULT '' COMMENT '规格',
    Unit VARCHAR(20) NOT NULL COMMENT '计量单位',
    Category VARCHAR(50) DEFAULT '' COMMENT '分类',
    Price DECIMAL(18, 2) DEFAULT 0 COMMENT '单价',
    Remark TEXT COMMENT '备注',
    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_code (Code),
    INDEX idx_name (Name)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='物料表';

-- 仓库表
CREATE TABLE IF NOT EXISTS warehouses (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Code VARCHAR(50) NOT NULL UNIQUE COMMENT '仓库编号',
    Name VARCHAR(100) NOT NULL COMMENT '仓库名称',
    Location VARCHAR(200) DEFAULT '' COMMENT '位置',
    Manager VARCHAR(50) DEFAULT '' COMMENT '管理员',
    Remark TEXT COMMENT '备注',
    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_code (Code)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='仓库表';

-- 入库表
CREATE TABLE IF NOT EXISTS instocks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Code VARCHAR(50) NOT NULL UNIQUE COMMENT '入库单号',
    MaterialId INT NOT NULL COMMENT '物资ID',
    WarehouseId INT NOT NULL COMMENT '仓库ID',
    Quantity DECIMAL(18, 2) NOT NULL COMMENT '入库数量',
    Price DECIMAL(18, 2) NOT NULL COMMENT '单价',
    Amount DECIMAL(18, 2) NOT NULL COMMENT '金额',
    Supplier VARCHAR(100) DEFAULT '' COMMENT '供应商',
    InTime DATETIME NOT NULL COMMENT '入库时间',
    Operator VARCHAR(50) NOT NULL COMMENT '操作员',
    Remark TEXT COMMENT '备注',
    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_code (Code),
    INDEX idx_material (MaterialId),
    INDEX idx_warehouse (WarehouseId),
    INDEX idx_intime (InTime),
    FOREIGN KEY (MaterialId) REFERENCES materials(Id),
    FOREIGN KEY (WarehouseId) REFERENCES warehouses(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='入库表';

-- 出库表
CREATE TABLE IF NOT EXISTS outstocks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Code VARCHAR(50) NOT NULL UNIQUE COMMENT '出库单号',
    MaterialId INT NOT NULL COMMENT '物资ID',
    WarehouseId INT NOT NULL COMMENT '仓库ID',
    Quantity DECIMAL(18, 2) NOT NULL COMMENT '出库数量',
    Price DECIMAL(18, 2) NOT NULL COMMENT '单价',
    Amount DECIMAL(18, 2) NOT NULL COMMENT '金额',
    Receiver VARCHAR(100) DEFAULT '' COMMENT '领用人',
    OutTime DATETIME NOT NULL COMMENT '出库时间',
    Operator VARCHAR(50) NOT NULL COMMENT '操作员',
    Remark TEXT COMMENT '备注',
    CreateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
    INDEX idx_code (Code),
    INDEX idx_material (MaterialId),
    INDEX idx_warehouse (WarehouseId),
    INDEX idx_outtime (OutTime),
    FOREIGN KEY (MaterialId) REFERENCES materials(Id),
    FOREIGN KEY (WarehouseId) REFERENCES warehouses(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='出库表';

-- 库存表（MySQL 5.7 版本不支持 ON UPDATE CURRENT_TIMESTAMP，改为触发器）
CREATE TABLE IF NOT EXISTS stocks (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    MaterialId INT NOT NULL COMMENT '物资ID',
    WarehouseId INT NOT NULL COMMENT '仓库ID',
    Quantity DECIMAL(18, 2) NOT NULL DEFAULT 0 COMMENT '库存数量',
    Amount DECIMAL(18, 2) NOT NULL DEFAULT 0 COMMENT '库存金额',
    UpdateTime DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT '更新时间',
    UNIQUE KEY uk_material_warehouse (MaterialId, WarehouseId),
    INDEX idx_material (MaterialId),
    INDEX idx_warehouse (WarehouseId),
    FOREIGN KEY (MaterialId) REFERENCES materials(Id),
    FOREIGN KEY (WarehouseId) REFERENCES warehouses(Id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='库存表';

-- 创建触发器以自动更新 UpdateTime（MySQL 5.7 解决方案）
DELIMITER $$
CREATE TRIGGER trg_stocks_update_time
BEFORE UPDATE ON stocks
FOR EACH ROW
BEGIN
    SET NEW.UpdateTime = CURRENT_TIMESTAMP;
END$$
DELIMITER ;

-- 插入初始管理员账号
INSERT INTO users (Username, Password, RealName, Role, Phone, IsActive) 
VALUES ('admin', '123456', '系统管理员', '管理员', '13800138000', 1);

-- 插入测试操作员账号
INSERT INTO users (Username, Password, RealName, Role, Phone, IsActive) 
VALUES ('user', '123456', '普通用户', '操作员', '13900139000', 1);

-- 插入示例仓库数据
INSERT INTO warehouses (Code, Name, Location, Manager, Remark) VALUES
('WH001', '主仓库', '一楼东区', '张三', '主要存放原材料'),
('WH002', '副仓库', '一楼西区', '李四', '存放成品'),
('WH003', '临时仓库', '二楼', '王五', '临时存放区');

-- 插入示例物料数据
INSERT INTO materials (Code, Name, Spec, Unit, Category, Price, Remark) VALUES
('MAT001', '螺丝', 'M6*20', '个', '五金配件', 0.50, '普通螺丝'),
('MAT002', '螺母', 'M6', '个', '五金配件', 0.30, '六角螺母'),
('MAT003', '垫片', 'Φ6', '个', '五金配件', 0.10, '平垫'),
('MAT004', '钢板', '1000*2000*2mm', '张', '原材料', 120.00, '冷轧钢板'),
('MAT005', '电线', 'BV2.5平方', '米', '电工材料', 3.50, '铜芯线'),
('MAT006', '开关', '86型单开', '个', '电工材料', 8.00, '墙壁开关'),
('MAT007', '油漆', '白色面漆', '桶', '化工材料', 85.00, '5L装'),
('MAT008', '砂纸', '800目', '张', '耗材', 2.00, '水砂纸');

-- 注意事项
-- 1. 本脚本专门为 MySQL 5.7 优化
-- 2. 主要差异：BOOLEAN 改为 TINYINT(1)，添加触发器处理 UpdateTime
-- 3. 默认管理员账号：admin / 123456
-- 4. 默认操作员账号：user / 123456
-- 5. 请根据实际情况修改 Database/DbConfig.cs 中的数据库连接参数

