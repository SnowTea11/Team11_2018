#pragma once

/**
 * @file Assets.h
 * @brief ゲーム内で使用するアセットの定義ファイル
 * @author 阿曽
 * @date 2017/2/23
 */

 //! Assetsの名前空間
namespace Assets {
	/**
	* @enum Texture
	* 使用するテクスチャの定義
	*/
	enum class Texture {
		Background,
		Player,
		Player_Right,
		Enemy,

		Number,

		Title,
		Tutorial,
		StageSelect,
		Result,

		RankS,
		RankA,
		RankB,
		RankC,

		Star1,
		Star2,
		Star3,
		StarFrame1,
		StarFrame2,
		StarFrame3,

		Cursor,
		Text,
		Boomerang,
		Bumper,
		Block,
		Form,
		AirFlow
	};
}