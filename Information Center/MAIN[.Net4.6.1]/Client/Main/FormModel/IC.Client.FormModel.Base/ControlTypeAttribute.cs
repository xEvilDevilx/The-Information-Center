using System;

using IC.Client.FormModel.Base.Enums;

namespace IC.Client.FormModel.Base
{
    /// <summary>
    /// Presents attribute for check control type
    /// 
    /// 2017/01/30 - Created, VTyagunov
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ControlTypeAttribute : Attribute
    {
        /// <summary>UserControl types</summary>
        private UserControlTypes _controlTypes;

        /// <summary>UserControl types property</summary>
        public UserControlTypes ControlTypes
        {
            get { return _controlTypes; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controlTypes">User Control type</param>
        public ControlTypeAttribute(UserControlTypes controlTypes)
        {
            _controlTypes = controlTypes;
        }
    }
}