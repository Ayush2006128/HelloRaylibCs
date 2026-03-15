namespace HelloRaylibCs
{
    using Raylib_cs;
    public class Program
    {
        private static void CheckBallCollisions(float ballX, float ballY, int ballRadius, 
            Rectangle leftPedal, Rectangle rightPedal, ref float ballSpeedX, ref float ballSpeedY)
        {
            // Check for collision with top and bottom walls
            if (ballY <= 0 || ballY >= 450)
            {
                ballSpeedY = -ballSpeedY;
            }

            // Check for collision with left pedal
            if (ballX - ballRadius <= leftPedal.X + leftPedal.Width &&
                ballY >= leftPedal.Y && ballY <= leftPedal.Y + leftPedal.Height)
            {
                ballSpeedX = -ballSpeedX;
            }

            // Check for collision with right pedal
            if (ballX - ballRadius <= rightPedal.X + rightPedal.Width &&
                ballY >= rightPedal.Y && ballY <= rightPedal.Y + rightPedal.Height)
            {
                ballSpeedX = -ballSpeedX;
            }
        }

        private static void MovePedal(ref Rectangle pedal, string keyGroup, float changeValue)
        {
            KeyboardKey upKey = keyGroup == "arrows" ? KeyboardKey.Up : KeyboardKey.W;
            KeyboardKey downKey = keyGroup == "arrows" ? KeyboardKey.Down : KeyboardKey.S;

            if (Raylib.IsKeyPressed(upKey) && pedal.Y > 0)
            {
                pedal.Y -= changeValue;
            }
            else if (Raylib.IsKeyPressed(downKey) && pedal.Y < 360)
            {
                pedal.Y += changeValue;
            }
        }

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
            int scoreLeft = 0;
            int scoreRight = 0;

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

                // Move the ball
                ballX += ballSpeedX;
                ballY += ballSpeedY;

                // Check collisions
                CheckBallCollisions(ballX, ballY, ballRadius, leftPedal, rightPedal, ref ballSpeedX, ref ballSpeedY);

                // Move the pedals with keyboard input
                MovePedal(ref leftPedal, "wsad", 10f);
                MovePedal(ref rightPedal, "arrows", 10f);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}