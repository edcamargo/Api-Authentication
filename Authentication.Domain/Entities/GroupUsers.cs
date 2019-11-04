using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Domain.Entities
{
    /// <summary>
    /// Class of GroupUsers
    /// </summary>
    [Table("GroupUsers")]
    public class GroupUsers : BaseEntity
    {
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        //public virtual Groups Group { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        //public new virtual Users User { get; set; }
    }
}
