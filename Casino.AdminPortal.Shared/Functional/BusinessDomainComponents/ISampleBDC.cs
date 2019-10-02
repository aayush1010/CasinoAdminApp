using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Business;
using Casino.AdminPortal.Shared.Infrastructure.Common.OperationResult;

namespace Casino.AdminPortal.Shared.Functional.BusinessDomainComponents
{
    public interface ISampleBdc : IBusinessDomainComponent
    {
        OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto);
    }
}
