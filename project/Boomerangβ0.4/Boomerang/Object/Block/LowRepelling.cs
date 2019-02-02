using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boomerang
{
    // 低反発ブロッククラス　半径-1
    class LowRepelling : Character
    {
        public LowRepelling(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
           : base(CharacterID.Enemy3, "form", position, 24.0f, gameManager, mediator)
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
