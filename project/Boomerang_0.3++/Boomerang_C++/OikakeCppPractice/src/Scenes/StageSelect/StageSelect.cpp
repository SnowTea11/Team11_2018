#include "StageSelect.h"
#include "Scenes/Base/Scene.h"

#include"World/World.h"
#include"Actor/Base/ActorGroup.h"
#include"Renderer/Renderer.h"
#include"Actor/Base/EventMessage.h"
#include"Application/Window/Window.h"
#include"Input/Input.h"

StageSelect::StageSelect(WorldPtr & world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
	CursorPosition = 60;
}

StageSelect::~StageSelect()
{
}

void StageSelect::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::StageSelect, "stage.png");
	renderer.LoadTexture(Assets::Texture::Cursor, "player_sd.png");
}

void StageSelect::Initialize()
{
	shBGM = LoadSoundMem("asset/texture/stageBGM.mp3");
	shSE1 = LoadSoundMem("asset/texture/inputSE.wav");
	shSE2 = LoadSoundMem("asset/texture/decideSE.wav");
	PlaySoundMem(shBGM, DX_PLAYTYPE_LOOP);

	world->GetSceneShareValue().Initialize();
	world->Initialize();


	isEnd = false;

	//!ワールドのイベントメッセージを受け取る
	world->AddEventMessageListener([&](EventMessage message, void* param)
	{
		HandleMessage(message, param);
	});
}

void StageSelect::Update(float deltaTime)
{
	Input::GetInstance().Update();
	world->Update(deltaTime);

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_RIGHT))
	{
		if (CursorPosition < 1020)
		{
			CursorPosition += 240;
			PlaySoundMem(shSE1, DX_PLAYTYPE_BACK);
		}
	}

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_LEFT))
	{
		if (CursorPosition > 60)
		{
			CursorPosition -= 240;
			PlaySoundMem(shSE1, DX_PLAYTYPE_BACK);
		}
	}

	if (CursorPosition == 60)
	{
		nextScene =Scene::Stage1;
	}
	if (CursorPosition == 300)
	{
		nextScene = Scene::Stage2;
	}
	if (CursorPosition == 540)
	{
		nextScene = Scene::Stage3;
	}
	if (CursorPosition == 780)
	{
		nextScene = Scene::Stage4;
	}
	if (CursorPosition == 1020)
	{
		nextScene = Scene::Stage5;
	}

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE)) 
	{
		PlaySoundMem(shSE2, DX_PLAYTYPE_NORMAL);
		isEnd = true;
	}
}

void StageSelect::Draw() const
{
	renderer.DrawTexture(Assets::Texture::StageSelect);
	renderer.DrawTexture(Assets::Texture::Cursor,Vector2(CursorPosition,550));
	world->Draw(renderer);
}

bool StageSelect::IsEnd() const
{
	return isEnd;
}

Scene StageSelect::Next() const
{
	return nextScene;//本当は選択したステージへ
}

void StageSelect::Finalize()
{
	StopSoundMem(shBGM);
	world->Finalize();
	renderer.Clear();
}

void StageSelect::HandleMessage(EventMessage message, void * param)
{
	if (message == EventMessage::GameEnd)
	{
		isEnd = true;
	}
}


