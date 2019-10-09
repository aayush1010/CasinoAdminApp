using System.Diagnostics.CodeAnalysis;
using Casino.AdminPortal.Shared.Infrastructure.Business;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Shared.Infrastructure.Facades
{
    /// <summary>
    /// Represents the abstract base class for all facades,
    /// Author : Nagarro     
    /// </summary>
    public abstract class FacadeBase : IFacade
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeBase"/> class.
        /// </summary>
        /// <param name="facadeType">Type of the facade.</param>
        protected FacadeBase(FacadeType facadeType)
        {
            FacadeType = facadeType;
        }
        #endregion

        #region IFacade Members

        /// <summary>
        /// Gets the type of the facade.
        /// </summary>
        /// <value>The type of the facade.</value>
        public FacadeType FacadeType { get; }

        #endregion

        #region Factory Access

        /// <summary>
        /// Gets the factory for the facade.
        /// </summary>
        /// <value>The facade.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected FacadeFactory Facade => FacadeFactory.Instance;

        /// <summary>
        /// Gets the factory for the business domain component.
        /// </summary>
        /// <value>The business domain component.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected BdcFactory BusinessDomainComponent => BdcFactory.Instance;

        /// <summary>
        /// Gets the factory for the data transfer object.
        /// </summary>
        /// <value>The data transfer object.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DtoFactory DataTransferObject => DtoFactory.Instance;

        #endregion

    }
}
