#include "Bullet.h"

#include "Actor/Player/Player.h"
#include"Renderer/Renderer.h"
#include"Collision/Collision2D/Circle/Circle.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"

Bullet::Bullet(IWorld * world, const Vector2 & position)
	: Actor2D(world, "boomerang", position, std::make_shared<Circle>(Vector2::Zero, 24.0f))
{
}

Bullet::~Bullet()
{
}

void Bullet::OnInitialize()
{
	NotSin = false;
	count = 60;

	origin = position;		// ‰ŠúˆÊ’u‚ğ‰ñ“]²‚É‚·‚é
	rotateHeight = 96.0f;	// ‰ñ“]²‚©‚ç‚Ì‹——£
	spin = 0;				// ‰ñ“]‘¬“x
	radian = 2.0f;			// ‰ñ“]²‚©‚ç‚ÌŠp“x
	hide = false;			// •`‰æ‚·‚é‚©‚Ç‚¤‚©‚Ìƒtƒ‰ƒO
}

void Bullet::OnUpdate(float deltaTime)
{
	//‘O‚ÌƒtƒŒ[ƒ€‚ÌCos‚ÆSin
	bCos = cos;
	bSin = sin;

	//‰~ˆÚ“®
	//’e‚Ì‚wÀ•W = ‰ñ“]²‚Ì‚wÀ•W + cos(‰ñ“]²‚©‚ç‚ÌŠp“x) * ‰ñ“]²‚©‚ç‚Ì‹——£
	cos = (float)Math::Cos(radian);
	//’e‚Ì‚xÀ•W = ‰ñ“]²‚Ì‚xÀ•W + sin(‰ñ“]²‚©‚ç‚ÌŠp“x) * ‰ñ“]²‚©‚ç‚Ì‹——£                                                                                                         
	sin = (float)Math::Sin(radian);

	//‰ñ“]²‚©‚ç‚ÌŠp“x
	radian += ((float)Math::PI / 180);

	//X‚ÌˆÚ“®
	position.x = origin.x + cos * rotateHeight * deltaTime;

	//Y‚ÌˆÚ“®
	if (NotSin)
	{
		position.y = origin.y + -sin * rotateHeight * deltaTime;
	}
	else
	{
		position.y = origin.y + sin * rotateHeight * deltaTime;
	}
	//ƒu[ƒƒ‰ƒ“‚Ì‰ñ“]‘¬“x
	spin -= 3.0f;

	//ƒvƒŒƒCƒ„[‚ÌŒ»İˆÊ’u
	nextPosition = position;

	//“Š‚°‰‚ß‚Ì‚¿‚ç‚Â‚«‚ğÁ‚·—p‚Ìƒtƒ‰ƒO(‚İ‚¦‚é‚æ‚¤‚É‚·‚é)
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

	float distanse = (float)Math::SquareRoot((nextPosition.x - origin.x) * (nextPosition.x - origin.x)
		+ (nextPosition.y - origin.y) * (nextPosition.y - origin.y));



}

void Bullet::ReSpawn()
{
	position = Vector2(Random::Rangef(0.0f, Window::width - 16.0f), Random::Rangef(0.0f, Window::height - 16.0f));
}
