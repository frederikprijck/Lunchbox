using System;
namespace Lunchbox.Models
{
    public class Ingredient : AuditableDbEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int MeasurementId { get; set; }
        public Measurement Measurement { get; set; }

        public int Amount { get; set; }
    }
}
