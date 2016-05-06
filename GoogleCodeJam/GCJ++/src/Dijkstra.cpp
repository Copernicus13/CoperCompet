#include "Prototypes.h"

enum enm_t
{
	u = 1,
	i,
	j,
	k
};

static const int tab[4][4] =
	{
		u,  i,  j,  k,
		i, -u, -k,  j,
		j,  k, -u, -i,
		k, -j,  i, -u
	};

static bool compute(unsigned int enm, string s)
{
	bool minus = false;
	unsigned int result = s[0] - 'i' + 2;
	for (unsigned int a (1); a < s.size(); ++a)
	{
		int tmp = tab[s[a] - 'i' + 1][result - 1];
		minus ^= tmp < 0;
		result = std::abs(tmp);
	}
	return result == enm && !minus;
}

static string trim(string s)
{
	std::ostringstream os;
	unsigned int a (0);
	while (a + 4 < s.size())
	{
		os << s[a];
		if (s[a] == s[a + 1] && s[a] == s[a + 2] && s[a] == s[a + 3] && s[a] == s[a + 4])
			a += 5;
		else
			++a;
	}
	for (unsigned int b (0); b < s.size() - a; ++b)
		os << s[a + b];

	//if (os.str().size() > 1000)
	//	return trim(os.str());

	return os.str();
}

#if 0
static bool findRec(string s, unsigned int enm, unsigned int idx)
{
	if (s.size() == 0)
		return enm == k + 1 ? true : false;

	if (idx > s.size())
		return false;

	if (compute((enm_t)enm, s.substr(0, idx)))
		return findRec(s.substr(idx), ++enm, 1);

	return findRec(s, enm, ++idx);
}
#else
static bool findIte(string s)
{
	for (unsigned int a (1); a <= s.size(); ++a)
	{
		if (compute(i, s.substr(0, a)))
		{
			for (unsigned int b (1); b <= s.substr(a, b).size(); ++b)
			{
				if (compute(j, s.substr(a, b)))
				{
					for (unsigned int c (1); c <= s.substr(a + b, c).size(); ++c)
					{
						if (compute(k, s.substr(a + b, c)))
						{
							if (a + b + c == s.size())
								return true;
						}
					}
				}
			}
		}
	}
	return false;
}
#endif

void GoogleCodeJam::Y2015::Qualification::Dijkstra()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int L, X;

		std::cin >> L >> X;
		std::cin.ignore();

		string s;
		s.reserve(X);
		std::getline(std::cin, s);
		std::ostringstream os;
		for (unsigned int b (0); b < X; ++b)
			os << s;

		s = trim(os.str());

		if (findIte(s))
		//if (findRec(s, i, 1))
			std::cout << "Case #" << a << ": YES" << std::endl;
		else
			std::cout << "Case #" << a << ": NO" << std::endl;
	}
}
