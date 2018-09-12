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

            while(!gameWindow.CloseRequested)
            {
                game.HandleInput();
                game.Update();
                game.Draw();
                SplashKit.Delay(100);
            }
            

        }
    }
}
