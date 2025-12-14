using MJYNetStock.Database;
using MJYNetStock.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace MJYNetStock.DAL
{
    /// <summary>
    /// 物料数据访问类
    /// </summary>
    public class MaterialDAL
    {
        /// <summary>
        /// 获取所有物料
        /// </summary>
        public static DataTable GetAllMaterials()
        {
            string sql = "SELECT * FROM materials ORDER BY Id DESC";
            return DbHelper.ExecuteQuery(sql);
        }

        /// <summary>
        /// 根据条件查询物料
        /// </summary>
        public static DataTable SearchMaterials(string keyword)
        {
            string sql = @"SELECT * FROM materials 
                          WHERE Code LIKE @Keyword OR Name LIKE @Keyword OR Spec LIKE @Keyword 
                          ORDER BY Id DESC";
            return DbHelper.ExecuteQuery(sql, new MySqlParameter("@Keyword", $"%{keyword}%"));
        }

        /// <summary>
        /// 添加物料
        /// </summary>
        public static bool AddMaterial(Material material)
        {
            string sql = @"INSERT INTO materials (Code, Name, Spec, Unit, Category, Price, Remark, CreateTime) 
                          VALUES (@Code, @Name, @Spec, @Unit, @Category, @Price, @Remark, @CreateTime)";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Code", material.Code),
                new MySqlParameter("@Name", material.Name),
                new MySqlParameter("@Spec", material.Spec),
                new MySqlParameter("@Unit", material.Unit),
                new MySqlParameter("@Category", material.Category),
                new MySqlParameter("@Price", material.Price),
                new MySqlParameter("@Remark", material.Remark),
                new MySqlParameter("@CreateTime", material.CreateTime));
            return result > 0;
        }

        /// <summary>
        /// 更新物料
        /// </summary>
        public static bool UpdateMaterial(Material material)
        {
            string sql = @"UPDATE materials SET Code=@Code, Name=@Name, Spec=@Spec, Unit=@Unit, 
                          Category=@Category, Price=@Price, Remark=@Remark WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql,
                new MySqlParameter("@Id", material.Id),
                new MySqlParameter("@Code", material.Code),
                new MySqlParameter("@Name", material.Name),
                new MySqlParameter("@Spec", material.Spec),
                new MySqlParameter("@Unit", material.Unit),
                new MySqlParameter("@Category", material.Category),
                new MySqlParameter("@Price", material.Price),
                new MySqlParameter("@Remark", material.Remark));
            return result > 0;
        }

        /// <summary>
        /// 删除物料
        /// </summary>
        public static bool DeleteMaterial(int id)
        {
            string sql = "DELETE FROM materials WHERE Id=@Id";
            int result = DbHelper.ExecuteNonQuery(sql, new MySqlParameter("@Id", id));
            return result > 0;
        }
    }
}
