using MJYNetStock.Database;
using MJYNetStock.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 出库数据访问类
    /// </summary>
    public class OutStockDAL
    {
        /// <summary>
        /// 获取所有出库记录
        /// </summary>
        public static DataTable GetAllOutStocks()
        {
            string sql = @"SELECT o.*, m.Code AS MaterialCode, m.Name AS MaterialName, w.Name AS WarehouseName
                          FROM outstocks o
                          LEFT JOIN materials m ON o.MaterialId = m.Id
                          LEFT JOIN warehouses w ON o.WarehouseId = w.Id
                          ORDER BY o.Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 按条件查询出库记录
        /// </summary>
        public static DataTable SearchOutStocks(string? code, string? materialName, DateTime? startDate, DateTime? endDate)
        {
            string sql = @"SELECT o.*, m.Code AS MaterialCode, m.Name AS MaterialName, w.Name AS WarehouseName
                          FROM outstocks o
                          LEFT JOIN materials m ON o.MaterialId = m.Id
                          LEFT JOIN warehouses w ON o.WarehouseId = w.Id
                          WHERE 1=1";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(code))
            {
                sql += " AND o.Code LIKE @Code";
                parameters.Add(new MySqlParameter("@Code", $"%{code}%"));
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                sql += " AND m.Name LIKE @MaterialName";
                parameters.Add(new MySqlParameter("@MaterialName", $"%{materialName}%"));
            }

            if (startDate.HasValue)
            {
                sql += " AND o.OutTime >= @StartDate";
                parameters.Add(new MySqlParameter("@StartDate", startDate.Value));
            }

            if (endDate.HasValue)
            {
                sql += " AND o.OutTime <= @EndDate";
                parameters.Add(new MySqlParameter("@EndDate", endDate.Value.AddDays(1)));
            }

            sql += " ORDER BY o.Id DESC";
            return DbHelper.ExecuteQuery(sql, parameters.ToArray());
        }

        /// <summary>
        /// 添加出库记录
        /// </summary>
        public static bool AddOutStock(OutStock outStock)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 检查库存是否足够
                        string checkSql = "SELECT Quantity FROM stocks WHERE MaterialId=@MaterialId AND WarehouseId=@WarehouseId";
                        using (var checkCmd = new MySqlCommand(checkSql, conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@MaterialId", outStock.MaterialId);
                            checkCmd.Parameters.AddWithValue("@WarehouseId", outStock.WarehouseId);
                            var result = checkCmd.ExecuteScalar();
                            
                            if (result == null || Convert.ToDecimal(result) < outStock.Quantity)
                            {
                                MessageBox.Show("库存不足，无法出库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                        // 插入出库记录
                        string sql = @"INSERT INTO outstocks (Code, MaterialId, WarehouseId, Quantity, Price, Amount, 
                                      Receiver, OutTime, Operator, Remark, CreateTime) 
                                      VALUES (@Code, @MaterialId, @WarehouseId, @Quantity, @Price, @Amount, 
                                      @Receiver, @OutTime, @Operator, @Remark, @CreateTime)";
                        using (var cmd = new MySqlCommand(sql, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Code", outStock.Code);
                            cmd.Parameters.AddWithValue("@MaterialId", outStock.MaterialId);
                            cmd.Parameters.AddWithValue("@WarehouseId", outStock.WarehouseId);
                            cmd.Parameters.AddWithValue("@Quantity", outStock.Quantity);
                            cmd.Parameters.AddWithValue("@Price", outStock.Price);
                            cmd.Parameters.AddWithValue("@Amount", outStock.Amount);
                            cmd.Parameters.AddWithValue("@Receiver", outStock.Receiver);
                            cmd.Parameters.AddWithValue("@OutTime", outStock.OutTime);
                            cmd.Parameters.AddWithValue("@Operator", outStock.Operator);
                            cmd.Parameters.AddWithValue("@Remark", outStock.Remark);
                            cmd.Parameters.AddWithValue("@CreateTime", outStock.CreateTime);
                            cmd.ExecuteNonQuery();
                        }

                        // 更新库存
                        UpdateStock(conn, transaction, outStock.MaterialId, outStock.WarehouseId, outStock.Quantity, outStock.Amount);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"出库操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 更新库存
        /// </summary>
        private static void UpdateStock(MySqlConnection conn, MySqlTransaction transaction, int materialId, int warehouseId, decimal quantity, decimal amount)
        {
            string updateSql = @"UPDATE stocks SET Quantity = Quantity - @Quantity, Amount = Amount - @Amount, 
                                UpdateTime = @UpdateTime WHERE MaterialId=@MaterialId AND WarehouseId=@WarehouseId";
            using (var cmd = new MySqlCommand(updateSql, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@MaterialId", materialId);
                cmd.Parameters.AddWithValue("@WarehouseId", warehouseId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@UpdateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 生成出库单号
        /// </summary>
        public static string GenerateOutStockCode()
        {
            return $"OUT{DateTime.Now:yyyyMMddHHmmss}";
        }
    }
}
