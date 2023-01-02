using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IQRTemplateService
    {
        public Task<List<QRTemplate>> GetQRTemplateList();
        public Task<QRTemplate> GetQRTemplateListById(int Id);
        public Task<QRTemplate> AddQRTemplate(QRTemplate qRTemplate);
        public Task<QRTemplate> UpdateQRTemplate(QRTemplate qRTemplate);
        public Task<QRTemplate> DeleteQRTemplate(int Id);
    }
}
