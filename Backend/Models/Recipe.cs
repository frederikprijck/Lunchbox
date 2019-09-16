using System;
using System.Collections.Generic;

namespace Lunchbox.Models
{
    public class Recipe: AuditableDbEntity
    {
        public Recipe() 
        {

        }

        public string Title { get; set; }
        public int NbOfPersons { get; set; }
        public List<RecipeStep> RecipeSteps { get; set; }
    }
}
