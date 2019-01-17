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
        public Enemy4(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy4, "air_flow", position, 24.0f, gameManager, mediator)
        {
        }
        public override void Update()
        {
            //Vector2 speed;
            //if (mediator.IsCharacterDead(CharacterID.Player))
            //{
            //    speed = new Vector2(-1, 0);
            //}
            //else
            //{
            //    speed = mediator.GetCharacterPosition(CharacterID.Player) - position;
            //    speed.Normalize();
            //    speed.X = -1.0f;     //バックしない
            //}
            //speed.Normalize();
            //position = position + speed * 3.0f;
            //if (position.X < (0.0f - radius))
            //{
            //    isDead = true;
            //}
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;
            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide)//プレイヤーグループと当たる
            {
                //isDead = true;
                gameManager.SetScore(gameManager.GetScore() + 10);
                mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }
    }
}