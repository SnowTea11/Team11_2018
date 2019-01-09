using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Shooting
{
    class GameManager
    {
        private InputState inputState;
        public InputState GetInputState()
        {
            return inputState;
        }

        private Renderer renderer;
        public Renderer GetRenderer()
        {
            return renderer;
        }

        private Sound sound;
        public Sound GetSound()
        {
            return sound;
        }

        private Random random;
        public Random GetRandom()
        {
            return random;
        }

        private int score;
        public int GetScore()
        {
            return score;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }

        private int hiScore;
        public int GetHiScore()
        {
            return hiScore;
        }
        public void SetHiScore(int hiScore)
        {
            if (hiScore < this.hiScore) return;
            this.hiScore = hiScore;
        }

        public GameManager(ContentManager content, GraphicsDevice graphics)
        {
            inputState = new InputState();
            renderer = new Renderer(content, graphics);
            sound = new Sound(content);
            random = new Random();
            hiScore = 0;//最初に一回だけ
        }
        public void LoadContent()
        {
            //α
            renderer.LoadTexture("boomerang");
            renderer.LoadTexture("player");
            renderer.LoadTexture("enemy");
            renderer.LoadTexture("bumper");
            renderer.LoadTexture("block");
            renderer.LoadTexture("air_flow");


            //グラフィック、サウンドの読み込み
            renderer.LoadTexture("gametitle");
            renderer.LoadTexture("gameplay");
            renderer.LoadTexture("gameover");
            renderer.LoadTexture("Player64");
            renderer.LoadTexture("Bullet16");
            renderer.LoadTexture("Enemy64");
            renderer.LoadTexture("Explosion64");
            renderer.LoadTexture("score");
            renderer.LoadTexture("hiscore");
            renderer.LoadTexture("number");
            renderer.LoadTexture("EnemyBullet16");
            //追加：ボスリソース読み込み             
            renderer.LoadTexture("Boss1");
            renderer.LoadTexture("Boss2");
            renderer.LoadTexture("Boss3");
            renderer.LoadTexture("BossBullet64");
            renderer.LoadTexture("BossBulletB64");
            renderer.LoadTexture("ministorm");

            sound.LoadBGM("titlebgm");
            sound.LoadBGM("gameplaybgm");
            sound.LoadBGM("endingbgm");
            sound.LoadSE("titlese");
            sound.LoadSE("gameplayse");
            sound.LoadSE("endingse");
            sound.LoadSE("Explosion");
            sound.LoadSE("shot");
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
