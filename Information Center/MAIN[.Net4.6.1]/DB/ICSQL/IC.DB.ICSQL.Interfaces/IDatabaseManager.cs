namespace IC.DB.ICSQL.Interfaces
{
    /// <summary>
    /// Presents Database Manager functionality interface
    /// 
    /// 2018/02/10 - Created, VTyagunov
    /// </summary>
    public interface IDatabaseManager
    {
        /// <summary>DB Version</summary>
        int Version { get; }

        /// <summary>
        /// Use for Database Update
        /// </summary>
        void UpdateDB();
    }
}