/*
	Find the largest possible value of N where the standard deviation of the values in the
	set {1,2,3,N} is equal to the standard deviation of the values in the set {1,2,3}.
*/

#include <iostream>
#include <iomanip>
#include <vector>
#include <algorithm>
#include <cmath>

#include "Prototypes.h"
#include "../../Libraries/Maths/include/Maths.h"

using namespace std;

void
HackerRank::AI::ProbabilityAndStatistics::StandardDeviation1()
{
	vector<double> list = { 1, 2, 3 };
	auto goal = Maths::Stats::PopStandardDeviation(list);

	double d(0), result(0);
	list.push_back(d);
	while (d < 10)
	{
		auto actual = Maths::Stats::PopStandardDeviation(list);
		if (abs(goal - actual) < 0.0001)
			result = max(result, d);
		d += .001;
		list[3] = d;
	}

	cout << fixed << setprecision(2) << result << endl;
}
