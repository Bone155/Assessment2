using System;
using System.Collections.Generic;
using System.Text;
using static Raylib.Raylib;
using Raylib;

namespace ConsoleApp1
{
    class Bullet : SpriteObject
    {
        public SceneObject bulletObject = new SceneObject();
        SpriteObject bulletSprite = new SpriteObject();

        public Bullet()
        {
            bulletSprite.Load("bulletBlueSilver.png");
            bulletSprite.SetRotate(-90 * (float)(Math.PI / 180.0f));
            AddChild(bulletSprite);
            bulletSprite.IsBullet = true;

        }

        ~Bullet()
        {

        }

        public void bulletSpawn(SceneObject turret)
        {
            localTransform.Set(turret.GlobalTransform);
            Vector2 facing = new Vector2(bulletObject.LocalTransform.m1, bulletObject.LocalTransform.m2);
            bulletObject.Translate(facing.x, facing.y);
        }

    }
}
