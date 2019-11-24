namespace IC.Client.BusinessLogic.Interfaces
{
    /// <summary>
    /// Presents Control Business Logic interface
    /// 
    /// 2017/08/14 - Created, VTyagunov
    /// </summary>
    public interface IControlBusinessLogic
    {
        /// <summary>
        /// Use for show control
        /// </summary>
        void ShowControl();

        /// <summary>
        /// Use for hide control
        /// </summary>
        void HideControl();

        /// <summary>
        /// Use for show last visible control
        /// </summary>
        void ShowLastControl();
    }
}