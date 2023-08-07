using AutoMapper;
using FTS.Data.IRepositories.Common;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;
using FTS.Service.DTOs;
using FTS.Service.Helpers;
using FTS.Service.Interfaces;
using FTS.Service.Mappers;

namespace FTS.Service.Services;

public class WorkOutService : IServiceInterface<WorkOutCreationDto, WorkOutUpdateDto, WorkOutResultDto>
{
    private readonly IUnitOfWork unitOfWork;
    private IMapper mapper;
    public WorkOutService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(n => n.AddProfile<MappingProfile>()));
    }

    public async Task<Response<WorkOutResultDto>> CreateAsync(WorkOutCreationDto dto)
    {
        if (unitOfWork.UserRepository.GetByIdAsync(dto.UserId) is null)
            return new Response<WorkOutResultDto>
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var mapped = mapper.Map<WorkOut>(dto);
        await unitOfWork.WorkOutRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<WorkOutResultDto>(mapped);

        return new Response<WorkOutResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<WorkOutResultDto>> Update(WorkOutUpdateDto dto)
    {
        var entity = await unitOfWork.WorkOutRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            return new Response<WorkOutResultDto>()
            {
                StatusCode = 403,
                Message = "This WorkOut is not found"
            };

        var mapped = mapper.Map(dto, entity);
        unitOfWork.WorkOutRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<WorkOutResultDto>(mapped);

        return new Response<WorkOutResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> Delete(long id)
    {
        var entity = await unitOfWork.WorkOutRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This WorkOut is not found"
            };

        unitOfWork.WorkOutRepository.Delete(entity);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<WorkOutResultDto>> GetByIdAsync(long id)
    {
        var entity = await unitOfWork.WorkOutRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<WorkOutResultDto>()
            {
                StatusCode = 404,
                Message = "This WorkOut is not found"
            };

        var result = mapper.Map<WorkOutResultDto>(entity);
        return new Response<WorkOutResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<WorkOutResultDto>> GetAll()
    {
        var WorkOuts = unitOfWork.WorkOutRepository.GetAll();
        var resultWorkOuts = new List<WorkOutResultDto>();
        foreach (var WorkOut in WorkOuts)
            resultWorkOuts.Add(mapper.Map<WorkOutResultDto>(WorkOut));

        return new Response<IEnumerable<WorkOutResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = resultWorkOuts
        };
    }
}
