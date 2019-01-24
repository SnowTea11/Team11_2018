#include"Input/Input.h"
#include<DxLib.h>
#include <math.h>
#include"Math/Convert/Convert.h"

Input::Input() 
	: keyBoard()
{
	RegistFunc();
}

Input::~Input() {
}

Input & Input::GetInstance() {
	static Input instance;
	return instance;
}

void Input::RegistFunc() {
	axisFunc[0] = [&](void)->float {return GetVertical(); };
	axisFunc[1] = [&](void)->float {return GetHorizontal(); };
	axisFunc[2] = [&](void)->float {return  GetVertical2(); };
	axisFunc[3] = [&](void)->float {return  GetHorizontal2(); };
}

bool Input::GetCommand(Command command) {
	return commandFunc[static_cast<int>(command)]();
}

float Input::GetAxis(Axis axis)
{
	return axisFunc[static_cast<int>(axis)]();
}



KeyBoard & Input::GetKeyBoard()
{
	return keyBoard;
}


void Input::Update() {
	keyBoard.Update();
	prevInput = curInput;
	curInput = Input::GetInstance().GetVelocity();
}

Vector2 Input::GetVelocity() const
{
	return Vector2(GetHorizontal(), GetVertical());
}


float Input::GetVertical() const
{
	float value = 0.0f;

	if (keyBoard.IsState(KEY_INPUT_W)) {
		value = 0.0f;
	}
	if (keyBoard.IsState(KEY_INPUT_S)) {
		value = 0.0f;
	}
	return value;
}

float Input::GetHorizontal() const
{
	float value = 0.0f;
	if (keyBoard.IsDown(KEY_INPUT_A)) {
		value = -12.0f;
	}
	if (keyBoard.IsDown(KEY_INPUT_D)) {
		value = 12.0f;
	}
	return value;
}

float Input::GetVertical2() const
{
	float value = 0.0f;

	if (keyBoard.IsState(KEY_INPUT_UP)) {
		value = -1.0f;
	}
	if (keyBoard.IsState(KEY_INPUT_DOWN)) {
		value = 1.0f;
	}
	return value;
}

float Input::GetHorizontal2() const
{
	float value = 0.0f;

	if (keyBoard.IsState(KEY_INPUT_LEFT)) {
		value = -1.0f;
	}
	if (keyBoard.IsState(KEY_INPUT_RIGHT)) {
		value = 1.0f;
	}
	return value;
}

