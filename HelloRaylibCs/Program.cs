namespace HelloRaylibCs
{
    using Raylib_cs;
    public class Program
    {
        [System.STAThread]
        public static void Main()
        {
            Raylib.InitWindow(800, 450, "Pong!");

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
            int score = 0;

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
                Raylib.DrawText($"{score}", 385, 10, 20, Color.Black);

                // Move the ball
                ballX += ballSpeedX;
                ballY += ballSpeedY;

                // Check for collision with top and bottom walls
                if (ballY <= 0 || ballY >= 450)
                {
                    ballSpeedY = -ballSpeedY; // Reverse the ball's vertical direction
                }

                // Check for collision with left pedal
                if (ballX - ballRadius <= leftPedal.X + leftPedal.Width &&
                    ballY >= leftPedal.Y && ballY <= leftPedal.Y + leftPedal.Height)
                {
                    ballSpeedX = -ballSpeedX; // Reverse the ball's horizontal direction
                }

                if (ballX - ballRadius <= rightPedal.X + rightPedal.Width &&
    ballY >= rightPedal.Y && ballY <= rightPedal.Y + rightPedal.Height)
                {
                    ballSpeedX = -ballSpeedX; // Reverse the ball's horizontal direction
                }
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}