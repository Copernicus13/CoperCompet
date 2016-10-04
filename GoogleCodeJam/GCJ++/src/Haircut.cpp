#include "Prototypes.h"

typedef unsigned long long int l_int;
typedef std::vector<unsigned int> tab_t;

static l_int solve(tab_t tab, l_int n)
{
	unsigned int b = static_cast<unsigned int>(tab.size());

	l_int time (0), sum (0);
	// Naive way
	//for (; sum < n; ++time)
	//{
	//	sum = 0;
	//	for (unsigned int a (0); a < b; ++a)
	//		sum += time / tab[a] + 1;
	//}
	//--time;

	// Stochastic way of finding time
	l_int x, ptr = std::numeric_limits<l_int>::max();
	while (time < ptr)
	{
		x = (time + ptr) / 2;
		l_int tmpsum = 0;
		for (unsigned int a (0); a < b; ++a)
			tmpsum += x / tab[a] + 1;
		if (tmpsum >= n)
			ptr = x;
		else
			time = x + 1;
	}

	tab_t ind;
	sum = 0;
	for (unsigned int a (0); a < b; ++a)
	{
	    sum += time / tab[a] + 1;
		if (time % tab[a] == 0)
			ind.push_back(a);
	}

	return ind[ind.size() - 1 - (unsigned int)(sum - n)] + 1;
}

void GoogleCodeJam::Y2015::Round1A::Haircut()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int b;
		l_int n;
		std::cin >> b >> n;
		tab_t tab;
		tab.resize(b);
		for (unsigned int c (0); c < b; ++c)
		{
			std::cin >> tab[c];
			assert(tab[c] > 0);
		}

		std::cout << "Case #" << a << ": " << solve(tab, n) << std::endl;
	}
}