using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface IQRDetailService
    {
        public Task<List<QRDetails>> GetQRDetailList();

        public Task<QRDetails> GetQRDetailListById(int Id);

        public Task<int> AddQRDetails(QRDetails qRDetails);

        public Task<int> UpdateQReDetails(QRDetails qRDetails);

        public Task<int> DeleteQRDetails(int Id);
    }
}