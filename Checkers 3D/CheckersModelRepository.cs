using System;
using System.Drawing;
using System.Collections.Generic;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using BoardGame;
using Direct3D;
using BoardGame.Direct3D;

namespace Checkers.Direct3D
{
    class CheckersModelRepository : IBoardGameModelRepository
    {


        private Model blackSquare;
        private Model redSquare;

        private Model redPiece;
        private Model redKingPiece;

        private Model blackPiece;
        private Model blackKingPiece;

        private Mesh mesh;
        private Material[] meshMaterials = null;
        private Texture[] meshTextures = null;

        public CheckersModelRepository()
        {
        }



        public void Initialize(Microsoft.DirectX.Direct3D.Device device)
        {
          
            Mesh blockMesh = Mesh.Box(device, 1.0f, 0.5f, 1.0f).Clone(MeshFlags.Managed, VertexFormats.PositionNormal | VertexFormats.Specular, device);
            // Создание красного и чёрного материала и их осветлённых копий
            Material darkRedMaterial = new Material();
            darkRedMaterial.Ambient = Color.Black;
            darkRedMaterial.Diffuse = Color.Black;


            Material highlightedRedMaterial = new Material();
            highlightedRedMaterial.Ambient = Color.LightSalmon;
            highlightedRedMaterial.Diffuse = Color.LightSalmon;

            Material squareBlackMaterial = new Material();
            Color squareBlack = Color.FromArgb(0xFF, 0xFA, 0xFA, 0xFA);
            squareBlackMaterial.Ambient = squareBlack;
            squareBlackMaterial.Diffuse = squareBlack;
            
            Material blackMaterial = new Material();
            Color almostBlack = Color.FromArgb(0xFF, 0x10, 0x10, 0x10);
            blackMaterial.Ambient = almostBlack;
            blackMaterial.Diffuse = almostBlack;

            Material highlightedBlackMaterial = new Material();
            Color squarehighlightedBlackMaterial = Color.FromArgb(0xFF, 0xFF, 0x15, 0x1C);
            highlightedBlackMaterial.Ambient = squarehighlightedBlackMaterial;
            highlightedBlackMaterial.Diffuse = squarehighlightedBlackMaterial;

            blackSquare = new Model(blockMesh, new Material[] {squareBlackMaterial, highlightedBlackMaterial});
            redSquare = new Model(blockMesh, new Material[] { darkRedMaterial, highlightedRedMaterial });

            blackSquare.PositionOffset = new Vector3(0.0f, -0.25f, 0.0f);
            redSquare.PositionOffset = new Vector3(0.0f, -0.25f, 0.0f);

            LoadMesh(@"..\..\Resources\WhiteMan.X", device, out mesh, ref meshMaterials, ref meshTextures);
            redPiece = new Model(mesh, meshMaterials, meshTextures);

            LoadMesh(@"..\..\Resources\BlackMan.X", device, out mesh, ref meshMaterials, ref meshTextures);
            blackPiece = new Model(mesh, meshMaterials, meshTextures);
            LoadMesh(@"..\..\Resources\WhiteKing.X", device, out mesh, ref meshMaterials, ref meshTextures);
            redKingPiece = new Model(mesh, meshMaterials, meshTextures);
            LoadMesh(@"..\..\Resources\BlackKing.X", device, out mesh, ref meshMaterials, ref meshTextures);
            blackKingPiece = new Model(mesh, meshMaterials, meshTextures);



            redPiece.PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);
            redKingPiece.PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);
            blackPiece.PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);
            blackKingPiece.PositionOffset = new Vector3(0.0f, 0.0f, 0.0f);


            Quaternion rotation = Quaternion.RotationAxis(new Vector3(1.0f, 0.0f, 0.0f), (float)Math.PI / 2.0f);
            redPiece.Orientation = rotation;
            blackPiece.Orientation = rotation;
            redKingPiece.Orientation = rotation;
            blackKingPiece.Orientation = rotation;
        }

        public Model GetBoardSquareModel(Square square)
        {
            if ((square.Column + square.Row) % 2 == 0)
                return blackSquare;
            else
                return redSquare;
        }

        public Model GetBoardPieceModel(int pieceId)
        {
            if (pieceId == CheckersLogic.PieceStateBlack)
                return blackPiece;
            if (pieceId == CheckersLogic.PieceStateBlackKing)
                return blackKingPiece;
            if (pieceId == CheckersLogic.PieceStateRed)
                return redPiece;
            if (pieceId == CheckersLogic.PieceStateRedKing)
                return redKingPiece;

            return null;
        }

        public void LoadMesh(string file,  Device device, out Mesh mesh, ref Material[] meshMaterials,
            ref Texture[] meshTextures)
        {

            ExtendedMaterial[] mtrl;
            mesh = Mesh.FromFile(file, MeshFlags.Managed, device, out mtrl);
            if ((mtrl != null) && (mtrl.Length > 0))
            {
                meshMaterials = new Material[mtrl.Length];
                meshTextures = new Texture[mtrl.Length];

                for (int i = 0; i < mtrl.Length; i++)
                {
                    meshMaterials[i] = mtrl[i].Material3D;
                    if ((mtrl[i].TextureFilename != null) && (mtrl[i].TextureFilename != string.Empty))
                    {

                        meshTextures[i] = TextureLoader.FromFile(device,
                           @"../../Resources/" + mtrl[i].TextureFilename);
                    }
                }
            }
        }

    }

}
