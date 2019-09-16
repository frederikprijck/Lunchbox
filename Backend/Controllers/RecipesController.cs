using System.Collections.Generic;
using System.Linq;
using Lunchbox.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
