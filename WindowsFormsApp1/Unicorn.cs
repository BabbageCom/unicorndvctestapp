using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Access4u
{

    public sealed class Unicorn
    {
        public delegate int D_Connected();
        public delegate int D_Disconnected(int dwDisconnectCode);
        public delegate int D_Terminated();
        public delegate int D_OnNewChannelConnection();
        public delegate int D_OnDataReceived(int cbSize, IntPtr pBuffer);
        public delegate int D_OnReadError(int dwErrorCode);
        public delegate int D_OnClose();
        public enum ConnectionType { server = 0, client = 1 };


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern IntPtr LoadLibraryW(string lpPathName);

        /// <summary>
        ///   This function will try to determine the location of the UnicornDVC istallation, and load the
        ///   correct UnicornDVCAppLib file, without requiring it to be installed in the same folder as the
        ///   running application.
        /// </summary>
        public static IntPtr PreloadUnicornAppLib()
        {
            Microsoft.Win32.RegistryKey regKey = null;

            if (regKey == null)
            {
                // Istalled for all users?
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\UnicornDVC", false);
            }
            if (regKey == null)
            {
                // Istalled for a single user?
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\UnicornDVC", false);
            }
            if (regKey == null)
            {
                // Istalled for all users?
                regKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\UnicornDVC", false);
            }
            if (regKey == null)
            {
                // Istalled for a single user?
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\UnicornDVC", false);
            }

            if (regKey != null)
            {
                string unicornInstallationDir = (string)regKey.GetValue("InstallLocation");
                string libName = "UnicornDVCAppLib.dll";
                string libDir = null;

                if (IntPtr.Size == 8)
                {
                    libDir = unicornInstallationDir + @"\lib64";
                }
                else if (IntPtr.Size == 4)
                {
                    libDir = unicornInstallationDir + @"\lib";
                }
                if (libDir != null)
                {
                    string libFullPath = libDir + @"\" + libName;
                    return LoadLibraryW(libFullPath);
                }
            }
            return IntPtr.Zero;

        }


        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_Initialize(
                ConnectionType connectionType
            );
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_SetLicenseKey(
                [MarshalAs(UnmanagedType.LPWStr)]String licenseKey,
                [MarshalAs(UnmanagedType.Bool)]bool activate,
                [MarshalAs(UnmanagedType.LPWStr)]String errorMessage
            );
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr Unicorn_GetHardwareId();
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_Open(
                ConnectionType connectionType
            );
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_Write(
                ConnectionType connectionType,
                int cbSize,
                IntPtr pBuffer);
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_Close(
                ConnectionType connectionType
            );
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern int Unicorn_Terminate(
                ConnectionType connectionType
            );
        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern void Unicorn_SetCallbacks(
                ConnectionType connectionType,
                D_Connected _Connected,
                D_Disconnected _Disconnected,
                D_Terminated _Terminated,
                D_OnNewChannelConnection _OnNewChannelConnection,
                D_OnDataReceived _OnDataReceived,
                D_OnReadError _OnReadError,
                D_OnClose _OnClose
            );

        [DllImport("UnicornDVCAppLib.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
        private static extern bool Unicorn_IsLicensed();


        // Prevent construction
        private Unicorn() { }

        public static int Initialize(ConnectionType connectionType)
        {
            return Unicorn_Initialize(connectionType);
        }
        public static int SetLicenseKey(string licenseKey, bool activate, string errorMessage)
        {
            return Unicorn_SetLicenseKey(licenseKey, activate, errorMessage);
        }
        public static string GetHardwareId()
        {
            return Marshal.PtrToStringUni(Unicorn_GetHardwareId());
        }
        public static int Open(ConnectionType connectionType)
        {
            return Unicorn_Open(connectionType);
        }
        public static int Write(ConnectionType connectionType, int cbSize, byte[] buffer)
        {
            IntPtr pBuffer = Marshal.AllocHGlobal(cbSize);
            Marshal.Copy(buffer, 0, pBuffer, cbSize);
            int res = Unicorn_Write(connectionType, cbSize, pBuffer);
            Marshal.FreeHGlobal(pBuffer);
            return res;
        }

        public static int Close(ConnectionType connectionType)
        {
            return Unicorn_Close(connectionType);
        }
        public static int Terminate(ConnectionType connectionType)
        {
            return Unicorn_Terminate(connectionType);
        }
        public static void SetCallbacks(
            ConnectionType connectionType,
            D_Connected _Connected,
            D_Disconnected _Disconnected,
            D_Terminated _Terminated,
            D_OnNewChannelConnection _OnNewChannelConnection,
            D_OnDataReceived _OnDataReceived,
            D_OnReadError _OnReadError,
            D_OnClose _OnClose
        )
        {
            Unicorn_SetCallbacks(connectionType, _Connected, _Disconnected, _Terminated, _OnNewChannelConnection, _OnDataReceived, _OnReadError, _OnClose);
        }
        public static bool IsLicensed()
        {
            return Unicorn_IsLicensed();
        }
    }
}
