using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Domain.Entities
{
    /// <summary>
    /// Class of Group
    /// </summary>
    [Table("Group")]
    public class Groups : BaseEntity 
    {
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        //public virtual Company Company { get; set; }

        public string Name { get; set; }
    }
}
