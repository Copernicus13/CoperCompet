#include "Prototypes.h"

void GoogleCodeJam::Y2014::Round1B::NewLotteryGame()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int A, B, K;
		std::cin >> A >> B >> K;
		assert(A >= 1 && A <= 1000000000);
		assert(B >= 1 && B <= 1000000000);
		assert(K >= 1 && K <= 1000000000);

		unsigned int res (0);

		for (unsigned int i (0); i < A; ++i)
			for (unsigned int j (0); j < B; ++j)
				if ((i & j) <= K - 1)
					++res;

		std::cout << "Case #" << a << ": " << res << std::endl;
	}
}