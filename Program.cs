//SIT771 6.3
//Breakout: Opposition
//

using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Breakout
{
    public static class Constants
    {
        public const int GAP = 5;
        public const int BatSpeed = 20;
        public const int BallSpeed = 5;
        public const int BrickWidth = 80;

        public const int BallRadius = 5;

        public static readonly Color PlayerBallColor = Color.Aqua;

        public static readonly Color PlayerColor = Color.Blue;

        public static readonly Color NPCBallColor = Color.Aqua;

        public static readonly Color NPCColor = Color.Blue;

    }

    public class Program
    {
        
        public static void Main()
        {
            Window gameWindow = new Window("Breakout: Opposition", 800, 800);
            Breakout game = new Breakout(gameWindow);

            game.Initialize();

            while(!gameWindow.CloseRequested && !game.IsGameOver)
            {
                



                game.HandleInput();
                game.CheckCollision();
                game.Update();
                game.Draw();
                
                 
            
            }
            

        }
    }
}
