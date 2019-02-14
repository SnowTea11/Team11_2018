#include "GameFrame.h"
#include"World/World.h"
#include"Scenes/Base/SceneManager.h"
#include"Scenes/Base/Scene.h"
#include"Scenes/GameMain/GameMain.h"
#include"Scenes/Title/Title.h"
#include"Scenes/Tutorial/Tutorial.h"
#include"Scenes/StageSelect/StageSelect.h"
#include"Scenes/Stage/Stage1.h"
#include"Scenes/Stage/Stage2.h"
#include"Scenes/Stage/Stage3.h"
#include"Scenes/Stage/Stage4.h"
#include"Scenes/Stage/Stage5.h"
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
	sceneManager.Add(Scene::Tutorial, std::make_shared<Tutorial>(world));
	sceneManager.Add(Scene::StageSelect, std::make_shared<StageSelect>(world));
	sceneManager.Add(Scene::Stage1, std::make_shared<Stage1>(world));
	sceneManager.Add(Scene::Stage2, std::make_shared<Stage2>(world));
	sceneManager.Add(Scene::Stage3, std::make_shared<Stage3>(world));
	sceneManager.Add(Scene::Stage4, std::make_shared<Stage4>(world));
	sceneManager.Add(Scene::Stage5, std::make_shared<Stage5>(world));
	sceneManager.Add(Scene::GameMain, std::make_shared<GameMain>(world));
	sceneManager.Add(Scene::Result, std::make_shared<Result>(world));


	sceneManager.Change(Scene::Title);

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