// Main.cpp�: d�finit le point d�entr�e pour l�application console.
//

#include <cstdlib>
#include <string>

#include "Prototypes.h"

using namespace GoogleCodeJam::Y2008;

int main(int argc, char* argv[])
{
	if (argc != 2)
	{
		return EXIT_FAILURE;
	}

	std::string param (argv[1]);
	if (param == "MinimumScalarProduct")
	{
		MinimumScalarProduct();
	}
	else if (param == "Milkshakes")
	{
		Milkshakes();
	}

#ifdef _DEBUG
	system("pause");
#endif

	return EXIT_SUCCESS;
}