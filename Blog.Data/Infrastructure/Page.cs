using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Infrastructure
{
    public class Page
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Page()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public Page(int pageNumber) : this(pageNumber, 10)
        {
        }

        public Page(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int Skip
        {
            get { return (PageNumber - 1) * PageSize; }
        }
    }

    public static class PagingExtensions
    {
        /// <summary>
        /// Extend IQueryable to simplify access to skip and take methods 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="page"></param>
        /// <returns>IQueryable with Skip and Take having been performed</returns>
        public static IQueryable<T> GetPage<T>(this IQueryable<T> queryable, Page page)
        {
            return queryable.Skip(page.Skip).Take(page.PageSize);

            // 100
            // PageSize = 10
            // Page => 10 primeros

            // Page 1 - 1 = 0
            // PageSize = 10 => SKIP 0

            // Select * FROM POSTS Where TRUE SKIP 0 LIMIT 10


            // Page 2 - 1 = 1
            // 1 * 10 => SKIP 10
            // Select * FROM POSTS Where TRUE SKIP 10 LIMIT 10

        }
    }
}
