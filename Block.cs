using System;
using SplashKitSDK;

namespace Breakout
{
    public abstract class Block
    {
        public double X {get; set;}

        public double Y {get; set;}

        public int Width {get; set;}

        public int Height {get; set;}
        
        public Color MainColor {get; set;}

        public Bitmap CollisionBitmap;


        public Block(Window w, int width, int height)
        {
            X = w.Width/2;
            Y = w.Height/2;
            Width = width;
            Height = height;
            MainColor = Color.Blue;

            CollisionBitmap = SplashKit.CreateBitmap("Block", Width, Height);
            CollisionBitmap.SetupCollisionMask();
        }

        public void Draw()
        {
            CollisionBitmap.FillRectangle(MainColor,CollisionBitmap.BoundingRectangle());
            CollisionBitmap.Draw(X,Y);
        }

        public void Vanish()
        {
        }
    }

    public sealed class Bat: Block
    {
        private const int SPEED = 5;    // bat speed

        
        public Bat(Window w, int width, int height): base(w, width, height)
        {
        }

        public void StayOnWindow(Window w)
        {
            const int GAP = 10;

            if (X + Width > w.Width - GAP)
            {
                X = w.Width - GAP - Width;
            }
            else if (X < GAP)
            {
                X = GAP;
            }
        }

        public void MoveLeft()
        {
            X -= SPEED;
        }

        public void MoveRight()
        {
            X += SPEED;
        }
    }

    public sealed class Brick: Block
    {
        public Brick(Window w, int width, int height): base(w, width, height)
        {
        }
    }
}