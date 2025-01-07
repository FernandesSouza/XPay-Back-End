using MassTransit;

namespace Vanguardium.RabbitMqServices;

public sealed class ReaderBankStatementConsumerService : IConsumer<string>
{
    public Task Consume(ConsumeContext<string> context)
    {
        throw new NotImplementedException();
    }
}