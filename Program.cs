//SIT771 6.3
//Breakout: Opposition
//

using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    static class Constants
    {
        public const int GAP = 5;
        public const int BatSpeed = 20;
        public const int BallSpeed = 5;
        public const int BrickWidth = 80;

    }

    public class Program
    {
        
        public static void Main()
        {
            Window gameWindow = new Window("Breakout: Opposition", 800, 800);
            Breakout game = new Breakout(gameWindow);

            //const uint FRAMES_PER_SECOND = 60;
            //const uint SKIP_TICKS = 1000 / FRAMES_PER_SECOND;

            //Timer loop = SplashKit.CreateTimer("loop");

            //uint sleeptime = 1;

            game.Initialize();

            while(!gameWindow.CloseRequested)
            {
                //loop.Start();



                game.HandleInput();
                game.CheckCollision();
                game.Update();
                game.Draw();
                
                 //sleeptime = loop.Ticks - SKIP_TICKS;
                //Console.WriteLine(loop.Ticks);
            
            }
            

        }
    }
}
