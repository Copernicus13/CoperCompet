#include "Prototypes.h"

typedef std::pair<int, int> flavor_t;
typedef std::vector<flavor_t> list_t;
typedef std::vector<list_t> tab_t;

static bool issatisfied(list_t l, std::vector<int> f)
{
	for (list_t::size_type x (0); x < l.size(); ++x)
	{
		if (l[x].second == f[l[x].first - 1])
		{
			return true;
		}
	}
	return false;
}

static int getmalted(list_t l)
{
	for (list_t::size_type x (0); x < l.size(); ++x)
	{
		if (l[x].second == 1)
		{
			return x;
		}
	}
	return -1;
}

void GoogleCodeJam::Y2008::Milkshakes()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int nbflavor, nbcustomers;
		std::cin >> nbflavor >> nbcustomers;
		assert(nbflavor >= 1 && nbflavor <= 2000);
		assert(nbcustomers >= 1 && nbcustomers <= 2000);

		tab_t customers;
		customers.reserve(nbcustomers);

		for (unsigned int b (0); b < nbcustomers; ++b)
		{
			unsigned int nbgout;
			std::cin >> nbgout;
			list_t gout;
			gout.reserve(nbgout);
			for (unsigned int c (0); c < nbgout; ++c)
			{
				int g, h;
				std::cin >> g >> h;
				gout.push_back(std::make_pair(g, h));
			}
			customers.push_back(gout);
		}

		std::vector<int> res (nbflavor, 0);
		bool impossible = false;

		for (int b (0); b < static_cast<int>(customers.size()); ++b)
		{
			if (issatisfied(customers[b], res))
			{
				continue;
			}
			int posmalted = getmalted(customers[b]);
			if (posmalted == -1)
			{
				impossible = true;
				break;
			}
			res[customers[b][posmalted].first - 1] = 1;
			b = -1;
		}

		std::cout << "Case #" << a << ':';
		if (impossible)
		{
			std::cout << " IMPOSSIBLE";
		}
		else
		{
			for (std::vector<int>::size_type x (0); x < res.size(); ++x)
			{
				std::cout << ' ' << res[x];
			}
		}
		std::cout << std::endl;
	}
}
