// Include the namespaces (code libraries) you need below.
using Microsoft.VisualBasic;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        /// Variable that doesn't let you click the coin again while the animation is going
        Boolean AnimationProcess = false;
        /// Size that the animation messes with
        float CoinHeight = 180;
        /// True = Back side of coin 
        /// False = Front side of coin
        Boolean coinFlipping = false;
        /// Coinflip 
        int CoinFlipRandom = 0;


        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Coin Flip Game");
            Window.ClearBackground(84, 91, 120);
            Draw.SetFillColor(232, 203, 32);
            Draw.Ellipse(200, 200, 180, 180);
        }


        public void Update()
        {
            //  Heads is 0, Tails is 1
            int CoinFlipRandom = Random.Integer(1);
            
            // Supposed to flip the coins between the front and back while the animation plays
            // It works now!!

            if (CoinHeight <= 0)
                coinFlipping = true;
            if (CoinHeight >= 180)
                coinFlipping = false;

            //I need to change the animation a bit more because the coin flip isn't exactly there yet
            //The back side also needs to shrink to show the top side growing            

            // Checks if the Mouse clicked to started the coin flip
            if (Input.IsMouseButtonPressed(MouseButton.Left) == true && AnimationProcess == false)
            {
                AnimationProcess = true;
            }

            // front flip animation
            if ((AnimationProcess == true) && coinFlipping == false) 
            {
                Window.ClearBackground(84, 91, 120);
                Draw.SetFillColor(232, 203, 32);
                Draw.Ellipse(200, 200, 180, CoinHeight);
                CoinHeight += Time.DeltaTime * -300;
            }

            // Back flip animation
            if ((AnimationProcess == true) && coinFlipping == true)
            {
                Window.ClearBackground(84, 91, 120);
                Draw.SetFillColor(212, 162, 0);
                Draw.Ellipse(200, 200, 180, CoinHeight);
                CoinHeight += Time.DeltaTime * +300;
            }

        }
    }

}
