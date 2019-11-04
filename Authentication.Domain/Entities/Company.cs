using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Authentication.Domain.Entities
{
    /// <summary>
    /// Class of Company
    /// </summary>
    [Table("Company")]
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }

        //public virtual List<Group> Group { get; set; }
        //public new virtual List<User> User { get; set; }
    }
}
