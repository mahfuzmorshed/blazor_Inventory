using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Shared.Data
{
    public static class PagedResultExtension
    {
        public static PagedResultT<T> GetPaged<T>(this IQueryable<T> query,int page,int pageSize)where T : class
        {
            var result=new PagedResultT<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount=(int)Math.Ceiling(pageCount);
            var skip=(page-1)*pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();
            return result;
        }
    }
}
