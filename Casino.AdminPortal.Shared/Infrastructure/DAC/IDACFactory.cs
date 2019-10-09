using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;

namespace Casino.AdminPortal.Shared.Infrastructure.DAC
{
    /// <summary>
    /// Defines a contract for data access component factory,
    /// Author		: Nagarro
    /// </summary>
    public interface IDacFactory
    {
        /// <summary>
        /// Creates the specified DAC type.
        /// </summary>
        /// <param name="type">The DAC type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        IDataAccessComponent Create(DacType type, params object[] args);
    }
}
