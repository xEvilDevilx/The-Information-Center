using System.Collections.Generic;
using System.Drawing;

using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces.ControlModel.Base;

namespace IC.Client.FormModel.Interfaces
{
    /// <summary>
    /// Implements work with plugins
    /// 
    /// 2017/08/15 - Created, VTyagunov
    /// </summary>
    public interface IPluginManager
    {
        /// <summary>Flag shows Plugin Load state</summary>
        bool IsPluginLoaded { get; set; }
        /// <summary>Contains Dictionary of Controls</summary>
        Dictionary<UserControlTypes, IControl> ControlsDictionary { get; set; }
        /// <summary>Last Control Type</summary>
        UserControlTypes LastControlType { get; }
        /// <summary>Current Control Type</summary>
        UserControlTypes CurrentControlType { get; }
        /// <summary>Clean Background Image from loaded plugin assembly</summary>
        Bitmap CleanBackgroundImage { get; }

        /// <summary>
        /// Use for show asigned control
        /// </summary>
        /// <param name="controlType">User Control Type</param>
        void ShowControl(UserControlTypes controlType);

        /// <summary>
        /// Use for Hide Control
        /// </summary>
        /// <param name="controlType">User Control Type</param>
        void HideControl(UserControlTypes controlType);

        /// <summary>
        /// Use for hide all controls
        /// </summary>
        void HideAllControls();

        /// <summary>
        /// Use for Show Last Control
        /// </summary>
        void ShowLastControl();
    }
}