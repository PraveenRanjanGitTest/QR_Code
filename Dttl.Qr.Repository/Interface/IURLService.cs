using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface IURLService
    {
        public Task<List<URLQRCode>> GetURLQRCodelList();

<<<<<<< HEAD
        public Task<UrlqrCode> GetURLQRCodeListById(int Id);
=======
        public Task<List<URLQRCode>> GetURLQRCodeListById(int Id);
>>>>>>> d62eaafbb20a2a0ef18004aa8aa9c4bc6e1083e8

        public Task<int> AddURLQRCode(URLQRCode uRLQRCode);

        public Task<int> UpdateURLQRCode(URLQRCode uRLQRCode);

        public Task<int> DeleteURLQRCode(int Id);
    }
}