using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Dttl.Qr.Repository.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository.Implementation
{
    public class QRCodeService : IQRCodeService
    {
        private readonly DbContextClass _dbContext;

        public QRCodeService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QrCode>> GetQRCodeList()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRCodeId", ""));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCode"));

            return await _dbContext._qrCode
                  .FromSqlRaw(@"exec [SP_QRCode] @QRCodeId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<List<QrCode>> GetQRCodeListById(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRCodeId", Id));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCodeId"));

            return await _dbContext._qrCode
                  .FromSqlRaw(@"exec [SP_QRCode] @QRCodeId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> AddQRCodes(QrCode qRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRCodeId", ""));
            parameter.Add(new SqlParameter("@TemplateId", qRCode.TemplateId));
            parameter.Add(new SqlParameter("@QRType", qRCode.QRType));
            parameter.Add(new SqlParameter("@Static", qRCode.Static));
            parameter.Add(new SqlParameter("@Dynamic", qRCode.Dynamic));
            parameter.Add(new SqlParameter("@IsActive", ""));
            parameter.Add(new SqlParameter("@CreatedBy", qRCode.CreatedBy));
            parameter.Add(new SqlParameter("@ModifiedBy", ""));
            parameter.Add(new SqlParameter("@Type", "AddQRCode"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCodeAddUpdate] @QRCodeId,@TemplateId,@QRType,@Static,@Dynamic,@IsActive,@CreatedBy,@ModifiedBy,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateQRCode(QrCode qRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRCodeId", qRCode.QRCodeId));
            parameter.Add(new SqlParameter("@TemplateId", qRCode.TemplateId));
            parameter.Add(new SqlParameter("@QRType", qRCode.QRType));
            parameter.Add(new SqlParameter("@Static", qRCode.Static));
            parameter.Add(new SqlParameter("@Dynamic", qRCode.Dynamic));
            parameter.Add(new SqlParameter("@IsActive", qRCode.IsActive));
            parameter.Add(new SqlParameter("@CreatedBy", ""));
            parameter.Add(new SqlParameter("@ModifiedBy", qRCode.ModifiedBy));
            parameter.Add(new SqlParameter("@Type", "UpdateQRCode"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCodeAddUpdate] @QRCodeId,@TemplateId,@QRType,@Static,@Dynamic,@IsActive,@CreatedBy,@ModifiedBy,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteQRCodes(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRCodeId", Id));
            parameter.Add(new SqlParameter("@Type", "DeleteQRCodeId"));
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode] @QRCodeId,@Type", parameter.ToArray()));
            return result;
        }
    }
}