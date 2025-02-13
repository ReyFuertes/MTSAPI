﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Application.Requests.Categories.Queries.GetAllCategories
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
