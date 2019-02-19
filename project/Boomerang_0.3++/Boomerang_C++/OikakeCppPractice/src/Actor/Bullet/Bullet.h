#pragma once

#include"Actor/Base/Actor2D.h"

class Bullet : public Actor2D {
public:
	Bullet(IWorld* world, const Vector2& position);
	~Bullet();
private:
	virtual void OnInitialize() override;
	virtual void OnUpdate(float deltaTime)override;
	virtual void OnDraw(Renderer& renderer)override;
	virtual void OnFinalize()override;
	virtual void OnMessage(EventMessage message, void* param)override;
	virtual void OnCollide(const HitInfo& hitInfo)override;
private:
	void ReSpawn();
	// 回転軸
	Vector2 origin;
	// プレイヤーの現在位置の取得(Hit時用)
	Vector2 nextPosition;
	// 回転軸からの距離
	float rotateHeight;
	// 回転軸からの角度
	double radian;
	// 投げ始めのちらつきを消す用のフラグ
	bool hide;
	// 回転速度
	float spin;

	// コサイン、1フレーム前のコサイン
	float cos, bCos;
	// サイン、1フレーム前のサイン
	float sin, bSin;

	// 気流用のsin反転用フラグ
	bool NotSin;

	float count;
};