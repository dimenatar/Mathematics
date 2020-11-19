//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <tchar.h>
//---------------------------------------------------------------------------
USEFORM("..\..\..\Documents\Embarcadero\Studio\Projects\AuthorisationForm.cpp", Authorisation);
USEFORM("..\..\..\Documents\Embarcadero\Studio\Projects\MainMenuForm.cpp", Main);
USEFORM("..\..\..\Documents\Embarcadero\Studio\Projects\MatrixForm.cpp", Matrix);
//---------------------------------------------------------------------------
int WINAPI _tWinMain(HINSTANCE, HINSTANCE, LPTSTR, int)
{
	try
	{
		Application->Initialize();
		Application->MainFormOnTaskBar = true;
		Application->CreateForm(__classid(TAuthorisation), &Authorisation);
		Application->CreateForm(__classid(TMain), &Main);
		Application->CreateForm(__classid(TMatrix), &Matrix);
		Application->Run();
	}
	catch (Exception &exception)
	{
		Application->ShowException(&exception);
	}
	catch (...)
	{
		try
		{
			throw Exception("");
		}
		catch (Exception &exception)
		{
			Application->ShowException(&exception);
		}
	}
	return 0;
}
//---------------------------------------------------------------------------
