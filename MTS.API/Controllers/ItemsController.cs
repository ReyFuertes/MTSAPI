using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.Application.Requests.Categories.Commands;

namespace MTS.API.Controllers
{
    public class ItemsController : AuthorizedControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemCommand command)
        {
            return null;
        }
    }
}
