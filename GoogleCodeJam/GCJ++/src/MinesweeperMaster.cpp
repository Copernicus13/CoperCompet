#if 1

#include "Prototypes.h"

typedef std::vector< std::vector<char> > tab_t;

static void init(tab_t &tab, unsigned int R, unsigned int C)
{
	for (tab_t::size_type i (0); i < R; ++i)
	{
		tab[i].resize(C);
		for (tab_t::value_type::size_type j (0); j < C; ++j)
			tab[i][j] = '*';
	}
}

static void create1(tab_t &tab, unsigned int R, unsigned int C, unsigned int e)
{
	init(tab, R, C);

	tab[0][0] = 'c';
	unsigned int y (0), z (1);
	for (int i1 (0), i2 (e - 1); i1 < i2; ++i1)
	{
		bool u (false);
		for (int j (z); j >= 0; --j)
		{
			if (tab[y][j] == '*')
			{
				u = true;
				tab[y][j] = '.';
				if (!j && z < C - 1)
				{
					y = 0;
					++z;
				}
				break;
			}
		}
		if (!u)
		{
			++y;
			--i1;
		}
	}
}

static void create2(tab_t &tab, unsigned int R, unsigned int C, unsigned int e)
{
	init(tab, R, C);

	tab[0][0] = 'c';
	unsigned int y (0), z (1);
	for (int i1 (0), i2 (e - 1); i1 < i2; ++i1)
	{
		bool u (false);
		for (unsigned int j (0); j <= z; ++j)
		{
			if (tab[y][j] == '*')
			{
				u = true;
				tab[y][j] = '.';
				if (j == z && y < R - 1)
					++y;
				break;
			}
		}
		if (!u)
		{
			y = 0;
			++z;
			--i1;
		}
	}
}

static void create3(tab_t &tab, unsigned int R, unsigned int C, unsigned int e)
{
	init(tab, R, C);

	tab[0][0] = 'c';
	unsigned int x (0), y (0), z (1);
	for (int i1 (0), i2 (e - 1); i1 < i2; ++i1, y = x)
	{
		bool u (false);
		for (int j (z); j >= 0; --j)
		{
			if (tab[y][j] == '*')
			{
				u = true;
				tab[y][j] = '.';
				break;
			}
			if (y < R - 1)
				++y;
		}
		if (!u)
		{
			if (z < C - 1)
				++z;
			else
				++x;
			--i1;
		}
	}
}

static void enrich(tab_t &tab)
{
	for (tab_t::size_type i (0); i < tab.size(); ++i)
		for (tab_t::value_type::size_type j (0); j < tab[i].size(); ++j)
			if (tab[i][j] == '*')
				for (int k (-1); k <= 1; ++k)
					for (int l (-1); l <= 1; ++l)
						try
						{
							if (tab.at(i + k).at(j + l) == 'c')
								tab.at(i + k).at(j + l) = 'B';
							else if (tab.at(i + k).at(j + l) != '*' && tab.at(i + k).at(j + l) != 'B')
								tab.at(i + k).at(j + l) = 'A';
						}
						catch (...) { }
}

static bool isvalid(const tab_t &tab, unsigned int nb, unsigned int M)
{
	bool res;
	for (tab_t::size_type i (0); i < tab.size(); ++i)
		for (tab_t::value_type::size_type j (0); j < tab[i].size(); ++j)
			if (tab[i][j] == 'A' || tab[i][j] == 'B')
			{
				res = false;
				for (int k (-1); k <= 1; ++k)
					for (int l (-1); l <= 1; ++l)
						try
						{
							if (tab.at(i + k).at(j + l) == '.' || tab.at(i + k).at(j + l) == 'c')
								res = true;
						}
						catch (...) { }
				if (!res && nb - 1 != M)
					return false;
			}

	return true;
}

static void display(tab_t &tab, unsigned int swapped)
{
	for (tab_t::size_type i (0); i < tab.size(); ++i)
		for (tab_t::value_type::size_type j (0); j < tab[i].size(); ++j)
			if (tab[i][j] == 'A')
				tab[i][j] = '.';
			else if (tab[i][j] == 'B')
				tab[i][j] = 'c';

	if (!swapped)
		for (tab_t::const_iterator i1 (tab.begin()), i2 (tab.end()); i1 != i2; ++i1)
		{
			for (tab_t::value_type::const_iterator j1 (i1->begin()), j2 (i1->end()); j1 != j2; ++j1)
				std::cout << *j1;
			std::cout << std::endl;
		}
	else
		for (tab_t::value_type::size_type j (0); j < tab[0].size(); ++j)
		{
			for (tab_t::size_type i (0); i < tab.size(); ++i)
				std::cout << tab[i][j];
			std::cout << std::endl;
		}
}

