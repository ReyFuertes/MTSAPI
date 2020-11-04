using System;
using System.Collections.Generic;
using System.Text;

namespace MTS.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageFileId { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
