using Dttl.Qr.Model;

namespace Dttl.Qr.Repository.Interface
{
    public interface IQRTemplateService
    {
        public Task<List<QRTemplate>> GetQRTemplateList();

        public Task<QRTemplate> GetQRTemplateListById(int Id);

        public Task<int> AddQRTemplate(QRTemplate qRTemplate);

        public Task<int> UpdateQRTemplate(QRTemplate qRTemplate);

        public Task<int> DeleteQRTemplate(int Id);
    }
}