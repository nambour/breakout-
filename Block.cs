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
        
        protected Color MainColor {get;set;}

        public Bitmap CollisionBitmap;


        public Block(Color color, double x, double y, int width, int height)
        {
            MainColor = color;
            X = x;
            Y = y;
            Width = width;
            Height = height;

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


    public class Bat: Block
    {
        private const int SPEED = 20;    // bat speed

        public Bat(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {

        }
 
        public void StayOnWindow(Window w)
        {
            const int GAP = 5;
            
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


   public class Brick: Block
    {
        public Brick(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {
        }
        
    }
}