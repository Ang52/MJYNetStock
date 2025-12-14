using MJYNetStock.Database;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 报表数据访问类
    /// </summary>
    public class ReportDAL
    {
        /// <summary>
        /// 获取月入库汇总
        /// </summary>
        public static DataTable GetMonthlyInStock(int year, int month)
        {
            string sql = @"SELECT m.Code AS MaterialCode, m.Name AS MaterialName, m.Spec AS MaterialSpec, 
                          m.Unit AS MaterialUnit, SUM(i.Quantity) AS TotalQuantity, SUM(i.Amount) AS TotalAmount
                          FROM instocks i
                          LEFT JOIN materials m ON i.MaterialId = m.Id
                          WHERE YEAR(i.InTime) = @Year AND MONTH(i.InTime) = @Month
                          GROUP BY i.MaterialId, m.Code, m.Name, m.Spec, m.Unit
                          ORDER BY TotalAmount DESC";
            return DbHelper.ExecuteQuery(sql,
                new MySqlParameter("@Year", year),
                new MySqlParameter("@Month", month));
        }

        /// <summary>
        /// 获取月出库汇总
        /// </summary>
        public static DataTable GetMonthlyOutStock(int year, int month)
        {
            string sql = @"SELECT m.Code AS MaterialCode, m.Name AS MaterialName, m.Spec AS MaterialSpec, 
                          m.Unit AS MaterialUnit, SUM(o.Quantity) AS TotalQuantity, SUM(o.Amount) AS TotalAmount
                          FROM outstocks o
                          LEFT JOIN materials m ON o.MaterialId = m.Id
                          WHERE YEAR(o.OutTime) = @Year AND MONTH(o.OutTime) = @Month
                          GROUP BY o.MaterialId, m.Code, m.Name, m.Spec, m.Unit
                          ORDER BY TotalAmount DESC";
            return DbHelper.ExecuteQuery(sql,
                new MySqlParameter("@Year", year),
                new MySqlParameter("@Month", month));
        }

        /// <summary>
        /// 获取当前库存汇总
        /// </summary>
        public static DataTable GetCurrentStock()
        {
            string sql = @"SELECT m.Code AS MaterialCode, m.Name AS MaterialName, m.Spec AS MaterialSpec, 
                          m.Unit AS MaterialUnit, w.Name AS WarehouseName, s.Quantity, s.Amount
                          FROM stocks s
                          LEFT JOIN materials m ON s.MaterialId = m.Id
                          LEFT JOIN warehouses w ON s.WarehouseId = w.Id
                          WHERE s.Quantity > 0
                          ORDER BY s.Amount DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取月度汇总统计
        /// </summary>
        public static DataTable GetMonthlySummary(int year, int month)
        {
            string sql = @"SELECT 
                          (SELECT COALESCE(SUM(Amount), 0) FROM instocks WHERE YEAR(InTime) = @Year AND MONTH(InTime) = @Month) AS InAmount,
                          (SELECT COALESCE(SUM(Amount), 0) FROM outstocks WHERE YEAR(OutTime) = @Year AND MONTH(OutTime) = @Month) AS OutAmount,
                          (SELECT COALESCE(SUM(Amount), 0) FROM stocks WHERE Quantity > 0) AS StockAmount";
            return DbHelper.ExecuteQuery(sql,
                new MySqlParameter("@Year", year),
                new MySqlParameter("@Month", month));
        }
    }
}
