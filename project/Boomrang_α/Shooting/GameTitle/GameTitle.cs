using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shooting
{
    class GameTitle : IScene
    {
        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;

        private bool isEnd;//シーン終了フラグ

        public GameTitle(GameManager gameManager)
        {
            this.gameManager = gameManager;
            inputState = gameManager.GetInputState();
            sound = gameManager.GetSound();
            renderer = gameManager.GetRenderer();
            //ランダムは未使用
        }
        public void Initialize()
        {
            isEnd = false;
        }
        public void Update()
        {
            sound.PlayBGM("titlebgm");
            if (inputState.IsKeyDown(Keys.Space))
            {
                this.isEnd = true;
                sound.PlaySE("titlese");
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("gametitle", Vector2.Zero);
        }
        public void Shutdown()
        {
            sound.StopBGM();
        }
        public bool IsEnd()
        {
            return this.isEnd;
        }
        public SceneType Next()
        {
            return SceneType.GamePlay;//ゲームプレイへ
        }
    }
}
