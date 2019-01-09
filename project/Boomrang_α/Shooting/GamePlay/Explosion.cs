using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Explosion : Character
    {
        private int counter;
        private Sound sound;
        private Motion motion;

        public Explosion(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.Explosion, "Explosion64", position, 32.0f, gameManager, mediator)
        {
            counter = 7 * 5;//アニメーション終了時間の計算
            sound = gameManager.GetSound();

            motion = new Motion();
            motion.AddRectangle(0, new Rectangle(64 * 0, 0, 64, 64));
            motion.AddRectangle(1, new Rectangle(64 * 1, 0, 64, 64));
            motion.AddRectangle(2, new Rectangle(64 * 2, 0, 64, 64));
            motion.AddRectangle(3, new Rectangle(64 * 3, 0, 64, 64));
            motion.AddRectangle(4, new Rectangle(64 * 4, 0, 64, 64));
            motion.AddRectangle(5, new Rectangle(64 * 5, 0, 64, 64));
            motion.AddRectangle(6, new Rectangle(64 * 6, 0, 64, 64));
            motion.Initialize(0, 7, 5);//4フレームごとに

            sound.PlaySE("Explosion");
        }
        public override void Update()
        {
            counter--;
            if (counter <= 0)
            {
                isDead = true;
            }
            motion.Update();
        }
        public override void Hit(Character character)
        {
        }
        //Drawを追加する。
        public override void Draw()
        {
            renderer.DrawTexture(name, position - new Vector2(radius, radius), motion.CurrentRectangle());
        }
    }
}

