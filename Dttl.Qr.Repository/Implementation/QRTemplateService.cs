using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
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

        public async Task<int> AddQRTemplate(QRTemplate qRTemplate)
        {
            var _qrtemplate = new QRTemplate();
            _qrtemplate.TemplateName = qRTemplate.TemplateName;
            _qrtemplate.Height = qRTemplate.Height;
            _qrtemplate.Width = qRTemplate.Width;
            _qrtemplate.ForeColor = qRTemplate.ForeColor;
            _qrtemplate.BackgroundColor = qRTemplate.BackgroundColor;
            _qrtemplate.Logo = qRTemplate.Logo;
            _qrtemplate.TemplatePreview = qRTemplate.TemplatePreview;
            _qrtemplate.ActiveStatus = 1;
            _qrtemplate.ApprovedStatus = 3;
            _qrtemplate.CreatedBy = qRTemplate.CreatedBy;
            _qrtemplate.CreatedDate = DateTime.UtcNow;

            var result = await _dbContext.AddAsync(_qrtemplate);
            await _dbContext.SaveChangesAsync();
            return result.Entity.TemplateId;
        }

        public async Task<int> UpdateQRTemplate(QRTemplate qRTemplate)
        {
            var _qrtemplate = _dbContext._qRTemplates.FirstOrDefault(t => t.TemplateId == qRTemplate.TemplateId);
            _qrtemplate.TemplateId = qRTemplate.TemplateId;
            _qrtemplate.ActiveStatus = qRTemplate.ActiveStatus;
            _qrtemplate.ModifiedBy = qRTemplate.ModifiedBy;
            _qrtemplate.ModifiedDate = DateTime.UtcNow;

            var result = _dbContext._qRTemplates.Update(_qrtemplate);
            await _dbContext.SaveChangesAsync();
            return result.Entity.TemplateId;
        }

        public async Task<int> DeleteQRTemplate(int Id)
        {
            var result = await _dbContext._qRTemplates.FindAsync(Id);
            _dbContext._qRTemplates.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result.TemplateId;
        }
    }
}