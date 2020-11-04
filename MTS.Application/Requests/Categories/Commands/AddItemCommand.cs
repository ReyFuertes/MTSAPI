using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Categories.Commands
{
    public class AddItemCommand : IRequest<string>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public IFormFile File { get; set; }
    }
}
