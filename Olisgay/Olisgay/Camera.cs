using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olisgay
{
    static class Camera
    {


        public static Vector2 Position;

        public static float Zoom;

        public static Vector2 Origin;

        private static bool UpdateMatrix;

        public static float CameraSpeed;

        public static Rectangle Viewport { get; set; }

        public static Rectangle WorldRect { get; set; }

        public static Matrix Transform = Matrix.Identity;

        public static void Initialize()
        {
            CameraSpeed = 4f;

            Position = new Vector2(0, 0);

            Origin = new Vector2(Viewport.Width / 2, Viewport.Height / 2);
        }


        public static void Update()
        {

            if (IsKeyDown(Keys.Left))
            {

                Position += new Vector2(-CameraSpeed, 0);

                UpdateMatrix = true;

            }

            if (IsKeyDown(Keys.Right))
            {

                Position += new Vector2(CameraSpeed, 0);

                UpdateMatrix = true;

            }

            if (IsKeyDown(Keys.Up))
            {

                Position += new Vector2(0, -CameraSpeed);

                UpdateMatrix = true;

            }

            if (IsKeyDown(Keys.Down))
            {

                Position += new Vector2(0, CameraSpeed);

                UpdateMatrix = true;

            }
        }
        public static Matrix TransformMatrix()

        {

            if (UpdateMatrix)

{

            Transform = Matrix.CreateTranslation(new Vector3(-Position, 0)) *

                        Matrix.CreateTranslation(new Vector3(Origin, 0));

             UpdateMatrix = false;

}

                       return Transform;

        }



    }
}
