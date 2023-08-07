using AutoMapper;
using FTS.Data.IRepositories.Common;
using FTS.Data.Repositories.Common;
using FTS.Domain.Entities;
using FTS.Service.DTOs;
using FTS.Service.Helpers;
using FTS.Service.Interfaces;
using FTS.Service.Mappers;

namespace FTS.Service.Services;

public class NuritionPlanService : IServiceInterface<NuritionPlanCreationDto, NuritionPlanUpdateDto, NuritionPlanResultDto>
{
    private readonly IUnitOfWork unitOfWork;
    private IMapper mapper;
    public NuritionPlanService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(n => n.AddProfile<MappingProfile>()));
    }

    public async Task<Response<NuritionPlanResultDto>> CreateAsync(NuritionPlanCreationDto dto)
    {
        if (unitOfWork.UserRepository.GetByIdAsync(dto.UserId) is null)
            return new Response<NuritionPlanResultDto>
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var mapped = mapper.Map<NuritionPlan>(dto);
        await unitOfWork.NuritionPlanRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<NuritionPlanResultDto>(mapped);

        return new Response<NuritionPlanResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<NuritionPlanResultDto>> Update(NuritionPlanUpdateDto dto)
    {
        var entity = await unitOfWork.NuritionPlanRepository.GetByIdAsync(dto.Id);
        if (entity is null)
            return new Response<NuritionPlanResultDto>()
            {
                StatusCode = 403,
                Message = "This NuritionPlan is not found"
            };

        var mapped = mapper.Map(dto, entity);
        unitOfWork.NuritionPlanRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<NuritionPlanResultDto>(mapped);

        return new Response<NuritionPlanResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> Delete(long id)
    {
        var entity = await unitOfWork.NuritionPlanRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This NuritionPlan is not found"
            };

        unitOfWork.NuritionPlanRepository.Delete(entity);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<NuritionPlanResultDto>> GetByIdAsync(long id)
    {
        var entity = await unitOfWork.NuritionPlanRepository.GetByIdAsync(id);
        if (entity is null)
            return new Response<NuritionPlanResultDto>()
            {
                StatusCode = 404,
                Message = "This NuritionPlan is not found"
            };

        var result = mapper.Map<NuritionPlanResultDto>(entity);
        return new Response<NuritionPlanResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<NuritionPlanResultDto>> GetAll()
    {
        var NuritionPlans = unitOfWork.NuritionPlanRepository.GetAll();
        var resultNuritionPlans = new List<NuritionPlanResultDto>();
        foreach (var NuritionPlan in NuritionPlans)
            resultNuritionPlans.Add(mapper.Map<NuritionPlanResultDto>(NuritionPlan));

        return new Response<IEnumerable<NuritionPlanResultDto>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = resultNuritionPlans
        };
    }
}
