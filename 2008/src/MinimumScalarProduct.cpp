#include <iterator>
#include <algorithm>
#include <vector>
#include <iostream>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Y2008::MinimumScalarProduct()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 1000);

	for (int a (1); a <= nbCases; ++a)
	{
		int n;

		std::cin >> n;
		assert(nbCases >= 1 && nbCases <= 800);
 
		std::vector<int> v1;
		v1.reserve(n);
		std::vector<int> v2;
		v2.reserve(n);

		for (int b (0); b < n; ++b)
		{
			int c;
			std::cin >> c;
			v1.push_back(c);
		}
		for (int b (0); b < n; ++b)
		{
			int c;
			std::cin >> c;
			v2.push_back(c);
		}

		std::sort(v1.begin(), v1.end());
		std::sort(v2.begin(), v2.end());
		std::reverse(v2.begin(), v2.end());

		long long int res = 0;
		for (std::vector<int>::const_iterator i1 (v1.begin()), i2 (v2.begin());
			 i1 != v1.end() && i2 != v2.end();
			 ++i1, ++i2)
		{
			res += static_cast<long long int>(*i1) * (*i2);
		}

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
