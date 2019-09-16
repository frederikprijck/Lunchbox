using Lunchbox.Models;

namespace Lunchbox.Controllers
{
    public class RecipeStepsController : BaseController<RecipeStep>
    {
        public RecipeStepsController(LunchboxContext context) : base(context)
        {
        }
    }
}
