using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Common.OperationResult;
using Casino.AdminPortal.Shared.Infrastructure.Facades;

namespace Casino.AdminPortal.Shared.Functional.BusinessFacades
{
    public interface ISampleFacade : IFacade
    {
        OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto);
    }
}
