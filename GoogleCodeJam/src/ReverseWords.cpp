#include <string>
#include <iostream>
#include <sstream>
#include <stack>
#include <cassert>

#include "Prototypes.h"

void GoogleCodeJam::Y2010::Africa::ReverseWords()
{
	int nbCases;

	std::cin >> nbCases;
	std::cin.ignore();
	assert(nbCases >= 1 && nbCases <= 100);

	for (int a (1); a <= nbCases; ++a)
	{
		std::string s;
		std::stringstream ss;
		std::stack<std::string> r;

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
