namespace MJYNetStock.Models
{
    /// <summary>
    /// 库存实体类
    /// </summary>
    public class Stock
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        public string MaterialSpec { get; set; } = string.Empty;
        public string MaterialUnit { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public decimal Quantity { get; set; } // 库存数量
        public decimal Amount { get; set; } // 库存金额
        public DateTime UpdateTime { get; set; } = DateTime.Now; // 更新时间
    }
}
