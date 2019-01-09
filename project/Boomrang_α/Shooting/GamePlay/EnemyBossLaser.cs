using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyBossLaser : Character
    {
        private int counter;

        public EnemyBossLaser(Vector2 position, GameManager gameManager, ICharacterMediator mediator) 
            : base(CharacterID.EnemyBullet,"BossBullet64", position, 32.0f, gameManager, mediator)
        {
            counter = 120;
        }

        public override void Update()
        {
            if (counter == 120)
            {
                mediator.AddCharacter(new EnemyBossLaserParts(
                    position + new Vector2(-16.0f, 0.0f), "BossBullet64", gameManager, mediator));
            }
            else if (counter > 0 && counter % 4 == 0)
            {
                mediator.AddCharacter(new EnemyBossLaserParts(
                    position + new Vector2(-16.0f, 0.0f), "BossBulletB64", gameManager, mediator));
            }
            else if (counter <= 0)
            {
                position.X = position.X - 8.0f;
            }
            if (position.X < (0 - radius))
            {
                isDead = true;
            }
            counter--;
        }

        public override void Hit(Character character)
        {
        }
    }
}
