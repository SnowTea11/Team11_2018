using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Boomerang
{
    class Renderer
    {
        private ContentManager contentManager;
        private SpriteBatch spriteBatch;
        private GraphicsDevice graphicsDevice;
        private Dictionary<string, Texture2D> textures = new Dictionary<string, Texture2D>();

        public Renderer(ContentManager content, GraphicsDevice graphics)
        {
            contentManager = content;
            contentManager.RootDirectory = "Content";
            graphicsDevice = graphics;
            spriteBatch = new SpriteBatch(graphics);
        }

        public void LoadTexture(string name)
        {
            textures[name] = contentManager.Load<Texture2D>(name);
        }
        public void UnloadContent()
        {
            textures.Clear();
        }
        public void Begin()
        {
            spriteBatch.Begin();
        }
        public void End()
        {
            spriteBatch.End();
        }
        public void DrawTexture(string name, Vector2 position)
        {
            spriteBatch.Draw(textures[name], position, Color.White);
        }
        public void DrawTexture(string name, Vector2 position, float alpha = 1.0f)
        {
            spriteBatch.Draw(textures[name], position, Color.White * alpha);
        }
        public void DrawTexture(string name, Vector2 position, Rectangle rectangle, float alpha = 1.0f)
        {
            spriteBatch.Draw(textures[name], position, rectangle, Color.White * alpha);
        }
        public void DrawTexture(string name, Vector2 position, Rectangle rectangle, Color color, float angle, Vector2 center, Vector2 size)
        {
            spriteBatch.Draw(textures[name], //テクスチャ                 
                position,       //位置                 
                rectangle,      //テクスチャ内矩形                 
                color,          //色(alpha 込)                 
                angle,          //回転角度(ラジアン)                 
                center,         //表示中心位置                 
                size,           //拡大 XY                 
                SpriteEffects.None,         //エフェクト                 
                0.0f            //レイヤー(0 でフロント、1 でバック)             
                );
        }
        public void DrawNumber(string name, Vector2 position, int number)
        {
            foreach (var n in number.ToString())
            {
                spriteBatch.Draw(textures[name], position, new Rectangle((n - '0') * 32, 0, 32, 64), Color.White);
                position.X += 32;
            }
        }

    }
}
