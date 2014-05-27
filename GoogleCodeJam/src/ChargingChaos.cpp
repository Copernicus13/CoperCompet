#include "Prototypes.h"

void GoogleCodeJam::Y2014::Round1A::ChargingChaos()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int devices, length;
		std::cin >> devices >> length;
		assert(devices >= 1 && devices <= 150);
		assert(devices >= 2 && devices <= 40);

		std::cout << "Case #" << a << ":" << std::endl;
	}
}
