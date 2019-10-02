using Casino.AdminPortal.Shared.Infrastructure.Common.CommonAttributes;

namespace Casino.AdminPortal.Shared.Infrastructure.Common.Enums
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DtoType
    {

        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,
        [QualifiedTypeName("Casino.AdminPortal.DTOModel.dll", "Casino.AdminPortal.DTOModel.SampleDTO")]
        SampleDto = 1,
        [QualifiedTypeName("Casino.AdminPortal.DTOModel.dll", "Casino.AdminPortal.DTOModel.UserDTO")]
        UserDto = 2,
        
    }
}
