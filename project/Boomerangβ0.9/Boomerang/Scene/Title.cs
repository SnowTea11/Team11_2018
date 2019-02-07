using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class Title : IScene
    {
        private SceneType nextScene;//どのシーンに行くか決める用
        private bool frashCheck;// alpha値を増減を変える用
        private float alphaChange;//点滅
        private float alphaValue;//alphaの値

        //使用する分だけ用意
        private GameManager gameManager;
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;
        private bool isEnd;//シーン終了フラグ

        public Title(GameManager gameManager)
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
            frashCheck = true;
            alphaChange = 1.0f / 60f;
            alphaValue = 1.2f;
        }
        public void Update()
        {
            nextScene = SceneType.Tutorial;

            sound.PlayBGM("titleBGM");

            if (inputState.IsKeyDown(Keys.Space) || inputState.IsPadDown(Buttons.A))
            {
                this.isEnd = true;
                sound.PlaySE("inputSE");
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("title", Vector2.Zero);
            renderer.DrawTexture("start", new Vector2(300, 550),alphaValue);

            Flashing();
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
            return nextScene;//チュートリアル画面へ
        }
        private void Flashing()
        {
            if (frashCheck)// スタート
            {
                alphaValue += alphaChange;// alpha値を増やす
                if (alphaValue >= 1.2f)  // alpha値が1.2f以上になったらalpha値を減らす処理に移行する
                    frashCheck = false;
            }
            else
            {
                alphaValue -= alphaChange;// alpha値を減らす
                if (alphaValue <= 0.2f)  // alpha値が0.5f以下になったらalpha値を増やす処理に移行する
                    frashCheck = true;
            }
        }
    }
}
