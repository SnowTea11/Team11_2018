#pragma once

/**
 * @file Scene.h
 * @brief ゲーム内で使用するシーンの定義ファイル
 * @author 阿曽
 * @date Unknown
 */

/**
 * @enum Scene
 * ゲーム内で使用するシーンの定義
 */
enum class Scene {
	//!デフォルト　＆　何のシーンでもない
	None,
	//!タイトル
	Title,
	//!チュートリアル
	Tutorial,

	//!ステージセレクト
	StageSelect,
	//ステージ
	Stage1,
	Stage2,
	Stage3,
	Stage4,
	Stage5,

	//!ゲームメイン
	GameMain,
	//!リザルト
	Result,
	Result2,
	Result3,
	Result4,
	Result5,
};
