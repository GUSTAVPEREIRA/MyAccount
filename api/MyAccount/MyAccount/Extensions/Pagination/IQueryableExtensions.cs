using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccount.Extensions.Pagination
{
    public static class IQueryableExtensions
    {
        public async static Task<PageResult<T>> GetPageResultAsync<T>(this IQueryable<T> query, int currentPage, int size) where T : class
        {
            var skip = (currentPage - 1) * size;
            var rowCount = await query.CountAsync();
            var results = await query.Skip(skip).Take(size).ToListAsync();
            var resultCount = results.Count;

            var pageResult = new PageResult<T>
            {
                CurrentPage = currentPage,
                PageCount = (int)Math.Ceiling(decimal.Divide(rowCount, size)),
                PageSize = size,
                RowCount = rowCount,
                Results = results,
                resultCount = resultCount
            };

            return pageResult;
        }
    }
}