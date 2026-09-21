// Include the namespaces (code libraries) you need below.
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
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 400);
            Window.SetTitle("Coin Flip Game");
            Draw.SetFillColor(232, 203, 32);
            Draw.Ellipse(200, 200, 180, 180);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {


            if (Input.IsMouseButtonPressed(MouseButton.Left) == true)
            {
                Window.ClearBackground(84, 91, 120);
            }
            else if (Input.IsMouseButtonReleased(MouseButton.Left) == true)
            {
                Draw.SetFillColor(232, 203, 32);
                Draw.Ellipse(200, 200, 180, 180);
            }
        }
    }

}
