#include "Prototypes.h"

typedef std::vector<unsigned int> tab_t;
typedef std::pair<unsigned int, unsigned int> pair_t;

static pair_t solve(tab_t tab)
{
	unsigned int n = tab.size();
	unsigned int sum1 = 0, sum2 = 0, diff = 0;
	for (unsigned int a (0); a < n - 1; ++a)
	{
		if (tab[a + 1] < tab[a])
		{
			sum1 += tab[a] - tab[a + 1];
			diff = std::max(diff, tab[a] - tab[a + 1]);
		}
	}
	for (unsigned int a (0); a < n - 1; ++a)
	{
		sum2 += std::min(tab[a], diff);
	}
	return std::make_pair(sum1, sum2);
}


void GoogleCodeJam::Y2015::Round1A::MushroomMonster()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int N;
		std::cin >> N;

		tab_t tab;
		tab.resize(N);

		for (unsigned int b (0); b < N; ++b)
		{
			std::cin >> tab[b];
		}

		pair_t rep = solve(tab);
		std::cout << "Case #" << a << ": " << rep.first << ' ' << rep.second << std::endl;
	}
}