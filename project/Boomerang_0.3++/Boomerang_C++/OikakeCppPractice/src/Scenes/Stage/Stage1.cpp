#include "Stage1.h"
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

Stage1::Stage1(WorldPtr& world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Stage1::~Stage1()
{
}

void Stage1::LoadAssets()
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

void Stage1::Initialize()
{
	sh = LoadSoundMem("asset/texture/gameplayBGM.mp3");
	PlaySoundMem(sh, DX_PLAYTYPE_BACK);

	world->GetSceneShareValue().Initialize();
	world->Initialize();


	world->AddActor_Back(ActorGroup::Player, std::make_shared<Player>(world.get(), Vector2(600, 696)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(456, 408)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(600, 408)));
	world->AddActor_Back(ActorGroup::Block, std::make_shared<Block>(world.get(), Vector2(744, 408)));

	world->AddActor_Back(ActorGroup::UI, std::make_shared<Score>(world.get()));
	world->AddActor_Back(ActorGroup::UI, std::make_shared<TimerUI>(world.get(), 1 * 60));

	world->AddActor_Back(ActorGroup::Enemy, std::make_shared<Enemy>(world.get(), Vector2(456, 264)));
	world->AddActor_Back(ActorGroup::Enemy, std::make_shared<Enemy>(world.get(), Vector2(504, 600)));

	isEnd = false;

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param)
	{
		HandleMessage(message, param);
	});
}

void Stage1::Update(float deltaTime)
{
	Input::GetInstance().Update();
	world->Update(deltaTime);

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_NUMPADENTER))
	{
		isEnd = true;
	}
}

void Stage1::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Background);
	world->Draw(renderer);
}

bool Stage1::IsEnd() const
{
	return isEnd;
}

Scene Stage1::Next() const
{
	return Scene::Result;//リザルト画面へ
}

void Stage1::Finalize() {
	StopSoundMem(sh);

	world->Finalize();
	renderer.Clear();
}

void Stage1::HandleMessage(EventMessage message, void * param)
{ 
	
	if (message == EventMessage::GameEnd)
	{
		bScene = Scene::Stage1;
		isEnd = true;
	}
}
