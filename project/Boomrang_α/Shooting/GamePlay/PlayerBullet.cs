using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class PlayerBullet : Character
    {
        private Vector2 velocity;
        private Random random;
        public PlayerBullet(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.PlayerBullet, "Bullet16", position, 8.0f, gameManager, mediator)
        {
            velocity = new Vector2(10.0f, 0.0f);
            random = gameManager.GetRandom();
        }
        public override void Update()
        {
            position = position + velocity;
            if (position.X > (Screen.Width + radius))
            {
                isDead = true;
            }
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;
            if (character.GetCharacterID() == CharacterID.EnemyBullet) return;   //敵の弾とは当たらない                        
            if (character.GetCharacterID() == CharacterID.EnemyStorm)//追加：竜巻に当たると乱反射 
            {
                velocity.X *= -1;
                velocity.Y = random.Next(-5, 5);
                return;
            }
            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide) //敵とのみ当たる
            {
                isDead = true;
            }
        }
    }
}
