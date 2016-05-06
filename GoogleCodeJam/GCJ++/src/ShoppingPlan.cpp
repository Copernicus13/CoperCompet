#if 1

#include "Prototypes.h"

typedef struct { short x, y; double getNorm() { return std::sqrt(static_cast<double>(x) * x + y * y); } } point_t;
typedef struct { std::map<string, unsigned int> items; point_t location; } store_t;
typedef std::array<std::array<std::array<double, 2>, 1 << 15>, 51> tab_t;

static tab_t F;

static double getNorm(point_t const &a, point_t const &b)
{
	return std::sqrt(std::pow(static_cast<double>(b.x) - a.x, 2) + std::pow(static_cast<double>(b.y) - a.y, 2));
}

static double getMin(std::vector<store_t> &stores, std::vector<string> const &items,
	std::vector<bool> const &perishable, unsigned int prcGaz, unsigned int mask, unsigned int cur, unsigned int b)
{
	double& ret = F[cur][mask][b];
	if (ret == -1)
	{
		//std::clog << '>' << mask << ' ' << cur << ' ' << b << ' ' << ret << std::endl;
		ret = std::numeric_limits<double>::max();
		if (mask == 0)
		{
			if (cur == stores.size() - 1)
				ret = 0;
			return ret;
		}
		for (unsigned int i (0); i < items.size(); ++i)
		{
			if ((mask & 1 << i) && stores[cur].items.count(items[i]) != 0)
			{
				for (unsigned int j (0); j < stores.size(); ++j)
				{
					unsigned int tmp = mask ^ (1 << i);
					if (j == cur)
					{
						ret = std::min(ret, getMin(stores, items, perishable, prcGaz, tmp, j, b || perishable[i]) +
							stores[cur].items[items[i]]);
					}
					else if (b || perishable[i])
					{
						ret = std::min(ret, getMin(stores, items, perishable, prcGaz, tmp, j, 0) +
							stores[cur].items[items[i]] + (stores[cur].location.getNorm() + stores[j].location.getNorm()) * prcGaz);
					}
					else
					{
						ret = std::min(ret, getMin(stores, items, perishable, prcGaz, tmp, j, 0) +
							stores[cur].items[items[i]] + getNorm(stores[cur].location, stores[j].location) * prcGaz);
					}
				}
			}
		}
		//std::clog << '<' << mask << ' ' << cur << ' ' << b << ' ' << ret << std::endl;
	}
	return ret;
}

void GoogleCodeJam::Practice::Problems::ShoppingPlan()
{
	std::cout.setf(std::ios::fixed, std::ios::floatfield);
	std::cout.precision(7);

	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int nbItems, nbStores, prcGaz;

		std::cin >> nbItems >> nbStores >> prcGaz;
		assert(nbItems >= 1 && nbItems <= 15);
		assert(nbStores >= 1 && nbStores <= 50);
		assert(prcGaz >= 1 && prcGaz <= 1000);

		std::vector<string> items;
		std::vector<bool> perishable;
		perishable.reserve(nbItems);
		for (unsigned int b (0); b < nbItems; ++b)
		{
			string s;
			std::cin >> s;

			if (s.back() == '!')
			{
				perishable.push_back(true);
				s = s.substr(0, s.length() - 1);
			}
			else
				perishable.push_back(false);
			items.push_back(s);
		}

		std::vector<store_t> stores;
		stores.reserve(nbStores);

		std::cin.ignore();
		for (unsigned int b (0); b < nbStores; ++b)
		{
			store_t st;
			string str;

			std::getline(std::cin, str);
			std::istringstream iss (str);

			iss >> st.location.x >> st.location.y;
			iss.ignore();
			do
			{
				unsigned int prc;
				std::getline(iss, str, ':');
				iss >> prc;
				iss.ignore();
				st.items[str] = prc;
			} while (!iss.eof());

			stores.push_back(st);
		}

		for (tab_t::size_type b (0); b < F.size(); ++b)
			for (tab_t::value_type::size_type c (0); c < F[b].size(); ++c)
				for (tab_t::value_type::value_type::size_type d (0); d < F[b][c].size(); ++d)
					F[b][c][d] = -1;

		store_t st;
		point_t k = { 0, 0 };
		st.location = k;
		stores.push_back(st);

		double res = std::numeric_limits<double>::max();

		for (unsigned int b (0); b < nbStores; ++b)
			res = std::min(res, getMin(stores, items, perishable, prcGaz, (1 << nbItems) - 1, b, 0) +
				getNorm(k, stores[b].location) * prcGaz);

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}

