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
        private Window _gameWindow;

        private Wall _wall;

        private Bat _npcBat;

        private Bat _playerBat;

        private List<Bat> _bats = new List<Bat>();

        private Ball _playerBall;

        private Ball _npcBall;

        private Font _font;

        private List<Color> Rainbow;

        private List<Line> _borad;
        

        public Breakout(Window w)
        {
            _gameWindow = w;

            Point2D ptTopLeft = new Point2D() {X = 0, Y = 0};
            Point2D ptBottomLeft = new Point2D() {X = 0, Y = w.Height};
            Point2D ptTopRight = new Point2D() {X = w.Width, Y = 0};
            Point2D ptBottomRight = new Point2D() {X = w.Width, Y = w.Height};
            Line leftLine;
            Line rightLine;
            leftLine.StartPoint = ptTopLeft;
            leftLine.EndPoint = ptBottomLeft;
            rightLine.StartPoint = ptTopRight;
            rightLine.EndPoint = ptBottomRight;

            _borad.Add(leftLine);
            _borad.Add(rightLine);


            _playerBat = new Bat(Color.Blue, w.Width/2, w.Height*0.95, 80, 10);
            _bats.Add(_playerBat);
            
            _wall = new Wall(w);

            _playerBall = new Ball(w, Color.Aqua, _playerBat, 7);


        }

        public void Initialize()
        {

        }

        public void HandleInput()
        {
            SplashKit.ProcessEvents();
            
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _playerBat.MoveLeft();
            }
            else if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _playerBat.MoveRight();
            }

            _playerBat.StayOnWindow(_gameWindow);

            
        }

        public void CheckCollision()
        {
            _playerBall.CheckCollision(_borad, _bats, _wall);
        }

        public void Update()
        {

                _playerBall.Update();    
            
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.Black);
           
            _playerBat.Draw();

            _wall.Draw();

            
            _playerBall.Draw();
            
            
            _gameWindow.Refresh();
        }

        public void ShowMenu()
        {

        }

        public void AddBall()
        {

        }

        public void Start()
        {

        }

        public void End()
        {

        }

        public void Restart()
        {
            
        }


    }
}