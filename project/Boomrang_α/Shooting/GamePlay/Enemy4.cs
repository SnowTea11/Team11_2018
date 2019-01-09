using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Enemy4 : Character
    {
        private Vector2 basePosition;   //回転の中心座
        private float angle;            //回転角

        public Enemy4(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy, "Enemy64", position, 32.0f, gameManager, mediator)
        {
            basePosition = position;
            angle = 0.0f;
        }
        public override void Update()
        {
            basePosition = basePosition + new Vector2(-2.0f, 0.0f);
            double radian = angle / 180 * Math.PI;  //角度をラジアンに
            position.X = basePosition.X + (float)Math.Cos(radian) * 64.0f;
            position.Y = basePosition.Y + (float)Math.Sin(radian) * 64.0f;
            angle = angle + 4.0f;

            if (position.X < (0.0f - radius))
            {
                isDead = true;
            }
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;
            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide)//プレイヤーグループと当たる
            {
                isDead = true;
                gameManager.SetScore(gameManager.GetScore() + 10);
                mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }
    }
}
