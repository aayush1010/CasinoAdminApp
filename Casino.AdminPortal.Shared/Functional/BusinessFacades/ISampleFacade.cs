namespace Casino.AdminPortal.Shared
{
    public interface ISampleFacade : IFacade
    {
        OperationResult<ISampleDTO> SampleMethod(ISampleDTO sampleDTO);
    }
}
