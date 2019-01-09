using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class InputState
    {
        private KeyboardState currentKey;
        private KeyboardState previousKey;
        private Vector2 keyVelocity = Vector2.Zero;

        private GamePadState currentPad;
        private GamePadState previousPad;
        private Vector2 padVelocity;

        public InputState() { }
        public bool IsKeyDown(Keys key)
        {
            bool current = currentKey.IsKeyDown(key);
            bool previous = previousKey.IsKeyDown(key);

            return current && !previous;
        }
        public Vector2 KeyVelocity()//ゲッター
        {
            return keyVelocity;
        }
        private void UpdateKey(KeyboardState keyState)
        {
            previousKey = currentKey;
            currentKey = keyState;
        }
        private void UpdateKeyVelocity(KeyboardState keyState)
        {
            keyVelocity = Vector2.Zero;

            if (keyState.IsKeyDown(Keys.Right))     // 右
            {
                keyVelocity.X = +1.0f;
            }
            if (keyState.IsKeyDown(Keys.Left))      // 左
            {
                keyVelocity.X = -1.0f;
            }
            if (keyState.IsKeyDown(Keys.Down))      // 下
            {
                keyVelocity.Y = +1.0f;
            }
            if (keyState.IsKeyDown(Keys.Up))        // 上
            {
                keyVelocity.Y = -1.0f;
            }

            if (keyVelocity.Length() != 0.0f) 
            {
                keyVelocity.Normalize();
            }
        }

        public bool IsPadDown(Buttons button)
        {
            bool current = currentPad.IsButtonDown(button);
            bool previous = previousPad.IsButtonDown(button);

            return current && !previous;
        }
        public Vector2 PadVelocity()
        {
            return padVelocity;
        }
        private void UpdatePad(GamePadState padState)
        {
            previousPad = currentPad;
            currentPad = padState;
        }
        private void UpdatePadVelocity(GamePadState padState)
        {
            padVelocity = Vector2.Zero;

            if (padState.DPad.Up == ButtonState.Pressed)
            {
                padVelocity.Y = -1.0f;
            }
            if (padState.DPad.Down == ButtonState.Pressed)
            {
                padVelocity.Y = +1.0f;
            }
            if (padState.DPad.Left == ButtonState.Pressed)
            {
                padVelocity.X = -1.0f;
            }
            if (padState.DPad.Right == ButtonState.Pressed)
            {
                padVelocity.X = 1.0f;
            }

            if (padVelocity.Length() != 0.0f)
            {
                keyVelocity.Normalize();
            }
        }

        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            UpdateKey(keyState);
            UpdateKeyVelocity(keyState);

            GamePadState padState = GamePad.GetState(PlayerIndex.One);
            UpdatePad(padState);
            UpdatePadVelocity(padState);
        }
    }
}
