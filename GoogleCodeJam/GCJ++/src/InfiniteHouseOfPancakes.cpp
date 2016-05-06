#include "Prototypes.h"

#if 0
typedef std::vector<unsigned int> tab_t;

static int split(unsigned int i, unsigned int &rest)
{
	if (i > 3)
	{
		unsigned int tmp1 = 0, tmp2 = 0;
		unsigned int res = split(i / 2 + i % 2, tmp1) + 1;

		if (i / 2 > 3)
			res += split(i / 2, tmp2);

		rest = std::max(tmp1, tmp2);
		return res;
	}
	rest = i;
	return 0;
}

void GoogleCodeJam::Y2015::Qualification::InfiniteHouseOfPancakes()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int nbDiners;
		std::cin >> nbDiners;

		tab_t tab;
		tab.resize(nbDiners);

		for (unsigned int b (0); b < nbDiners; ++b)
		{
			unsigned int nbPancakes;
			std::cin >> nbPancakes;
			tab[b] = nbPancakes;
		}

		unsigned int result = 0;
		unsigned int rest = 0;

		for (unsigned int b (0); b < nbDiners; ++b)
		{
			unsigned int tmp = tab[b];
			if (tab[b] > 3)
				result += split(tab[b], tmp);
			rest = std::max(rest, tmp);
		}

		std::cout << "Case #" << a << ": " << result + rest << std::endl;
	}
}
#endif

using namespace std;

void GoogleCodeJam::Y2015::Qualification::InfiniteHouseOfPancakes()
{
	int T;
	cin >> T;
	for(int t = 1; t <= T; t++){
		int n;
		cin >> n;
		int stuff[1000];
		for(int i = 0; i < n; i++) cin >> stuff[i];
		int answer = 1000;
		for(int i = 1; i <= 1000; i++){
			int cur = i;
			for(int j = 0; j < n; j++){
				cur += (stuff[j]-1)/i;
			}
			answer = min(answer, cur);
		}
		cout << "Case #" << t << ": ";
		cout << answer << endl;
	}
}