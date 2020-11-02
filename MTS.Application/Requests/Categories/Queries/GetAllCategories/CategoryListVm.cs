using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Categories.Queries.GetAllCategories
{
    public class CategoryListVm
    {
        public IList<CategoryDto> Categories { get; set; }
    }
}
