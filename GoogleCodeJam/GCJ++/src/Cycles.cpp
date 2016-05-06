#include <iostream>
#include <vector>
#include <deque>
#include <algorithm>
#include <utility>
#include <iterator>
#include <cmath>
#include <cstring>
#include <deque>
#include <cassert>

#include "Prototypes.h"

typedef std::pair<int, int> vertex_t;
typedef std::vector<vertex_t> list_t;
typedef std::vector<list_t> tab_t;
typedef std::vector<int> vint_t;

static int fact(int i)
{
	if (i == 1)
		return 1;
	return fact(i - 1) * i;
}

//static bool isforbidden(list_t f, vertex_t v)
//{
//	for (list_t::size_type x (0); x < f.size(); ++x)
//	{
//		if (f[x].first == v.first && f[x].second == v.second)
//		{
//			return true;
//		}
//	}
//	return false;
//}

static int hamiltonian(vint_t s, list_t f)
{
	//int c = 0;
	//tab_t t;

	//s.pop_front();
	//vint_t v;
	//v.reserve(n);
	//v.push_back(1);
	
	//for (int i (1); i <= n; ++n)
	//{
	//	s.push_back(i);
	//}
	//for (int i (0); i < n; ++n)
	//{
	//	for (int i = 2; i <= n; ++n)
	//	{
	//		if (isforbidden(f, std::make_pair(s.back(), i)))
	//			continue;
	//		v.push_back(i);
	//	}
	//}
	return -1;
}

void GoogleCodeJam::Practice::Contest::Cycles()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 10);

	for (int a (1); a <= nbCases; ++a)
	{
		int n, k;

		std::cin >> n;
		assert(n >= 3 && n <= 300);
		std::cin >> k;
		assert(k >= 0 && k <= 15);

		list_t f;
		f.reserve(k);

		for (int b (0); b < n; ++b)
		{
			vertex_t v;
			std::cin >> v.first >> v.second;
			f.push_back(v);
		}

		vint_t s(n);
		for (int b (0); b < n; ++b)
		{
			s[b] = b + 1;
		}
		int res = hamiltonian(s, f);

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
