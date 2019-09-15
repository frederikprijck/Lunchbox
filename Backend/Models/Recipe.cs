using System;
namespace Lunchbox.Models
{
    public class Recipe: AuditableDbEntity
    {
        public Recipe() 
        {

        }

        public string Title { get; set; }
        public int NbOfPersons { get; set; }
    }
}
