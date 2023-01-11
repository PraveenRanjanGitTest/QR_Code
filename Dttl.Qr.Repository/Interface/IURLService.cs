using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface IURLService
    {
        public Task<List<UrlqrCode>> GetURLQRCodelList();
        public Task<UrlqrCode> GetURLQRCodeListById(int Id);

        public Task<int> AddURLQRCode(UrlqrCode uRLQRCode);

        public Task<int> UpdateURLQRCode(UrlqrCode uRLQRCode);

        public Task<int> DeleteURLQRCode(int Id);
    }
}