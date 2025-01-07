using MassTransit;

namespace Vanguardium.ApplicationService.RabbitMqServices.Consumers;

public sealed class GenerateReportConsumerService : IConsumer<string>
{
    public Task Consume(ConsumeContext<string> context)
    {
        throw new NotImplementedException();
    }
}