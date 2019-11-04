using System;
using System.Runtime.Serialization;

namespace Authentication.DataVo.ValueObjects
{
    [DataContract]
    public class GroupUsersVo
    {
        [DataMember(Order = 1, Name = "Id", IsRequired = false)]
        public int Id { get; set; }

        [DataMember(Order = 2, Name = "GroupId", IsRequired = false)]
        public int GroupId { get; set; }

        //[DataMember(Order = 3, Name = "Groups", IsRequired = false)]
        //public virtual GroupsVo Groups { get; set; }

        [DataMember(Order = 3, Name = "UserId", IsRequired = false)]
        public int UserId { get; set; }

        //[DataMember(Order = 5, Name = "User", IsRequired = true)]
        //public virtual UsersVo.UserVo Users { get; set; }

        [DataMember(Order = 4, Name = "DateInclude", IsRequired = true)]
        public DateTime DateInclude { get; set; }
    }
}
