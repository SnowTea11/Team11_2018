#include "Block.h"

#include"Renderer/Renderer.h"
#include"Collision/Collision2D/Box/Box.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"

Block::Block(IWorld * world, const Vector2 & position)
	: Actor2D(world, "Block", position, std::make_shared<Box>(Vector2::Zero, Vector2(48.0f, 48.0f)))
{
}

Block::~Block()
{
}

void Block::OnInitialize()
{
	isDead = false;
}

void Block::OnUpdate(float deltaTime)
{
	if (isDead = true) OnFinalize();
}

void Block::OnDraw(Renderer & renderer)
{
	renderer.DrawTexture(Assets::Texture::Block, position);

}

void Block::OnFinalize()
{
}

void Block::OnMessage(EventMessage message, void * param)
{
}

void Block::OnCollide(const HitInfo & hitInfo)
{
	//isDead = true;
	//ReSpawn();
	//int score = 1;
	//world->SendEventMessage(EventMessage::AddScore, &score);
}


void Block::ReSpawn()
{
	position = Vector2(Random::Rangef(0.0f, Window::width - 64.0f), Random::Rangef(0.0f, Window::height - 64.0f));
}
