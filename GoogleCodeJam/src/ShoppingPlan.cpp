#include <iostream>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Practice::Problems::ShoppingPlan()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (int a (1); a <= nbCases; ++a)
	{
		std::cout << "Case #" << a << ": " << std::endl;
	}
}