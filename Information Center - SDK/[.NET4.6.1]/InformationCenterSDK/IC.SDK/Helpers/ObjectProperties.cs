using System;
using System.Linq;
using System.Reflection;

using IC.SDK.Interfaces.Helpers;

namespace IC.SDK.Helpers
{
    /// <summary>
    /// Implements methods for properties of objects
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public class ObjectProperties : IObjectProperties
    {
        /// <summary>
        /// Use for sort of object property names
        /// </summary>
        /// <param name="obj">Object for sort a properties</param>
        /// <returns></returns>
        public IOrderedEnumerable<PropertyInfo> GetOrderedProperties(object obj)
        {
            Logger.Log.Debug("GetOrderedProperties. Enter");

            try
            {
                var type = obj.GetType();
                var unOrderedProperties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var orderedProperties =
                    type.GetProperties().OrderBy(item => item.Name);

                Logger.Log.Debug("GetOrderedProperties. Exit");
                return orderedProperties;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetOrderedProperties.", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for return property value
        /// </summary>
        /// <param name="obj">Object for return of property value</param>
        /// <param name="propertyName">Property name</param>
        /// <returns></returns>
        public object GetPropertyValue(object obj, string propertyName)
        {
            Logger.Log.Debug("GetPropertyValue. Enter");

            try
            {
                var propertyInfo = obj.GetType().GetProperty(propertyName, BindingFlags.Public | 
                    BindingFlags.Instance);
                if (propertyInfo == null)
                    throw new ArgumentException(string.Format("GetPropertyValue. Property '{0}' is not found!", 
                        propertyInfo), "property");

                Logger.Log.Debug("GetPropertyValue. Exit");
                return propertyInfo.GetValue(obj, null);
            }
            catch (Exception ex)
            {
                Logger.Log.Error("GetPropertyValue.", ex);
                throw;
            }
        }
    }
}