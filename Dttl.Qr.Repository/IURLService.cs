using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IURLService
    {
        public Task<List<URLQRCode>> GetURLQRCodelList();

        public Task<URLQRCode> GetURLQRCodeListById(int Id);

        public Task<URLQRCode> AddURLQRCode(URLQRCode qRTemplate);

        public Task<URLQRCode> UpdateURLQRCode(URLQRCode qRTemplate);

        public Task<URLQRCode> DeleteURLQRCode(int Id);
    }
}