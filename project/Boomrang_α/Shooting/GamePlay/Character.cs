using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooting
{
    public enum CharacterID
    {
        PlayerSide = 1,
        EnemySide = 2,
        NeutralSide = 3,
        CheckNumber = 100,
        Player = PlayerSide * CheckNumber,
        PlayerBullet,        
        Enemy = EnemySide * CheckNumber,
        Enemy2,
        Enemy3,
        Enemy4,
        EnemyBullet,
        EnemyStorm, //追加
        EnemyBoss,  //追加
        Explosion = NeutralSide * CheckNumber
    }
    abstract class Character
    {
        protected CharacterID characterID;
        public CharacterID GetCharacterID()
        {
            return characterID;
        }
        protected string name;    //アセット名
        protected Vector2 position;   //位置
        public Vector2 GetPosition()
        {
            return position;
        }

        protected float radius;   //半径
        protected bool isDead = false;
        protected GameManager gameManager;
        protected ICharacterMediator mediator;
        protected Renderer renderer;

        public Character(CharacterID charcterID, string name, Vector2 position, float radius,
            GameManager gameManager, ICharacterMediator mediator)
        {
            this.characterID = charcterID;
            this.name = name;
            this.position = position;
            this.radius = radius;
            this.gameManager = gameManager;
            this.mediator = mediator;
            this.renderer = gameManager.GetRenderer();
        }

        public abstract void Update();
        public abstract void Hit(Character character);

        public virtual void Draw()
        {
            renderer.DrawTexture(name, position - new Vector2(radius, radius));
        }
        public bool IsDead()
        {
            return isDead;
        }
        public bool Collision(Character character)
        {
            if (Vector2.Distance(this.position, character.position) <= (this.radius + character.radius))
            {
                return true;
            }
            return false;
        }
    }
}
