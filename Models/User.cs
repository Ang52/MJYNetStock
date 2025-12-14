namespace MJYNetStock.Models
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RealName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // 管理员、操作员
        public string Phone { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
