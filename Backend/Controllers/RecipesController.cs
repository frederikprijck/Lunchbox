using Lunchbox.Models;
using Microsoft.AspNetCore.Mvc;
namespace Lunchbox.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : BaseController<Recipe>
    {
        public RecipesController(LunchboxContext context) : base(context)
        {
        }
    }
}
