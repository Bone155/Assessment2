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

        public Bullet()
        {
            bulletSprite.Load("bulletBlueSilver.png");
            bulletSprite.SetRotate(90 * (float)(Math.PI / 180.0f));
            AddChild(bulletSprite);
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

    }
}
