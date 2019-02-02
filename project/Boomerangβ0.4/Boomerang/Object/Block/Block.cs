using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boomerang
{
    class Block : Character
    {
        public Block(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy, "block", position, 24.0f, gameManager, mediator)
        {
        }
        public override void Update()
        {
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
            }
        }

    }
}
