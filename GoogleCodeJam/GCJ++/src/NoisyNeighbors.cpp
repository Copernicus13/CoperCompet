#include "Prototypes.h"

typedef std::vector<unsigned int> tab_t;

static int getResult(tab_t tab)
{
	return 0;
}

void GoogleCodeJam::Y2015::Round1B::NoisyNeighbors()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int nbShyness;
		std::cin >> nbShyness;

		tab_t tab;
		tab.resize(nbShyness + 1);

		for (unsigned int b (0); b < nbShyness + 1; ++b)
		{
			unsigned char shyness;
			std::cin >> shyness;
			tab[b] = shyness - '0';
		}

		int rep = getResult(tab);
		std::cout << "Case #" << a << ": " << rep << std::endl;
	}
}