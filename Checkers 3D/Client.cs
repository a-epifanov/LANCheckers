using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectPlay;
using Shared;
using System.IO;
using Checkers;
using System.Drawing.Imaging;
using BoardGame;
using BoardGame.Direct3D;

namespace GameClient
{
    public partial class _Client : Form
    {
        public delegate void StatusConnection(bool statusConnection);
        private delegate void AddHostCallback(Host host);
        private delegate void DisconnectCallback();
        public delegate void ReceiveMainPlayer(Player mainPlayer);
        public delegate void ReceiveEnemyImage();
        public delegate void ReceiveImage();

        private Client connection = null;
        private Address hostaddress = null;
        private ApplicationDescription desc;
        private Address deviceAddress = null;
        private bool connected = false;
        private StatusConnection statusConnection;
        private ReceiveMainPlayer receiveMainPlayer;
        public ReceiveImage receiveImage; 
        public LeftMouseUp leftMouseUp;
        public LeftMouseDown leftMouseDown;
        List<Host> FoundHosts = new List<Host>();

        public _Client()
        {
            InitializeComponent();
            InitializeClient();
        }

        public void InitializeClient()
        {
            connection = new Client();
            connection.ConnectComplete += new
            ConnectCompleteEventHandler(OnConnectComplete);
            connection.FindHostResponse += new
            FindHostResponseEventHandler(OnFindHost);
            connection.SessionTerminated += new
            SessionTerminatedEventHandler(OnSessionTerminate);
            connection.Receive += new ReceiveEventHandler(OnDataReceive);
            if (!IServiceProviderValid(Address.ServiceProviderTcpIp))
            {
                MessageBox.Show("Невозможно создать TCP/IP службу поддержки",
                    "Выход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            deviceAddress = new Address();
            deviceAddress.ServiceProvider = Address.ServiceProviderTcpIp;

            hostaddress = new Address();
            hostaddress.ServiceProvider = Address.ServiceProviderTcpIp;
            hostaddress.AddComponent(Address.KeyPort, SharedCode.DataPort);

            desc = new ApplicationDescription();
            desc.GuidApplication = SharedCode.ApplicationGuid;  
        }

        private bool IServiceProviderValid(Guid provider)
        {
            ServiceProviderInformation[] providers =
                connection.GetServiceProviders(true);

            foreach (ServiceProviderInformation info in providers)
            {
                if (info.Guid == provider)
                    return true;
            }
            return false;
        }

        private void FindServer()
        {
            try
            {
                connection.FindHosts(desc, hostaddress, deviceAddress, null,
                    1, 0, 5, FindHostsFlags.None);
            }
            catch
            {
                MessageBox.Show("Невозможно выполнить поиск",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void OnFindHost(object sender, FindHostResponseEventArgs e)
        {
                if (connected)
                    return;
                Host host = new Host();
                host.desc = e.Message.ApplicationDescription;
                host.addressSender = e.Message.AddressSender;
                host.deviceAddress = e.Message.AddressDevice;
                this.BeginInvoke(new AddHostCallback(AddHost),
                    new object[] { host });

        }

        private void OnConnectComplete(object sender, ConnectCompleteEventArgs e)
        {
            if (e.Message.ResultCode == Microsoft.DirectX.DirectPlay.ResultCode.Success)
            {
                Shared.SharedCode.EnemyPlayer.Name = ((Client)sender).GetServerInformation().Name;
                MessageBox.Show("Соединение выполнено",
        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connected = true;
                if (statusConnection != null)
                    statusConnection(connected);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(string.Format("Ошибка соединения: (0)",
                    e.Message.ResultCode),
        "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddHost(Host host)
        {
            
            FoundHosts.Add(host);
            string foundSession = string.Format(
                                "Сессия ({0})",
                            host.desc.SessionName);
            listBox1.Items.Add(foundSession.ToString());

        }



        private void OnSessionTerminate(object sender, SessionTerminatedEventArgs e)
        {
            MessageBox.Show("Сессия завершена",
"", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connected = false;
            if (statusConnection != null)
                statusConnection(connected);

        }

        private void OnDataReceive(object sender, ReceiveEventArgs e)
        {
            SharedCode.NetworkMessages msg = (SharedCode.NetworkMessages)e.Message.ReceiveData.Read(typeof(SharedCode.NetworkMessages));
            NetworkPacket returnedPacked = new NetworkPacket();
            switch (msg)
            {
                case SharedCode.NetworkMessages.MainPlayer:
                    receiveMainPlayer((Player)e.Message.ReceiveData.Read(typeof(Player)));
                    break;
                case SharedCode.NetworkMessages.Image:
                    byte[] reciveLen = new byte[4];
                    reciveLen = (byte[])e.Message.ReceiveData.Read(typeof(byte), 4);
                    int lenght = BitConverter.ToInt32(reciveLen, 0);
                    byte[] recive = new byte[lenght];
                    recive = (byte[])e.Message.ReceiveData.Read(typeof(byte), lenght);
                    MemoryStream ms = new MemoryStream();
                    ms.Write(recive, 0, lenght);
                    Shared.SharedCode.EnemyPlayer.UserImage = Image.FromStream(ms);
                    break;
                case SharedCode.NetworkMessages.LeftMouseDown:
                    leftMouseDown((Square)e.Message.ReceiveData.Read(typeof(Square)));
                    break;
                case SharedCode.NetworkMessages.LeftMouseUp:
                    leftMouseUp((Square)e.Message.ReceiveData.Read(typeof(Square)));
                    break;
            }
        }


        public void SendImage(Image userImage)
        {
            if (connected)
            {
                
                NetworkPacket packet = new NetworkPacket();
                packet.Write(Shared.SharedCode.NetworkMessages.Image);

                MemoryStream ms = new MemoryStream();
                //Bitmap bmp = new Bitmap(userImage);
                //userImage.Dispose();
                // Сохранили картинку в MemStream
                userImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                // Картинка в массиве
                byte[] arrImage = ms.GetBuffer();
                // Получили длину массива с картинкой
                int lenght = arrImage.Length;
                byte[] len = BitConverter.GetBytes(lenght);
                // Записали длину в поток
                packet.Write(len);
                packet.Write(arrImage);

                connection.Send(packet, 0, SendFlags.Guaranteed);
            }
        }

        public void SendLeftMouseDown(BoardGame.Square location)
        {
            if (connected)
            {
                NetworkPacket packet = new NetworkPacket();
                packet.Write(Shared.SharedCode.NetworkMessages.LeftMouseDown);
                packet.Write(location);
                connection.Send(packet, 0, SendFlags.Guaranteed);
            }
        }

        public void SendLeftMouseUp(Square location)
        {
            if (connected)
            {
                NetworkPacket packet = new NetworkPacket();
                packet.Write(Shared.SharedCode.NetworkMessages.LeftMouseUp);
                packet.Write(location);
                connection.Send(packet, 0, SendFlags.Guaranteed);
            }
        }

        public void SetStatusConnection(StatusConnection statusConnection)
        {
            this.statusConnection = statusConnection;
        }


        public void SetReceiveMainPlayer(ReceiveMainPlayer receiveMainPlayer)
        {
            this.receiveMainPlayer += receiveMainPlayer;
        }

        public void SetReceiveImage(ReceiveImage receiveImage)
        {
            this.receiveImage = receiveImage;
        }

        public void DisposeConnection()
        {
            
            connected = false;
            if (statusConnection != null)
                statusConnection(connected);
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FoundHosts.Clear();
            listBox1.Items.Clear();
            FindServer();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                PlayerInformation info = new PlayerInformation();
                info.Name = Shared.SharedCode.CurrentPlayer.Name;
                connection.SetClientInformation(info, SyncFlags.ClientInformation);
                connection.Connect(FoundHosts[listBox1.SelectedIndex].desc,
                    FoundHosts[listBox1.SelectedIndex].addressSender,
                    FoundHosts[listBox1.SelectedIndex].deviceAddress, null, ConnectFlags.OkToQueryForAddressing);
            }
            else
            {
                MessageBox.Show("Выберите ссессию",
"", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }


    }

    public class Host
    {
        public ApplicationDescription desc;
        public Address addressSender;
        public Address deviceAddress;
    };
}
