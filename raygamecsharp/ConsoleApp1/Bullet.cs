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
            bulletObject.AddChild(bulletSprite);
        }

        ~Bullet()
        {

        }

        public void bulletSpawn(SceneObject turret)
        {
            localTransform.Set(turret.GlobalTransform);
            Vector3 facing = new Vector3(bulletObject.LocalTransform.m1, bulletObject.LocalTransform.m2, 1);
            bulletObject.Translate(facing.x, facing.y);
        }

    }
}
