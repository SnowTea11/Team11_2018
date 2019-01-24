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
	Vector2 origin;
	Vector2 nextPosition;
	float rotateHeight;
	double radian;
	bool hide;
	float kaiten;
	float cos, bCos;
	float sin, bSin;
	bool NotSin;
	float count;
};