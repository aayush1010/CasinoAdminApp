using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;

namespace Casino.AdminPortal.Shared.Infrastructure.DTO
{
    /// <summary>
    /// Defines a contract for DTO factory,
    /// Author : Nagarro     
    /// </summary>
    public interface IDtoFactory
    {
        /// <summary>
        /// Creates the specified DTO type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        IDto Create(DtoType type, params object[] args);
    }
}
