using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Boomerang
{
    class GameManager
    {
        private InputState inputState;
        private Renderer renderer;
        private Sound sound;
        private Random random;
        private int score;
        private int hiScore;
        private int stagestate;
        private int enemyCounter;
        private int boomerangCounter;
        private int rank;
        private bool pitch;

        public InputState GetInputState()
        {
            return inputState;
        }
        public Renderer GetRenderer()
        {
            return renderer;
        }
        public Sound GetSound()
        {
            return sound;
        }
        public Random GetRandom()
        {
            return random;
        }
        public int GetScore()
        {
            return score;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }
        public int GetHiScore()
        {
            return hiScore;
        }
        public void SetHiScore(int hiScore)
        {
            if (hiScore < this.hiScore) return;
            this.hiScore = hiScore;
        }

        //ステージ取得用
        public int GetStage()
        {
            return stagestate;
        }
        //次に行くステージ
        public void SetStage(int _stage)
        {
            this.stagestate = _stage;
        }
        //残りのエネミー数
        public int GetEcounter()
        {
            return enemyCounter;
        }
        public void SetEcounter(int _eCounter)
        {
            this.enemyCounter = _eCounter;
        }
        //残りブーメラン数
        public int GetBcounter()
        {
            return boomerangCounter;
        }
        public void SetBcounter(int _bCounter)
        {
            this.boomerangCounter = _bCounter;
        }
        //ランク
        public int GetRank()
        {
            return rank;
        }
        public void SetRank(int _rank)
        {
            this.rank = _rank;
        }
        public bool GetPitch()
        {
            return pitch;
        }
        public void SetPitch(bool _pitch)
        {
            this.pitch = _pitch;
        }


        public GameManager(ContentManager content, GraphicsDevice graphics)
        {
            inputState = new InputState();//操作
            renderer = new Renderer(content, graphics);//描画
            sound = new Sound(content);//音
            random = new Random();
            hiScore = 0;//最初に一回だけ
        }
        public void LoadContent()
        {
            //キャラクター
            renderer.LoadTexture("player_sd");//セレクトのプレイヤー
            renderer.LoadTexture("player");//プレイヤー
            renderer.LoadTexture("player_right");//プレイヤー反転
            renderer.LoadTexture("enemy");//敵
            renderer.LoadTexture("boomerang");//ブーメラン

            //ブロック
            renderer.LoadTexture("air_flow"); //気流
            renderer.LoadTexture("block"); //ブロック
            renderer.LoadTexture("bumper"); //高反発       
            renderer.LoadTexture("form"); //低反発

            //背景
            renderer.LoadTexture("title");//タイトル
            renderer.LoadTexture("gameplay");//ゲームプレイ
            renderer.LoadTexture("result");//リザルト
            renderer.LoadTexture("stage");//ステージセレクト
            renderer.LoadTexture("tutorial");//操作説明

            //UI
            renderer.LoadTexture("rankA");//ランクA
            renderer.LoadTexture("rankB");//ランクB
            renderer.LoadTexture("rankC");//ランクC
            renderer.LoadTexture("rankS");//ランクS
            renderer.LoadTexture("star_off");//リザルトの空の星
            renderer.LoadTexture("star_on");//リザルトの星
            renderer.LoadTexture("tuto_boomerang");//カーソル
            renderer.LoadTexture("cursur");//カーソル
            renderer.LoadTexture("dotted");//弾道予測線
            renderer.LoadTexture("dotted_right");//弾道予測線
            renderer.LoadTexture("start");//スタートボタン

            //SE
            sound.LoadSE("air_flowSE");//気流に当たった時
            sound.LoadSE("blockSE");//ブロックに当たった時
            sound.LoadSE("boomerangSE");//
            sound.LoadSE("bumperSE");//バンパーに当たった時
            sound.LoadSE("decideSE");//ステージ選択した時
            sound.LoadSE("en_voiceSE");//
            sound.LoadSE("formSE");//低反発に当たった時
            sound.LoadSE("inputSE");//選択したとき
            sound.LoadSE("resultSE");//リザルトで決定キー押した時

            //BGM
            sound.LoadBGM("titleBGM");//タイトル
            sound.LoadBGM("resultBGM");//リザルト
            sound.LoadBGM("stageBGM");//ステージセレクト
            sound.LoadBGM("gameplayBGM");//プレイ
        }
        public void UnloadContent()
        {
            renderer.UnloadContent();
            sound.UnloadContent();
        }
        public void Update()
        {
            //Updateで最初に実行
            inputState.Update();
        }
    }
}
