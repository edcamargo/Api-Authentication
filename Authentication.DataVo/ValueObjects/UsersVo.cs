using Authentication.Domain.Entities;
using System;
using System.Runtime.Serialization;

namespace Authentication.DataVo.ValueObjects
{
    public class UsersVo
    {
        [DataContract]
        public class UserVo
        {
            [DataMember(Order = 1, Name = "Id", IsRequired = false)]
            public int Id { get; set; }

            [DataMember(Order = 2, Name = "CompanyId", IsRequired = false)]
            public int CompanyId { get; set; }

            [DataMember(Order = 3, Name = "Company", IsRequired = false)]
            public virtual CompanyVo Company { get; set; }

            [DataMember(Order = 4, Name = "Name", IsRequired = true)]
            public string Name { get; set; }

            [DataMember(Order = 5, Name = "Login", IsRequired = true)]
            public string Login { get; set; }

            [DataMember(Order = 6, Name = "PassWord", IsRequired = true)]
            public string PassWord { get; set; }

            [DataMember(Order = 7, Name = "Email", IsRequired = true)]
            public string Email { get; set; }

            [DataMember(Order = 8, Name = "Status", IsRequired = true)]
            public bool Status { get; set; }

            [DataMember(Order = 9, Name = "DateInclude", IsRequired = true)]
            public DateTime DateInclude { get; set; }

            [DataMember(Order = 10, Name = "User", IsRequired = true)]
            public string User { get; set; }
        }

        /// <summary>
        /// Class Login Access
        /// </summary>
        [DataContract]
        public class UserLoginVo
        {
            //[DataMember(Order = 1, Name = "Id")]
            //public int Id { get; set; }

            [DataMember(Order = 2, Name = "Login", IsRequired = true)]
            public string Login { get; set; }

            [DataMember(Order = 3, Name = "PassWord", IsRequired = true)]
            public string PassWord { get; set; }

            /*
            [DataMember(Order = 3, Name = "ReturnMenu", IsRequired = false)]
            public bool ReturnMenu { get; set; } = true;
            */
        }
    }
}
