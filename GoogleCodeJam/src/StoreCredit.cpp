#include <iostream>
#include <cassert>

#include "Prototypes.h"

static int* GetResult(const int c, const int i, const int p[]);

void GoogleCodeJam::Y2010::Africa::StoreCredit()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 50);

	for (int a (1); a <= nbCases; ++a)
	{
		int c, i;

		std::cin >> c;				// amount of credit you have at the store
		assert(c >= 5 && c <= 1000);
		std::cin >> i;				// number of items in the store
		assert(i >= 3 && c <= 2000);

		int* p = new int[i];		// prices
		for (int b (0); b < i; ++b)
		{
			std::cin >> p[b];
			assert(p[b] >= 1 && p[b] <= 1000);
		}

		int* r = GetResult(c, i, p);
		std::cout << "Case #" << a << ": " << r[0] << ' ' << r[1] << std::endl;
		delete[] r;
		delete[] p;
	}
}

static int* GetResult(const int c, const int i, const int p[])
{
	int* r = new int[2];
	for (int a (0); a < i; ++a)
	{
		for (int b (0); b < i; ++b)
		{
			if (b == a)
			{
				continue;
			}
			if (p[a] + p[b] == c)
			{
				if (a < b)
				{
					r[0] = a + 1;
					r[1] = b + 1;
				}
				else
				{
					r[0] = b + 1;
					r[1] = a + 1;
				}
				break;
			}
		}
	}
	return r;
}