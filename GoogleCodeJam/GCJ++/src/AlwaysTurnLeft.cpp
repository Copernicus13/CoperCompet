#include <iostream>
#include <string>
#include <cstring>
#include <vector>
#include <array>
#include <algorithm>
#include <cassert>

#include "Prototypes.h"

const int SIZE_MAT = 11000;

#define tabd tab->data()

typedef std::vector<char> list_t;
typedef std::array<std::array<char, SIZE_MAT>, 2 * SIZE_MAT> tab_t;

static void tighten(tab_t *tab, int &x, int &y, int &dir, char actual)
{
	switch (dir)
	{
	  case 0:
		switch (actual)
		{
		  case 'R':
			dir = 3;
			break;
		  case 'L':
			dir = 2;
			break;
		  case 'W':
			tabd[x][y] |= 1;
			--y;
			break;
		}
		break;
	  case 1:
		switch (actual)
		{
		  case 'R':
			dir = 2;
			break;
		  case 'L':
			dir = 3;
			break;
		  case 'W':
			tabd[x][y] |= 2;
			++y;
			break;
		}
		break;
	  case 2:
		switch (actual)
		{
		  case 'R':
			dir = 0;
			break;
		  case 'L':
			dir = 1;
			break;
		  case 'W':
			tabd[x][y] |= 4;
			--x;
			break;
		}
		break;
	  case 3:
		switch (actual)
		{
		  case 'R':
			dir = 1;
			break;
		  case 'L':
			dir = 0;
			break;
		  case 'W':
			tabd[x][y] |= 8;
			++x;
			break;
		}
		break;
	}
}

static tab_t* createmaze(list_t const &going, list_t const &coming)
{
	int x = SIZE_MAT, y = 0, dir = 1;
	tab_t *tab = new tab_t();
	std::memset(tab, 0, SIZE_MAT * SIZE_MAT << 1);
	tabd[x][y] = 1;
	for (list_t::const_iterator a (going.begin() + 1); a != going.end(); ++a)
	{
		tighten(tab, x, y, dir, *a);
	}
	tighten(tab, x, y, dir, 'R');
	tighten(tab, x, y, dir, 'R');
	int saved_x (x), saved_y (y);
	for (list_t::const_iterator a (coming.begin()); a != coming.end(); ++a)
	{
		tighten(tab, x, y, dir, *a);
	}
	tabd[saved_x][saved_y] = 0;
	return tab;
}

static void displaymaze(tab_t* tab)
{
	tab_t::size_type x;
	for (x = SIZE_MAT; tabd[x][0]; --x)
		;
	int saved_x (++x);
	for (tab_t::value_type::size_type y (0); y < SIZE_MAT && tabd[saved_x][y]; ++y)
	{
		for (x = saved_x; tabd[x][0]; ++x)
			std::cout << static_cast<char>(tabd[x][y] > 9 ? 'a' + tabd[x][y] - 10 : '0' + tabd[x][y]);
		std::cout << std::endl;
	}
}

void GoogleCodeJam::Practice::Problems::AlwaysTurnLeft()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 100);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		list_t going, coming;
		string s;
		std::cin >> s;
		going.resize(s.size());
		std::copy(s.begin(), s.end(), going.begin());
		std::cin >> s;
		coming.resize(s.size());
		std::copy(s.begin(), s.end(), coming.begin());

		std::cout << "Case #" << a << ':' << std::endl;

		tab_t *tab = createmaze(going, coming);
		displaymaze(tab);
		delete tab;
	}
}
