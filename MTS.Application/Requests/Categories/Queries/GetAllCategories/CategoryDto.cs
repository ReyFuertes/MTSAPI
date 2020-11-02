using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Categories.Queries.GetAllCategories
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
