using Dttl.Qr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
