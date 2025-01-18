using Vanguardium.Domain.Handlers.ValidationHandler;

namespace Vanguardium.Domain.Interface;

public interface IValidate<T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
    ValidationResponse Validation(T entity);
}