#include <iostream>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Y2008::Qualification::FlySwatter()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (int a (1); a <= nbCases; ++a)
	{
		double f, R, t, r, g;

		std::cin >> f >> R >> t >> r >> g;
		assert(f > 0 && f <= 10000 && f < R);
		assert(R > 0 && R <= 10000);
		assert(t > 0 && t <= 10000 && t < R);
		assert(r > 0 && r <= 10000 && r < R);
		assert(g > 0 && g <= 10000);

		std::cout << "Case #" << a << ": " << std::endl;
	}
}
