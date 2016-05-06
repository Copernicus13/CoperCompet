#include <iostream>
#include <vector>
#include <deque>
#include <algorithm>
#include <utility>
#include <iterator>
#include <cmath>
#include <cstring>
#include <cassert>

#include "Prototypes.h"

typedef struct { unsigned short x, y; } point_t;
typedef std::vector<point_t> list_t;

static bool operator <(point_t const &first, point_t const &second)
{
	return first.y == second.y ? first.x < second.x : first.y < second.y;
}

int covered[15];

bool iscovered(list_t const &pt, int sz, int n, int k)
{
	int i, j;
	if (k == 0)
	{
		for (i = 0; i < n; ++i)
			if (!covered[i])
				return false;
		return true;
	}
	for (i = 0; i < n; ++i)
		if (!covered[i])
			break;
	if (i == n)
		return true;
	bool rv = false;
	for (j = 0; j < n && !rv; ++j)
	{
		if (pt[j].x >= pt[i].x - sz && pt[j].x <= pt[i].x + sz)
		{
			if (!covered[j])
			{
				int y = pt[i].y;
				int x = (pt[j].x <= pt[i].x ? pt[j].x : pt[j].x - sz);
				for (int a = 0; a < n; ++a)
				{
					if (pt[a].x >= x && pt[a].x <= x + sz && pt[a].y >= y && pt[a].y <= y + sz)
					{
						++covered[a];
					}
				}
				rv |= iscovered(pt, sz, n, k - 1);
				for (int a = 0; a < n; ++a)
				{
					if (pt[a].x >= x && pt[a].x <= x + sz && pt[a].y >= y && pt[a].y <= y + sz)
					{
						--covered[a];
					}
				}
			}
		}
	}
	return rv;
}

void GoogleCodeJam::Practice::Contest::SquareFields()
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
			point_t p;
			std::cin >> p.x >> p.y;
			assert(p.x >= 0 && p.x < 64000 && p.y >= 0 && p.y < 64000);
			points.push_back(p);
		}

		std::sort(points.begin(), points.end());
		std::memset(covered, 0, sizeof(covered));
		
		int lo = 0, hi = 64000;
		while (lo < hi)
		{
			int mid = (lo + hi) / 2;
			if (iscovered(points, mid, n, k))
			{
				hi = mid;
			}
			else
			{
				lo = mid + 1;
			}
		}

		std::cout << "Case #" << a << ": " << lo << std::endl;
	}
}
