using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class Result : IScene
    {
        private int cursorPosition;//カーソルの場所
        private SceneType nextScene;
        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState input;
        private Sound sound;
        public int state;

        private bool isEnd;//シーン終了フラグ

        public Result(GameManager gameManager)
        {
            this.gameManager = gameManager;
            input = gameManager.GetInputState();
            sound = gameManager.GetSound();
            renderer = gameManager.GetRenderer();
        }
        public void Initialize()
        {
            state = gameManager.GetStage();
            cursorPosition = 120;
            isEnd = false;
        }
        public void Update()
        {
            sound.PlayBGM("resultBGM");


            if (input.IsKeyDown(Keys.Left))
            {
                cursorPosition = 120;
            }
            if (input.IsKeyDown(Keys.Right))
            {
                cursorPosition = 650;
            }

            if (input.IsKeyDown(Keys.Space))
            {
                SceneCange();
                this.isEnd = true;
                sound.PlaySE("inputSE");
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("result", Vector2.Zero);
            renderer.DrawTexture("cursur", new Vector2(cursorPosition, 620));

            Evaluate();
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
            return nextScene;//ゲームタイトルへ
        }

        private void SceneCange()
        {

            if (cursorPosition == 120)
            {
                NScene();
            }
            if (cursorPosition == 650)
            {
                nextScene = SceneType.StageSelect;
            }
        }
        private void NScene()
        {
            if (state == 0)
            {
                nextScene = SceneType.Stage1;
            }
            else if (state == 1)
            {
                nextScene = SceneType.Stage2;
            }
            else if (state == 2)
            {
                nextScene = SceneType.Stage3;
            }
            else if (state == 3)
            {
                nextScene = SceneType.Stage4;
            }
            else if (state == 4)
            {
                nextScene = SceneType.Stage5;
            }
            else
            {
                nextScene = SceneType.Title;
            }
        }
        private void Evaluate()
        {
            if (input.IsKeyPush(Keys.S))
            {
                renderer.DrawTexture("star_on", new Vector2(150, 150));
                renderer.DrawTexture("star_on", new Vector2(475, 150));
                renderer.DrawTexture("star_on", new Vector2(800, 150));
                renderer.DrawTexture("rankS", new Vector2(700, 430));
            }
            if (input.IsKeyPush(Keys.A))
            {
                renderer.DrawTexture("star_on", new Vector2(150, 150));
                renderer.DrawTexture("star_on", new Vector2(475, 150));
                renderer.DrawTexture("star_off", new Vector2(800, 150));
                renderer.DrawTexture("rankA", new Vector2(700, 430));
            }
            if (input.IsKeyPush(Keys.B))
            {
                renderer.DrawTexture("star_on", new Vector2(150, 150));
                renderer.DrawTexture("star_off", new Vector2(475, 150));
                renderer.DrawTexture("star_off", new Vector2(800, 150));
                renderer.DrawTexture("rankB", new Vector2(700, 430));
            }
            if (input.IsKeyPush(Keys.C))
            {
                renderer.DrawTexture("star_off", new Vector2(150, 150));
                renderer.DrawTexture("star_off", new Vector2(475, 150));
                renderer.DrawTexture("star_off", new Vector2(800, 150));
                renderer.DrawTexture("rankC", new Vector2(700, 430));
            }
        }
    }
}
