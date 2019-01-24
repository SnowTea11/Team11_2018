#include "Bullet.h"

#include "Actor/Player/Player.h"
#include"Renderer/Renderer.h"
#include"Collision/Collision2D/Circle/Circle.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"

Bullet::Bullet(IWorld * world, const Vector2 & position)
	: Actor2D(world, "Bullet", position, std::make_shared<Circle>(Vector2::Zero, 8.0f))
{
}

Bullet::~Bullet()
{
}

void Bullet::OnInitialize()
{
	NotSin = false;
	count = 60;

	origin = position;
	rotateHeight = 96.0f;
	kaiten = 0;
	radian = 2.0f;
	hide = false;
}

void Bullet::OnUpdate(float deltaTime)
{
	//�O�̃t���[����Cos��Sin
	bCos = cos;
	bSin = sin;

	//�~�ړ�
	//�e�̂w���W = ��]���̂w���W + cos(��]������̊p�x) * ��]������̋���
	cos = (float)Math::Cos(radian);
	//�e�̂x���W = ��]���̂x���W + sin(��]������̊p�x) * ��]������̋���                                                                                                         
	sin = (float)Math::Sin(radian);

	//��]������̊p�x
	radian += ((float)Math::PI / 180);

	//X�̈ړ�
	position.x = origin.x + -cos * rotateHeight;

	//Y�̈ړ�
	if (NotSin)
	{

		position.y = origin.y + -sin * rotateHeight;
	}
	else
	{
		position.y = origin.y + sin * rotateHeight;
	}
	//�u�[�������̉�]���x
	kaiten -= 3.0f;

	//�v���C���[�̌��݈ʒu
	nextPosition = position;

	//�������߂̂�����������p�̃t���O(�݂���悤�ɂ���)
	hide = true;
}

void Bullet::OnDraw(Renderer & renderer)
{
	renderer.DrawTexture(Assets::Texture::Boomerang, position, Vector2(24, 24), Vector2(1, 1), kaiten, Color::White);

}

void Bullet::OnFinalize()
{
}

void Bullet::OnMessage(EventMessage message, void * param)
{
}

void Bullet::OnCollide(const HitInfo & hitInfo)
{
	if (!hide) return;

	float distanse = (float)Math::SquareRoot((nextPosition.x - origin.x) * (nextPosition.x - origin.x)
		+ (nextPosition.y - origin.y) * (nextPosition.y - origin.y));

}

void Bullet::ReSpawn()
{
	position = Vector2(Random::Rangef(0.0f, Window::width - 16.0f), Random::Rangef(0.0f, Window::height - 16.0f));
}
