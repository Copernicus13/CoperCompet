#include "Prototypes.h"

const double PI  = std::acos(-1.0);
const double EPS = 1.0e-5;

typedef struct { short x, y; double getNorm() { return std::sqrt(static_cast<double>(x) * x + y * y); } } point_t;

static double getNorm(point_t const &a, point_t const &b)
{
	return std::sqrt(std::pow(static_cast<double>(b.x) - a.x, 2) + std::pow(static_cast<double>(b.y) - a.y, 2));
}

template<typename T>
inline static double myacos(T x) { return std::acos(static_cast<double>(x)) * 180 / PI; }

template<typename T>
inline static double mypow(T x, int y) { return std::pow(static_cast<double>(x), y); }

template<typename T>
inline static bool isnan(T x) { return x != x; }

void GoogleCodeJam::Practice::Beta2008::TriangleTrilemma()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		std::cout << "Case #" << a << ": ";
		point_t p1, p2, p3;
		std::cin >> p1.x >> p1.y >> p2.x >> p2.y >> p3.x >> p3.y;
		assert(p1.x >= -1000 && p1.x <= 1000);
		assert(p1.y >= -1000 && p1.y <= 1000);
		assert(p2.x >= -1000 && p2.x <= 1000);
		assert(p2.y >= -1000 && p2.y <= 1000);
		assert(p3.x >= -1000 && p3.x <= 1000);
		assert(p3.y >= -1000 && p3.y <= 1000);

		double b (getNorm(p1, p2)),
			   c (getNorm(p1, p3)),
			   d (getNorm(p2, p3)),
			   alpha (myacos((c * c + d * d - b * b) / (2 * c * d))),
			   beta  (myacos((d * d + b * b - c * c) / (2 * d * b))),
			   gamma (myacos((b * b + c * c - d * d) / (2 * b * c)));

		if (std::abs(alpha - 180) < EPS || std::abs(beta - 180) < EPS || std::abs(gamma - 180) < EPS ||
			isnan(alpha) || isnan(beta) || isnan(gamma))
		{
			std::cout << "not a triangle" << std::endl;
			continue;
		}

		if (std::abs(b - c) < EPS || std::abs(c - d) < EPS || std::abs(b - d) < EPS)	// angle 1 == angle 2
			std::cout << "isosceles ";
		else
			std::cout << "scalene ";

		if (90 - alpha > EPS && 90 - beta > EPS && 90 - gamma > EPS)	// angles < 90
			std::cout << "acute";
		else if (std::abs(alpha - 90) < EPS || std::abs(beta - 90) < EPS || std::abs(gamma - 90) < EPS)	// angles == 90
			std::cout << "right";
		else
			std::cout << "obtuse";

		std::cout << " triangle" << std::endl;
	}
}
