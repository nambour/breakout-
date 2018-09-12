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

        private Bat _nPCBat;

        private Bat _playerBat;

        private List<Ball> _balls;

        private Font _font;

        public enum State
        {

        }


        public Breakout(Window w)
        {
            _gameWindow = w;
            _playerBat = new Bat(0,0, 100, 20);
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

        public void Update()
        {
            
        }

        public void Draw()
        {
            _gameWindow.Clear(Color.Black);
           
            _playerBat.Draw();
            
            _gameWindow.Refresh(60);
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