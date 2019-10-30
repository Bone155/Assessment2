using Raylib;
using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;

namespace ConsoleApp1
{
    class Tank : SpriteObject
    {
        SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        Bullet bullet;
        public AABB2 tankB = new AABB2();
        SceneObject[] Corners = new SceneObject[4];
        public AABB2 BulletAABB;

        public int tankSpeed = 2;
        public int turretSpeed = 2;
        public int bulletSpeed = 6;
        public int reloadTime = 0;
        public bool isbullet = false;
        public int health = 50;
        public bool winState = false;

        public Tank(string tank, string turret, string bulletF)
        {
            bullet = new Bullet(bulletF);
            BulletAABB = bullet.bulletB;
            //Loading tank texture
            tankSprite.Load(tank);

            // sprite is facing the wrong way... fix that here
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));

            // sets an offset for the base, so it rotates around the centre
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            //Loading turret texture
            turretSprite.Load(turret);

            // sprite is facing the wrong way... fix that here
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));

            // set the turret offset from the tank base
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);
            Corners[0] = new SceneObject();
            Corners[0].SetPosition(-38, -40);

            Corners[1] = new SceneObject();
            Corners[1].SetPosition(32, -40);

            Corners[2] = new SceneObject();
            Corners[2].SetPosition(32, 35);

            Corners[3] = new SceneObject();
            Corners[3].SetPosition(-38, 35);

            AddChild(Corners[0]);
            AddChild(Corners[1]);
            AddChild(Corners[2]);
            AddChild(Corners[3]);


            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            AddChild(tankSprite);
            AddChild(turretObject);

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite
            SetPosition(GetScreenWidth() / 2, GetScreenHeight() / 2);
        }

        ~Tank()
        {

        }

        public void TankBox()
        {
            Vector2[] MyPoints = new Vector2[4];
            MyPoints[0] = new Vector2(Corners[0].GlobalTransform.m7, Corners[0].GlobalTransform.m8);
            MyPoints[1] = new Vector2(Corners[1].GlobalTransform.m7, Corners[1].GlobalTransform.m8);
            MyPoints[2] = new Vector2(Corners[2].GlobalTransform.m7, Corners[2].GlobalTransform.m8);
            MyPoints[3] = new Vector2(Corners[3].GlobalTransform.m7, Corners[3].GlobalTransform.m8);
            
            tankB.Center();
            tankB.Extents();
            tankB.Corners();
            tankB.Fit(MyPoints);

            DrawLine((int)tankB.min.x, (int)tankB.min.y, (int)tankB.max.x, (int)tankB.min.y, Color.BLACK);
            DrawLine((int)tankB.max.x, (int)tankB.min.y, (int)tankB.max.x, (int)tankB.max.y, Color.BLACK);
            DrawLine((int)tankB.max.x, (int)tankB.max.y, (int)tankB.min.x, (int)tankB.max.y, Color.BLACK);
            DrawLine((int)tankB.min.x, (int)tankB.max.y, (int)tankB.min.x, (int)tankB.min.y, Color.BLACK);
        }

        public void P1(float deltaTime)
        {
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                Rotate(-deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                Rotate(deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector2 facing = new Vector2(LocalTransform.m1, LocalTransform.m2) * deltaTime * 100 * tankSpeed;

                Translate(facing.x, facing.y);
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector2 facing = new Vector2(LocalTransform.m1, LocalTransform.m2) * deltaTime * -100 * tankSpeed;

                Translate(facing.x, facing.y);
            }

            Update(deltaTime);

            if (IsKeyDown(KeyboardKey.KEY_Q))
            {
                turretObject.Rotate(-deltaTime * turretSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_E))
            {
                turretObject.Rotate(deltaTime * turretSpeed);
            }

            bullet.Draw();
            float xR = turretObject.GlobalTransform.m1;
            float yR = turretObject.GlobalTransform.m2;
            float rot = MathF.Atan2(xR, yR);

            if (IsKeyPressed(KeyboardKey.KEY_SPACE) && (reloadTime * deltaTime) >= 5)
            {
                turretObject.AddChild(bullet);
                bullet.SetPosition(65, -5.5f);

                float bulletX = bullet.GlobalTransform.m7;
                float bulletY = bullet.GlobalTransform.m8;

                turretObject.RemoveChild(bullet);
                reloadTime = 0;
                bullet.SetRotate(rot);
                bullet.bulletSpawn(turretObject, deltaTime);
                bullet.SetPosition(bulletX, bulletY);

                isbullet = true;
            }

            if (isbullet)
            {
                Vector2 facing = new Vector2(bullet.LocalTransform.m1, bullet.LocalTransform.m2) * deltaTime * 100 * bulletSpeed;
                bullet.Translate(facing.x, facing.y);
            }
        }

        public void P2(float deltaTime)
        {
            if (IsKeyDown(KeyboardKey.KEY_KP_4))
            {
                Rotate(-deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_6))
            {
                Rotate(deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_8))
            {
                Vector2 facing = new Vector2(LocalTransform.m1, LocalTransform.m2) * deltaTime * 100 * tankSpeed;

                Translate(facing.x, facing.y);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_5))
            {
                Vector2 facing = new Vector2(LocalTransform.m1, LocalTransform.m2) * deltaTime * -100 * tankSpeed;

                Translate(facing.x, facing.y);
            }

            Update(deltaTime);

            if (IsKeyDown(KeyboardKey.KEY_KP_7))
            {
                turretObject.Rotate(-deltaTime * turretSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_KP_9))
            {
                turretObject.Rotate(deltaTime * turretSpeed);
            }

            bullet.Draw();
            float xR = turretObject.GlobalTransform.m1;
            float yR = turretObject.GlobalTransform.m2;
            float rot = MathF.Atan2(xR, yR);

            if (IsKeyPressed(KeyboardKey.KEY_KP_ENTER) && (reloadTime * deltaTime) >= 5)
            {
                turretObject.AddChild(bullet);
                bullet.SetPosition(65, -5.5f);

                float bulletX = bullet.GlobalTransform.m7;
                float bulletY = bullet.GlobalTransform.m8;

                turretObject.RemoveChild(bullet);
                reloadTime = 0;
                bullet.SetRotate(rot);
                bullet.bulletSpawn(turretObject, deltaTime);
                bullet.SetPosition(bulletX, bulletY);

                isbullet = true;
            }

            if (isbullet)
            {
                Vector2 facing = new Vector2(bullet.LocalTransform.m1, bullet.LocalTransform.m2) * deltaTime * 100 * bulletSpeed;
                bullet.Translate(facing.x, facing.y);
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            reloadTime++;
            TankBox();
            bullet.BulletBox();
        }

    }
}
