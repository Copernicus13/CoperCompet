#include "Prototypes.h"

typedef std::vector<unsigned int> tab_t;

static bool isPossible(tab_t tab1, tab_t &, unsigned int, unsigned int V)
{
	//unsigned int result = 0;
	for (unsigned int i(0); i < tab1.size() - 1; ++i)
		if (i < V && i + 1 > V)
			tab1[i] = 0;
			//continue;
	return false;
}

static void getResult(tab_t tab1, tab_t &tab2, unsigned int C, unsigned int V)
{
	for (unsigned int i(0); i < V; ++i)
		if (!isPossible(tab1, tab2, C, V))
			tab2.push_back(i);
}

void GoogleCodeJam::Y2015::Round1C::LessMoneyMoreProblems()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int C, D, V;
		std::cin >> C >> D >> V;

		tab_t tab1, tab2;
		tab1.resize(D);

		for (unsigned int b (0); b < D; ++b)
			std::cin >> tab1[b];

		getResult(tab1, tab2, C, V);
		std::cout << "Case #" << a << ": " << tab2.size() << std::endl;
	}
}