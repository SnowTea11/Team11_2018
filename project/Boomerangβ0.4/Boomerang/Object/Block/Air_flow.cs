using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boomerang
{
    class Air_flow : Character
    {
        public Air_flow(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
           : base(CharacterID.Enemy4, "air_flow", position, 24.0f, gameManager, mediator)
        {
        }
        public override void Update()
        {
            
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
