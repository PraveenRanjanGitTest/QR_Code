using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TemplateId", ""));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRTemplate"));

            return await _dbContext._qRTemplates
                  .FromSqlRaw(@"exec SP_QRCode @TemplateId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<List<QRTemplate>> GetQRTemplateListById(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TemplateId", Id));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRTemplateId"));

            return await _dbContext._qRTemplates
                  .FromSqlRaw(@"exec SP_QRCode @TemplateId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> AddQRTemplate(QRTemplate qRTemplate)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TemplateId", ""));
            parameter.Add(new SqlParameter("@TemplateName", qRTemplate.TemplateName));
            parameter.Add(new SqlParameter("@Height", qRTemplate.Height));
            parameter.Add(new SqlParameter("@Width", qRTemplate.Width));
            parameter.Add(new SqlParameter("@ForeColor", qRTemplate.ForeColor));
            parameter.Add(new SqlParameter("@BackgroundColor", qRTemplate.BackgroundColor));
            parameter.Add(new SqlParameter("@Logo", qRTemplate.Logo));
            parameter.Add(new SqlParameter("@IsActive", ""));
            parameter.Add(new SqlParameter("@IsApproved", ""));
            parameter.Add(new SqlParameter("@CreatedBy", qRTemplate.CreatedBy));
            parameter.Add(new SqlParameter("@ModifiedBy", ""));
            parameter.Add(new SqlParameter("@Type", "AddQRTemplate"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCodeAddUpdate] @TemplateId,@TemplateName,@Height,@Width,@ForeColor,@BackgroundColor,@Logo,@IsActive,@IsApproved,@CreatedBy,@ModifiedBy,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateQRTemplate(QRTemplate qRTemplate)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TemplateId", qRTemplate.TemplateId));
            parameter.Add(new SqlParameter("@TemplateName", qRTemplate.TemplateName));
            parameter.Add(new SqlParameter("@Height", qRTemplate.Height));
            parameter.Add(new SqlParameter("@Width", qRTemplate.Width));
            parameter.Add(new SqlParameter("@ForeColor", qRTemplate.ForeColor));
            parameter.Add(new SqlParameter("@BackgroundColor", qRTemplate.BackgroundColor));
            parameter.Add(new SqlParameter("@Logo", qRTemplate.Logo));
            parameter.Add(new SqlParameter("@IsActive", true));
            parameter.Add(new SqlParameter("@IsApproved", true));
            parameter.Add(new SqlParameter("@CreatedBy", ""));
            parameter.Add(new SqlParameter("@ModifiedBy", qRTemplate.ModifiedBy));
            parameter.Add(new SqlParameter("@Type", "UpdateQRTemplate"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCodeAddUpdate] @TemplateId,@TemplateName,@Height,@Width,@ForeColor,@BackgroundColor,@Logo,@IsActive,@IsApproved,@CreatedBy,@ModifiedBy,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteQRTemplate(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@TemplateId", Id));
            parameter.Add(new SqlParameter("@Type", "DeleteQRTemplate"));
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode] @TemplateId,@Type", parameter.ToArray()));
            return result;
        }
    }
}