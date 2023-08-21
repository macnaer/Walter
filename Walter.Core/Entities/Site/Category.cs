using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walter.Core.Interfaces;

namespace Walter.Core.Entities.Site
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return Name;
        }
    }
}
