using Casino.AdminPortal.Shared.Functional.DataTransferObjects;
using Casino.AdminPortal.Shared.Infrastructure.DAC;

namespace Casino.AdminPortal.Shared.Functional.DataAccessComponents
{
    public interface ISampleDac : IDataAccessComponent
    {
        ISampleDto SampleMethod(ISampleDto sampleDto);
    }
}
