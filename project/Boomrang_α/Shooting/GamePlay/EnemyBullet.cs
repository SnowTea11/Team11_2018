using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyBullet : Character
    {
        private Vector2 direction;

        public EnemyBullet(Vector2 position, Vector2 direction, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.EnemyBullet, "EnemyBullet16", position, 8.0f, gameManager, mediator)
        {
            this.direction = direction;
        }
        public override void Update()
        {
            position = position + direction;
            //画面外に出たら削除
            if (position.X < (0 - radius) || (Screen.Width + radius) < position.X ||
                position.Y < (0 - radius) || (Screen.Height + radius) < position.Y)
            {
                isDead = true;
            }
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;
            if (character.GetCharacterID() == CharacterID.PlayerBullet) return; //弾とは当たらない
            if ((int)character.GetCharacterID() /(int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide) //プレイヤーグループと当たる
            {
                isDead = true;
            }
        }
    }

}
