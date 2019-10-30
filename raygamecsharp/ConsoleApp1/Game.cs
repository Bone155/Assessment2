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

        int GameOverTime = 0;
        bool winState1;
        bool winState2;
        Tank blueTank;
        Tank redTank;

        public void Init()
        {
            blueTank = new Tank("tankBlue.png", "barrelBlue.png", "bulletBlueSilver.png");
            redTank = new Tank("tankRed.png", "barrelRed.png", "bulletRedSilver.png");
            blueTank.SetPosition(50, 120);
            redTank.SetPosition(GetScreenWidth() - 50, GetScreenHeight() - 80);
            redTank.Rotate((float)Math.PI);
            winState1 = blueTank.winState;
            winState2 = redTank.winState;
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
            blueTank.OnUpdate(deltaTime);
            redTank.OnUpdate(deltaTime);
            blueTank.P1(deltaTime);
            redTank.P2(deltaTime);

            if (blueTank.BulletAABB.Overlaps(redTank.tankB))
            {
                DrawLine((int)redTank.tankB.min.x, (int)redTank.tankB.min.y, (int)redTank.tankB.max.x, (int)redTank.tankB.min.y, Color.BLACK);
                DrawLine((int)redTank.tankB.max.x, (int)redTank.tankB.min.y, (int)redTank.tankB.max.x, (int)redTank.tankB.max.y, Color.BLACK);
                DrawLine((int)redTank.tankB.max.x, (int)redTank.tankB.max.y, (int)redTank.tankB.min.x, (int)redTank.tankB.max.y, Color.BLACK);
                DrawLine((int)redTank.tankB.min.x, (int)redTank.tankB.max.y, (int)redTank.tankB.min.x, (int)redTank.tankB.min.y, Color.BLACK);
                redTank.health--;
            }

            if (redTank.BulletAABB.Overlaps(blueTank.tankB))
            {
                DrawLine((int)blueTank.tankB.min.x, (int)blueTank.tankB.min.y, (int)blueTank.tankB.max.x, (int)blueTank.tankB.min.y, Color.BLACK);
                DrawLine((int)blueTank.tankB.max.x, (int)blueTank.tankB.min.y, (int)blueTank.tankB.max.x, (int)blueTank.tankB.max.y, Color.BLACK);
                DrawLine((int)blueTank.tankB.max.x, (int)blueTank.tankB.max.y, (int)blueTank.tankB.min.x, (int)blueTank.tankB.max.y, Color.BLACK);
                DrawLine((int)blueTank.tankB.min.x, (int)blueTank.tankB.max.y, (int)blueTank.tankB.min.x, (int)blueTank.tankB.min.y, Color.BLACK);
                blueTank.health--;
            }

            if (blueTank.health <= 0)
            {
                blueTank.health = 0;
                GameOverTime++;
                if ((GameOverTime * deltaTime) >= 1)
                {
                    winState2 = true;
                    DrawText("Red Tank Wins!", 10, 90, 200, Color.RED);
                }
            }

            if (redTank.health <= 0)
            {
                redTank.health = 0;
                GameOverTime++;
                if ((GameOverTime * deltaTime) >= 1)
                {
                    winState1 = true;
                    DrawText("Blue Tank Wins!", 10, 90, 200, Color.SKYBLUE);
                }
            }

            if (winState1 || winState2)
            {
                blueTank.tankSpeed = 0 * (int)deltaTime;
                blueTank.turretSpeed = 0 * (int)deltaTime;
                blueTank.isbullet = false;

                redTank.tankSpeed = 0 * (int)deltaTime;
                redTank.turretSpeed = 0 * (int)deltaTime;
                redTank.isbullet = false;
            }

            if (blueTank.GlobalTransform.m7 <= 0)
                blueTank.GlobalTransform.m7 = GetScreenWidth() - 1;

            if (blueTank.GlobalTransform.m7 >= GetScreenWidth())
                blueTank.GlobalTransform.m7 = 0;

            if (blueTank.GlobalTransform.m8 <= 0)
                blueTank.GlobalTransform.m8 = GetScreenHeight() - 1;

            if (blueTank.GlobalTransform.m8 >= GetScreenHeight())
                blueTank.GlobalTransform.m8 = 0;

            if (redTank.GlobalTransform.m7 <= 0)
                redTank.GlobalTransform.m7 = GetScreenWidth() - 1;

            if (redTank.GlobalTransform.m7 >= GetScreenWidth())
                redTank.GlobalTransform.m7 = 0;

            if (redTank.GlobalTransform.m8 <= 0)
                redTank.GlobalTransform.m8 = GetScreenHeight() - 1;

            if (redTank.GlobalTransform.m8 >= GetScreenHeight())
                redTank.GlobalTransform.m8 = 0;

            if ((blueTank.reloadTime * deltaTime) >= 0 && (blueTank.reloadTime * deltaTime) < 5)
                DrawText("Reloading", 10, 30, 24, Color.SKYBLUE);

            if ((redTank.reloadTime * deltaTime) >= 0 && (redTank.reloadTime * deltaTime) < 5)
                DrawText("Reloading", GetScreenWidth() - 120, 30, 24, Color.RED);
        }

        public void Draw()
        {
            BeginDrawing();

            ClearBackground(Color.BLACK);

            DrawText("Blue Tank: " + blueTank.health, 10, 10, 12, Color.SKYBLUE);
            DrawText("Red Tank: " + redTank.health, GetScreenWidth() - 90, 10, 12, Color.RED);

            blueTank.Draw();
            redTank.Draw();

            EndDrawing();
        }
    }
}
