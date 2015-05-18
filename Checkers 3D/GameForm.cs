using System;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectPlay;
using BoardGame.Direct3D;
using Checkers;
using GameServer;
using GameClient;
using Checkers.Direct3D;

namespace BoardGame
{
    public partial class GameForm : Form
    {
        private CheckersLogic gameLogic;
        private CheckersModelRepository modelRepository;
        private bool run_Client = false;
        private bool run_Server = false;
        private bool creted_Server = false;
        private GameServer._Server server = null;
        private GameClient._Client client = null;
        public delegate void AddSetSharedCallback(bool param);
        public delegate void AddSetFormPlayersCallback(Player playerIdentifier);
        public delegate void AddSetMenuItemCallback(int m1, int m2, bool param);

        public GameForm()
        {
            gameLogic = new CheckersLogic();
            modelRepository = new CheckersModelRepository();
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(gamePanel.HandleMouseWheel);

            gameLogic.SetNextPlayerHandler(GameNextPlayer);

            gamePanel.Initialize(gameLogic, modelRepository);
            Shared.SharedCode.CurrentPlayer.Name = System.Environment.UserName;
            Shared.SharedCode.CurrentPlayer.UserImage = (Image)Checkers_3D.Resource.question_100;
            
            SetSharedSquare(true);
        }

        void GameNextPlayer(Player playerIdentifier)
        {
            this.toolStripStatusLabel1.Text = "Текущий игрок " + playerIdentifier.ToString();
                this.BeginInvoke( new AddSetSharedCallback(SetSharedSquare),
                new object[] {gameLogic.GetMainPlayer() == playerIdentifier});
        }


        private void SetSharedSquare(bool param)
        {
            if (param)
            {
                pictureBox3.Image = Shared.SharedCode.CurrentPlayer.UserImage;
                label3.Text = Shared.SharedCode.CurrentPlayer.Name;
            }
            else
            {
                pictureBox3.Image = Shared.SharedCode.EnemyPlayer.UserImage;
                label3.Text = Shared.SharedCode.EnemyPlayer.Name;
            }
        }


        private void SetFormPayersData(Player playerIdentifier)
        {
            label1.Text = Shared.SharedCode.CurrentPlayer.Name;
            label2.Text = Shared.SharedCode.EnemyPlayer.Name;
            if (playerIdentifier == Player.White)
            {
                pictureBox1.Image = Checkers_3D.Resource.White;
                pictureBox2.Image = Checkers_3D.Resource.Black;
            }
            else
            {
                pictureBox1.Image = Checkers_3D.Resource.Black;
                pictureBox2.Image = Checkers_3D.Resource.White;
            }
        }


        public void SetMenuItemCallback(int m1, int m2, bool param)
        {
            
            ToolStripItem item = ((ToolStripMenuItem)
                menuStrip1.Items[0]).DropDownItems[m1];
            if (m1 == 0)
            item = ((ToolStripMenuItem)item).DropDownItems[m2];            
            item.Enabled = param;

        
        }

        private void GetStatusConnectionServer(bool statusConnection)
        {
            run_Server = statusConnection;
            if (run_Server)
            {
                server.leftMouseDown = gamePanel.GamePanel_EnemyMouseDown;
                server.leftMouseUp = gamePanel.GamePanel_EnemyMouseUp;
                gamePanel.leftMouseDown = server.SendLeftMouseDown;
                gamePanel.leftMouseUp = server.SendLeftMouseUp;

                Random autoRand = new Random();
                gameLogic.SetMainPlayer((Player)autoRand.Next(0, 2));              
                server.SendMainPlayer(CheckersLogic.GetOtherPlayer(gameLogic.GetMainPlayer()));

                server.SendImage(Shared.SharedCode.CurrentPlayer.UserImage);            


                this.BeginInvoke(new AddSetFormPlayersCallback(SetFormPayersData),
        new object[] { gameLogic.GetMainPlayer() });
                gamePanel.InitializeNewGame();

                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 1, 0, false });
            }


        }

        private void GetStatusConnectionClient(bool statusConnection)
        {
            run_Client = statusConnection;
            if (run_Client)
            {
                client.SetReceiveMainPlayer(gameLogic.SetMainPlayer);
                client.SetReceiveMainPlayer(InitializeClientBoard);
                client.leftMouseDown = gamePanel.GamePanel_EnemyMouseDown;
                client.leftMouseUp = gamePanel.GamePanel_EnemyMouseUp;
                gamePanel.leftMouseDown = client.SendLeftMouseDown;
                gamePanel.leftMouseUp = client.SendLeftMouseUp;

                client.SendImage(Shared.SharedCode.CurrentPlayer.UserImage);

                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 1, 0, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 0, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 1, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 2, true });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 3, false });

            }
            else
            {
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 1, 0, true });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 0, true });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 1, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 2, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                    new object[] { 0, 3, true });
            }
        }

        public void InitializeClientBoard(Player playerIdentifier)
        {
            gamePanel.InitializeNewGame();
            this.BeginInvoke(new AddSetFormPlayersCallback(SetFormPayersData),
                    new object[] {playerIdentifier});
        }

        private void GetStatusCreatedServer(bool statusCreated)
        {
            creted_Server = statusCreated;
            if (creted_Server)
            {
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 0, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 1, true });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 2, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 3, false });
            }
            else
            {
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 0, true });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 1, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 2, false });
                this.BeginInvoke(new AddSetMenuItemCallback(SetMenuItemCallback),
                        new object[] { 0, 3, true });
            }
        }


        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GameOptions.Form1 options = new GameOptions.Form1();

            if (options.ShowDialog(this) == DialogResult.OK)
            {
                label3.Text = Shared.SharedCode.CurrentPlayer.Name;
                pictureBox3.Image = Shared.SharedCode.CurrentPlayer.UserImage;
            }
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            if (creted_Server)
                server.DisposeConnection();
       
        }

        private void ToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            server = new GameServer._Server();
            server.SetStatusConnection(GetStatusConnectionServer);
            server.SetStatusCreated(GetStatusCreatedServer);
            server.ShowDialog(this);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            client = new GameClient._Client();
            client.SetStatusConnection(GetStatusConnectionClient);
            client.ShowDialog(this);
        }

        private void ToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            if (run_Server)
                server.DisposeConnection();

            if (run_Client)
                client.DisposeConnection();
           
        }


        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Checkers_3D.About()).ShowDialog(this);
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new Checkers_3D.Help()).ShowDialog(this);
        }






    }
}