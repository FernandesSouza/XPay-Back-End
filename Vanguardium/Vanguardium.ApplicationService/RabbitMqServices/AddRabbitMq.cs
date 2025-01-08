using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vanguardium.ApplicationService.RabbitMqServices.Consumers;
using Vanguardium.RabbitMqServices;

namespace Vanguardium.ApplicationService.RabbitMqServices
{
    public static class AddRabbitMq
    {
        public static void RabbitMqImplement(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("RabbitPort");
            const string exchangeType = "topic";

            services.AddMassTransit(busConfiguration =>
            {
                busConfiguration.AddConsumer<TransferValidateConsumerService>();
                busConfiguration.AddConsumer<GenerateReportConsumerService>();
                busConfiguration.AddConsumer<ReaderBankStatementConsumerService>();

                busConfiguration.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(new Uri(connectionString!), host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("validate-transfer-queue", endpoint =>
                    {
                        endpoint.Bind("bank-exchange", bind =>
                        {
                            bind.ExchangeType = exchangeType;
                            bind.RoutingKey = "transfer.validate";
                        });

                        endpoint.ConfigureConsumer<TransferValidateConsumerService>(ctx);
                    });

                    cfg.ReceiveEndpoint("generate-report-queue", endpoint =>
                    {
                        endpoint.Bind("bank-exchange", bind =>
                        {
                            bind.ExchangeType = exchangeType;
                            bind.RoutingKey = "report.generate";
                        });

                        endpoint.ConfigureConsumer<GenerateReportConsumerService>(ctx);
                    });

                    cfg.ReceiveEndpoint("read-bank-statement-queue", endpoint =>
                    {
                        endpoint.Bind("bank-exchange", bind =>
                        {
                            bind.ExchangeType = exchangeType;
                            bind.RoutingKey = "statement.read";
                        });

                        endpoint.ConfigureConsumer<ReaderBankStatementConsumerService>(ctx);
                    });
                });
            });
        }
    }
}