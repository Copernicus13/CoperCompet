#include "Prototypes.h"

static const char* const tab[27] =
{
	"2", "22", "222",			// ABC
	"3", "33", "333",			// DEF
	"4", "44", "444",			// GHI
	"5", "55", "555",			// JKL
	"6", "66", "666",			// MNO
	"7", "77", "777", "7777",	// PQRS
	"8", "88", "888",			// TUV
	"9", "99", "999", "9999",	// WXYZ
	"0"							// Space
};

void GoogleCodeJam::Y2010::Africa::T9Spelling()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	std::cin.ignore();
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		std::cout << "Case #" << a << ": ";
		char l = -1;
		for (char c (static_cast<char>(std::cin.get()));
			 c != '\n';
			 c = static_cast<char>(std::cin.get()))
		{
			if (c == 32)
			{
				c += 'a' - ' ' + 26;
			}
			if (tab[c - 97][0] == l)
			{
				std::cout << ' ';
			}
			std::cout << tab[c - 97];
			l = tab[c - 97][0];
		}
		std::cout << std::endl;
	}
}
