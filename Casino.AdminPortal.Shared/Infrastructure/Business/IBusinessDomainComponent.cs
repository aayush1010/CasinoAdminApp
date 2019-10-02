using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;

namespace Casino.AdminPortal.Shared.Infrastructure.Business
{
    /// <summary>
    /// Defines a contract for base business domain component,
    /// Author : Nagarro
    /// </summary>
    public interface IBusinessDomainComponent
    {
        /// <summary>
        /// Gets the type of the BDC.
        /// </summary>
        /// <value>The type of the BDC.</value>
        BdcType BdcType { get; }
    }
}
