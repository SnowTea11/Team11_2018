using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class Motion
    {
        private int minIndex;   //範囲の最初
        private int maxIndex;   //範囲の最後+1
        private int interval;   //モーションの間隔
        private int counter;    //カウンター
        private int currentIndex;   //今のモーション番号
        //表示位置を番号で管理する
        //Dictionaryを使えば登録の順番を気にしなくてもよい
        private Dictionary<int, Rectangle> rectangles = new Dictionary<int, Rectangle>();

        //newした状態ではアニメーションしない
        public Motion()
        {
            Initialize(0, 0, 0);
        }
        //指定した番号から番号の間を順に表示していく
        //間隔は60で１秒
        public void Initialize(int minIndex, int maxIndex, int interval)
        {
            this.minIndex = minIndex;
            this.maxIndex = maxIndex;
            this.interval = interval;
            counter = interval;		//カウンター
            currentIndex = minIndex;	//今のモーション番号
        }
        //表示範囲の登録
        public void AddRectangle(int index, Rectangle rectangle)
        {
            rectangles[index] = rectangle;
        }
        //カウンターとモーション番号の処理
        public void Update()
        {
            if (minIndex >= maxIndex) return;//変化しない
            counter--;
            if (counter <= 0)//番号を増やす
            {
                counter = interval;
                currentIndex++;
                if (currentIndex >= maxIndex)//番号を元に戻す
                {
                    currentIndex = minIndex;
                }
            }
        }
        //今の表示範囲を取り出す。
        public Rectangle CurrentRectangle()
        {
            return rectangles[currentIndex];
        }
    }
}
