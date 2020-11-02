using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.Application.Requests.Categories.Queries.GetAllCategories;

namespace MTS.API.Controllers
{
    public class CategoriesController : AuthorizedControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await Mediator.Send(new GetAllCategoriesQuery()));
        }
    }
}
    