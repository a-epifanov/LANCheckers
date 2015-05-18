using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace Direct3D
{

    public class Model
    {

        private Mesh mesh;
        
        private Material[] material;
        private Texture[] texture;
        private bool selected;
        protected Vector3 position;

        private Vector3 positionOffset;
        protected Quaternion orientation;

        protected Vector3 scale;


        public Model(Mesh mesh, Material[] material)
        {
            this.mesh = mesh;
            this.material = material;
            this.selected = false;
            this.position = Vector3.Empty;
            this.orientation = Quaternion.Identity;
            this.positionOffset = Vector3.Empty;
            this.scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public Model(Mesh mesh, Material[] meshMaterials, Texture[] meshTextures)
        {
            this.mesh = mesh;
            this.material = meshMaterials;
            this.texture = meshTextures;
            this.selected = false;
            this.position = Vector3.Empty;
            this.orientation = Quaternion.Identity;
            this.positionOffset = Vector3.Empty;
            this.scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public Model(Mesh mesh, Material[] material, Vector3 position)
        {
            this.mesh = mesh;
            this.material = material;
            this.selected = false;
            this.position = position;
            this.orientation = Quaternion.Identity;
            this.positionOffset = Vector3.Empty;
            this.scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public void Render(Device device)
        {
            device.Transform.World = this.World;
            //for (int i = 0; i < material.Length; i++)
            //{
                device.Material = material[selected ? 1 : 0];
                //if (texture != null && texture.Length > i)
                //device.SetTexture(0, texture[i]);
                mesh.DrawSubset(0);
            //}

        }


        public Boolean Selected
        {
            get { return selected; }
            set { selected = value; } 
        }

        public Matrix World
        {
            
            get { return Matrix.Scaling(scale) * Matrix.RotationQuaternion(orientation) * Matrix.Translation(position + positionOffset); }
        }
        
        public Mesh Mesh
        {
            get { return mesh; }
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Quaternion Orientation
        {
            get { return orientation; }
            set { orientation = value; }
        }

        public Vector3 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public Vector3 PositionOffset
        {
            get { return positionOffset; }
            set { positionOffset = value; }
        }

    }
}
