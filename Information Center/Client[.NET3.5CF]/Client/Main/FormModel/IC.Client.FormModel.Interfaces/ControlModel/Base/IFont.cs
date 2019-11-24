namespace IC.Client.FormModel.Interfaces.ControlModel.Base
{
    /// <summary>
    /// Presents Font manage interface
    /// 
    /// 2017/08/15 - Created, VTyagunov
    /// </summary>
    public interface IFont
    {
        /// <summary>
        /// Use for Set Font to all Control text
        /// </summary>
        /// <param name="fontName">Name of Font</param>
        void SetFont(string fontName);

        /// <summary>
        /// Use for Set Default Font to all Control text
        /// </summary>
        void SetDefaultFont();
    }
}