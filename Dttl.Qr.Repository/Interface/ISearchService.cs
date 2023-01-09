using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface ISearchService
    {
        public Task<List<FilterData>> GetSearchByFilter(SearchFilter searchFilter);
    }
}