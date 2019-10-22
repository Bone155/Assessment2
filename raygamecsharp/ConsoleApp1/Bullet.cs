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
        Tank tank;

        int bulletSpeed = 50;

        public Bullet(string bullet)
        {
            bulletSprite.Load(bullet);
        }

        public void Face(SceneObject turret)
        {
            localTransform.Set(turret.GlobalTransform);
            Vector3 facing = new Vector3(tank.tankObject.LocalTransform.m1, tank.tankObject.LocalTransform.m2, 1) * bulletSpeed;
            Translate(facing.x, facing.y);
        }

        ~Bullet()
        {

        }

        public override void OnUpdate(float deltaTime)
        {
            if (IsKeyDown(KeyboardKey.KEY_SPACE))
            {
                
            }
        }

    }
}
