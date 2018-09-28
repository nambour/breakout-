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

        public enum BallGroup {player, npc};
        public BallGroup Group;


        private Bat _bat;

        public bool IsStandby = true;

        


        public Ball(Window w, Color color, Bat bat)
        {
            _bat = bat;
            MainColor = color;
            Radius = Constants.BallRadius;
            X = bat.X + bat.Width/2;
            Y = bat.Y - Radius;
            Circle.Center.X = X;
            Circle.Center.Y = Y;
            Circle.Radius = Radius;

            
        }

        
        public void Subscribe(Breakout theGame)
        {
           // theGame.BallLaunch += new Breakout.BallLaunchHandler(HasLaunched);
           theGame.Launch += HasLaunched;
           theGame.CollideWithBorder += HasCollidedWithBorder;
           theGame.CollideWithBrick += HasCollidedWithBrick;
           theGame.CollideWithBat += HasCollidedWithBat;
        }

        public void Draw()
        {
            SplashKit.FillCircle(MainColor, X, Y, Radius);
        }

        public void StayOnBat()
        {
            X = _bat.X + _bat.Width/2;
            Y = _bat.Y - Radius;

            Circle.Center.X = X;
            Circle.Center.Y = Y;
            Circle.Radius = Radius;
        }

        public void Update()
        {
            if (IsStandby)
            {
                StayOnBat();
            }
            else
            {
                X += Velocity.X;
                Y += Velocity.Y;

                Circle.Center.X = X;
                Circle.Center.Y = Y;
                Circle.Radius = Radius;
            }
        }

        
        public void HasLaunched(Object sender, EventArgs e)
        {
            if (IsStandby)
            {
                Breakout game = (Breakout) sender;
                Random random = new Random();
                var randomX = random.Next(0,game.GameWindow.Width);
                Point2D fromPt = new Point2D() {X = X, Y = Y};
                Point2D toPt = new Point2D() {X = randomX, Y = 100};

                Vector2D dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));
                Velocity = SplashKit.VectorMultiply(dir, Constants.BallSpeed);

                IsStandby = false;

                Console.WriteLine(this.GetType().Name + " Launched");
            }

        }
        
        public void HasCollidedWithBorder(Object sender, EventArgs e)
        {
            var normal = SplashKit.VectorFromAngle(0,1);
            var reflection = SplashKit.VectorSubtract
            (
                Velocity, SplashKit.VectorMultiply
                (
                    normal, 2*SplashKit.DotProduct
                    (
                        Velocity, normal)));


            Velocity = reflection;

            Console.WriteLine(this.GetType().Name + " Bounced");
        }

        public void HasCollidedWithBrick(Object sender, EventArgs e)
        {
            var normal = SplashKit.VectorFromAngle(90,1);
            var reflection = SplashKit.VectorSubtract
            (
                Velocity, SplashKit.VectorMultiply
                (
                    normal, 2*SplashKit.DotProduct
                    (
                        Velocity, normal)));


            Velocity = reflection;

            Console.WriteLine(this.GetType().Name + " Bounced");
        }

        public void HasCollidedWithBat(Object sender, EventArgs e)
        {
            var normal = SplashKit.VectorFromAngle(90,1);
            var reflection = SplashKit.VectorSubtract
            (
                Velocity, SplashKit.VectorMultiply
                (
                    normal, 2*SplashKit.DotProduct
                    (
                        Velocity, normal)));


            Velocity = reflection;

            Console.WriteLine(this.GetType().Name + " Bounced");
        }

    }

}