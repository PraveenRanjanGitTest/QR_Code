using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IQRCodeService
    {
        public Task<List<QrCode>> GetQRCodeList();

        public Task<List<QrCode>> GetQRCodeListById(int Id);

        public Task<int> AddQRCodes(QrCode qRCode);

        public Task<int> UpdateQRCode(QrCode qRCode);

        public Task<int> DeleteQRCodes(int Id);
    }
}