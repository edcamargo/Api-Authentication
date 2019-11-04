using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.DataVo.ValueObjects
{
    [DataContract]
    public class GroupsVo
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = false)]
        public int Id { get; set; }

        [DataMember(Order = 2, Name = "CompanyId", IsRequired = false)]
        public int CompanyId { get; set; }

        /*
        [DataMember(Name = "Company")]
        public virtual CompanyVo Company { get; set; }
        */

        [DataMember(Order = 4, Name = "Name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Order = 5, Name = "DateInclude", IsRequired = true)]
        public DateTime DateInclude { get; set; }

        [DataMember(Order = 6, Name = "User", IsRequired = true)]
        public string User { get; set; }
    }
}
