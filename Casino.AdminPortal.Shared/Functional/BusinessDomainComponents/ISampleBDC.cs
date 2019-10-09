namespace Casino.AdminPortal.Shared
{
    public interface ISampleBdc : IBusinessDomainComponent
    {
        OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto);
    }
}
