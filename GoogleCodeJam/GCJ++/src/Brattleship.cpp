#include "Prototypes.h"

static unsigned int getResult(unsigned int C, unsigned int W)
{
	if (W == C)
		return W;
	if (C / W >= 2)
		return getResult(C - W, W) + 1;

	return W + 1;
}

void GoogleCodeJam::Y2015::Round1C::Brattleship()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int R, C, W;
		std::cin >> R >> C >> W;

		int rep = R * getResult(C, W);
		std::cout << "Case #" << a << ": " << rep << std::endl;
	}
}