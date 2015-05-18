using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using Microsoft.DirectX;
using Direct3D;
using Checkers;
namespace BoardGame.Direct3D
{
    public delegate void LeftMouseDown(Square location);
    public delegate void LeftMouseUp(Square location);
    
    public class GamePanel : Panel
    {
        private IBoardGameLogic gameLogic;
        private IBoardGameModelRepository boardGameModelRepository;

        public LeftMouseDown leftMouseDown;
        public LeftMouseUp leftMouseUp;
        private Device device = null;
        private Camera camera;
        private Model selectedPieceModel;
        private Vector3 selectedPiecePosition;
        private VisualBoard board;
        private Move ponderedMove = null;
        private List<Move> availableMoves;
        private Point previousPoint = Point.Empty;

        private float cameraAngle = -((float)Math.PI / 2.0f);
        private float cameraElevation = 7.0f;
        private float cameraDistanceFactor = 1.5f;



        public GamePanel()
        {
            InitializeComponent();
        }


        private static PresentParameters CreatePresentParameters()
        {
            PresentParameters presentParameters = new PresentParameters();

            presentParameters.BackBufferFormat = Format.Unknown;
            presentParameters.SwapEffect = SwapEffect.Discard;
            presentParameters.Windowed = true;
            presentParameters.EnableAutoDepthStencil = true;
            presentParameters.AutoDepthStencilFormat = DepthFormat.D16;
            presentParameters.PresentationInterval = PresentInterval.Immediate; 
            return presentParameters;
        }

        private static void SetupDefaultLight(Device device)
        {
            device.RenderState.Ambient = Color.FromArgb(0x606060);
            device.RenderState.Lighting = true;

            device.Lights[0].Enabled = false;
            device.Lights[0].Update();
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.FromArgb(128, 128, 128);
            device.Lights[0].Direction = new Vector3(0.5f, -0.33f, 0.66f);
            device.Lights[0].Update();
            device.Lights[0].Enabled = true;
        }


        public void Initialize(IBoardGameLogic gameLogic, IBoardGameModelRepository boardGameModelRepository)
        {
            try
            {
                PresentParameters presentParameters = GamePanel.CreatePresentParameters();
                Caps caps = Manager.GetDeviceCaps(Manager.Adapters.Default.Adapter,
                                                   DeviceType.Hardware);
                CreateFlags deviceFlags;

                if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
                    deviceFlags = CreateFlags.HardwareVertexProcessing;
                else
                    deviceFlags = CreateFlags.SoftwareVertexProcessing;

                device = new Device(0, DeviceType.Hardware,
    this, deviceFlags, presentParameters);



                device.DeviceReset += new EventHandler(OnDeviceReset);

                device.RenderState.ZBufferEnable = true;
                device.RenderState.Lighting = true;
                device.RenderState.ShadeMode = ShadeMode.Gouraud;

                GamePanel.SetupDefaultLight(device);

                this.gameLogic = gameLogic;
                this.boardGameModelRepository = boardGameModelRepository;
                this.boardGameModelRepository.Initialize(device);


                camera = new Camera(new Vector3(gameLogic.Columns / 2.0f, 5.0f, -gameLogic.Rows), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(gameLogic.Columns / 2 - 0.5f, 0.0f, gameLogic.Rows / 2 - 0.5f));

                board = new VisualBoard(gameLogic, boardGameModelRepository);
                availableMoves = gameLogic.GetAvailableMoves();

                SetCameraPosition();
            }
            catch (DirectXException exception)
            {
                MessageBox.Show(exception.Message, "Упс!");
            }
        }

        public void InitializeNewGame()
        {
            gameLogic.Initialize();
            availableMoves = gameLogic.GetAvailableMoves();
            SetCameraPosition();
            Render();
        }

        private void OnDeviceReset(object sender, EventArgs e)
        {
            device.RenderState.ZBufferEnable = true;
            device.RenderState.Lighting = true;
            device.RenderState.ShadeMode = ShadeMode.Gouraud;

            GamePanel.SetupDefaultLight(device);

            Render();
        }

        public void Render()
        {
            try
            {
                device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, System.Drawing.SystemColors.Control, 1.0f, 0);
                device.BeginScene();

                device.Transform.View = camera.ViewMatrix;
                device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 4.0f, (float)Width / (float)Height, 1.0f, 100.0f);

                board.Render(device);

                if (selectedPieceModel != null)
                {
                    selectedPieceModel.Position = selectedPiecePosition;
                    selectedPieceModel.Render(device);
                }

                device.EndScene();
                device.Present();
            }
            catch {
                Render();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (device != null)
                Render();
            else
                base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (device == null)
                base.OnPaintBackground(e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GamePanel_MouseUp);
            this.ResumeLayout(false);
        }

