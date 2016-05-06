#include "Prototypes.h"

typedef std::vector<string> lists_t;
typedef std::vector< std::vector<unsigned int> > tab_t;

static int levenshteinDistance(string str1, string str2)
{
	tab_t d;
	d.resize(str1.length() + 1);
	for (tab_t::iterator u(d.begin()); u != d.end(); ++u)
		u->resize(str2.length() + 1);

	for (unsigned int i (0); i < str1.length() + 1; ++i)
		d[i][0] = i;
	for (unsigned int j (0); j < str2.length() + 1; ++j)
		d[0][j] = j;

	unsigned int cost;

	for (unsigned int i(1); i < str1.length() + 1; ++i)
		for (unsigned int j(1); j < str2.length() + 1; ++j)
		{
			if (str1[i - 1] == str2[j - 1])
				cost = 0;
			else
				cost = 1;

			d[i][j] = std::min(std::min(d[i - 1][j] + 1, d[i][j - 1] + 1), d[i - 1][j - 1] + cost);
		}
	return d[str1.length()][str2.length()];
}

static string reduceStr(const string &str)
{
	string s;
	s = str[0];
	for (lists_t::value_type::const_iterator i1 (str.begin() + 1), i2 (str.end()); i1 != i2; ++i1)
		if (*i1 != s[s.length() - 1])
			s += *i1;
	return s;
}

//static int doit(lists_t &str, unsigned int N)
//{
//	int res (0);
//
//	int t[26][100];
//
//	std::memset(t, -1, sizeof (t));
//
//	for (unsigned int b (0); b < str.size(); ++b)
//	{
//		for (unsigned int c (0); c < str[b].size(); ++c)
//		{
//			if (t[str[b][c] - 'a'][b] == -1)
//			{
//				t[str[b][c] - 'a'][b] = (int)std::count(str[b].begin(), str[b].end(), str[b][c]);
//			}
//		}
//	}
//
//	for (unsigned int b (0); b < 26; ++b)
//		for (unsigned int c (0); c < N; ++c)
//			for (unsigned int d (0); d < N; ++d)
//				if (t[b][c] == -1 && t[b][d] != -1)
//					return -1;
//
//	for (unsigned int b (0); b < 26; ++b)
//		if (t[b][0] != -1)
//		{
//			unsigned int tmp (0);
//			for (unsigned int c (0); c < N; ++c)
//			{
//				tmp += t[b][c];
//			}
//			if (double(tmp) / N > 1)
//			{
//				res += (int)(double(tmp) / N);
//			}
//		}
//
//	return res;
//}

void GoogleCodeJam::Y2014::Round1B::TheRepeater()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int N;
		std::cin >> N;
		assert(N >= 2 && N <= 100);

		lists_t list;

		for (unsigned int b (0); b < N; ++b)
		{
			string s;
			std::cin >> s;
			list.push_back(s);
		}

		int res = 0;
		string s (reduceStr(list[0]));
		for (unsigned int b(1); b < N; ++b)
		{
			if (reduceStr(list[b]) != s)
			{
				res = -1;
				std::cout << "Case #" << a << ": Fegla Won" << std::endl;
				break;
			}
		}

		if (res == -1)
			continue;

		res = levenshteinDistance(list[0], list[1]);

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}
