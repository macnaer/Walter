using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Walter.Core.Entities.Site;

namespace Walter.Core.Entities.Specifications
{
    public class Posts
    {
        public class ByCategory : Specification<Post>
        {
            public ByCategory(int categoryId)
            {
                Query
                  .Include(x => x.Category)
                  .Where(c => c.CategoryId == categoryId).OrderByDescending(x => x.Id); ;
            }
        }
    }
}
