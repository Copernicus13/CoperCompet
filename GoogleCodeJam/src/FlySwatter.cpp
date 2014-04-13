#include "Prototypes.h"

const long double pi = 3.1415926535897932384626433832795;

void GoogleCodeJam::Y2008::Qualification::FlySwatter()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		double f, R, t, r, g;

		std::cin >> f >> R >> t >> r >> g;
		assert(f > 0 && f <= 10000 && f < R);
		assert(R > 0 && R <= 10000);
		assert(t > 0 && t <= 10000 && t < R);
		assert(r > 0 && r <= 10000 && r < R);
		assert(g > 0 && g <= 10000);

		long double res = (pi * (R - t - f) * (R - t - f) *
			((2 * r + 2 * f) * (2 * g + 2 * r - 2 * f) /
			(g + 2 * r) * (g + 2 * r)) +
			(pi * (t + f) * (2 * R - t - f))) /
			(pi * R * R);

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
