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
	// ��]��
	Vector2 origin;
	// �v���C���[�̌��݈ʒu�̎擾(Hit���p)
	Vector2 nextPosition;
	// ��]������̋���
	float rotateHeight;
	// ��]������̊p�x
	double radian;
	// �����n�߂̂�����������p�̃t���O
	bool hide;
	// ��]���x
	float spin;

	// �R�T�C���A1�t���[���O�̃R�T�C��
	float cos, bCos;
	// �T�C���A1�t���[���O�̃T�C��
	float sin, bSin;

	// �C���p��sin���]�p�t���O
	bool NotSin;

	float count;
};