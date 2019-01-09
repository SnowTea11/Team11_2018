using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class EnemyGenerator
    {
        //エネミー発生用データ、一件分
        // struct、構造体と呼ぶ、クラスより負荷が軽い
        private struct GenerateData
        {
            public int frameTime;	//発生時間
            public string enemyType;	//敵の種類
            public Vector2 position;    //発生位置
            //コンストラクタ
            public GenerateData(int frameTime, string enemyType, Vector2 position)
            {
                this.frameTime = frameTime;
                this.enemyType = enemyType;
                this.position = position;
            }
        }
        //エネミー発生用データ、全部
        private List<GenerateData> generateData;
        //現在使用中データ位置
        private int currentIndex;
        //フレームカウンタ、時間の代わりに使用
        private int frameCounter;

        //コンストラクタ、newするとき、データファイル名を指定すること。
        //Initializeが作成されるまでエラーは外れない。
        public EnemyGenerator(string fileName)
        {
            Initialize(fileName);
        }
        //初期化
        public void Initialize(string fileName)
        {
            if (generateData != null)
            {
                generateData.Clear();	//すでにデータが入っていいればクリア。
            }
            else
            {
                generateData = new List<GenerateData>();
            }
            currentIndex = 0;
            frameCounter = 0;

            ReadData(fileName);//プログラムが長くなりそうなときはメソッドを分割する。
        }
        //データの読み込み
        private void ReadData(string fileName)
        {
            FileStream datafs = new FileStream(fileName, FileMode.Open);
            StreamReader dataSr = new StreamReader(datafs);

            while (!dataSr.EndOfStream)
            {
                string line = dataSr.ReadLine();
                string[] items = line.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (items.Length != 4) continue;    //データの件数が4以外はここで終わり
                                                    //変数にデータを変換してセット
                int frameTime = int.Parse(items[0]);
                string enemyType = items[1];
                Vector2 position = new Vector2(int.Parse(items[2]), int.Parse(items[3]));
                //リストに追加する。
                generateData.Add(new GenerateData(frameTime, enemyType, position));
            }
            //すべてのデータが登録したら出現時間でソートする。
            generateData.Sort((x, y) => x.frameTime.CompareTo(y.frameTime));

            dataSr.Close();
        }
        // characterManagerにエネミーを追加する。Updateで使用する。
        public void AddEnemys(GameManager gameManager, CharacterManager characterManager)
        {
            //データが終わったらこれ以上実行しない。
            if (currentIndex >= generateData.Count) return;
            //時間を進める。
            frameCounter++;
            //今の時間と同じデータを全て登録する。
            while ((currentIndex < generateData.Count) && (frameCounter == generateData[currentIndex].frameTime))
            {
                characterManager.AddCharacter(generateEnemy(generateData[currentIndex], gameManager, characterManager));
                currentIndex++;
            }
        }
        //敵を生成する部分を分離。
        private Character generateEnemy(GenerateData generateData, GameManager gameManager, CharacterManager characterManager)
        {
            if (generateData.enemyType == "Enemy")
            {
                return new Enemy(generateData.position, gameManager, characterManager);
            }
            if (generateData.enemyType == "Enemy2")
            {
                return new Enemy2(generateData.position, gameManager, characterManager);
            }
            if (generateData.enemyType == "Enemy3")
            {
                return new Enemy3(generateData.position, gameManager, characterManager);
            }
            if (generateData.enemyType == "Enemy4")
            {
                return new Enemy4(generateData.position, gameManager, characterManager);
            }
            if (generateData.enemyType == "Enemy5")
            {
                return new Enemy5(generateData.position, gameManager, characterManager);
            }
            if (generateData.enemyType == "EnemyBoss")
            {
                return new EnemyBoss(gameManager, characterManager);
            }
            //敵の種類がわからないときは生成しない。
            return null;
        }
        public bool IsEnemyEnd()
        {
            return currentIndex >= generateData.Count;
        }
    }
}
