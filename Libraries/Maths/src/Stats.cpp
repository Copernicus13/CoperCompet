#include "Maths.h"
#include <cmath>
#include <numeric>

using namespace std;

double
Maths::Stats::PopStandardDeviation(const vector<double>& input)
{
	double mean = accumulate(input.begin(), input.end(), 0.0) / input.size();
	double sq_sum = inner_product(input.begin(), input.end(), input.begin(), 0.0);
	return sqrt(sq_sum / input.size() - mean * mean);
}
