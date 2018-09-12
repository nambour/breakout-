//SIT771 6.3
//Breakout: Opposition
//

using System;
using SplashKitSDK;

namespace Breakout
{
    public class Program
    {
        
        public static void Main()
        {
            Window gameWindow = new Window("Breakout: Opposition", 600, 800);
            Breakout game = new Breakout(gameWindow);

            //const uint FRAMES_PER_SECOND = 60;
            //const uint SKIP_TICKS = 1000 / FRAMES_PER_SECOND;

            //Timer loop = SplashKit.CreateTimer("loop");

            //uint sleeptime = 1;

            while(!gameWindow.CloseRequested)
            {
                //loop.Start();
                game.HandleInput();
                game.Update();
                game.Draw();

               
                
                 //sleeptime = loop.Ticks - SKIP_TICKS;
                //Console.WriteLine(loop.Ticks);
            
            }
            

        }
    }
}
