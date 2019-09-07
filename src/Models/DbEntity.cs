using System;
namespace Lunchbox.Models
{
    public abstract class DbEntity
    {
        public DbEntity()
        {
        }

        public int Id { get; set; }
    }
}
