namespace Casino.AdminPortal.Shared
{
    public interface ISampleBDC : IBusinessDomainComponent
    {
        OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO);
    }
}
