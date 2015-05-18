using System;
using System.Collections.Generic;
using Checkers;

namespace BoardGame
{

    public delegate void NextPlayerHandler(Player playerIdentifier);
    public delegate void SendBoardState(int[,] boardState);
    public interface IBoardGameLogic
    {

        // ����� ����� �����
        int Rows
        {
            get;
        }

        // ����� �������� �����

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

        // ���������� ������� ��������� ����

        List<Move> GetAvailableMoves();


        void Initialize();

        bool IsGameOver(out string gameOverStatement);

        //����������� ����� �� ����� ������� � ������

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
