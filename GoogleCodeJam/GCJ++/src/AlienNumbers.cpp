#include <string>
#include <iostream>
#include <cmath>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Practice::Problems::AlienNumbers()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		string s1, s2, s3;

		std::cin >> s1 >> s2 >> s3;

		std::cout << "Case #" << a << ": ";

		unsigned int total (0);
		float base1 (static_cast<float>(s2.size()));
		float base2 (static_cast<float>(s3.size()));
		for (unsigned int b (0); b < s1.size(); ++b)
		{
			total += static_cast<int>(s2.find_first_of(s1[b])) *
				static_cast<int>(std::powl(base1, static_cast<int>(s1.size()) - b - 1));
		}

		unsigned int remainder (total);
		unsigned int len (0);
		for (unsigned int tmp (total); tmp != 0; tmp /= static_cast<unsigned int>(base2), ++len)
			;
		for (unsigned int b (0); b < len; ++b)
		{
			unsigned int t (static_cast<unsigned int>(std::powl(base2, len - b - 1)));
			std::cout << s3[remainder / t];
			remainder %= t;
		}
		std::cout << std::endl;
	}
}
