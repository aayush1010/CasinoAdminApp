using Casino.AdminPortal.Shared.Infrastructure.Common.CommonAttributes;

namespace Casino.AdminPortal.Shared.Infrastructure.Common.Enums
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DacType
    {

        [QualifiedTypeName("Casino.AdminPortal.Data.dll", "Casino.AdminPortal.Data.SampleDAC")]
        SampleDac = 1,
        [QualifiedTypeName("Casino.AdminPortal.Data.dll", "Casino.AdminPortal.Data.UserDAC")]
        UserDac = 2,
    }
}
