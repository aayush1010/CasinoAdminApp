using Casino.AdminPortal.Shared;

namespace Casino.AdminPortal.BusinessFacades
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
