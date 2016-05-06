/*
    There are 3 urns : X, Y and Z.

    Urn X contains 4 red balls and 3 black balls.
    Urn Y contains 5 red balls and 4 black balls.
    Urn Z contains 4 red balls and 4 black balls.

    One ball is drawn from each urn.
	What is the probability that the 3 balls drawn consist of 2 red balls and 1 black ball ?
*/

#include <iostream>
#include <boost\rational.hpp>

#include "Prototypes.h"


using namespace std;
using namespace boost;

void
HackerRank::AI::ProbabilityAndStatistics::BasicProbability3()
{
	rational<int>
		probXRed(4, 7), probXBlack(3, 7),
		probYRed(5, 9), probYBlack(4, 9),
		probZRed(4, 8), probZBlack(4, 8);

	rational<int> result = probXRed * probYRed * probZBlack +
		probXBlack * probYRed * probZRed +
		probXRed * probYBlack * probZRed;

	cout << result << endl;
}
