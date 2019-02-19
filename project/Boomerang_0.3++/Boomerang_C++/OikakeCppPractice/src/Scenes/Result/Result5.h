#pragma once

#include "Scenes/Base/IScene.h"
#include"World/IWorld.h"
#include"World/WorldPtr.h"

class Renderer;
enum class EventMessage;
enum class Scene;

/*! @class GameMainScene
*   @brief  ゲームメインシーン
*/
class Result5 : public IScene {
public:
	/**
	* @brief コンストラクタ
	* @param world ワールドポインタ
	*/
	explicit Result5(WorldPtr& world);
	/**
	* @brief デストラクタ
	*/
	virtual ~Result5();
	/**
	* @brief アセットを読み込む
	*/
	virtual void LoadAssets() override;
	/**
	* @brief 初期化
	*/
	virtual void Initialize() override;
	/**
	* @brief 更新
	* @param deltaTime １秒
	*/
	virtual void Update(float deltaTime)override;
	/**
	* @brief 描画
	*/
	virtual void Draw() const override;
	/**
	* @brief シーンが終了か判定
	* @return [true 終了] : [false まだ終了していない]
	*/
	virtual bool IsEnd() const override;
	/**
	* @brief 次に移動するシーンを取得
	* @return 次に移動するシーン
	*/
	virtual Scene Next()const override;
	/**
	* @brief 終了
	*/
	virtual void Finalize() override;


private:
	/**
	* @brief イベントメッセージを受け取る
	* @param message 登録したイベントメッセージ
	* @param param イベントと一緒に送る変数
	*/
	void HandleMessage(EventMessage message, void* param);

private:
	//!ワールドポインタ
	WorldPtr world;
	//!描画クラス
	Renderer& renderer;
	//!シーンが終了したか判定用
	bool isEnd;

	Scene nextScene;

	int CursorPosition;//カーソルの場所
};
