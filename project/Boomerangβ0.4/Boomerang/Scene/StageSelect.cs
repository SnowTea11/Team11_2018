using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class StageSelect : IScene
    {
        private SceneType nextScene;
        private int cursorPosition;//カーソルの場所

        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;

        private bool isEnd;//シーン終了フラグ

        public StageSelect(GameManager gameManager)
        {
            this.gameManager = gameManager;
            inputState = gameManager.GetInputState();
            sound = gameManager.GetSound();
            renderer = gameManager.GetRenderer();
            //ランダムは未使用
        }
        public void Initialize()
        {
            cursorPosition = 60;
            nextScene = SceneType.Stage1;
            isEnd = false;
        }
        public void Update()
        {
            sound.PlayBGM("stageBGM");

            SceneCange();

            if (inputState.IsKeyDown(Keys.Left))
            {
                if (cursorPosition > 60)
                {
                    cursorPosition -= 240;
                    sound.PlaySE("inputSE");
                }
            }
            if (inputState.IsKeyDown(Keys.Right))
            {
                if (cursorPosition < 1020)
                {
                    cursorPosition += 240;
                    sound.PlaySE("inputSE");
                }
            }

            if (inputState.IsKeyDown(Keys.Space))
            {
                this.isEnd = true;
                sound.PlaySE("decideSE");
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("stage", Vector2.Zero);
            renderer.DrawTexture("player_sd", new Vector2(cursorPosition, 550));
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
            return nextScene;//ゲームプレイへ
        }

        private void SceneCange()
        {
            if (cursorPosition == 100)
            {
                nextScene = SceneType.Stage1;
            }
            if (cursorPosition == 200)
            {
                nextScene = SceneType.Stage2;
            }
            if (cursorPosition == 300)
            {
                nextScene = SceneType.Stage3;
            }
            if (cursorPosition == 400)
            {
                nextScene = SceneType.Stage4;
            }
            if (cursorPosition == 500)
            {
                nextScene = SceneType.Stage5;
            }
        }
    }
}
