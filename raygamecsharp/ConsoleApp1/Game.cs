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
        Timer gameTime = new Timer();
        private float timer = 0;
        private int fps = 1;
        private int frames;

        private float deltaTime;

        Tank tank;
        Bullet bullet;

        public void Init()
        {
            tank = new Tank();
            bullet = new Bullet();
        }

        public void Shutdown()
        {

        }

        public void Update()
        {
            deltaTime = gameTime.GetDeltaTime();

            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            // insert game logic here
            tank.OnUpdate(deltaTime);

        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.WHITE);

            DrawText(fps.ToString(), 10, 10, 12, Color.RED);

            tank.tankObject.Draw();

            bullet.bulletObject.Draw();

            EndDrawing();
        }
    }
}
