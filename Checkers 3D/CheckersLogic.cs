using System;
using System.Collections.Generic;
using BoardGame;
using System.Threading;

namespace Checkers
{

    // Ётот класс представл€ет логику игры
    class CheckersLogic : IBoardGameLogic
    {
        public static readonly int PieceStateRed = 1;
        public static readonly int PieceStateRedKing = 2;
        public static readonly int PieceStateBlack = 3;
        public static readonly int PieceStateBlackKing = 4;
        

        private NextPlayerHandler nextPlayerHandler;
        public int[,] boardState;
        private bool lockMove = true;
        private Player mainPlayer = Player.White;
        private Player currentPlayer;

        public CheckersLogic() 
        {
            this.boardState = new int[this.Rows, this.Columns];
        }

        private void OnNextPlayer(Player playerIdentifier)
        {
            if (nextPlayerHandler != null)
            {
                /*ParameterizedThreadStart threadDelegate = new ParameterizedThreadStart(nextPlayerHandler);
                Thread newThread = new Thread(threadDelegate);
                newThread.Start(currentPlayer);
                */

                nextPlayerHandler(currentPlayer);
                if (currentPlayer == mainPlayer)
                    lockMove = false;
                else
                    lockMove = true;
            }
        }

        public void Initialize()
        {
            // ќчистка всех площадок
            for (int row = 0; row < this.Rows; ++row)
            {
                for (int column = 0; column < this.Columns; ++column)
                {
                    boardState[row, column] = 0;
                }
            }

            // –азмещение 24 шашек
            for (int i = 0; i < 4; ++i)
            {
                boardState[0, i * 2] = CheckersLogic.PieceStateRed;
                boardState[1, i * 2 + 1] = CheckersLogic.PieceStateRed;
                boardState[2, i * 2] = CheckersLogic.PieceStateRed;

                boardState[7, i * 2 + 1] = CheckersLogic.PieceStateBlack;
                boardState[6, i * 2] = CheckersLogic.PieceStateBlack;
                boardState[5, i * 2 + 1] = CheckersLogic.PieceStateBlack;
            }

            currentPlayer = Player.White;
            OnNextPlayer(currentPlayer);
        }




        private int CountPiecesLeft(Player player)
        {
            int[] playersBoardState = GetPlayersSquareState(player);
            int numberOfPiecesLeft = 0;
            for (int row = 0; row < this.Rows; ++row)
            {
                for (int column = 0; column < this.Columns; ++column)
                {
                    if (this[row, column] == playersBoardState[0] || this[row, column] == playersBoardState[1])
                    {
                        ++numberOfPiecesLeft;
                    }
                }
            }
            return numberOfPiecesLeft;
        }



        //¬озвращает trye если конец игры.
        private bool HasPlayerLost(Player player)
        {
            if (CountPiecesLeft(player) == 0)
                return true;

            if (CountPiecesLeft(CheckersLogic.GetOtherPlayer(player)) == 0)
                return false;

            GetAvailableMoves();
            return !(GetAvailableMoves().Count > 0);
        }

        public List<Move> GetAvailableMoves()
        {
            List<Move> normalMoves = new List<Move>();
            List<Move> capturingMoves = new List<Move>();

            int[] playersBoardState = CheckersLogic.GetPlayersSquareState(currentPlayer);
            int[] otherPllayersBoardState = CheckersLogic.GetPlayersSquareState(CheckersLogic.GetOtherPlayer(currentPlayer));

            int forwardDirection = (currentPlayer == Player.White ? 1 : -1);

            for (int row = 0; row < this.Rows; ++row)
            {
                for (int column = 0; column < this.Columns; ++column)
                {
                    if (boardState[row, column] == playersBoardState[0])
                        CheckNormalPieces(normalMoves, capturingMoves, otherPllayersBoardState, new int[] { forwardDirection }, row, column);

                    if (boardState[row, column] == playersBoardState[1])
                        CheckNormalPieces(normalMoves, capturingMoves, otherPllayersBoardState, new int[] { 1, -1 }, row, column);
                }
            }

            if (capturingMoves.Count > 0)
                return capturingMoves;
            else
                return normalMoves;
        }

