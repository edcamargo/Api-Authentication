using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Domain.Entities
{
    /// <summary>
    /// Class of Users
    /// </summary>
    [Table("User")]
    public class Users : BaseEntity
    {
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }

    [NotMapped]
    public class UserLogin
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PassWord { get; set; }
    }
}
