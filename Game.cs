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

        private Wall _wall;

        private Bat _npc;

        private Bat _player;

        private List<Bat> _bats = new List<Bat>();

        private Ball _playerBall;

        private Ball _npcBall;

        private Font _font;

        private List<Color> Rainbow;

        private Border _border;

        public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler OnBallLaunch;


        

        

        

        public Breakout(Window w)
        {
            GameWindow = w;

            _border =  new Border(w);

            _player = new Player(Color.Blue, w.Width/2, w.Height*0.95, 80, 10);
            _bats.Add(_player);
            
            _wall = new Wall(w);

            _playerBall = new Ball(w, Color.Aqua, _player, 7);

            //_playerBall.HasLaunched(_player, EventArgs.Empty);


        }

        public void Initialize()
        {
            //register event 
            _playerBall.Subscribe(this);
            
            
        }

        public void HandleInput()
        {
            SplashKit.ProcessEvents();
            
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _player.MoveLeft();
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _player.MoveRight();
            }

            else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                if(OnBallLaunch != null)
                {
                    OnBallLaunch(this, EventArgs.Empty);
                }               
            }

            _player.StayOnWindow(GameWindow);

            
        }

        public void CheckCollision()
        {
            CheckBall(_playerBall, _border);
            CheckBall(_playerBall, _player);
            CheckBall(_playerBall, _wall);
        }

        private void CheckBall(Ball ball, Border border)
        {
            foreach (Line line in _border.Lines)
            {
                
                if (SplashKit.LineIntersectsCircle(line, _playerBall.Circle))
                {
                    
                    Console.WriteLine("Hit Border");

                    _playerBall.HasCollided(_player, EventArgs.Empty);
                }
            }

        }

        private void CheckBall(Ball ball, Bat bat)
        {

        }

        private void CheckBall(Ball ball, Wall wall)
        {

        }


        public void Update()
        {

            _playerBall.Update();

                
            
        }

        public void Draw()
        {
            GameWindow.Clear(Color.Black);

            _wall.Draw();
           
            _player.Draw();
            
            _playerBall.Draw();
            
            GameWindow.Refresh();
        }


        public void AddBall()
        {

        }


        


    }
}
