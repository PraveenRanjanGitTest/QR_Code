using Dttl.Qr.Model;

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