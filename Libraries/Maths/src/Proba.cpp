#include "Maths.h"

using namespace std;

unsigned long long int
Maths::Proba::Combination(unsigned int nTotal, unsigned int kElems)
{
	return Maths::Arithmetic::Factorial(nTotal) /
		(Maths::Arithmetic::Factorial(kElems) * Maths::Arithmetic::Factorial(nTotal - kElems));
}

unsigned long long int
Maths::Proba::Permutation(unsigned int nTotal, unsigned int kElems)
{
	return Maths::Arithmetic::Factorial(nTotal) / Maths::Arithmetic::Factorial(nTotal - kElems);
}
