#include "Prototypes.h"

void GoogleCodeJam::Y2015::Qualification::OminousOmino()
{
	unsigned int T;

	std::cin >> T;
	assert(T >= 1 && T <= 100);

	for (unsigned int a (1); a <= T; ++a)
	{
		unsigned int X, R, C;
		std::cin >> X >> R >> C;
		assert(X >= 1 && X <= 20);
		assert(R >= 1 && R <= 20);
		assert(C >= 1 && C <= 20);

		string winner;

		if (X == 1)
		{
			winner = "GABRIEL";
		}
		else if (X == 2)
		{
			if ((R * C) % 2 == 1)
				winner = "RICHARD";
			else
				winner = "GABRIEL";
		}
		else if (X == 3)
		{
			if (R * C <= 4 || R * C % 3)
				winner = "RICHARD";
			else
				winner = "GABRIEL";
		}
		else if (X == 4)
		{
			if (R * C <= 9 || R * C % 4)
				winner = "RICHARD";
			else
				winner = "GABRIEL";
		}
		else if (X == 5)
		{
			if (R < 3 || C < 3 || R * C % 5)
				winner = "RICHARD";
			else
				winner = "GABRIEL";
		}
		else if (X == 6)
		{
			if (R < 3 || C < 3 || R * C % 6 || R * C != 12)
				winner = "RICHARD";
			else
				winner = "GABRIEL";
		}
		else
		{
			winner = "RICHARD";
		}

		std::cout << "Case #" << a << ": " << winner << std::endl;
	}
}