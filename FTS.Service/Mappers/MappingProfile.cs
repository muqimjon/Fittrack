using AutoMapper;
using FTS.Domain.Entities;
using FTS.Service.DTOs;

namespace FTS.Service.Mappers;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ProgressRecord, ProgressRecordResultDto>();
        CreateMap<ProgressRecordCreationDto, ProgressRecord>();
        CreateMap<ProgressRecordUpdateDto, ProgressRecord>();

        CreateMap<User, UserResultDto>();
        CreateMap<UserCreationDto, User>();
        CreateMap<UserUpdateDto, User>();

        CreateMap<WorkOut, WorkOutResultDto>();
        CreateMap<WorkOutCreationDto, WorkOut>();
        CreateMap<WorkOutUpdateDto, WorkOut>();

        CreateMap<NuritionPlan, NuritionPlanResultDto>();
        CreateMap<NuritionPlanCreationDto, NuritionPlan>();
        CreateMap<NuritionPlanUpdateDto, NuritionPlan>();
    }
}
