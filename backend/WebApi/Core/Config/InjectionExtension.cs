
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using Microsoft.AspNetCore.Identity;
using Core.Base;
using Core.Service;

namespace Core.Config
{
    public static class InjectionExtension
    {
        public static void DependencyInjectionRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INhanCongRepository, NhanCongRepository>();
            services.AddScoped<INKSLKRepository, NKSLKRepository>(); 
            services.AddScoped<IThongKeRepository, ThongKeRepository>();
            // huynh them san pham 
            services.AddScoped<ISanPhamRepository, SanPhamRepository>();
            // huynh them cong viec
            services.AddScoped<ICongViecRepository, CongViecRepository>();
        }
    }
}
