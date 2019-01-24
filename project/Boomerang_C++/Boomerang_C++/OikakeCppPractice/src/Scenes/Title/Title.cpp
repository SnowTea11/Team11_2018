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
}

void Title::Initialize()
{
	isEnd = false;
}

void Title::Update(float deltaTime)
{
	Input::GetInstance().Update();

	if (Input::GetInstance().GetKeyBoard().IsDown(KEY_INPUT_SPACE)) {
		isEnd = true;
	}

}

void Title::Draw() const
{
	renderer.DrawTexture(Assets::Texture::Title);
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
	renderer.Clear();
}

void Title::HandleMessage(EventMessage message, void * param)
{
}
