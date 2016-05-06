#include "Maths.h"
#include <utility>

unsigned long long int
Maths::Arithmetic::Factorial(unsigned int n)
{
	unsigned long long int result = 1;
	for (unsigned int i(1); i <= n; ++i)
		result *= i;
	return result;
}

unsigned int
Maths::Arithmetic::PGCD(unsigned int u, unsigned int v)
{
	// PGCD(0, v) == v; PGCD(u, 0) == u, PGCD(0, 0) == 0
	if (u == 0)
		return v;
	if (v == 0)
		return u;

	int shift;
	// Let shift := lg K, where K is the greatest power of 2
	// dividing both u and v.
	for (shift = 0; ((u | v) & 1) == 0; ++shift)
	{
		u >>= 1;
		v >>= 1;
	}

	while ((u & 1) == 0)
		u >>= 1;

	// From here on, u is always odd.
	do
	{
		// Remove all factors of 2 in v -- they are not common
		//   note: v is not zero, so while will terminate
		while ((v & 1) == 0)  // Loop X
			v >>= 1;

		// Now u and v are both odd. Swap if necessary so u <= v,
		// then set v = v - u (which is even). For bignums, the
		// swapping is just pointer movement, and the subtraction
		// can be done in-place.
		if (u > v)
			std::swap(u, v);

		v -= u;	// Here v >= u.
	} while (v != 0);

	// restore common factors of 2
	return u << shift;
}