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
        Tank tank2;

        public void Init()
        {
            tank = new Tank("tankBlue.png", "barrelBlue.png", "bulletBlueSilver.png");
            tank2 = new Tank("tankRed.png", "barrelRed.png", "bulletRedSilver.png");
            tank.SetPosition(50, 90);
            tank2.SetPosition(GetScreenWidth() - 50, GetScreenHeight() - 80);
            tank2.Rotate((float)Math.PI);
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
            tank2.OnUpdate(deltaTime);
            tank.P1(deltaTime);
            tank2.P2(deltaTime);
            if (tank.BulletAABB.Overlaps(tank2.tankB))
            {
                DrawLine((int)tank2.tankB.min.x, (int)tank2.tankB.min.y, (int)tank2.tankB.max.x, (int)tank2.tankB.min.y, Color.RED);
                DrawLine((int)tank2.tankB.max.x, (int)tank2.tankB.min.y, (int)tank2.tankB.max.x, (int)tank2.tankB.max.y, Color.RED);
                DrawLine((int)tank2.tankB.max.x, (int)tank2.tankB.max.y, (int)tank2.tankB.min.x, (int)tank2.tankB.max.y, Color.RED);
                DrawLine((int)tank2.tankB.min.x, (int)tank2.tankB.max.y, (int)tank2.tankB.min.x, (int)tank2.tankB.min.y, Color.RED);
                tank2.health--;
            }
            if (tank2.BulletAABB.Overlaps(tank.tankB))
            {
                DrawLine((int)tank.tankB.min.x, (int)tank.tankB.min.y, (int)tank.tankB.max.x, (int)tank.tankB.min.y, Color.RED);
                DrawLine((int)tank.tankB.max.x, (int)tank.tankB.min.y, (int)tank.tankB.max.x, (int)tank.tankB.max.y, Color.RED);
                DrawLine((int)tank.tankB.max.x, (int)tank.tankB.max.y, (int)tank.tankB.min.x, (int)tank.tankB.max.y, Color.RED);
                DrawLine((int)tank.tankB.min.x, (int)tank.tankB.max.y, (int)tank.tankB.min.x, (int)tank.tankB.min.y, Color.RED);
                tank.health--;
            }
            if (tank.health <= 0)
            {
                DrawText("Red Tank Wins!", 10, 90, 200, Color.RED);
            }

            if (tank2.health <= 0)
            {
                DrawText("Blue Tank Wins!", 10, 90, 200, Color.SKYBLUE);
            }
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.BLACK);

            DrawText("Blue Tank: " + tank.health, 10, 10, 12, Color.RED);
            DrawText("Red Tank: " + tank2.health, GetScreenWidth() - 90, 10, 12, Color.RED);

            tank.Draw();
            tank2.Draw();

            EndDrawing();
        }
    }
}
