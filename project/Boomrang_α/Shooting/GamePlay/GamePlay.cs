using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Shooting
{
    class GamePlay : IScene
    {
        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;

        private bool isEnd;//シーン終了フラグ
        private int endCount;
        private bool bossFind;

        private CharacterManager characterManager;
        private EnemyGenerator enemyGenerator;
        public GamePlay(GameManager gameManager)
        {
            this.gameManager = gameManager;
            inputState = gameManager.GetInputState();
            sound = gameManager.GetSound();
            renderer = gameManager.GetRenderer();
        }
        public void Initialize()
        {
            isEnd = false;
            endCount = int.MinValue;
            bossFind = false;

            gameManager.SetScore(0);

            characterManager = new CharacterManager(gameManager);
            characterManager.AddCharacter(new Player(new Vector2(600, 600), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(600 , 408), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(792, 408), gameManager, characterManager));
            //characterManager.AddCharacter(new Enemy(new Vector2(600, 216), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(792, 216), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(886, 504), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(696, 504), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(696, 312), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(new Vector2(504, 312), gameManager, characterManager));
            //characterManager.AddCharacter(new Enemy(new Vector2(792, 168), gameManager, characterManager));
            //characterManager.AddCharacter(new Enemy2(new Vector2(886, 312), gameManager, characterManager));
            //characterManager.AddCharacter(new Enemy(new Vector2(744, 168), gameManager, characterManager));
            characterManager.AddCharacter(new Enemy3(new Vector2(600, 216), gameManager, characterManager));
            //characterManager.AddCharacter(new Enemy4(new Vector2(Screen.Width - 200, 300), gameManager, characterManager));
            //enemyGenerator = new EnemyGenerator("enemy.txt");
        }
        public void Update()
        {
            sound.PlayBGM("gameplaybgm");
            ////敵の発生
            //enemyGenerator.AddEnemys(gameManager, characterManager);

            characterManager.Update();

            //if (endCount < 0)
            //{
            //    if (characterManager.IsCharacterDead(CharacterID.Player))
            //    {
            //        endCount = 2 * 60;//2秒
            //    }
            //    if (!bossFind)
            //    {
            //        if (!characterManager.IsCharacterDead(CharacterID.EnemyBoss))
            //        {
            //            bossFind = true;
            //        }
            //    }
            //    else
            //    {
            //        if (characterManager.IsCharacterDead(CharacterID.EnemyBoss))
            //        {
            //            endCount = 2 * 60;//2秒
            //        }
            //    }
            //}
            //else if (endCount > 0)
            //{
            //    endCount--;
            //}
            //else if(endCount == 0)
            //{
            //    this.isEnd = true;
            //    sound.PlaySE("gameplayse");
            //}

            //gameManager.SetHiScore(gameManager.GetScore());
        }
        public void Draw()
        {
            //renderer.DrawTexture("gameplay", Vector2.Zero);

            characterManager.Draw();

            //スコア、ハイスコアの表示
            ScoreDraw("score", new Vector2(50, 10), gameManager.GetScore());
            ScoreDraw("hiscore", new Vector2(450, 10), gameManager.GetHiScore());
        }
        private void ScoreDraw(string name, Vector2 position, int point)
        {//このメソッドはGamePlay内でしか使用しない。
            renderer.DrawTexture(name, position);    //表示位置を変更可能
            renderer.DrawNumber("number", position + new Vector2(200, 3), point);
        }
        public void Shutdown()
        {
            sound.StopBGM();

            gameManager.SetHiScore(gameManager.GetScore());
        }
        public bool IsEnd()
        {
            return this.isEnd;
        }
        public SceneType Next()
        {
            return SceneType.GameOver;//ゲームオーバーへ
        }
    }
}
