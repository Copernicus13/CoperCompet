// Main.cpp : définit le point d’entrée pour l’application console.
//

#include <cstdlib>
#include <string>

#include "Prototypes.h"

using namespace GoogleCodeJam::Y2009;

int main(int argc, char* argv[])
{
	if (argc != 2)
	{
		return EXIT_FAILURE;
	}

	std::string param (argv[1]);
	if (param == "AlienLanguage")
	{
		AlienLanguage();
	}
	
#ifdef _DEBUG
	system("pause");
#endif

	return EXIT_SUCCESS;
}