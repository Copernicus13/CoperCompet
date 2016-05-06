#include "Prototypes.h"

typedef std::vector<unsigned int> tab_t;

static int getNbOfGuest(tab_t tab, unsigned int i, unsigned int people)
{
	if (i == tab.size())
		return 0;
	if (i > people)
		return i - people + getNbOfGuest(tab, i + 1, i + tab[i]);
	return getNbOfGuest(tab, i + 1, people + tab[i]);
}

void GoogleCodeJam::Y2015::Round1A::Logging()
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

		int rep = getNbOfGuest(tab, 0, 0);
		std::cout << "Case #" << a << ": " << rep << std::endl;
	}
}