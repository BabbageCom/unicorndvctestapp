using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Access4u;
namespace WindowsFormsApp1
{
    public partial class UnicornDemo : Form
    {

        enum ConnectionState
        {
            RESET,
            INITIALIZED,
            OPEN,
            CLOSED,
            TERMINATED
        };

        ConnectionState _currentState;
        ConnectionState CurrentState
        {
            set
            {
                switch (value)
                {
                    case ConnectionState.RESET:
                        break;
                    case ConnectionState.INITIALIZED:
                        break;
                    case ConnectionState.OPEN:
                        break;
                    case ConnectionState.CLOSED:
                        break;
                    case ConnectionState.TERMINATED:
                        break;
                    default:
                        break;
                }
                _currentState = value;
            }
            get
            {
                return _currentState;
            }
        }

        private Unicorn.ConnectionType connectionType;
        private bool opened = false;
        private byte received = 0;
        IntPtr libHandle = IntPtr.Zero;
        private bool initialized = false;
        private int Connected()
        {
            AddLog("Connected callback called");
            return 0;
        }

        private int Disconnected(int dwDisconnectCode)
        {
            AddLog(String.Format("Disconnected callback called with dwDisconnectCode {0}", dwDisconnectCode));
            CurrentState = ConnectionState.CLOSED;
            AddLog(dwDisconnectCode);
            return 0;
        }

        private int Terminated()
        {
            AddLog("Terminated callback called");
            CurrentState = ConnectionState.TERMINATED;
            return 0;
        }

        private int OnNewChannelConnection()
        {
            AddLog("OnNewChannelConnection callback called");
            CurrentState = ConnectionState.OPEN;
            opened = true;
            return 0;
        }

        private int OnDataReceived(int cbSize, IntPtr pBuffer)
        {
            byte[] bytes = new byte[cbSize];
            string buffer;
            Marshal.Copy(pBuffer, bytes, 0, cbSize);
            buffer = Encoding.UTF8.GetString(bytes);
            ReceivedText.Text = buffer;
            received++;
            return 0;
        }

        private int OnReadError(int dwErrorCode)
        {
            AddLog(String.Format("OnReadError callback called with dwErrorCode {0}", dwErrorCode));
            AddLog(dwErrorCode);
            CurrentState = ConnectionState.CLOSED;
            opened = false;
            return 0;
        }

        private int OnClose()
        {
            AddLog("OnClose callback called");
            CurrentState = ConnectionState.CLOSED;
            return 0;
        }
        public UnicornDemo()
        {
            InitializeComponent();
            libHandle = Unicorn.PreloadUnicornAppLib();
            if(libHandle == IntPtr.Zero)
            {
                AddLog("Failed to locate UnicornAppLib");
                AddLog(new Win32Exception(Marshal.GetLastWin32Error()).Message);
            }
            else
            {
                AddLog(String.Format("UnicornAppLib (0x{0:X}) loaded", (long)libHandle));
            }

            if (Unicorn.IsLicensed())
            {
                AddLog("Unicorn is licensed");
                ClientModeRadio.Checked = true;
            }
            else
            {
                AddLog("Unicorn is not licensed");
                ServerModeRadio.Checked = true;
                ClientModeRadio.Enabled = false;
            }

            CurrentState = ConnectionState.RESET;
            
        }

        private void twoWayText_TextChanged(object sender, EventArgs e)
        {
            string s = TypedText.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            Unicorn.Write(connectionType, bytes.Length, bytes);
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            int res;
            res = Unicorn.Open(connectionType);
            if (res != 0)
            {
                AddLog(String.Format("Open failed with status code {0}", res));
                AddLog(res);
            }
            else
            {
                AddLog("Open succeeded");
            }
        }

        void AddLog(int err)
        {
            if(err != 0)
            {
                AddLog(new Win32Exception(err).Message);
            }
        }
        void AddLog(string s)
        {
            ListViewItem item = new ListViewItem();
            item.Text = s;
            item.ToolTipText = s;
            LogBox.Items.Insert(0, item);
            LogBox.Columns[0].Width = LogBox.Width - 30;
            LogBox.ShowItemToolTips = true;
        }

        private void LogBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InitializeButton_Click(object sender, EventArgs e)
        {
            if (ServerModeRadio.Checked)
            {
                connectionType = Unicorn.ConnectionType.server;
            } else if (ClientModeRadio.Checked)
            {
                connectionType = Unicorn.ConnectionType.client;
            }
            else
            {
                MessageBox.Show("Please, select the connection mode.");
                return;
            }


            Unicorn.D_Connected _Connected = new Unicorn.D_Connected(Connected);
            Unicorn.D_Disconnected _Disconnected = new Unicorn.D_Disconnected(Disconnected);
            Unicorn.D_Terminated _Terminated = new Unicorn.D_Terminated(Terminated);
            Unicorn.D_OnNewChannelConnection _OnNewChannelConnection = new Unicorn.D_OnNewChannelConnection(OnNewChannelConnection);
            Unicorn.D_OnDataReceived _OnDataReceived = new Unicorn.D_OnDataReceived(OnDataReceived);
            Unicorn.D_OnReadError _OnReadError = new Unicorn.D_OnReadError(OnReadError);
            Unicorn.D_OnClose _OnClose = new Unicorn.D_OnClose(OnClose);


            Unicorn.SetCallbacks(connectionType, Connected, Disconnected, Terminated, OnNewChannelConnection, OnDataReceived, OnReadError, OnClose);


            int res = Unicorn.Initialize(connectionType);
            if (res != 0)
            {
                AddLog("Unicorn initialization failed");
                AddLog(res);
            }
            else
            {
                AddLog("Unicorn initialized");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            int res = Unicorn.Close(connectionType);
            if (res != 0)
            {
                AddLog("Failed to close connection");
                AddLog(res);
            } else
            {
                AddLog("Close succeeded");
            }
        }

        private void TerminateButton_Click(object sender, EventArgs e)
        {
            int res = Unicorn.Terminate(connectionType);
            if (res != 0)
            {
                AddLog("Failed to terminate connection");
                AddLog(res);
            }
            else
            {
                AddLog("Terminate succeeded");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
