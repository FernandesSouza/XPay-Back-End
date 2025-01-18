using FluentValidation;
using Vanguardium.Domain.Interface;

namespace Vanguardium.Domain.Handlers.ValidationHandler;

public class Validate<T> : AbstractValidator<T>, IValidate<T> where T : class
{
    public Task<ValidationResponse> ValidationAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public ValidationResponse Validation(T entity)
    {
        throw new NotImplementedException();
    }
}