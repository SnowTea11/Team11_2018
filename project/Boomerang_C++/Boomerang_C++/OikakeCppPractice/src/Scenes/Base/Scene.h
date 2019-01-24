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
	//!ゲームメイン
	GameMain,
	//!リザルト
	Result
};