        private void CheckNormalPieces(List<Move> normalMoves, List<Move> capturingMoves, int[] otherPllayersBoardState, int[] rowDirections, int row, int column)
        {
            List<Square> normalMoveDestinations = new List<Square>();
            List<Square> capturingMoveDestinations = new List<Square>();

            foreach (int rowDirection in rowDirections)
            {
                if (this[row, column] == PieceStateRedKing || this[row, column] == PieceStateBlackKing)
                {
                    int kingRowA = row + rowDirection;
                    int kingColumnA = column + rowDirection;
                    int kingRowB = row + rowDirection * 2;
                    int kingColumnB = column + rowDirection * 2;
                    bool capturing = false;

                    while ((kingRowA >= 0 && kingRowA < this.Rows) &&
                        (kingColumnA >= 0 && kingColumnA < this.Columns))
                    {

                        if (this[kingRowA, kingColumnA] == 0 && (!capturing))
                            normalMoveDestinations.Add(new Square(kingRowA, kingColumnA));
                        else
                        {
                            if (this[kingRowB, kingColumnB] == 0)
                            {
                                if ((this[kingRowA, kingColumnA] == otherPllayersBoardState[0] ||
                        this[kingRowA, kingColumnA] == otherPllayersBoardState[1]) || capturing)
                                {
                                    capturingMoveDestinations.Add(new Square(kingRowB, kingColumnB));
                                    capturing = true;
                                }
                                else break;
                            }
                            else break;
                        }
                        kingRowA += rowDirection;
                        kingColumnA += rowDirection;
                        kingRowB += rowDirection;
                        kingColumnB += rowDirection;

                    }

                    kingRowA = row + rowDirection;
                    kingColumnA = column - rowDirection;
                    kingRowB = row + rowDirection * 2;
                    kingColumnB = column - rowDirection * 2;
                    capturing = false;

                    while ((kingRowA >= 0 && kingRowA < this.Rows) &&
                        (kingColumnA >= 0 && kingColumnA < this.Columns))
                    {


                        if (this[kingRowA, kingColumnA] == 0 && (!capturing))
                            normalMoveDestinations.Add(new Square(kingRowA, kingColumnA));
                        else
                        {
                            if (this[kingRowB, kingColumnB] == 0)
                            {
                                if ((this[kingRowA, kingColumnA] == otherPllayersBoardState[0] ||
                        this[kingRowA, kingColumnA] == otherPllayersBoardState[1]) || capturing)
                                {
                                    capturingMoveDestinations.Add(new Square(kingRowB, kingColumnB));
                                    capturing = true;
                                }
                                else break;
                            }
                            else break;
                        }
                        kingRowA += rowDirection;
                        kingColumnA -= rowDirection;
                        kingRowB += rowDirection;
                        kingColumnB -= rowDirection;
                    }
                }
                else
                {
                    int tryRowA = row + rowDirection;
                    int tryRowB = row + rowDirection * 2;
                    int tryRowC = row - rowDirection * 2;
                    int tryRowD = row - rowDirection;
                    int tryColumnA1 = column + 1;
                    int tryColumnA2 = column - 1;
                    int tryColumnB1 = column + 2;
                    int tryColumnB2 = column - 2;

                    if (this[tryRowA, tryColumnA1] == 0)
                        normalMoveDestinations.Add(new Square(tryRowA, tryColumnA1));
                    else
                    {
                        if (this[tryRowB, tryColumnB1] == 0 &&
                            (this[tryRowA, tryColumnA1] == otherPllayersBoardState[0] || this[tryRowA, tryColumnA1] == otherPllayersBoardState[1]))
                            capturingMoveDestinations.Add(new Square(tryRowB, tryColumnB1));
                    }

                    if (this[tryRowA, tryColumnA2] == 0)
                        normalMoveDestinations.Add(new Square(tryRowA, tryColumnA2));
                    else
                    {
                        if (this[tryRowB, tryColumnB2] == 0 &&
                            (this[tryRowA, tryColumnA2] == otherPllayersBoardState[0] || this[tryRowA, tryColumnA2] == otherPllayersBoardState[1]))
                            capturingMoveDestinations.Add(new Square(tryRowB, tryColumnB2));
                    }

                    if (this[tryRowC, tryColumnB1] == 0 &&
                            (this[tryRowD, tryColumnA1] == otherPllayersBoardState[0] || this[tryRowD, tryColumnA1] == otherPllayersBoardState[1]))
                        capturingMoveDestinations.Add(new Square(tryRowC, tryColumnB1));

                    if (this[tryRowC, tryColumnB2] == 0 &&
                           (this[tryRowD, tryColumnA2] == otherPllayersBoardState[0] || this[tryRowD, tryColumnA2] == otherPllayersBoardState[1]))
                        capturingMoveDestinations.Add(new Square(tryRowC, tryColumnB2));
                }
                if (normalMoveDestinations.Count > 0)
                    normalMoves.Add(new Move(new Square(row, column), normalMoveDestinations));

                if (capturingMoveDestinations.Count > 0)
                    capturingMoves.Add(new Move(new Square(row, column), capturingMoveDestinations));
            }
        }

        

