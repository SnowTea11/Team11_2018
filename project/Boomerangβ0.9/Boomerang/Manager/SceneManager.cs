using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomerang
{
    class SceneManager
    {
        private Dictionary<SceneType, IScene> scenes = new Dictionary<SceneType, IScene>();
        private IScene currentScene = null;
        private GameManager gameManager;
        private Renderer renderer;

        public SceneManager(GameManager gameManager)
        {
            this.gameManager = gameManager;
            renderer = gameManager.GetRenderer();
        }
        public void AddScene(SceneType sceneType, IScene scene)
        {
            scenes[sceneType] = scene;
        }
        public void Change(SceneType sceneType)
        {
            //現在のシーンを終了
            if (currentScene != null)
            {
                currentScene.Shutdown();
            }
            //現在のシーンを変更、初期化
            currentScene = this.scenes[sceneType];
            currentScene.Initialize();
        }
        public void Update()
        {
            //ゲームマネージャーの更新後に各シーンのUpdateを実行
            gameManager.Update();
            currentScene.Update();
            //シーン管理からシーンに終了を問い合わせる
            if (currentScene.IsEnd())
            {
                Change(currentScene.Next());
            }
        }
        public void Draw()
        {
            //各シーンのDraw実行、前後に
            renderer.Begin();
            currentScene.Draw();
            renderer.End();
        }
    }
}
