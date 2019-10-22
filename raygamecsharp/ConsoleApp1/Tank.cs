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
        public SceneObject turretObject = new SceneObject();
        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        int tankSpeed = 3;
        int turretSpeed = 5;

        public Tank(string tank, string turret)
        {
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

            // set up the scene object hierarchy - parent the turret to the base,
            // then the base to the tank sceneObject
            turretObject.AddChild(turretSprite);
            tankObject.AddChild(tankSprite);
            tankObject.AddChild(turretObject);

            // having an empty object for the tank parent means we can set the
            // position/rotation of the tank without
            // affecting the offset of the base sprite
            tankObject.SetPosition(GetScreenWidth() / 2.0f, GetScreenHeight() / 2.0f);
        }

        ~Tank()
        {

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
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m2, 1) * deltaTime * 100 * tankSpeed;

                tankObject.Translate(facing.x, facing.y);
            }

            if (IsKeyDown(KeyboardKey.KEY_S))
            {
                Vector3 facing = new Vector3(tankObject.LocalTransform.m1, tankObject.LocalTransform.m2, 1) * deltaTime * -100 * tankSpeed;

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
        }

    }
}
