using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class URLService : IURLService
    {
        private readonly DbContextClass _dbContext;

        public URLService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<URLQRCode>> GetURLQRCodelList()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@URLId", ""));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCode_Url"));

            return await _dbContext._uRLQRCodes
                  .FromSqlRaw(@"exec [SP_QRCode_Url] @URLId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<List<URLQRCode>> GetURLQRCodeListById(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@URLId", Id));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRCode_UrlId"));

            return await _dbContext._uRLQRCodes
                  .FromSqlRaw(@"exec [SP_QRCode_Url] @URLId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> AddURLQRCode(URLQRCode uRLQRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@URLId", ""));
            parameter.Add(new SqlParameter("@QRCodeId", uRLQRCode.QRCodeId));
            parameter.Add(new SqlParameter("@Title", uRLQRCode.Title));
            parameter.Add(new SqlParameter("@Url", uRLQRCode.Url));
            parameter.Add(new SqlParameter("@Type", "AddQRCode_Url"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode_UrlAddUpdate] @URLId,@QRCodeId,@Title,@Url,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateURLQRCode(URLQRCode uRLQRCode)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@URLId", uRLQRCode.URLId));
            parameter.Add(new SqlParameter("@QRCodeId", uRLQRCode.QRCodeId));
            parameter.Add(new SqlParameter("@Title", uRLQRCode.Title));
            parameter.Add(new SqlParameter("@Url", uRLQRCode.Url));
            parameter.Add(new SqlParameter("@Type", "UpdateQRCode_Url"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode_UrlAddUpdate] @URLId,@QRCodeId,@Title,@Url,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteURLQRCode(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@URLId", Id));
            parameter.Add(new SqlParameter("@Type", "DeleteQRCode_Url"));
            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRCode_Url] @URLId,@Type", parameter.ToArray()));
            return result;
        }
    }
}