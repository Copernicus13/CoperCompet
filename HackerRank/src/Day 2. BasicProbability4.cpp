/*
	Bag1 contains 4 red balls and 5 black balls.
	Bag2 contains 3 red balls and 7 black balls.

	One ball is drawn from the Bag1, and 2 balls are drawn from Bag2.
	Find the probability that 2 balls are black and 1 ball is red.
*/

#include <iostream>
#include <boost\rational.hpp>

#include "Prototypes.h"

using namespace std;
using namespace boost;

void
HackerRank::AI::ProbabilityAndStatistics::BasicProbability4()
{
	rational<int> probBag1Red(4, 9), probBag1Black(5, 9),
		probBag2Red(3, 10), probBag2Black(7, 10);

	rational<int> result =
		// B + RB
		probBag1Black *
		probBag2Red *
		rational<int>(probBag2Black.numerator(), probBag2Black.denominator() - 1) +
		// B + BR
		probBag1Black *
		probBag2Black *
		rational<int>(probBag2Red.numerator(), probBag2Red.denominator() - 1) +
		// R + BB
		probBag1Red *
		probBag2Black *
		rational<int>(probBag2Black.numerator() - 1, probBag2Black.denominator() - 1);

	cout << result << endl;
}
