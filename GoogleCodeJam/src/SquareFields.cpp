#include <iostream>
#include <vector>
#include <algorithm>
#include <utility>
#include <cmath>
#include <cassert>

#include "Prototypes.h"

typedef struct s
{
	short _x, _y;
	float _norm;
	s(short x, short y)
	{
		_x = x;
		_y = y;
		_norm = std::sqrt(static_cast<float>(x * x + y * y));
	}
} point_t;

typedef std::vector<point_t> list_t;
typedef std::vector<list_t> tab_t;

bool operator <(point_t const &first, point_t const &second)
{
	return first._norm < second._norm;
}

void GoogleCodeJam::Practice::SquareFields()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 10);

	for (int a (1); a <= nbCases; ++a)
	{
		int n, k;

		std::cin >> n;
		assert(n >= 1 && n <= 15);
		std::cin >> k;
		assert(k >= 1 && k <= 15);
		assert(k < n);

		list_t points;
		points.reserve(n);

		for (int b (0); b < n; ++b)
		{
			unsigned short x, y;
			std::cin >> x >> y;
			assert(x >= 0 && x < 64000 && y >= 0 && y < 64000);
			points.push_back(point_t(x, y));
		}

		std::sort(points.begin(), points.end());

		tab_t tab(;
		tab.reserve(k);

		const int taille = n / k + n % k;
		for (int i = 0; i < k; ++i)
		{
			list_t sublist;
			sublist.reserve(taille);
			for (int j = 0; j < n / k; ++j)
			{
			}
			std::min_element(points.begin(), points.end());
			sublist.push_back(0);
			tab.push_back(sublist);
		}

		unsigned short res;
		//for (res = 1; !good(points, far, res); ++res);

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
