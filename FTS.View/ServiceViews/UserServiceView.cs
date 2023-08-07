using FTS.Service.DTOs;
using FTS.Service.Services;

namespace FTS.View.ServiceViews;

public class UserServiceView
{
    private readonly UserService userService;
    public UserServiceView()
    {
        userService = new UserService();
    }

    public async Task CreateAsync()
    {
        UserCreationDto dto = new UserCreationDto();

        Console.Write("FirstName: ");
        dto.FirstName = Console.ReadLine()!;

        Console.Write("LastName: ");
        dto.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        dto.Email = Console.ReadLine()!;

        Console.Write("Address: ");
        dto.Address = Console.ReadLine()!;

        Console.Write("Password: ");
        dto.Password = Console.ReadLine()!;

        var result = await userService.CreateAsync(dto);
        Console.WriteLine(result.Message);
    }

    public async Task UpdateAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var checkId = await userService.GetByIdAsync(id);
        if (checkId.StatusCode != 200)
        {
            Console.WriteLine(checkId.Message);
            return;
        }

        await Update(id);
    }

    public async Task Update(long id)
    {
        UserResultDto olduser = (await userService.GetByIdAsync(id)).Data;
        UserUpdateDto dto = new UserUpdateDto();

        Console.Write("FirstName: ");
        Console.WriteLine(olduser!.FirstName);
        Console.Write("New: ");
        dto.FirstName = Console.ReadLine()!;

        Console.Write("LastName: ");
        Console.WriteLine(olduser.LastName);
        Console.Write("New: ");
        dto.LastName = Console.ReadLine()!;

        Console.Write("Email: ");
        Console.WriteLine(olduser.Email);
        Console.Write("New: ");
        dto.Email = Console.ReadLine()!;

        Console.Write("Address: ");
        Console.WriteLine(olduser.Address);
        Console.Write("New: ");
        dto.Address = Console.ReadLine()!;

        Console.Write("Password: ");
        Console.WriteLine(olduser.Password);
        Console.Write("New: ");
        dto.Password = Console.ReadLine()!;

        var result = await userService.Update(dto);
        Console.WriteLine(result.Message);
    }

    public async Task<UserResultDto> Update(UserUpdateDto user)
    {
        var result = await userService.Update(user);
        Console.WriteLine(result.Message);
        return result.Data ?? null!;
    }

    public async Task DeleteAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var checkId = await userService.GetByIdAsync(id);
        if (checkId.StatusCode != 200)
        {
            Console.WriteLine(checkId.Message);
            return;
        }

        var result = await userService.Delete(id);
        Console.WriteLine(result.Message);
    }

    public async Task GetByIdAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var result = await userService.GetByIdAsync(id);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }

        var user = result.Data;
        Console.WriteLine($"Id: {user!.Id} | " +
            $"Name: {user.FirstName} | " +
            $"DateOfBirth: {user.LastName} | " +
            $"Email: {user.Email} | " +
            $"Address: {user.Address}");
    }

    public void GetAll()
    {
        var result = userService.GetAll();
        if (!result.Data!.Any())
        {
            Console.WriteLine("This table is empty");
            return;
        }

        var users = result.Data;
        foreach (var user in users!)
            Console.WriteLine($"Id: {user.Id} | " +
                $"Name: {user.FirstName} | " +
                $"DateOfBirth: {user.LastName} | " +
                $"Email: {user.Email} | " +
                $"Address: {user.Address}");
    }
}
