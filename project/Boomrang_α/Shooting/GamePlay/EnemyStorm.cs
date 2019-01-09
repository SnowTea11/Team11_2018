using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyStorm : Character
    {
        private Vector2 basePosition;
        private double radian;
        private float rotateHeight;

        public EnemyStorm(Vector2 position, GameManager gameManager, ICharacterMediator mediator) 
            : base(CharacterID.EnemyStorm, "ministorm", position, 32.0f, gameManager, mediator)
        {
            basePosition = position;
            rotateHeight = 1.0f; radian = 0.0f;
        }

        public override void Update()
        {
            basePosition = basePosition + new Vector2(-2.0f, 0.0f);
            position.X = basePosition.X + (float)Math.Cos(radian) * rotateHeight;
            position.Y = basePosition.Y + (float)Math.Sin(radian) * rotateHeight;
            radian = radian + (Math.PI / 180) * 10;
            rotateHeight += 1.0f;
            if (position.X < (0.0f - radius))
            {
                isDead = true;
            }
        }

        public override void Hit(Character character)
        { }

        public override void Draw()
        {
            renderer.DrawTexture(name,      //アセット名                 
                position,                   //位置                 
                new Rectangle(0, 0, (int)radius * 2, (int)radius * 2),
                Color.White * 0.5f,         //色*透明度                 
                0.0f,                       //回転                 
                new Vector2(radius, radius),//表示中心                 
                new Vector2(1.0f, 1.0f)     //倍率
                );              
        }
    }
}
