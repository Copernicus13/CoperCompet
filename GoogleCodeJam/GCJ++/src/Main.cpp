// Main.cpp�: d�finit le point d�entr�e pour l�application console.
//

#include <cstdlib>
#include <cstring>

#include "Prototypes.h"

typedef void (*PtrFonct_t)();
typedef struct { PtrFonct_t func; const char* name; } funct;

static const funct tabfct[] =
	{
		{ GoogleCodeJam::Practice::Problems::AlienNumbers , "AlienNumbers" },		// done
		{ GoogleCodeJam::Practice::Problems::AlwaysTurnLeft, "AlwaysTurnLeft" },	// done
		{ GoogleCodeJam::Practice::Problems::EggDrop, "EggDrop" },					// done with help
		{ GoogleCodeJam::Practice::Problems::ShoppingPlan, "ShoppingPlan" },		// done with help
		{ GoogleCodeJam::Practice::Beta2008::TriangleTrilemma, "TriangleTrilemma" },	// done
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
		{ GoogleCodeJam::Y2010::Africa::T9Spelling, "T9Spelling" },					// done
		{ GoogleCodeJam::Y2014::Qualification::MagicTrick, "MagicTrick" },			// done
		{ GoogleCodeJam::Y2014::Qualification::CookieClickerAlpha, "CookieClickerAlpha" },	// done
		{ GoogleCodeJam::Y2014::Qualification::MinesweeperMaster, "MinesweeperMaster" },
		{ GoogleCodeJam::Y2014::Qualification::DeceitfulWar, "DeceitfulWar" },
		{ GoogleCodeJam::Y2014::Round1A::ChargingChaos, "ChargingChaos" },
		{ GoogleCodeJam::Y2014::Round1A::FullBinaryTree, "FullBinaryTree" },
		{ GoogleCodeJam::Y2014::Round1A::ProperShuffle, "ProperShuffle" },
		{ GoogleCodeJam::Y2014::Round1B::TheRepeater, "TheRepeater" },
		{ GoogleCodeJam::Y2014::Round1B::NewLotteryGame, "NewLotteryGame" },
		{ GoogleCodeJam::Y2015::Qualification::StandingOvation, "StandingOvation" },
		{ GoogleCodeJam::Y2015::Qualification::InfiniteHouseOfPancakes, "InfiniteHouseOfPancakes" },
		{ GoogleCodeJam::Y2015::Qualification::Dijkstra, "Dijkstra" },
		{ GoogleCodeJam::Y2015::Qualification::OminousOmino, "OminousOmino" },
		{ GoogleCodeJam::Y2015::Round1A::MushroomMonster, "MushroomMonster" },
		{ GoogleCodeJam::Y2015::Round1A::Haircut, "Haircut" },
		{ GoogleCodeJam::Y2015::Round1A::Logging, "Logging" },
		{ GoogleCodeJam::Y2015::Round1B::CounterCulture, "CounterCulture" },
		{ GoogleCodeJam::Y2015::Round1B::NoisyNeighbors, "NoisyNeighbors" },
		{ GoogleCodeJam::Y2015::Round1B::HikingDeer, "HikingDeer" },
		{ GoogleCodeJam::Y2015::Round1C::Brattleship, "Brattleship" },
		{ GoogleCodeJam::Y2015::Round1C::TypewriterMonkey, "TypewriterMonkey" },
		{ GoogleCodeJam::Y2015::Round1C::LessMoneyMoreProblems, "LessMoneyMoreProblems" }
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