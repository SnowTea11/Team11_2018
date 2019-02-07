using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
	class BumeranUI:Character
	{
		//\pajero

		//\pajero
		//\pajero
		//\pajero
		//\pajero
		//\pajero
		//\pajero

		//回転軸
		private Vector2 origin;
		//プレイヤーの現在位置の取得(Hit時用)
		private Vector2 nextPosition;
		//回転軸からの距離
		private float rotateHeight;
		//回転軸からの角度
		private double radian;
		//１フレーム前のサイン、コサイン
		private float bCos;
		private float bSin;

        bool Direction;

		public BumeranUI(Vector2 position, GameManager gameManager, ICharacterMediator mediator, bool Direction)
			: base(CharacterID.BoomerangUI, "dotted_right", position, 24.0f, gameManager, mediator)
		{
            this.Direction = Direction;
		}
		public override void Update()
		{
			if(!gameManager.GetInputState().IsKeyPush(Keys.J))
			{
				isDead = true;
			}
		}
		public override void Hit(Character character)
		{
			

		}
		public override void Draw()
		{
            if(Direction == true)
            {
			    renderer.DrawTexture("dotted_right",position);
            }
            else
            {
                renderer.DrawTexture("dotted", position);
            }

		}
	}
}
