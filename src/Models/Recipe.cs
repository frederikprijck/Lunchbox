using System;
namespace Lunchbox.Models
{
    public class Recipe: DbEntity
    {
        public Recipe() 
        {

        }

        public string Title { get; set; }
        public int NbOfPersons { get; set; }
    }
}
