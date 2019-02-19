#pragma once

#include"Actor/Base/Actor2D.h"

class Block : public Actor2D {
public:
	Block(IWorld* world, const Vector2& position);
	~Block();
private:
	virtual void OnInitialize() override;
	virtual void OnUpdate(float deltaTime)override;
	virtual void OnDraw(Renderer& renderer)override;
	virtual void OnFinalize()override;
	virtual void OnMessage(EventMessage message, void* param)override;
	virtual void OnCollide(const HitInfo& hitInfo)override;
private:
	void ReSpawn();
	bool isDead;

};