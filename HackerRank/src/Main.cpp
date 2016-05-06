// Main.cpp : définit le point d’entrée pour l’application console.
//

#include <cstdlib>
#include <cstring>
#include <algorithm>

#include "Prototypes.h"

typedef void(*PtrFonct_t)();
typedef struct { PtrFonct_t func; const char* name; } funct;

static const funct tabfct[] =
{
	{ HackerRank::AI::ProbabilityAndStatistics::StandardDeviation1, "StandardDeviation1" },
	{ HackerRank::AI::ProbabilityAndStatistics::StandardDeviation2, "StandardDeviation2" },
	{ HackerRank::AI::ProbabilityAndStatistics::BasicProbability1, "BasicProbability1" },
	{ HackerRank::AI::ProbabilityAndStatistics::BasicProbability2, "BasicProbability2" },
	{ HackerRank::AI::ProbabilityAndStatistics::BasicProbability3, "BasicProbability3" },
	{ HackerRank::AI::ProbabilityAndStatistics::BasicProbability4, "BasicProbability4" },
};

class GetFunc
{
public:
	static char* name;

	static bool FindIt(const funct i)
	{
		return strcmp(i.name, name) == 0;
	}
};

char* GetFunc::name = NULL;

int main(int argc, char* argv[])
{
	std::ios_base::sync_with_stdio(false);

	if (argc != 2)
	{
		return EXIT_FAILURE;
	}

#ifdef _DEBUG
	std::system((string("title ") + argv[1]).c_str());
#endif

	GetFunc::name = argv[1];
	const funct* p = std::find_if(tabfct, tabfct + sizeof(tabfct) / sizeof(funct), GetFunc::FindIt);
	if (p != tabfct + sizeof(tabfct) / sizeof(funct))
		p->func();

#ifdef _DEBUG
	std::system("pause");
#endif

	return EXIT_SUCCESS;
}
