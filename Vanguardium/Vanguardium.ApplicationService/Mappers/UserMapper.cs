using Vanguardium.ApplicationService.Dtos.AddresDtos.Request;
using Vanguardium.ApplicationService.Dtos.UserDtos.Request;
using Vanguardium.ApplicationService.Dtos.UserDtos.Response;
using Vanguardium.ApplicationService.Interfaces;
using Vanguardium.Domain.Entities;

namespace Vanguardium.ApplicationService.Mappers;

public sealed class UserMapper() : IUserMapper
{
    public User DomainToRequest(UserRequestDto userRequestDto) =>
        new()
        {
            Name = userRequestDto.Name,
            Document = userRequestDto.Document,
            Email = userRequestDto.Email,
            CreationDate = userRequestDto.CreationDate,
            Password = userRequestDto.Password,
            Status = true,
            Role = userRequestDto.Role,
            Gender = userRequestDto.Gender,
            Telephone = userRequestDto.Telephone,
            DateOfBirth = userRequestDto.DateOfBirth,
            Address = SingleToAddresRequest(userRequestDto.Address!)
        };

    public List<UserSimpleResponse> DtoToResponse(List<User> users) =>
        users.Select(SingleToResponse).ToList();

    private UserSimpleResponse SingleToResponse(User user) =>
        new()
        {
            Name = user.Name,
            Document = user.Document,
            Status = user.Status,
            Gender = user.Gender,
            CreationDate = user.CreationDate
        };

    private Address SingleToAddresRequest(AddresRegisterRequestDto addresRegisterRequestDto) =>
        new()
        {
            Street = addresRegisterRequestDto.Street,
            District = addresRegisterRequestDto.District,
            PostalCode = addresRegisterRequestDto.PostalCode,
            City = addresRegisterRequestDto.City,
            Country = addresRegisterRequestDto.Country,
            State = addresRegisterRequestDto.State,
        };
}