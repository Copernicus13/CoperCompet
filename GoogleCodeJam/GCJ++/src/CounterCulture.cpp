#include "Prototypes.h"

#if 1
static unsigned long long int twist(unsigned long long int nb)
{
	std::stringstream ss;
	ss << nb;
	string s(ss.str());
	ss.str("");
	for (string::const_reverse_iterator i1(s.crbegin()), i2(s.crend()); i1 != i2; ++i1)
		if (ss.str().length() > 0 || *i1 != '0')
			ss << *i1;
	unsigned long long int res;
	ss >> res;
	return res;
}

void GoogleCodeJam::Y2015::Round1B::CounterCulture()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a(1); a <= T; ++a)
	{
		unsigned long long int N;
		std::cin >> N;

		unsigned long long int b, rep;

		for (b = 1, rep = 1; b < N; ++b, ++rep)
		{
			if (N > 91 && b == 1)
			{
				b = 90;
				rep = 19;
				continue;
			}
			if (N > 901 && b == 91)
			{
				b = 900;
				rep = 36;
				continue;
			}
			if (N > 9901 && b == 901)
			{
				b = 9900;
				rep = 233;
				continue;
			}
			if (N > 99001 && b == 9901)
			{
				b = 99000;
				rep = 430;
				continue;
			}
			if (N > 999001 && b == 99001)
			{
				b = 999000;
				rep = 2427;
				continue;
			}
			unsigned long long int tmp = twist(b),
				tmp2 = twist(b + 1);

			if (tmp > b && tmp <= N && (tmp2 > N || tmp2 < tmp))
				b = tmp - 1;
		}

		std::cout << "Case #" << a << ": " << std::min(b, rep) << std::endl;
	}
}

#else

#include <cstdio>
#include <numeric>
#include <iostream>
#include <vector>
#include <set>
#include <cstring>
#include <string>
#include <map>
#include <cmath>
#include <ctime>
#include <algorithm>
#include <bitset>
#include <queue>
#include <sstream>
#include <deque>
#include <cassert>

using namespace std;

#define mp make_pair
#define pb push_back
#define rep(i,n) for(int i = 0; i < (n); i++)
#define re return
#define fi first
#define se second
#define sz(x) ((int) (x).size())
#define all(x) (x).begin(), (x).end()
#define sqr(x) ((x) * (x))
#define sqrt(x) sqrt(abs(x))
#define y0 y3487465
#define y1 y8687969
#define fill(x,y) memset(x,y,sizeof(x))
#define prev PREV

typedef vector<int> vi;
typedef long long ll;
typedef long double ld;
typedef double D;
typedef pair<int, int> ii;
typedef vector<ii> vii;
typedef vector<string> vs;
typedef vector<vi> vvi;

template<class T> T abs(T x) { re x > 0 ? x : -x; }

ll n;
int m;

ll rev(ll x) {
	ll y = 0;
	while (x) {
		y = y * 10 + x % 10;
		x /= 10;
	}
	re y;
}

ll get(ll x) {
	ll base = 1;
	while (base * base <= x) base *= 10;
	ll ans = 0;
	while (x >= 10) {
		while ((base / 10) * (base / 10) > x) base /= 10;
		ll y = x % base;
		if (y == 0) {
			ans++;
			x--;
		}
		else {
			ans += y;
			x -= y - 1;
			ll z = rev(x);
			if (x != z) x = z; else x--;
		}
	}
	re ans + x;
}

void GoogleCodeJam::Y2015::Round1B::CounterCulture()
{
	int tt;
	cin >> tt;
	for (int it = 1; it <= tt; it++) {
		cin >> n;
		cout << "Case #" << it << ": " << get(n) << endl;
		//cerr << it << " / " << tt << " = " << (double)clock() / CLOCKS_PER_SEC << " | " << ((double)clock() / it * tt) / CLOCKS_PER_SEC << endl;
	}
}

#endif