using MJYNetStock.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 库存数据访问类
    /// </summary>
    public class StockDAL
    {
        /// <summary>
        /// 获取所有库存
        /// </summary>
        public static DataTable GetAllStocks()
        {
            string sql = @"SELECT s.*, m.Code AS MaterialCode, m.Name AS MaterialName, m.Spec AS MaterialSpec, 
                          m.Unit AS MaterialUnit, w.Name AS WarehouseName
                          FROM stocks s
                          LEFT JOIN materials m ON s.MaterialId = m.Id
                          LEFT JOIN warehouses w ON s.WarehouseId = w.Id
                          WHERE s.Quantity > 0
                          ORDER BY s.Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 按条件查询库存
        /// </summary>
        public static DataTable SearchStocks(string? materialCode, string? materialName, int? warehouseId)
        {
            string sql = @"SELECT s.*, m.Code AS MaterialCode, m.Name AS MaterialName, m.Spec AS MaterialSpec, 
                          m.Unit AS MaterialUnit, w.Name AS WarehouseName
                          FROM stocks s
                          LEFT JOIN materials m ON s.MaterialId = m.Id
                          LEFT JOIN warehouses w ON s.WarehouseId = w.Id
                          WHERE s.Quantity > 0";
            
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(materialCode))
            {
                sql += " AND m.Code LIKE @MaterialCode";
                parameters.Add(new MySqlParameter("@MaterialCode", $"%{materialCode}%"));
            }

            if (!string.IsNullOrEmpty(materialName))
            {
                sql += " AND m.Name LIKE @MaterialName";
                parameters.Add(new MySqlParameter("@MaterialName", $"%{materialName}%"));
            }

            if (warehouseId.HasValue && warehouseId.Value > 0)
            {
                sql += " AND s.WarehouseId = @WarehouseId";
                parameters.Add(new MySqlParameter("@WarehouseId", warehouseId.Value));
            }

            sql += " ORDER BY s.Id DESC";
            return DbHelper.ExecuteQuery(sql, parameters.ToArray());
        }
    }
}
