using MassTransit;
using Vanguardium.ApplicationService.Dtos.RabbitDtos;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Enums;
using Vanguardium.Infra.Interfaces;

namespace Vanguardium.ApplicationService.RabbitMqServices.Consumers;

public sealed class TransferValidateConsumerService(
    ITransferMapper transferMapper,
    ITransferRepository transferRepository,
    IUserRepository userRepository) : IConsumer<TransferMessage>
{
    public async Task Consume(ConsumeContext<TransferMessage> context)
    {
        var message = context.Message;
        var transfer = transferMapper.DomainToRequest(message);
        //TEMPO PARA SIMULAR VALIDAÇÕES DA TRANSFERENCIA
        await Task.Delay(TimeSpan.FromSeconds(10));
        var sender = await userRepository.FindByPredicateAsync(c => c.Id == transfer.SenderId);
        var recipient = await userRepository.FindByPredicateAsync(c => c.Id == transfer.RecipientId);

        sender!.Balance -= transfer.ValueForTransfer;
        recipient!.Balance += transfer.ValueForTransfer;

        await userRepository.UpdateAsync(sender);
        await userRepository.UpdateAsync(recipient);
        transfer.StatusTransfer = StatusTransfer.Finished;
        await transferRepository.SaveAsync(transfer);
    }
}