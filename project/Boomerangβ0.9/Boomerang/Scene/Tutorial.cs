using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class Tutorial : IScene
    {
        private SceneType nextScene;
        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;

        private bool isEnd;//シーン終了フラグ

        public Tutorial(GameManager gameManager)
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
            sound.PlayBGM("titleBGM");

            //つぎのシーンはステージセレクト
            nextScene = SceneType.StageSelect;

            if (inputState.IsKeyDown(Keys.Space) || inputState.IsPadDown(Buttons.A))
            {
                this.isEnd = true;
                sound.PlaySE("inputSE");
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("tutorial", Vector2.Zero);
            renderer.DrawTexture("tuto_boomerang",new Vector2(900,400));
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
            return nextScene;//ステージセレクト
        }
    }
}

