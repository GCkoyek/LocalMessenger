using System;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientw
{
    public partial class ClientForm : Form
    {
        private bool isDragging = false;
        private Point mouseOffset;
        private TcpClient _client;
        private NetworkStream _stream;
        private byte[] _buffer = new byte[1024];
        private NotifyIcon _notifyIcon;

        public ClientForm()
        {
            InitializeComponent();
            InitializeNotifyIcon();
        }

        // Initialization of NotifyIcon
        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon
            {
                Icon = SystemIcons.Information,
                Visible = true
            };
        }

        private void ConnectToServer()
        {
            try
            {
                _client = new TcpClient("172.18.112.1", 6001);
                _stream = _client.GetStream();
                ReceiveMessage();
                statusLabel.Text = "Status: Połączono";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd połączenia z serwerem: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Status: Niepołączono";
            }
        }


        private void ReceiveMessage()
        {
            Task.Run(() =>
            {
                StringBuilder messageBuilder = new StringBuilder();
                try
                {
                    while (true)
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
                                outputTextBox.AppendText("Serwer:\n" + fullMessage + Environment.NewLine);
                                ShowNotification("Nowa wiadomość", fullMessage);
                            });
                            messageBuilder.Clear();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Błąd odbioru wiadomości: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
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
            outputTextBox.AppendText("Ty:\n" + inputTextBox.Text + Environment.NewLine);
            inputTextBox.Clear();
        }
        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _client.Close();
            _notifyIcon.Dispose();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            SetRoundedCorners(this);
            ConnectToServer();
        }

        private void ClientForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseOffset = new Point(e.X, e.Y);
            }
        }

        private void ClientForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                this.Left = e.X + this.Left - mouseOffset.X;
                this.Top = e.Y + this.Top - mouseOffset.Y;
            }
        }

        private void ClientForm_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void SetRoundedCorners(Form form)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(form.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(form.Width - radius - 1, form.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, form.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            form.Region = new System.Drawing.Region(path);
        }
    }
}
