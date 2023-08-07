using FTS.Service.DTOs;
using FTS.Service.Services;
using FTS.View.GenericView;

namespace FTS.View.ServiceViews;

public class ProgressRecordServiceView : GenericView<ProgressRecordCreationDto, ProgressRecordUpdateDto, ProgressRecordResultDto, ProgressRecordService>
{
    public ProgressRecordServiceView(ProgressRecordService ProgressRecordService) : base(ProgressRecordService)
    {
    }
}
