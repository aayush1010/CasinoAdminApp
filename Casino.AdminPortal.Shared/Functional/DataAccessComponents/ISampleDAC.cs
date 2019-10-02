namespace Casino.AdminPortal.Shared
{
    public interface ISampleDac : IDataAccessComponent
    {
        ISampleDto SampleMethod(ISampleDto sampleDto);
    }
}
