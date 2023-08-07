using AutoMapper;
using FTS.Data.IRepositories.Common;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;
using FTS.Service.DTOs;
using FTS.Service.Helpers;
using FTS.Service.Interfaces;
using FTS.Service.Mappers;

namespace FTS.Service.Services;

public class ProgressRecordService : IServiceInterface<ProgressRecordCreationDto, ProgressRecordUpdateDto, ProgressRecordResultDto>
{
    private readonly IUnitOfWork unitOfWork;
    private IMapper mapper;
    public ProgressRecordService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(n => n.AddProfile<MappingProfile>()));
    }

    public async Task<Response<ProgressRecordResultDto>> CreateAsync(ProgressRecordCreationDto dto)
    {
        if ((await unitOfWork.UserRepository.GetByIdAsync(dto.UserId)) is null)
            return new Response<ProgressRecordResultDto>
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var mapped = mapper.Map<ProgressRecord>(dto);
        await unitOfWork.ProgressRecordRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<ProgressRecordResultDto>(mapped);

        return new Response<ProgressRecordResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<ProgressRecordResultDto>> Update(ProgressRecordUpdateDto dto)
    {
        var entity = await unitOfWork.ProgressRecordRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            return new Response<ProgressRecordResultDto>()
            {
                StatusCode = 403,
                Message = "This ProgressRecord is not found"
            };

        var mapped = mapper.Map(dto, entity);
        unitOfWork.ProgressRecordRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<ProgressRecordResultDto>(mapped);

        return new Response<ProgressRecordResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> Delete(long id)
    {
        var entity = await unitOfWork.ProgressRecordRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This ProgressRecord is not found"
            };

        unitOfWork.ProgressRecordRepository.Delete(entity);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<ProgressRecordResultDto>> GetByIdAsync(long id)
    {
        var entity = await unitOfWork.ProgressRecordRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<ProgressRecordResultDto>()
            {
                StatusCode = 404,
                Message = "This ProgressRecord is not found"
            };

        var result = mapper.Map<ProgressRecordResultDto>(entity);
        return new Response<ProgressRecordResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<ProgressRecordResultDto>> GetAll()
    {
        var ProgressRecords = unitOfWork.ProgressRecordRepository.GetAll();
        var resultProgressRecords = new List<ProgressRecordResultDto>();
        foreach (var ProgressRecord in ProgressRecords)
            resultProgressRecords.Add(mapper.Map<ProgressRecordResultDto>(ProgressRecord));

        return new Response<IEnumerable<ProgressRecordResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = resultProgressRecords
        };
    }
}