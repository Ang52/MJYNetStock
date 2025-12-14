using MJYNetStock.Database;
using MJYNetStock.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 入库数据访问类
    /// </summary>
    public class InStockDAL
    {
        /// <summary>
        /// 获取所有入库记录
        /// </summary>
        public static DataTable GetAllInStocks()
        {
            string sql = @"SELECT i.*, m.Code AS MaterialCode, m.Name AS MaterialName, w.Name AS WarehouseName
                          FROM instocks i
                          LEFT JOIN materials m ON i.MaterialId = m.Id
                          LEFT JOIN warehouses w ON i.WarehouseId = w.Id
                          ORDER BY i.Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 按条件查询入库记录
        /// </summary>
        public static DataTable SearchInStocks(string? code, string? materialName, DateTime? startDate, DateTime? endDate)
        {
            string sql = @"SELECT i.*, m.Code AS MaterialCode, m.Name AS MaterialName, w.Name AS WarehouseName
                          FROM instocks i
                          LEFT JOIN materials m ON i.MaterialId = m.Id
                          LEFT JOIN warehouses w ON i.WarehouseId = w.Id
                          WHERE 1=1";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(code))
            {
                sql += " AND i.Code LIKE @Code";
                parameters.Add(new MySqlParameter("@Code", $"%{code}%"));
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                sql += " AND m.Name LIKE @MaterialName";
                parameters.Add(new MySqlParameter("@MaterialName", $"%{materialName}%"));
            }

            if (startDate.HasValue)
            {
                sql += " AND i.InTime >= @StartDate";
                parameters.Add(new MySqlParameter("@StartDate", startDate.Value));
            }

            if (endDate.HasValue)
            {
                sql += " AND i.InTime <= @EndDate";
                parameters.Add(new MySqlParameter("@EndDate", endDate.Value.AddDays(1)));
            }

            sql += " ORDER BY i.Id DESC";
            return DbHelper.ExecuteQuery(sql, parameters.ToArray());
        }

        /// <summary>
        /// 添加入库记录
        /// </summary>
        public static bool AddInStock(InStock inStock)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 插入入库记录
                        string sql = @"INSERT INTO instocks (Code, MaterialId, WarehouseId, Quantity, Price, Amount, 
                                      Supplier, InTime, Operator, Remark, CreateTime) 
                                      VALUES (@Code, @MaterialId, @WarehouseId, @Quantity, @Price, @Amount, 
                                      @Supplier, @InTime, @Operator, @Remark, @CreateTime)";
                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Code", inStock.Code);
                            cmd.Parameters.AddWithValue("@MaterialId", inStock.MaterialId);
                            cmd.Parameters.AddWithValue("@WarehouseId", inStock.WarehouseId);
                            cmd.Parameters.AddWithValue("@Quantity", inStock.Quantity);
                            cmd.Parameters.AddWithValue("@Price", inStock.Price);
                            cmd.Parameters.AddWithValue("@Amount", inStock.Amount);
                            cmd.Parameters.AddWithValue("@Supplier", inStock.Supplier);
                            cmd.Parameters.AddWithValue("@InTime", inStock.InTime);
                            cmd.Parameters.AddWithValue("@Operator", inStock.Operator);
                            cmd.Parameters.AddWithValue("@Remark", inStock.Remark);
                            cmd.Parameters.AddWithValue("@CreateTime", inStock.CreateTime);
                            cmd.ExecuteNonQuery();
                        }

                        // 更新库存
                        UpdateStock(conn, transaction, inStock.MaterialId, inStock.WarehouseId, inStock.Quantity, inStock.Amount, true);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"入库操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        private static void UpdateStock(MySqlConnection conn, MySqlTransaction transaction, int materialId, int warehouseId, decimal quantity, decimal amount, bool isIn)
        {
            string checkSql = "SELECT Id, Quantity, Amount FROM stocks WHERE MaterialId=@MaterialId AND WarehouseId=@WarehouseId";
            using (var cmd = new MySqlCommand(checkSql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@MaterialId", materialId);
                cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                var result = cmd.ExecuteReader();
                
                bool exists = result.Read();
                int stockId = exists ? Convert.ToInt32(result["Id"]) : 0;
                decimal currentQty = exists ? Convert.ToDecimal(result["Quantity"]) : 0;
                decimal currentAmount = exists ? Convert.ToDecimal(result["Amount"]) : 0;
                result.Close();

                decimal newQty = isIn ? currentQty + quantity : currentQty - quantity;
                decimal newAmount = isIn ? currentAmount + amount : currentAmount - amount;

                if (exists)
                {
                    string updateSql = "UPDATE stocks SET Quantity=@Quantity, Amount=@Amount, UpdateTime=@UpdateTime WHERE Id=@Id";
                    using (var updateCmd = new MySqlCommand(updateSql, conn, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@Id", stockId);
                        updateCmd.Parameters.AddWithValue("@Quantity", newQty);
                        updateCmd.Parameters.AddWithValue("@Amount", newAmount);
                        updateCmd.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
                        updateCmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string insertSql = @"INSERT INTO stocks (MaterialId, WarehouseId, Quantity, Amount, UpdateTime) 
                                        VALUES (@MaterialId, @WarehouseId, @Quantity, @Amount, @UpdateTime)";
                    using (var insertCmd = new MySqlCommand(insertSql, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@MaterialId", materialId);
                        insertCmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                        insertCmd.Parameters.AddWithValue("@Quantity", newQty);
                        insertCmd.Parameters.AddWithValue("@Amount", newAmount);
                        insertCmd.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
                        insertCmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// 生成入库单号
        /// </summary>
        public static string GenerateInStockCode()
        {
            return $"IN{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
