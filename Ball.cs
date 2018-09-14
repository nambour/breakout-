using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public class Ball
    {
        const int SPEED = 4;
        public double X {get; set;}

        public double Y {get; set;}

        public int Radius {get; set;}

        private Vector2D Velocity {get; set;}

        protected Color MainColor {get;set;}

        public Circle Circle;

        private Bat _bat;

        


        public Ball(Window w, Color color, Bat bat, int radius)
        {
            _bat = bat;
            MainColor = color;
            Radius = radius;
            X = bat.X + bat.Width/2;
            Y = bat.Y - Radius;
            Circle.Center.X = X;
            Circle.Center.Y = Y;
            Circle.Radius = Radius;

            
        }

        public void Draw()
        {
            SplashKit.FillCircle(MainColor, X, Y, Radius);
        }

        public void StayOnBat()
        {
            X = _bat.X + _bat.Width/2;
            Y = _bat.Y - Radius;
        }

        public void Update()
        {
            X += Velocity.X;
            Y += Velocity.Y;
        }

        
        public void HasLaunched(Object sender, EventArgs e)
        {
            Bat b = (Bat)sender;

            Point2D fromPt = new Point2D()
            {
                X = X,
                Y = Y
            };
            
            Point2D toPt = new Point2D()
            {
                X = 0,
                Y = 0
            };

            Vector2D dir;
            dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
            Velocity = SplashKit.VectorMultiply(dir, SPEED);
        }

        public void CheckCollision(List<Line> boarder, List<Bat> bats, Wall wall)
        {
            if (CollidedWith(boarder))
            {
                Console.WriteLine("got it!!!");
            }

            foreach (Bat bat in bats)
            {
                if (CollidedWith(bat))
                {
                    
                }
            }

            foreach (Brick brick in wall.Bricks)
            {
                if (CollidedWith(brick))
                {
                    
                }
            }

            


        }

        public bool CollidedWith(Brick brick)
        {
            return false;
        }

        public bool CollidedWith(Bat bat)
        {
            return false;
        }

        public bool CollidedWith(List<Line> boarder)
        {
            foreach (Line line in boarder)
            {
                if (SplashKit.LineIntersectsCircle(line, this.Circle))
                {
                    return true;
                }
            }

            return false;
        }






    }

}