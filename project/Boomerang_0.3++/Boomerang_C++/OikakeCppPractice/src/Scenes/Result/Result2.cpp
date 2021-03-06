#include "Result2.h"
#include "Scenes/Base/Scene.h"
#include"Renderer/Renderer.h"
#include"Input/Input.h"
#include"Actor/UI/Score/Score.h"
#include"World/World.h"
#include "Scenes/Base/SceneManager.h"

Result2::Result2(WorldPtr & world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Result2::~Result2()
{
}

void Result2::LoadAssets()
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

void Result2::Initialize()
{
	CursorPosition = 120;

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param)
	{
		HandleMessage(message, param);
	});

	isEnd = false;
	world->Initialize();
	world->AddActor_Back(ActorGroup::UI, std::make_shared<Score>(world.get()));
}

void Result2::Update(float deltaTime)
{
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
		nextScene = Scene::Stage3;
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

void Result2::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Result);
	renderer.DrawTexture(Assets::Texture::Cursor, Vector2(CursorPosition, 620));
	
	//renderer.DrawTexture("star_on", new Vector2(150, 150));
//renderer.DrawTexture("star_on", new Vector2(475, 150));
//renderer.DrawTexture("star_on", new Vector2(800, 150));
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

bool Result2::IsEnd() const
{
	return isEnd;
}

Scene Result2::Next() const
{
	return nextScene;
}

void Result2::Finalize()
{
	world->Finalize();
	renderer.Clear();
}

void Result2::HandleMessage(EventMessage message, void * param)
{
	if (message == EventMessage::GameEnd)
	{
		isEnd = true;
	}
}

