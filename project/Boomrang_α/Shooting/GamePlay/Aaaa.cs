using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Aaaa : Character
    {
        //\pajero

        //\pajero
        //\pajero
        //\pajero
        //\pajero
        //\pajero
        //\pajero

        private Vector2 origin;
        private Vector2 centerPosition;
        private Vector2 nextPosition;

        private float rotateHeight;
        private double radian;
        private bool hide;
        private float kaiten = 0;

        //１フレーム前のサイン、コサイン
        private float bCos;
        private float bSin;

        //サイン、コサイン
        private float cos;
        private float sin;
        // 気流用のsin反転用フラグ
        private bool NotSin = false;
        //private bool couse = false;
        //private float count = 1;




        public Aaaa(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.PlayerBullet, "boomerang", position, 24.0f, gameManager, mediator)
        {
            origin = position + new Vector2(122, 96);
            rotateHeight = 96.0f;
            radian = 0.0f;
            hide = false;
        }
        public override void Update()
        {

            //円移動
            //弾のＸ座標 = 回転軸のＸ座標 + cos(回転軸からの角度) * 回転軸からの距離
            //弾のＹ座標 = 回転軸のＹ座標 + sin(回転軸からの角度) * 回転軸からの距離
            cos = (float)Math.Cos(radian);
            sin = (float)Math.Sin(radian);

            radian += ((float)Math.PI / 180);//回転軸からの距離を右分増加


            position.X = origin.X + -cos * rotateHeight;
            if (NotSin)
            {
                position.Y = origin.Y + sin * rotateHeight;
            }
            else
            {
                position.Y = origin.Y + -sin * rotateHeight;
            }


            kaiten += 0.5f;

            nextPosition = position;

            hide = true;
        }
        public override void Hit(Character character)
        {
            if (character.GetCharacterID() == CharacterID.Enemy2)
            {
                rotateHeight += 32;
            }
            if (character.GetCharacterID() == CharacterID.Enemy3)
            {
                rotateHeight -= 16;
            }
            if (character.GetCharacterID() == CharacterID.Enemy4)
            {
                NotSin = true;
            }

            if (character.GetCharacterID() == CharacterID.Enemy ||
                character.GetCharacterID() == CharacterID.Enemy2 ||
                character.GetCharacterID() == CharacterID.Enemy3)
            {



                //距離を測る
                float distanse = (float)Math.Sqrt((nextPosition.X - origin.X) * (nextPosition.X - origin.X)
                                                + (nextPosition.Y - origin.Y) * (nextPosition.Y - origin.Y));
                if (radian <= 45)
                {
                    origin.X = nextPosition.X + distanse;

                    radian = 0;
                }
                else if (radian <= 135)
                {
                    origin.Y = nextPosition.Y - distanse;
                    radian = 90;
                }
                else if (radian <= 225)
                {
                    origin.X = nextPosition.X - distanse;

                    radian = 180;
                }
                else if (radian < 315)
                {
                    origin.Y = nextPosition.Y + distanse;

                    radian = 270;
                }
                else
                {
                    origin.X = nextPosition.X + distanse;

                    radian = 0;
                }

                position = nextPosition;

                hide = false;
                //senterPosition = (position + basePosition) * 2;
                //couse = true;
                //isDead = true;
            }
        }
        public override void Draw()
        {
            if (hide)
            {
                renderer.DrawTexture(
                name,      //アセット名                 
                position,                   //位置                 
                new Rectangle(0, 0, (int)radius * 2, (int)radius * 2),
                Color.White * 0.5f,         //色*透明度                 
                kaiten,                       //回転                 
                new Vector2(radius, radius),//表示中心                 
                new Vector2(1.0f, 1.0f)     //倍率
                );
            }
        }
    }
}

