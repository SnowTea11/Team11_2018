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
	CursorPosition = 120;
}

Result::~Result()
{
}

void Result::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::Result, "result.png");
	renderer.LoadTexture(Assets::Texture::Number, "number.png");
	renderer.LoadTexture(Assets::Texture::Cursor, "cursur.png");
	renderer.LoadTexture(Assets::Texture::RankS, "rankS.png");
	renderer.LoadTexture(Assets::Texture::RankA, "rankA.png");
	renderer.LoadTexture(Assets::Texture::RankB, "rankB.png");
	renderer.LoadTexture(Assets::Texture::RankC, "rankC.png");
	renderer.LoadTexture(Assets::Texture::Star1, "star_on.png");
	renderer.LoadTexture(Assets::Texture::Star2, "star_on.png");
	renderer.LoadTexture(Assets::Texture::Star3, "star_on.png");
	renderer.LoadTexture(Assets::Texture::StarFrame1, "star_off.png");
	renderer.LoadTexture(Assets::Texture::StarFrame2, "star_off.png");
	renderer.LoadTexture(Assets::Texture::StarFrame3, "star_off.png");

}

void Result::Initialize()
{
	isEnd = false;
	world->Initialize();
	world->AddActor_Back(ActorGroup::UI, std::make_shared<Score>(world.get()));

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param)
	{
		HandleMessage(message, param);
	});
}


void Result::Update(float deltaTime)
{
	Input::GetInstance().Update();
	world->Update(deltaTime);

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_RIGHT))
	{
		CursorPosition = 650;
	}
	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_LEFT))
	{
		CursorPosition = 120;
	}

	if (CursorPosition == 120)
	{
		nextScene = Scene::Stage2;
	}
	if (CursorPosition == 650)
	{
		nextScene = Scene::StageSelect;
	}


	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE))
	{
		isEnd = true;
	}

}

void Result::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Result);
	renderer.DrawTexture(Assets::Texture::Cursor, Vector2(CursorPosition, 620));

	renderer.DrawTexture(Assets::Texture::RankS, Vector2(700, 430));
	renderer.DrawTexture(Assets::Texture::RankA, Vector2(700, 430));
	renderer.DrawTexture(Assets::Texture::RankB, Vector2(700, 430));
	renderer.DrawTexture(Assets::Texture::RankC, Vector2(700, 430));

	renderer.DrawTexture(Assets::Texture::Star1, Vector2(150, 150));
	renderer.DrawTexture(Assets::Texture::Star2, Vector2(475, 150));
	renderer.DrawTexture(Assets::Texture::Star3, Vector2(800, 150));
	renderer.DrawTexture(Assets::Texture::StarFrame1, Vector2(150, 150));
	renderer.DrawTexture(Assets::Texture::StarFrame2, Vector2(475, 150));
	renderer.DrawTexture(Assets::Texture::StarFrame3, Vector2(800, 150));


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
	if (message == EventMessage::GameEnd)
	{
		isEnd = true;
	}
}

