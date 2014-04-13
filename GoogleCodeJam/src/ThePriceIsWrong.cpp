#include "Prototypes.h"

typedef std::vector<string> lists_t;
typedef std::vector<int> listi_t;
typedef std::array<std::array<bool, 64>, 64> tab_t;

void GoogleCodeJam::Practice::Beta2008::ThePriceIsWrong()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	std::cin.ignore();
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		string s;
		std::istringstream iss;

		std::getline(std::cin, s);
		lists_t products;
		iss.str(s);
		do
		{
			iss >> s;
			products.push_back(s);
		} while (!iss.eof());

		std::getline(std::cin, s);
		listi_t guesses;
		iss.str(s);
		iss.clear();
		do
		{
			int i;
			iss >> i;
			guesses.push_back(i);
		} while (!iss.eof());

		unsigned int sz (products.size());
		tab_t F;
		listi_t v;
		v.reserve(sz);

		for (unsigned int b (0); b < 64; ++b)
			for (unsigned int c (0); c < 64; ++c)
				F[b][c] = false;

		for (unsigned int b (0); b < sz; ++b)
			for (unsigned int c (0); c < sz; ++c)
				F[b][c] = b <= c ? (guesses[b] <= guesses[c]) : (guesses[b] > guesses[c]);

		for (unsigned int b (0); b < sz; ++b)
			v.push_back(std::count_if(F[b].begin(), F[b].begin() + sz, [](bool &c) { return !c; }));

		int mx (64);
		bool bl (false);
		lists_t res;
		while (mx != 0)
		{
			for (unsigned int c (0); c < sz; ++c)
				if (v[c] == mx)
				{
					if (!bl)
					{
						res.push_back(products[c]);
						bl = true;
					}
					else
						bl = false;
				}
			bl = false;
			--mx;
		}

		std::cout << "Case #" << a << ':';

		std::sort(res.begin(), res.end());
		for (unsigned int b (0); b < (res.size() >> 1) + res.size() % 2; ++b)
			std::cout << ' ' << res[b];

		std::cout << std::endl;
	}
}