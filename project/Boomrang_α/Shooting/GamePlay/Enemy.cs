using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    // 通常のブロッククラス
    class Enemy : Character
    {
        public Enemy(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy, "block", position, 24.0f, gameManager, mediator)
        {
        }
        public override void Update()
        {
            //position = position + new Vector2(-4.0f, 0.0f);
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
                //isDead = true;
                gameManager.SetScore(gameManager.GetScore() + 10);
                mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }

        
    }
}

