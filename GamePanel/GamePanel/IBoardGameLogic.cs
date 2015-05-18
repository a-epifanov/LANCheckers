using System;
using System.Collections.Generic;
using Checkers;

namespace BoardGame
{

    public delegate void NextPlayerHandler(Player playerIdentifier);
    public delegate void SendBoardState(int[,] boardState);
    public interface IBoardGameLogic
    {

        // Число строк доски
        int Rows
        {
            get;
        }

        // Число столбцов доски

        int Columns
        {
            get;
        }


        int this[int row, int column]
        {
            get;
            set;
        }


        int this[Square square]
        {
            get;
            set;
        }

        // Возвращает текущие доступные ходы

        List<Move> GetAvailableMoves();


        void Initialize();

        bool IsGameOver(out string gameOverStatement);

        //перемещение шашки из одной позиции в другую

        List<Move> Move(Square square, Square allowedSquare);
        
        void SetNextPlayerHandler(NextPlayerHandler nextPlayerHandler);
        void SetMainPlayer(Player mainPlayer);

        Player GetMainPlayer();


        bool LockMove
        {
            get;
            set;
        }

    }
}
