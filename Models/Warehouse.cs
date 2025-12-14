namespace MJYNetStock.Models
{
    /// <summary>
    /// 仓库实体类
    /// </summary>
    public class Warehouse
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; // 仓库编号
        public string Name { get; set; } = string.Empty; // 仓库名称
        public string Location { get; set; } = string.Empty; // 位置
        public string Manager { get; set; } = string.Empty; // 管理员
        public string Remark { get; set; } = string.Empty; // 备注
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
