namespace Casino.AdminPortal.Shared
{
    public interface ISampleFacade : IFacade
    {
        OperationResult<ISampleDto> SampleMethod(ISampleDto sampleDto);
    }
}
