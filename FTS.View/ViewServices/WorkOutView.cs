using System.Reflection;
using TCreate = FTS.Service.DTOs.WorkOutCreationDto;
using TUpdate = FTS.Service.DTOs.WorkOutUpdateDto;
using TResult = FTS.Service.DTOs.WorkOutResultDto;
using TService = FTS.Service.Services.WorkOutService;

namespace FTS.View.ViewServices;

public class WorkOutView
{
    private readonly TService service;

    public WorkOutView()
    {
        service = new TService();
    }

    public async Task CreateAsync()
    {
        TCreate dto = new TCreate();

        PropertyInfo[] properties = typeof(TCreate).GetProperties();
        foreach (var property in properties)
        {
            Console.Write(property.Name + ": ");

            if (property.PropertyType == typeof(long))
                property.SetValue(dto, long.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(int))
                property.SetValue(dto, int.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(string))
                property.SetValue(dto, Console.ReadLine());
            else if (property.PropertyType == typeof(decimal))
                property.SetValue(dto, decimal.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(DateTime))
            {
                Console.Write("(dd mm yyyy): ");
                property.SetValue(dto, DateTime.Parse(Console.ReadLine()!));
            }
            else if (property.PropertyType == typeof(bool))
            {
                Console.Write("(true/false): ");
                property.SetValue(dto, bool.Parse(Console.ReadLine()!));
            }
            else if (property.PropertyType.IsEnum)
            {
                var names = Enum.GetNames(property.PropertyType);
                long queue = 1;
                foreach (var name in names)
                    Console.WriteLine($"{queue++}. {name}");

                if (int.TryParse(Console.ReadLine(), out int enumIndex) && enumIndex >= 0 && enumIndex < names.Length)
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names[enumIndex]));
                else
                    Console.WriteLine("Invalid enum value.");
            }
        }

        var result = await service.CreateAsync(dto);
        Console.WriteLine(result.Message);
    }

    public async Task UpdateAsync()
    {
        var checkDto = await service.GetByIdAsync(long.Parse(Console.ReadLine()!));
        if (checkDto.StatusCode != 200)
        {
            Console.WriteLine("This Id is not found");
            return;
        }

        TResult oldDto = checkDto.Data!;
        TUpdate dto = new TUpdate();

        PropertyInfo[] old = typeof(TResult).GetProperties();
        PropertyInfo[] properties = typeof(TCreate).GetProperties();
        int count = 0;
        foreach (var property in properties)
        {
            Console.Write($"{property.Name}: {old[count++].GetValue(oldDto)}\nNew: ");

            if (property.PropertyType == typeof(long))
                property.SetValue(dto, long.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(int))
                property.SetValue(dto, int.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(string))
                property.SetValue(dto, Console.ReadLine());
            else if (property.PropertyType == typeof(decimal))
                property.SetValue(dto, decimal.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(DateTime))
                property.SetValue(dto, DateTime.Parse(Console.ReadLine()!));
            else if (property.PropertyType.IsEnum)
            {
                var names = Enum.GetNames(property.PropertyType);
                long queue = 1;
                foreach (var name in names)
                    Console.WriteLine($"{queue++}. {name}");

                if (int.TryParse(Console.ReadLine(), out int enumIndex) && enumIndex >= 0 && enumIndex < names.Length)
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names[enumIndex]));
                else
                    Console.WriteLine("Invalid enum value.");
            }
        }

        var result = await service.Update(dto);
        Console.WriteLine(result.Message);
    }

    public async Task DeleteAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var checkId = await service.GetByIdAsync(id);
        if (checkId.StatusCode != 200)
        {
            Console.WriteLine(checkId.Message);
            return;
        }

        var result = await service.Delete(id);
        Console.WriteLine(result.Message);
    }

    public async Task GetByIdAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var result = await service.GetByIdAsync(id);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }

        var dto = result.Data;
        PropertyInfo[] properties = typeof(TResult).GetProperties();

        foreach (var property in properties)
            Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
    }

    public void GetAll()
    {
        var result = service.GetAll();

        if (result.StatusCode != 200)
            foreach (var dto in result.Data!)
            {
                PropertyInfo[] properties = typeof(TResult).GetProperties();
                foreach (var property in properties)
                    Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
                Console.WriteLine("----------");
            }
        else
            Console.WriteLine(result.Message);
    }
}
