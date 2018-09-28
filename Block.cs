using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Block
    {
        public double X {get; set;}

        public double Y {get; set;}

        public int Width {get; set;}

        public int Height {get; set;}
        
        protected Color Color {get;set;}

        public Bitmap CollisionBitmap;

        public bool IsEnabled = true;


        public Block(Color color, double x, double y, int width, int height)
        {
            Color = color;
            X = x;
            Y = y;
            Width = width;
            Height = height;

            CollisionBitmap = SplashKit.CreateBitmap("Block", Width, Height);
        }

        public void Draw()
        {
            if(IsEnabled)
            {
                CollisionBitmap.FillRectangle(Color, CollisionBitmap.BoundingRectangle());
                CollisionBitmap.Draw(X,Y);
                CollisionBitmap.SetupCollisionMask();
            }
            
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Bat: Block
    {
        public Bat(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {

        }
 
        public void StayOnWindow(Window w)
        {
            if (X + Width > w.Width - Constants.GAP)
            {
                X = w.Width - Constants.GAP - Width;
            }
            else if (X < Constants.GAP)
            {
                X = Constants.GAP;
            }
        }

        public void MoveLeft()
        {
            X -= Constants.BatSpeed;
        }

        public void MoveRight()
        {
            X += Constants.BatSpeed;
        }
    }

    public sealed class Player: Bat
    {
        public Player(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {

        }
    }

    public sealed class NPC: Bat
    {
        public NPC(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {
            
        }
    }




    /// <summary>
    /// 
    /// </summary>
    public class Brick: Block
    {
        public Brick(Color color, double x, double y, int width, int height): base(color, x, y, width, height)
        {
        }
        
    }
}