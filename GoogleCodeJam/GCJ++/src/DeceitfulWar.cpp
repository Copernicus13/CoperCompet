#if 1

#include "Prototypes.h"

typedef std::vector<double> vect_t;
typedef std::deque<double> queue_t;

unsigned int war(const vect_t &naomi, const vect_t &ken)
{
	unsigned int res (0);

	queue_t naomiq (naomi.begin(), naomi.end()),
			kenq (ken.begin(), ken.end());

	std::sort(kenq.begin(), kenq.end());

	while (!naomiq.empty())
	{
		queue_t::value_type d (naomiq.front());
		naomiq.pop_front();
		queue_t::const_iterator e (std::upper_bound(kenq.begin(), kenq.end(), d));
		if (e == kenq.end())
		{
			++res;
			e = kenq.begin();
		}
		kenq.erase(e);
	}
	return res;
}

unsigned int deceitfulwar(vect_t &naomi, vect_t &ken)
{
	unsigned int res (static_cast<int>(naomi.size()));

	//vect_t naomiv (naomi.begin(), naomi.end()),
	//	   kenv (ken.begin(), ken.end());

	std::sort(naomi.begin(), naomi.end()); //, std::greater<queue_t::value_type>());
	std::sort(ken.begin(), ken.end());

	for (vect_t::size_type i (0); i < naomi.size(); ++i)
		if (naomi[i] < ken[0])
			--res;

	//while (!naomi.empty())
	//{
	//	vect_t::value_type d (naomiv.front());
	//	//naomiq.pop_front();
	//	vect_t::const_iterator e (std::upper_bound(kenv.begin(), kenv.end(), d));
	//	//naomiq.pop_back();
	//	//kenq.pop_front();

	//	if (d < naomiv.front())
	//		++res;
	//}

	return res;

	/*queue_t naomiq (naomi.begin(), naomi.end()),
			kenq (ken.begin(), ken.end());

	std::sort(naomiq.begin(), naomiq.end());
	std::sort(kenq.begin(), kenq.end());

	while (!naomiq.empty())
	{
		double d (naomiq.front()), e (kenq.front());
		naomiq.pop_front();
		kenq.pop_front();

		if (e == kenq.end())
		{
			++res;
			e = kenq.begin();
		}
		kenq.erase(e);
	}
	return res;*/
}

void GoogleCodeJam::Y2014::Qualification::DeceitfulWar()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 50);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int nbBlocks;

		std::cin >> nbBlocks;
		assert(nbBlocks >= 1 && nbBlocks <= 1000);

		vect_t naomi, ken;
		naomi.reserve(nbBlocks);
		ken.reserve(nbBlocks);

		for (unsigned int b (0); b < nbBlocks; ++b)
		{
			vect_t::value_type d;
			std::cin >> d;
			naomi.push_back(d);
		}

		for (unsigned int b (0); b < nbBlocks; ++b)
		{
			vect_t::value_type d;
			std::cin >> d;
			ken.push_back(d);
		}

		unsigned int war		  (war(naomi, ken)),
					 deceitfulWar (deceitfulwar(naomi, ken));

		std::cout << "Case #" << a << ": " << deceitfulWar << ' ' << war << std::endl;
	}
}

#else

#define _CRT_SECURE_NO_WARNINGS

#include <vector>
#include <list>
#include <map>
#include <set>
#include <deque>
#include <stack>
#include <bitset>
#include <algorithm>
#include <functional>
#include <numeric>
#include <utility>
#include <sstream>
#include <iostream>
#include <iomanip>
#include <cstdio>
#include <cmath>
#include <cstdlib>
#include <ctime>

#include "Prototypes.h"

using namespace std;

pair <double, int> a[123456];

void GoogleCodeJam::Y2014::Qualification::DeceitfulWar()
{
  int tt;
  scanf("%d", &tt);
  for (int qq=1;qq<=tt;qq++) {
    printf("Case #%d: ", qq);
    int n;
    cin >> n;
    for (int i = 0; i < n; i++) {
      cin >> a[i].first;
      a[i].second = 1;
    }
    for (int i = 0; i < n; i++) {
      cin >> a[i + n].first;
      a[i + n].second = -1;
    }
    sort(a, a + n + n);
    int z = 0, cz = 0;
    for (int i = n + n - 1; i >= 0; i--) {
      cz += a[i].second;
      if (cz > z) z = cz;
    }
    int y = 0, bal = 0;
    for (int i = n + n - 1; i >= 0; i--) {
      if (a[i].second == 1) {
        bal++;
      } else {
        if (bal > 0) {
          bal--;
          y++;
        }
      }
    }
    printf("%d %d\n", y, z);
  }
}

#endif