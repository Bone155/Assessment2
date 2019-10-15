using Raylib;
using static Raylib.Raylib;

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

            InitWindow(screenWidth, screenHeight, "Tanks");

            game.Init();

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
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
            CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
