using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IVCardService
    {
        public Task<List<VCardQRCode>> GetVCardList();

        public Task<List<VCardQRCode>> GetVCardById(int Id);

        public Task<int> AddVCard(VCardQRCode vCardQRCode);

        public Task<int> UpdateVCarde(VCardQRCode vCardQRCode);

        public Task<int> DeleteVCard(int Id);
    }
}