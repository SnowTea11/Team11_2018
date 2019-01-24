#include "GameFrame.h"
#include"World/World.h"
#include"Scenes/Base/SceneManager.h"
#include"Scenes/Base/Scene.h"
#include"Scenes/GameMain/GameMain.h"
#include"Scenes/Title/Title.h"
#include"Scenes/Tutorial/Tutorial.h"
#include"Scenes/Result/Result.h"


GameFrame::GameFrame()
	: GameApplication()
	, world(nullptr)
	, sceneManager()
{

}

GameFrame::~GameFrame()
{
}

void GameFrame::Initialize()
{
	world = std::make_shared<World>();
	sceneManager.Initialize();

	sceneManager.Add(Scene::Title, std::make_shared<Title>(world));
	sceneManager.Add(Scene::GameMain, std::make_shared<GameMain>(world));
	sceneManager.Add(Scene::Result, std::make_shared<Result>(world));
	sceneManager.Add(Scene::Tutorial, std::make_shared<Tutorial>(world));

	sceneManager.Change(Scene::GameMain);

}

void GameFrame::Update(float deltaTime)
{
	sceneManager.Update(deltaTime);
}

void GameFrame::Draw()
{
	sceneManager.Draw();
}

void GameFrame::Finalize()
{
	sceneManager.Finalize();
}