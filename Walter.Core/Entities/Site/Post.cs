using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Interfaces;

namespace Walter.Core.Entities.Site
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FullText { get; set; } = string.Empty;
        public string PublishDate { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = "Default.png";
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
