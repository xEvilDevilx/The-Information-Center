namespace IC.Server.Core.Interfaces
{
    /// <summary>
    /// Presents the Simple Collection
    /// 
    /// 2016/12/15 - Created, VTyagunov
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISimpleCollection<T>
    {
        /// <summary>  
        /// Use for add T to the Collection
        /// </summary>
        /// <param name="t">T object to Add</param>
        /// <returns></returns>
        bool Add(T t);

        /// <summary>
        /// Use for get T from collection
        /// </summary>
        /// <param name="obj">Object for get T from collection</param>
        /// <returns></returns>
        T Get(object obj);

        /// <summary>
        /// Use for remove T from collection
        /// </summary>
        /// <param name="t">T object to Remove</param>
        /// <returns></returns>
        bool Remove(T t);
    }
}