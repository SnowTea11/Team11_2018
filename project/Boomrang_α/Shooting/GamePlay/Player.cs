using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shooting
{
    class Player : Character
    {
        private InputState input;
        private Sound sound;
        public Player(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Player, "player", position, 24.0f, gameManager, mediator)
        {
            this.input = gameManager.GetInputState();
            this.sound = gameManager.GetSound();
        }
        public override void Update()
        {
            if (input.IsKeyDown(Keys.Right)) position.X = position.X + 48;
            if (input.IsKeyDown(Keys.Left)) position.X = position.X - 48;
            if (input.IsKeyDown(Keys.Up)) position.Y = position.Y - 48;
            if (input.IsKeyDown(Keys.Down)) position.Y = position.Y + 48;
            //position = position + input.KeyVelocity() * 8;

            if (position.X < radius) position.X = radius;
            if (position.X > Screen.Width - radius)
                position.X = Screen.Width - radius;
            if (position.Y < radius) position.Y = radius;
            if (position.Y > Screen.Height - radius)
                position.Y = Screen.Height - radius;

            if (input.IsKeyDown(Keys.Space))
            {
                Vector2 bulletPosition = position + new Vector2(0, -96);
                mediator.AddCharacter(new Abbb(bulletPosition, gameManager, mediator));
                //mediator.AddCharacter(new PlayerBullet(bulletPosition, gameManager, mediator));
                sound.PlaySE("shot");
            }
            if (input.IsKeyDown(Keys.V))
            {
                Vector2 bulletPosition = position + new Vector2(-radius, -96);
                mediator.AddCharacter(new Aaaa(bulletPosition, gameManager, mediator));
                //mediator.AddCharacter(new PlayerBullet(bulletPosition, gameManager, mediator));
                sound.PlaySE("shot");
            }
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;                     
            if (character.GetCharacterID() == CharacterID.EnemyStorm)//追加：Storm に当たると敵側に吸い寄せられる処理    
            {
                position.X += 2;
                return;
            }
            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide)	//敵グループと当たる
            {
                //isDead = true;
                mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }
    }
}
