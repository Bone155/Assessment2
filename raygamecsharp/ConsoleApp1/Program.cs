using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            Game game = new Game();


            int screenWidth = 800;
            int screenHeight = 450;

            rl.InitWindow(screenWidth, screenHeight, "Tanks");

            game.Init();

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------

                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------

                game.Draw();

                game.Update();

                //----------------------------------------------------------------------------------
            }

            game.Shutdown();
            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
