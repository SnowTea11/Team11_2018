#include "Stage3.h"
#include "Scenes/Base/Scene.h"


#include"World/World.h"
#include"Actor/Base/ActorGroup.h"
#include"Renderer/Renderer.h"
#include"Actor/Base/EventMessage.h"
#include"Actor/Player/Player.h"
#include"Actor/Enemy/Enemy.h"
#include"Actor/Block/Block.h"
#include"Utility/Random/Random.h"
#include"Application/Window/Window.h"
#include"Actor/UI/Score/Score.h"
#include"Actor/UI/TimerUI/TimerUI.h"
#include"Input/Input.h"

Stage3::Stage3(WorldPtr& world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Stage3::~Stage3()
{
}

void Stage3::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::Background, "gameplay.png");
	renderer.LoadTexture(Assets::Texture::Number, "number.png");

	renderer.LoadTexture(Assets::Texture::Player, "player.png");
	renderer.LoadTexture(Assets::Texture::Player_Right, "player_right.png");
	renderer.LoadTexture(Assets::Texture::Enemy, "enemy.png");

	renderer.LoadTexture(Assets::Texture::Boomerang, "boomerang.png");

	renderer.LoadTexture(Assets::Texture::Block, "block.png");
	renderer.LoadTexture(Assets::Texture::Bumper, "bumper.png");
	renderer.LoadTexture(Assets::Texture::Form, "form.png");
	renderer.LoadTexture(Assets::Texture::AirFlow, "air_flow.png");
}

void Stage3::Initialize()
{
	world->GetSceneShareValue().Initialize();
	world->Initialize();


	world->AddActor_Back(ActorGroup::Player, std::make_shared<Player>(world.get(), Vector2(600, 696)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(600, 408)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(360, 408)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(120, 408)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(360, 264)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(456, 264)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(984, 360)));

	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(744, 264)));

	world->AddActor_Back(ActorGroup::UI, std::make_shared<Score>(world.get()));
	world->AddActor_Back(ActorGroup::UI, std::make_shared<TimerUI>(world.get(), 1 * 60));

	world->AddActor_Back(ActorGroup::Enemy, std::make_shared<Enemy>(world.get(), Vector2(1080, 216)));

	isEnd = false;

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param)
	{
		HandleMessage(message, param);
	});
}

void Stage3::Update(float deltaTime)
{
	Input::GetInstance().Update();
	world->Update(deltaTime);

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_NUMPADENTER))
	{
		isEnd = true;
	}
}

void Stage3::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Background);
	world->Draw(renderer);
}

bool Stage3::IsEnd() const
{
	return isEnd;
}

Scene Stage3::Next() const
{
	return Scene::Result3;//リザルト画面へ
}

void Stage3::Finalize() {
	world->Finalize();
	renderer.Clear();
}

void Stage3::HandleMessage(EventMessage message, void * param)
{
	if (message == EventMessage::GameEnd)
	{
		isEnd = true;
	}
}