#else

#include <iostream>
#include <sstream>
#include <fstream>
#include <algorithm>
#include <vector>
#include <list>
#include <string>
#include <map>
#include <set>
#include <queue>
#include <stack>
#include <complex>
#include <cstdio>
#include <cassert>
#include <cmath>

#include "Prototypes.h"

using namespace std;

#define FOR(i,a,b) for(int i=(a),_b=(b);i<=_b;i++)
#define REP(i,n) FOR(i,0,(n)-1)
#define FORD(i,a,b) for(int i=(a),_b=(b);i>=_b;i--)
#define sz size()
template<class T> inline int size(const T& c) { return c.sz; }
#define FORA(i,c) REP(i,size(c))

#define itype(c) __typeof((c).begin())
#define FORE(e,c) for(itype(c) e=(c).begin();e!=(c).end();e++)
#define pb push_back
#define X first
#define Y second
#define mp make_pair
#define all(x) (x).begin(),(x).end()
#define SORT(x) sort(all(x))
#define REVERSE(x) reverse(all(x))
#define CLEAR(x,c) memset(x,c,sizeof(x)) 

typedef long long LL;
typedef vector<int> VI;
typedef vector<VI> VVI;
typedef vector<string> VS;
LL s2i(string s) { istringstream i(s); LL x; i>>x; return x; }
template<class T> string i2s(T x) { ostringstream o; o << x; return o.str(); }

#define pi acos(-1.)
#define eps 1e-7
#define inf 1e17
#define maxn 100
#define maxp 1100000

typedef complex<double> point;
#define x real()
#define y imag()

int n,m;
double price;
string name[maxn];
bool bad[maxn];
point P[maxn];
int M[maxn][maxn];

double F[1 << 15][51][2];

double f(int mask,int cur,int b) {
  double& ret = F[mask][cur][b];
  if(ret==-1) {
	  std::clog << '>' << mask << ' ' << cur << ' ' << b << ' ' << ret << std::endl;
    ret = inf;
    if(mask==0) {
      if(cur==m-1) ret=0;
      return ret;
    }
    REP(i,n) if((mask&1<<i) && M[cur][i]!=-1) REP(j,m) {
	int tmp = mask^(1<<i);
	if(j==cur) {
	  ret = std::min(ret, f(tmp,j,b||bad[i])+M[cur][i]);
	}
	else if(bad[i] || b) {
	  ret = std::min(ret, f(tmp,j,0)+M[cur][i]+(abs(P[cur])+abs(P[j]))*price);
	}
	else {
	  ret = std::min(ret, f(tmp,j,0)+M[cur][i]+abs(P[j]-P[cur])*price);
	}
      }
	std::clog << '<' << mask << ' ' << cur << ' ' << b << ' ' << ret << std::endl;
  }
  return ret;
}

void GoogleCodeJam::Practice::Problems::ShoppingPlan()
{
  int T;
  cin>>T;
  for(int C=1; C<=T; C++) {
    cin>>n>>m>>price;
    REP(i,n) {
      cin>>name[i];
      bad[i]=0;
      if(name[i][name[i].length()-1]=='!') {
	bad[i]=1;
	name[i]=name[i].substr(0,name[i].length()-1);
      }
    }
    string s;
    getline(cin,s);
    memset(M,-1,sizeof(M));
    REP(i,m) {
      getline(cin,s);
      istringstream ss(s);
	  double w1, w2;
      ss>> w1 >> w2;
	  P[i].real(w1);
	  P[i].imag(w2);
      string t;
      while(ss>>t) {
	int k = t.find(':');
	int p = atoi(t.substr(k+1).c_str());
	t = t.substr(0,k);
	REP(j,n) if(t==name[j]) {
	  M[i][j] = p;
	  break;
	}
      }
    }
    P[m++]=point(0,0);

    REP(i,1<<n) REP(j,m) REP(k,2) F[i][j][k]=-1;
    double sol = inf;
    REP(i,m) {
      sol = std::min(sol, f((1<<n)-1,i,0)+abs(P[i])*price);
    }
    printf("Case #%d: %.7f\n",C,sol);
  }
}


#endif