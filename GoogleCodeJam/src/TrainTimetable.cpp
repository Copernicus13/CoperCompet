#include "Prototypes.h"

typedef struct
{
	time_t dep;
	time_t arr;
	bool from;
} trp_t;
typedef std::vector<trp_t> list_t;

static bool operator <(trp_t const &t1, trp_t const &t2)
{
	return t1.dep < t2.dep;
}

static void todaytime(time_t &t, int hour, int minute)
{
	time_t now = time(NULL);
	struct tm tmp;
	localtime_s(&tmp, &now);

	tmp.tm_hour = hour;
	tmp.tm_min = minute;
	tmp.tm_sec = 0;

	t = mktime(&tmp);
}

static void doit(std::list<time_t> &t1, std::list<time_t> &t2, unsigned int &res, trp_t x, unsigned int t)
{
	bool found (false);
	std::list<time_t>::const_iterator y;
	for (y = t1.begin(); y != t1.end(); ++y)
	{
		if (std::difftime(x.dep, *y) >= 0)
		{
			found = true;
			break;
		}
	}
	if (found)
	{
		t1.erase(y);
	}
	else
	{
		++res;
	}
	t2.push_back(x.arr + t * 60);
}

void GoogleCodeJam::Y2008::Qualification::TrainTimetable()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int t, nA, nB;
		std::cin >> t >> nA >> nB;
		assert(t >= 0 && t <= 60);
		assert(nA >= 0 && nA <= 100);
		assert(nB >= 0 && nB <= 100);

		list_t j;
		j.reserve(nA + nB);
		for (unsigned int b (0); b < nA + nB; ++b)
		{
			trp_t trp;
			int c, d;
			std::cin >> c;
			std::cin.ignore();
			std::cin >> d;
			todaytime(trp.dep, c, d);

			std::cin >> c;
			std::cin.ignore();
			std::cin >> d;
			todaytime(trp.arr, c, d);
 
			trp.from = b >= nA; // false = A, true = B
			j.push_back(trp);
		}

		std::sort(j.begin(), j.end());

		std::list<time_t> tA;
		std::list<time_t> tB;

		unsigned int resA (0), resB (0);
		for (list_t::const_iterator x (j.begin()); x != j.end(); ++x)
		{
			if (!x->from)
			{
				doit(tA, tB, resA, *x, t);
			}
			else
			{
				doit(tB, tA, resB, *x, t);
			}
		}

		std::cout << "Case #" << a << ": " << resA << ' ' << resB << std::endl;
	}
}
