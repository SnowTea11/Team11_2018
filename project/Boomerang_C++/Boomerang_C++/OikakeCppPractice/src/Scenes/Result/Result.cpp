#include "Result.h"
#include "Scenes/Base/Scene.h"
#include"Renderer/Renderer.h"
#include"Input/Input.h"
#include"Actor/UI/Score/Score.h"
#include"World/World.h"
#include "Scenes/Base/SceneManager.h"

Result::Result(WorldPtr & world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Result::~Result()
{
}

void Result::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::Result, "result.png");
	renderer.LoadTexture(Assets::Texture::Number, "number.png");

}

void Result::Initialize()
{
	CursorPosition = 120;

	isEnd = false;
	world->Initialize();
	world->AddActor_Back(ActorGroup::UI, std::make_shared<Score>(world.get()));
}

void Result::Update(float deltaTime)
{
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_RIGHT))
	{
		CursorPosition = 650;
	}
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_LEFT))
	{
		CursorPosition = 120;
	}

	if (CursorPosition = 120)
	{
		nextScene = Scene::Stage2;
	}
	if (CursorPosition == 650)
	{
		nextScene = Scene::StageSelect;
	}

	Input::GetInstance().Update();
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE))
	{
		isEnd = true;
	}
	world->Update(deltaTime);
}

void Result::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Result);
	world->Draw(renderer);
}

bool Result::IsEnd() const
{
	return isEnd;
}

Scene Result::Next() const
{
	return nextScene;
}

void Result::Finalize()
{
	world->Finalize();
	renderer.Clear();
}

void Result::HandleMessage(EventMessage message, void * param)
{
	
}

