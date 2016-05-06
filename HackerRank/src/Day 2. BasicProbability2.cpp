/*
    For a single toss of 2 fair (evenly-weighted) dice, find the probability that
	the values rolled by each die will be different and their sum is 6.
*/

#include <iostream>
#include <boost\rational.hpp>

#include "Prototypes.h"

using namespace std;
using namespace boost;

void
HackerRank::AI::ProbabilityAndStatistics::BasicProbability2()
{
	unsigned int num(0);

	for (unsigned int a(1); a <= 6; ++a)
		for (unsigned int b(1); b <= 6; ++b)
			if (a != b && a + b == 6)
				++num;

	rational<int> result(num, 6 * 6);

	cout << result << endl;
}
