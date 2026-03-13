namespace HelloRaylibCs
{
    using Raylib_cs;
    public class Program
    {
        [System.STAThread]
        public static void Main()
        {
            Raylib.InitWindow(800, 450, "Hello Raylib-cs!");

            // Pedals for Pong game
            Rectangle leftPedal = new Rectangle(10, 225, 5, 20);
            Rectangle rightPedal = new Rectangle(785, 225, 5, 20);

            // Ball for Pong game
            int ballX = 400;
            int ballY = 225;
            int ballRadius = 5;

            // Ball speed
            int ballSpeed = 5;

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
                // Draw the ball
                Raylib.DrawCircle(ballX, ballY, ballRadius, Color.Red);

                // Draw the score
                Raylib.DrawText($"{score}", 385, 10, 20, Color.Black);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}