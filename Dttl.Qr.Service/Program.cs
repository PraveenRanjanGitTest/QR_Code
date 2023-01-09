using Dttl.Qr.Data;
using Dttl.Qr.Repository.Implementation;
using Dttl.Qr.Repository.Interface;

namespace Dttl.Qr.Service
{
    public class Program
    {
        /*
         * Start Application
         */
        const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void Main(string[] args)
        {
            var buildedApp = BuildQRCodeGenerationApp(args);
            var application = ConfigureQRCodeGenerationApp(buildedApp);
            application.Run();
        }
        public static WebApplication BuildQRCodeGenerationApp(string[] args)
        {
           
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            services.AddCors(o => o.AddPolicy(MyAllowSpecificOrigins, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
           

            services.AddDbContext<DbContextClass>();

            services.AddScoped<IQRCodeService, QRCodeService>();
            services.AddScoped<IQRTemplateService, QRTemplateService>();
            services.AddScoped<IQRDetailService, QRDetailService>();
            services.AddScoped<IURLService, URLService>();
            services.AddScoped<IVCardService, VCardService>();
            services.AddScoped<ISearchService, SearchService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApplicationInsightsTelemetry();

            return builder.Build();
        }

        private static WebApplication ConfigureQRCodeGenerationApp(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("devCorsPolicy");
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            return app;
        }
    }
}