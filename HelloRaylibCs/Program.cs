using Raylib_cs;
using HelloRaylibCs.lib;

namespace HelloRaylibCs
{
    public class Program
    {

        [System.STAThread]
        public static void Main()
        {
            Raylib.InitWindow(800, 450, "Pong!");

            Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(0)); // Sync with monitor refresh rate for smooth animation

            Image icon = Raylib.LoadImage("ping-pong.png");

            Raylib.SetWindowIcon(icon);

            // Pedals for Pong game
            Rectangle leftPedal = new Rectangle(10, 225, 5, 90);
            Rectangle rightPedal = new Rectangle(785, 225, 5, 90);

            // Ball for Pong game (use floats for smooth movement)
            float ballX = 400f;
            float ballY = 225f;
            int ballRadius = 5;

            // Ball speed
            float ballSpeedX = 0.5f;
            float ballSpeedY = 0.5f;

            // Score 
            int scoreLeft = 0;
            int scoreRight = 0;

            // Game states
            string gameState = "init";

            // Main game loop
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);

                // Draw the pedals
                Raylib.DrawRectangleRec(leftPedal, Color.Black);
                Raylib.DrawRectangleRec(rightPedal, Color.Black);
                // Draw boundry line
                Raylib.DrawLine(400, 0, 400, 450, Color.LightGray);
                // Draw the ball (cast positions to int for drawing)
                Raylib.DrawCircle((int)ballX, (int)ballY, ballRadius, Color.Red);

                // Draw the score
                Raylib.DrawText($"{scoreLeft}", 380, 10, 20, Color.Black);
                Raylib.DrawText($"{scoreRight}", 410, 10, 20, Color.Black);

                // Check state
                if (gameState == "init")
                {
                    Raylib.DrawText("Press SPACE to Start", 300, 200, 20, Color.DarkGray);
                    if (Raylib.IsKeyPressed(KeyboardKey.Space))
                    {
                        gameState = "playing";
                    }
                }
                else if (gameState == "playing")
                {
                    // Move the ball
                    ballX += ballSpeedX;
                    ballY += ballSpeedY;

                    // Check collisions
                    Utils.CheckBallCollisions(ballX, ballY, ballRadius, leftPedal, rightPedal, ref ballSpeedX, ref ballSpeedY);

                    // Check for scoring
                    if (ballX < 0)
                    {
                        scoreRight++;
                        ballX = 400f;
                        ballY = 225f;
                        ballSpeedX = -ballSpeedX; // Change direction
                        gameState = "init"; // Reset to init state
                    }
                    else if (ballX > 800)
                    {
                        scoreLeft++;
                        ballX = 400f;
                        ballY = 225f;
                        ballSpeedX = -ballSpeedX; // Change direction
                        gameState = "init"; // Reset to init state
                    }
                }
                // Move the pedals with keyboard input
                Utils.MovePedal(ref leftPedal, "wsad", 10f);
                Utils.MovePedal(ref rightPedal, "arrows", 10f);

                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}