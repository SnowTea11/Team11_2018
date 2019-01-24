#include "Player.h"
#include "Renderer/Renderer.h"
#include"Input/Input.h"
#include"Application/Window/Window.h"
#include"Collision/Collision2D/Box/Box.h"
#include"Actor/Bullet/Bullet.h"


Player::Player(IWorld * world, const Vector2 & position)
	: Actor2D(world,"player",position, std::make_shared<Box>(Vector2::Zero, Vector2(48.0f,48.0f)))
	, Speed(5.0f)
{
}

Player::~Player()
{
}

void Player::OnInitialize()
{
	// trueで左向き(デフォルト)、falseで右向き
	Direction = true;
}

void Player::OnUpdate(float deltaTime)
{
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE)) {
		world->AddActor_Back(ActorGroup::Boomerang, std::make_shared<Bullet>(world, position));
	}
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_LEFT)) Direction = true;
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_RIGHT)) Direction = false;

	position += Input::GetInstance().GetVelocity() * Speed * deltaTime;
	position.Clamp(Vector2::Zero, Vector2(Window::width - 48, Window::height - 48));
}

void Player::OnDraw(Renderer & renderer)
{
	if (Direction == true)	renderer.DrawTexture(Assets::Texture::Player, position);
	if (Direction == false)	renderer.DrawTexture(Assets::Texture::Player_Right, position);
}

void Player::OnFinalize()
{
}

void Player::OnMessage(EventMessage message, void * param)
{
}

void Player::OnCollide(const HitInfo & hitInfo)
{
	world->SendEventMessage(EventMessage::Hit);
}

void Player::OnBullet() {
}
