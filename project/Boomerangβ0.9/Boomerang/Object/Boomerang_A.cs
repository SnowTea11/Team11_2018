using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Boomerang
{
    class Boomerang_A : Character
    {
        //\pajero

        //\pajero
        //\pajero
        //\pajero
        //\pajero
        //\pajero
        //\pajero
        Character character;
        //回転軸
        private Vector2 origin;
        //プレイヤーの現在位置の取得(Hit時用)
        private Vector2 nextPosition;
        //回転軸からの距離
        private float rotateHeight;
        //回転軸からの角度
        private double radian;

        // 代入して仮置きする用の変数
        private float oldHeight;

        //投げ初めのちらつきを消す用のフラグ
        private bool hide;
        //回転速度
        private float kaiten = 0;

        //１フレーム前のサイン、コサイン
        private float bCos;
        private float bSin;

        //サイン、コサイン
        private float cos;
        private float sin;

        // 気流用のsin反転用フラグ
        private bool NotSin = true;

        private float count = 60;

        // 死亡フラグ用のフラグ
        private bool isDeadFlag = false;

        public Boomerang_A(Vector2 position, GameManager gameManager, ICharacterMediator mediator)
            : base(CharacterID.PlayerBullet, "boomerang", position, 24.0f, gameManager, mediator)
        {
            origin = position;//初期位置を回転軸にする
            rotateHeight = 144.0f;//回転軸からの距離
            radian = 4.71f;//回転軸からの角度(0が回転軸から見て左)
            hide = false;//描画するかどうかのフラグ
            gameManager.SetPitch(true);
        }
        public override void Update()
        {
            //前のフレームのCosとSin
            bCos = cos;
            bSin = sin;


            //円移動
            //弾のＸ座標 = 回転軸のＸ座標 + cos(回転軸からの角度) * 回転軸からの距離
            cos = (float)Math.Cos(radian);
            //弾のＹ座標 = 回転軸のＹ座標 + sin(回転軸からの角度) * 回転軸からの距離                                                                                                         
            sin = (float)Math.Sin(radian);

            //回転軸からの角度
            radian += ((float)Math.PI / 180);

            //Xの移動
            position.X = origin.X + -cos * rotateHeight;

            //Yの移動
            if (NotSin)
            {

                position.Y = origin.Y + -sin * rotateHeight;
            }
            else
            {
                position.Y = origin.Y + sin * rotateHeight;
            }
            //ブーメランの回転速度
            kaiten += 0.5f;

            // 一定まで飛ぶとフラグ、帰るとDeadする
            if (position.Y < 680)
            {
                isDeadFlag = true;
            }
            if (position.Y > 689 && isDeadFlag == true)
            {
                gameManager.SetBcounter(gameManager.GetBcounter() - 1);
                gameManager.SetPitch(false);
                isDead = true;
            }

            //プレイヤーの現在位置
            nextPosition = position;

            //投げ初めのちらつきを消す用のフラグ(みえるようにする)
            hide = true;
        }

        //Hit時の処理
        public override void Hit(Character character)
        {
            //描画されてないときは当たらない
            if (!hide) return;

            //距離を測る
            //float distanse = (float)Math.Sqrt((nextPosition.X - origin.X) * (nextPosition.X - origin.X) + (nextPosition.Y - origin.Y) * (nextPosition.Y - origin.Y));

            //バンパーに当たった時
            if (character.GetCharacterID() == CharacterID.Enemy2)
            {
                BumperReact();
            }
            //低反発に当たった時
            if (character.GetCharacterID() == CharacterID.Enemy3)
            {
                LowReact();
            }
            //気流にあたった時
            if (character.GetCharacterID() == CharacterID.Enemy4)
            {
                AirReact();
            }
            //ブロックに当たった時の処理
            if (character.GetCharacterID() == CharacterID.Enemy)
            {
                BlockReact();
                //isDead = true;
            }

            position = nextPosition;

            //回転軸が移動したときのちらつき防止
            hide = false;
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
        private void BlockReact()//ブロックに当たった時の処理
        {


            if (!NotSin) //時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight * 2;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight * 2;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight * 2;
                    radian = 3.65;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y - rotateHeight * 2;
                    radian = 2.3;
                }
            }

            if (NotSin) //反時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight * 2;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight * 2;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight * 2;
                    radian = 3.7;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y + rotateHeight * 2;
                    radian = 2.3;
                }
            }

        }
        private void BumperReact()
        {//バンパーに当たった時

            oldHeight = rotateHeight;
            rotateHeight += 48;

            if (rotateHeight > 192)
            {
                rotateHeight = 192;
            }
            if (!NotSin) //時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight + oldHeight;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight - oldHeight;
                    radian = 3.65;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 2.3;
                }
            }

            if (NotSin) //反時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight + oldHeight;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight - oldHeight;
                    radian = 3.7;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y + rotateHeight + oldHeight;
                    radian = 2.3;
                }
            }

        }
        private void LowReact()
        {//低反発に当たった時

            oldHeight = rotateHeight;
            //rotateHeight = 144;
            rotateHeight -= 48;

            if (rotateHeight < 96)
            {
                rotateHeight = 96;
            }
            if (!NotSin) //時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight + oldHeight;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight - oldHeight;
                    radian = 3.65;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 2.3;
                }
            }

            if (NotSin) //反時計回りのとき
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight - oldHeight;
                    radian = 5.25;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight + oldHeight;
                    radian = 0.8;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight - oldHeight;
                    radian = 3.7;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y + rotateHeight + oldHeight;
                    radian = 2.3;
                }
            }

        }
        private void AirReact()
        {//気流に当たった時

            //反転用
            NotSin = !NotSin;

            //反時計回りのとき
            if (NotSin)
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y + rotateHeight * 2;
                    radian = 2.1;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight * 2;
                    radian = 0.6;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight * 2;
                    radian = 3.8;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y - rotateHeight * 2;
                    radian = 5.3;
                }
            }
            //時計回りのとき(いつもの)
            if (!NotSin)
            {
                //第2象限
                if (bCos > cos && bSin < sin)
                {
                    origin.Y = origin.Y - rotateHeight * 2;
                    radian = 2.1;
                }
                //第4象限
                else if (bCos > cos && bSin > sin)
                {
                    origin.X = origin.X + rotateHeight * 2;
                    radian = 0.6;
                }
                //第3象限
                else if (bCos < cos && bSin < sin)
                {
                    origin.X = origin.X - rotateHeight * 2;
                    radian = 3.8;
                }
                //第1象限
                else if (bCos < cos && bSin > sin)
                {
                    origin.Y = origin.Y + rotateHeight * 2;
                    radian = 5.3;
                }
            }
        }
    }   
}
