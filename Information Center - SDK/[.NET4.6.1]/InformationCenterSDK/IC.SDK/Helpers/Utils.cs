using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

using IC.SDK.Base.Constants;

namespace IC.SDK.Helpers
{
    /// <summary>
    /// Universal helper
    /// 
    /// 2016/12/21 - Created, VTyagunov
    /// </summary>
    public static class Utils
    {
        [DllImport("iphlpapi.dll", SetLastError = true)]
        public static extern int GetAdaptersInfo(byte[] info, ref uint size);

        /// <summary>
        /// Return current IP-address
        /// </summary>
        /// <returns></returns>
        public static string LocalIPAddress()
        {
            Logger.Log.Debug("LocalIPAddress. Enter");

            var localIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }

            Logger.Log.Debug("LocalIPAddress. Exit");
            return localIP;
        }

        /// <summary>
        /// Get enum values
        /// </summary>
        /// <param name="enumeration">Enumeration</param>
        /// <returns></returns>
        public static IEnumerable<Enum> GetValues(Enum enumeration)
        {
            Logger.Log.Debug("GetValues. Enter");

            var enumerations = new List<Enum>();
            foreach (FieldInfo fieldInfo in enumeration.GetType().
                GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                enumerations.Add((Enum)fieldInfo.GetValue(enumeration));
            }

            Logger.Log.Debug("GetValues. Exit");
            return enumerations;
        }

        /// <summary>
        /// Get MAC-address
        /// </summary>
        /// <returns></returns>
        public static string GetMacAddress()
        {
            Logger.Log.Debug("GetMacAddress. Enter");

            uint num = 0u;
            GetAdaptersInfo(null, ref num);
            byte[] array = new byte[(int)((UIntPtr)num)];
            int adaptersInfo = GetAdaptersInfo(array, ref num);
            if (adaptersInfo == 0)
            {
                string macAddress = "";
                int macLength = BitConverter.ToInt32(array, 400);
                macAddress = BitConverter.ToString(array, 404, macLength);
                macAddress = macAddress.Replace("-", ":");

                Logger.Log.Debug("GetMacAddress. Exit");
                return macAddress;
            }
            else
            {
                Logger.Log.Debug("GetMacAddress. Exit");
                return "";
            }      
        }

        /// <summary>
        /// Use for get current directory in kiosk(.NET3.5CF)
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            Logger.Log.Debug("GetCurrentDirectory. Enter/Exit");
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
        }

        /// <summary>
        /// Use for Start Simple Thread
        /// </summary>
        /// <param name="action">Actions to do</param>
        public static void StartSimpleThread(Action action)
        {
            Logger.Log.Debug("StartSimpleThread. Enter");

            try
            {
                var threadStart = new ThreadStart(action);
                var thread = new Thread(threadStart);
                thread.Start();

                Logger.Log.Debug("StartSimpleThread. Exit");
            }
            catch (Exception ex)
            {
                Logger.Log.Error("StartSimpleThread", ex);
                throw;
            }
        }

        /// <summary>
        /// Use for Get UDP End Point
        /// </summary>
        /// <returns></returns>
        public static IPEndPoint GetUDPEndPoint()
        {
            Logger.Log.Debug("GetUDPEndPoint. Enter");

            var groupIP = IPAddress.Parse("255.255.255.255");
            int groupPort = BaseConstants.UdpServerPort;
            var groupEndPoint = new IPEndPoint(groupIP, groupPort);
            
            Logger.Log.Debug("GetUDPEndPoint. Exit");
            return groupEndPoint;
        }
    }
}