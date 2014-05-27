#include "Prototypes.h"

typedef std::vector<string> lists_t;

static int doit(lists_t &str, unsigned int N)
{
	int res (0);

	int t[26][100];

	std::memset(t, -1, sizeof (t));

	for (unsigned int b (0); b < str.size(); ++b)
	{
		for (unsigned int c (0); c < str[b].size(); ++c)
		{
			if (t[str[b][c] - 'a'][b] == -1)
			{
				t[str[b][c] - 'a'][b] = (int)std::count(str[b].begin(), str[b].end(), str[b][c]);
			}
		}
	}

	for (unsigned int b (0); b < 26; ++b)
		for (unsigned int c (0); c < N; ++c)
			for (unsigned int d (0); d < N; ++d)
				if (t[b][c] == -1 && t[b][d] != -1)
					return -1;

	for (unsigned int b (0); b < 26; ++b)
		if (t[b][0] != -1)
		{
			unsigned int tmp (0);
			for (unsigned int c (0); c < N; ++c)
			{
				tmp += t[b][c];
			}
			if (double(tmp) / N > 1)
			{
				res += (int)(double(tmp) / N);
			}
		}

	return res;
}

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

		lists_t str;

		for (unsigned int b (0); b < N; ++b)
		{
			string s;
			std::cin >> s;
			str.push_back(s);
		}

		bool res (true);
		for (unsigned int b (0); b < N; ++b)
		{
			if (str[b] != str[0])
			{
				res = false;
				break;
			}
		}
		if (res)
		{
			std::cout << "Case #" << a << ": 0" << std::endl;
			continue;
		}

		int res2 (doit(str, N));

		if (res2 == -1)
			std::cout << "Case #" << a << ": Fegla Won" << std::endl;
		else
			std::cout << "Case #" << a << ": " << res2 << std::endl;
	}
}
