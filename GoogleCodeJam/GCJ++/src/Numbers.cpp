#include "Prototypes.h"

inline static long double mypow(long double X, unsigned int Y)
{
    for (long double Z = 1; ; X *= X)
    {
		if ((Y & 1) != 0)
			Z *= X;
		if ((Y >>= 1) == 0)
			return Z;
	}
}

void GoogleCodeJam::Y2008::Numbers()
{
	const long double c1 = 5.2360679774997896964091736687313;
	const long double c2 = 5.2360679774997896964091;
	const long double c3 = 5.2360679774997896;

	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		int n;
		std::cin >> n;

		/*unsigned long long int res = 1;
	    for (int o = 0; o < n / 4; ++o)
	    {
			int k = (3 + std::sqrtl(5));
			int r = k % 1000;
		}
		if (n % 2)
		{
			res *= 3 + std::sqrtl(5);
		}*/
		//std::cout << mypow(3 + std::sqrtl(5), static_cast<unsigned int>(n)) << std::endl;
		//int r = static_cast<int>(std::powl(c, n)) % 1000;
		std::cout.precision(50);
		std::cout << "Case #" << a << ": " << mypow(c1, static_cast<unsigned int>(n)) << std::endl;
		std::cout << "Case #" << a << ": " << mypow(c2, static_cast<unsigned int>(n)) << std::endl;
		std::cout << "Case #" << a << ": " << mypow(c3, static_cast<unsigned int>(n)) << std::endl;
		std::cout << "Case #" << a << ": " << mypow(3 + std::sqrtl(5), static_cast<unsigned int>(n)) << std::endl;
		std::cout << "Case #" << a << ": " << mypow(3 + std::sqrtl(5), static_cast<unsigned int>(n / 2)) * mypow(3 + std::sqrtl(5), static_cast<unsigned int>(n / 2)) << std::endl;
	}
}