void GoogleCodeJam::Y2014::Qualification::MinesweeperMaster()
{
	unsigned int nbCases;

	std::cin >> nbCases;
	assert(nbCases >= 1 && nbCases <= 230);

	for (unsigned int a (1); a <= nbCases; ++a)
	{
		unsigned int R, C, M, swapped (0);
		std::cin >> R >> C >> M;
		assert(R >= 1 && R <= 50);
		assert(C >= 1 && C <= 50);
		unsigned int nb (R * C), e (nb - M);
		assert(M >= 0 && M < nb);

		std::cout << "Case #" << a << ':' << std::endl;

		if (C == 1 && R == 1)
		{
			std::cout << 'c' << std::endl;
			continue;
		}
		else if (R == 1)
		{
			if (M > 0)
				std::cout << std::setfill('*') << std::setw(M) << '*';
			if (e - 1 > 0)
				std::cout << std::setfill('.') << std::setw(e - 1) << '.';
			std::cout << 'c' << std::endl;
			continue;
		}
		else if (C == 1)
		{
			for (unsigned int b (0); b < M; ++b)
				std::cout << '*' << std::endl;
			for (unsigned int b (0); b < e - 1; ++b)
				std::cout << '.' << std::endl;
			std::cout << 'c' << std::endl;
			continue;
		}

		if (R < C)
		{
			std::swap(R, C);
			swapped = 1;
		}

		tab_t tab (R);

		create1(tab, R, C, e);
		enrich(tab);

		if (!isvalid(tab, nb, M))
		{
			create2(tab, R, C, e);
			enrich(tab);
		}

		if (!isvalid(tab, nb, M))
		{
			create3(tab, R, C, e);
			enrich(tab);
		}

		if (!isvalid(tab, nb, M))
		{
			//if (swapped)
			//	std::clog << "R: " << C << " ; C: " << R;
			//else
			//	std::clog << "R: " << R << " ; C: " << C;

			//std::clog << " ; M: " << M << " ; nb: " << nb
			//		  << " ; e: " << e << " ; swapped: " << swapped << std::endl;

			std::cout << "Impossible" << std::endl;
			continue;
		}

		display(tab, swapped);
	}
}

#else

#define _CRT_SECURE_NO_WARNINGS

#include "Prototypes.h"

using namespace std;

vector <string> solve(int r, int c, int m) {
  string w = "";
  for (int j = 0; j < c; j++) w += ".";
  vector <string> ret;
  for (int i = 0; i < r; i++) ret.push_back(w);
  if (m == 0) {
    ret[0][0] = 'c';
    return ret;
  }
  if (m == r * c - 1) {
    for (int i = 0; i < r; i++)
      for (int j = 0; j < c; j++) ret[i][j] = '*';
    ret[0][0] = 'c';
    return ret;
  }
  if (r == 1) {
    for (int j = 0; j < m; j++) ret[0][j] = '*';
    ret[0][c - 1] = 'c';
    return ret;
  }
  if (m >= r * c - 3) {
    return vector <string>();
  }
  if (r == 2) {
    if (m % 2 == 1) {
      return vector <string>();
    }
    for (int i = 0; i < 2; i++)
      for (int j = 0; j < m / 2; j++) ret[i][j] = '*';
    ret[0][c - 1] = 'c';
    return ret;
  }
  for (int i = 0; i < r; i++)
    for (int j = 0; j < c; j++) ret[i][j] = '*';
  m = r * c - m;
  if (m == 5 || m == 7) {
    return vector <string>();
  }
  if (m == 2 * r + 1) {
    for (int i = 0; i < r - 1; i++)
      for (int j = 0; j < m / r; j++) ret[i][j] = '.';
    ret[0][m / r] = '.';
    ret[1][m / r] = '.';
    ret[2][m / r] = '.';
    ret[0][0] = 'c';
    return ret;
  }
  if (m >= 2 * r) {
    for (int i = 0; i < r; i++)
      for (int j = 0; j < m / r; j++) ret[i][j] = '.';
    for (int i = 0; i < m % r; i++) ret[i][m / r] = '.';
    if (m % r == 1) {
      ret[1][m / r] = '.';
      ret[r - 1][m / r - 1] = '*';
    }
    ret[0][0] = 'c';
    return ret;
  }
  if (m % 2 == 0) {
    for (int i = 0; i < m / 2; i++)
      for (int j = 0; j < 2; j++) ret[i][j] = '.';
    ret[0][0] = 'c';
    return ret;
  }
  for (int i = 0; i < (m - 3) / 2; i++)
    for (int j = 0; j < 2; j++) ret[i][j] = '.';
  ret[0][2] = '.';
  ret[1][2] = '.';
  ret[2][2] = '.';
  ret[0][0] = 'c';
  return ret;
}

void GoogleCodeJam::Y2014::Qualification::MinesweeperMaster()
{
  int tt;
  scanf("%d", &tt);
  for (int qq=1;qq<=tt;qq++) {
    printf("Case #%d:\n", qq);
    int r, c, m;
    scanf("%d %d %d", &r, &c, &m);
    vector <string> ret;
    if (r <= c) {
      ret = solve(r, c, m);
    } else {
      vector <string> temp = solve(c, r, m);
      if (!temp.empty()) {
        for (int i = 0; i < r; i++) {
          string w = "";
          for (int j = 0; j < c; j++) w += temp[j][i];
          ret.push_back(w);
        }
      }
    }
    if (ret.empty()) {
      puts("Impossible");
    } else {
      int cs = 0, cc = 0;
      for (int i = 0; i < r; i++)
        for (int j = 0; j < c; j++)
          if (ret[i][j] == 'c') cc++; else
          if (ret[i][j] == '*') cs++;
      if (cc != 1 || cs != m) {
        cerr << "ERROR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! at test " << qq << ": " << r << " " << c << " " << m << endl;
      }
      for (int i = 0; i < r; i++) printf("%s\n", ret[i].c_str());
    }
  }
}

#endif