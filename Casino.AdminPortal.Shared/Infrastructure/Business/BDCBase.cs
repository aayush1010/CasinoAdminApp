using System.Diagnostics.CodeAnalysis;


namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Represents the abstract base class for all Business Domain Components,
    /// Author : Nagarro     
    /// </summary>
    public abstract class BdcBase : IBusinessDomainComponent
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="BdcBase"/> class.
        /// </summary>
        /// <param name="bdcType">Type of the BDC.</param>
        /// <param name="securityToken">The security token.</param>
        protected BdcBase(BdcType bdcType)
        {
            BdcType = bdcType;
        }

        #endregion

        #region IBusinessDomainComponent Members

        /// <summary>
        /// Gets the type of the BDC.
        /// </summary>
        /// <value>The type of the BDC.</value>
        public BdcType BdcType { get; private set; }

        #endregion

        #region Factory Access

        /// <summary>
        /// Gets the factory for business domain component.
        /// </summary>
        /// <value>The business domain component.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected BdcFactory BusinessDomainComponent => BdcFactory.Instance;

        /// <summary>
        /// Gets the factory for data transfer object.
        /// </summary>
        /// <value>The data transfer object.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DtoFactory DataTransferObject => DtoFactory.Instance;

        /// <summary>
        /// Gets the data access component.
        /// </summary>
        /// <value>The data access component.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DacFactory DataAccessComponent => DacFactory.Instance;

        #endregion
    }
}
