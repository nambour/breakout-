using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{

/// <summary>
/// Game Controller Class
/// </summary>
    public class Breakout
    {
        public Window GameWindow;

        public Wall Wall;

        public Bat Npc;

        public Bat Player;

        private List<Bat> _bats = new List<Bat>();

        public Ball PlayerBall;

        public Ball NpcBall;

        private Font _font;

        private List<Color> Rainbow;

        private Border _border;

        public bool IsGameOver = false;

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Launch;

        public void OnLaunch(EventArgs e)
        {
            if (Launch != null)
            {
                this.Launch(this, e);
            }
        }

        public event EventHandler CollideWithBorder;

        public void OnCollideWithBorder(EventArgs e)
        {
            if (CollideWithBorder != null)
            {
                this.CollideWithBorder(this, e);
            }
        }

        public event EventHandler CollideWithBrick;

        public void OnCollideWithBrick(EventArgs e)
        {
            if (CollideWithBrick != null)
            {
                this.CollideWithBrick(this, e);
            }
        }

        public event EventHandler CollideWithBat;

        public void OnCollideWithBat(EventArgs e)
        {
            if (CollideWithBat != null)
            {
                this.CollideWithBat(this, e);
            }
        }
        

        

        

        public Breakout(Window w)
        {
            GameWindow = w;

            _border =  new Border(w);

            Player = new Player(Constants.PlayerColor, w.Width/2, w.Height*0.95, 580, 5);
            
            _bats.Add(Player);

            Npc = new NPC(Constants.NPCColor, w.Width/2, w.Height*0.05, 1000, 5);

            _bats.Add(Npc);
            
            Wall = new Wall(w);

            PlayerBall = new Ball(w, Constants.PlayerBallColor, Player);

            NpcBall = new Ball(w,Constants.NPCBallColor, Npc);

            //_playerBall.HasLaunched(_player, EventArgs.Empty);


        }

        public void Initialize()
        {
            //register event 
            PlayerBall.Subscribe(this);
            NpcBall.Subscribe(this);
            
            
        }

        public void HandleInput()
        {
            SplashKit.ProcessEvents();
            
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                Player.MoveLeft();
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                Player.MoveRight();
            }

            else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                this.OnLaunch(EventArgs.Empty);            
            }

            Player.StayOnWindow(GameWindow);

            
        }

        public void CheckCollision()
        {
            CheckBallCollision(PlayerBall, _border);
            CheckBallCollision(PlayerBall, Wall);
            CheckBallCollision(PlayerBall, Player);

            CheckBallCollision(NpcBall, _border);
            CheckBallCollision(NpcBall, Wall);
            CheckBallCollision(NpcBall, Player);

            
            
        }

        private void CheckBallCollision(Ball ball, Border border)
        {
            foreach (Line line in _border.Lines)
            {
                
                if (SplashKit.LineIntersectsCircle(line, PlayerBall.Circle))
                {
                    this.OnCollideWithBorder(EventArgs.Empty);
                    Console.WriteLine(ball.GetType().Name + " hit " + border.GetType().Name);                 
                }
            }

        }

        private void CheckBallCollision(Ball ball, Wall wall)
        {
            var aliveBricks = -1;
            foreach (Brick brick in wall.Bricks)
            {
                if (brick.IsEnabled)
                {
                   
                    aliveBricks += 1;

                    if (SplashKit.BitmapCircleCollision(brick.CollisionBitmap, brick.X, brick.Y, ball.Circle))
                    {
                        this.OnCollideWithBrick(EventArgs.Empty);
                        brick.IsEnabled = false;

                        Console.WriteLine(ball.GetType().Name + " hit " + brick.GetType().Name);
                    }                
                }            
            }

            if (aliveBricks == 0)
            {
                IsGameOver = true;
            }
        }

        private void CheckBallCollision(Ball ball, Bat bat)
        {
            if (SplashKit.BitmapCircleCollision(bat.CollisionBitmap, bat.X, bat.Y, ball.Circle))
            {
                this.OnCollideWithBat(EventArgs.Empty);
                Console.WriteLine(ball.GetType().Name + " hit " + bat.GetType().Name);
            }

        }

        


        public void Update()
        {

            PlayerBall.Update();

                
            
        }

        public void Draw()
        {
            GameWindow.Clear(Color.Black);

            Wall.Draw();
           
            Player.Draw();
            
            PlayerBall.Draw();

            Npc.Draw();
            
            GameWindow.Refresh();
        }


        public void AddBall()
        {

        }


        


    }
}
