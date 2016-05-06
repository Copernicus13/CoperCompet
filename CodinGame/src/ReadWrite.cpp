#include <iostream>
#include <string>

using std::string;

int main()
{
	int n1, n2;
	std::cin >> n1 >> n2;
	
	string s, w1, w2;

    std::cin.ignore();
	std::getline(std::cin, s);
	std::cin >> w1 >> w2;

    if (s.size() == n1 + n2)
    {
		std::cout << w1 << std::endl;
	}
	else
	{
	    std::cout << w2 << std::endl;
	}
	
	return 0;
}