using Raylib;
using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;

namespace ConsoleApp1
{
    class Tank : SpriteObject
    {
        public SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        Bullet bullet = new Bullet();
        public AABB2 tankB = new AABB2();
        Vector2 position = new Vector2();
        SceneObject Tlft = new SceneObject();
        SceneObject Trt = new SceneObject();
        SceneObject Brt = new SceneObject();
        SceneObject Blft = new SceneObject();
        SceneObject[] Corners = new SceneObject[4];

        int tankSpeed = 2;
        int turretSpeed = 2;
        int bulletSpeed = 6;
        int bulletTime = 0;
        bool isbullet = false;

        public Tank()
        {
            //Loading tank texture
            tankSprite.Load("tankBlue.png");

            // sprite is facing the wrong way... fix that here
            tankSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));

            // sets an offset for the base, so it rotates around the centre
            tankSprite.SetPosition(-tankSprite.Width / 2.0f, tankSprite.Height / 2.0f);

            //Loading turret texture
            turretSprite.Load("barrelBlue.png");

            // sprite is facing the wrong way... fix that here
            turretSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));

            // set the turret offset from the tank base
            turretSprite.SetPosition(0, turretSprite.Width / 2.0f);

            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);
            Corners[0] = Tlft;
            Corners[1] = Trt;
            Corners[2] = Brt;
            Corners[3] = Blft;
            tankObject.AddChild(Corners[0]);
            tankObject.AddChild(Corners[1]);
            tankObject.AddChild(Corners[2]);
            tankObject.AddChild(Corners[3]);

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }

        ~Tank()
        {

        }

        public void TankBox()
        {
            Vector2[] MyPoints = new Vector2[4];
            MyPoints[0] = new Vector2(Corners[0].GlobalTransform.m7 - (Width / 2), Corners[0].GlobalTransform.m8 - (Height / 2));
            MyPoints[1] = new Vector2(Corners[1].GlobalTransform.m7 + (Width / 2), Corners[1].GlobalTransform.m8 - (Height / 2));
            MyPoints[2] = new Vector2(Corners[2].GlobalTransform.m7 + (Width / 2), Corners[2].GlobalTransform.m8 + (Height / 2));
            MyPoints[3] = new Vector2(Corners[3].GlobalTransform.m7 - (Width / 2), Corners[3].GlobalTransform.m8 + (Height / 2));
            
            tankB.Fit(MyPoints);
            DrawLineEx(MyPoints[0], MyPoints[1], 2, Color.GREEN);
            DrawLineEx(MyPoints[1], MyPoints[2], 2, Color.GREEN);
            DrawLineEx(MyPoints[2], MyPoints[3], 2, Color.GREEN);
            DrawLineEx(MyPoints[3], MyPoints[0], 2, Color.GREEN);
        }

        public override void OnUpdate(float deltaTime)
        {
            
            if (IsKeyDown(KeyboardKey.KEY_A))
            {
                tankObject.Rotate(-deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_D))
            {
                tankObject.Rotate(deltaTime * tankSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_W))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m2, tankObject.LocalTransform.m3) * deltaTime * 100 * tankSpeed;

                tankObject.Translate(facing.x, facing.y);
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m2, tankObject.LocalTransform.m3) * deltaTime * -100 * tankSpeed;

                tankObject.Translate(facing.x, facing.y);
            }

            tankObject.Update(deltaTime);

            if (IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                turretObject.Rotate(-deltaTime * turretSpeed);
            }

            if (IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                turretObject.Rotate(deltaTime * turretSpeed);
            }

            bullet.Draw();
            float xR = turretObject.GlobalTransform.m1;
            float yR = turretObject.GlobalTransform.m2;
            float rot = MathF.Atan2(xR, yR);

            if (IsKeyPressed(KeyboardKey.KEY_SPACE))
            {                
                turretObject.AddChild(bullet);
                bullet.SetPosition(65, -5.5f);

                float bulletX = bullet.GlobalTransform.m7;
                float bulletY = bullet.GlobalTransform.m8;

                turretObject.RemoveChild(bullet);

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

            TankBox();
        }

    }
}
