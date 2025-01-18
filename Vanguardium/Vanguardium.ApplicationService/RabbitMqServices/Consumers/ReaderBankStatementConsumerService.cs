using MassTransit;

namespace Vanguardium.ApplicationService.RabbitMqServices.Consumers;

public class ReaderBankStatementConsumerService : IConsumer<string>
{
    public Task Consume(ConsumeContext<string> context)
    {
        throw new NotImplementedException();
    }
}