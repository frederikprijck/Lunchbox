namespace Lunchbox.Models
{
    public class RecipeStep : AuditableDbEntity
    {
        public RecipeStep()
        {
        }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
    }
}
