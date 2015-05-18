using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D;

namespace BoardGame.Direct3D
{
    //Этот класс визуализирует объект CheckersLogic.

    class VisualBoard
    {

        private IBoardGameLogic gameLogic;
        private IBoardGameModelRepository boardGameModelRepository;
        private Square selectedSquare = Square.Negative;
        

        private Square currentPieceOrigin = Square.Negative;


        public VisualBoard(IBoardGameLogic gameLogic, IBoardGameModelRepository boardGameModelRepository) 
        {
            this.gameLogic = gameLogic;
            this.boardGameModelRepository = boardGameModelRepository;
        }

        public void Render(Device device)
        {
            for (int row = 0; row < gameLogic.Rows; ++row)
            {
                for (int column = 0; column < gameLogic.Columns; ++column)
                {
                    Square currentSquare = new Square(row, column);

                    Model boardSquare = boardGameModelRepository.GetBoardSquareModel(currentSquare);
                    if (boardSquare != null)
                    {
                        boardSquare.Position = new Vector3((float)column, 0.0f, (float)row);
                        boardSquare.Selected = currentSquare.Equals(selectedSquare);
                        boardSquare.Render(device);
                    }


                    if (!currentPieceOrigin.Equals(currentSquare))
                    {

                        Model pieceModel = boardGameModelRepository.GetBoardPieceModel(gameLogic[currentSquare]);
                        if (pieceModel != null)
                        {
                            pieceModel.Position = new Vector3((float)column, 0.0f, (float)row);
                            pieceModel.Render(device);
                        }
                    }
                }
            }
        }



        //Этот метод позволяет проверить границу (MouseOver) на модели в 3D пространстве.

        public bool GetMouseOverBlockModel(Device device, int mouseX, int mouseY, out Square square, List<Square> highlightIfHit)
        {
            selectedSquare = Square.Negative;
            square = new Square();
            bool foundMatch = false;
            float closestMatch = int.MaxValue;
            for (int row = 0; row < gameLogic.Rows; ++row)
            {
                for (int column = 0; column < gameLogic.Columns; ++column)
                {
                    Square currentSquare = new Square(row, column);
                    Model boardSquare = boardGameModelRepository.GetBoardSquareModel(currentSquare);
                    if (boardSquare != null)
                    {
                        boardSquare.Position = new Vector3((float)column, 0.0f, (float)row);

                        Vector3 near = new Vector3(mouseX, mouseY, 0.0f);
                        Vector3 far = new Vector3(mouseX, mouseY, 1.0f);

                       
                        near.Unproject(device.Viewport, device.Transform.Projection, device.Transform.View, boardSquare.World);
                        far.Unproject(device.Viewport, device.Transform.Projection, device.Transform.View, boardSquare.World);
                        far.Subtract(near);

                        IntersectInformation closestIntersection;
                        if (boardSquare.Mesh.Intersect(near, far, out closestIntersection) && closestIntersection.Dist < closestMatch)
                        {
                            closestMatch = closestIntersection.Dist;
                            square = new Square(row, column);


                            if (highlightIfHit != null)
                            {
                                foreach (Square highlightSquare in highlightIfHit)
                                {
                                    if (highlightSquare.Equals(square))
                                    {
                                        selectedSquare = new Square(row, column);
                                    }
                                }
                            }

                            foundMatch = true;
                        }
                    }
                }
            }
            return foundMatch;
        }


        public Model PickUpPiece(Square pieceLocation)
        {
            if (pieceLocation.Row < 0 || pieceLocation.Row >= gameLogic.Rows || pieceLocation.Column < 0 || pieceLocation.Column >= gameLogic.Columns)
                return null;
                
            if (gameLogic[pieceLocation] > 0)
            {
                currentPieceOrigin = pieceLocation;
                return boardGameModelRepository.GetBoardPieceModel(gameLogic[pieceLocation]);
            }
            else
            {
                return null;
            }
        }

        public void DropPiece()
        {
            currentPieceOrigin = Square.Negative;
        }
    }
}
