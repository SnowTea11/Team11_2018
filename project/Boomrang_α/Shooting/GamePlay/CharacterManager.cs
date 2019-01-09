using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Shooting
{
    class CharacterManager : ICharacterMediator
    {

        private List<Character> playerSide; //プレイヤーグループ
        private List<Character> enemySide;  //敵グループ
        private List<Character> neutralSide;    //中立グループ、どのグループとも当たらない
        private List<Character> addCharacters;  //追加するキャラクター

        private GameManager gameManager;

        public CharacterManager(GameManager gameManager)
        {
            this.gameManager = gameManager;
            Initialize();
        }
        public void Initialize()
        {
            if (playerSide != null)
            {
                playerSide.Clear();
            }
            else
            {
                playerSide = new List<Character>();
            }
            if (enemySide != null)
            {
                enemySide.Clear();
            }
            else
            {
                enemySide = new List<Character>();
            }
            if (neutralSide != null)
            {
                neutralSide.Clear();
            }
            else
            {
                neutralSide = new List<Character>();
            }
            if (addCharacters != null)
            {
                addCharacters.Clear();
            }
            else
            {
                addCharacters = new List<Character>();
            }
        }
        public void Add(Character character)
        {
            //キャラクターを分類して追加
            if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide)    
            {
                playerSide.Add(character);
            }
            else if ((int)character.GetCharacterID() / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide)
            {
                enemySide.Add(character);
            }
            else//当てはまらないキャラは中立に
            {
                neutralSide.Add(character);
            }
        }

        public void Update()
        {
            foreach (Character c in playerSide)
            {
                c.Update();
            }
            foreach (Character c in enemySide)
            {
                c.Update();
            }
            foreach (Character c in neutralSide)
            {
                c.Update();
            }
            //キャラクターを追加
            foreach (Character c in addCharacters)
            {
                Add(c);
            }
            addCharacters.Clear();
            //当たり判定
            Hit();
            //死亡フラグの立っているキャラを全て削除
            playerSide.RemoveAll(c => c.IsDead() == true);
            enemySide.RemoveAll(c => c.IsDead() == true);
            neutralSide.RemoveAll(c => c.IsDead() == true);
        }
        private void Hit()
        {
            //プレイヤーグループと敵グループのみ当たり判定を行う
            foreach (Character c1 in playerSide)
            {
                foreach (Character c2 in enemySide)
                {
                    if (c1.IsDead() || c2.IsDead())
                    {//キャラが死んでいたら次へ
                        continue;
                    }
                    if (c1.Collision(c2))
                    {//ヒットの通知
                        c1.Hit(c2);
                        c2.Hit(c1);
                    }
                }
            }
        }
        public void Draw()
        {
            foreach (Character c in playerSide)
            {
                c.Draw();
            }
            foreach (Character c in enemySide)
            {
                c.Draw();
            }
            foreach (Character c in neutralSide)
            {
                c.Draw();
            }
        }

        //ICharacterMediatorでの実装
        public void AddCharacter(Character character)
        {
            if (character == null) return;
            addCharacters.Add(character);
        }
        public bool IsCharacterDead(CharacterID characterID)
        {
            //キャラクターが見つからなければ死亡
            Character find = null;
            if ((int)characterID / (int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide)
            {
                find = playerSide.Find(c => c.GetCharacterID() == characterID);
            }
            else if ((int)characterID / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide)
            {
                find = enemySide.Find(c => c.GetCharacterID() == characterID);
            }
            if (find == null || find.IsDead())
            {
                return true;
            }
            return false;
        }
        public Vector2 GetCharacterPosition(CharacterID characterID)
        {
            Character find = null;
            if ((int)characterID / (int)CharacterID.CheckNumber == (int)CharacterID.PlayerSide)
            {
                find = playerSide.Find(c => c.GetCharacterID() == characterID);
            }
            else if ((int)characterID / (int)CharacterID.CheckNumber == (int)CharacterID.EnemySide)
            {
                find = enemySide.Find(c => c.GetCharacterID() == characterID);
            }
            if (find != null && !find.IsDead())
            {
                return find.GetPosition();
            }
            return new Vector2(float.MinValue, float.MinValue);//キャラクターがいないとき
        }
    }
}

