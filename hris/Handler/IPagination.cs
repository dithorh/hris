using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hris.Handler
{
    public interface IPagination<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter">filter apply by user</param>
        /// <param name="initialPage">initial page</param>
        /// <param name="pageSize">ammount of records for each page</param>
        /// <param name="totalRecords">total of recrods</param>
        /// <param name="recordsFiltered">total records filtered when filter applied</param>
        /// <returns>list all categories found</returns>
        IQueryable<T> GetPaginated(string filter, int initialPage, int pageSize, out int totalRecords, out int recordsFiltered);
    }
}
