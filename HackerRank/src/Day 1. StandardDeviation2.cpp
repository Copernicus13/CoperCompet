/*
	The heights of a group of children are measured. The resulting data has a mean of
	0.675 meters, and a standard deviation of 0.065 meters.	One particular child is
	90.25 centimeters tall.	Compute z, the number of standard deviations away from the
	mean that the particular child is.
*/

#include <iostream>
#include <iomanip>
#include "Prototypes.h"

using namespace std;

void
HackerRank::AI::ProbabilityAndStatistics::StandardDeviation2()
{
	const float mean = 67.5f;
	const float sd = 6.5f;
	const float tallBoy = 90.25f;

	cout << fixed << setprecision(2) << (tallBoy - mean) / sd << endl;
}
