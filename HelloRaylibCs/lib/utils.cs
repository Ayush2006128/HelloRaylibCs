using Raylib_cs;

namespace HelloRaylibCs.lib
{
    internal class Utils
    {
        public static void CheckBallCollisions(float ballX, float ballY, int ballRadius,
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

        public static void MovePedal(ref Rectangle pedal, string keyGroup, float changeValue)
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

    }
}
