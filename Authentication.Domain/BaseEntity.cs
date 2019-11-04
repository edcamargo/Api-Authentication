using System;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateInclude { get; set; } = DateTime.Now;
        public string User { get; set; }

        public bool Compare(object obj)
        {
            var compareTo = obj as BaseEntity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }
    }
}
