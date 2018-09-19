using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public class Ball
    {
        public double X {get; set;}

        public double Y {get; set;}

        public int Radius {get; set;}

        private Vector2D Velocity {get; set;}

        protected Color MainColor {get;set;}

        public Circle Circle;

        private enum group {player, npc};

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

        
        public void Subscribe(Breakout theGame)
        {
           // theGame.BallLaunch += new Breakout.BallLaunchHandler(HasLaunched);
           theGame.OnBallLaunch += HasLaunched;
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

            Circle.Center.X = X;
            Circle.Center.Y = Y;
            Circle.Radius = Radius;
        }

        
        public void HasLaunched(Object sender, EventArgs e)
        {
            Breakout game = (Breakout) sender;
            Random random = new Random();
            var randomX = random.Next(0,game.GameWindow.Width);
            Point2D fromPt = new Point2D() {X = X, Y = Y};
            Point2D toPt = new Point2D() {X = randomX, Y = 100};

            Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
            Velocity = SplashKit.VectorMultiply(dir, Constants.BallSpeed);

            Console.WriteLine("Ball Launched");

        }


        public void HasCollided(Object sender, EventArgs e)
        {
            Point2D fromPt = new Point2D() {X = 0, Y = 100};
            Point2D toPt = new Point2D() {X = 200, Y = 500};
            
            Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
            Velocity = SplashKit.VectorMultiply(dir, Constants.BallSpeed);
            Console.WriteLine("Ball Bounced");
        }

        






    }

}