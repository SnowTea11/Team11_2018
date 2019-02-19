#include "Bullet.h"

#include "Actor/Player/Player.h"
#include"Renderer/Renderer.h"
#include"Collision/Collision2D/Box/Box.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"

Bullet::Bullet(IWorld * world, const Vector2 & position)
	: Actor2D(world, "boomerang", position, std::make_shared<Box>(Vector2::Zero, Vector2(48.0f, 48.0f)))
{
}

Bullet::~Bullet()
{
}

void Bullet::OnInitialize()
{
	NotSin = false;
	count = 60;

	origin = position + Vector2(24,24);		// ‰ŠúˆÊ’u‚ð‰ñ“]Ž²‚É‚·‚é
	rotateHeight = 144.0f;	// ‰ñ“]Ž²‚©‚ç‚Ì‹——£
	spin = 90;				// ‰ñ“]‘¬“x
	radian = 270.0f;			// ‰ñ“]Ž²‚©‚ç‚ÌŠp“x
	hide = false;			// •`‰æ‚·‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
}

void Bullet::OnUpdate(float deltaTime)
{
	//‘O‚ÌƒtƒŒ[ƒ€‚ÌCos‚ÆSin
	bCos = cos;
	bSin = sin;

	//‰~ˆÚ“®
	//’e‚Ì‚wÀ•W = ‰ñ“]Ž²‚Ì‚wÀ•W + cos(‰ñ“]Ž²‚©‚ç‚ÌŠp“x) * ‰ñ“]Ž²‚©‚ç‚Ì‹——£
	cos = (float)Math::Cos(radian);
	//’e‚Ì‚xÀ•W = ‰ñ“]Ž²‚Ì‚xÀ•W + sin(‰ñ“]Ž²‚©‚ç‚ÌŠp“x) * ‰ñ“]Ž²‚©‚ç‚Ì‹——£                                                                                                         
	sin = (float)Math::Sin(radian);

	//‰ñ“]Ž²‚©‚ç‚ÌŠp“x
	radian += ((float)Math::PI / 180) * 90;

	//X‚ÌˆÚ“®
	position.x = origin.x + cos * rotateHeight;

	//Y‚ÌˆÚ“®
	if (!NotSin)
	{
		position.y = origin.y + -sin * rotateHeight;
	}
	else
	{
		position.y = origin.y + sin * rotateHeight;
	}
	//ƒu[ƒƒ‰ƒ“‚Ì‰ñ“]‘¬“x
	spin -= 8.0f;

	//ƒvƒŒƒCƒ„[‚ÌŒ»ÝˆÊ’u
	nextPosition = position;

	//“Š‚°‰‚ß‚Ì‚¿‚ç‚Â‚«‚ðÁ‚·—p‚Ìƒtƒ‰ƒO(‚Ý‚¦‚é‚æ‚¤‚É‚·‚é)
	hide = true;
}

void Bullet::OnDraw(Renderer & renderer)
{
	renderer.DrawTexture(Assets::Texture::Boomerang, position, Vector2(24, 24), Vector2(1, 1), spin, Color::White);

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
	world->SendEventMessage(EventMessage::Hit);

	float distanse = (float)Math::SquareRoot((nextPosition.x - origin.x) * (nextPosition.x - origin.x)
		+ (nextPosition.y - origin.y) * (nextPosition.y - origin.y));


}

void Bullet::ReSpawn()
{
	position = Vector2(Random::Rangef(0.0f, Window::width - 16.0f), Random::Rangef(0.0f, Window::height - 16.0f));
}
