#pragma once

#include <string>
#include <vector>

using std::string;

namespace Maths
{

namespace Arithmetic
{
	unsigned long long int Factorial(unsigned int n);
	unsigned int PGCD(unsigned int u, unsigned int v);
} // namespace Arithmetic

namespace Proba
{
	unsigned long long int Combination(unsigned int nTotal, unsigned int kElems);
	unsigned long long int Permutation(unsigned int nTotal, unsigned int kElems);
} // namespace Proba

namespace Stats
{
	double PopStandardDeviation(const std::vector<double>& input);
} // namespace Stats

} // namespace Maths