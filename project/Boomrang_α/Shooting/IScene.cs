using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
    //シーンの種類を列挙
    public enum SceneType
    {
        GameTitle,
        GamePlay,
        GameOver
    }
    interface IScene
    {
        void Initialize();//準備
        void Update();//ルール
        void Draw();//表示
        void Shutdown();//終了
        //シーン管理用
        bool IsEnd();//シーン終了チェック
        SceneType Next();//次のシーン取得
    }
}
