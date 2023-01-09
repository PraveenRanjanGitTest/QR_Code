using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface IURLService
    {
        public Task<List<URLQRCode>> GetURLQRCodelList();

        public Task<List<URLQRCode>> GetURLQRCodeListById(int Id);

        public Task<int> AddURLQRCode(URLQRCode uRLQRCode);

        public Task<int> UpdateURLQRCode(URLQRCode uRLQRCode);

        public Task<int> DeleteURLQRCode(int Id);
    }
}