#pragma once

#include<DxLib.h>
#include<array>
#include<functional>

#include"Math/Math.h"
#include"Math/Vector3/Vector3.h"
#include"Math/Vector2/Vector2.h"
#include"KeyBoard/KeyBoard.h"
#include"Command.h"
#include"Axis.h"

/**
 * @file Input.h
 * @brief ���͊Ǘ��N���X��`�w�b�_�[
 * @author ���]
 * @date Unknown
 */

 /*! @class Input
 *   @brief  ���͊Ǘ��N���X
 */
class Input {
private:	
	/// <summary>
	/// �R���X�g���N�^
	/// </summary>
	Input();	
	/// <summary>
	/// �f�X�g���N�^
	/// </summary>
	~Input();

private:
	/// <summary>
	/// �Q�[���p�̃{�^����`�ŉ����ꂽ��s��������o�^
	/// </summary>
	void RegistFunc();	
public:	
	/// <summary>
	/// Input�N���X�̎��Ԃ��擾
	/// </summary>
	/// <returns>Input�N���X�̎���</returns>
	static Input& GetInstance();
	
	/// <summary>
	/// �Q�[���p�̃{�^���������ꂽ���H
	/// </summary>
	/// <param name="command">�Q�[���p�̃{�^��</param>
	/// <returns>�����ꂽ���H</returns>
	bool GetCommand(Command command);

	/// <summary>
	/// ����(Horizontal)�E�c��(Vertical)�̓��͒l���擾�ł���
	/// </summary>
	/// <param name="axis">����(Horizontal)�E�c��(Vertical)</param>
	/// <returns>�w�肵�����̓��͒l</returns>
	float GetAxis(Axis axis);	

	/// <summary>
	/// �X�V
	/// </summary>
	void Update();

	/// <summary>
	/// WASD�L�[ LStick�̓��͂��ꂽ�l��Ԃ�
	/// </summary>
	/// <returns>�ړ���(0.0 �` 1.0)</returns>
	Vector2 GetVelocity() const;

	KeyBoard& GetKeyBoard();
private:
	//----RegistFunc�p�̊֐�----
	
	/// <summary>
	/// �c��(WS�L�[, LStick�̏㉺)�̓��͒l���擾����
	/// </summary>
	/// <returns>�c��(WS�L�[, LStick�̏㉺)�̓��͒l</returns>
	float GetVertical() const;
	/// <summary>
	/// ����(AD�L�[, LStick�̍��E)�̓��͒l���擾����
	/// </summary>
	/// <returns>����(AD�L�[, LStick�̍��E)�̓��͒l</returns>
	float GetHorizontal()const;
	/// <summary>
	/// �c��(�㉺�L�[, RStick�̏㉺)�̓��͒l���擾����
	/// </summary>
	/// <returns>�c��(�㉺�L�[, RStick�̏㉺)�̓��͒l</returns>
	float GetVertical2()const;
	/// <summary>
	/// ����(���E�L�[, RStick�̍��E)�̓��͒l���擾����
	/// </summary>
	/// <returns>����(���E�L�[, RStick�̍��E)�̓��͒l</returns>
	float GetHorizontal2()const;

private:	


	//!�Q�[���p�̃{�^���������ꂽ�����i�[����z��
	using CommandFunc = std::array < std::function<bool(void)>, static_cast<int>(Command::Max_Of_Num)>;
	//!�Q�[���p�̃{�^���������ꂽ�����i�[����z��	
	CommandFunc commandFunc;

	//!�c�����̓��͐��l���i�[����z��
	using AxisFunc = std::array< std::function<float(void)>, static_cast<int>(Axis::Max_Of_Num)>;
	
	//!�c�����̓��͐��l���i�[����z��
	AxisFunc axisFunc;

	KeyBoard keyBoard;

	Vector2 prevInput;
	Vector2 curInput;

};