        public static int[] GetPlayersSquareState(Player player)
        {
            return (player == Player.White ?
                new int[] { CheckersLogic.PieceStateRed, CheckersLogic.PieceStateRedKing } :
                new int[] { CheckersLogic.PieceStateBlack, CheckersLogic.PieceStateBlackKing });
        }

        // получение другого игрока
        public static Player GetOtherPlayer(Player player)
        {
            return player == Player.White ? Player.Black : Player.White;
        }



        //перемещение из текущей позициии в позицию назначени€
        public List<Move> Move(Square origin, Square destination)
        {
            int rowDelta = destination.Row - origin.Row;
            int columnDelta = Math.Sign(destination.Column - origin.Column);
            this[destination] = this[origin];
            this[origin] = 0;
            

            if ((destination.Row == (this.Rows - 1)) && (this[destination] == CheckersLogic.PieceStateRed))
                this[destination] = CheckersLogic.PieceStateRedKing;

            if ((destination.Row == 0) && (this[destination] == CheckersLogic.PieceStateBlack))
                this[destination] = CheckersLogic.PieceStateBlackKing;

            if (Math.Abs(rowDelta) >= 2)
            if (this[destination.Row, destination.Column] == PieceStateRedKing ||
                this[destination.Row, destination.Column] == PieceStateBlackKing)
            {
                int countBefore = CountPiecesLeft(CheckersLogic.GetOtherPlayer(currentPlayer));
                for (int diagonal = 1; diagonal < Math.Abs(rowDelta); diagonal++)
                    if (rowDelta > 0 && columnDelta > 0)
                        this[origin.Row + diagonal, origin.Column + diagonal] = 0;
                    else
                        if (rowDelta > 0 && columnDelta < 0)
                            this[origin.Row + diagonal, origin.Column - diagonal] = 0;
                        else
                            if (rowDelta < 0 && columnDelta > 0)
                                this[origin.Row - diagonal, origin.Column + diagonal] = 0;
                            else
                                this[origin.Row - diagonal, origin.Column - diagonal] = 0;

                int countAfter = CountPiecesLeft(CheckersLogic.GetOtherPlayer(currentPlayer));
                if (countBefore - countAfter != 0)
                {
                    List<Move> availableMoves = GetAvailableMoves();
                    if (availableMoves.Count > 0)
                    {
                        foreach (Move move in availableMoves)
                        {
                            if (move.Origin.Equals(destination) && Math.Abs(move.Origin.Row - move.Destinations[0].Row) >= 2)
                                return availableMoves;
                        }
                    }
                }
            }
            else

                if (Math.Abs(rowDelta) == 2)
                {
                    this[origin.Row + Math.Sign(rowDelta), origin.Column + columnDelta] = 0; // TODO: Fix this magic value (Empty)

                    List<Move> availableMoves = GetAvailableMoves();
                    if (availableMoves.Count > 0)
                    {
                        foreach (Move move in availableMoves)
                        {
                            if (move.Origin.Equals(destination) && move.IsCapturing)
                                return availableMoves;
                        }
                    }
                }

            currentPlayer = CheckersLogic.GetOtherPlayer(currentPlayer);
            OnNextPlayer(currentPlayer);
            return GetAvailableMoves();
        }

        public int Rows
        {
            get { return 8; }
        }

        public int Columns
        {
            get { return 8; }
        }

        public int this[int row, int column]
        {
            get
            {
                if (row >= 0 && row < this.Rows && column >= 0 && column < this.Columns)
                    return boardState[row, column];
                else
                    return -1;
            }
            set
            {
                boardState[row, column] = value;
            }
        }

        public int this[Square square]
        {
            get
            {
                return this[square.Row, square.Column];
            }
            set
            {
                this[square.Row, square.Column] = value;
            }
        }

        public bool IsGameOver(out string gameOverStatement)
        {
            gameOverStatement = null;
            if (HasPlayerLost(Player.Black))
            {
                gameOverStatement = "„Єрные проиграли!";
                return true;
            }

            if (HasPlayerLost(Player.White))
            {
                gameOverStatement = " расные проиграли!";
                return true;
            }

            return false;
        }

        public void SetBoardState(int[,] boardState)
        {
            this.boardState = boardState;
        }

        public void SetNextPlayerHandler(NextPlayerHandler nextPlayerHandler)
        {
            this.nextPlayerHandler = nextPlayerHandler;
        }

        public void SetMainPlayer(Player mainPlayer)
        {
            this.mainPlayer = mainPlayer;
            OnNextPlayer(currentPlayer);
        }

        public Player GetMainPlayer()
        {
            return mainPlayer;
        }



        public bool LockMove
        {
            get { return this.lockMove; }
            set { this.lockMove = value; }
        }

    }
}
