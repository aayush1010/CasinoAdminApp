namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Represents the factory for Data Transfer Objects,
    /// Author : Nagarro 
    /// </summary>    
    public class DtoFactory : FactoryBase, IDtoFactory
    {
        //The variable is declared to be volatile to ensure that assignment to the 
        //_instance variable completes before the instance variable can be accessed.
        private static volatile DtoFactory _instance;
        private static readonly object _syncObject = new object();

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="DtoFactory"/> class.
        /// </summary>
        private DtoFactory()
        {
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Instance is private static property to return the same Instance of the class everytime.
        /// Note: Double - checked serialized initialization of Class pattern is used.
        /// </summary>       
        public static DtoFactory Instance
        {
            get
            {
                #region Single Instance Logic
                //Check for null before acquiring the lock.
                if (_instance == null)
                {
                    //Use a _syncObject to lock on, to avoid deadlocks among multiple threads.
                    lock (_syncObject)
                    {
                        //Again check if _instance has been initialized, 
                        //since some other thread may have acquired the lock first and constructed the object.
                        if (_instance == null)
                        {
                            _instance = new DtoFactory();
                        }
                    }
                }
                #endregion

                return _instance;
            }
        }

        #endregion

        #region IDTOFactory Members

        /// <summary>
        /// Creates the specified DTO type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        public IDto Create(DtoType type, params object[] args)
        {
            try
            {
                // get type info
                QualifiedTypeNameAttribute qualifiedNameAttr = EnumAttributeUtility<DtoType, QualifiedTypeNameAttribute>.GetEnumAttribute(type.ToString());

                // Initialize instance
                IDto instance = null;

                // create instance
                instance = (IDto)this.CreateObjectInstance(qualifiedNameAttr.AssemblyFileName, qualifiedNameAttr.QualifiedTypeName, args);

                // return
                return instance;
            }
            catch (FactoryException fex)
            {
                throw fex;
            }
        }

        #endregion
    }
}
