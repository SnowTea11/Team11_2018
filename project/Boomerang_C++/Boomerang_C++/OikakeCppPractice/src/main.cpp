#include<DxLib.h>
#include"Application/GameFrame/GameFrame.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	return GameFrame().Run();
}