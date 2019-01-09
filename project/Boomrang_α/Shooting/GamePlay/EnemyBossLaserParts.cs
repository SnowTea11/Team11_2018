using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyBossLaserParts : Character
    {
        public EnemyBossLaserParts(Vector2 position, string name, GameManager gameManager, ICharacterMediator mediator) 
            : base(CharacterID.EnemyBullet, name, position, 32.0f, gameManager, mediator)
        { }
        public override void Update()
        {
            position.X = position.X - 8.0f;
            if (position.X < (0 - radius))
            {
                isDead = true;
            }
        }
        public override void Hit(Character character)
        {
        }
    }
}
