#pragma once

#include "Scenes/Base/Scene.h"
#include "Scenes/Base/IScene.h"
#include"World/IWorld.h"
#include"World/WorldPtr.h"

class Renderer;
enum class EventMessage;
enum class Scene;

/*! @class GameMainScene
*   @brief  �������
*/
class StageSelect : public IScene {
public:
	/**
	* @brief �R���X�g���N�^
	* @param world ���[���h�|�C���^
	*/
	explicit StageSelect(WorldPtr& world);
	/**
	* @brief �f�X�g���N�^
	*/
	virtual ~StageSelect();
	/**
	* @brief �A�Z�b�g��ǂݍ���
	*/
	virtual void LoadAssets() override;
	/**
	* @brief ������
	*/
	virtual void Initialize() override;
	/**
	* @brief �X�V
	* @param deltaTime �P�b
	*/
	virtual void Update(float deltaTime)override;
	/**
	* @brief �`��
	*/
	virtual void Draw() const override;
	/**
	* @brief �V�[�����I��������
	* @return [true �I��] : [false �܂��I�����Ă��Ȃ�]
	*/
	virtual bool IsEnd() const override;
	/**
	* @brief ���Ɉړ�����V�[�����擾
	* @return ���Ɉړ�����V�[��
	*/
	virtual Scene Next()const override;
	/**
	* @brief �I��
	*/
	virtual void Finalize() override;

private:
	/**
	* @brief �C�x���g���b�Z�[�W���󂯎��
	* @param message �o�^�����C�x���g���b�Z�[�W
	* @param param �C�x���g�ƈꏏ�ɑ���ϐ�
	*/
	void HandleMessage(EventMessage message, void* param);

private:
	//!���[���h�|�C���^
	WorldPtr world;
	//!�`��N���X
	Renderer& renderer;
	//!�V�[�����I������������p
	bool isEnd;
    int CursorPosition;//�J�[�\���̏ꏊ
	
	Scene nextScene;//�V�[��
	//�T�E���h�p�̕ϐ�
	int shBGM, shSE1, shSE2;
};

