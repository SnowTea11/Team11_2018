#include "Enemy.h"

#include"Renderer/Renderer.h"
#include"Collision/Collision2D/Box/Box.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"

Enemy::Enemy(IWorld * world, const Vector2 & position)
	: Actor2D(world,"Enemy",position,std::make_shared<Box>(Vector2::Zero,Vector2(48.0f,48.0f)))
{
}

Enemy::~Enemy()
{
}

void Enemy::OnInitialize()
{
	isDead = false;
}

void Enemy::OnUpdate(float deltaTime)
{
	if (isDead = true) OnFinalize();
}

void Enemy::OnDraw(Renderer & renderer)
{
	renderer.DrawTexture(Assets::Texture::Enemy, position);

}

void Enemy::OnFinalize()
{
}

void Enemy::OnMessage(EventMessage message, void * param)
{
}

void Enemy::OnCollide(const HitInfo & hitInfo)
{
	//isDead = true;
	ReSpawn();
	int score = 1;
	world->SendEventMessage(EventMessage::AddScore, &score);
}


void Enemy::ReSpawn()
{
	position = Vector2(Random::Rangef(0.0f, Window::width - 64.0f), Random::Rangef(0.0f, Window::height - 64.0f));
}
