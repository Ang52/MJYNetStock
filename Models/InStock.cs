namespace MJYNetStock.Models
{
    /// <summary>
    /// 入库单实体类
    /// </summary>
    public class InStock
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; // 入库单号
        public int MaterialId { get; set; }
        public string MaterialCode { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; } = string.Empty;
        public decimal Quantity { get; set; } // 入库数量
        public decimal Price { get; set; } // 单价
        public decimal Amount { get; set; } // 金额
        public string Supplier { get; set; } = string.Empty; // 供应商
        public DateTime InTime { get; set; } = DateTime.Now; // 入库时间
        public string Operator { get; set; } = string.Empty; // 操作员
        public string Remark { get; set; } = string.Empty;
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
