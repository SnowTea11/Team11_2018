using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Enemy5 : Character
    {
        private int shotCounter;
        private Random random;
        public Enemy5(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Enemy, "Enemy64", position, 32.0f, gameManager, mediator)
        {
            random = gameManager.GetRandom();
            shotCounter = random.Next(0, 20) + random.Next(0, 20);
        }
        public override void Update()
        {
            shotCounter--;
            if (shotCounter < 0 && !mediator.IsCharacterDead(CharacterID.Player))
            {
                Vector2 direction = mediator.GetCharacterPosition(CharacterID.Player) - position ;
                direction.Normalize();
                Console.WriteLine(direction.X + ":" + direction.Y);
                mediator.AddCharacter(new EnemyBullet(position, direction * 4, gameManager, mediator));
                shotCounter = 80 + random.Next(0, 20) + random.Next(0, 20);
            }

            position = position + new Vector2(-3.0f, 0.0f);
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
