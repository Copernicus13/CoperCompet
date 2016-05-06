#include "Prototypes.h"

void GoogleCodeJam::Practice::Beta2008::RandomRoute()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		std::cout << "Case #" << a << ": " << std::endl;
	}
}