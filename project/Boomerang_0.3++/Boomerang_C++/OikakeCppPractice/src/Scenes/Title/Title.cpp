#include "Title.h"
#include"Renderer/Renderer.h"
#include "Scenes/Base/Scene.h"
#include"Input/Input.h"

Title::Title(WorldPtr & world)
	: isEnd(false)
	, world(world)
	, renderer(Renderer::GetInstance())
{
}

Title::~Title()
{
}

void Title::LoadAssets()
{
	renderer.LoadTexture(Assets::Texture::Title, "title.png");
	renderer.LoadTexture(Assets::Texture::Text, "start.png");
}

void Title::Initialize()
{
	shBGM = LoadSoundMem("asset/texture/titleBGM.mp3");
	PlaySoundMem(shBGM, DX_PLAYTYPE_LOOP);
	shSE = LoadSoundMem("asset/texture/inputSE.wav");

	isEnd = false;
	frashCheck = true;
	alphaChange = 1.0f / 60.0f;
	alphaValue = 1.2f;
}

void Title::Update(float deltaTime)
{
	Input::GetInstance().Update();
	

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE)) {
		PlaySoundMem(shSE, DX_PLAYTYPE_BACK);
		isEnd = true;
	}

	if (frashCheck) {
		alphaValue += alphaChange;
		if (alphaValue >= 1.0f)
			frashCheck = false;
	}
	else
	{
		alphaValue -= alphaChange;
		if (alphaValue <= 0.01f)
			frashCheck = true;
	}

}

void Title::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Title);
	renderer.DrawTexture(Assets::Texture::Text, Vector2(300, 500), Vector2(0, 0), Vector2(1, 1), 0.0f, Color::White, alphaValue);

}

bool Title::IsEnd() const
{
	return isEnd;
}

Scene Title::Next() const
{
	return Scene::Tutorial;
}

void Title::Finalize()
{
	StopSoundMem(shBGM);
	renderer.Clear();
}

void Title::HandleMessage(EventMessage message, void * param)
{
}

