using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;
using Raylib;

namespace ConsoleApp1
{
    class Bullet : SpriteObject
    {
        SpriteObject bulletSprite = new SpriteObject();

        public AABB2 bulletB = new AABB2();

        SceneObject[] Corners = new SceneObject[4];

        public Bullet(string bullet)
        {
            bulletSprite.Load(bullet);
            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            AddChild(bulletSprite);
            Corners[0] = new SceneObject();
            Corners[0].SetPosition(-26, 1);

            Corners[1] = new SceneObject();
            Corners[1].SetPosition(0, 1);

            Corners[2] = new SceneObject();
            Corners[2].SetPosition(0, 12);

            Corners[3] = new SceneObject();
            Corners[3].SetPosition(-26, 12);

            AddChild(Corners[0]);
            AddChild(Corners[1]);
            AddChild(Corners[2]);
            AddChild(Corners[3]);
        }

        ~Bullet()
        {

        }

        public void bulletSpawn(SceneObject turret, float deltaTime)
        {
            localTransform.Set(turret.GlobalTransform);
            Vector2 facing = new Vector2(LocalTransform.m1, LocalTransform.m2) * deltaTime;
            Translate(facing.x, facing.y);
        }

        public void BulletBox()
        {
            Vector2[] MyPoints = new Vector2[4];
            MyPoints[0] = new Vector2(Corners[0].GlobalTransform.m7, Corners[0].GlobalTransform.m8);
            MyPoints[1] = new Vector2(Corners[1].GlobalTransform.m7, Corners[1].GlobalTransform.m8);
            MyPoints[2] = new Vector2(Corners[2].GlobalTransform.m7, Corners[2].GlobalTransform.m8);
            MyPoints[3] = new Vector2(Corners[3].GlobalTransform.m7, Corners[3].GlobalTransform.m8);

            bulletB.Center();
            bulletB.Extents();
            bulletB.Corners();
            bulletB.Fit(MyPoints);

            DrawLine((int)bulletB.min.x, (int)bulletB.min.y, (int)bulletB.max.x, (int)bulletB.min.y, Color.BLACK);
            DrawLine((int)bulletB.max.x, (int)bulletB.min.y, (int)bulletB.max.x, (int)bulletB.max.y, Color.BLACK);
            DrawLine((int)bulletB.max.x, (int)bulletB.max.y, (int)bulletB.min.x, (int)bulletB.max.y, Color.BLACK);
            DrawLine((int)bulletB.min.x, (int)bulletB.max.y, (int)bulletB.min.x, (int)bulletB.min.y, Color.BLACK);
        }

    }
}
