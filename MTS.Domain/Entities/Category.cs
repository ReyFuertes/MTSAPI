﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
