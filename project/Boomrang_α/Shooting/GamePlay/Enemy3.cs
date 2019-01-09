using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Enemy3 : Character
    {
        private int hp;
        public Enemy3(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy, "Enemy64", position, 32.0f, gameManager, mediator)
        {
            hp = 4;
        }
        public override void Update()
        {
            position = position + new Vector2(-4.0f, 0.0f);
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
                hp--;
                if (hp > 0) return;
                isDead = true;
                gameManager.SetScore(gameManager.GetScore() + 10);
                mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }
    }
}
