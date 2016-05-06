#include "Prototypes.h"

typedef std::map<string, bool> dict_t;

void GoogleCodeJam::Y2008::Qualification::SavingUniverse()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 20);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int S;
		std::cin >> S;
		std::cin.ignore();
		assert(S >= 2 && S <= 100);

		dict_t motors;
		for (unsigned int b (0); b < S; ++b)
		{
			string s;
			std::getline(std::cin, s);
			motors[s] = false;
		}

		unsigned int Q;
		std::cin >> Q;
		std::cin.ignore();
		assert(Q >= 0 && Q <= 1000);

		unsigned int res = 0;
		for (unsigned int b (0); b < Q; ++b)
		{
			string s;
			std::getline(std::cin, s);
			if (!motors[s])
			{
				motors[s] = true;
				if (std::all_of(motors.begin(), motors.end(), [](std::pair<string, bool> const &i) { return i.second; }))
				{
					++res;
					std::for_each(motors.begin(), motors.end(), [](std::pair<const string, bool> &i) { i.second = false; });
					motors[s] = true;
				}
			}
		}

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
