namespace MJYNetStock.Models
{
    /// <summary>
    /// 物料实体类
    /// </summary>
    public class Material
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; // 物资编号
        public string Name { get; set; } = string.Empty; // 物资名称
        public string Spec { get; set; } = string.Empty; // 规格
        public string Unit { get; set; } = string.Empty; // 计量单位
        public string Category { get; set; } = string.Empty; // 分类
        public decimal Price { get; set; } = 0; // 单价
        public string Remark { get; set; } = string.Empty; // 备注
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
