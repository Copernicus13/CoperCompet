#include "Prototypes.h"

#define pi acos(-1.)
#define eps 1e-7
#define inf 1LL<<32
#define maxn 1100

typedef long long int long_t;
typedef std::array<std::array<long_t, maxn>, maxn> tab_t;

static tab_t F;

/*
  f(d,b) = f(d-1,b)+f(d-1,b-1)+1
  f(d,0) = 0
  d(1,x) = 1
  
  f(d,1) = d
  f(d,2) = (d+1)*d/2
  f(d,3) = (d^2+5)*d/6
 */

static long_t g(long_t d,long_t b)
{
	b = std::min(b, d);
	if (d < maxn && b < maxn)
		return F[(int)d][(int)b];
	if (b == 0)
		return 0;
	if (b == 1)
		return d;
	if (b == 2)
	{
		long_t x = (d + 1) * d / 2;
		x = std::min(x, inf);
		return x;
	}
	if (b == 3)
	{
		long_t x = d * d + 5;
		x = std::min(x, inf);
		x *= d / 6;
		x = std::min(x, inf);
		return x;
	}
	return inf;
}

static long_t getd(long_t f,long_t d,long_t b)
{
	long_t low = 0, high = d;
	while (high - low > 1)
	{
		long_t m = (low + high) / 2;
		if (g(m, b) < f)
			low = m;
		else
			high = m;
	}
	return high;
}

static long_t getb(long_t f,long_t d,long_t b)
{
	b = std::min(b, d);
	long_t low = 0, high = b;
	while (high - low > 1)
	{
		long_t m = (low + high) / 2;
		if (g(d, m) < f)
			low = m;
		else
			high = m;
	}
	return high;
}

void GoogleCodeJam::Practice::Problems::EggDrop()
{
	for (int j = 1; j < maxn; ++j)
		F[1][j] = 1;
	for (int i = 1; i < maxn; ++i)
		for (int j = 1; j < maxn; ++j)
		{
			long_t x = F[i - 1][j - 1],
				   y = F[i - 1][j];
			if (x == inf || y == inf || x + y + 1 >= inf)
				F[i][j] = inf;
			else
				F[i][j] = x + y + 1;
		}

	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		long_t f, d, b, fmax, dmin, bmin;
		std::cin >> f >> d >> b;
		fmax = g(d, b);
		dmin = getd(f, d, b);
		bmin = getb(f, d, b);
		std::cout << "Case #" << a << ": "
			      << (fmax >= inf ? -1 : fmax) << ' ' << dmin << ' ' << bmin << std::endl;
	}
}