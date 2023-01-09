using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly DbContextClass _dbContext;

        public SearchService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FilterData>> GetSearchByFilter(SearchFilter searchFilter)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@FromDate", searchFilter.FromDate));
            parameter.Add(new SqlParameter("@ToDate", searchFilter.ToDate));
            parameter.Add(new SqlParameter("@TemplateName", searchFilter.TemplateName));
            parameter.Add(new SqlParameter("@Type", "SearchData"));

            var result = await Task.Run(() => _dbContext._filterData
           .FromSqlRaw(@"exec [QR_Search] @FromDate, @ToDate, @TemplateName, @Type", parameter.ToArray()).ToListAsync());
            return result;
        }
    }
}