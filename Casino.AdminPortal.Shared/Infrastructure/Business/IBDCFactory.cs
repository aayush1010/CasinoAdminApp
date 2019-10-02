using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;

namespace Casino.AdminPortal.Shared.Infrastructure.Business
{
    /// <summary>
    /// Defines a contract for BDC factory,
    /// Author : Nagarro
    /// </summary>
    public interface IBdcFactory
    {
        /// <summary>
        /// Creates the specified BDC type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        IBusinessDomainComponent Create(BdcType type, params object[] args);
    }
}
