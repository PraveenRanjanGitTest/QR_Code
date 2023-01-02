using Dttl.Qr.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dttl.Qr.Repository
{
    public interface IVCardService
    {
        public Task<List<VCardQRCode>> GetVCardList();
        public Task<VCardQRCode> GetVCardById(int Id);
        public Task<VCardQRCode> AddVCard(VCardQRCode vCardQRCode);
        public Task<VCardQRCode> UpdateVCarde(VCardQRCode vCardQRCode);
        public Task<VCardQRCode> DeleteVCard(int Id);

    }
}
