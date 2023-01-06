using Dttl.Qr.Data;
using Dttl.Qr.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dttl.Qr.Repository
{
    public class QRDetailService : IQRDetailService
    {
        private readonly DbContextClass _dbContext;

        public QRDetailService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<QRDetails>> GetQRDetailList()
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRDetailId", ""));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRDetails"));

            return await _dbContext._qRDetails
                  .FromSqlRaw(@"exec [SP_QRDetails] @QRDetailId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<List<QRDetails>> GetQRDetailListById(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRDetailId", Id));
            parameter.Add(new SqlParameter("@Type", "FetchDataQRDetailsId"));

            return await _dbContext._qRDetails
                  .FromSqlRaw(@"exec [SP_QRDetails] @QRDetailId, @Type", parameter.ToArray()).ToListAsync();
        }

        public async Task<int> AddQRDetails(QRDetails qRDetails)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRDetailId", ""));
            parameter.Add(new SqlParameter("@QRCodeId", qRDetails.QRCodeId));
            parameter.Add(new SqlParameter("@QRName", qRDetails.QRName));
            parameter.Add(new SqlParameter("@QRImage", qRDetails.QRImage));
            parameter.Add(new SqlParameter("@Type", "AddQRDetails"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRDetailsAddUpdate] @QRDetailId,@QRCodeId,@QRName,@QRImage,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> UpdateQReDetails(QRDetails qRDetails)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRDetailId", qRDetails.QRDetailId));
            parameter.Add(new SqlParameter("@QRCodeId", qRDetails.QRCodeId));
            parameter.Add(new SqlParameter("@QRName", qRDetails.QRName));
            parameter.Add(new SqlParameter("@QRImage", qRDetails.QRImage));
            parameter.Add(new SqlParameter("@Type", "UpdateQRDetails"));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec [SP_QRDetailsAddUpdate] @QRDetailId,@QRCodeId,@QRName,@QRImage,@Type", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteQRDetails(int Id)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@QRDetailId", Id));
            parameter.Add(new SqlParameter("@Type", "DeleteQRDetails"));

            var result = await Task.Run(() => _dbContext.Database
                        .ExecuteSqlRawAsync(@"exec [SP_QRDetails] @QRDetailId,@Type", parameter.ToArray()));
            return result;
        }
    }
}