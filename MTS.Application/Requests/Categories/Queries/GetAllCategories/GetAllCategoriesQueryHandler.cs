using MediatR;
using MTS.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MTS.Application.Requests.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, CategoryListVm>
    {
        private readonly MTSDbContext _context;

        public GetAllCategoriesQueryHandler(MTSDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryListVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _context.Categories
                .Select(c => new CategoryDto() { 
                    Id = c.Id,
                    Name = c.Name,
                    Items = c.Items.Select(i => new ItemDto()
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Description = i.Name,
                        Price = i.Price
                    }).ToList()
                }).ToListAsync();


            var list = new CategoryListVm()
            {
                Categories = await categories
            };

            return list;
        }
    }
}
