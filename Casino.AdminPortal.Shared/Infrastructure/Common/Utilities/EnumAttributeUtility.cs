using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace Casino.AdminPortal.Shared
{
    /// <summary>
    /// Provides utility methods for Enum attribute,
    /// Author : Nagarro     
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum.</typeparam>
    /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
    public static class EnumAttributeUtility<TEnum, TAttribute>
        where TEnum : new()
        where TAttribute : Attribute
    {
        /// <summary>
        /// Local Cache
        /// </summary>
        private static readonly Dictionary<string, TAttribute> AttrDict = new Dictionary<string, TAttribute>();

        /// <summary>
        /// Initializes the <see cref="EnumAttributeUtility&lt;TEnum, TAttribute&gt;"/> class.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static EnumAttributeUtility()
        {
            TEnum e = new TEnum();
            if (AttrDict.Count == 0)
            {
                Type t = e.GetType();
                if (t.IsEnum)
                {
                    FieldInfo[] fields = t.GetFields();
                    foreach (FieldInfo fInfo in fields)
                    {
                        object[] attrs = fInfo.GetCustomAttributes(typeof(TAttribute), false);
                        if (attrs.Length == 1)
                        {
                            TAttribute fieldTagAttr = (TAttribute)attrs[0];
                            AttrDict.Add(fInfo.GetValue(e).ToString(), fieldTagAttr);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the cache list.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, TAttribute> GetList()
        {
            return AttrDict;
        }

        /// <summary>
        /// Gets the enum attribute.
        /// </summary>
        /// <param name="enumField">The enum field.</param>
        /// <returns></returns>

        [SuppressMessage("Microsoft.Design", "CA1000:DoNotDeclareStaticMembersOnGenericTypes")]
        public static TAttribute GetEnumAttribute(string enumField)
        {
            if (AttrDict.ContainsKey(enumField))
                return AttrDict[enumField];
            else
                throw new AttributeNotDefinedException(enumField);
        }
    }
}
