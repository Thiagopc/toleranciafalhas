using Microsoft.EntityFrameworkCore;
using ToleranciaFalhas.domain.Interfaces.Repositories;
using ToleranciaFalhas.infra.Repositories.Db;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToleranciaFalhas.api.IoC
{
    public static class DependencyInversion
    {
        //public static void ConfigureIoc(this IServiceCollection services)
        //{

        //    //services.AddScoped

        //    services.AddDbContext<ConnectionDb>(options => {
        //        options.UseNpgsql("User ID=postgres;Password=sjaijsaJ923s_9232js;Host=instance.c3oq2okygbx8.us-east-1.rds.amazonaws.com;Port=5432;Database=estudo;\"");
        //    });


        //    services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        //}
    }
}
