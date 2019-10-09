using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Raylib;
using static Raylib.Raylib;

namespace ConsoleApp1
{
    class Game
    {
        Stopwatch stopwatch = new Stopwatch();

        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime = 0.005f;

        Tank tank = new Tank();

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            tank();
        }

        public void Shutdown()
        {

        }

        public void Update()
        {
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;

            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            lastTime = currentTime;

            // insert game logic here            
            tank.OnUpdate(deltaTime);
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            tank.Draw();

            EndDrawing();
        }
    }
}
