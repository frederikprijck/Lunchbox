using System;
using System.Collections.Generic;
using Lunchbox.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lunchbox.Controllers
{
    public class RecipeStepsController : BaseController<RecipeStep>
    {
        public RecipeStepsController(LunchboxContext context) : base(context)
        {
        }
    }
}
