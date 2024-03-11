using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using ToleranciaFalhas.domain.Interfaces.Event;
using ToleranciaFalhas.domain.Interfaces.Factory;
using ToleranciaFalhas.domain.Interfaces.Repositories;
using ToleranciaFalhas.domain.Interfaces.Services;
using ToleranciaFalhas.domain.Services;
using ToleranciaFalhas.infra.Factory;
using ToleranciaFalhas.infra.Repositories;
using ToleranciaFalhas.infra.Repositories.Db;
using ToleranciaFalhas.infra.Repositories.Db.Dapper;
using ToleranciaFalhas.infra.SqsEvent;

namespace ToleranciaFalhas.infra.IoC
{
    public static class InversaodeControle
    {
        public static void ConfigureIoC(this IServiceCollection service)
        {
            service.AddDbContext<ConnectionDb>((options) => {
                options.UseNpgsql("User ID=postgres;Password=sjaijsaJ923s_9232js;Host=instance.c3oq2okygbx8.us-east-1.rds.amazonaws.com;Port=5432;Database=estudo;");
            });

            

            service.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            service.AddScoped(typeof(IBaseReadRepository<>), typeof(ConnectionDbReader<>));
            service.AddScoped<IClienteService, ClienteService>();
            service.AddScoped<IProdutoService, ProdutoService>();
            service.AddScoped<IConnectionDbReaderFactory, ConnectionDbReaderFactory>();


            #region sqs
            var sqsConfig = new AmazonSQSConfig
            {
                // RegionEndpoint = RegionEndpoint.SAEast1 // Defina a região do seu Amazon SQS
                RegionEndpoint = RegionEndpoint.USEast1 // Defina a região do seu Amazon SQS
            };

            var basic = new BasicAWSCredentials("AKIAVRUVVOBUW2DTPFX6", "LUhH6P85nF/Veg5NqPMtpG1qbZsduFNC4nAPaiY2");
            var sqsClient = new AmazonSQSClient(basic, sqsConfig);           

            service.AddSingleton<IAmazonSQS>(sp =>
            {
                return new AmazonSQSClient(sqsConfig);
            });

            service.AddScoped<ISqsEvent, SqsEvent.SqsEvent>();

            #endregion
        }
    }
}
