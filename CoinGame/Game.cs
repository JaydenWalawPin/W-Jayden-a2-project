// Include the namespaces (code libraries) you need below.
using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{

    public class Game
    {
        // Variable that doesn't let you click the coin again while the animation is going
        Boolean AnimationProcess = false;

        // Size that the animation messes with
        float CoinHeight = 180;

        // True = Back side of coin 
        // False = Front side of coin
        Boolean coinFlipping = false;

        // Coinflip. 0 = even. 1 = odd. 2 = None
        int CoinFlipRandom = 2;
        // This variable is utterly redundant, but it makes my life easier
        string FlipState = "not yet";

        // Sets each frame of animation
        // 0 = Front shrink
        // 1 = Back expand
        // 2 = Back shrink
        // 3 = Front expand
        int AnimationFrame = 0;

        // Controls animation speed so I don't have to manually change all of the if statements every time I want to test a new speed 
        float AnimationSpeed = 500;

        // Determines the amount of Loops the coin(animation) will do
        int AnimationLoops = -1;
        // AnimationLoops' cousin that stops it from being changed forever
        Boolean AmountOfLoopsHasBeenChosen = false;

        // Stops the animation in the odd position
        Boolean StopTheOdds = false;
        // Fixes an issue of the odd never stopping and expanding forever
        Boolean StopOddsFailSafe = false;


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
            //Debug stuff
            //Console.WriteLine(AnimationFrame);
            //Console.WriteLine(AnimationLoops);

            // Determines the coin flip
            
            if (CoinFlipRandom == 2)
            {
                AmountOfLoopsHasBeenChosen = false;
                CoinFlipRandom = Random.Integer(0, 2);
            }



            // Determines how many loops the coin will do 
            // At least that's what it used to do. I changed it so both do the same amount of loops to keep the suspence
            // I could probably change this code and everything would be fine
            // but you will not catch my living body touching this part of the code

            if (CoinFlipRandom == 0 && AmountOfLoopsHasBeenChosen == false)
            {
                FlipState = "Odd";
                AnimationLoops = 2;
                AmountOfLoopsHasBeenChosen = true;
            }
            else if (CoinFlipRandom == 1 && AmountOfLoopsHasBeenChosen == false)
            {
                FlipState = "Even";
                AnimationLoops = 2;
                AmountOfLoopsHasBeenChosen = true;
            }

            // Supposed to flip the coins between the front and back while the animation plays
            // It works now!!

            if (CoinHeight <= 0)
            {
                coinFlipping = true;
            }
            if (CoinHeight >= 180)
            {
                coinFlipping = false;
            }

            // -----------------------------
            // -----------------------------
            // -----------------------------
            //        ANIMATION HELL
            // -----------------------------
            // -----------------------------
            // -----------------------------

            // Checks if the Mouse clicked to started the coin flip
            if (Input.IsMouseButtonPressed(MouseButton.Left) == true && AnimationProcess == false)
            {
                AnimationProcess = true;
            }

            // front shrink animation
            if ((AnimationProcess == true) && coinFlipping == false && AnimationFrame == 0) 
            {
                Window.ClearBackground(84, 91, 120);
                Draw.SetFillColor(232, 203, 32);
                Draw.Ellipse(200, 200, 180, CoinHeight);
                CoinHeight += Time.DeltaTime * -AnimationSpeed;
                AnimationFrame = 0;
            }

            // Back expand animation
            if (AnimationProcess == true && coinFlipping == true && AnimationFrame == 0 || AnimationFrame == 1)
            {
                if (StopTheOdds == false)
                {
                    Window.ClearBackground(84, 91, 120);
                    Draw.SetFillColor(212, 162, 0);
                    Draw.Ellipse(200, 200, 180, CoinHeight);
                    CoinHeight += Time.DeltaTime * AnimationSpeed;
                    AnimationFrame = 1;
                }

                // Makes the of the coin be the odd side if the random number generator lands on odd
                if (StopTheOdds == true && AnimationLoops == 0 && CoinHeight < 180)
                {
                    Window.ClearBackground(84, 91, 120);
                    Draw.SetFillColor(212, 162, 0);
                    Draw.Ellipse(200, 200, 180, CoinHeight);
                    CoinHeight += Time.DeltaTime * AnimationSpeed;
                    AnimationFrame = 1;
                }

                else if (StopTheOdds == true && AnimationLoops == 0 && CoinHeight >= 180)
                {
                    StopOddsFailSafe = true;
                }
            }

            // Back shrink animation
            if (AnimationProcess == true && coinFlipping == false && StopTheOdds == false && AnimationFrame == 1 || AnimationFrame == 2)
            {
                Window.ClearBackground(84, 91, 120);
                Draw.SetFillColor(212, 162, 0);
                Draw.Ellipse(200, 200, 180, CoinHeight);
                CoinHeight += Time.DeltaTime * -AnimationSpeed;
                AnimationFrame = 2;
            }

            // front expand animation
            if ((AnimationProcess == true) && coinFlipping == true && StopTheOdds == false && AnimationFrame == 2 || AnimationFrame == 3)
            {
                Window.ClearBackground(84, 91, 120);
                Draw.SetFillColor(232, 203, 32);
                Draw.Ellipse(200, 200, 180, CoinHeight);
                CoinHeight += Time.DeltaTime * AnimationSpeed;
                AnimationFrame = 3;
            }

            // Resets the animation
            if (AnimationProcess == true && AnimationFrame == 3 && coinFlipping == false)
            {
                AnimationFrame = 0;
                AnimationLoops -= 1;
            }

            // When animation ends, end the animation
            if (AnimationLoops == 0 && CoinFlipRandom == 0 && StopTheOdds == false)
            {
                AnimationProcess = false;
                coinFlipping = false;
                AnimationFrame = 0;
                CoinFlipRandom = 2;
            }

            // ends the animation when the number is odd
            if (AnimationLoops == 0 && CoinFlipRandom == 1)
            {
                StopTheOdds = true;
                CoinFlipRandom = 1;
            }

            if (AnimationLoops == 0 && CoinFlipRandom == 1 && StopTheOdds == true && StopOddsFailSafe == true)
            {
                CoinFlipRandom = 0;
                StopOddsFailSafe = false;
                StopTheOdds = false;
            }
            // It WOOOOORRRRKKKKKSSSSSSSSS
        }
    }
}