        private void CheckForGameOver()
        {
           
            string gameOverStatement;
            if (gameLogic.IsGameOver(out gameOverStatement))
            {
                DialogResult result = MessageBox.Show(gameOverStatement + " Начать заново?", "Проиграли!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    gameLogic.SetMainPlayer(gameLogic.GetMainPlayer() == 
                        Player.White ? Player.Black : Player.White);
                    InitializeNewGame();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void SetCameraPosition()
        {
           
            float cameraX = gameLogic.Columns / 2.0f + (cameraDistanceFactor * gameLogic.Columns * (float)Math.Cos(cameraAngle));
            float cameraZ;
            if (gameLogic.GetMainPlayer() == Checkers.Player.White)
                cameraZ = gameLogic.Rows / 2.0f + (cameraDistanceFactor * gameLogic.Rows * (float)Math.Sin(cameraAngle));
            else
                cameraZ = gameLogic.Rows / 2.0f - (cameraDistanceFactor * gameLogic.Rows * (float)Math.Sin(cameraAngle));


            camera.Position = new Vector3(
                cameraX,
                cameraElevation,
                cameraZ);
        }

        public void HandleMouseWheel(object sender, MouseEventArgs e)
        {

            cameraDistanceFactor = Math.Max(0.0f, cameraDistanceFactor + Math.Sign(e.Delta) / 5.0f);
            SetCameraPosition();
            Render();
        }

        private void GamePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                cameraAngle += (e.X - previousPoint.X) / 100.0f;
                cameraElevation = Math.Max(0, cameraElevation + (e.Y - previousPoint.Y) / 10.0f);
                SetCameraPosition();
                previousPoint = e.Location;
            }

            Square square;
            if (!gameLogic.LockMove)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (ponderedMove != null)
                    {
                        if (board.GetMouseOverBlockModel(device, e.X, e.Y, out square, ponderedMove.Destinations))
                        {

                            selectedPiecePosition.X = square.Column;
                            selectedPiecePosition.Z = square.Row;
                        }
                    }
                }
                else
                {
                    board.GetMouseOverBlockModel(device, e.X, e.Y, out square, GamePanel.GetSquaresFromMoves(availableMoves));
                }
            }

            Render();
        }

        public void GamePanel_EnemyMouseDown(Square square)
        {

            foreach (Move move in availableMoves)
            {
                if (square.Equals(move.Origin))
                {
                    selectedPieceModel = board.PickUpPiece(square);
                    selectedPiecePosition = new Vector3(square.Column, 1.0f, square.Row);
                    ponderedMove = move;
                    break;
                }
            }
            Render();
        }

        public void GamePanel_EnemyMouseUp(Square square)
        {
            if (ponderedMove != null)
            {

                foreach (Square allowedSquare in ponderedMove.Destinations)
                {
                    if (square.Equals(allowedSquare))
                    {
                        availableMoves = gameLogic.Move(ponderedMove.Origin, allowedSquare);
                        break;
                    }
                }
            }
            board.DropPiece();
            selectedPieceModel = null;
            Render();

            CheckForGameOver();
        }

        private void GamePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!gameLogic.LockMove)
            {
            previousPoint = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                ponderedMove = null;
                Square square;
                if (board.GetMouseOverBlockModel(device, e.X, e.Y, out square, null))
                {

                    foreach (Move move in availableMoves)
                    {
                        if (square.Equals(move.Origin))
                        {
                            if (leftMouseDown != null)
                                leftMouseDown(square);
                            selectedPieceModel = board.PickUpPiece(square);
                            selectedPiecePosition = new Vector3(square.Column, 1.0f, square.Row);
                            ponderedMove = move;
                            break;
                        }
                    }
                }
            }
            Render();
            }
        }

        private void GamePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (!gameLogic.LockMove)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Square square;
                    if (board.GetMouseOverBlockModel(device, e.X, e.Y, out square, null))
                    {

                        if (ponderedMove != null)
                        {
                            if (leftMouseUp != null)
                                leftMouseUp(square);
                            foreach (Square allowedSquare in ponderedMove.Destinations)
                            {
                                if (square.Equals(allowedSquare))
                                {

                                    availableMoves = gameLogic.Move(ponderedMove.Origin, allowedSquare);
                                    break;
                                }
                            }
                        }
                    }
                    board.DropPiece();
                    selectedPieceModel = null;
                    Render();

                    CheckForGameOver();
                }
            }
        }

        private static List<Square> GetSquaresFromMoves(List<Move> moves)
        {
            List<Square> squares = new List<Square>();
            foreach(Move move in moves)
            {
                squares.Add(move.Origin);
            }
            return squares;
        }
    }
}
