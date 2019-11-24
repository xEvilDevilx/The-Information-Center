namespace IC.DB.ICSQL.MSSQL.SQLScripts
{
    /// <summary>
    /// Presents SQL constants
    /// 
    /// 2018/02/10 - Created, VTyagunov
    /// </summary>
    public class SQLConstants
    {
        /// <summary>Select current DB version query</summary>
        public const string SelectCurrentDBVersion = 
            "SELECT [VALUE] FROM [ICDB].[dbo].[Version] WHERE [KEY] = 'DB'";
        /// <summary>Update to new DB Version query</summary>
        public const string UpdateDBVersion = "UPDATE [dbo].[Version] SET [VALUE] = {0} WHERE [KEY] = 'DB'";
    }
}