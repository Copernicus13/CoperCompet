#include <string>
#include <iostream>
#include <cmath>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Practice::Problems::AlienNumbers()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (int a (1); a <= nbCases; ++a)
	{
		std::string s1, s2, s3;

		std::cin >> s1 >> s2 >> s3;

		std::cout << "Case #" << a << ": ";

		int total (0);
		float base1 (static_cast<float>(s2.size()));
		float base2 (static_cast<float>(s3.size()));
		for (int b (0); b < static_cast<int>(s1.size()); ++b)
		{
			total += static_cast<int>(s2.find_first_of(s1[b])) *
				static_cast<int>(std::powl(base1, static_cast<int>(s1.size()) - b - 1));
		}

		int remainder (total);
		int len (0);
		for (int tmp (total); tmp != 0; tmp /= static_cast<int>(base2), ++len)
			;
		for (int b (0); b < len; ++b)
		{
			int t (static_cast<int>(std::powl(base2, len - b - 1)));
			std::cout << s3[remainder / t];
			remainder %= t;
		}
		std::cout << std::endl;
	}
}
