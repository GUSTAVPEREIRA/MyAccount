using System.Collections.Generic;

namespace MyAccount.Extensions.Pagination
{
    public class PageResult<T> : PageResultBase where T : class
    {
        public ICollection<T> Results { get; set; }

        public PageResult()
        {
            Results = new List<T>();
        }
    }
}