using System;
namespace Lunchbox.Models
{
    public class AuditableDbEntity : DbEntity
    {
        public AuditableDbEntity()
        {
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
