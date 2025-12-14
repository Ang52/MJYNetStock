using MJYNetStock.Database;
using MJYNetStock.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 仓库数据访问类
    /// </summary>
    public class WarehouseDAL
    {
        /// <summary>
        /// 获取所有仓库
        /// </summary>
        public static DataTable GetAllWarehouses()
        {
            string sql = "SELECT * FROM warehouses ORDER BY Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        public static bool AddWarehouse(Warehouse warehouse)
        {
            string sql = @"INSERT INTO warehouses (Code, Name, Location, Manager, Remark, CreateTime) 
                          VALUES (@Code, @Name, @Location, @Manager, @Remark, @CreateTime)";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Code", warehouse.Code),
                new MySqlParameter("@Name", warehouse.Name),
                new MySqlParameter("@Location", warehouse.Location),
                new MySqlParameter("@Manager", warehouse.Manager),
                new MySqlParameter("@Remark", warehouse.Remark),
                new MySqlParameter("@CreateTime", warehouse.CreateTime));
            return result > 0;
        }

        /// <summary>
        /// 更新仓库
        /// </summary>
        public static bool UpdateWarehouse(Warehouse warehouse)
        {
            string sql = @"UPDATE warehouses SET Code=@Code, Name=@Name, Location=@Location, 
                          Manager=@Manager, Remark=@Remark WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Id", warehouse.Id),
                new MySqlParameter("@Code", warehouse.Code),
                new MySqlParameter("@Name", warehouse.Name),
                new MySqlParameter("@Location", warehouse.Location),
                new MySqlParameter("@Manager", warehouse.Manager),
                new MySqlParameter("@Remark", warehouse.Remark));
            return result > 0;
        }

        /// <summary>
        /// 删除仓库
        /// </summary>
        public static bool DeleteWarehouse(int id)
        {
            string sql = "DELETE FROM warehouses WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql, new MySqlParameter("@Id", id));
            return result > 0;
        }
    }
}
