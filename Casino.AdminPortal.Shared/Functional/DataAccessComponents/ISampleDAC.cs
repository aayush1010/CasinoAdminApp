namespace Casino.AdminPortal.Shared
{
    public interface ISampleDAC : IDataAccessComponent
    {
        ISampleDTO SampleMethod(ISampleDTO sampleDTO);
    }
}
