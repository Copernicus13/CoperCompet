#include <string>
#include <iostream>
#include <map>
#include <algorithm>
#include <cassert>

#include "Prototypes.h"

typedef std::map<std::string, bool> dict_t;

void GoogleCodeJam::Y2008::Qualification::SavingUniverse()
{
	int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 20);

	for (int a (1); a <= nbCases; ++a)
	{
		int S;
		std::cin >> S;
		std::cin.ignore();
		assert(S >= 2 && S <= 100);

		dict_t motors;
		for (int b (0); b < S; ++b)
		{
			std::string s;
			std::getline(std::cin, s);
			motors[s] = false;
		}

		int Q;
		std::cin >> Q;
		std::cin.ignore();
		assert(Q >= 0 && Q <= 1000);

		int res = 0;
		for (int b (0); b < Q; ++b)
		{
			std::string s;
			std::getline(std::cin, s);
			if (!motors[s])
			{
				motors[s] = true;
				if (std::all_of(motors.begin(), motors.end(), [](std::pair<std::string, bool> const &i) { return i.second; }))
				{
					++res;
					std::for_each(motors.begin(), motors.end(), [](std::pair<const std::string, bool> &i) { i.second = false; });
					motors[s] = true;
				}
			}
		}

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
