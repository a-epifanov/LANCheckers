using System;
using Direct3D;

namespace BoardGame.Direct3D
{
    public interface IBoardGameModelRepository
    {
        void Initialize(Microsoft.DirectX.Direct3D.Device device);


        Model GetBoardSquareModel(Square square);

        Model GetBoardPieceModel(int pieceId);

    }
}
