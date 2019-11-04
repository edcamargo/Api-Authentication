using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.DataVo.ValueObjects
{
    [DataContract]
    public class CompanyVo
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = false)]
        public int Id { get; set; }

        [DataMember(Order = 2, Name = "Name", IsRequired = true)]
        public string Name { get; set; }

        [DataMember(Order = 3, Name = "Cnpj", IsRequired = true)]
        public string Cnpj { get; set; }

        [DataMember(Order = 4, Name = "DateInclude", IsRequired = true)]
        public DateTime DateInclude { get; set; }

        [DataMember(Order = 5, Name = "User", IsRequired = true)]
        public string User { get; set; }
    }
}
