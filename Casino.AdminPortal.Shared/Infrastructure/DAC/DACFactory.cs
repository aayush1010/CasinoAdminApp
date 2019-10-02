using System;

namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Represents the factory for data access components,
    /// Author		: Nagarro
    /// </summary>
    public class DacFactory : FactoryBase, IDacFactory
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //mInstance variable completes before the instance variable can be accessed.
        [ThreadStatic]
        private static volatile DacFactory _instance;
        private static readonly object _syncObject = new object();

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DacFactory"/> class.
        /// </summary>
        private DacFactory()
        {
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>
        public static DacFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a mSyncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if mInstance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new DacFactory();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }
        #endregion

        #region IDACFactory Members

        /// <summary>
        /// Creates the specified DAC type.
        /// </summary>
        /// <param name="type">The DAC type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IDataAccessComponent Create(DacType type, params object[] args)
        {
            // get attribuye value
            QualifiedTypeNameAttribute qualifiedNameAttr = EnumAttributeUtility<DacType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());

            // create instance
            return (IDataAccessComponent)this.CreateObjectInstance(qualifiedNameAttr.AssemblyFileName, qualifiedNameAttr.QualifiedTypeName, args);
        }

        #endregion
    }
}

