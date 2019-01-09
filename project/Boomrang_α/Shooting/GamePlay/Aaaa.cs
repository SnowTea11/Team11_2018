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

        private Vector2 basePosition;
        private float rotateHeight;
        private double radian;
        private bool hide;
        private float kaiten = 0;

        public Aaaa(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.PlayerBullet, "boomerang", position, 24.0f, gameManager, mediator)
        {
            basePosition = position;
            rotateHeight = 64.0f;
            radian = 90.0f;
            hide = false;

            
        }
        public override void Update()
        {  
            //円移動
            //弾のＸ座標 = 回転軸のＸ座標 + cos(回転軸からの角度) * 回転軸からの距離
            //弾のＹ座標 = 回転軸のＹ座標 + sin(回転軸からの角度) * 回転軸からの距離
            float cos = (float)Math.Cos(radian);
            float sin = (float)Math.Sin(radian);
            radian += ((float)Math.PI / 180);//回転軸からの距離を右分増加

            position.X = (basePosition.X) + cos * rotateHeight;
            position.Y = (basePosition.Y) + sin * rotateHeight;

            hide = true;

            kaiten += 0.5f;
        }
        public override void Hit(Character character)
        {
        }
        public override void Draw()
        {
            if(hide)
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


