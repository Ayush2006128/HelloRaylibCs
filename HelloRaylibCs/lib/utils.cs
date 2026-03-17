using Raylib_cs;

namespace HelloRaylibCs.lib
{
    internal class Utils
    {
        public static void CheckBallCollisions(float ballX, float ballY, int ballRadius,
    Rectangle leftpaddle, Rectangle rightpaddle, ref float ballSpeedX, ref float ballSpeedY)
        {
            // Check for collision with top and bottom walls
            if (ballY <= 0 || ballY >= 450)
            {
                ballSpeedY = -ballSpeedY;
            }

            // Check for collision with left paddle
            if (ballX - ballRadius <= leftpaddle.X + leftpaddle.Width &&
                ballY >= leftpaddle.Y && ballY <= leftpaddle.Y + leftpaddle.Height)
            {
                ballSpeedX = -ballSpeedX;
            }

            // Check for collision with right paddle
            if (ballX - ballRadius <= rightpaddle.X + rightpaddle.Width &&
                ballY >= rightpaddle.Y && ballY <= rightpaddle.Y + rightpaddle.Height)
            {
                ballSpeedX = -ballSpeedX;
            }
        }

        public static void Movepaddle(ref Rectangle paddle, string keyGroup, float changeValue)
        {
            KeyboardKey upKey = keyGroup == "arrows" ? KeyboardKey.Up : KeyboardKey.W;
            KeyboardKey downKey = keyGroup == "arrows" ? KeyboardKey.Down : KeyboardKey.S;

            if (Raylib.IsKeyDown(upKey) && paddle.Y > 0)
            {
                paddle.Y -= changeValue;
            }
            else if (Raylib.IsKeyDown(downKey) && paddle.Y < 360)
            {
                paddle.Y += changeValue;
            }
        }

    }
}
