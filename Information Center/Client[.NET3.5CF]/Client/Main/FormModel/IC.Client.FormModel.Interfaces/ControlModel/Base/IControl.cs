namespace IC.Client.FormModel.Interfaces.ControlModel.Base
{
    /// <summary>
    /// Presents Control interface
    /// 
    /// 2017/01/30 - created VTyagunov
    /// </summary>
    public interface IControl : IFont
    {
        /// <summary>
        /// Use for show control
        /// </summary>
        void ShowControl();

        /// <summary>
        /// Use for hide control
        /// </summary>
        void HideControl();
    }
}