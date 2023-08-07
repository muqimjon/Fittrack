using FTS.Service.DTOs;
using FTS.Service.Services;
using FTS.View.GenericView;

namespace FTS.View.ServiceViews;

public class NuritionPlanServiceView : GenericView<NuritionPlanCreationDto, NuritionPlanUpdateDto, NuritionPlanResultDto, NuritionPlanService>
{
    public NuritionPlanServiceView(NuritionPlanService unitOfWork) : base(unitOfWork)
    {
    }
}
