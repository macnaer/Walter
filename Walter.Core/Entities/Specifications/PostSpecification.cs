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
    public static class Posts
    {
        public class All : Specification<Post>
        {
            public All()
            {
                Query.Include(x => x.Category).OrderByDescending(x => x.Id);
            }
        }

        public class ById : Specification<Post>
        {
            public ById(int id)
            {
                Query.Where(p => p.Id == id).Include(x => x.Category);
            }
        }

        public class ByCategory : Specification<Post>
        {
            public ByCategory(int categoryId)
            {
                Query
                  .Include(x => x.Category)
                  .Where(c => c.CategoryId == categoryId).OrderByDescending(x => x.Id); ;
            }
        }
        public class Search : Specification<Post>
        {
            public Search(string searchString)
            {
                Query
                    .Include(p => p.Category)
                    .Where(p => p.Title.Contains(searchString) || p.FullText.Contains(searchString)).OrderByDescending(x => x.Id);
            }
        }
    }
}
