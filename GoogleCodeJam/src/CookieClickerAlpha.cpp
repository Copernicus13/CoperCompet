#if 1

#include "Prototypes.h"

static double doit(double c, double f, double x)
{
	double time (0), gain (2), nextbuy (c / gain);

	while ((time + x / gain) > (time + (x / (gain + f)) + (c / gain)))
	{
		time += nextbuy;
		gain += f;
		nextbuy = c / gain;
	}

	return time + x / gain;
}

void GoogleCodeJam::Y2014::Qualification::CookieClickerAlpha()
{
	std::cout.setf(std::ios::fixed, std::ios::floatfield);
	std::cout.precision(7);

	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		double c, f, x;

		std::cin >> c >> f >> x;
		assert(c >= 1 && c <= 10000);
		assert(f >= 1 && f <= 100);
		assert(x >= 1 && x <= 100000);

		double res = doit(c, f, x);
		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}

#else

#define _CRT_SECURE_NO_WARNINGS

#include "Prototypes.h"


using namespace std;


void GoogleCodeJam::Y2014::Qualification::CookieClickerAlpha()
{
  int tt;
  scanf("%d", &tt);
  for (int qq=1;qq<=tt;qq++) {
    printf("Case #%d: ", qq);
    double c, f, x;
    cin >> c >> f >> x;
    double spent = 0, ans = 1e30;
    int km = -1;
    double rate = 2.0;
    for (int farms = 0; farms <= 1000000; farms++) {
      double current = spent + x / rate;
      if (current < ans) {
        ans = current;
        km = farms;
      }
      spent += c / rate;
      rate += f;
    }
    printf("%.7lf\n", ans);
  }
}

#endif