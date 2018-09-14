using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public class Wall
    {
        private const int _ROW = 7;
        private const int _BRICKWIDTH = 80;
        public List<Brick> Bricks = new List<Brick>();

        private List<Color> _rainbow = new List<Color>(7);
        

        public Wall(Window w)
        {   
            var col = w.Width/_BRICKWIDTH;

            _rainbow.Add(Color.Red);
            _rainbow.Add(Color.Orange);
            _rainbow.Add(Color.Yellow);
            _rainbow.Add(Color.Green);
            _rainbow.Add(Color.Blue);
            _rainbow.Add(Color.Indigo);
            _rainbow.Add(Color.Violet);

            for (int n = 0; n < _rainbow.Count; n++)
            {   
                for (int i = 0; i < col; i++)
                {
                    Brick brick = new Brick(_rainbow[n], _BRICKWIDTH*i, w.Height/2-7*20/2+n*20, 80, 20);
                    Bricks.Add(brick);
                }
            }   

        }

        public void Draw()
        {
            foreach(Brick b in Bricks)
            {
                b.Draw();
            }
        }
    }   
}

