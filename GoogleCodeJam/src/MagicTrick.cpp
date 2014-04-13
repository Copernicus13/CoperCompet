#include "Prototypes.h"

typedef std::array<std::array<int, 4>, 4> tab_t;

void GoogleCodeJam::Y2014::Qualification::MagicTrick()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int guess1, guess2;
		tab_t tab1, tab2;

		std::cin >> guess1;
		for (unsigned int b (0); b < 4; ++b)
			for (unsigned int c (0); c < 4; ++c)
				std::cin >> tab1[b][c];

		std::cin >> guess2;
		for (unsigned int b (0); b < 4; ++b)
			for (unsigned int c (0); c < 4; ++c)
				std::cin >> tab2[b][c];

		--guess1, --guess2;

		std::cout << "Case #" << a << ": ";

		unsigned int res (std::numeric_limits<unsigned int>::max());
		for (unsigned int b (0); b < 4; ++b)
			for (unsigned int c (0); c < 4; ++c)
			{
				if (tab1[guess1][b] == tab2[guess2][c])
				{
					if (res == std::numeric_limits<unsigned int>::max())
						res = tab1[guess1][b];
					else
						res = 17;
				}
			}

		if (res == 17)
			std::cout << "Bad magician!";
		else if (res == std::numeric_limits<unsigned int>::max())
			std::cout << "Volunteer cheated!";
		else
			std::cout << res;

		std::cout << std::endl;
	}
}