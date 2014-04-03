// Main.cpp : définit le point d’entrée pour l’application console.
//

#include <cstdlib>
#include <cstring>
#include <map>
#include <algorithm>

#include "Prototypes.h"

typedef void (*PtrFonct_t)();
typedef struct { PtrFonct_t func; const char* name; } funct;

static const funct tabfct[] =
	{
		{ GoogleCodeJam::Practice::Problems::AlienNumbers , "AlienNumbers" },		// done
		{ GoogleCodeJam::Practice::Problems::AlwaysTurnLeft, "AlwaysTurnLeft" },
		{ GoogleCodeJam::Practice::Problems::EggDrop, "EggDrop" },
		{ GoogleCodeJam::Practice::Problems::ShoppingPlan, "ShoppingPlan" },
		{ GoogleCodeJam::Practice::Beta2008::TriangleTrilemma, "TriangleTrilemma" },
		{ GoogleCodeJam::Practice::Beta2008::ThePriceIsWrong, "ThePriceIsWrong" },
		{ GoogleCodeJam::Practice::Beta2008::RandomRoute, "RandomRoute" },
		{ GoogleCodeJam::Practice::Beta2008::HexagonGame, "HexagonGame" },
		{ GoogleCodeJam::Practice::Contest::OldMagician, "OldMagician" },			// done
		{ GoogleCodeJam::Practice::Contest::SquareFields, "SquareFields" },
		{ GoogleCodeJam::Practice::Contest::Cycles, "Cycles" },
		{ GoogleCodeJam::Y2008::Qualification::SavingUniverse, "SavingUniverse" },	// done
		{ GoogleCodeJam::Y2008::Qualification::TrainTimetable, "TrainTimetable" },	// done
		{ GoogleCodeJam::Y2008::Qualification::FlySwatter, "FlySwatter" },
		{ GoogleCodeJam::Y2008::MinimumScalarProduct, "MinimumScalarProduct" },		// done
		{ GoogleCodeJam::Y2008::Milkshakes, "Milkshakes" },							// done
		{ GoogleCodeJam::Y2008::Numbers, "Numbers" },
		{ GoogleCodeJam::Y2009::AlienLanguage, "AlienLanguage" },
		{ GoogleCodeJam::Y2010::Africa::ReverseWords, "ReverseWords" },				// done
		{ GoogleCodeJam::Y2010::Africa::StoreCredit, "StoreCredit" },				// done
		{ GoogleCodeJam::Y2010::Africa::T9Spelling, "T9Spelling" }					// done
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
	if (argc != 2)
	{
		return EXIT_FAILURE;
	}

	GetFunc::name = argv[1];
	const funct* p = std::find_if(tabfct, tabfct + sizeof(tabfct) / sizeof(funct), GetFunc::FindIt);
	if (p != tabfct + sizeof(tabfct) / sizeof(funct))
		p->func();

#ifdef _DEBUG
	system("pause");
#endif

	return EXIT_SUCCESS;
}