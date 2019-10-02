using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Shared.Functional.DataTransferObjects
{ 
    public interface ISampleDto : IDto
    {
        string SampleProperty { get; set; }
    }
}
