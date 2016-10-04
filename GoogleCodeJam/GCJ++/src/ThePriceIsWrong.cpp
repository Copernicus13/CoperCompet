#if 1

#include "Prototypes.h"

typedef std::vector<string> lists_t;
typedef std::vector<int> listi_t;
typedef std::array<std::array<bool, 64>, 64> tab_t;

void GoogleCodeJam::Practice::Beta2008::ThePriceIsWrong()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	std::cin.ignore();
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		string s;
		std::istringstream iss;

		std::getline(std::cin, s);
		lists_t products;
		iss.str(s);
		do
		{
			iss >> s;
			products.push_back(s);
		} while (!iss.eof());

		std::getline(std::cin, s);
		listi_t guesses;
		iss.str(s);
		iss.clear();
		do
		{
			int i;
			iss >> i;
			guesses.push_back(i);
		} while (!iss.eof());

		unsigned int sz (static_cast<unsigned int>(products.size()));
		tab_t F;
		listi_t v;
		v.reserve(sz);

		for (unsigned int b (0); b < 64; ++b)
			for (unsigned int c (0); c < 64; ++c)
				F[b][c] = false;

		for (unsigned int b (0); b < sz; ++b)
			for (unsigned int c (0); c < sz; ++c)
				F[b][c] = b <= c ? (guesses[b] <= guesses[c]) : (guesses[b] > guesses[c]);

		for (unsigned int b (0); b < sz; ++b)
			v.push_back(static_cast<int>(
				std::count_if(F[b].begin(), F[b].begin() + sz, [](bool &c) { return !c; })));

		int mx (64);
		bool bl (false);
		lists_t res;
		while (mx != 0)
		{
			for (unsigned int c (0); c < sz; ++c)
				if (v[c] == mx)
				{
					if (!bl)
					{
						res.push_back(products[c]);
						bl = true;
					}
					else
						bl = false;
				}
			bl = false;
			--mx;
		}

		std::cout << "Case #" << a << ':';

		std::sort(res.begin(), res.end());
		for (unsigned int b (0); b < (res.size() >> 1) + res.size() % 2; ++b)
			std::cout << ' ' << res[b];

		std::cout << std::endl;
	}
}

#else

#define _CRT_SECURE_NO_WARNINGS

#include <map>
#include <set>
#include <cmath>
#include <queue>
#include <vector>
#include <string>
#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <cassert>
#include <numeric>
#include <algorithm>
#include <iostream>
#include <sstream>
#include <ctime>

#include "Prototypes.h"

using namespace std;

typedef long long int64;
typedef vector<int> vi;
typedef vector<string> vs;
typedef vector<double> vd;

#define For(i,a,b) for (int i(a),_b(b); i <= _b; ++i)
#define Ford(i,a,b) for (int i(a),_b(b); i >= _b; --i)
#define Rep(i,n) for (int i(0),_n(n); i < _n; ++i)
#define Repd(i,n) for (int i((n)-1); i >= 0; --i)
#define Fill(a,c) memset(&a, c, sizeof(a))
#define MP(x, y) make_pair((x), (y))
#define All(v) (v).begin(), (v).end()

template<typename T, typename S> T cast(S s) {
	stringstream ss;
	ss << s;
	T res;
	ss >> res;
	return res;
}

template<typename T> inline T sqr(T a) { return a*a; }
template<typename T> inline int Size(const T& c) { return (int)c.size(); }
template<typename T> inline void checkMin(T& a, T b) { if (b < a) a = b; }
template<typename T> inline void checkMax(T& a, T b) { if (b > a) a = b; }
template<typename T> inline bool isSet(T number, int bit) { return (number&(T(1)<<bit)) != 0; }

char buf[1024*1024];
int n;
string name[64];
int price[64];
bool exist[64];
int dp[64];

int maxSubseq() {
	int res = 0;
	Rep(i, n) {
		if (exist[i]) {
			dp[i] = 1;
			Rep(j, i)
				if (exist[j] && price[j] < price[i])
					checkMax(dp[i], 1+dp[j]);
			checkMax(res, dp[i]);
		}
	}
	return res;
}

void solve() {
	scanf(" ");
	gets(buf);
	n = 0;
	string s(buf);
	istringstream iss(s);
	string s2;
	while (iss >> s2) 
		name[n++] = s2;
	Rep(i, n)
		scanf("%d", &price[i]);
	Rep(i, n)
		exist[i] = true;
	int k = maxSubseq();
	map<string,int> m;
	Rep(i, n)
		m[name[i]] = i;
	for (map<string,int>::iterator it = m.begin(); it != m.end(); ++it) {
		exist[(*it).second] = false;
		if (maxSubseq() == k)
			printf(" %s", (*it).first.c_str());
		else
			exist[(*it).second] = true;
	}
	printf("\n");
}

void GoogleCodeJam::Practice::Beta2008::ThePriceIsWrong()
{
	int n;
	scanf("%d", &n);
	For(test, 1, n) {
		printf("Case #%d:", test);
		solve();
	}

	exit(0);
}


#endif