using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooting
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
            sceneManager.AddScene(SceneType.GameTitle, new GameTitle(gameManager));
            sceneManager.AddScene(SceneType.GamePlay, new GamePlay(gameManager));
            sceneManager.AddScene(SceneType.GameOver, new GameOver(gameManager));
            //開始シーンを指定
            sceneManager.Change(SceneType.GamePlay);

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
