using Dttl.Qr.Model;

namespace Dttl.Qr.Repository
{
    public interface IQRTemplateService
    {
        public Task<List<QRTemplate>> GetQRTemplateList();

        public Task<List<QRTemplate>> GetQRTemplateListById(int Id);

        public Task<int> AddQRTemplate(QRTemplate qRTemplate);

        public Task<int> UpdateQRTemplate(QRTemplate qRTemplate);

        public Task<int> DeleteQRTemplate(int Id);
    }
}