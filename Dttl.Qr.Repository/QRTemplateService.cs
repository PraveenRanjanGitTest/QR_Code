using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class QRTemplateService : IQRTemplateService
    {
        private readonly DbContextClass _dbContext;

        public QRTemplateService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QRTemplate>> GetQRTemplateList()
        {
            return await _dbContext._qRTemplates.ToListAsync();
        }

        public async Task<QRTemplate> GetQRTemplateListById(int Id)
        {
            return await _dbContext._qRTemplates.FirstOrDefaultAsync(m => m.TemplateId == Id);
        }

        public async Task<QRTemplate> AddQRTemplate(QRTemplate qRTemplate)
        {
            var result = await _dbContext.AddAsync(qRTemplate);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QRTemplate> UpdateQRTemplate(QRTemplate qRTemplate)
        {
            var result = _dbContext._qRTemplates.Update(qRTemplate);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<QRTemplate> DeleteQRTemplate(int Id)
        {
            var result = await _dbContext._qRTemplates.FindAsync(Id);
            _dbContext._qRTemplates.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}