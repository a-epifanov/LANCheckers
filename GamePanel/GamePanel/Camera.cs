using System;
using Microsoft.DirectX;

namespace Direct3D
{

    class Camera
    {
        private Vector3 position;
        private Vector3 upDirection;

        private Vector3 lookAtTarget;


        public Camera(Vector3 position, Vector3 upDirection, Vector3 lookAtTarget)
        {
            this.position = position;
            this.upDirection = upDirection;
            this.lookAtTarget = lookAtTarget;
        }

        public Matrix ViewMatrix
        {
            get { return Matrix.LookAtLH(position, lookAtTarget, upDirection); }
        }

        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector3 LookAtTarget
        {
            get { return lookAtTarget; }
            set { lookAtTarget = value; }
        }

    }
}
