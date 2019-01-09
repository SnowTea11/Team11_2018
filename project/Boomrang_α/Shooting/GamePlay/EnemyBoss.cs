using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyBoss : Character
    {
        public enum BossState
        {
            Appearance, Normal, Swoon, Anger, Crushing
        }

        private int hp;
        private int counter;
        private float moveY;
        private BossState bossState;
        private float alpha;
        private Random random;

        public EnemyBoss(GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.EnemyBoss, "Boss1", new Vector2(Screen.Width + 90.0f, Screen.Height / 2), 90.0f, gameManager, mediator)
        {
            hp = 200;
            moveY = -2;
            counter = 0;
            alpha = 1.0f;
            bossState = BossState.Appearance;
            random = gameManager.GetRandom();
        }
        public override void Update()
        {
            if (bossState == BossState.Appearance)
            {
                position.X -= 1.0f;
                if (counter >= 300)
                {
                    bossState = BossState.Normal;
                    counter = 0;
                }
            }
            else if (bossState == BossState.Normal)
            {
                if (counter < 360)
                {
                    position.Y = position.Y + moveY;
                    if (position.Y - radius <= 0 || position.Y + radius >= Screen.Height)
                    {
                        moveY *= -1;
                    }
                    if (counter % 60 == 0 && counter < 360)
                    {
                        BossShot();
                    }
                }
                else if (counter == 360)
                {
                    mediator.AddCharacter(new EnemyBossLaser(position + new Vector2(-100.0f, 30.0f), gameManager, mediator));
                }
                else if (counter >= 540)
                {
                    counter = 0;
                }
            }
            else if (bossState == BossState.Swoon)
            {
                if (counter >= 180)
                {
                    name = "Boss3";
                    counter = 0;
                    moveY *= 1.5f;
                    bossState = BossState.Anger;
                }
            }
            else if (bossState == BossState.Anger)
            {
                if (counter < 360)
                {
                    position.Y = position.Y + moveY;
                    if (position.Y - radius < 0 || position.Y + radius > Screen.Height)
                    {
                        moveY *= -1;
                    }
                    if (counter % 30 == 0 && counter < 360)
                    {
                        BossShot();
                    }
                }
                else if (counter == 360)
                {
                    mediator.AddCharacter(new EnemyBossLaser(position + new Vector2(-100.0f, 30.0f), gameManager, mediator));
                }
                else if (540 <= counter && counter < 780)
                {
                    if (counter % 10 == 0)
                    {
                        mediator.AddCharacter(new EnemyStorm(position + new Vector2(-100f, 30.0f), gameManager, mediator));
                    }
                }
                else if (counter >= 780)
                {
                    counter = 0;
                }
            }
            else if (bossState == BossState.Crushing)
            {
                alpha -= (1.0f / 180.0f);
                if (counter < 180 && counter % 3 == 0)
                {
                    mediator.AddCharacter(new Explosion(position + new Vector2(random.Next(-100, 100), random.Next(-100, 100)), gameManager, mediator));
                    position.Y += 1.0f;
                }
                else if (counter > 180)
                {
                    isDead = true;
                }
            }
            counter++;
        }
        private void BossShot()
        {
            mediator.AddCharacter(new EnemyBullet(position, new Vector2(-5.0f, -2.0f), gameManager, mediator));
            mediator.AddCharacter(new EnemyBullet(position, new Vector2(-5.0f, 0.0f), gameManager, mediator));
            mediator.AddCharacter(new EnemyBullet(position, new Vector2(-5.0f, 2.0f), gameManager, mediator));
        }
        public override void Hit(Character character)
        {
            if (isDead == true) return;
            if (character.ToString().Contains("Player") && bossState != BossState.Swoon && bossState != BossState.Crushing)    //プレイヤーグループと当たる             
            {
                hp--;
                if (hp == 100)
                {
                    bossState = BossState.Swoon;
                    name = "Boss2";
                    counter = 0;
                    return;
                }
                if (hp > 0) return;
                bossState = BossState.Crushing;
                counter = 0;
                gameManager.SetScore(gameManager.GetScore() + 10000);
            }
        } 
        public override void Draw()
        {
            renderer.DrawTexture(name, position, 
                new Rectangle(0, 0, (int)radius * 2, (int)radius * 2), 
                Color.White * alpha, 
                0.0f,                       //回転                 
                new Vector2(radius, radius),//表示中心                 
                new Vector2(1.0f, 1.0f)     //倍率             
                );
        } 
    }
}
