using Casino.AdminPortal.Shared.Functional.BusinessDomainComponents;
using Casino.AdminPortal.Shared.Functional.BusinessFacades;
using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.Business;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.Common.OperationResult;
using Casino.AdminPortal.Shared.Infrastructure.Facades;

namespace Casino.AdminPortal.BusinessFacades.Facades
{
    public class SampleFacade : FacadeBase, ISampleFacade
    {
        public SampleFacade() : base(FacadeType.SampleFacade)
        {

        }

        public OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto)
        {
            ISampleBdc sampleBdc = (ISampleBdc)BdcFactory.Instance.Create(BdcType.SampleBdc);//because bdcfactory is singleton, as we cant create object with new keyword
            return sampleBdc.SampleMethod(sampleDto);
        }
    }
}
