using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using static System.Windows.Forms.Control;
using System.Xml.Linq;

using IC.Client.FormModel.Base;
using IC.Client.FormModel.Base.Constants;
using IC.Client.FormModel.Base.Enums;
using IC.Client.FormModel.Interfaces;
using IC.Client.FormModel.Interfaces.ControlModel.Base;
using IC.SDK;
using IC.SDK.Helpers;

namespace IC.Client.FormModel
{
    /// <summary>
    /// Implements work with plugins
    /// 
    /// 2017/01/22 - created VTyagunov
    /// </summary>
    public class PluginManager : IPluginManager
    {
        #region Variables

        /// <summary>Store Control's Collection</summary>
        private ControlCollection _controls;

        #endregion

        #region Properties

        /// <summary>Flag shows Plugin Load state</summary>
        public bool IsPluginLoaded { get; set; }
        /// <summary>Contains Dictionary of Controls</summary>
        public Dictionary<UserControlTypes, IControl> ControlsDictionary { get; set; }
        /// <summary>Last Control Type</summary>
        public UserControlTypes LastControlType { get; private set; }
        /// <summary>Current Control Type</summary>
        public UserControlTypes CurrentControlType { get; private set; }
        /// <summary>Clean Background Image from loaded plugin assembly</summary>
        public Bitmap CleanBackgroundImage { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controls">Control collection</param>
        public PluginManager(ControlCollection controls)
        {
            Logger.Log.Debug("PluginManager. Ctr. Enter");

            IsPluginLoaded = false;
            _controls = controls;
            LastControlType = UserControlTypes.UnAvailable;
            CurrentControlType = UserControlTypes.UnAvailable;
            ControlsDictionary = new Dictionary<UserControlTypes, IControl>();

            var controlPluginDirName = string.Format("{0}\\Plugins\\{1}.dll",
                Directory.GetCurrentDirectory(), LoadPluginName(PluginTypes.Control));
            ControlsDictionary.Clear();
            LoadAssemblies(controlPluginDirName);
            IsPluginLoaded = CheckPluginLoadStatus();

            Logger.Log.Debug("PluginManager. Ctr. Exit");
        }

        #endregion

        #region Methods

        /// <summary>
        /// Use for load controls from plugin dll
        /// </summary>
        private void LoadAssemblies(string dirName)
        {
            Logger.Log.Debug("LoadAssemblies. Enter");

            try
            {
                var assembly = Assembly.LoadFrom(dirName);
                if (assembly == null)
                    return;

                string resourceName = assembly.GetName().Name + ".Properties.Resources";
                var rm = new ResourceManager(resourceName, assembly);
                if (rm != null)
                    CleanBackgroundImage = (Bitmap)rm.GetObject("imgCleanBackground");

                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass)
                    {
                        object[] attributes = type.GetCustomAttributes(true);
                        foreach (Attribute attribute in attributes)
                        {
                            var controlTypeAttr = attribute as ControlTypeAttribute;
                            if (controlTypeAttr != null)
                            {
                                var control = (UserControl)Activator.CreateInstance(type);
                                control.Hide();
                                _controls.Add(control);

                                ControlsDictionary.Add(controlTypeAttr.ControlTypes,
                                    (IControl)control);
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LoadAssemblies. ", ex);
            }

            Logger.Log.Debug("LoadAssemblies. Exit");
        }

        /// <summary>
        /// Use for load plugin dll name from client config xml
        /// </summary>
        /// <param name="pluginType">Plugin Type</param>
        /// <returns></returns>
        private string LoadPluginName(PluginTypes pluginType)
        {
            Logger.Log.Debug("LoadPluginName. Enter");

            try
            {
                string pluginName = "";
                switch (pluginType)
                {
                    case PluginTypes.Control:
                        pluginName = FormModelConstants.ConfigControlPluginName;
                        break;
                }

                var dirName = string.Format("{0}\\{1}", Utils.GetCurrentDirectory(),
                    FormModelConstants.ClientConfigXMLName);
                var xml = XDocument.Load(dirName);
                var tagValue = xml.Descendants(pluginName).First();

                Logger.Log.Debug("LoadPluginName. Exit");

                return tagValue.Value;
            }
            catch (Exception ex)
            {
                Logger.Log.Error("LoadPluginName. ", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for check plugin load status
        /// </summary>
        /// <returns>Plugin load status</returns>
        private bool CheckPluginLoadStatus()
        {
            Logger.Log.Debug("CheckPluginLoadStatus. Enter/Exit");

            var userControlTypes = new UserControlTypes();
            if (ControlsDictionary.Count == Utils.GetValues(userControlTypes).Count())
                return true;
            else return false;
        }

        /// <summary>
        /// Use for show asigned control
        /// </summary>
        /// <param name="controlType">User Control Type</param>
        public void ShowControl(UserControlTypes controlType)
        {
            Logger.Log.Debug("ShowControl. Enter");

            HideAllControls();
            ControlsDictionary[controlType].ShowControl();
            LastControlType = CurrentControlType;
            CurrentControlType = controlType;

            Logger.Log.Debug("ShowControl. Exit");
        }

        /// <summary>
        /// Use for Hide Control
        /// </summary>
        /// <param name="controlType">User Control Type</param>
        public void HideControl(UserControlTypes controlType)
        {
            Logger.Log.Debug("HideControl. Enter");

            ControlsDictionary[controlType].HideControl();

            Logger.Log.Debug("HideControl. Exit");
        }

        /// <summary>
        /// Use for hide all controls
        /// </summary>
        public void HideAllControls()
        {
            Logger.Log.Debug("HideAllControls. Enter");

            foreach (var control in ControlsDictionary)
                control.Value.HideControl();

            Logger.Log.Debug("HideAllControls. Exit");
        }

        /// <summary>
        /// Use for Show Last Control
        /// </summary>
        public void ShowLastControl()
        {
            Logger.Log.Debug("ShowOldControl. Enter");

            ShowControl(LastControlType);

            Logger.Log.Debug("ShowOldControl. Exit");
        }
        
        #endregion
    }
}