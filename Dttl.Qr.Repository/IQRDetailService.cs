using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IQRDetailService
    {
        public Task<List<QRDetails>> GetQRDetailList();

        public Task<QRDetails> GetQRDetailListById(int Id);

        public Task<QRDetails> AddQRDetails(QRDetails qRTemplate);

        public Task<QRDetails> UpdateQReDetails(QRDetails qRTemplate);

        public Task<QRDetails> DeleteQRDetails(int Id);
    }
}