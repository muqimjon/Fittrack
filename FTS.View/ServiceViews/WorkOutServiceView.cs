using FTS.Service.DTOs;
using FTS.Service.Services;
using FTS.View.GenericView;

namespace FTS.View.ServiceViews;

public class WorkOutServiceView : GenericView<WorkOutCreationDto, WorkOutUpdateDto, WorkOutResultDto, WorkOutService>
{
    public WorkOutServiceView(WorkOutService WorkOutService) : base(WorkOutService)
    {
    }
}
