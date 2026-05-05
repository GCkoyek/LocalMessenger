using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener _tcpListener;
        private TcpClient _client;
        private NetworkStream _stream;
        private byte[] _buffer = new byte[1024];
        private Thread _listenerThread;
        private NotifyIcon _notifyIcon;

        public ServerForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
            StartServer();
        }

        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = SystemIcons.Information;
            _notifyIcon.Visible = true;
        }

        private void StartServer()
        {
            _listenerThread = new Thread(ListenForClients);
            _listenerThread.Start();
        }

        private void ListenForClients()
        {
            _tcpListener = new TcpListener(IPAddress.Any, 6001);
            _tcpListener.Start();
            Invoke((MethodInvoker)delegate { statusLabel.Text = "Oczekiwanie na połączenie..."; });

            _client = _tcpListener.AcceptTcpClient();
            _stream = _client.GetStream();
            Invoke((MethodInvoker)delegate { statusLabel.Text = "Połączono z klientem!"; });

            ReceiveMessage();
        }

        private void ReceiveMessage()
        {
            StringBuilder messageBuilder = new StringBuilder();
            while (true)
            {
                try
                {
                    int bytesRead = _stream.Read(_buffer, 0, _buffer.Length);
                    if (bytesRead == 0)
                        break;

                    string partMessage = Encoding.UTF8.GetString(_buffer, 0, bytesRead);
                    messageBuilder.Append(partMessage);

                    if (partMessage.Contains("<EOF>"))
                    {
                        string fullMessage = messageBuilder.ToString().Replace("<EOF>", "");
                        Invoke((MethodInvoker)delegate
                        {
                            outputTextBox.AppendText("Adam:\n" + fullMessage + Environment.NewLine);
                            ShowNotification("Nowa wiadomość", fullMessage);
                        });
                        messageBuilder.Clear();
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        private void ShowNotification(string title, string message)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = message;
            _notifyIcon.ShowBalloonTip(3000);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = inputTextBox.Text + "<EOF>";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            _stream.Write(messageBytes, 0, messageBytes.Length);
            outputTextBox.AppendText("Wojtek:\n" + inputTextBox.Text + Environment.NewLine);
            inputTextBox.Clear();
        }

        private void ServerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tcpListener.Stop();
            _client.Close();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
