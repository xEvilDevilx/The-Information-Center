using System.Linq;
using System.Reflection;

namespace IC.SDK.Interfaces.Helpers
{
    /// <summary>
    /// Presents methods for properties of objects
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public interface IObjectProperties
    {
        /// <summary>
        /// Use for sort of object property names
        /// </summary>
        /// <param name="obj">Object for sort a properties</param>
        /// <returns></returns>
        IOrderedEnumerable<PropertyInfo> GetOrderedProperties(object obj);

        /// <summary>
        /// Use for return property value
        /// </summary>
        /// <param name="obj">Object for return of property value</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        object GetPropertyValue(object obj, string propertyName);
    }
}