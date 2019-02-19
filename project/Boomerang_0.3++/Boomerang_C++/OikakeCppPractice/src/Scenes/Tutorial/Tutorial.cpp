#include "Tutorial.h"
#include"Renderer/Renderer.h"
#include "Scenes/Base/Scene.h"
#include"Input/Input.h"

#include"World/World.h"
#include"Actor/Base/ActorGroup.h"
#include"Actor/Base/EventMessage.h"
#include"Actor/Player/Player.h"
#include"Input/Input.h"

Tutorial::Tutorial(WorldPtr & world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Tutorial::~Tutorial()
{
}

void Tutorial::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::Tutorial, "Tutorial.png");
	renderer.LoadTexture(Assets::Texture::Player, "Tutorial.png");
}

void Tutorial::Initialize()
{
	shBGM = LoadSoundMem("asset/texture/titleBGM.mp3");
	shSE = LoadSoundMem("asset/texture/inputSE.wav");
	PlaySoundMem(shBGM, DX_PLAYTYPE_LOOP);

	world->GetSceneShareValue().Initialize();
	world->Initialize();

	world->AddActor_Back(ActorGroup::Player, std::make_shared<Player>(world.get(), Vector2::Zero));

	isEnd = false;

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param) {
		HandleMessage(message, param);
	});
}

void Tutorial::Update(float deltaTime)
{
	Input::GetInstance().Update();
	world->Update(deltaTime);

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE)) {
		PlaySoundMem(shSE, DX_PLAYTYPE_BACK);
		isEnd = true;
	}
}

void Tutorial::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Player);
	renderer.DrawTexture(Assets::Texture::Tutorial, Vector2(100, 100), Vector2(0, 0), Vector2(2, 2));
	renderer.DrawTexture(Assets::Texture::Tutorial, Vector2(200, 200), Vector2(0, 0), Vector2(3, 3));
	world->Draw(renderer);
}

bool Tutorial::IsEnd() const
{
	return isEnd;
}

Scene Tutorial::Next() const
{
	return Scene::StageSelect;
}

void Tutorial::Finalize()
{
	StopSoundMem(shBGM);
	world->Finalize();
	renderer.Clear();
}

void Tutorial::HandleMessage(EventMessage message, void * param)
{
}
