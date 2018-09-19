using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public class Wall
    {
        public List<Brick> Bricks = new List<Brick>();

        private List<Color> _rainbow = new List<Color>(7);
        

        public Wall(Window w)
        {   
            _rainbow.Add(Color.Red);
            _rainbow.Add(Color.Orange);
            _rainbow.Add(Color.Yellow);
            _rainbow.Add(Color.Green);
            _rainbow.Add(Color.Blue);
            _rainbow.Add(Color.Indigo);
            _rainbow.Add(Color.Violet);

            var column = Math.Floor(Convert.ToDouble(w.Width/Constants.BrickWidth));

            for (int n = 0; n < _rainbow.Count; n++)
            {   
                for (int i = 0; i < column; i++)
                {
                    Brick b = new Brick(_rainbow[n], Constants.BrickWidth*i, w.Height/2 - 70 + n*20, 80, 20);
                    Bricks.Add(b);
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

