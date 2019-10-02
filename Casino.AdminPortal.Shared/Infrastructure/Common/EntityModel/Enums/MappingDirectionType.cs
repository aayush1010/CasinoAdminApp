using System.Diagnostics.CodeAnalysis;

namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// 
    /// </summary>
    public enum MappingDirectionType
    {
        /// <summary>
        /// 
        /// </summary>
        None,
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        DtoFromEntity, // DB (Entity) to UI (DTO)
        /// <summary>
        /// 
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly")]
        EntityFromDto,// UI (DTO) to DB (Entity)
        /// <summary>
        /// 
        /// </summary>
        Both
    }
}
