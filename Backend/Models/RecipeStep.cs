namespace Lunchbox.Models
{
    public class RecipeStep : AuditableDbEntity
    {
        public RecipeStep()
        {
        }

        public Recipe Recipe { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }
}
