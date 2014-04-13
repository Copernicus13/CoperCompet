#include "Prototypes.h"

void GoogleCodeJam::Y2008::MinimumScalarProduct()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 1000);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int n;

		std::cin >> n;
		assert(n >= 1 && n <= 800);
 
		std::vector<int> v1;
		v1.reserve(n);
		std::vector<int> v2;
		v2.reserve(n);

		for (unsigned int b (0); b < n; ++b)
		{
			int c;
			std::cin >> c;
			v1.push_back(c);
		}
		for (unsigned int b (0); b < n; ++b)
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
