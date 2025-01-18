using Vanguardium.Domain.Entities;
using Vanguardium.Domain.Enums;
using Vanguardium.Infra.ORM.Context;

namespace Vanguardium.Infra.ORM.Seeds;

//TODO: TERMINAR O SEEDING

public class GenerateSeeding(ApplicationContext dbContext)
{
    private static readonly HashSet<string> GeneratedDocuments = [];


    private async Task CreateAllSeeds()
    {
        var company = await CreateCompanySeed();

        if (company.Count != 0)
        {
            var userList = await CreateUserSeed();

            var statusCreating = userList.Count > 0 && await CreateUserCompanyRelationship(company, userList);
        }
    }

    private async Task<bool> CreateUserCompanyRelationship(List<Company> companies, List<User> users)
    {
        var userArray = users.ToArray();
        var userLists = PartitionInChunksOf(userArray, 200);

        var taskOne = CompanyRelationShip(companies[0].Id, userLists[0].ToList());
        var taskTwo = CompanyRelationShip(companies[1].Id, userLists[1].ToList());
        var taskThree = CompanyRelationShip(companies[2].Id, userLists[2].ToList());

        await Task.WhenAll(taskOne, taskTwo, taskThree);

        return true;
    }

    private async Task<bool> CompanyRelationShip(long companyId, List<User> users)
    {
        foreach (var userCompany in users.Select(itens => new UserCompany
                 {
                     UserId = itens.Id,
                     CompanyId = companyId
                 }))
        {
            dbContext.Add(userCompany);
        }

        return await dbContext.SaveChangesAsync() > 0;
    }

    private async Task<List<User>> CreateUserSeed()
    {
        var userList = new List<User>();

        for (var i = 0; i < 600; i++)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = $"User{i}",
                Document = GenerateUniqueCpf(),
                Email = $"user{i}@example.com",
                Password = $"{i}10391",
                CreationDate = DateTime.Now,
                DateOfBirth = "",
                Gender = Gender.Men,
                Status = true,
                AddressId = 0,
                Telephone = null,
                Role = ERole.Employee
            };
            userList.Add(user);
            dbContext.Add(user);
        }

        await dbContext.SaveChangesAsync();
        return userList;
    }

    private async Task<List<Company>> CreateCompanySeed()
    {
        var companyList = new List<Company>();

        for (var i = 0; i < 3; i++)
        {
            var company = new Company
            {
                Id = i,
                CorporateName = $"Company {i}",
                Document = $"6885098800011{i}",
                AddressId = null,
                ContactNumber = null,
                Balance = 1000000
            };
            companyList.Add(company);
            dbContext.Add(company);
        }

        await dbContext.SaveChangesAsync();
        return companyList;
    }

    private static string GenerateUniqueCpf()
    {
        string cpf;
        do
        {
            cpf = GenerateValidCpf();
        } while (!GeneratedDocuments.Add(cpf));

        return cpf;
    }

    private static string GenerateValidCpf()
    {
        var random = new Random();
        var numbers = new int[9];
        for (var i = 0; i < 9; i++)
        {
            numbers[i] = random.Next(0, 9);
        }

        var sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += numbers[i] * (10 - i);
        }

        int firstVerifier = sum % 11;
        firstVerifier = firstVerifier < 2 ? 0 : 11 - firstVerifier;

        sum = 0;
        for (var i = 0; i < 9; i++)
        {
            sum += numbers[i] * (11 - i);
        }

        sum += firstVerifier * 2;
        var secondVerifier = sum % 11;
        secondVerifier = secondVerifier < 2 ? 0 : 11 - secondVerifier;

        return string.Join("", numbers) + firstVerifier + secondVerifier;
    }

    private static List<T[]> PartitionInChunksOf<T>(T[] items, int count)
    {
        var chunks = new List<T[]>();
        var current = 0;
        while (current < items.Length)
        {
            chunks.Add(items.Skip(current).Take(count).ToArray());
            current += count;
        }

        return chunks;
    }
}