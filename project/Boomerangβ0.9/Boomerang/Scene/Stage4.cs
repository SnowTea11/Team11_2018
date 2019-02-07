using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Boomerang
{
    class Stage4 : IScene
    {
        private SceneType nextScene;
        private GameManager gameManager;
        //使用する分だけ用意
        private Renderer renderer;
        private InputState inputState;
        private Sound sound;

        public int state;
        public int rank;

        private bool isEnd;//シーン終了フラグ

        private CharacterManager characterManager;

        Vector2 a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25,
               b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21, b22, b23, b24, b25,
               c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25,
               d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25,
               e1, e2, e3, e4, e5, e6, e7, e8, e9, e10, e11, e12, e13, e14, e15, e16, e17, e18, e19, e20, e21, e22, e23, e24, e25,
               f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15, f16, f17, f18, f19, f20, f21, f22, f23, f24, f25,
               g1, g2, g3, g4, g5, g6, g7, g8, g9, g10, g11, g12, g13, g14, g15, g16, g17, g18, g19, g20, g21, g22, g23, g24, g25,
               h1, h2, h3, h4, h5, h6, h7, h8, h9, h10, h11, h12, h13, h14, h15, h16, h17, h18, h19, h20, h21, h22, h23, h24, h25,
               i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11, i12, i13, i14, i15, i16, i17, i18, i19, i20, i21, i22, i23, i24, i25,
               j1, j2, j3, j4, j5, j6, j7, j8, j9, j10, j11, j12, j13, j14, j15, j16, j17, j18, j19, j20, j21, j22, j23, j24, j25,
               k1, k2, k3, k4, k5, k6, k7, k8, k9, k10, k11, k12, k13, k14, k15, k16, k17, k18, k19, k20, k21, k22, k23, k24, k25,
               l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l23, l24, l25,
               m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16, m17, m18, m19, m20, m21, m22, m23, m24, m25,
               n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, n15, n16, n17, n18, n19, n20, n21, n22, n23, n24, n25;
        public Stage4(GameManager gameManager)
        {
            this.gameManager = gameManager;
            inputState = gameManager.GetInputState();
            sound = gameManager.GetSound();
            renderer = gameManager.GetRenderer();
            state = gameManager.GetStage();
            rank = gameManager.GetRank();
        }
        public void Initialize()
        {
            isEnd = false;

            gameManager.SetScore(0);
            //敵の数
            gameManager.SetEcounter(2);
            //ブーメランの数
            gameManager.SetBcounter(3);
            state = 4;
            rank = 0;
            MapPositionInitialize();

            characterManager = new CharacterManager(gameManager);
            characterManager.AddCharacter(new Player(new Vector2(600, 696), gameManager, characterManager));

            characterManager.AddCharacter(new Block(f13, gameManager, characterManager));
            characterManager.AddCharacter(new Block(i10, gameManager, characterManager));
            characterManager.AddCharacter(new Block(i19, gameManager, characterManager));

            characterManager.AddCharacter(new Bumper(m6, gameManager, characterManager));

            characterManager.AddCharacter(new LowRepelling(l7, gameManager, characterManager));

            characterManager.AddCharacter(new Enemy(j3, gameManager, characterManager));
            characterManager.AddCharacter(new Enemy(f19, gameManager, characterManager));
        }
        public void Update()
        {
            sound.PlayBGM("gameplayBGM");


            gameManager.SetStage(state);

            characterManager.Update();

            if (!gameManager.GetPitch())
            {
                if (gameManager.GetBcounter() == 0 && gameManager.GetEcounter() == 0)//RankA
                {
                    gameManager.SetRank(2);
                    isEnd = true;
                }
                else if (gameManager.GetBcounter() > 0 && gameManager.GetEcounter() == 0)//RankS
                {
                    gameManager.SetRank(3);
                    isEnd = true;
                }
                else if (gameManager.GetBcounter() == 0 && gameManager.GetEcounter() == 2)//RankC
                {
                    gameManager.SetRank(0);
                    isEnd = true;
                }
                else if (gameManager.GetBcounter() == 0 && gameManager.GetEcounter() == 1)//RankB
                {
                    gameManager.SetRank(1);
                    isEnd = true;
                }
            }
        }
        public void Draw()
        {
            renderer.DrawTexture("gameplay", Vector2.Zero);

            characterManager.Draw();

            // ブーメランの回数表示
            if (gameManager.GetBcounter() >= 1)
            {
                renderer.DrawTexture("boomerang", new Vector2(450, 10));

                if (gameManager.GetBcounter() >= 2)
                {
                    renderer.DrawTexture("boomerang", new Vector2(500, 10));

                    if (gameManager.GetBcounter() == 3)
                    {
                        renderer.DrawTexture("boomerang", new Vector2(550, 10));
                    }
                }
            }
            //スコア、ハイスコアの表示
            // ScoreDraw("score", new Vector2(50, 10), gameManager.GetScore());
            // ScoreDraw("hiscore", new Vector2(450, 10), gameManager.GetHiScore());
        }
        private void ScoreDraw(string name, Vector2 position, int point)
        {//このメソッドはGamePlay内でしか使用しない。
            //renderer.DrawTexture(name, position);    //表示位置を変更可能
            //renderer.DrawNumber("number", position + new Vector2(200, 3), point);
        }
        public void MapPositionInitialize()
        {
            a1 = new Vector2(24, 24);
            a2 = new Vector2(72, 24);
            a3 = new Vector2(120, 24);
            a4 = new Vector2(168, 24);
            a5 = new Vector2(216, 24);
            a6 = new Vector2(264, 24);
            a7 = new Vector2(312, 24);
            a8 = new Vector2(360, 24);
            a9 = new Vector2(408, 24);
            a10 = new Vector2(456, 24);
            a11 = new Vector2(504, 24);
            a12 = new Vector2(552, 24);
            a13 = new Vector2(600, 24);
            a14 = new Vector2(648, 24);
            a15 = new Vector2(696, 24);
            a16 = new Vector2(744, 24);
            a17 = new Vector2(792, 24);
            a18 = new Vector2(840, 24);
            a19 = new Vector2(888, 24);
            a20 = new Vector2(936, 24);
            a21 = new Vector2(984, 24);
            a22 = new Vector2(1032, 24);
            a23 = new Vector2(1080, 24);
            a24 = new Vector2(1128, 24);
            a25 = new Vector2(1176, 24);
            b1 = new Vector2(24, 72);
            b2 = new Vector2(72, 72);
            b3 = new Vector2(120, 72);
            b4 = new Vector2(168, 72);
            b5 = new Vector2(216, 72);
            b6 = new Vector2(264, 72);
            b7 = new Vector2(312, 72);
            b8 = new Vector2(360, 72);
            b9 = new Vector2(408, 72);
            b10 = new Vector2(456, 72);
            b11 = new Vector2(504, 72);
            b12 = new Vector2(552, 72);
            b13 = new Vector2(600, 72);
            b14 = new Vector2(648, 72);
            b15 = new Vector2(696, 72);
            b16 = new Vector2(744, 72);
            b17 = new Vector2(792, 72);
            b18 = new Vector2(840, 72);
            b19 = new Vector2(888, 72);
            b20 = new Vector2(936, 72);
            b21 = new Vector2(984, 72);
            b22 = new Vector2(1032, 72);
            b23 = new Vector2(1080, 72);
            b24 = new Vector2(1128, 72);
            b25 = new Vector2(1176, 72);
            c1 = new Vector2(24, 120);
            c2 = new Vector2(72, 120);
            c3 = new Vector2(120, 120);
            c4 = new Vector2(168, 120);
            c5 = new Vector2(216, 120);
            c6 = new Vector2(264, 120);
            c7 = new Vector2(312, 120);
            c8 = new Vector2(360, 120);
            c9 = new Vector2(408, 120);
            c10 = new Vector2(456, 120);
            c11 = new Vector2(504, 120);
            c12 = new Vector2(552, 120);
            c13 = new Vector2(600, 120);
            c14 = new Vector2(648, 120);
            c15 = new Vector2(696, 120);
            c16 = new Vector2(744, 120);
            c17 = new Vector2(792, 120);
            c18 = new Vector2(840, 120);
            c19 = new Vector2(888, 120);
            c20 = new Vector2(936, 120);
            c21 = new Vector2(984, 120);
            c22 = new Vector2(1032, 120);
            c23 = new Vector2(1080, 120);
            c24 = new Vector2(1128, 120);
            c25 = new Vector2(1176, 120);
            d1 = new Vector2(24, 168);
            d2 = new Vector2(72, 168);
            d3 = new Vector2(120, 168);
            d4 = new Vector2(168, 168);
            d5 = new Vector2(216, 168);
            d6 = new Vector2(264, 168);
            d7 = new Vector2(312, 168);
            d8 = new Vector2(360, 168);
            d9 = new Vector2(408, 168);
            d10 = new Vector2(456, 168);
            d11 = new Vector2(504, 168);
            d12 = new Vector2(552, 168);
            d13 = new Vector2(600, 168);
            d14 = new Vector2(648, 168);
            d15 = new Vector2(696, 168);
            d16 = new Vector2(744, 168);
            d17 = new Vector2(792, 168);
            d18 = new Vector2(840, 168);
            d19 = new Vector2(888, 168);
            d20 = new Vector2(936, 168);
            d21 = new Vector2(984, 168);
            d22 = new Vector2(1032, 168);
            d23 = new Vector2(1080, 168);
            d24 = new Vector2(1128, 168);
            d25 = new Vector2(1176, 168);
            e1 = new Vector2(24, 216);
            e2 = new Vector2(72, 216);
            e3 = new Vector2(120, 216);
            e4 = new Vector2(168, 216);
            e5 = new Vector2(216, 216);
            e6 = new Vector2(264, 216);
            e7 = new Vector2(312, 216);
            e8 = new Vector2(360, 216);
            e9 = new Vector2(408, 216);
            e10 = new Vector2(456, 216);
            e11 = new Vector2(504, 216);
            e12 = new Vector2(552, 216);
            e13 = new Vector2(600, 216);
            e14 = new Vector2(648, 216);
            e15 = new Vector2(696, 216);
            e16 = new Vector2(744, 216);
            e17 = new Vector2(792, 216);
            e18 = new Vector2(840, 216);
            e19 = new Vector2(888, 216);
            e20 = new Vector2(936, 216);
            e21 = new Vector2(984, 216);
            e22 = new Vector2(1032, 216);
            e23 = new Vector2(1080, 216);
            e24 = new Vector2(1128, 216);
            e25 = new Vector2(1176, 216);
            f1 = new Vector2(24, 264);
            f2 = new Vector2(72, 264);
            f3 = new Vector2(120, 264);
            f4 = new Vector2(168, 264);
            f5 = new Vector2(216, 264);
            f6 = new Vector2(264, 264);
            f7 = new Vector2(312, 264);
            f8 = new Vector2(360, 264);
            f9 = new Vector2(408, 264);
            f10 = new Vector2(456, 264);
            f11 = new Vector2(504, 264);
            f12 = new Vector2(552, 264);
            f13 = new Vector2(600, 264);
            f14 = new Vector2(648, 264);
            f15 = new Vector2(696, 264);
            f16 = new Vector2(744, 264);
            f17 = new Vector2(792, 264);
            f18 = new Vector2(840, 264);
            f19 = new Vector2(888, 264);
            f20 = new Vector2(936, 264);
            f21 = new Vector2(984, 264);
            f22 = new Vector2(1032, 264);
            f23 = new Vector2(1080, 264);
            f24 = new Vector2(1128, 264);
            f25 = new Vector2(1176, 264);
            g1 = new Vector2(24, 312);
            g2 = new Vector2(72, 312);
            g3 = new Vector2(120, 312);
            g4 = new Vector2(168, 312);
            g5 = new Vector2(216, 312);
            g6 = new Vector2(264, 312);
            g7 = new Vector2(312, 312);
            g8 = new Vector2(360, 312);
            g9 = new Vector2(408, 312);
            g10 = new Vector2(456, 312);
            g11 = new Vector2(504, 312);
            g12 = new Vector2(552, 312);
            g13 = new Vector2(600, 312);
            g14 = new Vector2(648, 312);
            g15 = new Vector2(696, 312);
            g16 = new Vector2(744, 312);
            g17 = new Vector2(792, 312);
            g18 = new Vector2(840, 312);
            g19 = new Vector2(888, 312);
            g20 = new Vector2(936, 312);
            g21 = new Vector2(984, 312);
            g22 = new Vector2(1032, 312);
            g23 = new Vector2(1080, 312);
            g24 = new Vector2(1128, 312);
            g25 = new Vector2(1176, 312);
            h1 = new Vector2(24, 360);
            h2 = new Vector2(72, 360);
            h3 = new Vector2(120, 360);
            h4 = new Vector2(168, 360);
            h5 = new Vector2(216, 360);
            h6 = new Vector2(264, 360);
            h7 = new Vector2(312, 360);
            h8 = new Vector2(360, 360);
            h9 = new Vector2(408, 360);
            h10 = new Vector2(456, 360);
            h11 = new Vector2(504, 360);
            h12 = new Vector2(552, 360);
            h13 = new Vector2(600, 360);
            h14 = new Vector2(648, 360);
            h15 = new Vector2(696, 360);
            h16 = new Vector2(744, 360);
            h17 = new Vector2(792, 360);
            h18 = new Vector2(840, 360);
            h19 = new Vector2(888, 360);
            h20 = new Vector2(936, 360);
            h21 = new Vector2(984, 360);
            h22 = new Vector2(1032, 360);
            h23 = new Vector2(1080, 360);
            h24 = new Vector2(1128, 360);
            h25 = new Vector2(1176, 360);
            i1 = new Vector2(24, 408);
            i2 = new Vector2(72, 408);
            i3 = new Vector2(120, 408);
            i4 = new Vector2(168, 408);
            i5 = new Vector2(216, 408);
            i6 = new Vector2(264, 408);
            i7 = new Vector2(312, 408);
            i8 = new Vector2(360, 408);
            i9 = new Vector2(408, 408);
            i10 = new Vector2(456, 408);
            i11 = new Vector2(504, 408);
            i12 = new Vector2(552, 408);
            i13 = new Vector2(600, 408);
            i14 = new Vector2(648, 408);
            i15 = new Vector2(696, 408);
            i16 = new Vector2(744, 408);
            i17 = new Vector2(792, 408);
            i18 = new Vector2(840, 408);
            i19 = new Vector2(888, 408);
            i20 = new Vector2(936, 408);
            i21 = new Vector2(984, 408);
            i22 = new Vector2(1032, 408);
            i23 = new Vector2(1080, 408);
            i24 = new Vector2(1128, 408);
            i25 = new Vector2(1176, 408);
            j1 = new Vector2(24, 456);
            j2 = new Vector2(72, 456);
            j3 = new Vector2(120, 456);
            j4 = new Vector2(168, 456);
            j5 = new Vector2(216, 456);
            j6 = new Vector2(264, 456);
            j7 = new Vector2(312, 456);
            j8 = new Vector2(360, 456);
            j9 = new Vector2(408, 456);
            j10 = new Vector2(456, 456);
            j11 = new Vector2(504, 456);
            j12 = new Vector2(552, 456);
            j13 = new Vector2(600, 456);
            j14 = new Vector2(648, 456);
            j15 = new Vector2(696, 456);
            j16 = new Vector2(744, 456);
            j17 = new Vector2(792, 456);
            j18 = new Vector2(840, 456);
            j19 = new Vector2(888, 456);
            j20 = new Vector2(936, 456);
            j21 = new Vector2(984, 456);
            j22 = new Vector2(1032, 456);
            j23 = new Vector2(1080, 456);
            j24 = new Vector2(1128, 456);
            j25 = new Vector2(1176, 456);
            k1 = new Vector2(24, 504);
            k2 = new Vector2(72, 504);
            k3 = new Vector2(120, 504);
            k4 = new Vector2(168, 504);
            k5 = new Vector2(216, 504);
            k6 = new Vector2(264, 504);
            k7 = new Vector2(312, 504);
            k8 = new Vector2(360, 504);
            k9 = new Vector2(408, 504);
            k10 = new Vector2(456, 504);
            k11 = new Vector2(504, 504);
            k12 = new Vector2(552, 504);
            k13 = new Vector2(600, 504);
            k14 = new Vector2(648, 504);
            k15 = new Vector2(696, 504);
            k16 = new Vector2(744, 504);
            k17 = new Vector2(792, 504);
            k18 = new Vector2(840, 504);
            k19 = new Vector2(888, 504);
            k20 = new Vector2(936, 504);
            k21 = new Vector2(984, 504);
            k22 = new Vector2(1032, 504);
            k23 = new Vector2(1080, 504);
            k24 = new Vector2(1128, 504);
            k25 = new Vector2(1176, 504);
            l1 = new Vector2(24, 552);
            l2 = new Vector2(72, 552);
            l3 = new Vector2(120, 552);
            l4 = new Vector2(168, 552);
            l5 = new Vector2(216, 552);
            l6 = new Vector2(264, 552);
            l7 = new Vector2(312, 552);
            l8 = new Vector2(360, 552);
            l9 = new Vector2(408, 552);
            l10 = new Vector2(456, 552);
            l11 = new Vector2(504, 552);
            l12 = new Vector2(552, 552);
            l13 = new Vector2(600, 552);
            l14 = new Vector2(648, 552);
            l15 = new Vector2(696, 552);
            l16 = new Vector2(744, 552);
            l17 = new Vector2(792, 552);
            l18 = new Vector2(840, 552);
            l19 = new Vector2(888, 552);
            l20 = new Vector2(936, 552);
            l21 = new Vector2(984, 552);
            l22 = new Vector2(1032, 552);
            l23 = new Vector2(1080, 552);
            l24 = new Vector2(1128, 552);
            l25 = new Vector2(1176, 552);
            m1 = new Vector2(24, 600);
            m2 = new Vector2(72, 600);
            m3 = new Vector2(120, 600);
            m4 = new Vector2(168, 600);
            m5 = new Vector2(216, 600);
            m6 = new Vector2(264, 600);
            m7 = new Vector2(312, 600);
            m8 = new Vector2(360, 600);
            m9 = new Vector2(408, 600);
            m10 = new Vector2(456, 600);
            m11 = new Vector2(504, 600);
            m12 = new Vector2(552, 600);
            m13 = new Vector2(600, 600);
            m14 = new Vector2(648, 600);
            m15 = new Vector2(696, 600);
            m16 = new Vector2(744, 600);
            m17 = new Vector2(792, 600);
            m18 = new Vector2(840, 600);
            m19 = new Vector2(888, 600);
            m20 = new Vector2(936, 600);
            m21 = new Vector2(984, 600);
            m22 = new Vector2(1032, 600);
            m23 = new Vector2(1080, 600);
            m24 = new Vector2(1128, 600);
            m25 = new Vector2(1176, 600);
            n1 = new Vector2(24, 648);
            n2 = new Vector2(72, 648);
            n3 = new Vector2(120, 648);
            n4 = new Vector2(168, 648);
            n5 = new Vector2(216, 648);
            n6 = new Vector2(264, 648);
            n7 = new Vector2(312, 648);
            n8 = new Vector2(360, 648);
            n9 = new Vector2(408, 648);
            n10 = new Vector2(456, 648);
            n11 = new Vector2(504, 648);
            n12 = new Vector2(552, 648);
            n13 = new Vector2(600, 648);
            n14 = new Vector2(648, 648);
            n15 = new Vector2(696, 648);
            n16 = new Vector2(744, 648);
            n17 = new Vector2(792, 648);
            n18 = new Vector2(840, 648);
            n19 = new Vector2(888, 648);
            n20 = new Vector2(936, 648);
            n21 = new Vector2(984, 648);
            n22 = new Vector2(1032, 648);
            n23 = new Vector2(1080, 648);
            n24 = new Vector2(1128, 648);
            n25 = new Vector2(1176, 648);
        }
        public void Shutdown()
        {
            sound.StopBGM();

            gameManager.SetHiScore(gameManager.GetScore());
            gameManager.SetStage(4);
        }
        public bool IsEnd()
        {
            return this.isEnd;
        }
        public SceneType Next()
        {
            return SceneType.Result;//ゲームオーバーへ
        }
    }
}
