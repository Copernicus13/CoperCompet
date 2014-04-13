#include <string>
#include <iostream>
#include <sstream>
#include <stack>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Y2010::Africa::ReverseWords()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	std::cin.ignore();
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		string s;
		std::stringstream ss;
		std::stack<string> r;

		std::getline(std::cin, s);
		ss.str(s);

		while (ss >> s)
		{
			r.push(s);
		}
		
		std::cout << "Case #" << a << ":";
		do
		{
			std::cout << ' ' << r.top();
			r.pop();
		}
		while (!r.empty());
		std::cout << std::endl;
	}
}
