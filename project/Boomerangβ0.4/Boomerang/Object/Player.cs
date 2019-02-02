using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class Player : Character
    {
        private InputState input;
        private Sound sound;
        private bool Direction;
        public Player(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Player, "player", position, 24.0f, gameManager, mediator)
        {
            this.input = gameManager.GetInputState();
            this.sound = gameManager.GetSound();
            this.Direction = true;
        }
        public override void Update()
        {
            // キーボード時操作、上下対応
            if (input.IsKeyDown(Keys.Right)) position.X = position.X + 48;
            if (input.IsKeyDown(Keys.Left)) position.X = position.X - 48;
            if (input.IsKeyDown(Keys.Up)) position.Y = position.Y - 48;
            if (input.IsKeyDown(Keys.Down)) position.Y = position.Y + 48;

            // パッド時操作、左右のみ、右スティックで方向転換
            if (input.IsPadDown(Buttons.DPadRight)) position.X = position.X + 48;
            if (input.IsPadDown(Buttons.DPadLeft)) position.X = position.X - 48;
            if (input.IsPadDown(Buttons.RightThumbstickLeft)) Direction = true;
            if (input.IsPadDown(Buttons.RightThumbstickRight)) Direction = false;
            
            //position = position + input.KeyVelocity() * 8;

            if (position.X < radius) position.X = radius;
            if (position.X > Screen.Width - radius)
                position.X = Screen.Width - radius;
            if (position.Y < radius) position.Y = radius;
            if (position.Y > Screen.Height - radius)
                position.Y = Screen.Height - radius;

            if (input.IsKeyDown(Keys.Space))
            {
                Vector2 bulletPosition = position + new Vector2(0, -144);
                mediator.AddCharacter(new Boomerang_B(bulletPosition, gameManager, mediator));
                //mediator.AddCharacter(new PlayerBullet(bulletPosition, gameManager, mediator));
                //sound.PlaySE("shot");
            }
            if (input.IsKeyDown(Keys.V))
            {
                Vector2 bulletPosition = position + new Vector2(-4, -148);
                mediator.AddCharacter(new Boomerang_A(bulletPosition, gameManager, mediator));
                //mediator.AddCharacter(new PlayerBullet(bulletPosition, gameManager, mediator));
                //sound.PlaySE("shot");
            }

            if (input.IsPadDown(Buttons.B))
            {
                if (Direction)
                {
                    Vector2 bulletPosition = position + new Vector2(-4, -148);
                    mediator.AddCharacter(new Boomerang_A(bulletPosition, gameManager, mediator));
                }
                else
                {
                    Vector2 bulletPosition = position + new Vector2(0, -144);
                    mediator.AddCharacter(new Boomerang_B(bulletPosition, gameManager, mediator));
                }
            }
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;

            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide)	//敵グループと当たる
            {
                //isDead = true;
                //mediator.AddCharacter(new Explosion(position, gameManager, mediator));
            }
        }
        public override void Draw()
        {
            if (Direction) renderer.DrawTexture("player", position - new Vector2(radius, radius));
            if (!Direction) renderer.DrawTexture("player_right", position - new Vector2(radius, radius));
        }
    }
}