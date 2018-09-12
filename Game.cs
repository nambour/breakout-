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
            _playerBat = new Bat(w, 100, 30);
        }

        public void Initialize()
        {

        }

        public void HandleInput()
        {
            
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