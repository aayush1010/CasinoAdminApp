using System.Diagnostics.CodeAnalysis;
using Casino.AdminPortal.Shared.Infrastructure.Common.Enums;
using Casino.AdminPortal.Shared.Infrastructure.DTO;

namespace Casino.AdminPortal.Shared.Infrastructure.DAC
{
    public abstract class DacBase : IDataAccessComponent
    {

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="DacBase"/> class.
        /// </summary>
        /// <param name="dacType">Type of the dac.</param>
        protected DacBase(DacType dacType)
        {
            this.Type = dacType;
        }
        #endregion

        #region IDataAccessComponent Members

        /// <summary>
        /// private gets the type of the DAC.
        /// </summary>
        /// <value>The type of the DAC.</value>
        public DacType Type { get; }

        #endregion

        #region Factory Access

        /// <summary>
        /// Gets the factory of data access component.
        /// </summary>
        /// <value>The data access component.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DacFactory DataAccessComponent => DacFactory.Instance;

        /// <summary>
        /// Gets the factory of data transfer object.
        /// </summary>
        /// <value>The data transfer object.</value>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        protected DtoFactory DataTransferObject => DtoFactory.Instance;

        #endregion
    }
}
