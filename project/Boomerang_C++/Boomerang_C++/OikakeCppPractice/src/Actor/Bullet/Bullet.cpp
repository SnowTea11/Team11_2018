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

	origin = position + Vector2(24,24);		// 初期位置を回転軸にする
	rotateHeight = 144.0f;	// 回転軸からの距離
	spin = 90;				// 回転速度
	radian = 270.0f;			// 回転軸からの角度
	hide = false;			// 描画するかどうかのフラグ
}

void Bullet::OnUpdate(float deltaTime)
{
	//前のフレームのCosとSin
	bCos = cos;
	bSin = sin;

	//円移動
	//弾のＸ座標 = 回転軸のＸ座標 + cos(回転軸からの角度) * 回転軸からの距離
	cos = (float)Math::Cos(radian);
	//弾のＹ座標 = 回転軸のＹ座標 + sin(回転軸からの角度) * 回転軸からの距離                                                                                                         
	sin = (float)Math::Sin(radian);

	//回転軸からの角度
	radian += ((float)Math::PI / 180) * 90;

	//Xの移動
	position.x = origin.x + cos * rotateHeight;

	//Yの移動
	if (!NotSin)
	{
		position.y = origin.y + -sin * rotateHeight;
	}
	else
	{
		position.y = origin.y + sin * rotateHeight;
	}
	//ブーメランの回転速度
	spin -= 8.0f;

	//プレイヤーの現在位置
	nextPosition = position;

	//投げ初めのちらつきを消す用のフラグ(みえるようにする)
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
