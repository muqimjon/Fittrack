using AutoMapper;
using FTS.Data.IRepositories.Common;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;
using FTS.Service.DTOs;
using FTS.Service.Helpers;
using FTS.Service.Interfaces;
using FTS.Service.Mappers;

namespace FTS.Service.Services;

public class UserService : IServiceInterface<UserCreationDto, UserUpdateDto, UserResultDto>
{
    private readonly IUnitOfWork unitOfWork;
    private IMapper mapper;

    public UserService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(n => n.AddProfile<MappingProfile>()));
    }

    public async Task<Response<UserResultDto>> CreateAsync(UserCreationDto dto)
    {
        var check = await unitOfWork.UserRepository.GetByEmail(dto.Email);
        if (check is not null)
            return new Response<UserResultDto>()
            {
                StatusCode = 403,
                Message = "This User is already exist"
            };

        var mapped = mapper.Map<User>(dto);
        await unitOfWork.UserRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<UserResultDto>(mapped);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<UserResultDto>> Update(UserUpdateDto dto)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 403,
                Message = "This User is not found"
            };

        var mapped = mapper.Map(dto, entity);
        unitOfWork.UserRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<UserResultDto>(mapped);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> Delete(long id)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        unitOfWork.UserRepository.Delete(entity);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<UserResultDto>> GetByIdAsync(long id)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var result = mapper.Map<UserResultDto>(entity);
        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<UserResultDto>> GetAll()
    {
        var users = unitOfWork.UserRepository.GetAll();
        var resultUsers = new List<UserResultDto>();
        foreach (var user in users)
            resultUsers.Add(mapper.Map<UserResultDto>(user));

        return new Response<IEnumerable<UserResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = resultUsers
        };
    }
}
