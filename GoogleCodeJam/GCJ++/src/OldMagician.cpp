#include <iostream>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Practice::Contest::OldMagician()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 1000);

	for (int a (1); a <= nbCases; ++a)
	{
		int w, b;

		std::cin >> w;
		assert(w >= 0 && w <= 1e10);
		std::cin >> b;
		assert(b >= 0 && b <= 1e10);
		assert(w + b > 0);

		std::cout << "Case #" << a << ": " << (b % 2 ? "BLACK" : "WHITE") << std::endl;
	}
}
