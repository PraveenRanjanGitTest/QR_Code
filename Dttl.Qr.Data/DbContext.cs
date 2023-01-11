using Dttl.Qr.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dttl.Qr.Data
{
    public class DbContextClass : Microsoft.EntityFrameworkCore.DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("CS"));
        }

        public DbSet<QRTemplate> _qRTemplates { get; set; }
        public DbSet<QrCode> _qrCode { get; set; }
        public DbSet<VCardQRCode> _vCardQRCodes { get; set; }
        public DbSet<UrlqrCode> _uRLQRCodes { get; set; }
        public DbSet<QRDetails> _qRDetails { get; set; }
        public DbSet<FilterData> _filterData { get; set; }
    }
}