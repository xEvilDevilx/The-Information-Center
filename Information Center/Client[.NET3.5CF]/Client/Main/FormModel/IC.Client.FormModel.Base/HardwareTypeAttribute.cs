using System;

using IC.Client.FormModel.Base.Enums;

namespace IC.Client.FormModel.Base
{
    /// <summary>
    /// Presents attribute for check hardware type
    /// 
    /// 2017/08/24 - Created, VTyagunov
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HardwareTypeAttribute : Attribute
    {
        /// <summary>Hardware types</summary>
        private HardwareTypes _hardwareTypes;

        /// <summary>Hardware types property</summary>
        public HardwareTypes ControlTypes
        {
            get { return _hardwareTypes; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="hardwareTypes">Hardware type</param>
        public HardwareTypeAttribute(HardwareTypes hardwareTypes)
        {
            _hardwareTypes = hardwareTypes;
        }
    }
}