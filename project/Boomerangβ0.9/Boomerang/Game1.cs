using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        private GameManager gameManager;
        private SceneManager sceneManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Screen.Width;
            graphics.PreferredBackBufferHeight = Screen.Height;

        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameManager = new GameManager(Content, GraphicsDevice);

            //シーンマネージャーにシーンの登録
            sceneManager = new SceneManager(gameManager);
            sceneManager.AddScene(SceneType.Title, new Title(gameManager));
            sceneManager.AddScene(SceneType.Tutorial, new Tutorial(gameManager));
            sceneManager.AddScene(SceneType.StageSelect, new StageSelect(gameManager));
            sceneManager.AddScene(SceneType.Stage1, new Stage1(gameManager));
            sceneManager.AddScene(SceneType.Stage2, new Stage2(gameManager));
            sceneManager.AddScene(SceneType.Stage3, new Stage3(gameManager));
            sceneManager.AddScene(SceneType.Stage4, new Stage4(gameManager));
            sceneManager.AddScene(SceneType.Stage5, new Stage5(gameManager));
            sceneManager.AddScene(SceneType.Result, new Result(gameManager));
            //開始シーンを指定
            sceneManager.Change(SceneType.Stage1);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            gameManager.LoadContent();
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            gameManager.UnloadContent();
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            sceneManager.Update();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            sceneManager.Draw();

            base.Draw(gameTime);
        }
    }
}
