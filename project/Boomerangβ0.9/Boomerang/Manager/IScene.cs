using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boomerang
{
    public enum SceneType
    {
        Title,
        Tutorial,
        StageSelect,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Stage5,
        Result
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
